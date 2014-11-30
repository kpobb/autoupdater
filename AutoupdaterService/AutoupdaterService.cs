using System;
using System.IO;
using System.IO.Compression;
using System.ServiceModel;
using System.Text.RegularExpressions;
using AutoupdaterService.Entities;

namespace AutoupdaterService
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class AutoupdaterService : IAutoupdaterService
    {
        public UpdateResponse UpdateApplication(string applicationId)
        {
            var applicationRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", applicationId);

            if (!Regex.IsMatch(applicationId, "a-zA-Z0-9") && !Directory.Exists(applicationRoot))
            {
                throw new Exception("Application was not found.");
            }

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
    }
}