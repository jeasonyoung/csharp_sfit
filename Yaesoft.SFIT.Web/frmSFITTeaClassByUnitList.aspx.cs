//================================================================================
//  FileName: frmSFITTeaClassByUnitList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/9
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
    public partial class frmSFITTeaClassByUnitList : ModuleBasePage, ISFITTeaClassByUnitListView
    {
        #region 成员变量，构造函数。
        SFITTeaClassByUnitPresenter presenter = null;
        /// <summary>
        /// 
        /// </summary>
        public frmSFITTeaClassByUnitList()
        {
            this.presenter = new SFITTeaClassByUnitPresenter(this);
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
        protected void dgfrmSFITTeaClassByUnitList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITTeaClassByUnitList.DataSource = this.presenter.ListdataSource;
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.dgfrmSFITTeaClassByUnitList.InvokeBuildDataSource();
        }
        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteTeaClass(this.dgfrmSFITTeaClassByUnitList.CheckedValue);
        }
        #endregion

        #region ISFITTeaClassByUnitListView 成员

        public void BindUnit(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSchool, data);
        }

        #endregion

        #region ISFITTeaClassByUnitView 成员

        public void ShowMessage(string message)
        {
            this.errMessage.Message = message;
        }

        #endregion

        #region ISFITTeaClassByUnitListView 成员

        public GUIDEx UnitID
        {
            get { return this.ddlSchool.SelectedValue; }
        }

        public string TeacherName
        {
            get { return this.txtTeacherName.Text.Trim(); }
        }

        public string ClassName
        {
            get { return this.txtClassName.Text.Trim(); }
        }

        #endregion
    }
}
