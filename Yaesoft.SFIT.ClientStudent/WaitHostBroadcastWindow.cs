//================================================================================
//  FileName: WaitHostWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/16
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

using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.ClientStudent.Data;
using Yaesoft.SFIT.ClientStudent.Forms;
namespace Yaesoft.SFIT.ClientStudent
{
    /// <summary>
    /// 等待主机广播。
    /// </summary>
    public partial class WaitHostBroadcastWindow : BaseWindow, IReceiveBroadcast
    {
        #region 成员变量，构造函数。
        DateTime beginRuntime = DateTime.Now;
        DataObserver observer;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public WaitHostBroadcastWindow(ICoreService service)
            : base(service)
        {
            this.observer = new DataObserver();
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        private void WaitHostBroadcastWindow_Load(object sender, EventArgs e)
        {
            this.observer.Observer += this.ListenBroadcastHandler;
            this.lbBroadcastMessage.Text = this.lbBroadcastMessage.Text = string.Empty;
            this.CoreService.ForceQuit = false;
            this.btnSave.Enabled = false;
            this.OnMessageEvent(MessageType.Normal, string.Empty);
            this.timer.Tick += this.timer_Tick;
            this.timer.Enabled = true;
            ClientInitialService cis = this.CoreService as ClientInitialService;
            if (cis != null)
            {
                cis.LoadingInitial(this, new EventHandler(delegate(object o, EventArgs s)
                {
                    this.ThreadSafeMethod(new MethodInvoker(delegate()
                    {
                        if (!this.btnSave.Enabled) this.btnSave.Enabled = true;
                    }));
                }));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now - this.beginRuntime;
            this.lbRunTime.Text = string.Format("{0}:{1}'s", this.lbRunTime.Text.Split(':')[0], (int)ts.TotalSeconds);
        }

        private void ListenBroadcastHandler(List<HostBroadcast> items)
        {
            this.cbbTeaHost.BeginUpdate();
            this.cbbTeaHost.DataSource = items;
            this.cbbTeaHost.DisplayMember = "SName";
            this.cbbTeaHost.ValueMember = "SName";
            this.cbbTeaHost_SelectedIndexChanged(this.cbbTeaHost, EventArgs.Empty);
            this.cbbTeaHost.EndUpdate();
        }

        private void cbbTeaHost_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb != null)
            {
                HostBroadcast data = cbb.SelectedItem as HostBroadcast;
                if (data != null)
                {
                    this.txtHostInfo.Text = string.Format("主机名称：{0}\r\n主机地址：{1}\r\n主机ID：{2}", data.SName, data.UIP, data.UID);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HostBroadcast data = this.cbbTeaHost.SelectedItem as HostBroadcast;
            if (this.cbbTeaHost.SelectedIndex > -1 && data != null)
            {
                this.CoreService["host_sname"] = data.SName;
                this.CoreService["host_id"] = data.UID;
                this.CoreService["host_ip"] = data.UIP;
                if (data.Ports != null)
                {
                    try
                    {
                        ClientNetPortSettingsMgr.Serializer(data.Ports);
                    }
                    catch (Exception) { }
                    this.CoreService["portsettings"] = data.Ports;
                }
                //下一个界面。
                this.CoreService.AddForm(new StudentLoginWindow(this.CoreService));
                this.CoreService.ForceQuit = true;
                this.btnClose_Click(sender, e);
            }
        }
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible)
                this.Hide();
            else
                this.Show();
        }
        #endregion

        #region 重载。
        protected override void OnMessageEvent(MessageType type, string content)
        {
            if ((type & MessageType.Normal) == MessageType.Normal)
            {
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    this.lbMessage.Text = content;
                }));
            }
            base.OnMessageEvent(type, content);
        }
        #endregion

        #region IReceiveBroadcast 成员

        public void ReceiveBroadcast(Broadcast data)
        {
            if (data != null)
            {
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    string str = this.lbBroadcastMessage.Text;
                    this.lbBroadcastMessage.Text = string.Format("{0}\r\n{1}", data, str);
                    HostBroadcast host = data as HostBroadcast;
                    if (host != null && this.observer != null)
                    {
                        this.observer.AddDataObserver(host);
                    }
                }));
            }
        }

        #endregion
    }
}
