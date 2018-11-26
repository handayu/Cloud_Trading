namespace WeChartNotify
{
    partial class FormRealComputerInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_RM = new System.Windows.Forms.TextBox();
            this.textBox_CPU = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "内存使用率:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "CPU使用率:";
            // 
            // textBox_RM
            // 
            this.textBox_RM.Location = new System.Drawing.Point(111, 47);
            this.textBox_RM.Name = "textBox_RM";
            this.textBox_RM.ReadOnly = true;
            this.textBox_RM.Size = new System.Drawing.Size(260, 21);
            this.textBox_RM.TabIndex = 2;
            // 
            // textBox_CPU
            // 
            this.textBox_CPU.Location = new System.Drawing.Point(111, 91);
            this.textBox_CPU.Name = "textBox_CPU";
            this.textBox_CPU.ReadOnly = true;
            this.textBox_CPU.Size = new System.Drawing.Size(260, 21);
            this.textBox_CPU.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Computet_Usage_EnentTicker);
            // 
            // FormRealComputerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 191);
            this.Controls.Add(this.textBox_CPU);
            this.Controls.Add(this.textBox_RM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormRealComputerInfo";
            this.Text = "任务管理器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_RM;
        private System.Windows.Forms.TextBox textBox_CPU;
        private System.Windows.Forms.Timer timer1;
    }
}