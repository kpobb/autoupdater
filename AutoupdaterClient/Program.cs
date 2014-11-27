using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using AutoupdaterService;
using AutoupdaterService.Entities;

namespace AutoupdaterClient
{
    class Program
    {
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            try
            {
                var response = ExecuteUpdate();

                ExtractZipFile(response, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "new"));

                SelfUpdateApplication(AppDomain.CurrentDomain.BaseDirectory,
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "new"), "AutoupdaterClient.exe");
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            { 
            }

            Console.WriteLine("Click any buttons..");
            Console.ReadKey();
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AutoupdaterClient.lib.AutoupdaterService.dll"))
            {
                // ReSharper disable once PossibleNullReferenceException
                var assemblyData = new byte[stream.Length];

                stream.Read(assemblyData, 0, assemblyData.Length);

                return Assembly.Load(assemblyData);
            }
        }

        private static ServiceResponse ExecuteUpdate()
        {
            var binder = new BasicHttpBinding { MaxReceivedMessageSize = 3145728 };
            var factory = new ChannelFactory<IAutoupdaterService>(binder, "http://localhost:1989");
            var service = factory.CreateChannel();

            return service.UpdateApplication("BwinScriptUpdater");
        }

        private static void ExtractZipFile(ServiceResponse response, string destPath)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), response.ApplicationName);

            File.WriteAllBytes(tempPath, response.File);

            var dirInfo = new DirectoryInfo(destPath);

            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            var files = dirInfo.GetFiles();

            if (files.Any())
            {
                foreach (var file in files)
                {
                    file.Delete();
                }
            }

            ZipFile.ExtractToDirectory(tempPath, destPath);

            File.Delete(tempPath);
        }

        private static void SelfUpdateApplication(string currentAppPath, string newAppPath, string appName)
        {
            var cmd = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = string.Format("/C TIMEOUT 3 & MOVE /Y \"{0}\"\\* \"{1}\" & RD /Q \"{0}\" & START /D \"{1}\" {2}", newAppPath, currentAppPath, appName),
                    CreateNoWindow = true
                }
            };
            cmd.Start();

            Environment.Exit(0);
        }
    }
}