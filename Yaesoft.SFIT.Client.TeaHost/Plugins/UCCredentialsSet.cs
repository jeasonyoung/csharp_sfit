//================================================================================
//  FileName: UCCredentialsSet.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/10
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
    /// 
    /// </summary>
    public partial class UCCredentialsSet : BaseUserControl
    {
        #region 成员变量，构造函数。
        ImportCredentialsWindow window = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public UCCredentialsSet(ICoreService service)
            : base(service)
        {
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        private void UCCredentialsSet_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnToolTipEvent(this, "更换访问密钥");

        }

        private void UCCredentialsSet_MouseEnter(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                this.BackgroundImage = Properties.Resources.ChangedCredentialsMove;
            }
        }

        private void UCCredentialsSet_MouseLeave(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                this.BackgroundImage = Properties.Resources.ChangedCredentials;
            }
        }

        private void UCCredentialsSet_EnabledChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = this.Enabled ? Properties.Resources.ChangedCredentials : Properties.Resources.ChangedCredentialsDisabled;
        }

        private void UCCredentialsSet_Click(object sender, EventArgs e)
        {
            this.UCCredentialsSet_DoubleClick(sender, e);
        }

        private void UCCredentialsSet_DoubleClick(object sender, EventArgs e)
        {
            this.window = new ImportCredentialsWindow(this.CoreService, true);
            window.StartPosition = FormStartPosition.CenterParent;
            window.ShowDialog(this);
        }
        #endregion

        #region 重载。
        public override void ProcessHotkey(string hotKey)
        {
            if (this.window == null)
            {
                this.UCCredentialsSet_DoubleClick(this, EventArgs.Empty);
            }
        }
        #endregion

    }
}
