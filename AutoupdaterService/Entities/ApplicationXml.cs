using System;

namespace AutoupdaterService.Entities
{

    public class ApplicationXml
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Version Version { get; set; }
    }
}