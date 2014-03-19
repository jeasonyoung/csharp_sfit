//================================================================================
//  FileName: frmSFITStudentsPicker.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/23
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
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;

using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Service;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmSFITStudentsPicker : ModuleBasePage, ISFITStudentsPickerView
    {
        #region 成员变量，构造函数。
        SFITStudentsPresenter persenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITStudentsPicker()
        {
            this.persenter = new SFITStudentsPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.persenter.InitializeComponent();
        }
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.persenter.QueryResult();
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
                ListBoxHelper.GetSelected(this.listStudents, out strText, out strValue);
                if (strText != null && strValue != null)
                    this.SaveData(string.Empty, string.Join("|", strValue));
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }
        #endregion

        #region ISFITStudentsView 成员

        public void ShowMessage(string msg)
        {
            this.errMsg.Message = msg;
        }

        #endregion

        #region ISFITStudentsPickerView 成员

        public GUIDEx UnitID
        {
            get { return this.ddlSchool.SelectedValue; }
        }

        public string ClassName
        {
            get { return this.txtClassName.Text.Trim(); }
        }

        public string StudentName
        {
            get { return this.txtStudentName.Text.Trim(); }
        }

        public bool IsUnit
        {
            get
            {
                try
                {
                    string str = this.Request["IsUnit"];
                    if (!string.IsNullOrEmpty(str))
                        return bool.Parse(str);
                }
                catch (Exception) { }
                return false;
            }
        }

        public void BindUnits(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSchool, data);
        }

        public void BindQueryResult(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.listStudents, data);
        }

        #endregion
    }
}
