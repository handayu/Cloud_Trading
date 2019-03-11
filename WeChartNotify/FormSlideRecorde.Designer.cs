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
            this.textBox_timer = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_GetOutPutContent = new System.Windows.Forms.Button();
            this.button_SendNullStr = new System.Windows.Forms.Button();
            this.textBox_OutputHandle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_timer
            // 
            this.textBox_timer.Location = new System.Drawing.Point(242, 62);
            this.textBox_timer.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_timer.Name = "textBox_timer";
            this.textBox_timer.Size = new System.Drawing.Size(73, 21);
            this.textBox_timer.TabIndex = 10;
            this.textBox_timer.Text = "8000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 87);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "启动定时器开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(403, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(385, 90);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // button_GetOutPutContent
            // 
            this.button_GetOutPutContent.Location = new System.Drawing.Point(127, 87);
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
            this.button_SendNullStr.Location = new System.Drawing.Point(13, 87);
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
            this.textBox_OutputHandle.Location = new System.Drawing.Point(19, 51);
            this.textBox_OutputHandle.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_OutputHandle.Name = "textBox_OutputHandle";
            this.textBox_OutputHandle.Size = new System.Drawing.Size(186, 21);
            this.textBox_OutputHandle.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "公式编辑器输出句柄:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.textBox_timer);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.button_GetOutPutContent);
            this.groupBox2.Controls.Add(this.button_SendNullStr);
            this.groupBox2.Controls.Add(this.textBox_OutputHandle);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.Color.Gray;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(800, 120);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MultiCharts-公式编辑器设置";
            // 
            // FormSlideRecorde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormSlideRecorde";
            this.Text = "MC-输出窗口滑点等记录分析器";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_timer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_GetOutPutContent;
        private System.Windows.Forms.Button button_SendNullStr;
        private System.Windows.Forms.TextBox textBox_OutputHandle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}