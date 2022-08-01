using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace WcfService
{
    public class WcfHelper
    {
        public static Binding GetServiceBinding(bool isClient, int testServiceTimeoutSeconds, bool useReliableSession = true)
        {
            try
            {
                NetTcpBinding binding = new NetTcpBinding()
                {
                    MaxReceivedMessageSize = (long)2147483647,
                    MaxBufferPoolSize = (long)2147483647,
                    MaxBufferSize = 2147483647,

                    SendTimeout = (testServiceTimeoutSeconds == 0) ? TimeSpan.MaxValue : new TimeSpan(0, 0, 0, testServiceTimeoutSeconds),
                    ReceiveTimeout = TimeSpan.MaxValue,
                    CloseTimeout = TimeSpan.MaxValue,
                    OpenTimeout = TimeSpan.MaxValue,
                };

                if (isClient)
                {
                    binding.ListenBacklog = 2147483647;
                    binding.Security.Message.ClientCredentialType = MessageCredentialType.None;
                    binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.None;
                    binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
                    binding.PortSharingEnabled = false;
                    binding.TransactionFlow = false;
                }

                binding.Security.Mode = SecurityMode.None;

                if (useReliableSession)
                    binding.ReliableSession.Enabled = true;

                XmlDictionaryReaderQuotas myReaderQuotas = new XmlDictionaryReaderQuotas()
                {
                    MaxDepth = 2147483647,
                    MaxStringContentLength = 2147483647,
                    MaxArrayLength = 2147483647,
                    MaxBytesPerRead = 2147483647,
                    MaxNameTableCharCount = 2147483647
                };

                binding.GetType().GetProperty("ReaderQuotas").SetValue(binding, myReaderQuotas, null);

                if (useReliableSession)
                {
                    return CreateBindingWith_MaxPendingChannels_Set(binding);
                }
                else
                    return binding;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.Source + ex.InnerException);
                return null;
            }
        }

        private static Binding CreateBindingWith_MaxPendingChannels_Set(Binding baseBinding)
        {
            ReliableSessionBindingElement reliableSessionElement = baseBinding.CreateBindingElements().Find<ReliableSessionBindingElement>();

            if (reliableSessionElement == null)
            {
                throw new Exception("the base binding does not have ReliableSessionBindingElement");
            }

            CustomBinding customBinding = new CustomBinding(baseBinding);

            IEnumerator<BindingElement> enmrt = customBinding.Elements.GetEnumerator();
            while (enmrt.MoveNext())
            {
                if (enmrt.Current is ReliableSessionBindingElement)
                {
                    reliableSessionElement = enmrt.Current as ReliableSessionBindingElement;
                    reliableSessionElement.MaxTransferWindowSize = 32;
                    reliableSessionElement.MaxRetryCount = 8192;

                    reliableSessionElement.MaxPendingChannels = 128;

                    // When inactivity timeout is set, client will send ping(ILM) message on timeout frequency
                    // Service can close callback channel upon expiry of this timeout
                    // reliableSessionElement.InactivityTimeout = new TimeSpan(0, 0, 0, 120);

                }
            }

            return customBinding;
        }

        public static string GetLocalIP()
        {
            IPHostEntry host;
            string localIP = "localhost";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }

            return localIP;
        }

    }
}
