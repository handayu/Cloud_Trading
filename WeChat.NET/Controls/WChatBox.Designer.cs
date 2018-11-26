namespace WeChat.NET.Controls
{
    partial class WChatBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webKitBrowser1 = new WebKit.WebKitBrowser();
            this.plTop = new System.Windows.Forms.Panel();
            this.btnInfo = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.radioButton_Stop = new System.Windows.Forms.RadioButton();
            this.radioButton_Start = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_PATH = new System.Windows.Forms.TextBox();
            this.richTextBox_TEXTSINGLEINFO = new System.Windows.Forms.RichTextBox();
            this.textBox_Morning = new System.Windows.Forms.TextBox();
            this.EA_TEXT_SINGLE_INFO = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_Process = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_Eveing = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_Noon = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.plTop.SuspendLayout();
            this.EA_TEXT_SINGLE_INFO.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webKitBrowser1
            // 
            this.webKitBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webKitBrowser1.BackColor = System.Drawing.Color.White;
            this.webKitBrowser1.Location = new System.Drawing.Point(6, 20);
            this.webKitBrowser1.Name = "webKitBrowser1";
            this.webKitBrowser1.Size = new System.Drawing.Size(649, 77);
            this.webKitBrowser1.TabIndex = 1;
            this.webKitBrowser1.Url = new System.Uri("http://baidu.com", System.UriKind.Absolute);
            // 
            // plTop
            // 
            this.plTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(56)))));
            this.plTop.Controls.Add(this.btnInfo);
            this.plTop.Controls.Add(this.lblInfo);
            this.plTop.Controls.Add(this.btnBack);
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(661, 37);
            this.plTop.TabIndex = 7;
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Image = global::WeChat.NET.Properties.Resources.info;
            this.btnInfo.Location = new System.Drawing.Point(627, 3);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(30, 30);
            this.btnInfo.TabIndex = 2;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(117, 8);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(101, 20);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "与 张三 聊天中";
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = global::WeChat.NET.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(36, 29);
            this.btnBack.TabIndex = 0;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(6, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(649, 26);
            this.textBox1.TabIndex = 8;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(475, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = ":-)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(532, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 26);
            this.button2.TabIndex = 10;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "NotifyTime1:";
            // 
            // radioButton_Stop
            // 
            this.radioButton_Stop.AutoSize = true;
            this.radioButton_Stop.Location = new System.Drawing.Point(257, 34);
            this.radioButton_Stop.Name = "radioButton_Stop";
            this.radioButton_Stop.Size = new System.Drawing.Size(113, 16);
            this.radioButton_Stop.TabIndex = 14;
            this.radioButton_Stop.TabStop = true;
            this.radioButton_Stop.Text = "Stop--ClockLoop";
            this.radioButton_Stop.UseVisualStyleBackColor = true;
            // 
            // radioButton_Start
            // 
            this.radioButton_Start.AutoSize = true;
            this.radioButton_Start.Location = new System.Drawing.Point(257, 15);
            this.radioButton_Start.Name = "radioButton_Start";
            this.radioButton_Start.Size = new System.Drawing.Size(113, 16);
            this.radioButton_Start.TabIndex = 13;
            this.radioButton_Start.TabStop = true;
            this.radioButton_Start.Text = "Start-ClockLoop";
            this.radioButton_Start.UseVisualStyleBackColor = true;
            this.radioButton_Start.CheckedChanged += new System.EventHandler(this.Start_ClockCheckChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "PATH:";
            // 
            // textBox_PATH
            // 
            this.textBox_PATH.Location = new System.Drawing.Point(52, 25);
            this.textBox_PATH.Name = "textBox_PATH";
            this.textBox_PATH.Size = new System.Drawing.Size(198, 21);
            this.textBox_PATH.TabIndex = 11;
            this.textBox_PATH.Text = "C:\\strategy.txt";
            // 
            // richTextBox_TEXTSINGLEINFO
            // 
            this.richTextBox_TEXTSINGLEINFO.Location = new System.Drawing.Point(6, 59);
            this.richTextBox_TEXTSINGLEINFO.Name = "richTextBox_TEXTSINGLEINFO";
            this.richTextBox_TEXTSINGLEINFO.Size = new System.Drawing.Size(628, 179);
            this.richTextBox_TEXTSINGLEINFO.TabIndex = 10;
            this.richTextBox_TEXTSINGLEINFO.Text = "";
            // 
            // textBox_Morning
            // 
            this.textBox_Morning.Location = new System.Drawing.Point(160, 24);
            this.textBox_Morning.Name = "textBox_Morning";
            this.textBox_Morning.Size = new System.Drawing.Size(116, 21);
            this.textBox_Morning.TabIndex = 10;
            this.textBox_Morning.Text = "8:00:00";
            // 
            // EA_TEXT_SINGLE_INFO
            // 
            this.EA_TEXT_SINGLE_INFO.Controls.Add(this.radioButton_Stop);
            this.EA_TEXT_SINGLE_INFO.Controls.Add(this.radioButton_Start);
            this.EA_TEXT_SINGLE_INFO.Controls.Add(this.label6);
            this.EA_TEXT_SINGLE_INFO.Controls.Add(this.textBox_PATH);
            this.EA_TEXT_SINGLE_INFO.Controls.Add(this.richTextBox_TEXTSINGLEINFO);
            this.EA_TEXT_SINGLE_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EA_TEXT_SINGLE_INFO.Location = new System.Drawing.Point(3, 3);
            this.EA_TEXT_SINGLE_INFO.Name = "EA_TEXT_SINGLE_INFO";
            this.EA_TEXT_SINGLE_INFO.Size = new System.Drawing.Size(655, 244);
            this.EA_TEXT_SINGLE_INFO.TabIndex = 18;
            this.EA_TEXT_SINGLE_INFO.TabStop = false;
            this.EA_TEXT_SINGLE_INFO.Text = "EA_TEXT_SINGLE_INFO";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(40, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(251, 36);
            this.label15.TabIndex = 18;
            this.label15.Text = "PS:在Start-Clock监控文本的同时，\r\n达到上述固定时间查看MC进程是否在线，\r\n另外播报内存和CPU使用率,都加截图给WeChart\r\n";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(37, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "监控进程:";
            // 
            // textBox_Process
            // 
            this.textBox_Process.Location = new System.Drawing.Point(102, 106);
            this.textBox_Process.Name = "textBox_Process";
            this.textBox_Process.Size = new System.Drawing.Size(174, 21);
            this.textBox_Process.TabIndex = 16;
            this.textBox_Process.Text = "MultiCharts64";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(37, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "NotifyTime3:";
            // 
            // textBox_Eveing
            // 
            this.textBox_Eveing.Location = new System.Drawing.Point(160, 65);
            this.textBox_Eveing.Name = "textBox_Eveing";
            this.textBox_Eveing.Size = new System.Drawing.Size(116, 21);
            this.textBox_Eveing.TabIndex = 14;
            this.textBox_Eveing.Text = "20:30:00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "NotifyTime2:";
            // 
            // textBox_Noon
            // 
            this.textBox_Noon.Location = new System.Drawing.Point(160, 47);
            this.textBox_Noon.Name = "textBox_Noon";
            this.textBox_Noon.Size = new System.Drawing.Size(116, 21);
            this.textBox_Noon.TabIndex = 12;
            this.textBox_Noon.Text = "12:00:00";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.textBox_Process);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.textBox_Eveing);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.textBox_Noon);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.textBox_Morning);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 253);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(655, 245);
            this.groupBox7.TabIndex = 19;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "定时Send-MC-status";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.Time2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webKitBrowser1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 170);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "聊天中......";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(661, 170);
            this.panel2.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.EA_TEXT_SINGLE_INFO, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox7, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 207);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 501);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.TimeHoldText_EventClick);
            // 
            // WChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.plTop);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WChatBox";
            this.Size = new System.Drawing.Size(661, 708);
            this.Load += new System.EventHandler(this.WChatBox_Load);
            this.Resize += new System.EventHandler(this.WChatBox_Resize);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.EA_TEXT_SINGLE_INFO.ResumeLayout(false);
            this.EA_TEXT_SINGLE_INFO.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WebKit.WebKitBrowser webKitBrowser1;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton radioButton_Stop;
        private System.Windows.Forms.RadioButton radioButton_Start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_PATH;
        private System.Windows.Forms.RichTextBox richTextBox_TEXTSINGLEINFO;
        private System.Windows.Forms.TextBox textBox_Morning;
        private System.Windows.Forms.GroupBox EA_TEXT_SINGLE_INFO;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_Process;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_Eveing;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_Noon;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
    }
}
