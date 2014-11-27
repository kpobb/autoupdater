using System;
using System.IO;
using System.ServiceModel;

namespace AutoupdaterService
{
    [ServiceContract]
    public interface IAutoupdaterService
    {
        [OperationContract]
        ServiceResponse UpdateApplication(ServiceRequest appId);
    }

    [MessageContract]
    public class ServiceRequest
    {
        [MessageHeader]
        public string AppId { get; set; }
    }

    [MessageContract]
    public class ServiceResponse : IDisposable
    {
        [MessageHeader]
        public string ApplicationName { get; private set; }

        [MessageHeader]
        public string ApplicationId { get; private set; }

        [MessageHeader]
        public long Length { get; private set; }

        [MessageBodyMember]
        public Stream FileStream { get; private set; }

        public void Dispose()
        {
            if (FileStream != null)
            {
                FileStream.Close();
                FileStream = null;
            }
        }

        public static ServiceResponse Create(string filePath, string applicationId)
        {
            var stream = StreamHelper.ConvertToStream(filePath);
            
            return new ServiceResponse
            {
                ApplicationId = applicationId,
                ApplicationName = Path.GetFileName(filePath),
                FileStream = stream,
                Length = stream.Length
            };
        }
    }
}