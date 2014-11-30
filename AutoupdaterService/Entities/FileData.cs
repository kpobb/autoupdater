using System.Runtime.Serialization;

namespace AutoupdaterService.Entities
{
    [DataContract]
    public class FileData
    {
        [DataMember]
        public byte[] Bytes { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
