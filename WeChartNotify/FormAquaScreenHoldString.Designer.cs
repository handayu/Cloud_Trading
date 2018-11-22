namespace WeChartNotify
{
    partial class FormAquaScreenHoldString
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Handle = new System.Windows.Forms.TextBox();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.textBox_Width = new System.Windows.Forms.TextBox();
            this.button_AutoParam = new System.Windows.Forms.Button();
            this.button_CaptureRetangle = new System.Windows.Forms.Button();
            this.richTextBox_Result = new System.Windows.Forms.RichTextBox();
            this.button_Clear = new System.Windows.Forms.Button();
            this.textBox_X2 = new System.Windows.Forms.TextBox();
            this.textBox_Y2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_ClearParam = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.HoldHandle_TickEvent);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_ClearParam);
            this.groupBox1.Controls.Add(this.textBox_X2);
            this.groupBox1.Controls.Add(this.textBox_Y2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button_AutoParam);
            this.groupBox1.Controls.Add(this.textBox_Width);
            this.groupBox1.Controls.Add(this.textBox_X);
            this.groupBox1.Controls.Add(this.textBox_Height);
            this.groupBox1.Controls.Add(this.textBox_Y);
            this.groupBox1.Controls.Add(this.textBox_Title);
            this.groupBox1.Controls.Add(this.textBox_Handle);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capture Param";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Clear);
            this.groupBox2.Controls.Add(this.richTextBox_Result);
            this.groupBox2.Location = new System.Drawing.Point(13, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 189);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result -Text String";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_CaptureRetangle);
            this.groupBox3.Location = new System.Drawing.Point(13, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(775, 44);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Actions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "WindowsHandle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "XBegin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "YBegin:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Width:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Height:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Window Title:";
            // 
            // textBox_Handle
            // 
            this.textBox_Handle.Location = new System.Drawing.Point(120, 20);
            this.textBox_Handle.Name = "textBox_Handle";
            this.textBox_Handle.ReadOnly = true;
            this.textBox_Handle.Size = new System.Drawing.Size(207, 21);
            this.textBox_Handle.TabIndex = 6;
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(458, 15);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.ReadOnly = true;
            this.textBox_Title.Size = new System.Drawing.Size(232, 21);
            this.textBox_Title.TabIndex = 7;
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(283, 64);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.ReadOnly = true;
            this.textBox_Y.Size = new System.Drawing.Size(77, 21);
            this.textBox_Y.TabIndex = 8;
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(265, 139);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.ReadOnly = true;
            this.textBox_Height.Size = new System.Drawing.Size(77, 21);
            this.textBox_Height.TabIndex = 9;
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(78, 64);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.ReadOnly = true;
            this.textBox_X.Size = new System.Drawing.Size(77, 21);
            this.textBox_X.TabIndex = 10;
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(72, 139);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.ReadOnly = true;
            this.textBox_Width.Size = new System.Drawing.Size(77, 21);
            this.textBox_Width.TabIndex = 11;
            // 
            // button_AutoParam
            // 
            this.button_AutoParam.Location = new System.Drawing.Point(478, 67);
            this.button_AutoParam.Name = "button_AutoParam";
            this.button_AutoParam.Size = new System.Drawing.Size(232, 23);
            this.button_AutoParam.TabIndex = 12;
            this.button_AutoParam.Text = "Auto-HoldParam";
            this.button_AutoParam.UseVisualStyleBackColor = true;
            this.button_AutoParam.Click += new System.EventHandler(this.button_AutoParam_Click);
            // 
            // button_CaptureRetangle
            // 
            this.button_CaptureRetangle.Location = new System.Drawing.Point(72, 15);
            this.button_CaptureRetangle.Name = "button_CaptureRetangle";
            this.button_CaptureRetangle.Size = new System.Drawing.Size(315, 23);
            this.button_CaptureRetangle.TabIndex = 0;
            this.button_CaptureRetangle.Text = "Capture Retangle";
            this.button_CaptureRetangle.UseVisualStyleBackColor = true;
            this.button_CaptureRetangle.Click += new System.EventHandler(this.button_CaptureRetangle_Click);
            // 
            // richTextBox_Result
            // 
            this.richTextBox_Result.Location = new System.Drawing.Point(15, 20);
            this.richTextBox_Result.Name = "richTextBox_Result";
            this.richTextBox_Result.ReadOnly = true;
            this.richTextBox_Result.Size = new System.Drawing.Size(734, 107);
            this.richTextBox_Result.TabIndex = 0;
            this.richTextBox_Result.Text = "";
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(434, 152);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(315, 23);
            this.button_Clear.TabIndex = 1;
            this.button_Clear.Text = "Clear-Text";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // textBox_X2
            // 
            this.textBox_X2.Location = new System.Drawing.Point(78, 91);
            this.textBox_X2.Name = "textBox_X2";
            this.textBox_X2.ReadOnly = true;
            this.textBox_X2.Size = new System.Drawing.Size(77, 21);
            this.textBox_X2.TabIndex = 16;
            // 
            // textBox_Y2
            // 
            this.textBox_Y2.Location = new System.Drawing.Point(283, 91);
            this.textBox_Y2.Name = "textBox_Y2";
            this.textBox_Y2.ReadOnly = true;
            this.textBox_Y2.Size = new System.Drawing.Size(77, 21);
            this.textBox_Y2.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "YEnd:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "XEnd:";
            // 
            // button_ClearParam
            // 
            this.button_ClearParam.Location = new System.Drawing.Point(478, 108);
            this.button_ClearParam.Name = "button_ClearParam";
            this.button_ClearParam.Size = new System.Drawing.Size(232, 23);
            this.button_ClearParam.TabIndex = 17;
            this.button_ClearParam.Text = "Clear-ReadAgain";
            this.button_ClearParam.UseVisualStyleBackColor = true;
            this.button_ClearParam.Click += new System.EventHandler(this.button_ClearParam_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.SendMessage_TimeEvent);
            // 
            // FormAquaScreenHoldString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAquaScreenHoldString";
            this.Text = "Aqua图形识别字符提取";
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_AutoParam;
        private System.Windows.Forms.TextBox textBox_Width;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.TextBox textBox_Handle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.RichTextBox richTextBox_Result;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_CaptureRetangle;
        private System.Windows.Forms.TextBox textBox_X2;
        private System.Windows.Forms.TextBox textBox_Y2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_ClearParam;
        private System.Windows.Forms.Timer timer2;
    }
}