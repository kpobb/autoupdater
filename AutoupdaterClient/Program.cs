using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.ServiceModel;
using AutoupdaterService;

namespace AutoupdaterClient
{
    class Program
    {
        static void Main()
        {
            var binder = new BasicHttpBinding { MaxReceivedMessageSize = 3145728 };
            var factory = new ChannelFactory<IAutoupdaterService>(binder, "http://localhost:1989");
            var service = factory.CreateChannel();

            try
            {
                var response = service.UpdateApplication(new ServiceRequest { AppId = "BwinScriptUpdater" });

                ExtractZipFile(response, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "new"));

                response.FileStream.Dispose();

                SelfUpdateApplication(AppDomain.CurrentDomain.BaseDirectory,
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "new"), "AutoupdaterClient.exe");
            }
            catch { }

            //  Console.ReadKey();
        }

        private static void ExtractZipFile(ServiceResponse response, string destPath)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), response.ApplicationName);

            var bytes = StreamHelper.ConvertToBytes(response.FileStream);

            File.WriteAllBytes(tempPath, bytes);

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