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

        private BindingList<NotifyInfo> m_notifyBindList = new BindingList<NotifyInfo>();

        private MCDataLooper m_looper = null;
        private Form m_otherForm = null;

        public class NotifyInfo
        {
            public string Time
            {
                set;
                get;
            }

            public string Ins
            {
                set;
                get;
            }


            public string SeriesLoss
            {
                set;
                get;
            }
        }

        public FormSlideRecorde()
        {
            InitializeComponent();
        }

        public FormSlideRecorde(Form f)
        {
            InitializeComponent();

            m_otherForm = f;

            this.timer_NotifySeriesLoss.Start();

            this.dataGridView1.DataSource = this.m_notifyBindList;

            DataGridViewRowCollection rows = this.dataGridView1.Rows;
            foreach (DataGridViewRow r in rows)
            {
                r.DefaultCellStyle.BackColor = Color.White;
            }
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
            try
            {
                IntPtr handle = (IntPtr)Convert.ToInt32(this.textBox_OutputHandle.Text, 16);
                McOutPutWndHooker hooker = new McOutPutWndHooker(handle);
                string result = hooker.SendMessageToHoldOutPutMessage();

                if (m_looper == null)
                {
                    m_looper = new MCDataLooper(handle);
                }

                this.richTextBox_TradeInfo.Clear();
                m_notifyBindList.Clear();

                //转换成List然后对于收到的Print进行分类
                List<string> strInfoList = result.Split(new char[] { '\r', '\n' }).ToList();

                List<string> newStrinfoList = new List<string>();

                foreach (string str in strInfoList)
                {
                    if (str != "")
                    {
                        newStrinfoList.Add(str);
                    }
                }

                foreach (string strInfo in newStrinfoList)
                {
                    if (strInfo.Contains("NOTIFY"))
                    {
                        NotifyAppendTextRich(strInfo);
                    }
                    else
                    {
                        SingleAppendTextRich(strInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取内容分类或者超出获取的索引范围，检查...");
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer_MCOutput.Enabled = true;
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

        private void SingleAppendTextRich(string data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SingleAppendTextRich), data);
            }

            this.richTextBox_TradeInfo.AppendText("\n" + data);
        }

        private void NotifyAppendTextRich(string data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(NotifyAppendTextRich), data);
            }

            //肢解
            List<string> strList = data.Split('-').ToList();
            foreach (string s in strList)
            {
                s.Trim();
            }

            NotifyInfo info = new NotifyInfo()
            {
                Time = strList[1] + "-" + strList[2],
                Ins = strList[3],
                SeriesLoss = strList[4]
            };

            //找之前datagrid是否存在，如果不存在，直接添加，如果存在，删除，更新
            NotifyInfo tp = null;
            foreach (NotifyInfo nf in m_notifyBindList)
            {
                if (nf.Ins.Trim().CompareTo(info.Ins.Trim()) == 0)
                {
                    tp = nf;
                }
            }

            if (tp == null)
            {
                m_notifyBindList.Add(info);
            }
            else
            {
                m_notifyBindList.Remove(tp);
                m_notifyBindList.Add(info);
            }
        }

        private void TimerEvent_MCData(object sender, EventArgs e)
        {
            try
            {
                if (m_looper == null) return;
                string strMc = m_looper.GetMCData();
                if (strMc == "") return;

                //转换成List然后对于收到的Print进行分类
                List<string> strInfoList = strMc.Split(new char[] { '\r', '\n' }).ToList();

                List<string> newStrinfoList = new List<string>();

                foreach (string str in strInfoList)
                {
                    if (str != "")
                    {
                        newStrinfoList.Add(str);
                    }
                }

                foreach (string strInfo in newStrinfoList)
                {
                    if (strInfo.Contains("NOTIFY"))
                    {
                        NotifyAppendTextRich(strInfo);
                        //有连续亏损信息提示----发送文字+截图提示，不要语音，因为很频繁
                        SendGridLossSeries();
                    }
                    else
                    {
                        SingleAppendTextRich(strInfo);
                        //有交易信息发送-------发送文字+语音提示的;
                        (m_otherForm as Form1).GiveToMCOutPutToAction(strInfo);
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void SendGridLossSeries()
        {
            if (m_notifyBindList == null || m_notifyBindList.Count <= 0) return;
            string allStr = "";
            foreach (NotifyInfo f in m_notifyBindList)
            {
                string rowInfo = f.Ins + "-" + f.Time + "-" + f.SeriesLoss;
                allStr = allStr + rowInfo + "\n";
            }

            (m_otherForm as Form1).GiveToMCOutPutSeriesLossToAction(allStr);
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

        private void button_Notify_Click(object sender, EventArgs e)
        {
            FormProgram p = new FormProgram();
            p.ShowDialog();
        }

        //闪烁监控改变颜色
        private void timer_NotifySeriesLossEvent(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows = this.dataGridView1.Rows;
            foreach (DataGridViewRow r in rows)
            {
                NotifyInfo info = r.DataBoundItem as NotifyInfo;
                if (info == null || info.SeriesLoss == "") return;

                double lossnum = 0.00;
                double.TryParse(info.SeriesLoss.Trim(), out lossnum);

                double notifyLossNum = 0.00;
                double.TryParse(this.textBox_SeriesLossNotify.Text, out notifyLossNum);

                //如果亏损次数小于设定的监控次数，默认都是白色底，然后直接返回，如果大于，再更改
                if (lossnum < notifyLossNum)
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                    continue;
                }

                if (r.DefaultCellStyle.BackColor == Color.Red)
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    r.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private bool m_IsLook = false;
        private void ToolStripMenuItem_VisualOrNoEvent(object sender, EventArgs e)
        {
            if(m_IsLook == false)
            {
                this.panel2.Visible = false;
                this.richTextBox_TradeInfo.Visible = false;
                this.dataGridView1.Dock = DockStyle.Fill;
                m_IsLook = true;
            }
            else
            {
                this.panel2.Visible = true;
                this.richTextBox_TradeInfo.Visible = true;
                this.dataGridView1.Dock = DockStyle.Top;
                m_IsLook = false;
            }        
        }
    }
}
