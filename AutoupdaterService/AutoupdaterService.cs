using System;
using System.IO;
using System.IO.Compression;
using System.ServiceModel;
using AutoupdaterService.Entities;

namespace AutoupdaterService
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class AutoupdaterService : IAutoupdaterService
    {
        public ServiceResponse UpdateApplication(string applicationId)
        {
            var applicationRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", applicationId);

            var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".zip");

            try
            {
                ZipFile.CreateFromDirectory(applicationRoot, tempPath);
            }
            catch { }

            var response = ServiceResponse.Create(tempPath, applicationId);

            File.Delete(tempPath);

            return response;
        }       
    }
}