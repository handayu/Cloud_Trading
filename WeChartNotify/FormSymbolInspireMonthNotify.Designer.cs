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
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox_URL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_SymbolMonth = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(14, 52);
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
            this.richTextBox_SymbolMonth.Location = new System.Drawing.Point(14, 81);
            this.richTextBox_SymbolMonth.Name = "richTextBox_SymbolMonth";
            this.richTextBox_SymbolMonth.Size = new System.Drawing.Size(774, 357);
            this.richTextBox_SymbolMonth.TabIndex = 8;
            this.richTextBox_SymbolMonth.Text = "";
            // 
            // FormSymbolInspireMonthNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox_SymbolMonth);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.textBox_URL);
            this.Controls.Add(this.label1);
            this.Name = "FormSymbolInspireMonthNotify";
            this.Text = "MC主力合约换月提醒-建立新映射";
            this.Load += new System.EventHandler(this.Form_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TextBox textBox_URL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_SymbolMonth;
    }
}