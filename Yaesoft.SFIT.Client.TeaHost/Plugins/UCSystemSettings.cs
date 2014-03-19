//================================================================================
//  FileName: UCSystemSettings.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/15
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
    /// 系统设置插件。
    /// </summary>
    public partial class UCSystemSettings :BaseUserControl
    {
        #region 成员变量，构造函数。
        SystemSettingsWindow win = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public UCSystemSettings(ICoreService service)
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
        private void UCSystemSettings_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnToolTipEvent(this, "系统设置\r\n主要设置网络端口和监控时的颜色。");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSystemSettings_EnabledChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = this.Enabled ? Properties.Resources.SystemSettings : Properties.Resources.SystemSettingsDisabled;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSystemSettings_MouseEnter(object sender, EventArgs e)
        {
            if (this.Enabled)
                this.BackgroundImage = Properties.Resources.SystemSettingsMove;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSystemSettings_MouseLeave(object sender, EventArgs e)
        {
            if (this.Enabled)
                this.BackgroundImage = Properties.Resources.SystemSettings;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSystemSettings_Click(object sender, EventArgs e)
        {
            this.UCSystemSettings_DoubleClick(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSystemSettings_DoubleClick(object sender, EventArgs e)
        {
            this.win = new SystemSettingsWindow(this.CoreService);
            win.StartPosition = FormStartPosition.CenterParent;
            win.ShowDialog();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotKey"></param>
        public override void ProcessHotkey(string hotKey)
        {
            if (this.win == null)
            {
                this.UCSystemSettings_DoubleClick(this, EventArgs.Empty);
            }
        }
        #endregion

    }
}