//================================================================================
//  FileName: frmSFITStudentWorksByUnitList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/10
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
    /// <summary>
    /// 
    /// </summary>
    public partial class frmSFITStudentWorksByUnitList : ModuleBasePage, IStudentWorksByUnitListView
    {
        #region 成员变量，构造函数。
        SFITStudentWorksByUnitPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITStudentWorksByUnitList()
        {
            this.presenter = new SFITStudentWorksByUnitPresenter(this);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteData())
                this.LoadData();
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.ucStudentWorksList.LoadData(this.presenter.ListDataScuore);
        }
        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteEntityData(this.ucStudentWorksList.GetSelected);
        }
        #endregion

        #region IStudentWorksByUnitView 成员

        public void BindUnit(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSchool, data);
        }

        public void BindWorkStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlWorkStatus, data);
        }

        public void BindGrade(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        #endregion

        #region IStudentWorksByUnitListView 成员

        public GUIDEx UnitID
        {
            get { return this.ddlSchool.SelectedValue; }
        }

        public GUIDEx GradeID
        {
            get { return this.ddlGrade.SelectedValue; }
        }

        public string ClassName
        {
            get { return this.txtClassName.Text.Trim(); }
        }

        public string StudentName
        {
            get { return this.txtStudentName.Text.Trim(); }
        }
        public string WorkName
        {
            get { return this.txtWorkName.Text.Trim(); }
        }
        public GUIDEx WorkStatusID
        {
            get { return this.ddlWorkStatus.SelectedValue; }
        }

        public void ShowMessage(string message)
        {
            this.errMessage.Message = message;
        }

        #endregion
    }
}
