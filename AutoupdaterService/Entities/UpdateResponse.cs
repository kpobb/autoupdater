using System.IO;
using System.Runtime.Serialization;
using AutoupdaterService.Helpers;

namespace AutoupdaterService.Entities
{
    [DataContract]
    public class UpdateResponse
    {
        public UpdateResponse(string applicationId, string filePath)
        {
            ApplicationId = applicationId;

            File = new File
            {
                Source = StreamHelper.ConvertToBytes(filePath),
                Name = Path.GetFileName(filePath),
            };
        }

        [DataMember]
        public string ApplicationId { get; private set; }

        [DataMember]
        public File File { get; private set; } 
    }
}