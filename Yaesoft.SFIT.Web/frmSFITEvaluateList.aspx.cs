//================================================================================
// FileName: frmSFITEvaluateList.aspx.cs
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
	///frmSFITEvaluateList列表页面后台代码。
	///</summary>
    public partial class frmSFITEvaluateList : ModuleBasePage, ISFITEvaluateListView
    {
        #region 成员变量，构造函数。
        SFITEvaluatePresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITEvaluateList()
        {
            this.presenter = new SFITEvaluatePresenter(this);

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

        protected void dgfrmSFITEvaluateList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITEvaluateList.DataSource = this.presenter.ListDataSource;

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
            this.dgfrmSFITEvaluateList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteEvaluate(this.dgfrmSFITEvaluateList.CheckedValue);
        }
        #endregion

        #region ISFITEvaluateView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region ISFITEvaluateListView 成员

        public string EvaluateName
        {
            get { return this.txtEvaluateName.Text; }
        }

        #endregion
    }

}
