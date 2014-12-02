using System.IO;
using System.ServiceModel;
using AutoupdaterService;

namespace AutoupdaterClient
{
    public class Autoupdater
    {
        private readonly IUpdatableApplication _application;
        private readonly ZipExtractor _zip;
        private readonly IAutoupdaterService _autoupdaterService;

        public Autoupdater(IUpdatableApplication application)
        {
            _application = application;
            _zip = new ZipExtractor();

            var binder = new BasicHttpBinding { MaxReceivedMessageSize = 3145728 };
            var factory = new ChannelFactory<IAutoupdaterService>(binder, "http://localhost:1989");
            _autoupdaterService = factory.CreateChannel();
        }

        public bool HasUpdates()
        {
            return _autoupdaterService.HasUpdates(_application.Id, _application.Version);
        }

        public void Update()
        {
            var response = _autoupdaterService.UpdateApplication(_application.Id);

            var destDir = Path.Combine(_application.Path, "new");

            _zip.Extract(response.FileData.Bytes, destDir, response.FileData.Name);

            SelfUpdator.Update(destDir, _application.Name);

            Directory.Delete(destDir);
        }

        public void ForceUpdate()
        {
            if (HasUpdates())
            {
                Update();
            }
        }
    }
}