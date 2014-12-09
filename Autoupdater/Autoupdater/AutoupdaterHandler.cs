using System.IO;
using System.ServiceModel;
using Autoupdater.AutoupdaterService;

namespace Autoupdater
{
    public class AutoupdaterHandler
    {
        private readonly IUpdatableTool _tool;
        private readonly ZipHandler _zip = new ZipHandler();
        private readonly IAutoupdaterService _autoupdaterService;

        public AutoupdaterHandler(IUpdatableTool tool)
        {
            _tool = tool;

            var binder = new BasicHttpBinding { MaxReceivedMessageSize = 3145728 };
            var factory = new ChannelFactory<IAutoupdaterService>(binder, "http://localhost:1989/Autoupdater.svc");
            _autoupdaterService = factory.CreateChannel();
        }

        public void Update()
        {
            if (HasUpdate())
            {
                ForceUpdate();
            }
        }

        public bool HasUpdate()
        {
            return _autoupdaterService.HasUpdate(_tool.Id, _tool.Version);
        }

        public void ForceUpdate()
        {
            var response = _autoupdaterService.UpdateApplication(_tool.Id);

            var destDir = Path.Combine(_tool.Path, "new");

            _zip.Extract(response.File.Source, response.File.Name, destDir);

            SelfExtractor.Update(destDir, _tool.Name);

            Directory.Delete(destDir);
        }
    }
}