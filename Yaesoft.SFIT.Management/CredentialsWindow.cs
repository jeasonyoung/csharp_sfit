//================================================================================
//  FileName: CredentialsWindow.cs
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
    /// 访问密钥明细。
    /// </summary>
    public partial class CredentialsWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        private Credentials credentials = null;
        private CredentialStore store = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        internal CredentialsWindow(CredentialStore store, Credentials credit)
            : this()
        {
            this.store = store;
            this.credentials = credit;
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        public CredentialsWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        private void CredentialsWindow_Load(object sender, EventArgs e)
        {
            if (this.credentials != null)
            {
                this.txtSchoolID.Text = this.credentials.SchoolID;
                this.txtSchoolCode.Text = this.credentials.SchoolCode;
                this.txtSchoolName.Text = this.credentials.SchoolName;
                this.txtServiceURL.Text = this.credentials.ServiceURL;
                this.txtAccessAccount.Text = this.credentials.AccessAccount;
                this.txtAccessPassword.Text = this.credentials.AccessPassword;
                this.txtDescription.Text = this.credentials.Description;
                this.btnDelete.Enabled = true;
            }
            else
            {
                this.txtSchoolID.Text = string.Format("{0}", Guid.NewGuid()).Replace("-", string.Empty);
                this.btnDelete.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.credentials == null)
            {
                this.credentials = new Credentials();
            }
            if (string.IsNullOrEmpty(this.txtSchoolID.Text))
            {
                this.OnToolTipEvent(this.txtSchoolID, "学校ID不能为空！");
                return;
            }
            else
            {
                this.credentials.SchoolID = this.txtSchoolID.Text.Trim();
            }
            if (string.IsNullOrEmpty(this.txtSchoolCode.Text))
            {
                this.OnToolTipEvent(this.txtSchoolCode, "学校代码不能为空！");
                return;
            }
            else
            {
                this.credentials.SchoolCode = this.txtSchoolCode.Text.Trim();
            }
            if (string.IsNullOrEmpty(this.txtSchoolName.Text))
            {
                this.OnToolTipEvent(this.txtSchoolName, "学校名称不能为空！");
                return;
            }
            else
            {
                this.credentials.SchoolName = this.txtSchoolName.Text.Trim();
            }
            this.credentials.ServiceURL = this.txtServiceURL.Text.Trim();
            this.credentials.AccessAccount = this.txtAccessAccount.Text.Trim();
            this.credentials.AccessPassword = this.txtAccessPassword.Text.Trim();
            this.credentials.Description = this.txtDescription.Text.Trim();

            if (this.store != null)
            {
                this.store.Add(this.credentials);
                this.store.Serializer();
            }
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.credentials != null && this.store != null)
            {
                this.store.Remove(this.credentials);
                this.store.Serializer();
            }
            this.Close();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            base.OnFormClosing(e);
        }
        #endregion
    }
}
