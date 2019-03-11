using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeChartNotify
{
    public partial class FormSlideRecorde : Form
    {

        private MCDataLooper m_looper = null;

        public FormSlideRecorde()
        {
            InitializeComponent();
        }

        private void button_SendNullStr_Click(object sender, EventArgs e)
        {
            IntPtr handle = (IntPtr)Convert.ToInt32(this.textBox_OutputHandle.Text, 16);
            McOutPutWndHooker hooker = new McOutPutWndHooker(handle);
            hooker.SendMessageToOutPutWnd("");

            int timer = int.MinValue;
            int.TryParse(this.textBox_timer.Text, out timer);


            if (m_looper == null)
            {
                m_looper = new MCDataLooper(handle, timer);
            }
        }

        private void button_GetOutPutContent_Click(object sender, EventArgs e)
        {
            IntPtr handle = (IntPtr)Convert.ToInt32(this.textBox_OutputHandle.Text, 16);
            McOutPutWndHooker hooker = new McOutPutWndHooker(handle);
            string result = hooker.SendMessageToHoldOutPutMessage();

            int timer = int.MinValue;
            int.TryParse(this.textBox_timer.Text, out timer);


            if (m_looper == null)
            {
                m_looper = new MCDataLooper(handle, timer);
            }

            this.richTextBox1.AppendText("\n" + result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_looper != null)
            {
                m_looper.EventReceiveOutPutData += M_looper_EventReceiveOutPutData; ;
                m_looper.Start();
            }
            else
            {
                MessageBox.Show("M_Loper为null,请先测试发送完成邦定,生成m_looper对象.");
                return;
            }
        }

        private void M_looper_EventReceiveOutPutData(string data)
        {
            
        }
    }
}
