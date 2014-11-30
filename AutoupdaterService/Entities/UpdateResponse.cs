using System.IO;
using System.Runtime.Serialization;

namespace AutoupdaterService.Entities
{
    [DataContract]
    public class UpdateResponse
    {
        public UpdateResponse(string applicationId, string filePath)
        {
            ApplicationId = applicationId;

            FileData = new FileData
            {
                Bytes = StreamHelper.ConvertToBytes(filePath),
                Name = Path.GetFileName(filePath),
            };
        }

        [DataMember]
        public string ApplicationId { get; private set; }

        [DataMember]
        public FileData FileData { get; private set; } 
    }
}