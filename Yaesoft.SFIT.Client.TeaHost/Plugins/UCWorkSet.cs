//================================================================================
//  FileName: UCWorkSet.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/5
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
    /// 作品管理插件。
    /// </summary>
    public partial class UCWorkSet : BaseUserControl
    {
        #region 成员变量，构造函数
        UserInfo userInfo = null;
        ModifyWorkWindow modifyWorkWindow = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="info"></param>
        public UCWorkSet(ICoreService service, UserInfo info)
            : base(service)
        {
            this.userInfo = info;
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCWorkSet_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnToolTipEvent(this, "负责管理学生上传的作品");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCWorkSet_Click(object sender, EventArgs e)
        {
            this.UCWorkSet_DoubleClick(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCWorkSet_DoubleClick(object sender, EventArgs e)
        {
            this.modifyWorkWindow = new ModifyWorkWindow(this.CoreService);
            this.modifyWorkWindow.StartPosition = FormStartPosition.CenterScreen;
            this.modifyWorkWindow.WindowState = FormWindowState.Normal;
            this.modifyWorkWindow.Show(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCWorkSet_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.ModfiyWorkMove;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCWorkSet_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.ModfiyWork;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotKey"></param>
        public override void ProcessHotkey(string hotKey)
        {
            if (this.modifyWorkWindow == null)
            {
                this.UCWorkSet_DoubleClick(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}