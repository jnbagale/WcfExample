using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;

namespace WcfService
{

    public class Host
    {
        public ServiceHost srvcHost;
        public Host()
        {
        }

        public bool HostTcpService(Type serviceInterface, object serviceInstance, string hostIP, string port, string servicename, bool useReliableSession = true)
        {
            string baseAddress = string.Format("net.tcp://{0}:{1}/{2}", hostIP, port, servicename);

            bool IsHosted = false;
            Uri uriBase = new Uri(baseAddress);

            try
            {
                srvcHost = new ServiceHost(serviceInstance, uriBase);

                Binding tcpBinding = WcfHelper.GetServiceBinding(false, 0, useReliableSession);

                // Set SendTimeout to avoid client crashes to cause the callback to hang forever
                tcpBinding.SendTimeout = new TimeSpan(0, 0, 0, 60);

                CustomBinding cb = new CustomBinding(new TcpTransportBindingElement());

                ServiceMetadataBehavior meta = new ServiceMetadataBehavior();
                meta.HttpGetEnabled = false;

                srvcHost.Description.Behaviors.Add(meta);

                ServiceEndpoint serviceEndpoint = srvcHost.AddServiceEndpoint(serviceInterface, tcpBinding, uriBase);

                srvcHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

                // Add a ServiceDiscoveryBehavior
                srvcHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());

                // Add a UdpDiscoveryEndpoint
                srvcHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());

                srvcHost.Open();

                IsHosted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                IsHosted = false;
            }

            return IsHosted;
        }


        public bool IsOpen
        {
            get { return (srvcHost.State == CommunicationState.Opened); }
        }

        public bool IsClosed
        {
            get { return (srvcHost.State == CommunicationState.Closed); }
        }

        public bool IsFaulted
        {
            get { return (srvcHost.State == CommunicationState.Faulted); }
        }

        public void Close()
        {
            if (srvcHost != null && IsOpen)
            {
                srvcHost.Close();
            }
        }
    }
}
