//================================================================================
// FileName: frmSFITClassList.aspx.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
	
using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
	///<summary>
	///frmSFITClassList列表页面后台代码。
	///</summary>
    public partial class frmSFITClassList : ModuleBasePage, ISFITClassListView
    {
        #region 成员变量，构造函数。
        SFITClassPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITClassList()
        {
            this.presenter = new SFITClassPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.presenter.InitializeComponent();
                this.lbTitle.Text = this.NavigationContent;
            }
        }

        protected void dgfrmSFITClassList_BuildDataSource(object sender, EventArgs e)
        {
                this.dgfrmSFITClassList.DataSource = this.presenter.ListDataSource;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteData())
                this.LoadData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.dgfrmSFITClassList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteClass(this.dgfrmSFITClassList.CheckedValue);
        }
        #endregion

        #region ISFITClassView 成员

        public GUIDEx GradeID
        {
            get { return this.ddlGrade.SelectedValue; }
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        public void BindGrades(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }
        #endregion

        #region ISFITClassListView 成员

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        public string ClassName
        {
            get { return this.txtClassName.Text.Trim(); }
        }
        #endregion

    }

}
