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

            this.textBox_PATH.Text = ConfigurationManager.AppSettings["path"];
            this.label_ClockNotifyInfo.Text = "文本监控停止中......";
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
                //1.先去把窗口从最小化点开
                if (this.textBox_maxX.Text == "" && this.textBox_MaxY.Text == "")
                {
                    this.textBox_maxX.Text = Control.MousePosition.X.ToString();
                    this.textBox_MaxY.Text = Control.MousePosition.Y.ToString();
                    m_spreadTime = 0;
                    return;
                }

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

                //1.最后把窗口缩下去
                if (this.textBox_MinX.Text == "" && this.textBox_MinY.Text == "")
                {
                    this.textBox_MinX.Text = Control.MousePosition.X.ToString();
                    this.textBox_MinY.Text = Control.MousePosition.Y.ToString();
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

        /// <summary>
        /// 给像素识别或者图形识别了hi调用使用的外部接口
        /// </summary>
        public void GiveToOtherToAction()
        {
            if (CheckProcessIsOk())
            {
                ////MaxWeChatForm();

                ////1.输入内容;
                //SendMessageInfo("hello...");
                //SendEnterOperater();

                //SendMessageInfo("1.mc process is going ok");
                //SendEnterOperater();

                ////1.输入内容;
                //SendMessageInfo("2.memory-usage is " + ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString());
                //SendEnterOperater();

                ////1.输入内容;
                //SendMessageInfo("3.cpu-usgae is " + ComputerInfomation.getCPUUsage().ToString());
                //SendEnterOperater();

                ////3.完成截图;
                //SendShotScreenOperater();

                ////4.点击发送;
                //SendEnterOperater();

                ////5.完成以上,发语音提醒到app-QQ;
                //SendEnterVoiceOperater();

                ////MinWeChatForm();

                string content = "服务器终端实时状态:" + "\n" +
                        "1.Multicharts 进程运行良好..." + "\n" +
                        "2.内存使用率为: " + ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString() + "\n" +
                        "3.CPU使用率为: " + ComputerInfomation.getCPUUsage().ToString() + "\n";

                UseClipBoardWenziSend(content);

                //3.完成截图;
                SendShotScreenOperater();

                //4.点击发送;
                SendEnterOperater();
            }
            else
            {
                ////MaxWeChatForm();

                ////1.输入内容;
                //SendMessageInfo("hello...");
                //SendEnterOperater();

                //SendMessageInfo("1.mc process is crash,attention");
                //SendEnterOperater();

                ////1.输入内容;
                //SendMessageInfo("2.memory-usage is " + ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString());
                //SendEnterOperater();

                ////1.输入内容;
                //SendMessageInfo("3.cpu-usgae is " + ComputerInfomation.getCPUUsage().ToString());
                //SendEnterOperater();

                ////3.完成截图;
                //SendShotScreenOperater();

                ////4.点击发送;
                //SendEnterOperater();

                ////5.完成以上,发语音提醒到app-QQ;
                //SendEnterVoiceOperater();

                ////MinWeChatForm();
                string content = "服务器终端实时状态:" + "\n" +
                        "1.Multicharts 进程运行异常,请立即检查..." + "\n" +
                        "2.内存使用率为: " + ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString() + "\n" +
                        "3.CPU使用率为: " + ComputerInfomation.getCPUUsage().ToString() + "\n";

                UseClipBoardWenziSend(content);

                //3.完成截图;
                SendShotScreenOperater();

                //4.点击发送;
                SendEnterOperater();
            }
        }

        private void UseClipBoardWenziSend(string content)
        {
            Clipboard.Clear();
            Clipboard.SetDataObject(content);

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

        /// <summary>
        /// 给华尔街见闻-7*24小时新闻驱动使用的，文字信息剪切版然后复制粘贴到威信面板
        /// </summary>
        public void GiveToWallStreetEventDriveToAction(string wallStreetContent)
        {
            string c = wallStreetContent;

            Clipboard.Clear();
            Clipboard.SetDataObject(c);

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
            System.Threading.Thread.Sleep(500);
            SendEnterOperater();
        }

        private void SendMcStatus()
        {
            try
            {
                string dateTime = DateTime.Now.ToString("T");

                if (DateTime.Now.ToString("T").CompareTo(this.textBox_Morning.Text) == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    if (CheckProcessIsOk())
                    {
                        string rm = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();
                        string cpu = ComputerInfomation.getCPUUsage();

                        ////MaxWeChatForm();

                        ////1.输入内容;
                        //SendMessageInfo("1.mc process is going ok");
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("2.memory-usage is " + rm);
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("3.cpu-usgae is " + cpu);
                        //SendEnterOperater();

                        ////3.完成截图;
                        //SendShotScreenOperater();

                        ////4.点击发送;
                        //SendEnterOperater();

                        ////5.完成以上,发语音提醒到app-QQ;
                        //SendEnterVoiceOperater();

                        ////MinWeChatForm();

                        string content = string.Empty;
                        content = "服务器终端实时状态:" + "\n" +
                                    "   1.Multicharts 进程运行良好..." + "\n" +
                                    "   2.内存使用率为: " + ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString() + "\n" +
                                    "   3.CPU使用率为: " + ComputerInfomation.getCPUUsage().ToString() + "\n" + "\n";

                        //content = content + "华尔街早餐-交易人生学习: " + "\n" + ConfigurationManager.AppSettings["WallStreet1"] + "\n";

                        UseClipBoardWenziSend(content);

                        //3.完成截图;
                        SendShotScreenOperater();

                        //4.点击发送;
                        SendEnterOperater();
                    }
                    else
                    {

                        string rm = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();
                        string cpu = ComputerInfomation.getCPUUsage();

                        ////MaxWeChatForm();

                        ////1.输入内容;
                        //SendMessageInfo("1.mc process is going ok");
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("2.memory-usage is " + rm);
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("3.cpu-usgae is " + cpu);
                        //SendEnterOperater();

                        ////3.完成截图;
                        //SendShotScreenOperater();

                        ////4.点击发送;
                        //SendEnterOperater();

                        ////5.完成以上,发语音提醒到app-QQ;
                        //SendEnterVoiceOperater();

                        ////MinWeChatForm();

                        string content = string.Empty;
                        content = "服务器终端实时状态:" + "\n" +
                                    "   1.Multicharts 进程运行异常,请立即检查..." + "\n" +
                                    "   2.内存使用率为: " + ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString() + "\n" +
                                    "   3.CPU使用率为: " + ComputerInfomation.getCPUUsage().ToString() + "\n" + "\n";

                        //content = content + "华尔街早餐-交易人生学习: " + "\n" + ConfigurationManager.AppSettings["WallStreet1"] + "\n";

                        UseClipBoardWenziSend(content);

                        //3.完成截图;
                        SendShotScreenOperater();

                        //4.点击发送;
                        SendEnterOperater();
                    }
                }

                if (DateTime.Now.ToString("T").CompareTo(this.textBox_Noon.Text) == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    if (CheckProcessIsOk())
                    {
                        string rm = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();
                        string cpu = ComputerInfomation.getCPUUsage();

                        ////MaxWeChatForm();

                        ////1.输入内容;
                        //SendMessageInfo("1.mc process is going ok");
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("2.memory-usage is " + rm);
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("3.cpu-usgae is " + cpu);
                        //SendEnterOperater();

                        ////3.完成截图;
                        //SendShotScreenOperater();

                        ////4.点击发送;
                        //SendEnterOperater();

                        ////5.完成以上,发语音提醒到app-QQ;
                        //SendEnterVoiceOperater();

                        ////MinWeChatForm();

                        string content = string.Empty;
                        content = "服务器终端实时状态:" + "\n" +
                                    "   1.Multicharts 进程运行良好..." + "\n" +
                                    "   2.内存使用率为: " + ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString() + "\n" +
                                    "   3.CPU使用率为: " + ComputerInfomation.getCPUUsage().ToString() + "\n" + "\n";

                        //content = content + "华尔街午餐-全球即时要闻: " + "\n" + ConfigurationManager.AppSettings["WallStreet2"] + "\n";

                        UseClipBoardWenziSend(content);

                        //3.完成截图;
                        SendShotScreenOperater();

                        //4.点击发送;
                        SendEnterOperater();
                    }
                    else
                    {

                        string rm = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();
                        string cpu = ComputerInfomation.getCPUUsage();

                        ////MaxWeChatForm();

                        ////1.输入内容;
                        //SendMessageInfo("1.mc process is going ok");
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("2.memory-usage is " + rm);
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("3.cpu-usgae is " + cpu);
                        //SendEnterOperater();

                        ////3.完成截图;
                        //SendShotScreenOperater();

                        ////4.点击发送;
                        //SendEnterOperater();

                        ////5.完成以上,发语音提醒到app-QQ;
                        //SendEnterVoiceOperater();

                        ////MinWeChatForm();

                        string content = string.Empty;
                        content = "服务器终端实时状态:" + "\n" +
                                    "   1.Multicharts 进程运行异常,请立即检查..." + "\n" +
                                    "   2.内存使用率为: " + ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString() + "\n" +
                                    "   3.CPU使用率为: " + ComputerInfomation.getCPUUsage().ToString() + "\n" + "\n";

                        //content = content + "华尔街午餐-全球即时要闻: " + "\n" + ConfigurationManager.AppSettings["WallStreet2"] + "\n";

                        UseClipBoardWenziSend(content);

                        //3.完成截图;
                        SendShotScreenOperater();

                        //4.点击发送;
                        SendEnterOperater();
                    }
                }

                if (DateTime.Now.ToString("T").CompareTo(this.textBox_Eveing.Text) == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    if (CheckProcessIsOk())
                    {
                        string rm = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();
                        string cpu = ComputerInfomation.getCPUUsage();

                        ////MaxWeChatForm();

                        ////1.输入内容;
                        //SendMessageInfo("1.mc process is going ok");
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("2.memory-usage is " + rm);
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("3.cpu-usgae is " + cpu);
                        //SendEnterOperater();

                        ////3.完成截图;
                        //SendShotScreenOperater();

                        ////4.点击发送;
                        //SendEnterOperater();

                        ////5.完成以上,发语音提醒到app-QQ;
                        //SendEnterVoiceOperater();

                        ////MinWeChatForm();

                        string content = string.Empty;
                        content = "服务器终端实时状态:" + "\n" +
                                    "   1.Multicharts 进程运行良好..." + "\n" +
                                    "   2.内存使用率为: " + ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString() + "\n" +
                                    "   3.CPU使用率为: " + ComputerInfomation.getCPUUsage().ToString() + "\n" + "\n";

                        //content = content + "华尔街晚餐-大宗商品情报: " + "\n" + ConfigurationManager.AppSettings["WallStreet3"] + "\n";

                        UseClipBoardWenziSend(content);

                        //3.完成截图;
                        SendShotScreenOperater();

                        //4.点击发送;
                        SendEnterOperater();
                    }
                    else
                    {

                        string rm = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();
                        string cpu = ComputerInfomation.getCPUUsage();

                        ////MaxWeChatForm();

                        ////1.输入内容;
                        //SendMessageInfo("1.mc process is going ok");
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("2.memory-usage is " + rm);
                        //SendEnterOperater();

                        ////1.输入内容;
                        //SendMessageInfo("3.cpu-usgae is " + cpu);
                        //SendEnterOperater();

                        ////3.完成截图;
                        //SendShotScreenOperater();

                        ////4.点击发送;
                        //SendEnterOperater();

                        ////5.完成以上,发语音提醒到app-QQ;
                        //SendEnterVoiceOperater();

                        ////MinWeChatForm();

                        string content = string.Empty;
                        content = "服务器终端实时状态:" + "\n" +
                                    "   1.Multicharts 进程运行异常,请立即检查..." + "\n" +
                                    "   2.内存使用率为: " + ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString() + "\n" +
                                    "   3.CPU使用率为: " + ComputerInfomation.getCPUUsage().ToString() + "\n" + "\n";

                        //content = content + "华尔街晚餐-大宗商品情报: " + "\n" + ConfigurationManager.AppSettings["WallStreet3"] + "\n";

                        UseClipBoardWenziSend(content);

                        //3.完成截图;
                        SendShotScreenOperater();

                        //4.点击发送;
                        SendEnterOperater();
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void Time2_Click(object sender, EventArgs e)
        {
            this.timer2.Stop();

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

                ////MaxWeChatForm();

                ////1.输入内容;
                //SendMessageInfo(m_lastTxtSingleInfo);

                ////2.点击发送;
                //SendEnterOperater();

                ////3.完成截图;
                //SendShotScreenOperater();

                ////4.点击发送;
                //SendEnterOperater();

                ////5.完成以上,发语音提醒到app-QQ;
                //SendEnterVoiceOperater();

                ////MinWeChatForm();

                string content = "服务器端Multicharts有新的成交信息:" + "\n" +
                    m_lastTxtSingleInfo + "\n";

                UseClipBoardWenziSend(content);

                //3.完成截图;
                SendShotScreenOperater();

                //4.点击发送;
                SendEnterOperater();
            }

            this.timer2.Start();
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
            System.Threading.Thread.Sleep(600);

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

        public void ClearTxt(string path)
        {
            try
            {
                //设置文件共享方式为读写，FileShare.ReadWrite，这样的话，就可以打开了
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                fs.SetLength(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("清空文本失败:" + ex.Message);
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

            this.textBox_maxX.Clear();
            this.textBox_MaxY.Clear();

            this.textBox_MinX.Clear();
            this.textBox_MinY.Clear();
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
            if (this.radioButton_Start.Checked)
            {
                if (this.textBox_PATH.Text == "")
                {
                    MessageBox.Show("请输入要获取的文本的全路径！");
                    this.radioButton_Stop.Checked = true;
                    this.label_ClockNotifyInfo.Text = "文本路径为空,无法打开监控,重新输入再次开启..";
                    return;
                }
                else
                {
                    //重新打开的时候，先把m_lastInfo重新置位“”，并且清空我们跟踪的文本，免得刚启动因为我们各回测往txt又写入了
                    //新的文本，然后立即比较就报警，所以先重置，重新监控新的文本更新
                    m_lastTxtSingleInfo = "";
                    //
                    ClearTxt(this.textBox_PATH.Text);
                    //
                    this.richTextBox_TEXTSINGLEINFO.Clear();

                    //启动定时器，不断的获取该路径的txt的最后一条信息比较并根据开关是否发送
                    this.timer2.Enabled = true;
                    this.timer2.Start();
                    this.timer2.Interval = 10;//timer2控件的执行频率

                    this.label_ClockNotifyInfo.Text = "重置起始状态,清空文本,启动监控.....";

                }
            }
            else
            {
                //停止搜索
                this.timer2.Enabled = false;
                this.timer2.Stop();

                this.label_ClockNotifyInfo.Text = "停止文本信号监控......";

            }
        }

        private void ibtws1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 计算机器实时状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_realInfo_Click(object sender, EventArgs e)
        {
            FormRealComputerInfo holder = new FormRealComputerInfo();
            holder.Show();
        }

        private void button_TestMaxForm_Click(object sender, EventArgs e)
        {
            MaxWeChatForm();

        }

        private void button_TestMinForm_Click(object sender, EventArgs e)
        {
            MinWeChatForm();
        }

        private void MaxWeChatForm()
        {
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_maxX.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的X的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_maxX.Text, out x);
            }

            if (this.textBox_MaxY.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的y的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_MaxY.Text, out y);
            }

            //用屏幕取点工具可以得到坐标
            SetCursorPos(x, y);
            //点击
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), x, y, 0, IntPtr.Zero);
        }

        private void MinWeChatForm()
        {
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_MinX.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的X的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_MinX.Text, out x);
            }

            if (this.textBox_MinY.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的y的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_MinY.Text, out y);
            }

            //用屏幕取点工具可以得到坐标
            SetCursorPos(x, y);
            //点击
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), x, y, 0, IntPtr.Zero);

        }

        private void ToolStripMenuIteｍ_pirexHolder_Click(object sender, EventArgs e)
        {
            FormPixelCheck holder = new FormPixelCheck(this);
            holder.Show();
        }

        private void ToolStripMenuItem_EventDrive_Click(object sender, EventArgs e)
        {
            WallStreetEventDriveForm holder = new WallStreetEventDriveForm(this);
            holder.Show();
        }

        private void ToolStripMenuItem_MonthInspire_Click(object sender, EventArgs e)
        {
            FormSymbolInspireMonthNotify holder = new FormSymbolInspireMonthNotify();
            holder.Show();
        }
    }
}
