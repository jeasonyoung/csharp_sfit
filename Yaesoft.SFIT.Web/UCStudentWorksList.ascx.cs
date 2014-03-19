//================================================================================
//  FileName: UCStudentWorksList.ascx.cs
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
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using iPower;
using iPower.Platform.Engine.Service;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 学生作品列表控件。
    /// </summary>
    public partial class UCStudentWorksList : ModuleBaseControl, IUCStudentWorksListView
    {
        #region 成员变量，构造函数。
        UCStudentWorksListPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCStudentWorksList()
        {
            this.presenter = new UCStudentWorksListPresenter(this);
        }
        #endregion

        #region 属性。
        DataTable ListDataSource
        {
            get { return this.ViewState["ListDataSource"] as DataTable; }
            set { this.ViewState["ListDataSource"] = value; }
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }

        protected void dgUCStudentWorksList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgUCStudentWorksList.DataSource = this.ListDataSource;
        }
        #endregion

        #region IUCStudentWorksListView 成员

        public StringCollection GetSelected
        {
            get { return this.dgUCStudentWorksList.CheckedValue; }
        }

        public void LoadData(DataTable listDataSource)
        {
            this.ListDataSource = listDataSource;
            this.dgUCStudentWorksList.InvokeBuildDataSource();
        }

        #endregion
    }
}