using System.ServiceModel;
using Autoupdater.AutoupdaterService;

namespace Autoupdater
{
    public class AutoupdaterHandler
    {

        public AutoupdaterHandler(IUpdatableTool tool)
        {
            var binder = new BasicHttpBinding { MaxReceivedMessageSize = 3145728 };
            var factory = new ChannelFactory<IAutoupdaterService>(binder, "http://localhost:1989/Autoupdater.svc");
            var autoupdaterService = factory.CreateChannel();

            new AutoupdaterForm(autoupdaterService, tool);
        }
    }
}