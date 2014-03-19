//================================================================================
//  FileName: BoradcastAddressWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/30
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
using System.Net.Sockets;
using System.IO;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 广播地址设置。
    /// </summary>
    public partial class BoradcastAddressWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        UserInfo userInfo;
        bool isPluginLoad = false;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="userInfo"></param>
        public BoradcastAddressWindow(ICoreService service, UserInfo userInfo)
            : base(service)
        {
            this.userInfo = userInfo;
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="userInfo"></param>
        /// <param name="isPluginLoad"></param>
        public BoradcastAddressWindow(ICoreService service, UserInfo userInfo, bool isPluginLoad)
            : this(service, userInfo)
        {
            this.isPluginLoad = isPluginLoad;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoradcastAddressWindow_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            if (ips != null && ips.Length > 0)
            {
                this.ddlHostIP.BeginUpdate();
                this.ddlHostIP.Items.Clear();
                foreach (IPAddress ip in ips)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        this.ddlHostIP.Items.Add(ip);
                    }
                }
                this.ddlHostIP.EndUpdate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlHostIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtBroadcast.Text = string.Empty;

                this.OnClearErrorEvent();
                string strIP = this.ddlHostIP.Text.Trim();
                if (string.IsNullOrEmpty(strIP))
                {
                    this.OnSetErrorEvent(this.ddlHostIP, "请选择主机IP地址！");
                    return;
                }
                string strSub = this.txtIPSubnet.Text.Trim();
                if (string.IsNullOrEmpty(strSub))
                {
                    this.OnSetErrorEvent(this.txtIPSubnet, "请设置子网掩码！");
                    return;
                }
                IPAddress ip = null, ipsubnet = null;
                try
                {
                    ip = IPAddress.Parse(strIP);
                }
                catch (Exception x)
                {
                    this.ddlHostIP.SelectedIndex = -1;
                    this.OnSetErrorEvent(this.ddlHostIP, x.Message);
                    return;
                }
                try
                {
                    ipsubnet = IPAddress.Parse(strSub);
                }
                catch (Exception x)
                {
                    this.txtIPSubnet.Text = string.Empty;
                    this.OnSetErrorEvent(this.txtIPSubnet, x.Message);
                    return;
                }

                if (ip != null && ipsubnet != null)
                {
                    byte[] ips = ip.GetAddressBytes();
                    byte[] subs = ipsubnet.GetAddressBytes();
                    if (ips != null && subs != null)
                    {
                        //广播地址=子网按位求反再或IP地址。
                        byte[] broadcast = new byte[ips.Length];
                        for (int i = 0; i < broadcast.Length; i++)
                        {
                            broadcast[i] = (byte)((~subs[i]) | ips[i]);
                        }
                        this.txtBroadcast.Text = new IPAddress(broadcast).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                this.OnMessageEvent(MessageType.PopupInfo, ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIPSubnet_TextChanged(object sender, EventArgs e)
        {
            this.ddlHostIP_SelectedIndexChanged(this.ddlHostIP, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strBroadcast = this.txtBroadcast.Text;
                if (string.IsNullOrEmpty(strBroadcast))
                {
                    this.OnMessageEvent(MessageType.PopupInfo, "请配置广播地址！");
                    return;
                }

                HostAddress host = new HostAddress();
                host.HostIP = IPAddress.Parse(this.ddlHostIP.Text);
                host.BroadcastAddress = IPAddress.Parse(strBroadcast);
                this.CoreService.Add("hostaddress", host);

                if (!this.isPluginLoad)
                {
                    TeaSyncData teaSyncData = null;

                    try
                    {
                        teaSyncData = TeaSyncData.DeSerialize(FolderStructure.UserSyncDataFile(userInfo.UserID));
                    }
                    catch (Exception x)
                    {
                        this.OnMessageEvent(MessageType.PopupWarn, string.Format("同步的数据发生异常：{0}", x.Message));
                    }

                    if (teaSyncData != null)
                    {
                        this.CoreService.Add("teasyncdata", teaSyncData);
                        this.CoreService.AddForm(new MonitorStudentsWindow(this.CoreService));
                    }
                    else
                    {
                        this.CoreService.AddForm(new SyncDataWindow(this.CoreService, userInfo, true));
                    }

                    this.CoreService.ForceQuit = true;
                }
                this.btnClose_Click(this.btnClose, e);
            }
            catch (Exception ex)
            {
                this.OnMessageEvent(MessageType.PopupInfo, ex.Message);
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
    }
}