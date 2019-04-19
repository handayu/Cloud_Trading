using Newtonsoft.Json;
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
    public partial class WallStreetEventDriveForm : Form
    {

        private string m_startContent = "";

        private Form m_otherForm = null;

        public WallStreetEventDriveForm(Form f)
        {
            InitializeComponent();
            m_otherForm = f;

            this.textBox_URL.Text = string.Format("https://wallstreetcn.com/live/commodity");
        }


        public class ItemsItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string article { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> channels { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string content_more { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string content_text { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int display_time { get; set; }
            /// <summary>
            /// 7x24快讯
            /// </summary>
            public string global_channel_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string global_more_uri { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> image_uris { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string is_favourite { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string is_priced { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string reference { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string related_themes { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int score { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> symbols { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> tags { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string title { get; set; }
        }

        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public List<ItemsItem> items { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string next_cursor { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string polling_cursor { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string message { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Data data { get; set; }
        }

        public List<string> GetWallStreetHtlStr(string nurl)
        {
            string url = nurl;
            string hr = GetData(url);
            if (hr != null)
            {

                string htmlStr = hr;
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

                //获取到网页原版本的Html之后，经过正则表达式处理之后，然后清理，清除多余的不需要的"",等字符，取到第一条最新的返回
                List<string> ArrayNewList = new List<string>();
                foreach (string str in ArrayListIns)
                {
                    if (str != "")
                    {
                        string newStr = str.Replace("-", " ").Trim();
                        ArrayNewList.Add(newStr);
                    }
                }

                return ArrayNewList;

            }
            else
            {
                return null;
            }

        }

        public Root GetWallStreetHtl(string nurl)
        {

            string url = nurl;
            string hr = GetData(url);
            if (hr != null)
            {

                try
                {
                    Root bi = Deserialize<Root>(hr);
                    if (bi != null)
                    {
                        return bi;
                    }
                }
                catch (Exception err)
                {
                    //在这里只是捕获，但是不做处理 ，保证程序继续执行
                    //MessageBox.Show("解析出现问题，请检查:" + err.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 反序列化成对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Deserialize<T>(string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }


        private string GetData(string url)
        {
            HttpHelper hh = new HttpHelper();
            HttpItem hi = new HttpItem();
            hi.Encoding = Encoding.UTF8;
            hi.URL = url;
            HttpResult hr = hh.GetHtml(hi);
            if (hr != null)
            {
                return hr.Html;
            }
            return null;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            try
            {
                this.richTextBox1.Clear();

                //Root content = GetWallStreetHtl(this.textBox_URL.Text);

                //if (content == null || content.data == null || content.data.items == null) return;

                //List<ItemsItem> items = content.data.items;
                //foreach(ItemsItem it in items)
                //{
                //    this.listView_Content.Items.Add(it.content_text);
                //}

                List<string> aList = GetWallStreetHtlStr(this.textBox_URL.Text);
                if (aList == null) return;
                foreach (string sr in aList)
                {
                    this.richTextBox1.AppendText(sr + "\n");
                }

                //测试发送
                if (aList != null && aList.Count > 0)
                {
                    int indexStart = 0;


                    for (int i = 0; i < aList.Count; i++)
                    {
                        if (aList[i].Contains("联合制作"))
                        {
                            indexStart = i;
                            break;
                        }
                    }

                    string sendInfo = aList[indexStart + 1] + "\n" + aList[indexStart + 2];

                    //(m_otherForm as Form1).GiveToWallStreetEventDriveToAction(sendInfo);
                    m_startContent = sendInfo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取信息发生异常,尝试检查获取的html和arraylist硬编码，因为华尔街见闻的改版：" + ex.Message);
                return;
            }

        }

        private void Loop_TickEvent(object sender, EventArgs e)
        {
            try
            {
                this.richTextBox1.Clear();

                List<string> aList = GetWallStreetHtlStr(this.textBox_URL.Text);
                if (aList == null) return;
                foreach (string sr in aList)
                {
                    this.richTextBox1.AppendText(sr + "\n");
                }

                if (aList != null && aList.Count > 0)
                {
                    int indexStart = 0;

                    for (int i = 0; i < aList.Count; i++)
                    {
                        if (aList[i].Contains("联合制作"))
                        {
                            indexStart = i;
                            break;
                        }
                    }

                    string sendInfo = aList[indexStart + 1] + "\n" + aList[indexStart + 2];
                    if (sendInfo.CompareTo(m_startContent) == 0) return;

                    //(m_otherForm as Form1).GiveToWallStreetEventDriveToAction(sendInfo);
                    m_startContent = sendInfo;
                }
            }
            catch (Exception ex)
            {
                (m_otherForm as Form1).GiveToWallStreetEventDriveToAction("获取信息发生异常,尝试检查获取的html和arraylist硬编码，因为华尔街见闻的改版:" + ex.Message);
                return;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}
