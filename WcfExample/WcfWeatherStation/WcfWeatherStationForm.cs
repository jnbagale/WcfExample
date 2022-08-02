using System;
using System.Windows.Forms;
using WcfServiceClient;
using System.Linq;
using WcfService;

namespace WcfTestClient
{
    public partial class WcfWeatherStationForm : Form, IWeatherContractCallback
    {
        protected AsyncCallback asyncCallBack;

        public WcfWeatherStationForm()
        {
            InitializeComponent();

            string serverAddress = WcfService.WcfHelper.GetLocalIP();

            textBox_serverIp.Text = serverAddress;
            textBox_StationId.Text = serverAddress.Split('.').Last();
        }

        private void button_SubmitTemp_Click(object sender, EventArgs e)
        {
            int timeoutInSeconds = 30;
            int portNumber = 978;
            string serverAddress = textBox_serverIp.Text;
            string serviceName = "WcfService//WeatherService/";

            label1.Text = "";

            Application.DoEvents(); // Refresh the UI

            string msg = textBox_StationId.Text;
            label1.Text = "Submitting temperature to the Wcf Weather Service ...";

            Application.DoEvents(); // Refresh the UI

            asyncCallBack = new AsyncCallback(GetAsyncResult);

            WcfWeatherServiceClient wcfTestClient = WcfWeatherServiceClient.CreateWcfWeatherServiceClient(this, serviceName, serverAddress, portNumber.ToString(), timeoutInSeconds);

            try
            {
                int stationId = int.Parse(textBox_StationId.Text);
                double temp = double.Parse(textBox_Temp.Text);

                IAsyncResult result = wcfTestClient.BeginReportWeatherInfo(stationId, temp, asyncCallBack, wcfTestClient);

            }
            catch (Exception ex)
            {
                label1.Text = "The test service didn't respond. Please check to make sure its running";
            }
        }

        protected void GetAsyncResult(IAsyncResult result)
        {
            string errorMessage = string.Empty;

            try
            {
                WcfWeatherServiceClient wcfWeatherClient = (WcfWeatherServiceClient)result.AsyncState;

                bool logSuccessful = wcfWeatherClient.EndReportWeatherInfo(result);

                if (logSuccessful)
                    UpdateServerMessage($"Temperature logged by the weather server at {DateTime.Now.ToString()}");
                else
                    UpdateServerMessage("Temperature could not be logged by the weather server");

            }
            catch (System.ServiceModel.CommunicationException comEx)
            {
                errorMessage = "Communication Exception while receving result from the service";
                UpdateServerMessage(errorMessage + comEx.Message);
            }
            catch (Exception ex)
            {
                errorMessage = "Error while receving async result";
                UpdateServerMessage(errorMessage + ex.Message);
            }
        }

        private void UpdateServerMessage(string msg)
        {
            if (label1.InvokeRequired)
            {
                label1.Invoke((Action<string>)UpdateServerMessage, msg);
            }
            else
            {
                label1.Text = msg;
            }
        }

        public void PingWeatherStation(int stationId)
        {
            int currentStationId = int.Parse(textBox_StationId.Text);

            if (currentStationId == stationId) // in case the call back is mixed up but should never happen
            {
                label6.Text = DateTime.Now.ToString();
            }
            
        }
    }
}
