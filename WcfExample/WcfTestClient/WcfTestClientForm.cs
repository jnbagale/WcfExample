using System;
using System.Windows.Forms;
using WcfServiceClient;

namespace WcfTestClient
{
    public partial class WcfTestClientForm : Form
    {
        public WcfTestClientForm()
        {
            InitializeComponent();
        }

        private void button_PingServer_Click(object sender, EventArgs e)
        {
            int timeoutInSeconds = 10;
            int portNumber = 977;
            string serverAddress = WcfService.WcfHelper.GetLocalIP();
            string serviceName = "WcfService//TestService/";

            label1.Text = "";

            Application.DoEvents(); // Refresh the UI

            string msg = textBox_PingMessage.Text;
            label1.Text = "Pinging Test Service ...";

            Application.DoEvents(); // Refresh the UI

            WcfTestServiceClient wcfTestClient = WcfTestServiceClient.CreateWcfTestServiceClient(serviceName, serverAddress, portNumber.ToString(), timeoutInSeconds);

            try
            {
                label1.Text = (string)wcfTestClient.TestService(msg);

            }
            catch(Exception ex)
            {
                label1.Text = "The test service didn't respond. Please check to make sure its running";
            }
        }
    }
}
