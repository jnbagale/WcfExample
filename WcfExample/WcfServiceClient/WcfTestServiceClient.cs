using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using WcfService;

namespace WcfServiceClient
{
    public class WcfTestServiceClient : ClientBase<IWcfTestService>, IWcfTestService
    {
        public WcfTestServiceClient() : base()
        {
        }

        public WcfTestServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        {
        }

        public object TestService(object param)
        {
            return base.Channel.TestService(param);
        }

        /// <summary>
        ///  serviceName, address (ip), port number must match the values used on server side
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="serverAddress"></param>
        /// <param name="serverPortNumber"></param>
        /// <param name="serviceTimeoutInSeconds"></param>
        /// <returns></returns>
        public static WcfTestServiceClient CreateWcfTestServiceClient(string serviceName, string serverAddress, string serverPortNumber, int serviceTimeoutInSeconds = 60)
        {
            try
            {
                bool useReliableSession = true;

                Binding binding = WcfHelper.GetServiceBinding(true, serviceTimeoutInSeconds, useReliableSession);

                string uri = string.Format("net.tcp://{0}:{1}/{2}", serverAddress, serverPortNumber, serviceName);
                EndpointAddress ep = new EndpointAddress(uri);

                return new WcfTestServiceClient(binding, ep);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when creating WcfClient\n" + ex);
                return null;
            }
        }
    }
}
