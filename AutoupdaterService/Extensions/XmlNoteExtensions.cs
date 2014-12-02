using System.Xml;

namespace AutoupdaterService.Extensions
{
    public static class XmlNoteExtensions
    {
        public static string GetValueOrDefault(this XmlNode node, string key, string defaultValue = null)
        {
            var value = node[key];

            if (value != null)
            {
                return value.InnerText;
            }

            return defaultValue;
        }
    }
}