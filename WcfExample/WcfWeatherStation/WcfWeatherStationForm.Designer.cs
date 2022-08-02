namespace WcfTestClient
{
    partial class WcfWeatherStationForm
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
            this.button_SubmitTemp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_StationId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Temp = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_serverIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_SubmitTemp
            // 
            this.button_SubmitTemp.Location = new System.Drawing.Point(21, 132);
            this.button_SubmitTemp.Name = "button_SubmitTemp";
            this.button_SubmitTemp.Size = new System.Drawing.Size(79, 31);
            this.button_SubmitTemp.TabIndex = 0;
            this.button_SubmitTemp.Text = "Submit Temperature";
            this.button_SubmitTemp.UseVisualStyleBackColor = true;
            this.button_SubmitTemp.Click += new System.EventHandler(this.button_SubmitTemp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // textBox_StationId
            // 
            this.textBox_StationId.Location = new System.Drawing.Point(109, 65);
            this.textBox_StationId.Name = "textBox_StationId";
            this.textBox_StationId.Size = new System.Drawing.Size(54, 20);
            this.textBox_StationId.TabIndex = 2;
            this.textBox_StationId.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Station Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Temperature";
            // 
            // textBox_Temp
            // 
            this.textBox_Temp.Location = new System.Drawing.Point(109, 99);
            this.textBox_Temp.Name = "textBox_Temp";
            this.textBox_Temp.Size = new System.Drawing.Size(54, 20);
            this.textBox_Temp.TabIndex = 4;
            this.textBox_Temp.Text = "30";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_serverIp);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox_StationId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button_SubmitTemp);
            this.panel1.Controls.Add(this.textBox_Temp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 248);
            this.panel1.TabIndex = 6;
            // 
            // textBox_serverIp
            // 
            this.textBox_serverIp.Location = new System.Drawing.Point(110, 22);
            this.textBox_serverIp.Name = "textBox_serverIp";
            this.textBox_serverIp.Size = new System.Drawing.Size(169, 20);
            this.textBox_serverIp.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Server IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Last Ping From Server:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 9;
            // 
            // WcfWeatherStationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 274);
            this.Controls.Add(this.panel1);
            this.Name = "WcfWeatherStationForm";
            this.Text = "Wcf Weather Station";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_SubmitTemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_StationId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Temp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_serverIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

