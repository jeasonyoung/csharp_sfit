//================================================================================
//  FileName: WorkExportImportWindow.cs
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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Yaesoft.SFIT;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 作品导出导入。
    /// </summary>
    public partial class WorkExportImportWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        WorkExportWindow workExport = null;
        WorkImportWindow workImport = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public WorkExportImportWindow(ICoreService service)
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
        private void WorkExportImportWindow_Load(object sender, EventArgs e)
        {
             
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            this.workExport = new WorkExportWindow(this.CoreService);
            this.workExport.StartPosition = FormStartPosition.CenterScreen;
            this.workExport.ShowDialog(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.workImport = new WorkImportWindow(this.CoreService, this.openFileDialog.FileName);
                this.workImport.StartPosition = FormStartPosition.CenterScreen;
                this.workImport.ShowDialog(this);
            }
        }
        #endregion

    }
}