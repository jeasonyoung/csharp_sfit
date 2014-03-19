//================================================================================
//  FileName: SyncDataWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/31
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
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Poxy;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 同步数据。
    /// </summary>
    public partial class SyncDataWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        UserInfo userInfo;
        bool auto = false, syncComple = false;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="info"></param>
        /// <param name="auto"></param>
        public SyncDataWindow(ICoreService service, UserInfo info, bool auto)
            : base(service)
        {
            this.userInfo = info;
            this.auto = auto;
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="info"></param>
        public SyncDataWindow(ICoreService service, UserInfo info)
            : this(service, info, false)
        {
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyncDataWindow_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnMessageEvent(MessageType.Normal, string.Empty);
            TeaSyncData teaSyncData = this.CoreService["teasyncdata"] as TeaSyncData;
            if (teaSyncData != null)
            {
                this.OnMessageEvent(MessageType.Normal, string.Format("上次同步时间：{0:yyyy-MM-dd HH:mm:ss}", teaSyncData.Time));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.syncComple)
                {
                    if (auto)
                    {
                        this.CoreService.AddForm(new MonitorStudentsWindow(this.CoreService));
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    this.CoreService.ForceQuit = true;
                    this.btnClose_Click(this.btnClose, e);
                }
                else
                {
                    this.btnSync.Enabled = false;
                    TeaClientServicePoxyFactory.Instance(this.CoreService, new RaiseChangedHandler(delegate(string content)
                    {
                        this.OnMessageEvent(MessageType.Normal, content);
                    })).TeaDownSync(this.userInfo.UserID, new EventHandler(delegate(object o, EventArgs x)
                    {
                        this.syncComple = true;
                        this.ThreadSafeMethod(new MethodInvoker(delegate()
                        {
                            this.btnSync.Text = "同步完成";
                            this.btnSync.Enabled = true;
                        }));
                    }));
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, x.Message);
                this.btnSync.Enabled = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.userInfo != null && this.syncComple)
            {
                TeaSyncData teaSyncData = TeaSyncData.DeSerialize(FolderStructure.UserSyncDataFile(this.userInfo.UserID));
                if (teaSyncData != null)
                {
                    this.CoreService.Add("teasyncdata", teaSyncData);
                    this.DialogResult = DialogResult.OK;
                }
            }
            this.Close();
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
            if (!string.IsNullOrEmpty(content))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("[{0:HH/mm/ss}]{1}", DateTime.Now, content);
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    string str = this.txtMessage.Text.Trim();
                    if (!string.IsNullOrEmpty(str))
                    {
                        sb.Append("\r\n");
                        sb.Append(str);
                    }
                    this.txtMessage.Text = sb.ToString();
                }));
            }
            if ((type & MessageType.Normal) == MessageType.Normal)
            {
                if (content.Length > 30)
                {
                    content = content.Substring(0, 30) + "...";
                }
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    this.lbMessage.Text = content;
                }));
            }
            base.OnMessageEvent(type, content);
        }
        #endregion      
    }
}