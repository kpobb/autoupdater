using System.Runtime.Serialization;

namespace AutoupdaterService.Entities
{
    [DataContract]
    public class File
    {
        [DataMember]
        public byte[] Source { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
