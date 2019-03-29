namespace WeChartNotify
{
    partial class FormPixelCheck
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_TargetRGB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_SETX = new System.Windows.Forms.TextBox();
            this.textBox_SETY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer_AutoXY = new System.Windows.Forms.Timer(this.components);
            this.button_AutoSetingXY = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer_GetPirex);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "label_ScreenX:";
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(252, 21);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.ReadOnly = true;
            this.textBox_X.Size = new System.Drawing.Size(64, 21);
            this.textBox_X.TabIndex = 10;
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(427, 21);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.ReadOnly = true;
            this.textBox_Y.Size = new System.Drawing.Size(64, 21);
            this.textBox_Y.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "label_ScreenY:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Target --RGB VALUE:";
            // 
            // textBox_TargetRGB
            // 
            this.textBox_TargetRGB.Location = new System.Drawing.Point(282, 113);
            this.textBox_TargetRGB.Name = "textBox_TargetRGB";
            this.textBox_TargetRGB.Size = new System.Drawing.Size(64, 21);
            this.textBox_TargetRGB.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "X:";
            // 
            // textBox_SETX
            // 
            this.textBox_SETX.Location = new System.Drawing.Point(252, 63);
            this.textBox_SETX.Name = "textBox_SETX";
            this.textBox_SETX.Size = new System.Drawing.Size(64, 21);
            this.textBox_SETX.TabIndex = 16;
            // 
            // textBox_SETY
            // 
            this.textBox_SETY.Location = new System.Drawing.Point(427, 63);
            this.textBox_SETY.Name = "textBox_SETY";
            this.textBox_SETY.Size = new System.Drawing.Size(64, 21);
            this.textBox_SETY.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Y:";
            // 
            // timer_AutoXY
            // 
            this.timer_AutoXY.Enabled = true;
            this.timer_AutoXY.Tick += new System.EventHandler(this.Timer_AutoXY);
            // 
            // button_AutoSetingXY
            // 
            this.button_AutoSetingXY.Location = new System.Drawing.Point(159, 149);
            this.button_AutoSetingXY.Name = "button_AutoSetingXY";
            this.button_AutoSetingXY.Size = new System.Drawing.Size(276, 23);
            this.button_AutoSetingXY.TabIndex = 19;
            this.button_AutoSetingXY.Text = "AutoSetingXY";
            this.button_AutoSetingXY.UseVisualStyleBackColor = true;
            this.button_AutoSetingXY.Click += new System.EventHandler(this.AutoSeting_ButtonClick);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(159, 179);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(276, 23);
            this.button_Clear.TabIndex = 18;
            this.button_Clear.Text = "ClearAll-XY";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(549, 149);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(95, 23);
            this.button_Start.TabIndex = 20;
            this.button_Start.Text = "Start_Loop";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(549, 178);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(95, 23);
            this.button_Stop.TabIndex = 21;
            this.button_Stop.Text = "Stop_Loop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // FormPixelCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 350);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.button_AutoSetingXY);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_SETX);
            this.Controls.Add(this.textBox_SETY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_TargetRGB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_X);
            this.Controls.Add(this.textBox_Y);
            this.Controls.Add(this.label2);
            this.Name = "FormPixelCheck";
            this.Text = "FormPixelCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_TargetRGB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_SETX;
        private System.Windows.Forms.TextBox textBox_SETY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer_AutoXY;
        private System.Windows.Forms.Button button_AutoSetingXY;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
    }
}