//================================================================================
//  FileName: frmSFITStudentWorksQueryList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/13
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
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    public partial class frmSFITStudentWorksQueryList : ModuleBasePage, ISFITStudentWorksQueryListView
    {
        #region 成员变量，构造函数。
        SFITStudentWorksQueryPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITStudentWorksQueryList()
        {
            this.presenter = new SFITStudentWorksQueryPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.presenter.InitializeComponent();
                this.lbTitle.Text = this.NavigationContent;
            }
        }

        protected void dgfrmSFITStudentWorksQueryList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITStudentWorksQueryList.DataSource = this.presenter.ListDataSource;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        #endregion

        #region 重载。

        public override void LoadData()
        {
            this.dgfrmSFITStudentWorksQueryList.InvokeBuildDataSource();
        }
        
        #endregion

        #region ISFITStudentWorksQueryView 成员

        public void ShowMessage(string message)
        {
            this.errMessage.Message = message;
        }

        #endregion

        #region ISFITStudentWorksQueryListView 成员

        public void BindWorkStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlWorkStatus, data);
        }

        #endregion

        #region ISFITStudentWorksQueryListView 成员

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        public string GradeName
        {
            get { return this.txtGradeName.Text.Trim(); }
        }

        public string ClassName
        {
            get { return this.txtClassName.Text.Trim(); }
        }

        public string CatalogName
        {
            get { return this.txtCatalogName.Text.Trim(); }
        }

        public string WorkName
        {
            get { return this.txtWorkName.Text.Trim(); }
        }

        public GUIDEx WorkStatusID
        {
            get { return this.ddlWorkStatus.SelectedValue; }
        }
        #endregion
    }
}
