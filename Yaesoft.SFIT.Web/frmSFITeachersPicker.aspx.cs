//================================================================================
//  FileName: frmSFITeachersPicker.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/10/19
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iPower;
using iPower.Web.Utility;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    public partial class frmSFITeachersPicker : ModuleBasePage, ISFITeachersPickerView
    {
        #region 成员变量，构造函数。
        SFITeachersPickerPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITeachersPicker()
        {
            this.presenter = new SFITeachersPickerPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.presenter.Query();
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strText = null, strValue = null;
                ListBoxHelper.GetSelected(this.listTeacher, out strText, out strValue);
                if (strText != null && strValue != null)
                    this.SaveData(string.Join(",", strText), string.Join(",", strValue));
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            GUIDEx schoolID = this.RequestGUIEx("SchoolID");
            if (schoolID.IsValid)
            {
                this.txtSchoolName.Text = this.presenter.GetSchoolName(schoolID);
                this.txtSchoolName.Enabled = false;
            }
        }
        #endregion

        #region ISFITeachersPickerView 成员

        public string[] Values
        {
            get
            {
                string s = this.Request["Value"];
                if (!string.IsNullOrEmpty(s))
                    return s.Split(',');
                return null;
            }
        }

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        public string TeacherName
        {
            get { return this.txtTeacherName.Text.Trim(); }
        }

        public void BindResultQuery(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.listTeacher, data);
        }

        public void ShowMessage(string msg)
        {
            this.errMsg.Message = msg;
        }
        #endregion
    }
}
