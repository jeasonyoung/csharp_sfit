//================================================================================
//  FileName: UCLogin.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/19
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
using System.Net;
using System.Windows.Forms;

using Yaesoft.SFIT;
using Yaesoft.SFIT.Client.Net;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
namespace Yaesoft.SFIT.ClientStudent
{
    /// <summary>
    /// 学生登录。
    /// </summary>
    public partial class UCLogin : BaseUserControl
    {
        #region 成员变量，构造函数。
        private EnumLoginMethod loginMethod = EnumLoginMethod.SelectName;
        private Students students = null;
        private UDPSocket socket = null;
        private IPAddress hostIP = null;
        private PortSettings ports = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCLogin(ICoreService service, EnumLoginMethod method, Students students)
            : base(service)
        {
            this.loginMethod = method;
            this.students = students;
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.OnMessageEvent(MessageType.Normal, string.Empty);
                if (this.loginMethod != EnumLoginMethod.UnifiedLogin)
                {
                    this.txtUsername.DropDownStyle = ComboBoxStyle.DropDownList;
                    if (this.students != null)
                    {
                        foreach (Student stu in this.students)
                        {
                            string code = stu.StudentCode;
                            if (!string.IsNullOrEmpty(code) && code.Length > 2)
                            {
                                code = code.Substring(code.Length - 2);
                            }
                            stu.StudentName = string.Format("[{0}]{1}", code, stu.StudentName);
                        }
                        this.txtUsername.BeginUpdate();
                        this.txtUsername.DataSource = this.students;
                        this.txtUsername.DisplayMember = "StudentName";
                        this.txtUsername.ValueMember = "StudentID";
                        this.txtUsername.EndUpdate();
                    }
                    this.panelWork.Visible = (this.loginMethod == EnumLoginMethod.Password);
                }
                else
                {
                    this.panelWork.Visible = true;
                }

                #region 建立UDP监听。
                this.ports = this.CoreService["portsettings"] as PortSettings;
                this.hostIP = IPAddress.Parse(string.Format("{0}", this.CoreService["host_ip"]));

                this.socket = new UDPSocket(this.ports.HostOrder);
                this.socket.Changed += new Yaesoft.SFIT.Client.RaiseChangedHandler(delegate(string content)
                {
                    this.OnMessageEvent(MessageType.Normal, content);
                });
                this.socket.DataArrival += this.ReceiveHostData;
                this.socket.Start();
                #endregion
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.Normal | MessageType.PopupWarn, "发生异常：" + x.Message);
            }
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
                string strUsername = null, strPassword = null;
                #region 验证。
                this.OnClearErrorEvent();
                if (this.loginMethod == EnumLoginMethod.UnifiedLogin)
                {
                    strUsername = this.txtUsername.Text.Trim();
                    strPassword = this.txtPassword.Text.Trim();
                }
                else if (this.loginMethod == EnumLoginMethod.Password)
                {
                    strUsername = this.txtUsername.SelectedValue.ToString();
                    strPassword = this.txtPassword.Text.Trim();
                }
                else
                {
                    strUsername = this.txtUsername.SelectedValue.ToString();
                }

                if (string.IsNullOrEmpty(strUsername))
                {
                    this.OnSetErrorEvent(this.txtUsername, "请选择学生帐号！");
                    return;
                }
                if (this.loginMethod != EnumLoginMethod.SelectName && string.IsNullOrEmpty(strPassword))
                {
                    this.OnSetErrorEvent(this.txtPassword, "请输入学生密码！");
                    return;
                }
                #endregion



                #region 登录。
                this.btnLogin.Enabled = false;
                StartLogin sl = new StartLogin();
                sl.MachineName = Dns.GetHostName();
                sl.UserAccount = strUsername;
                sl.UserPassword = strPassword;
                this.OnMessageEvent(MessageType.Normal, "开始登录验证...");
                this.socket.Send(sl, new IPEndPoint(this.hostIP, this.ports.ClientCallback));
                #endregion

            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.Normal | MessageType.PopupWarn, "发生异常：" + x.Message);
                this.btnLogin.Enabled = true;
            }
        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void ReceiveHostData(Msg data)
        {
            this.OnMessageEvent(MessageType.Normal, "接收到教师机主机消息数据，正在分析...");
            if (this.hostIP != null && (data.UIP != this.hostIP.ToString()))
                return;
            EndLogin el = data as EndLogin;
            if (el != null)
            {
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    if (!el.Result)
                    {
                        this.OnMessageEvent(MessageType.Normal | MessageType.PopupWarn, el.Error);
                        this.btnLogin.Enabled = true;
                    }
                    else
                    {
                        this.socket.Close();
                        this.CoreService["student"] = el.Student;
                        this.CoreService.ForceQuit = true;
                        this.CoreService.AddForm(new StudentMainWindow(this.CoreService));
                        this.ParentForm.Close();
                    }
                }));
            }
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
            this.ThreadSafeMethod(new MethodInvoker(delegate()
            {
                this.lbMessage.Text = content;
            }));
            base.OnMessageEvent(type, content);
        }
        #endregion
    }
}