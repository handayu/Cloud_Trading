using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeChartNotify
{
    public partial class Form1 : Form
    {
        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        bool m_IsNotify = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;//timer控件的执行频率
                                      //mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 607, 385, 0, IntPtr.Zero);
            this.textBox_content.Text = "test content";

            this.radioButton_Start.Checked = false;
            this.radioButton_Stop.Checked = true;

            this.textBox_PATH.Text =  ConfigurationManager.AppSettings["path"];

        }

        public enum MouseEventFlags
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            Wheel = 0x0800,
            Absolute = 0x8000
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.MinValue;
            int y = int.MinValue;
            string content = "";

            if (this.textBox_setX.Text == "")
            {
                MessageBox.Show("请输入要设置焦点的X的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_setX.Text, out x);
            }

            if (this.textBox_setY.Text == "")
            {
                MessageBox.Show("请输入要设置焦点的y的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_setY.Text, out y);
            }

            if (this.textBox_content.Text == "")
            {
                MessageBox.Show("请输入要设置焦点的xy坐标获取焦点之后要输入的测试内容！");
                return;
            }
            else
            {
                content = this.textBox_content.Text;
            }

            //用屏幕取点工具可以得到坐标
            SetCursorPos(x, y);

            //点击获得输入的焦点
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), 0, 0, 0, IntPtr.Zero);
            System.Threading.Thread.Sleep(200);

            //输入我们需要测试的内容
            SendKeyContent(content);
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
        }

        private string m_nowX = "";
        private string m_nowY = "";
        private int m_spreadTime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.textBox_X.Text = Control.MousePosition.X.ToString();
            this.textBox_Y.Text = Control.MousePosition.Y.ToString();

            if (!m_autoSetingXY) return;

            m_nowX = Control.MousePosition.X.ToString();
            m_nowY = Control.MousePosition.Y.ToString();

            m_spreadTime = m_spreadTime + 10;

            if (Control.MousePosition.X.ToString().CompareTo(m_nowX) != 0
                || Control.MousePosition.Y.ToString().CompareTo(m_nowY) != 0)
            {
                m_spreadTime = 0;
            }

            if (Control.MousePosition.X.ToString().CompareTo(m_nowX) == 0
                && Control.MousePosition.Y.ToString().CompareTo(m_nowY) == 0
                && m_spreadTime >= 2000)
            {
                //1.先去设置输入的焦点点击坐标 
                if (this.textBox_setX.Text == "" && this.textBox_setY.Text == "")
                {
                    this.textBox_setX.Text = Control.MousePosition.X.ToString();
                    this.textBox_setY.Text = Control.MousePosition.Y.ToString();
                    m_spreadTime = 0;
                    return;
                }

                // 2.发送消息按钮点击坐标
                if (this.textBox_enterX.Text == "" && this.textBox_enterY.Text == "")
                {
                    this.textBox_enterX.Text = Control.MousePosition.X.ToString();
                    this.textBox_enterY.Text = Control.MousePosition.Y.ToString();
                    m_spreadTime = 0;
                    return;
                }

                //3.语音按钮点击坐标
                if (this.textBox_VoiceX.Text == "" && this.textBox_VoiceY.Text == "")
                {
                    this.textBox_VoiceX.Text = Control.MousePosition.X.ToString();
                    this.textBox_VoiceY.Text = Control.MousePosition.Y.ToString();
                    m_spreadTime = 0;
                    return;
                }

            }
        }

        private void button_testEnter_Click(object sender, EventArgs e)
        {
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_enterX.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的X的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_enterX.Text, out x);
            }

            if (this.textBox_enterY.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的y的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_enterY.Text, out y);
            }

            //用屏幕取点工具可以得到坐标
            SetCursorPos(x, y);
            //点击
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), x, y, 0, IntPtr.Zero);

        }

        private void button_StartClockGet_Click(object sender, EventArgs e)
        {
            if (this.textBox_PATH.Text == "")
            {
                MessageBox.Show("请输入要获取的文本的全路径！");
                return;
            }
            else
            {
                //启动定时器，不断的获取该路径的txt的最后一条信息比较并根据开关是否发送
                this.timer2.Enabled = true;
                this.timer2.Interval = 10;//timer2控件的执行频率
            }
        }

        private bool CheckProcessIsOk()
        {
            Process[] ps = Process.GetProcesses();
            bool findResult = false;
            foreach (Process p in ps)
            {
                if (p.ProcessName.Contains(this.textBox_Process.Text))
                {
                    findResult = true;
                }
            }
            return findResult;
        }

        public void GiveToOtherToAction()
        {
            if (CheckProcessIsOk())
            {
                //1.输入内容;
                SendMessageInfo("...");
                SendEnterOperater();

                SendMessageInfo("hello...mc process is going ok");
                //2.点击发送;
                SendEnterOperater();

                //3.完成截图;
                SendShotScreenOperater();

                //4.点击发送;
                SendEnterOperater();

                //5.完成以上,发语音提醒到app-QQ;
                SendEnterVoiceOperater();

            }
            else
            {

                //1.输入内容;
                SendMessageInfo("mc process is crash,attention");

                //2.点击发送;
                SendEnterOperater();

                //3.完成截图;
                SendShotScreenOperater();

                //4.点击发送;
                SendEnterOperater();

                //5.完成以上,发语音提醒到app-QQ;
                SendEnterVoiceOperater();

            }
        }


        private void SendMcStatus()
        {
            string dateTime = DateTime.Now.ToString("T");

            if (DateTime.Now.ToString("T").CompareTo(this.textBox_Morning.Text) == 0
                || DateTime.Now.ToString("T").CompareTo(this.textBox_Noon.Text) == 0
                || DateTime.Now.ToString("T").CompareTo(this.textBox_Eveing.Text) == 0)
            {
                System.Threading.Thread.Sleep(1000);
                if (CheckProcessIsOk())
                {
                    //1.输入内容;
                    SendMessageInfo("mc process is going ok");

                    //2.点击发送;
                    SendEnterOperater();

                    //3.完成截图;
                    SendShotScreenOperater();

                    //4.点击发送;
                    SendEnterOperater();

                    //5.完成以上,发语音提醒到app-QQ;
                    SendEnterVoiceOperater();

                }
                else
                {

                    //1.输入内容;
                    SendMessageInfo("mc process is crash,attention");

                    //2.点击发送;
                    SendEnterOperater();

                    //3.完成截图;
                    SendShotScreenOperater();

                    //4.点击发送;
                    SendEnterOperater();

                    //5.完成以上,发语音提醒到app-QQ;
                    SendEnterVoiceOperater();

                }
            }
        }

        private void Time2_Click(object sender, EventArgs e)
        {
            //时间警报器
            SendMcStatus();

            string lastSingleInfo = ReadTxt(this.textBox_PATH.Text);
            if (lastSingleInfo.CompareTo(m_lastTxtSingleInfo) == 0)
            {

            }
            else
            {
                AppendText(lastSingleInfo);

                m_lastTxtSingleInfo = lastSingleInfo;


                //1.输入内容;
                SendMessageInfo(m_lastTxtSingleInfo);

                //2.点击发送;
                SendEnterOperater();

                //3.完成截图;
                SendShotScreenOperater();

                //4.点击发送;
                SendEnterOperater();

                //5.完成以上,发语音提醒到app-QQ;
                SendEnterVoiceOperater();

            }
        }

        private void SendMessageInfo(string content)
        {
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_setX.Text == "")
            {
                MessageBox.Show("请输入要设置焦点的X的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_setX.Text, out x);
            }

            if (this.textBox_setY.Text == "")
            {
                MessageBox.Show("请输入要设置焦点的y的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_setY.Text, out y);
            }

            //用屏幕取点工具可以得到坐标
            SetCursorPos(x, y);

            //点击获得输入的焦点
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), 0, 0, 0, IntPtr.Zero);
            System.Threading.Thread.Sleep(200);

            //输入我们需要测试的内容
            SendKeyContent(content);
        }
        private void SendEnterOperater()
        {
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_enterX.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的X的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_enterX.Text, out x);
            }

            if (this.textBox_enterY.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的y的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_enterY.Text, out y);
            }

            //用屏幕取点工具可以得到坐标
            SetCursorPos(x, y);
            //点击
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), x, y, 0, IntPtr.Zero);

        }

        private void SendShotScreenOperater()
        {
            //1-----------------------------------------
            //屏幕宽
            int iWidth = Screen.PrimaryScreen.Bounds.Width;
            //屏幕高
            int iHeight = Screen.PrimaryScreen.Bounds.Height;
            //按照屏幕宽高创建位图
            Image img = new Bitmap(iWidth, iHeight);
            //从一个继承自Image类的对象中创建Graphics对象
            Graphics gc = Graphics.FromImage(img);
            //抓屏并拷贝到myimage里
            gc.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(iWidth, iHeight));
            //this.BackgroundImage = img;
            Clipboard.Clear();
            Clipboard.SetDataObject(img);
            //保存位图
            //img.Save(@"C:\Users\Administrator\Desktop\" + Guid.NewGuid().ToString() + ".jpg");
            System.Threading.Thread.Sleep(200);

            //2--------------------------------------------------
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_setX.Text == "")
            {
                MessageBox.Show("请输入要设置焦点的X的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_setX.Text, out x);
            }

            if (this.textBox_setY.Text == "")
            {
                MessageBox.Show("请输入要设置焦点的y的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_setY.Text, out y);
            }

            //用屏幕取点工具可以得到坐标
            SetCursorPos(x, y);

            //点击获得输入的焦点
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), 0, 0, 0, IntPtr.Zero);
            System.Threading.Thread.Sleep(200);
            //3.-------------------------------
            SendKeys.SendWait("^{V}");

            //4.-------------------------------
            System.Threading.Thread.Sleep(200);
            SendEnterOperater();
        }
        private void SendEnterVoiceOperater()
        {
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_VoiceX.Text == "")
            {
                MessageBox.Show("请输入要测试微信语音点击按钮的X的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_VoiceX.Text, out x);
            }

            if (this.textBox_VoiceY.Text == "")
            {
                MessageBox.Show("请输入要测试微信语音点击按钮的Y的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_VoiceY.Text, out y);
            }

            //用屏幕取点工具可以得到坐标
            SetCursorPos(x, y);
            //点击
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), x, y, 0, IntPtr.Zero);
        }

        string m_lastTxtSingleInfo = "";
        public string ReadTxt(string path)
        {
            try
            {
                List<string> lastTxtSingleInfo = new List<string>();

                //设置文件共享方式为读写，FileShare.ReadWrite，这样的话，就可以打开了
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    lastTxtSingleInfo.Add(line.ToString());
                }
                if (lastTxtSingleInfo.Count == 0)
                {
                    return "";
                }
                else
                {
                    return lastTxtSingleInfo[lastTxtSingleInfo.Count - 1];
                }
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        private void button_TestVoiceEnter_Click(object sender, EventArgs e)
        {
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_VoiceX.Text == "")
            {
                MessageBox.Show("请输入要测试微信语音点击按钮的X的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_VoiceX.Text, out x);
            }

            if (this.textBox_VoiceY.Text == "")
            {
                MessageBox.Show("请输入要测试微信语音点击按钮的Y的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_VoiceY.Text, out y);
            }

            //用屏幕取点工具可以得到坐标
            SetCursorPos(x, y);
            //点击
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), x, y, 0, IntPtr.Zero);
        }

        private void SendKeyContent(string context)
        {
            if (context == "" || context == null) return;
            foreach (char c in context)
            {
                SendKeys.SendWait(c.ToString());
                System.Threading.Thread.Sleep(100);
            }
        }

        private void AppendText(string info)
        {
            this.richTextBox_TEXTSINGLEINFO.AppendText("\r\n" + info);
        }

        private void Mouse_Click(object sender, MouseEventArgs e)
        {

        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_enterX.Clear();
            this.textBox_enterY.Clear();

            this.textBox_setX.Clear();
            this.textBox_setY.Clear();

            this.textBox_VoiceX.Clear();
            this.textBox_VoiceY.Clear();
        }

        private bool m_autoSetingXY = false;
        private void button_AutoSetingXY_Click(object sender, EventArgs e)
        {
            if (m_autoSetingXY == false)
            {
                m_autoSetingXY = true;
            }
            else
            {
                m_autoSetingXY = false;
            }
        }

        //1.抓全屏到剪切板-先清空剪切板，设置进去;
        //2.获取到内容的焦点准备粘贴进去;
        //3.Ctrl+V 消息粘贴进去
        //4.点发送按钮
        private void button_ShotScreen_Click(object sender, EventArgs e)
        {
            //1-----------------------------------------
            //屏幕宽
            int iWidth = Screen.PrimaryScreen.Bounds.Width;
            //屏幕高
            int iHeight = Screen.PrimaryScreen.Bounds.Height;
            //按照屏幕宽高创建位图
            Image img = new Bitmap(iWidth, iHeight);
            //从一个继承自Image类的对象中创建Graphics对象
            Graphics gc = Graphics.FromImage(img);
            //抓屏并拷贝到myimage里
            gc.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(iWidth, iHeight));
            //this.BackgroundImage = img;
            Clipboard.Clear();
            Clipboard.SetDataObject(img);
            //保存位图
            //img.Save(@"C:\Users\Administrator\Desktop\" + Guid.NewGuid().ToString() + ".jpg");
            System.Threading.Thread.Sleep(200);

            //2--------------------------------------------------
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_setX.Text == "")
            {
                MessageBox.Show("请输入要设置焦点的X的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_setX.Text, out x);
            }

            if (this.textBox_setY.Text == "")
            {
                MessageBox.Show("请输入要设置焦点的y的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_setY.Text, out y);
            }

            //用屏幕取点工具可以得到坐标
            SetCursorPos(x, y);

            //点击获得输入的焦点
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), 0, 0, 0, IntPtr.Zero);
            System.Threading.Thread.Sleep(200);
            //3.-------------------------------
            SendKeys.SendWait("^{V}");

            //4.-------------------------------
            System.Threading.Thread.Sleep(200);
            SendEnterOperater();
        }


        private void ToolStripMenuItem_Help_Click(object sender, EventArgs e)
        {
            FormHelp h = new FormHelp();
            h.Show();
        }

        private void ToolStripMenuItem_HoldScreenData_Click(object sender, EventArgs e)
        {
            FormScreenDataHolder holder = new FormScreenDataHolder();
            holder.Show();
        }

        private void ToolStripMenuItem_ScreenSeen_Click(object sender, EventArgs e)
        {
            FormShootPictureHoldString holder = new FormShootPictureHoldString();
            holder.Show();
        }

        private void ToolStripMenuItem_XiangSuToStr_Click(object sender, EventArgs e)
        {
            FormAquaScreenHoldString holder = new FormAquaScreenHoldString(this);
            holder.Show();
        }

        /// <summary>
        /// 开始和停止循环查找txt的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_ClockCheckChanged(object sender, EventArgs e)
        {
            if(this.radioButton_Start.Checked)
            {
                if (this.textBox_PATH.Text == "")
                {
                    MessageBox.Show("请输入要获取的文本的全路径！");
                    this.radioButton_Stop.Checked = true;
                    return;
                }
                else
                {
                    //启动定时器，不断的获取该路径的txt的最后一条信息比较并根据开关是否发送
                    this.timer2.Enabled = true;
                    this.timer2.Start();
                    this.timer2.Interval = 10;//timer2控件的执行频率
                }
            }
            else
            {
                //停止搜索
                this.timer2.Enabled = false;
                this.timer2.Stop();
             }
        }
    }
}
