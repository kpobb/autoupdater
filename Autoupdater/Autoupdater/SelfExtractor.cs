using System;
using System.Diagnostics;

namespace Autoupdater
{
    internal class SelfExtractor
    {
        public static void Update(string destPath, string applicationName)
        {
            if (string.IsNullOrWhiteSpace(applicationName))
            {
                return;
            }

            var cmd = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = string.Format("/C TIMEOUT 3 & MOVE /Y \"{0}\"\\* \"{1}\" & RD /Q \"{0}\" & START /D \"{1}\" {2}",
                                              destPath, AppDomain.CurrentDomain.BaseDirectory, applicationName),
                    CreateNoWindow = true
                }
            };
            cmd.Start();

            Environment.Exit(0);
        }
    }
}