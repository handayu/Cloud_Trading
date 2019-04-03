namespace WeChartNotify
{
    partial class FormSymbolInspireMonthNotify
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
            this.components = new System.ComponentModel.Container();
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox_URL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_SymbolMonth = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_SendTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(586, 96);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(160, 23);
            this.button_Start.TabIndex = 7;
            this.button_Start.Text = "开始监听";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // textBox_URL
            // 
            this.textBox_URL.Location = new System.Drawing.Point(73, 16);
            this.textBox_URL.Name = "textBox_URL";
            this.textBox_URL.Size = new System.Drawing.Size(715, 21);
            this.textBox_URL.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL-Api:";
            // 
            // richTextBox_SymbolMonth
            // 
            this.richTextBox_SymbolMonth.Location = new System.Drawing.Point(12, 125);
            this.richTextBox_SymbolMonth.Name = "richTextBox_SymbolMonth";
            this.richTextBox_SymbolMonth.Size = new System.Drawing.Size(549, 313);
            this.richTextBox_SymbolMonth.TabIndex = 8;
            this.richTextBox_SymbolMonth.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(509, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "PS:正在交易的品种(和下面MC代码一致,逗号隔开完成监控,MC用指定月份交易，换月可以参考，\r\n不用立即换月，可以等下一个信号):提示我们正在交易的品种的换月信" +
    "息。\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(549, 21);
            this.textBox1.TabIndex = 10;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer_SendEvent);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(584, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "换月信息推送时间:";
            // 
            // textBox_SendTime
            // 
            this.textBox_SendTime.Location = new System.Drawing.Point(586, 152);
            this.textBox_SendTime.Name = "textBox_SendTime";
            this.textBox_SendTime.Size = new System.Drawing.Size(116, 21);
            this.textBox_SendTime.TabIndex = 12;
            this.textBox_SendTime.Text = "15:30:00";
            // 
            // FormSymbolInspireMonthNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_SendTime);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox_SymbolMonth);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.textBox_URL);
            this.Controls.Add(this.label1);
            this.Name = "FormSymbolInspireMonthNotify";
            this.Text = "MC主力合约换月提醒-建立新映射";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.Load += new System.EventHandler(this.Form_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TextBox textBox_URL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_SymbolMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_SendTime;
    }
}