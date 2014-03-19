//================================================================================
//  FileName: UCWorkExportImport.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/16
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
    /// 作品导出导入设置。
    /// </summary>
    public partial class UCWorkExportImportSet : BaseUserControl
    {
        #region 成员变量，构造函数。
        bool isShow = false;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCWorkExportImportSet(ICoreService service)
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
        private void UCWorkExportImportSet_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnToolTipEvent(this, @"导出\导入学生作品数据");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCWorkExportImportSet_MouseEnter(object sender, EventArgs e)
        {
            if(this.Enabled)
                this.BackgroundImage = Properties.Resources.WorkExportImportMove;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCWorkExportImportSet_MouseLeave(object sender, EventArgs e)
        {
            if(this.Enabled)
                this.BackgroundImage = Properties.Resources.WorkExportImport;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCWorkExportImportSet_EnabledChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = this.Enabled ? Properties.Resources.WorkExportImport: Properties.Resources.WorkExportImportDisabled;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCWorkExportImportSet_Click(object sender, EventArgs e)
        {
            this.UCWorkExportImportSet_DoubleClick(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCWorkExportImportSet_DoubleClick(object sender, EventArgs e)
        {
            this.isShow = true;
            WorkExportImportWindow window = new WorkExportImportWindow(this.CoreService);
            window.StartPosition = FormStartPosition.CenterScreen;
            window.Show(this);
            this.isShow = false;
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
                this.UCWorkExportImportSet_DoubleClick(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}