//================================================================================
//  FileName: MainForm.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-11-23
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
namespace Yaesoft.SFIT.Management
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : BaseWindow
    {
        #region 成员变量，构造函数。
        CredentialStore store = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public MainForm()
        {
            this.store = CredentialStore.DeSerializer();
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.store == null)
            {
                this.store = new CredentialStore();
            }
            this.dataGridView.DataSource = this.store.Data;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CredentialsWindow win = new CredentialsWindow(this.store, null);
            if (win.ShowDialog(this) == DialogResult.OK)
            {
                this.btnSearch_Click(sender, e);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
