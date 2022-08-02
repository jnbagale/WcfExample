using System;
using System.Threading;
using WcfService;

namespace WcfServer
{
    class Program
    {
        static IWcfWeatherService serviceInstance;
        static void Main(string[] args)
        {
            Program prog = new Program();

            prog.HostWcfWeatherService();
        }

        private void HostWcfWeatherService()
        {
            string mutex_id = "WCF Weather Service";
            using (Mutex mutex = new Mutex(false, mutex_id))
            {
                if (!mutex.WaitOne(0, false))
                {
                    Console.WriteLine("Instance Already Running!", "Error");
                    return;
                }

                int portNumber = 978;
                string serverAddress = WcfHelper.GetLocalIP();
                string serviceNme = "WcfService/WeatherService/";

                Host host = new Host();

                serviceInstance = new WcfWeatherService();

                if (host.HostTcpService(typeof(IWcfWeatherService), serviceInstance, serverAddress, portNumber.ToString(), serviceNme))
                {
                    (serviceInstance as WcfWeatherService).Host = host;

                    Console.WriteLine(string.Format("WCF Test service has been hosted at {0}:{1}\n", serverAddress, portNumber));
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

                if ((serviceInstance as WcfWeatherService).Host != null && ((serviceInstance as WcfWeatherService).Host.IsOpen))
                {
                    (serviceInstance as WcfWeatherService).Host.Close();
                }
            }
        }

    }
}
