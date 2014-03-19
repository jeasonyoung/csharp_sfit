//================================================================================
//  FileName: StudentLoginWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/18
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

using Yaesoft.SFIT.Client.Net;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
namespace Yaesoft.SFIT.ClientStudent
{
    /// <summary>
    /// 用户登录。
    /// </summary>
    public partial class StudentLoginWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        private IPAddress hostIP;
        private UDPSocket socket;
        private PortSettings prots;
        private bool startSendLoginReq = true;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public StudentLoginWindow(ICoreService service)
            : base(service)
        {
            this.hostIP = IPAddress.Parse(string.Format("{0}", service["host_ip"]));
            this.prots = service["portsettings"] as PortSettings;
            this.socket = new UDPSocket(this.prots.HostOrder);
            this.socket.DataArrival += this.receiveHostData;
            this.socket.Changed += this.showMessage;
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentLoginWindow_Load(object sender, EventArgs e)
        {
            this.socket.Start();
            this.CoreService.ForceQuit = false;
            new Thread(new ThreadStart(delegate()
            {  
                this.OnMessageEvent(MessageType.Normal, "学生客户端发送开始登录请求...");
                int len = 10;
                while (this.startSendLoginReq && len > 0)
                {
                    this.socket.Send(new ReqLogin(), new IPEndPoint(this.hostIP, this.prots.ClientCallback));
                    len -= 1;
                    Thread.Sleep(2000);
                }
            })).Start();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBoxWork_Paint(object sender, PaintEventArgs e)
        {
            GroupBox g = sender as GroupBox;
            if (g != null && g.Controls.Count > 0)
            {
                Control child = g.Controls[0];
                if (child != null)
                {
                    int x = (g.Width - child.Width) / 2;
                    int y = (g.Height - child.Height) / 2;
                    child.Location = new Point((x < 0 ? 0 : x), (y < 0 ? 0 : y));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentLoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeSocketListener();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        protected override void OnMessageEvent(MessageType type, string content)
        {
            if ((type & MessageType.Normal) == MessageType.Normal)
            {
                if (this.lbMessage != null && !this.lbMessage.IsDisposed && this.lbMessage.Visible)
                {
                    this.ThreadSafeMethod(this.lbMessage, new MethodInvoker(delegate()
                    {
                        this.lbMessage.Text = content;
                    }));
                }
            }
            base.OnMessageEvent(type, content);
        }
        #endregion

        #region 数据处理。
        private void showMessage(string content)
        {
            this.OnMessageEvent(MessageType.Normal, content);
        }
        private void closeSocketListener()
        {
            if (this.socket != null)
            {
                this.socket.Close();
                this.socket.DataArrival -= this.receiveHostData;
                this.socket.Changed -= this.showMessage;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void receiveHostData(Msg data)
        {
            if (this.hostIP != null && data.UIP != this.hostIP.ToString()) return;
            RespLogin resp = data as RespLogin;
            if (resp != null && this.startSendLoginReq)
            {
                this.startSendLoginReq = false;
                this.OnMessageEvent(MessageType.Normal, "接收到教师机指令，分析数据...");
                this.closeSocketListener();
                this.CoreService["catalog"] = resp.Catalog;
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    this.groupBoxWork.Controls.Clear();
                    this.AddUseControls(this.groupBoxWork, new UCLogin(this.CoreService, resp.Method, resp.Students));
                }));
            }
        }
        #endregion
    }
}