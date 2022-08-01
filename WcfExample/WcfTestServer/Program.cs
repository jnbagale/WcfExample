using System;
using System.Threading;
using WcfService;

namespace WcfServer
{
    class Program
    {
        static IWcfTestService serviceInstance;
        static void Main(string[] args)
        {
            Program prog = new Program();

            prog.HostWcfTestService();
        }

        private void HostWcfTestService()
        {
            string mutex_id = "WCF Service Example";
            using (Mutex mutex = new Mutex(false, mutex_id))
            {
                if (!mutex.WaitOne(0, false))
                {
                    Console.WriteLine("Instance Already Running!", "Error");
                    return;
                }

                int portNumber = 977;
                string serverAddress = WcfHelper.GetLocalIP();
                string serviceNme = "WcfService/TestService/";

                Host host = new Host();

                serviceInstance = new WcfTestService();

                if (host.HostTcpService(typeof(IWcfTestService), serviceInstance, serverAddress, portNumber.ToString(), serviceNme))
                {
                    (serviceInstance as WcfTestService).Host = host;

                 Console.WriteLine(string.Format("WCF Test service has been hosted at {0}:{1}.\n", serverAddress, portNumber));
                }
                else
                {
                    Console.WriteLine("Problem Occured while trying to establish the service.");
                }

                string command = string.Empty;
                do
                {
                    command = Console.ReadLine();
                } while (!command.Equals("quit", StringComparison.InvariantCultureIgnoreCase));

                Console.WriteLine("Closing application..");

                if ((serviceInstance as WcfTestService).Host != null && ((serviceInstance as WcfTestService).Host.IsOpen))
                {
                    (serviceInstance as WcfTestService).Host.Close();
                }
            }
        }

    }
}
