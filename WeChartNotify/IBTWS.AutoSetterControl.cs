using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WeChartNotify
{
    public partial class IBTWS : UserControl
    {
        public IBTWS()
        {
            InitializeComponent();
        }

        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

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

        private void Click(int x,int y)
        {
            SetCursorPos(x, y);
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp), x, y, 0, IntPtr.Zero);
        }

        /// <summary>
        /// 按照XY坐标序列开始点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_YanShiJiaoyiIB_Click(object sender, EventArgs e)
        {
            OpenAM();
        }

        private void button_AutoSetingIBXY_Click(object sender, EventArgs e)
        {
            m_autoSetingXY = true;
        }

        private bool m_autoSetingXY = false;
        private int m_spreadTime = 0;
        private string m_nowX = "";
        private string m_nowY = "";
        private void TimeXYPicker_Event(object sender, EventArgs e)
        {
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
                //1.先去设置打开
                if (this.textBox_IBX1.Text == "" && this.textBox_IBY1.Text == "")
                {
                    this.textBox_IBX1.Text = Control.MousePosition.X.ToString();
                    this.textBox_IBY1.Text = Control.MousePosition.Y.ToString();
                    m_spreadTime = 0;
                    return;
                }

                // 2.去设置AM
                if (this.textBox_IBX2AM.Text == "" && this.textBox_IBY2AM.Text == "")
                {
                    this.textBox_IBX2AM.Text = Control.MousePosition.X.ToString();
                    this.textBox_IBY2AM.Text = Control.MousePosition.Y.ToString();
                    m_spreadTime = 0;
                    return;
                }

                // 2.去设置PM
                if (this.textBox_IBX3PM.Text == "" && this.textBox_IBY3PM.Text == "")
                {
                    this.textBox_IBX3PM.Text = Control.MousePosition.X.ToString();
                    this.textBox_IBY3PM.Text = Control.MousePosition.Y.ToString();
                    m_spreadTime = 0;
                    return;
                }

                // 2.去设置应用
                if (this.textBox_IBX4.Text == "" && this.textBox_IBY4.Text == "")
                {
                    this.textBox_IBX4.Text = Control.MousePosition.X.ToString();
                    this.textBox_IBY4.Text = Control.MousePosition.Y.ToString();
                    m_spreadTime = 0;
                    return;
                }

                // 2.去设置应用
                if (this.textBox_IBX5.Text == "" && this.textBox_IBY5.Text == "")
                {
                    this.textBox_IBX5.Text = Control.MousePosition.X.ToString();
                    this.textBox_IBY5.Text = Control.MousePosition.Y.ToString();
                    m_spreadTime = 0;
                    return;
                }
            }
        }

        private void Timer_ModifyEvent(object sender, EventArgs e)
        {
            string dateTime = DateTime.Now.ToString("T");

            if (DateTime.Now.ToString("T").CompareTo(this.textBox_AM.Text) == 0)
            {
                System.Threading.Thread.Sleep(1000);
                //打开PM进行延时
                OpenPM();
            }

            if (DateTime.Now.ToString("T").CompareTo(this.textBox_PM.Text) == 0)
            {
                System.Threading.Thread.Sleep(1000);
                //打开AM进行延时
                OpenAM();
            }
        }


        private void OpenAM()
        {
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_IBX1.Text == "" || this.textBox_IBY1.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_IBX1.Text, out x);
                int.TryParse(this.textBox_IBY1.Text, out y);

                Click(x, y);

                System.Threading.Thread.Sleep(2000);
            }

            //===========

            //====================
            if (this.textBox_IBX2AM.Text == "" || this.textBox_IBY2AM.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_IBX2AM.Text, out x);
                int.TryParse(this.textBox_IBY2AM.Text, out y);

                Click(x, y);
                System.Threading.Thread.Sleep(2000);

            }
            //=======
            if (this.textBox_IBX4.Text == "" || this.textBox_IBY4.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_IBX4.Text, out x);
                int.TryParse(this.textBox_IBY4.Text, out y);

                Click(x, y);
            }
            //=======
            if (this.textBox_IBX5.Text == "" || this.textBox_IBY5.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_IBX5.Text, out x);
                int.TryParse(this.textBox_IBY5.Text, out y);

                Click(x, y);
            }
        }

        private void OpenPM()
        {
            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_IBX1.Text == "" || this.textBox_IBY1.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_IBX1.Text, out x);
                int.TryParse(this.textBox_IBY1.Text, out y);

                Click(x, y);

                System.Threading.Thread.Sleep(2000);
            }

            //===========

            //====================
            if (this.textBox_IBX3PM.Text == "" || this.textBox_IBY3PM.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_IBX3PM.Text, out x);
                int.TryParse(this.textBox_IBY3PM.Text, out y);

                Click(x, y);
                System.Threading.Thread.Sleep(2000);

            }
            //=======
            if (this.textBox_IBX4.Text == "" || this.textBox_IBY4.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_IBX4.Text, out x);
                int.TryParse(this.textBox_IBY4.Text, out y);

                Click(x, y);
            }
            //=======
            if (this.textBox_IBX5.Text == "" || this.textBox_IBY5.Text == "")
            {
                MessageBox.Show("请输入要测试点击按钮的Int坐标！");
                return;
            }
            else
            {
                int.TryParse(this.textBox_IBX5.Text, out x);
                int.TryParse(this.textBox_IBY5.Text, out y);

                Click(x, y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenPM();
        }

        private void Timer_CheckTWS(object sender, EventArgs e)
        {
            this.timer_CheckTWS.Stop();

            if(CheckProcessIsOk())
            {
                this.pictureBox1.Image = Properties.Resources._2123123;
                this.progressBar1.Value = 0;
            }
            else
            {
                this.pictureBox1.Image = Properties.Resources._13412341;
                for(int i = 0;i<100;i++)
                {
                    this.progressBar1.Value = i;
                }
            }

            this.timer_CheckTWS.Start();
        }

        private bool CheckProcessIsOk()
        {
            Process[] ps = Process.GetProcesses();
            bool findResult = false;
            foreach (Process p in ps)
            {
                if (p.ProcessName.CompareTo(this.textBox_ProcessName.Text) == 0)
                {
                    findResult = true;
                    //MessageBox.Show("processName:" + p.ProcessName + " textBox: " + this.textBox_ProcessName.Text);
                    break;
                }
            }
            return findResult;
        }
    }
}
