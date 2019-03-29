using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeChartNotify
{
    public partial class FormSlideRecorde : Form
    {

        private MCDataLooper m_looper = null;
        private Form m_otherForm = null;

        public FormSlideRecorde()
        {
            InitializeComponent();
        }

        public FormSlideRecorde(Form f)
        {
            InitializeComponent();

            m_otherForm = f;
        }

        private void button_SendNullStr_Click(object sender, EventArgs e)
        {
            IntPtr handle = (IntPtr)Convert.ToInt32(this.textBox_OutputHandle.Text, 16);
            McOutPutWndHooker hooker = new McOutPutWndHooker(handle);
            hooker.SendMessageToOutPutWnd("");

            if (m_looper == null)
            {
                m_looper = new MCDataLooper(handle);
            }
        }

        private void button_GetOutPutContent_Click(object sender, EventArgs e)
        {
            IntPtr handle = (IntPtr)Convert.ToInt32(this.textBox_OutputHandle.Text, 16);
            McOutPutWndHooker hooker = new McOutPutWndHooker(handle);
            string result = hooker.SendMessageToHoldOutPutMessage();

            if (m_looper == null)
            {
                m_looper = new MCDataLooper(handle);
            }

            this.richTextBox1.Clear();
            this.richTextBox1.AppendText("\n" + result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer_MCOutput.Start();
            this.button_Start.Enabled = false;
            this.button_Start.ForeColor = Color.Aqua;

            this.button_Stop.Enabled = true;
            this.button_Stop.ForeColor = Color.Red;
        }

        private void Button_StopClick(object sender, EventArgs e)
        {
            this.timer_MCOutput.Stop();

            this.button_Start.Enabled = true;
            this.button_Start.ForeColor = Color.Red;

            this.button_Stop.Enabled = false;
            this.button_Stop.ForeColor = Color.Aqua;
        }

        private void AppendTextRich(string data)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AppendTextRich),data);
            }

            this.richTextBox1.AppendText("\n" + data);
        }

        private void TimerEvent_MCData(object sender, EventArgs e)
        {
            if (m_looper == null) return;
            string strMc = m_looper.GetMCData();
            if (strMc == "") return;
            //添加到appendBox，并一起发送到QQ
            AppendTextRich(strMc);

            //发送;
            (m_otherForm as Form1).GiveToMCOutPutToAction(strMc);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\config.ini";
            IniOperationClass c = new IniOperationClass(path);
            this.textBox_OutputHandle.Text = c.IniReadValue("MCHandle", "Handle");
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\config.ini";
            IniOperationClass c = new IniOperationClass(path);
            c.IniWriteValue("MCHandle", "Handle", this.textBox_OutputHandle.Text);
        }
    }
}
