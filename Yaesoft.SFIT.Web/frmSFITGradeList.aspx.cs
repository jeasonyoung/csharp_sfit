//================================================================================
// FileName: frmSFITGradeList.aspx.cs
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
	///frmSFITGradeList列表页面后台代码。
	///</summary>
    public partial class frmSFITGradeList : ModuleBasePage, ISFITGradeListView
    {
        #region 成员变量，构造函数。
        SFITGradePresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITGradeList()
        {
            this.presenter = new SFITGradePresenter(this);
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

        protected void dgfrmSFITGradeList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITGradeList.DataSource = this.presenter.ListDataSource;
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
            this.dgfrmSFITGradeList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteGrade(this.dgfrmSFITGradeList.CheckedValue);
        }
        #endregion

        #region ISFITGradeListView 成员

        public GUIDEx LearnLevelID
        {
            get { return this.ddlLearnLevel.SelectedValue; }
        }

        public string GradeName
        {
            get { return this.txtGradeName.Text.Trim(); }
        }

        #endregion

        #region ISFITGradeView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        
        public void BindLearnLevel(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlLearnLevel, data);
        }

        #endregion
    }
}
