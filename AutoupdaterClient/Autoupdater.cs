using System.IO;
using System.ServiceModel;
using AutoupdaterService;

namespace AutoupdaterClient
{
    public class Autoupdater
    {
        private readonly IUpdatable _application;
        private readonly ZipExtractor _zip;
        private readonly IAutoupdaterService _autoupdaterService;

        public Autoupdater(IUpdatable application)
        {
            _application = application;
            _zip = new ZipExtractor();

            var binder = new BasicHttpBinding { MaxReceivedMessageSize = 3145728 };
            var factory = new ChannelFactory<IAutoupdaterService>(binder, "http://localhost:1989");
            _autoupdaterService = factory.CreateChannel();
        }

        public bool HasUpdates()
        {
            return false;
        }

        public void Update()
        {
            var response = _autoupdaterService.UpdateApplication(_application.ApplicationId);

            var destDir = Path.Combine(_application.ApplicationPath, "new");

            _zip.Extract(response.FileData.Bytes, destDir, response.FileData.Name);

            SelfUpdator.Update(destDir, _application.ApplicationName);
        }
    }
}