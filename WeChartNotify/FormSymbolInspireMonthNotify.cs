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
    public partial class FormSymbolInspireMonthNotify : Form
    {
        public FormSymbolInspireMonthNotify()
        {
            InitializeComponent();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {

                HttpHelper hh = new HttpHelper();
                HttpItem hi = new HttpItem();
                hi.Encoding = Encoding.Default;
                hi.URL = this.textBox_URL.Text;
                HttpResult hr = hh.GetHtml(hi);     
        }

        //public Root GetWallStreetHtl(string nurl)
        //{

        //    string url = nurl;
        //    string hr = GetData(url);
        //    if (hr != null)
        //    {
        //        try
        //        {
        //            Root bi = Deserialize<Root>(hr);
        //            if (bi != null)
        //            {
        //                return bi;
        //            }
        //        }
        //        catch (Exception err)
        //        {
        //            //在这里只是捕获，但是不做处理 ，保证程序继续执行
        //            //MessageBox.Show("解析出现问题，请检查:" + err.Message);
        //        }
        //    }

        //    return null;
        //}

        ///// <summary>
        ///// 反序列化成对象
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public T Deserialize<T>(string obj)
        //{
        //    return JsonConvert.DeserializeObject<T>(obj);
        //}

        //private string GetData(string url)
        //{
        //    HttpHelper hh = new HttpHelper();
        //    HttpItem hi = new HttpItem();
        //    hi.Encoding = Encoding.UTF8;
        //    hi.URL = url;
        //    HttpResult hr = hh.GetHtml(hi);
        //    if (hr != null)
        //    {
        //        return hr.Html;
        //    }
        //    return null;
        //}

        private void Form_load(object sender, EventArgs e)
        {
            this.textBox_URL.Text = string.Format("http://hotmap.icetech.com.cn/hotmap.html");
        }
    }
}
