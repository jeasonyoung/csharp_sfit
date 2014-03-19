//================================================================================
//  FileName: LoginWindow.cs
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

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Poxy;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 登录窗口。
    /// </summary>
    public partial class LoginWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        LocalUserInfoCollection data;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service">核心服务接口。</param>
        public LoginWindow(ICoreService service)
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
        private void LoginWindow_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnMessageEvent(MessageType.Normal, string.Empty);
            this.OnToolTipEvent(this.ddlUserAccount, "任课教师帐号！");
            this.OnToolTipEvent(this.txtUserPassword, "任课教师密码！");

            this.data = LocalUserInfoCollection.DeSerialize();
            if (this.data != null)
            {
                this.ddlUserAccount.BeginUpdate();
                this.ddlUserAccount.DataSource = data;
                this.ddlUserAccount.DisplayMember = "UserAccount";
                this.ddlUserAccount.ValueMember = "UserAccount";
                this.ddlUserAccount.EndUpdate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlUserAccount_TextChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb != null && !string.IsNullOrEmpty(cbb.Text))
            {
                this.chkOffline.Checked = (cbb.SelectedIndex > -1);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkUpdateCert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.CoreService.AddForm(new ImportCredentialsWindow(this.CoreService));
            this.CoreService.ForceQuit = true;
            this.btnClose_Click(this.btnClose, EventArgs.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string strUserAccount = this.ddlUserAccount.Text.Trim();
                string strUserPassword = this.txtUserPassword.Text.Trim();
                this.OnClearErrorEvent();
                if (string.IsNullOrEmpty(strUserAccount))
                {
                    this.OnSetErrorEvent(this.ddlUserAccount, "请输入帐号！");
                    return;
                }
                if (string.IsNullOrEmpty(strUserPassword))
                {
                    this.OnSetErrorEvent(this.txtUserPassword, "请输入密码！");
                    return;
                }
                this.OnMessageEvent(MessageType.Normal, "准备开始验证帐号/密码...");
                this.SetControlsEnabledStatus(false);
                if (this.chkOffline.Checked)
                {
                    if (this.data == null)
                    {
                        throw new Exception("请取消离线登录！");
                    }
                    //离线登录。
                    this.OfflineVerify(strUserAccount, strUserPassword);
                }
                else
                {
                    //联线登录。
                    this.OnlineVerify(strUserAccount, strUserPassword);
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.Normal,"发生异常！");
                this.OnMessageEvent(MessageType.PopupInfo, x.Message);
                if (!this.chkOffline.Checked)
                {
                    this.SetControlsEnabledStatus(true);
                }
            }
            finally
            {
                if (this.chkOffline.Checked)
                {
                    this.SetControlsEnabledStatus(true);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        protected override void OnMessageEvent(MessageType type, string content)
        {
            if ((type & MessageType.Normal) == MessageType.Normal)
            {
                this.ThreadSafeMethod(this.lbMessage, new MethodInvoker(delegate()
                {
                    this.lbMessage.Text = content;
                }));
            }
            base.OnMessageEvent(type, content);
        }
        #endregion

        #region 函数处理。
        /// <summary>
        /// 登录成功
        /// </summary>
        /// <param name="userInfo"></param>
        private void LoginSuccess(UserInfo userInfo)
        {
            if (userInfo != null)
            {
                this.CoreService.AddForm(new BoradcastAddressWindow(this.CoreService, userInfo));
                this.CoreService.Add("userinfo", userInfo);
                this.CoreService.ForceQuit = true;
                this.Close();
            }
        }
        /// <summary>
        /// 离线登录。
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="local"></param>
        /// <returns></returns>
        private void OfflineVerify(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                LocalUserInfo info = this.data[userName];
                if (info == null)
                {
                    this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, "帐号不存在！请选择联线登录验证！");
                    return;
                }
                else
                {
                    Credentials cert = this.CoreService["credentials"] as Credentials;
                    if (cert == null)
                    {
                        this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, "访问密钥不存在或丢失，请重新更新访问密钥！");
                        return;
                    }
                    if (cert.SchoolID == info.SchoolID)
                    {
                        if (info.Password == password)
                        {
                            this.LoginSuccess(info);
                        }
                        else
                        {
                            this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, "密码不正确！");
                        }
                    }
                    else
                    {
                        string err = string.Format("用户不属于【{0}】的任课教师，请重新更新访问密钥或联线登录验证！", cert.SchoolName);
                        if (string.IsNullOrEmpty(info.SchoolID))
                        {
                            err = "由于版本升级，修复离线登录未验证教师所属学校的Bug，请重新联线登录！";
                        }
                        this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, err);
                    }
                }
            }
        }
        /// <summary>
        /// 联线登录。
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private void OnlineVerify(string userName, string password)
        {
            TeaClientServicePoxyFactory.Instance(this.CoreService, new RaiseChangedHandler(delegate(string content)
            {
                this.OnMessageEvent(MessageType.Normal, content);
            })).Authentication(EnumUserAuthen.Teacher, userName, password, new UserAuthenticationHandler(delegate(LocalUserInfo userInfo, Exception e)
            {
                if (e != null)
                {
                    this.OnMessageEvent(MessageType.PopupWarn, e.Message);
                    this.SetControlsEnabledStatus(true);
                    return;
                }
                if (this.data == null)
                {
                    this.data = new LocalUserInfoCollection();
                }
                this.data.Add(userInfo);
                this.data.Serialize();
                this.SetControlsEnabledStatus(true);
                this.LoginSuccess(userInfo);
            }));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        private void SetControlsEnabledStatus(bool enabled)
        {
            this.ThreadSafeMethod(new MethodInvoker(delegate()
            {
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Enabled = enabled;
                    }
                    else if (c is CheckBox)
                    {
                        c.Enabled = enabled;
                    }
                    else if (c is Button)
                    {
                        c.Enabled = enabled;
                    }
                    else if (c is ComboBox)
                    {
                        c.Enabled = enabled;
                    }
                    else if (c is LinkLabel)
                    {
                        c.Enabled = enabled;
                    }
                }
            }));
        }
        #endregion
    }
}