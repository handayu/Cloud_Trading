namespace WeChartNotify
{
    partial class WallStreetEventDriveForm
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
            this.textBox_URL = new System.Windows.Forms.TextBox();
            this.listView_Content = new System.Windows.Forms.ListView();
            this.button_Start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL-Api:";
            // 
            // textBox_URL
            // 
            this.textBox_URL.Location = new System.Drawing.Point(73, 23);
            this.textBox_URL.Name = "textBox_URL";
            this.textBox_URL.Size = new System.Drawing.Size(715, 21);
            this.textBox_URL.TabIndex = 1;
            // 
            // listView_Content
            // 
            this.listView_Content.Location = new System.Drawing.Point(14, 89);
            this.listView_Content.Name = "listView_Content";
            this.listView_Content.Size = new System.Drawing.Size(774, 353);
            this.listView_Content.TabIndex = 2;
            this.listView_Content.UseCompatibleStateImageBehavior = false;
            this.listView_Content.View = System.Windows.Forms.View.List;
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(14, 59);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(160, 23);
            this.button_Start.TabIndex = 3;
            this.button_Start.Text = "开始监听";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.Loop_TickEvent);
            // 
            // WallStreetEventDriveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.listView_Content);
            this.Controls.Add(this.textBox_URL);
            this.Controls.Add(this.label1);
            this.Name = "WallStreetEventDriveForm";
            this.Text = "7*24小时华尔街见闻事件驱动--全球播报";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_URL;
        private System.Windows.Forms.ListView listView_Content;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Timer timer1;
    }
}