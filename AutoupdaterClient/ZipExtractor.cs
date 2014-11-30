using System.IO;
using System.IO.Compression;
using System.Linq;

namespace AutoupdaterClient
{
    internal class ZipExtractor
    {
        public void Extract(byte[] file, string destPath, string fileName)
        {
            CreateDirectory(destPath);

            var tempPath = SaveZipToTempDirectory(file, fileName);

            ExtractZipToDirectory(tempPath, destPath);
        }

        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                CleanUpDirectory(path);
            }
        }

        private void CleanUpDirectory(string path)
        {
            var files = new DirectoryInfo(path).GetFiles();

            if (files.Any())
            {
                foreach (var file in files)
                {
                    file.Delete();
                }
            }
        }

        private string SaveZipToTempDirectory(byte[] bytes, string applicationName)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), applicationName);
            File.WriteAllBytes(tempPath, bytes);

            return tempPath;
        }

        private void ExtractZipToDirectory(string zipPath, string destPath)
        {
            ZipFile.ExtractToDirectory(zipPath, destPath);
            File.Delete(zipPath);
        }
    }
}
