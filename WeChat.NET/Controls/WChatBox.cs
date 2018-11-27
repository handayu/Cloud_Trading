using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using WeChat.NET.Objects;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace WeChat.NET.Controls
{
    /// <summary>
    /// 消息聊天框
    /// </summary>
    public partial class WChatBox : UserControl
    {
        public event FriendInfoViewEventHandler FriendInfoView;

        private string _friend_base64 = "data:img/jpg;base64,";
        private string _me_base64 = "data:img/jpg;base64,";

        //聊天好友
        private WXUser _friendUser;
        public WXUser FriendUser
        {
            get
            {
                return _friendUser;
            }
            set
            {
                if (value != _friendUser)
                {
                    if (_friendUser != null)
                    {
                        _friendUser.MsgRecved -= new MsgRecvedEventHandler(_friendUser_MsgRecved);
                        _friendUser.MsgSent -= new MsgSentEventHandler(_friendUser_MsgSent);
                    }
                    _friendUser = value;
                    if (_friendUser != null)
                    {
                        _friendUser.MsgRecved += new MsgRecvedEventHandler(_friendUser_MsgRecved);
                        _friendUser.MsgSent += new MsgSentEventHandler(_friendUser_MsgSent);

                        if (_friendUser.Icon != null)  //头像信息
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                _friendUser.Icon.Save(ms, ImageFormat.Png);
                                _friend_base64 = "data:img/jpg;base64," + Convert.ToBase64String(ms.ToArray());
                            }
                        }

                        webKitBrowser1.DocumentText = _totalHtml = "";

                        lblInfo.Text = "与 " + _friendUser.ShowName + " 聊天中";
                        lblInfo.Location = new Point((plTop.Width - lblInfo.Width) / 2, lblInfo.Location.Y);
                        IEnumerable<KeyValuePair<DateTime, WXMsg>> dic = _friendUser.RecvedMsg.Concat(_friendUser.SentMsg);
                        dic = dic.OrderBy(i => i.Key);
                        foreach (KeyValuePair<DateTime, WXMsg> p in dic)  //恢复聊天记录
                        {
                            if (p.Value.From == _friendUser.UserName)
                            {
                                ShowReceiveMsg(p.Value);
                            }
                            else
                            {
                                ShowSendMsg(p.Value);
                            }
                            p.Value.Readed = true;
                        }
                    }
                }
            }
        }
        //自己
        private WXUser _meUser;
        public WXUser MeUser
        {
            get
            {
                return _meUser;
            }
            set
            {
                _meUser = value;

                if (_meUser.Icon != null)  //头像信息
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        _meUser.Icon.Save(ms, ImageFormat.Png);
                        _me_base64 = "data:img/jpg;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public WChatBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WChatBox_Load(object sender, EventArgs e)
        {
            webKitBrowser1.IsWebBrowserContextMenuEnabled = false;

            this.radioButton_Start.Checked = false;
            this.radioButton_Stop.Checked = true;
        }
        /// <summary>
        /// 发送消息完成
        /// </summary>
        /// <param name="msg"></param>
        void _friendUser_MsgSent(WXMsg msg)
        {
            ShowSendMsg(msg);        
        }
        /// <summary>
        /// 收到新消息
        /// </summary>
        /// <param name="msg"></param>
        void _friendUser_MsgRecved(WXMsg msg)
        {
            ShowReceiveMsg(msg);

            if (msg.Msg.CompareTo("hi") == 0)
            {
                if (CheckProcessIsOk())
                {
                    string rm = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();
                    string cpu = ComputerInfomation.getCPUUsage();

                    SendTextMessage("Hi,服务器实时运行监控预览:");
                    SendTextMessage("   1.Multicharts进程正常运行中...");

                    SendTextMessage("   2.内存容量占用率:" + rm + "%");

                    SendTextMessage("   3.CPU使用率:" + cpu + "%");

                    //3.完成截图;
                    //SendShotScreenOperater();

                }
                else
                {

                    string rm = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();
                    string cpu = ComputerInfomation.getCPUUsage();

                    SendTextMessage("Hi,服务器运行监控预览:");
                    SendTextMessage("   1.Multicharts进程崩溃,立即检查...");

                    SendTextMessage("   2.内存容量占用率:" + rm + "%");

                    SendTextMessage("   3.CPU使用率:" + cpu + "%");

                    //3.完成截图;
                    //SendShotScreenOperater();

                }
            }
        }

        /// <summary>
        /// 点击发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && _friendUser != null && _meUser != null)
            {
                WXMsg msg = new WXMsg();
                msg.From = _meUser.UserName;
                msg.Msg = textBox1.Text;
                msg.Readed = false;
                msg.To = _friendUser.UserName;
                msg.Type = 1;
                msg.Time = DateTime.Now;

                _friendUser.SendMsg(msg, false);
            }
        }
        /// <summary>
        /// 消息输入框 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(null, null);
                e.Handled = true;
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        /// <summary>
        /// 查看详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (FriendInfoView != null)
            {
                FriendInfoView(_friendUser);
            }
        }

        private bool CheckProcessIsOk()
        {
            Process[] ps = Process.GetProcesses();
            bool findResult = false;
            foreach (Process p in ps)
            {
                if (p.ProcessName.Contains(this.textBox_Process.Text))
                {
                    findResult = true;
                }
            }
            return findResult;
        }

        private void Time2_Click(object sender, EventArgs e)
        {
            this.timer2.Stop();

            try
            {
                string dateTime = DateTime.Now.ToString("T");

                if (DateTime.Now.ToString("T").CompareTo(this.textBox_Morning.Text) == 0
                    || DateTime.Now.ToString("T").CompareTo(this.textBox_Noon.Text) == 0
                    || DateTime.Now.ToString("T").CompareTo(this.textBox_Eveing.Text) == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    if (CheckProcessIsOk())
                    {
                        string rm = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();
                        string cpu = ComputerInfomation.getCPUUsage();

                        SendTextMessage("定时服务器自检触发,服务器运行监控预览:");
                        SendTextMessage("   1.Multicharts进程正常运行中...");

                        SendTextMessage("   2.内存容量占用率:" + rm + "%");

                        SendTextMessage("   3.CPU使用率:" + cpu + "%");

                        //3.完成截图;
                        //SendShotScreenOperater();

                    }
                    else
                    {

                        string rm = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();
                        string cpu = ComputerInfomation.getCPUUsage();

                        SendTextMessage("定时服务器自检触发,服务器运行监控预览:");
                        SendTextMessage("   1.Multicharts进程崩溃,立即检查...");

                        SendTextMessage("   2.内存容量占用率:" + rm + "%");

                        SendTextMessage("   3.CPU使用率:" + cpu + "%");

                        //3.完成截图;
                        //SendShotScreenOperater();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            this.timer2.Start();
        }

        private void SendTextMessage(string text)
        {
            if (_friendUser != null && _meUser != null)
            {
                WXMsg msg = new WXMsg();
                msg.From = _meUser.UserName;
                msg.Msg = text;
                msg.Readed = false;
                msg.To = _friendUser.UserName;
                msg.Type = 1;
                msg.Time = DateTime.Now;

                _friendUser.SendMsg(msg, false);
            }
        }

        /// <summary>
        /// 大小改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WChatBox_Resize(object sender, EventArgs e)
        {
            lblInfo.Location = new Point((plTop.Width - lblInfo.Width) / 2, lblInfo.Location.Y);
        }
        #region  消息框操作相关
        /// <summary>
        /// UI界面显示发送消息
        /// </summary>
        private void ShowSendMsg(WXMsg msg)
        {
            if (_meUser == null || _friendUser == null)
            {
                return;
            }
            string str = @"<script type=""text/javascript"">window.location.hash = ""#ok"";</script> 
            <div class=""chat_content_group self"">   
            <img class=""chat_content_avatar"" src=""" + _me_base64 + @""" width=""40px"" height=""40px"">  
            <p class=""chat_nick"">" +_meUser.ShowName + @"</p>   
            <p class=""chat_content"">" + msg.Msg + @"</p>
            </div><a id='ok'></a>";
            if (_totalHtml == "")
            {
                _totalHtml = _baseHtml;
            }
            webKitBrowser1.DocumentText = _totalHtml = _totalHtml.Replace("<a id='ok'></a>", "") + str;
        }
        /// <summary>
        /// UI界面显示接收消息
        /// </summary>
        private void ShowReceiveMsg(WXMsg msg)
        {
            if (_meUser == null || _friendUser == null)
            {
                return;
            }
            string str = @"<script type=""text/javascript"">window.location.hash = ""#ok"";</script> 
            <div class=""chat_content_group buddy"">   
            <img class=""chat_content_avatar"" src=""" + _friend_base64 + @""" width=""40px"" height=""40px"">  
            <p class=""chat_nick"">" + _friendUser.ShowName + @"</p>   
            <p class=""chat_content"">" + msg.Msg + @"</p>
            </div><a id='ok'></a>";
            if (_totalHtml == "")
            {
                _totalHtml = _baseHtml;
            }
            msg.Readed = true;
            webKitBrowser1.DocumentText = _totalHtml = _totalHtml.Replace("<a id='ok'></a>", "") + str;
        }
        private string _totalHtml = "";
        private string _baseHtml = @"<html><head>
        <script type=""text/javascript"">window.location.hash = ""#ok"";</script>
        <style type=""text/css"">

        /*滚动条宽度*/  
        ::-webkit-scrollbar {  
        width: 8px;  
        }  
   
        /* 轨道样式 */  
        ::-webkit-scrollbar-track {  
        }  
   
        /* Handle样式 */  
        ::-webkit-scrollbar-thumb {  
        border-radius: 10px;  
        background: rgba(0,0,0,0.2);   
        }  
  
        /*当前窗口未激活的情况下*/  
        ::-webkit-scrollbar-thumb:window-inactive {  
        background: rgba(0,0,0,0.1);   
        }  
  
        /*hover到滚动条上*/  
        ::-webkit-scrollbar-thumb:vertical:hover{  
        background-color: rgba(0,0,0,0.3);  
        }  
        /*滚动条按下*/  
        ::-webkit-scrollbar-thumb:vertical:active{  
        background-color: rgba(0,0,0,0.7);  
        }  
        textarea{width: 500px;height: 300px;border: none;padding: 5px;}  

	    .chat_content_group.self {
        text-align: right;
        }
        .chat_content_group {
        padding: 5px;
        }
        .chat_content_group.self>.chat_content {
        text-align: left;
        }
        .chat_content_group.self>.chat_content {
        background: #7ccb6b;
        color:#fff;
        /*background: -webkit-gradient(linear,left top,left bottom,from(white,#e1e1e1));
        background: -webkit-linear-gradient(white,#e1e1e1);
        background: -moz-linear-gradient(white,#e1e1e1);
        background: -ms-linear-gradient(white,#e1e1e1);
        background: -o-linear-gradient(white,#e1e1e1);
        background: linear-gradient(#fff,#e1e1e1);*/
        }
        .chat_content {
        display: inline-block;
        min-height: 16px;
        max-width: 50%;
        color:#292929;
        background: #c3f1fd;
        font-family:微软雅黑;
        font-size:14px;
        /*background: -webkit-gradient(linear,left top,left bottom,from(#cf9),to(#9c3));
        background: -webkit-linear-gradient(#cf9,#9c3);
        background: -moz-linear-gradient(#cf9,#9c3);
        background: -ms-linear-gradient(#cf9,#9c3);
        background: -o-linear-gradient(#cf9,#9c3);
        background: linear-gradient(#cf9,#9c3);*/
        -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
        border-radius: 5px;
        padding: 10px 15px;
        word-break: break-all;
        /*box-shadow: 1px 1px 5px #000;*/
        line-height: 1.4;
        }

        .chat_content_group.self>.chat_nick {
        text-align: right;
        }
        .chat_nick {
        font-size: 14px;
        margin: 0 0 10px;
        color:#8b8b8b;
        }

        .chat_content_group.self>.chat_content_avatar {
        float: right;
        margin: 0 0 0 10px;
        }

        .chat_content_group.buddy {
        text-align: left;
        }
        .chat_content_group {
        padding: 10px;
        }
        .chat_content_avatar {
        float: left;
        width: 40px;
        height: 40px;
        margin-right: 10px;
        }
        .imgtest{margin:10px 5px;
        overflow:hidden;}
        .list_ul figcaption p{
        font-size:11px;
        color:#aaa;
        }
        .imgtest figure div{
        display:inline-block;
        margin:5px auto;
        width:100px;
        height:100px;
        border-radius:100px;
        border:2px solid #fff;
        overflow:hidden;
        -webkit-box-shadow:0 0 3px #ccc;
        box-shadow:0 0 3px #ccc;
        }
        .imgtest img{width:100%;
        min-height:100%; text-align:center;}
	    </style>
        </head><body>";
        #endregion

        private void Start_ClockCheckChanged(object sender, EventArgs e)
        {
            if (this.radioButton_Start.Checked)
            {
                if (this.textBox_PATH.Text == "")
                {
                    MessageBox.Show("请输入要获取的文本的全路径！");
                    this.radioButton_Stop.Checked = true;
                    return;
                }
                else
                {
                    //启动定时器，不断的获取该路径的txt的最后一条信息比较并根据开关是否发送
                    this.timer1.Enabled = true;
                    this.timer1.Start();
                    this.timer1.Interval = 500;//timer2控件的执行频率
                }
            }
            else
            {
                //停止搜索
                this.timer1.Enabled = false;
                this.timer1.Stop();
            }
        }

        private void TimeHoldText_EventClick(object sender, EventArgs e)
        {
            this.timer1.Stop();

            string lastSingleInfo = ReadTxt(this.textBox_PATH.Text);
            if (lastSingleInfo.CompareTo(m_lastTxtSingleInfo) == 0)
            {

            }
            else
            {
                AppendText(lastSingleInfo);

                m_lastTxtSingleInfo = lastSingleInfo;

                //1.输入内容;
                SendTextMessage("有新的交易动态:");
                SendTextMessage(m_lastTxtSingleInfo);

                //3.完成截图;
                //SendShotScreenOperater();

            }

            this.timer1.Start();
        }

        string m_lastTxtSingleInfo = "";
        public string ReadTxt(string path)
        {
            try
            {
                List<string> lastTxtSingleInfo = new List<string>();

                //设置文件共享方式为读写，FileShare.ReadWrite，这样的话，就可以打开了
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    lastTxtSingleInfo.Add(line.ToString());
                }
                if (lastTxtSingleInfo.Count == 0)
                {
                    return "";
                }
                else
                {
                    return lastTxtSingleInfo[lastTxtSingleInfo.Count - 1];
                }
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        private void AppendText(string info)
        {
            this.richTextBox_TEXTSINGLEINFO.AppendText("\r\n" + info);
        }
    }
}
