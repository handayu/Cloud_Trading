using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XDICTGRB;

//LINK：https://bbs.csdn.net/topics/370081360
//LINK:https://www.cnblogs.com/jiangj/archive/2010/09/26/1836159.html
//主要是想利用金山词霸的取词去取屏幕的词，但是并没有成功实现
namespace WeChartNotify
{
    public partial class FormScreenDataHolder : Form, IXDictGrabSink
    {
        private GrabProxy gp;

        public FormScreenDataHolder()
        {
            InitializeComponent();
        }

        //窗口永远置前
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern int SetWindowPos(
         IntPtr hwnd,
         int hWndInsertAfter,
         int x,
         int y,
         int cx,
         int cy,
         int wFlags);

        private void Form_Load(object sender, EventArgs e)
        {
            //窗口永远置前
            SetWindowPos(this.Handle, -1, Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2, this.Width, this.Height, 0);
            gp = new GrabProxy();
            gp.GrabInterval = 1;//指抓取时间间\隔 
            gp.GrabMode = XDictGrabModeEnum.XDictGrabMouse;//设定取词的属性 
            gp.GrabFlag = XDictGrabFlagEnum.XDictGrabOnlyEnglish;//只取英文
            gp.GrabEnabled = true;//是否取词的属性 
            gp.AdviseGrab(this);

        }

        //接口的实现 
        int IXDictGrabSink.QueryWord(string WordString, int lCursorX, int lCursorY, string SentenceString, ref int lLoc, ref int lStart)
        {
            this.textBox4.Text = SentenceString;//鼠标所在语句 
            this.textBox2.Text = SentenceString.Substring(lLoc, 1);//鼠标所在字符 
            this.textBox3.Text = lCursorX.ToString() + " " + lCursorY.ToString();
            this.textBox1.Text = GetWord(SentenceString, lLoc + 1);//取得单词
            return 1;
        }

        //取得单词的Method
        private string GetWord(string SentenceString, int lLoc)
        {
            int iR = 0;
            int iL = 0;
            int ilen = 0;
            ilen = SentenceString.Length;
            String str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (iL = lLoc; iL > 0; iL--)
            {
                if (str.IndexOf(SentenceString.Substring(iL, 1)) == -1)
                    break;
            }
            for (iR = lLoc; iR < ilen; iR++)
            {
                if (str.IndexOf(SentenceString.Substring(iR, 1)) == -1)
                    break;
            }
            return SentenceString.Substring(iL + 1, iR - iL - 1);
        }

    }
}
