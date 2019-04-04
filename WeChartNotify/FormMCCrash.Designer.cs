namespace WeChartNotify
{
    partial class FormMCCrash
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
            this.richTextBox_AllWindows = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Num = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBox_WechartVdio = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox_AllWindows
            // 
            this.richTextBox_AllWindows.Location = new System.Drawing.Point(12, 72);
            this.richTextBox_AllWindows.Name = "richTextBox_AllWindows";
            this.richTextBox_AllWindows.Size = new System.Drawing.Size(336, 355);
            this.richTextBox_AllWindows.TabIndex = 0;
            this.richTextBox_AllWindows.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前总窗口数:";
            // 
            // label_Num
            // 
            this.label_Num.AutoSize = true;
            this.label_Num.Location = new System.Drawing.Point(102, 25);
            this.label_Num.Name = "label_Num";
            this.label_Num.Size = new System.Drawing.Size(29, 12);
            this.label_Num.TabIndex = 2;
            this.label_Num.Text = "----";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.TimeCheckWindowsNum_Event);
            // 
            // richTextBox_WechartVdio
            // 
            this.richTextBox_WechartVdio.Location = new System.Drawing.Point(368, 72);
            this.richTextBox_WechartVdio.Name = "richTextBox_WechartVdio";
            this.richTextBox_WechartVdio.Size = new System.Drawing.Size(368, 74);
            this.richTextBox_WechartVdio.TabIndex = 3;
            this.richTextBox_WechartVdio.Text = "";
            // 
            // FormMCCrash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox_WechartVdio);
            this.Controls.Add(this.label_Num);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_AllWindows);
            this.Name = "FormMCCrash";
            this.Text = "MC崩溃可能性监控";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_AllWindows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Num;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox richTextBox_WechartVdio;
    }
}