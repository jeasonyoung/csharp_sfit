//================================================================================
// FileName: frmSFITEvaluateSetList.aspx.cs
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
	///frmSFITEvaluateSetList列表页面后台代码。
	///</summary>
    public partial class frmSFITEvaluateSetList : ModuleBasePage, ISFITEvaluateSetListView
    {
        #region 成员变量，构造函数。
        SFITEvaluateSetPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITEvaluateSetList()
        {
            this.presenter = new SFITEvaluateSetPresenter(this);
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

        protected void dgfrmSFITEvaluateSetList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITEvaluateSetList.DataSource = this.presenter.ListDataSource;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DeleteData())
                    this.LoadData();
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.dgfrmSFITEvaluateSetList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteEntityData(this.dgfrmSFITEvaluateSetList.CheckedValue);
        }
        #endregion


        #region ISFITEvaluateSetListView 成员
             
        public GUIDEx GradeID
        {
            get { return this.ddlGrade.SelectedValue; }
        }

        public string EvaluateName
        {
            get { return this.txtEvaluateName.Text.Trim(); }
        }
        #endregion

        #region ISFITEvaluateSetView 成员

        public void BindGrades(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion
    }
}
