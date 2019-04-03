using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UseHttpHelper;

namespace WeChartNotify
{
    public partial class FormSymbolInspireMonthNotify : Form
    {
        private List<string> m_nowHotMon = new List<string>();
        private Form m_otherForm = new Form();

        public FormSymbolInspireMonthNotify()
        {
            InitializeComponent();
        }

        public FormSymbolInspireMonthNotify(Form f)
        {
            InitializeComponent();
            m_otherForm = f;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void Form_load(object sender, EventArgs e)
        {
            this.textBox_URL.Text = string.Format("http://hotmap.icetech.com.cn/hotmap.html");

            string path = System.Windows.Forms.Application.StartupPath + "\\config.ini";
            IniOperationClass c = new IniOperationClass(path);
            this.textBox1.Text = c.IniReadValue("HOT", "Instrument");
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\config.ini";
            IniOperationClass c = new IniOperationClass(path);
            c.IniWriteValue("HOT", "Instrument", this.textBox1.Text);
        }

        private void Timer_SendEvent(object sender, EventArgs e)
        {
            string dateTime = DateTime.Now.ToString("T");

            if (DateTime.Now.ToString("T").CompareTo(this.textBox_SendTime.Text) == 0)
            {

                HttpHelper hh = new HttpHelper();
                HttpItem hi = new HttpItem();
                hi.Encoding = Encoding.Default;
                hi.URL = this.textBox_URL.Text;
                HttpResult hr = hh.GetHtml(hi);

                string htmlStr = hr.Html;

                string regEx_style = "<style[^>]*?>[\\s\\S]*?<\\/style>"; //定义style的正则表达式 
                string regEx_script = "<script[^>]*?>[\\s\\S]*?<\\/script>"; //定义script的正则表达式 
                string regEx_html = "<[^>]+>"; //定义HTML标签的正则表达式 
                htmlStr = Regex.Replace(htmlStr, regEx_style, "");//删除css
                htmlStr = Regex.Replace(htmlStr, regEx_script, "");//删除js
                htmlStr = Regex.Replace(htmlStr, regEx_html, "-");//删除html标记
                htmlStr = Regex.Replace(htmlStr, "\\s*|\t|\r|\n", "");//去除tab、空格、空行
                htmlStr = htmlStr.Replace(" ", "");
                htmlStr = htmlStr.Replace('"', ' ');//去除异常的引号" " "

                List<string> ArrayListIns = Regex.Split(htmlStr, "----", RegexOptions.IgnoreCase).ToList();
                //把下一条单独一行的换月提醒移动到上一条
                for (int i = 0; i < ArrayListIns.Count; i++)
                {
                    if (ArrayListIns[i].Contains("Change"))
                    {
                        ArrayListIns[i - 1] = ArrayListIns[i - 1] + ArrayListIns[i];
                    }
                }

                m_nowHotMon = ArrayListIns;

                this.richTextBox_SymbolMonth.Clear();
                foreach (string s in ArrayListIns)
                {
                    this.richTextBox_SymbolMonth.AppendText("\n" + s);
                }

                SendAllInfo();

                System.Threading.Thread.Sleep(3000);

                SendSelfInfo();
            }
        }

        /// <summary>
        /// 发送自定义信息 
        /// </summary>
        private void SendSelfInfo()
        {
            string strAll = "当前正在交易的品种的热门月(注意比对并合适时机切换):";
            List<string> selInsList = this.textBox1.Text.Split(',').ToList();

            foreach (string selI in selInsList)
            {
                foreach (string s in m_nowHotMon)
                {
                    if(s.Contains(selI)) strAll = strAll + "\n" + s;
                }
            }

            (m_otherForm as Form1).GiveToHOTMonthToAction(strAll);

        }

        //发送全量的品种换月信息 
        private void SendAllInfo()
        {
            string strAll = "全市场主力热门合约表:";
            foreach (string s in m_nowHotMon)
            {
                strAll = strAll + "\n" + s;
            }

            (m_otherForm as Form1).GiveToHOTMonthToAction(strAll);
        }
    }
}
