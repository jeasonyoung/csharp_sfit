//================================================================================
//  FileName: UCSyncSet.cs
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
namespace Yaesoft.SFIT.Client.TeaHost.Plugins
{
    /// <summary>
    /// 同步插件。
    /// </summary>
    public partial class UCSyncSet : BaseUserControl
    {
        #region 成员变量，构造函数。
        UserInfo info;
        bool isShow = false;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="info"></param>
        public UCSyncSet(ICoreService service, UserInfo info)
            : base(service)
        {
            this.info = info;
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 跨插件传递数据事件。
        /// </summary>
        public event CrossPluginHandler CrossPluginSendEvent;
        /// <summary>
        /// 触发跨插件传递数据事件。
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCrossPluginSendEvent(CrossPluginEventArgs e)
        {
            CrossPluginHandler handler = this.CrossPluginSendEvent;
            if (handler != null && e != null)
                handler(this, e);
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSyncSet_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnToolTipEvent(this, "同步数据，从服务器下载数据！");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSyncSet_Click(object sender, EventArgs e)
        {
            this.UCSyncSet_DoubleClick(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSyncSet_DoubleClick(object sender, EventArgs e)
        {
            this.isShow = true;
            SyncDataWindow sync = new SyncDataWindow(this.CoreService, this.info);
            sync.StartPosition = FormStartPosition.CenterParent;
            if (sync.ShowDialog() == DialogResult.OK)
            {
                this.OnCrossPluginSendEvent(new CrossPluginEventArgs(DockStyle.Top, new object[] { "reload", true }));
            }
            this.isShow = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSyncSet_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                this.BackgroundImage = this.Enabled ? Properties.Resources.SyncData : Properties.Resources.DisabledSyncData;
            }
            catch (Exception) { }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSyncSet_MouseEnter(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                this.BackgroundImage = Properties.Resources.MoveSyncData;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSyncSet_MouseLeave(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                this.BackgroundImage = Properties.Resources.SyncData;
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotKey"></param>
        public override void ProcessHotkey(string hotKey)
        {
            if (!this.isShow)
            {
                this.UCSyncSet_DoubleClick(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}