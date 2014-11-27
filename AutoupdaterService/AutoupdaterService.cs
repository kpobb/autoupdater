using System;
using System.IO;
using System.IO.Compression;
using System.ServiceModel;

namespace AutoupdaterService
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class AutoupdaterService : IAutoupdaterService
    {
        public ServiceResponse UpdateApplication(ServiceRequest request)
        {
            var applicationRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", request.AppId);

            var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".zip");

            try
            {
                ZipFile.CreateFromDirectory(applicationRoot, tempPath);
            }
            catch { }

            var response = ServiceResponse.Create(tempPath, request.AppId);

            File.Delete(tempPath);

            return response;
        }       
    }
}