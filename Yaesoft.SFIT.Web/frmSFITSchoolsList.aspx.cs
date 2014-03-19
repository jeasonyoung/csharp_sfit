//================================================================================
// FileName: frmSFITSchoolsList.aspx.cs
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
	///frmSFITSchoolsList列表页面后台代码。
	///</summary>
	public partial class frmSFITSchoolsList:ModuleBasePage,ISFITSchoolsListView
	{
		#region 成员变量，构造函数。
		SFITSchoolsPresenter presenter = null;
		///<summary>
		///构造函数。
		///</summary>
		public frmSFITSchoolsList()
		{
			this.presenter = new SFITSchoolsPresenter(this);
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

		protected void dgfrmSFITSchoolsList_BuildDataSource(object sender, EventArgs e)
		{
            this.dgfrmSFITSchoolsList.DataSource = this.presenter.ListDataSource;
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
            this.dgfrmSFITSchoolsList.InvokeBuildDataSource();
        }

		public override bool DeleteData()
		{
			return this.presenter.BatchDeleteData(this.dgfrmSFITSchoolsList.CheckedValue);
		}
		#endregion

        #region ISFITSchoolsListView 成员

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        #endregion

        #region ISFITSchoolsView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }

}
