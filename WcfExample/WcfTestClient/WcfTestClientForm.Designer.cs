namespace WcfTestClient
{
    partial class WcfTestClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_PingServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_PingMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_PingServer
            // 
            this.button_PingServer.Location = new System.Drawing.Point(25, 37);
            this.button_PingServer.Name = "button_PingServer";
            this.button_PingServer.Size = new System.Drawing.Size(96, 31);
            this.button_PingServer.TabIndex = 0;
            this.button_PingServer.Text = "Ping Server";
            this.button_PingServer.UseVisualStyleBackColor = true;
            this.button_PingServer.Click += new System.EventHandler(this.button_PingServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // textBox_PingMessage
            // 
            this.textBox_PingMessage.Location = new System.Drawing.Point(122, 12);
            this.textBox_PingMessage.Name = "textBox_PingMessage";
            this.textBox_PingMessage.Size = new System.Drawing.Size(96, 20);
            this.textBox_PingMessage.TabIndex = 2;
            this.textBox_PingMessage.Text = "Ping";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ping Message:";
            // 
            // WcfTestClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 341);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_PingMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_PingServer);
            this.Name = "WcfTestClientForm";
            this.Text = "Wcf Test Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_PingServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_PingMessage;
        private System.Windows.Forms.Label label2;
    }
}

