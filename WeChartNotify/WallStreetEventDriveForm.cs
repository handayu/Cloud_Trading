using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            this.textBox_URL.Text = string.Format("https://api-prod.wallstreetcn.com/apiv1/content/lives?channel=commodity-channel%2Cbestanalyst-channel&client=pc&cursor={0}&limit=20&first_page=false&accept=live%2Cvip-live",int.MaxValue);
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
            this.listView_Content.Items.Clear();

            Root content = GetWallStreetHtl(this.textBox_URL.Text);

            if (content == null || content.data == null || content.data.items == null) return;

            List<ItemsItem> items = content.data.items;
            foreach(ItemsItem it in items)
            {
                this.listView_Content.Items.Add(it.content_text);
            }

            //测试发送
            if(items != null && items.Count > 0)
            {
                (m_otherForm as Form1).GiveToWallStreetEventDriveToAction(items[0].content_text);
                m_startContent = items[0].content_text;
            }
        }

        private void Loop_TickEvent(object sender, EventArgs e)
        {
            Root content = GetWallStreetHtl(this.textBox_URL.Text);

            if (content == null || content.data == null || content.data.items == null) return;

            this.listView_Content.Items.Clear();

            List<ItemsItem> items = content.data.items;
            foreach (ItemsItem it in items)
            {
                this.listView_Content.Items.Add(it.content_text);
            }

            if (items != null && items.Count > 0 && items[0].content_text.CompareTo(m_startContent) != 0)
            {
                (m_otherForm as Form1).GiveToWallStreetEventDriveToAction(items[0].content_text);
                m_startContent = items[0].content_text;
            }
        }
    }
}
