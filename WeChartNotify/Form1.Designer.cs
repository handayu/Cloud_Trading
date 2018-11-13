namespace WeChartNotify
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_testInput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.textBox_setY = new System.Windows.Forms.TextBox();
            this.textBox_setX = new System.Windows.Forms.TextBox();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_testEnter = new System.Windows.Forms.Button();
            this.textBox_enterY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_enterX = new System.Windows.Forms.TextBox();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.richTextBox_TEXTSINGLEINFO = new System.Windows.Forms.RichTextBox();
            this.EA_TEXT_SINGLE_INFO = new System.Windows.Forms.GroupBox();
            this.button_StartClockGet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_PATH = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_TestVoiceEnter = new System.Windows.Forms.Button();
            this.textBox_VoiceY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_VoiceX = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_AutoSetingXY = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button_ShotScreen = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_Morning = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_Noon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_Eveing = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_Process = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.EA_TEXT_SINGLE_INFO.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_testInput
            // 
            this.button_testInput.Location = new System.Drawing.Point(242, 60);
            this.button_testInput.Name = "button_testInput";
            this.button_testInput.Size = new System.Drawing.Size(103, 23);
            this.button_testInput.TabIndex = 0;
            this.button_testInput.Text = "TestInput";
            this.button_testInput.UseVisualStyleBackColor = true;
            this.button_testInput.Click += new System.EventHandler(this.button1_Click);
            this.button_testInput.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_Move);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label_ScreenX:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "label_ScreenY:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "SetX:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "SetY:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_content);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button_testInput);
            this.groupBox1.Controls.Add(this.textBox_setY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_setX);
            this.groupBox1.Location = new System.Drawing.Point(2, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 96);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content-Test";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "TestContent:";
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(108, 60);
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(64, 21);
            this.textBox_content.TabIndex = 8;
            // 
            // textBox_setY
            // 
            this.textBox_setY.Location = new System.Drawing.Point(281, 20);
            this.textBox_setY.Name = "textBox_setY";
            this.textBox_setY.Size = new System.Drawing.Size(64, 21);
            this.textBox_setY.TabIndex = 5;
            // 
            // textBox_setX
            // 
            this.textBox_setX.Location = new System.Drawing.Point(108, 20);
            this.textBox_setX.Name = "textBox_setX";
            this.textBox_setX.Size = new System.Drawing.Size(64, 21);
            this.textBox_setX.TabIndex = 0;
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(108, 18);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.ReadOnly = true;
            this.textBox_X.Size = new System.Drawing.Size(64, 21);
            this.textBox_X.TabIndex = 6;
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(283, 18);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.ReadOnly = true;
            this.textBox_Y.Size = new System.Drawing.Size(64, 21);
            this.textBox_Y.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button_testEnter);
            this.groupBox2.Controls.Add(this.textBox_enterY);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox_enterX);
            this.groupBox2.Location = new System.Drawing.Point(1, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 96);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Button-Test";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "SetX:";
            // 
            // button_testEnter
            // 
            this.button_testEnter.Location = new System.Drawing.Point(69, 62);
            this.button_testEnter.Name = "button_testEnter";
            this.button_testEnter.Size = new System.Drawing.Size(276, 23);
            this.button_testEnter.TabIndex = 0;
            this.button_testEnter.Text = "TestButton-Enter";
            this.button_testEnter.UseVisualStyleBackColor = true;
            this.button_testEnter.Click += new System.EventHandler(this.button_testEnter_Click);
            // 
            // textBox_enterY
            // 
            this.textBox_enterY.Location = new System.Drawing.Point(281, 20);
            this.textBox_enterY.Name = "textBox_enterY";
            this.textBox_enterY.Size = new System.Drawing.Size(64, 21);
            this.textBox_enterY.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "SetY:";
            // 
            // textBox_enterX
            // 
            this.textBox_enterX.Location = new System.Drawing.Point(108, 20);
            this.textBox_enterX.Name = "textBox_enterX";
            this.textBox_enterX.Size = new System.Drawing.Size(64, 21);
            this.textBox_enterX.TabIndex = 0;
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(2, 251);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(371, 23);
            this.separatorControl1.TabIndex = 9;
            // 
            // richTextBox_TEXTSINGLEINFO
            // 
            this.richTextBox_TEXTSINGLEINFO.Location = new System.Drawing.Point(6, 59);
            this.richTextBox_TEXTSINGLEINFO.Name = "richTextBox_TEXTSINGLEINFO";
            this.richTextBox_TEXTSINGLEINFO.Size = new System.Drawing.Size(350, 176);
            this.richTextBox_TEXTSINGLEINFO.TabIndex = 10;
            this.richTextBox_TEXTSINGLEINFO.Text = "";
            // 
            // EA_TEXT_SINGLE_INFO
            // 
            this.EA_TEXT_SINGLE_INFO.Controls.Add(this.button_StartClockGet);
            this.EA_TEXT_SINGLE_INFO.Controls.Add(this.label6);
            this.EA_TEXT_SINGLE_INFO.Controls.Add(this.textBox_PATH);
            this.EA_TEXT_SINGLE_INFO.Controls.Add(this.richTextBox_TEXTSINGLEINFO);
            this.EA_TEXT_SINGLE_INFO.Location = new System.Drawing.Point(2, 273);
            this.EA_TEXT_SINGLE_INFO.Name = "EA_TEXT_SINGLE_INFO";
            this.EA_TEXT_SINGLE_INFO.Size = new System.Drawing.Size(377, 247);
            this.EA_TEXT_SINGLE_INFO.TabIndex = 11;
            this.EA_TEXT_SINGLE_INFO.TabStop = false;
            this.EA_TEXT_SINGLE_INFO.Text = "EA_TEXT_SINGLE_INFO";
            // 
            // button_StartClockGet
            // 
            this.button_StartClockGet.Location = new System.Drawing.Point(253, 23);
            this.button_StartClockGet.Name = "button_StartClockGet";
            this.button_StartClockGet.Size = new System.Drawing.Size(103, 23);
            this.button_StartClockGet.TabIndex = 13;
            this.button_StartClockGet.Text = "StartClockGet";
            this.button_StartClockGet.UseVisualStyleBackColor = true;
            this.button_StartClockGet.Click += new System.EventHandler(this.button_StartClockGet_Click);
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
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.Time2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.button_TestVoiceEnter);
            this.groupBox4.Controls.Add(this.textBox_VoiceY);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBox_VoiceX);
            this.groupBox4.Location = new System.Drawing.Point(371, 140);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(364, 96);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Button_VoiceTest";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "SetX:";
            // 
            // button_TestVoiceEnter
            // 
            this.button_TestVoiceEnter.Location = new System.Drawing.Point(69, 62);
            this.button_TestVoiceEnter.Name = "button_TestVoiceEnter";
            this.button_TestVoiceEnter.Size = new System.Drawing.Size(276, 23);
            this.button_TestVoiceEnter.TabIndex = 0;
            this.button_TestVoiceEnter.Text = "TestVoice-Enter";
            this.button_TestVoiceEnter.UseVisualStyleBackColor = true;
            this.button_TestVoiceEnter.Click += new System.EventHandler(this.button_TestVoiceEnter_Click);
            // 
            // textBox_VoiceY
            // 
            this.textBox_VoiceY.Location = new System.Drawing.Point(281, 20);
            this.textBox_VoiceY.Name = "textBox_VoiceY";
            this.textBox_VoiceY.Size = new System.Drawing.Size(64, 21);
            this.textBox_VoiceY.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "SetY:";
            // 
            // textBox_VoiceX
            // 
            this.textBox_VoiceX.Location = new System.Drawing.Point(108, 20);
            this.textBox_VoiceX.Name = "textBox_VoiceX";
            this.textBox_VoiceX.Size = new System.Drawing.Size(64, 21);
            this.textBox_VoiceX.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_AutoSetingXY);
            this.groupBox5.Controls.Add(this.button_Clear);
            this.groupBox5.Location = new System.Drawing.Point(371, 45);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(364, 96);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Set-PositionS";
            // 
            // button_AutoSetingXY
            // 
            this.button_AutoSetingXY.Location = new System.Drawing.Point(53, 22);
            this.button_AutoSetingXY.Name = "button_AutoSetingXY";
            this.button_AutoSetingXY.Size = new System.Drawing.Size(276, 23);
            this.button_AutoSetingXY.TabIndex = 1;
            this.button_AutoSetingXY.Text = "AutoSetingXY";
            this.button_AutoSetingXY.UseVisualStyleBackColor = true;
            this.button_AutoSetingXY.Click += new System.EventHandler(this.button_AutoSetingXY_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(53, 52);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(276, 23);
            this.button_Clear.TabIndex = 0;
            this.button_Clear.Text = "ClearAll-XY";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button_ShotScreen);
            this.groupBox6.Location = new System.Drawing.Point(385, 264);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(350, 96);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Test-ScreenShot";
            // 
            // button_ShotScreen
            // 
            this.button_ShotScreen.Location = new System.Drawing.Point(28, 38);
            this.button_ShotScreen.Name = "button_ShotScreen";
            this.button_ShotScreen.Size = new System.Drawing.Size(276, 23);
            this.button_ShotScreen.TabIndex = 0;
            this.button_ShotScreen.Text = "BUtton-Shot-Screen";
            this.button_ShotScreen.UseVisualStyleBackColor = true;
            this.button_ShotScreen.Click += new System.EventHandler(this.button_ShotScreen_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(763, 25);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Help});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // ToolStripMenuItem_Help
            // 
            this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItem_Help.Text = "说明";
            this.ToolStripMenuItem_Help.Click += new System.EventHandler(this.ToolStripMenuItem_Help_Click);
            // 
            // textBox_Morning
            // 
            this.textBox_Morning.Location = new System.Drawing.Point(160, 24);
            this.textBox_Morning.Name = "textBox_Morning";
            this.textBox_Morning.Size = new System.Drawing.Size(116, 21);
            this.textBox_Morning.TabIndex = 10;
            this.textBox_Morning.Text = "08:00:00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "TestContent:";
            // 
            // textBox_Noon
            // 
            this.textBox_Noon.Location = new System.Drawing.Point(160, 47);
            this.textBox_Noon.Name = "textBox_Noon";
            this.textBox_Noon.Size = new System.Drawing.Size(116, 21);
            this.textBox_Noon.TabIndex = 12;
            this.textBox_Noon.Text = "12:00:00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "TestContent:";
            // 
            // textBox_Eveing
            // 
            this.textBox_Eveing.Location = new System.Drawing.Point(160, 65);
            this.textBox_Eveing.Name = "textBox_Eveing";
            this.textBox_Eveing.Size = new System.Drawing.Size(116, 21);
            this.textBox_Eveing.TabIndex = 14;
            this.textBox_Eveing.Text = "20:30:00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(37, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "TestContent:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.textBox_Process);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.textBox_Eveing);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.textBox_Noon);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.textBox_Morning);
            this.groupBox7.Location = new System.Drawing.Point(385, 381);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(350, 146);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "定时Send-MC-status";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 532);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.separatorControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_X);
            this.Controls.Add(this.textBox_Y);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EA_TEXT_SINGLE_INFO);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "服务器软件-策略信号微信预警管理终端";
            this.Load += new System.EventHandler(this.Form_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.EA_TEXT_SINGLE_INFO.ResumeLayout(false);
            this.EA_TEXT_SINGLE_INFO.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_testInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.TextBox textBox_setY;
        private System.Windows.Forms.TextBox textBox_setX;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_testEnter;
        private System.Windows.Forms.TextBox textBox_enterY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_enterX;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private System.Windows.Forms.RichTextBox richTextBox_TEXTSINGLEINFO;
        private System.Windows.Forms.GroupBox EA_TEXT_SINGLE_INFO;
        private System.Windows.Forms.Button button_StartClockGet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_PATH;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_TestVoiceEnter;
        private System.Windows.Forms.TextBox textBox_VoiceY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_VoiceX;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_AutoSetingXY;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_ShotScreen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private System.Windows.Forms.TextBox textBox_Morning;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_Noon;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_Eveing;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_Process;
    }
}

