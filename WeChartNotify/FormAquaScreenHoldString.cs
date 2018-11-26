using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCaptureXLib;

namespace WeChartNotify
{
    public partial class FormAquaScreenHoldString : Form
    {
        private ITextCaptureX obj = null;
        private bool m_IsAutoParam = false;
        private Form m_otherForm = null;
        public FormAquaScreenHoldString(Form f)
        {
            InitializeComponent();
            m_otherForm = f;
            obj = new TextCaptureX();
        }

        //获取窗口标题
        [DllImport("user32", SetLastError = true)]
        public static extern int GetWindowText(
        IntPtr hWnd, //窗口句柄
        StringBuilder lpString, //标题
        int nMaxCount  //最大值
        );
        //获取类的名字
        [DllImport("user32.dll")]
        private static extern int GetClassName(
            IntPtr hWnd, //句柄
            StringBuilder lpString, //类名
            int nMaxCount //最大值
        );
        //根据坐标获取窗口句柄
        [DllImport("user32")]
        private static extern IntPtr WindowFromPoint(
        Point Point  //坐标
        );

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private int x = 0;
        private int y = 0;
        private int x2 = 0;
        private int y2 = 0;
        private int width = 0;
        private int height = 0;
        private IntPtr handle = IntPtr.Zero;
        private StringBuilder title;
        private string m_nowX = "";
        private string m_nowY = "";
        private int m_spreadTime = 0;
        private void HoldHandle_TickEvent(object sender, EventArgs e)
        {
            if (m_IsAutoParam)
            {

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
    && m_spreadTime >= 200)
                {

                    if (this.textBox_X.Text == "" || this.textBox_Y.Text == "")
                    {
                        x = Cursor.Position.X;
                        y = Cursor.Position.Y;

                        this.textBox_X.Text = Cursor.Position.X.ToString();
                        this.textBox_Y.Text = Cursor.Position.Y.ToString();
                        m_spreadTime = 0;
                        return;
                    }

                    if (this.textBox_X2.Text == "" || this.textBox_Y2.Text == "")
                    {
                        System.Threading.Thread.Sleep(2000);
                        x2 = Cursor.Position.X;
                        y2 = Cursor.Position.Y;
                        this.textBox_X2.Text = Cursor.Position.X.ToString();
                        this.textBox_Y2.Text = Cursor.Position.Y.ToString();
                        m_spreadTime = 0;
                        return;
                    }

                    if (this.textBox_Width.Text == "" || this.textBox_Height.Text == "")
                    {
                        width = Math.Abs(x2 - x);
                        height = Math.Abs(y2 - y);

                        this.textBox_Width.Text = width.ToString();
                        this.textBox_Height.Text = height.ToString();
                        m_spreadTime = 0;
                        return;
                    }

                    if (this.textBox_Handle.Text == "")
                    {
                        Point p = new Point(x, y);
                        handle = WindowFromPoint(p);//得到窗口句柄
                        title = new StringBuilder(256);
                        GetWindowText(handle, title, title.Capacity);//得到窗口的标题
                        StringBuilder className = new StringBuilder(256);
                        this.textBox_Handle.Text = handle.ToString();
                        this.textBox_Title.Text = title.ToString();
                        m_spreadTime = 0;
                        return;
                    }
                }
            }
        }

        private string GetString()
        {
            if(obj != null)
            {
                string result = obj.GetTextFromRect(handle.ToInt32(), x, y, width, height);
                return result;
            }
            else
            {
                obj = new TextCaptureX();
                string result = obj.GetTextFromRect(handle.ToInt32(), x, y, width, height);
                return result;
            }
        }

        private void button_AutoParam_Click(object sender, EventArgs e)
        {
            m_IsAutoParam = true;
        }

        private void button_CaptureRetangle_Click(object sender, EventArgs e)
        { 
            try
            {
                button_Clear_Click(null, null);

                if(obj != null)
                {
                    string result = obj.GetTextFromRect(handle.ToInt32(), x, y, width, height);
                    this.richTextBox_Result.AppendText(result);
                }
                else
                {
                    obj = new TextCaptureX();
                    string result = obj.GetTextFromRect(handle.ToInt32(), x, y, width, height);
                    this.richTextBox_Result.AppendText(result);
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Hold Error:" + ex.Message);
            }
            finally
            {
                obj = null;
            }

        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            this.richTextBox_Result.Clear();
        }

        private void button_ClearParam_Click(object sender, EventArgs e)
        {
            this.textBox_Width.Text = "";
            this.textBox_Height.Text = "";
            this.textBox_X.Text = "";
            this.textBox_Y.Text = "";
            this.textBox_X2.Text = "";
            this.textBox_Y2.Text = "";
            this.textBox_Handle.Text = "";
            this.textBox_Title.Text = "";
            this.richTextBox_Result.Text = "";
        }

        private void SendMessage_TimeEvent(object sender, EventArgs e)
        {
            this.timer2.Stop();

            try
            {
                if (this.textBox_X.Text != "" && this.textBox_Y.Text != ""
        && this.textBox_X2.Text != "" && this.textBox_Y2.Text != ""
        && this.textBox_Width.Text != "" && this.textBox_Height.Text != ""
        && this.textBox_Handle.Text != "")
                {
                    string str = GetString();
                    if (str != null && str != "" && str.Contains("hi"))
                    {
                        (m_otherForm as Form1).GiveToOtherToAction();
                    }
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show("SendMessage error:" + ex.Message);
            }

            this.timer2.Start();
        }
    }
}
