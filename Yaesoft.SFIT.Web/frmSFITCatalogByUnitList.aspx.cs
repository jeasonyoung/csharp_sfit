//================================================================================
//  FileName: frmSFITCatalogByUnitList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/26
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
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    public partial class frmSFITCatalogByUnitList : ModuleBasePage, ICatalogByUnitListView
    {
        #region 成员变量，构造函数。
        SFITCatalogByUnitPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITCatalogByUnitList()
        {
            this.presenter = new SFITCatalogByUnitPresenter(this);
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
        protected void dgfrmSFITCatalogList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITCatalogList.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.dgfrmSFITCatalogList.InvokeBuildDataSource();
        }
        public override bool DeleteData()
        {
            return this.presenter.DeleteCatalog(this.dgfrmSFITCatalogList.CheckedValue);
        }
        #endregion

        #region ICatalogByUnitView 成员

        public void BindGrade(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region ICatalogByUnitListView 成员

        public void BindUnit(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSchool, data);
        }

        public GUIDEx UnitID
        {
            get { return this.ddlSchool.SelectedValue; }
        }

        public GUIDEx GradeID
        {
            get { return this.ddlGrade.SelectedValue; }
        }

        public string CatalogName
        {
            get { return this.txtCatalogName.Text.Trim(); }
        }

        #endregion
    }
}
