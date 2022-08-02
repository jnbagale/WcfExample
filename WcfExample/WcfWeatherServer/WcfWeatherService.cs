using System.ServiceModel;
using System.Threading;
using WcfService;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WcfServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true, AddressFilterMode = AddressFilterMode.Any)]
    class WcfWeatherService : IWcfWeatherService
    {
        Tuple<int, double> stationAndTemp;
        internal Host Host { get; set; }
        Dictionary<int, IWeatherContractCallback> weatherStations = new Dictionary<int, IWeatherContractCallback>();
        System.Timers.Timer weatherStationPollTimer;

        public WcfWeatherService()
        {
            weatherStationPollTimer = new System.Timers.Timer(60 * 1000); // timeout_in_ms
            weatherStationPollTimer.Elapsed += new System.Timers.ElapsedEventHandler(weatherStationPollTimer_Elapsed);
            weatherStationPollTimer.Enabled = true;
        }

        public IAsyncResult BeginReportWeatherInfo(int stationId, double temp, AsyncCallback callback, object state)
        {
            stationAndTemp = Tuple.Create(stationId, temp);
            var task = Task<object>.Factory.StartNew(this.LogTemperature, state);

            IWeatherContractCallback weatherCallback = OperationContext.Current.GetCallbackChannel<IWeatherContractCallback>();

            weatherStations[stationId] = weatherCallback; // overwrite if the same station submits again in case the callback is new

            return task.ContinueWith(res => callback(task));
        }

        public object LogTemperature(object state)
        {
            Thread.Sleep(1000);

            int stationId = stationAndTemp.Item1;
            double temp = stationAndTemp.Item2;

            bool isCurrentTempValid = (temp > -100 && temp < 1000); // in degrees

            Console.Write($"{DateTime.Now.ToString()} Temperature received. Station Id: {stationId} Temperature {temp} ");

            if (isCurrentTempValid)
                Console.WriteLine($"Temperature is valid.");
            else
                Console.WriteLine("Temperature is not valid");

            return isCurrentTempValid;
        }

        public bool EndReportWeatherInfo(IAsyncResult result)
        {
            return (bool)((Task<object>)result).Result;
        }

        private void weatherStationPollTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(weatherStations.Count > 0)
            {
                foreach(var kvp in weatherStations)
                {
                    try
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()} Pinging Station {kvp.Key}");
                        kvp.Value.PingWeatherStation(kvp.Key); 
                    }
                    catch(Exception ex)
                    {
                        ;
                    }
                }
            }
        }
    }
}
