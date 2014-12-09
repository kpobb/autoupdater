using System.Xml.Serialization;

namespace CodeFiscaleGenerator.Entities
{
    [XmlRoot(ElementName = "ConfigurableResponses", Namespace = "")]
    public class ConfigurableResponses
    {
        [XmlElement(ElementName = "ConfigurableResponse")]
        public ConfigurableResponse[] ConfigurableResponse { get; set; }
    }
}
