using System;
using System.IO;
using System.IO.Compression;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Xml;
using AutoupdaterService.Entities;
using AutoupdaterService.Extensions;

namespace AutoupdaterService
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class AutoupdaterService : IAutoupdaterService
    {
        public UpdateResponse UpdateApplication(string applicationId)
        {
            var applicationRoot = GetApplicationDirectory(applicationId);

            var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".zip");

            try
            {
                ZipFile.CreateFromDirectory(applicationRoot, tempPath);
            }
            catch { }

            var response = new UpdateResponse(applicationId, tempPath);

            File.Delete(tempPath);

            return response;
        }

        public bool HasUpdates(string applicationId, Version version)
        {
            var app = ParseConfig(applicationId);

            if (app == null)
                return false;

            return app.Version > version;
        }

        private string GetApplicationDirectory(string applicationId)
        {
            var applicationRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", applicationId);

            if (!Regex.IsMatch(applicationId, "a-zA-Z0-9") && !Directory.Exists(applicationRoot))
            {
                throw new Exception("Application was not found.");
            }

            return applicationRoot;
        }

        private static ApplicationXml ParseConfig(string applicationId)
        {
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update.xml");

            var doc = new XmlDocument();
            doc.Load(configPath);

            var root = doc.DocumentElement;

            if (root == null)
            {
                return null;
            }

            var node = root.SelectSingleNode("/Applications/Application[Id='" + applicationId + "']");

            if (node == null)
            {
                return null;
            }

            return new ApplicationXml
            {
                Id = node.GetValueOrDefault("Id"),
                Name = node.GetValueOrDefault("Name"),
                Path = node.GetValueOrDefault("Path"),
                Version = Version.Parse(node.GetValueOrDefault("Version", "0.0.0"))
            };
        }
    }
}