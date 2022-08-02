using System.ServiceModel;
using System;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IWeatherContractCallback))]
    public interface IWcfWeatherService
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginReportWeatherInfo(int stationId, double temp, AsyncCallback callback, object state);

        bool EndReportWeatherInfo(IAsyncResult result);
    }

    public interface IWeatherContractCallback
    {
        [OperationContract]
        void PingWeatherStation(int stationId);
    }
}
