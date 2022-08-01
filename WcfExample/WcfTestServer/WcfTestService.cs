using System.ServiceModel;
using System.Threading;
using WcfService;

namespace WcfServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true, AddressFilterMode = AddressFilterMode.Any)]
    class WcfTestService : IWcfTestService
    {
        internal Host Host { get; set; }

        public object TestService(object param)
        {
            Thread.Sleep(1000);

            if (param is string && ((string)param == "Ping"))
                return "Pong";
            else
                return "Do we know each other?";
        }
    }
}
