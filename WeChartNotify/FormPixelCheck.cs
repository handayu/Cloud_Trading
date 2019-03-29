using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WeChartNotify
{
    public partial class FormPixelCheck : Form
    {

        private Form m_otherForm = null;

        public FormPixelCheck(Form f)
        {
            InitializeComponent();
            m_otherForm = f;
        }

        static POINT point;

        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int GetDC(int hwnd);
        [DllImport("gdi32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int GetPixel(int hdc, int x, int y);
        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int ReleaseDC(int hwnd, int hdc);
        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int WindowFromPoint(int x, int y);
        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int ScreenToClient(int hwnd, ref POINT lppoint);

        private struct POINT
        {
            private int x;
            private int y;
        }

        [DllImport("user32.dll")]//取设备场景 
        private static extern IntPtr GetDC(IntPtr hwnd);//返回设备场景句柄 
        [DllImport("gdi32.dll")]//取指定点颜色 
        private static extern int GetPixel(IntPtr hdc, Point p);

        public Color GetColor(int x, int y)
        {
            Point p = new Point(x, y);//取置顶点坐标 
            IntPtr hdc = GetDC(new IntPtr(0));//取到设备场景(0就是全屏的设备场景) 
            int c = GetPixel(hdc, p);//取指定点颜色 
            int r = (c & 0xFF);//转换R 
            int g = (c & 0xFF00) / 256;//转换G 
            int b = (c & 0xFF0000) / 65536;//转换B 
            return Color.FromArgb(r, g, b);
        }

        private string m_startRgbText = "";
        private void Timer_GetPirex(object sender, EventArgs e)
        {
            this.timer1.Stop();

            this.textBox_X.Text = Control.MousePosition.X.ToString();
            this.textBox_Y.Text = Control.MousePosition.Y.ToString();

            int x = int.MinValue;
            int y = int.MinValue;

            if (this.textBox_SETX.Text == "" || this.textBox_SETY.Text == "")
            {
                this.timer1.Start();
                return;
            }


            int.TryParse(this.textBox_SETX.Text, out x);
            int.TryParse(this.textBox_SETY.Text, out y);

            Color c = GetColor(x, y);

            int rgb = c.ToArgb();
            this.textBox_TargetRGB.Text = rgb.ToString();

            //如果和前值像素不一样(注意不要发动态图，因为像素值一直在切换)
            if(this.textBox_TargetRGB.Text != m_startRgbText)
            {
                //发送
                (m_otherForm as Form1).GiveToOtherToAction();

                //更新这个值
                Color cl = GetColor(x, y);
                int rgbl = c.ToArgb();
                m_startRgbText = rgbl.ToString();
            }

            this.timer1.Start();
        }

        private string m_nowX = "";
        private string m_nowY = "";
        private int m_spreadTime = 0;
        private void Timer_AutoXY(object sender, EventArgs e)
        {
            if (!m_autoSetingXY) return;

            m_nowX = Control.MousePosition.X.ToString();
            m_nowY = Control.MousePosition.Y.ToString();

            m_spreadTime = m_spreadTime + 60;

            if (Control.MousePosition.X.ToString().CompareTo(m_nowX) != 0
                || Control.MousePosition.Y.ToString().CompareTo(m_nowY) != 0)
            {
                m_spreadTime = 0;
            }

            if (Control.MousePosition.X.ToString().CompareTo(m_nowX) == 0
                && Control.MousePosition.Y.ToString().CompareTo(m_nowY) == 0
                && m_spreadTime >= 2000)
            {

                if (this.textBox_SETX.Text == "" && this.textBox_SETY.Text == "")
                {
                    this.textBox_SETX.Text = Control.MousePosition.X.ToString();
                    this.textBox_SETY.Text = Control.MousePosition.Y.ToString();

                    int x = int.MinValue;
                    int y = int.MinValue;

                    int.TryParse(this.textBox_SETX.Text, out x);
                    int.TryParse(this.textBox_SETY.Text, out y);

                    Color c = GetColor(x, y);

                    int rgb = c.ToArgb();
                    this.textBox_TargetRGB.Text = rgb.ToString();

                    m_spreadTime = 0;
                    return;
                }
            }
        }

        private bool m_autoSetingXY = false;

        private void AutoSeting_ButtonClick(object sender, EventArgs e)
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

        private void Clear_Click(object sender, EventArgs e)
        {
            this.textBox_SETX.Clear();
            this.textBox_SETY.Clear();

            this.textBox_TargetRGB.Text = "";

        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}









