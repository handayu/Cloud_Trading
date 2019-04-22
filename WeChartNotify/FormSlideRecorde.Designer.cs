namespace WeChartNotify
{
    partial class FormSlideRecorde
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
            this.button_GetOutPutContent = new System.Windows.Forms.Button();
            this.button_SendNullStr = new System.Windows.Forms.Button();
            this.textBox_OutputHandle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Notify = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.timer_MCOutput = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_SeriesLossNotify = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timer_NotifySeriesLoss = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_VisualOrNo = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox_TradeInfo = new System.Windows.Forms.RichTextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox_Tradeinfo = new System.Windows.Forms.CheckBox();
            this.checkBox_Notify = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(200, 8);
            this.button_Start.Margin = new System.Windows.Forms.Padding(2);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(73, 23);
            this.button_Start.TabIndex = 9;
            this.button_Start.Text = "启动定时器";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_GetOutPutContent
            // 
            this.button_GetOutPutContent.Location = new System.Drawing.Point(10, 57);
            this.button_GetOutPutContent.Margin = new System.Windows.Forms.Padding(2);
            this.button_GetOutPutContent.Name = "button_GetOutPutContent";
            this.button_GetOutPutContent.Size = new System.Drawing.Size(95, 23);
            this.button_GetOutPutContent.TabIndex = 7;
            this.button_GetOutPutContent.Text = "获取输出内容";
            this.button_GetOutPutContent.UseVisualStyleBackColor = true;
            this.button_GetOutPutContent.Click += new System.EventHandler(this.button_GetOutPutContent_Click);
            // 
            // button_SendNullStr
            // 
            this.button_SendNullStr.Location = new System.Drawing.Point(10, 81);
            this.button_SendNullStr.Margin = new System.Windows.Forms.Padding(2);
            this.button_SendNullStr.Name = "button_SendNullStr";
            this.button_SendNullStr.Size = new System.Drawing.Size(113, 23);
            this.button_SendNullStr.TabIndex = 6;
            this.button_SendNullStr.Text = "发送空字符串清空";
            this.button_SendNullStr.UseVisualStyleBackColor = true;
            this.button_SendNullStr.Click += new System.EventHandler(this.button_SendNullStr_Click);
            // 
            // textBox_OutputHandle
            // 
            this.textBox_OutputHandle.Location = new System.Drawing.Point(10, 32);
            this.textBox_OutputHandle.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_OutputHandle.Name = "textBox_OutputHandle";
            this.textBox_OutputHandle.Size = new System.Drawing.Size(186, 21);
            this.textBox_OutputHandle.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "公式编辑器输出句柄:";
            // 
            // button_Notify
            // 
            this.button_Notify.Location = new System.Drawing.Point(109, 57);
            this.button_Notify.Margin = new System.Windows.Forms.Padding(2);
            this.button_Notify.Name = "button_Notify";
            this.button_Notify.Size = new System.Drawing.Size(164, 23);
            this.button_Notify.TabIndex = 14;
            this.button_Notify.Text = "目前程序样例";
            this.button_Notify.UseVisualStyleBackColor = true;
            this.button_Notify.Click += new System.EventHandler(this.button_Notify_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(200, 30);
            this.button_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(73, 23);
            this.button_Stop.TabIndex = 11;
            this.button_Stop.Text = "关闭定时器";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.Button_StopClick);
            // 
            // timer_MCOutput
            // 
            this.timer_MCOutput.Interval = 1000;
            this.timer_MCOutput.Tick += new System.EventHandler(this.TimerEvent_MCData);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(334, 137);
            this.dataGridView1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.checkBox_Notify);
            this.panel2.Controls.Add(this.checkBox_Tradeinfo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox_SeriesLossNotify);
            this.panel2.Controls.Add(this.button_Stop);
            this.panel2.Controls.Add(this.button_Notify);
            this.panel2.Controls.Add(this.button_Start);
            this.panel2.Controls.Add(this.button_GetOutPutContent);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.button_SendNullStr);
            this.panel2.Controls.Add(this.textBox_OutputHandle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 131);
            this.panel2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "监控连续回撤次数:";
            // 
            // textBox_SeriesLossNotify
            // 
            this.textBox_SeriesLossNotify.Location = new System.Drawing.Point(119, 108);
            this.textBox_SeriesLossNotify.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SeriesLossNotify.Name = "textBox_SeriesLossNotify";
            this.textBox_SeriesLossNotify.Size = new System.Drawing.Size(154, 21);
            this.textBox_SeriesLossNotify.TabIndex = 16;
            this.textBox_SeriesLossNotify.Text = "3";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.richTextBox_TradeInfo);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(334, 461);
            this.panel4.TabIndex = 22;
            // 
            // timer_NotifySeriesLoss
            // 
            this.timer_NotifySeriesLoss.Enabled = true;
            this.timer_NotifySeriesLoss.Interval = 500;
            this.timer_NotifySeriesLoss.Tick += new System.EventHandler(this.timer_NotifySeriesLossEvent);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_VisualOrNo});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 26);
            // 
            // ToolStripMenuItem_VisualOrNo
            // 
            this.ToolStripMenuItem_VisualOrNo.Name = "ToolStripMenuItem_VisualOrNo";
            this.ToolStripMenuItem_VisualOrNo.Size = new System.Drawing.Size(129, 22);
            this.ToolStripMenuItem_VisualOrNo.Text = "隐藏/显示";
            this.ToolStripMenuItem_VisualOrNo.Click += new System.EventHandler(this.ToolStripMenuItem_VisualOrNoEvent);
            // 
            // richTextBox_TradeInfo
            // 
            this.richTextBox_TradeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_TradeInfo.Location = new System.Drawing.Point(0, 268);
            this.richTextBox_TradeInfo.Name = "richTextBox_TradeInfo";
            this.richTextBox_TradeInfo.Size = new System.Drawing.Size(334, 193);
            this.richTextBox_TradeInfo.TabIndex = 21;
            this.richTextBox_TradeInfo.Text = "";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Ins";
            this.Column1.HeaderText = "品种";
            this.Column1.Name = "Column1";
            this.Column1.Width = 55;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Time";
            this.Column2.HeaderText = "时间";
            this.Column2.Name = "Column2";
            this.Column2.Width = 55;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SeriesLoss";
            this.Column3.HeaderText = "原始Par(Loss风险控制阀值)";
            this.Column3.Name = "Column3";
            this.Column3.Width = 180;
            // 
            // checkBox_Tradeinfo
            // 
            this.checkBox_Tradeinfo.AutoSize = true;
            this.checkBox_Tradeinfo.Location = new System.Drawing.Point(129, 84);
            this.checkBox_Tradeinfo.Name = "checkBox_Tradeinfo";
            this.checkBox_Tradeinfo.Size = new System.Drawing.Size(96, 16);
            this.checkBox_Tradeinfo.TabIndex = 17;
            this.checkBox_Tradeinfo.Text = "交易记录发送";
            this.checkBox_Tradeinfo.UseVisualStyleBackColor = true;
            // 
            // checkBox_Notify
            // 
            this.checkBox_Notify.AutoSize = true;
            this.checkBox_Notify.Location = new System.Drawing.Point(232, 83);
            this.checkBox_Notify.Name = "checkBox_Notify";
            this.checkBox_Notify.Size = new System.Drawing.Size(96, 16);
            this.checkBox_Notify.TabIndex = 18;
            this.checkBox_Notify.Text = "品种监控发送";
            this.checkBox_Notify.UseVisualStyleBackColor = true;
            // 
            // FormSlideRecorde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 461);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel4);
            this.Name = "FormSlideRecorde";
            this.Text = "MC-公式编辑器(交易记录&品种连续信号监控器)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_GetOutPutContent;
        private System.Windows.Forms.Button button_SendNullStr;
        private System.Windows.Forms.TextBox textBox_OutputHandle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Timer timer_MCOutput;
        private System.Windows.Forms.Button button_Notify;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timer_NotifySeriesLoss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_SeriesLossNotify;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_VisualOrNo;
        private System.Windows.Forms.RichTextBox richTextBox_TradeInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.CheckBox checkBox_Tradeinfo;
        private System.Windows.Forms.CheckBox checkBox_Notify;
    }
}