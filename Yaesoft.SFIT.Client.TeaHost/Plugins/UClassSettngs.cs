//================================================================================
//  FileName: UClassSettngs.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/31
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

using Yaesoft.SFIT;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Plugins
{
    /// <summary>
    /// 上课设置。
    /// </summary>
    public partial class UClassSettngs : BaseUserControl
    {
        #region 成员变量，构造函数。
        bool start = false;
        Grades grades = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public UClassSettngs(ICoreService service)
            : base(service)
        {
            InitializeComponent();
        }
        #endregion

        #region 事件。
        /// <summary>
        /// 
        /// </summary>
        public event CrossPluginHandler CrossPluginSendEvent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void OnCrossPluginSend(CrossPluginEventArgs e)
        {
            CrossPluginHandler handler = this.CrossPluginSendEvent;
            if (handler != null && e != null)
                handler(this, e);
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UClassSettngs_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnToolTipEvent(this.btnStart, "启动后将开始侦听学生机客户端连接请求，关闭后侦听也将关闭！");
            this.LoadData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.grades != null)
            {
                Grade g = this.ddlGrade.SelectedItem as Grade;
                if (g != null)
                {
                    this.ddlClass.BeginUpdate();
                    this.ddlClass.DataSource = g.Classes;
                    this.ddlClass.DisplayMember = "ClassName";
                    this.ddlClass.ValueMember = "ClassID";
                    this.ddlClass.EndUpdate();

                    this.ddlCatalog.BeginUpdate();
                    this.ddlCatalog.DataSource = g.Catalogs;
                    this.ddlCatalog.DisplayMember = "CatalogName";
                    this.ddlCatalog.ValueMember = "CatalogID";
                    this.ddlCatalog.EndUpdate();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb != null && cbb.SelectedItem != null)
            {
                Catalog c = cbb.SelectedItem as Catalog;
                if (c != null)
                {
                    this.OnToolTipEvent(cbb, string.Format("{0}[{1}]", c.CatalogName, c.TypeName));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlLoginMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string  strValue = this.ddlLoginMethod.SelectedValue.ToString();
            int value = 0;
            if (Int32.TryParse(strValue, out value))
            {
                this.txtLoginPassword.Visible = (value == (int)EnumLoginMethod.Password);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            if (!this.start)
                this.btnStart.BackgroundImage = Properties.Resources.MoveStart;
            else
                this.btnStart.BackgroundImage = Properties.Resources.MoveEnd;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            if (!this.start)
                this.btnStart.BackgroundImage = Properties.Resources.Start;
            else
                this.btnStart.BackgroundImage = Properties.Resources.End;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Format("您确认{0}上课？", this.start ? "结束" : "开始"), "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                {
                    return;
                }
                this.OnClearErrorEvent();
                StartClassInfo sci = new StartClassInfo();
                Grade g = this.ddlGrade.SelectedItem as Grade;
                if (g != null)
                {
                    sci.GradeID = g.GradeID;
                    sci.GradeName = g.GradeName;
                    sci.Evaluate = g.Evaluate;
                }
                sci.ClassInfo = this.ddlClass.SelectedItem as Class;
                sci.CatalogInfo = this.ddlCatalog.SelectedItem as Catalog;
                sci.LoginMethod = (EnumLoginMethod)int.Parse(this.ddlLoginMethod.SelectedValue.ToString());
                sci.Password = this.txtLoginPassword.Text.Trim();

                if ((sci.LoginMethod == EnumLoginMethod.Password) && string.IsNullOrEmpty(sci.Password))
                {
                    string err = "请设置指定密码！";
                    this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, err);
                    this.OnSetErrorEvent(this.txtLoginPassword, err);
                    this.txtLoginPassword.Focus();
                    return;
                }
                this.WriteStatusInfo(this.start = !this.start);
                this.btnStart_MouseLeave(sender, e);

                this.CoreService["startclassinfo"] = sci;

                this.OnCrossPluginSend(new CrossPluginEventArgs(DockStyle.Right, new object[] { "syncdata", !this.start }));
                this.OnCrossPluginSend(new CrossPluginEventArgs(DockStyle.Fill, new object[] { "load", this.start, sci }));
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, "发生异常：\r\n" + x.Message);
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        private void WriteStatusInfo(bool start)
        {
            string strStatus = string.Empty, strTip = string.Empty;
            HostAddress hostAddr = this.CoreService["hostaddress"] as HostAddress;
            if (hostAddr != null)
            {
                strStatus = string.Format("{0}", hostAddr.HostIP);
                strTip = string.Format("主机地址：{0}\r\n广播地址：{1}", hostAddr.HostIP, hostAddr.BroadcastAddress);
            }
            if (this.start)
            {
                strStatus += ",正在上课中...";
                strTip += "\r\n正在上课中...";
            }
            this.lbStatus.Text = strStatus;
            this.OnToolTipEvent(this.lbStatus, strTip);
            this.OnMessageEvent(MessageType.Normal, strTip);
            this.ControlEnabled(this.panelWork, !start);           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="start"></param>
        private void ControlEnabled(Control panel, bool start)
        {
            if (panel != null && panel.HasChildren)
            {
                foreach (Control c in panel.Controls)
                {
                    if (c is ComboBox)
                        ((ComboBox)c).Enabled = start;
                    else if (c is TextBox)
                        ((TextBox)c).Enabled = start;
                }
            }
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 
        /// </summary>
        public void LoadData()
        {
            this.WriteStatusInfo(this.start);
            
            #region 登录方式。
            this.ddlLoginMethod.BeginUpdate();
            this.ddlLoginMethod.DataSource = EnumLoginMethodOperaTools.BindSource();
            this.ddlLoginMethod.DisplayMember = "Name";
            this.ddlLoginMethod.ValueMember = "Value";
            this.ddlLoginMethod.EndUpdate();
            #endregion

            UserInfo userInfo = this.CoreService["userinfo"] as UserInfo;
            if (userInfo != null)
            {
                this.lbUserInfo.Text = string.Format("任课教师：{0}[{1}]", userInfo.UserName, userInfo.UserCode);
                this.OnToolTipEvent(this.lbUserInfo, string.Format("教师代码：{0}\r\n任课教师：{1}\r\n教师ID：{2}", userInfo.UserCode, userInfo.UserName, userInfo.UserID));
            }
            TeaSyncData teaSyncData = this.CoreService["teasyncdata"] as TeaSyncData;
            if (teaSyncData != null && teaSyncData.School != null)
            {
                School sch = teaSyncData.School;
                this.lbSchoolName.Text = string.Format("{0}", sch.SchoolName);
                this.OnToolTipEvent(this.lbSchoolName, string.Format("学校代码：{0}\r\n学校名称：{1}\r\n学校类型：{2}\r\n学校ID：{3}",
                                                                     sch.SchoolCode, sch.SchoolName, EnumSchoolTypeOperaTools.GetCHName(sch.SchoolType), sch.SchoolID));
                if (sch.Teacher != null)
                {
                    Teacher tea = sch.Teacher;
                    if (tea != null && (tea.TeacherID == userInfo.UserID))
                    {
                        this.ddlGrade.BeginUpdate();
                        this.ddlGrade.DataSource = this.grades = tea.Grades;
                        this.ddlGrade.DisplayMember = "GradeName";
                        this.ddlGrade.ValueMember = "GradeID";
                        this.ddlGrade.EndUpdate();
                    }
                    else
                    {
                        this.OnMessageEvent(MessageType.Normal | MessageType.PopupWarn, "任课数据不存在或者任课教师与用户不一致！");
                    }
                }
            }
        }
        #endregion
    }
}