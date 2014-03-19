//================================================================================
//  FileName: SelectCredentialsWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/30
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
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 选择密钥。
    /// </summary>
    public partial class SelectCredentialsWindow :BaseWindow
    {
        #region 成员变量，构造函数。
        CredentialsCollection crets = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service">核心服务接口。</param>
        /// <param name="crets">密钥集合。</param>
        public SelectCredentialsWindow(ICoreService service, CredentialsCollection crets)
            : base(service)
        {
            this.crets = crets;
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        private void SelectCredentialsWindow_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnMessageEvent(MessageType.Normal, string.Empty);

            if (this.crets != null)
            {
                this.ddlSchoolName.BeginUpdate();
                this.ddlSchoolName.DataSource = this.crets;
                this.ddlSchoolName.DisplayMember = "SchoolName";
                this.ddlSchoolName.ValueMember = "SchoolID";
                this.ddlSchoolName.EndUpdate();
                this.ddlSchoolName_SelectedIndexChanged(this.ddlSchoolName, e);
            }
        }

        private void ddlSchoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Credentials c = this.ddlSchoolName.SelectedValue as Credentials;
            if (c != null)
            {
                this.txtServiceURL.Text = c.ServiceURL;
                this.txtAccessAccount.Text = c.AccessAccount;
                this.txtAccessPassword.Text = c.AccessPassword;
                this.txtDescription.Text = c.Description;

                this.btnSave.Tag = c;

                string msg = string.Format("{0}[{1}]", c.SchoolName, c.SchoolCode);

                this.OnToolTipEvent(this.ddlSchoolName, string.Format("{0}\r\n{1}", msg, c.ServiceURL));
                this.OnMessageEvent(MessageType.Normal, msg);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                try
                {
                    btn.Enabled = false;
                    Credentials cert = btn.Tag as Credentials;
                    if (cert != null)
                    {
                        CredentialsCollection data = new CredentialsCollection();
                        data.Add(cert);
                        CredentialsFactory.Serialize(data, FolderStructure.CredentialsFile);
                        this.CoreService["credentials"] = cert;
                        this.CoreService.AddForm(new LoginWindow(this.CoreService));
                        this.CoreService.ForceQuit = true;
                        this.Close();
                    }
                    else
                    {
                        this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, "请选择学校密钥！");
                    }
                }
                catch (Exception ex)
                {
                    this.OnMessageEvent(MessageType.Normal | MessageType.PopupWarn, "保存密钥时发生异常：" + ex.Message);
                }
                finally
                {
                    btn.Enabled = true;
                }
            }
        }
        #endregion

        #region 重载。
        protected override void OnMessageEvent(MessageType type, string content)
        {
            if ((type & MessageType.Normal) == MessageType.Normal)
                this.lbMessage.Text = content;
            base.OnMessageEvent(type, content);
        }
        #endregion

    }
}
