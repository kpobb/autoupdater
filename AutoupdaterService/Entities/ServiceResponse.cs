using System.IO;
using System.Runtime.Serialization;

namespace AutoupdaterService.Entities
{
    [DataContract]
    public class ServiceResponse
    {
        [DataMember]
        public string ApplicationName { get; private set; }

        [DataMember]
        public string ApplicationId { get; private set; }

        [DataMember]
        public long Length { get; private set; }

        [DataMember]
        public byte[] File { get; private set; } 

        public static ServiceResponse Create(string filePath, string applicationId)
        {
            var file = StreamHelper.ConvertToBytes(filePath);
            
            return new ServiceResponse
            {
                ApplicationId = applicationId,
                ApplicationName = Path.GetFileName(filePath),
                File = file,
                Length = file.Length
            };
        }
    }
}