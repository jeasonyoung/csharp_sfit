//================================================================================
//  FileName: UCSyncPluginSet.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/27
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
    /// 网络插件设置。
    /// </summary>
    public partial class UCNetPluginSet : BaseUserControl
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public UCNetPluginSet(ICoreService service)
            : base(service)
        {
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCNetPluginSet_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnToolTipEvent(this, "设置教师端客户端主机网络地址！");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCNetPluginSet_MouseEnter(object sender, EventArgs e)
        {
            if (this.Enabled)
                this.BackgroundImage = Properties.Resources.NetSetMove;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCNetPluginSet_MouseLeave(object sender, EventArgs e)
        {
            if (this.Enabled)
                this.BackgroundImage = Properties.Resources.NetSetEnabled;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCNetPluginSet_EnabledChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = this.Enabled ? Properties.Resources.NetSetEnabled : Properties.Resources.NetSetDisabled;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCNetPluginSet_Click(object sender, EventArgs e)
        {
            BoradcastAddressWindow win = new BoradcastAddressWindow(this.CoreService, this.CoreService["userinfo"] as UserInfo, true);
            if (win != null)
            {
                win.StartPosition = FormStartPosition.CenterParent;
                win.ShowDialog();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCNetPluginSet_DoubleClick(object sender, EventArgs e)
        {
            this.UCNetPluginSet_Click(sender, e);
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotKey"></param>
        public override void ProcessHotkey(string hotKey)
        {
            this.UCNetPluginSet_DoubleClick(this, EventArgs.Empty);
        }
        #endregion
    }
}