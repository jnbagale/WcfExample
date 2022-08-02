using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using WcfService;

namespace WcfServiceClient
{
    public class WcfWeatherServiceClient : DuplexClientBase<IWcfWeatherService>, IWcfWeatherService
    {
        public WcfWeatherServiceClient(InstanceContext callbackInstance)
        : base(callbackInstance)
        {
        }

        public WcfWeatherServiceClient(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress) :
        base(callbackInstance, binding, remoteAddress)
        {
            //this.Endpoint.EndpointBehaviors.Add();
        }
        
        public IAsyncResult BeginReportWeatherInfo(int stationId, double temp, AsyncCallback callback, object state)
        {
            return base.Channel.BeginReportWeatherInfo(stationId, temp, callback, state);
        }

        public bool EndReportWeatherInfo(IAsyncResult result)
        {
            return base.Channel.EndReportWeatherInfo(result);
        }

        /// <summary>
        ///  serviceName, address (ip), port number must match the values used on server side
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="serverAddress"></param>
        /// <param name="serverPortNumber"></param>
        /// <param name="serviceTimeoutInSeconds"></param>
        /// <returns></returns>
        public static WcfWeatherServiceClient CreateWcfWeatherServiceClient(IWeatherContractCallback wcc, string serviceName, string serverAddress, string serverPortNumber, int serviceTimeoutInSeconds = 60)
        {
            try
            {
                bool useReliableSession = true;

                Binding binding = WcfHelper.GetServiceBinding(true, serviceTimeoutInSeconds, useReliableSession);

                string uri = string.Format("net.tcp://{0}:{1}/{2}", serverAddress, serverPortNumber, serviceName);
                EndpointAddress ep = new EndpointAddress(uri);

                return new WcfWeatherServiceClient(new InstanceContext(wcc), binding, ep);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when creating WcfClient\n" + ex);
                return null;
            }
        }
    }
}
