//================================================================================
//  FileName: UCWorksComments.ascx.cs
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
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iPower;
using iPower.Platform.Engine.Service;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 匿名评阅
    /// </summary>
    public partial class UCWorksComments : ModuleBaseControl, IUCWorksCommentsListView
    {
        #region 成员变量，构造函数。
        UCWorksCommentsPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCWorksComments()
        {
            this.presenter = new UCWorksCommentsPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }

        protected void dgUCWorksComments_BuildDataSource(object sender, EventArgs e)
        {
            this.dgUCWorksComments.DataSource = this.presenter.ListDataSource;
        }

        protected void dgUCWorksCommentsDetail_BuildDataSource(object sender, EventArgs e)
        {
            this.dgUCWorksCommentsDetail.DataSource = this.presenter.ListDataSource;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            StringCollection priCollection = null;
            if (this.dgUCWorksComments.Visible)
            {
                priCollection = this.dgUCWorksComments.CheckedValue;
            }
            else if (this.dgUCWorksCommentsDetail.Visible)
            {
                priCollection = this.dgUCWorksCommentsDetail.CheckedValue;
            }

            if (priCollection != null && this.presenter.BatchDeleteComents(priCollection))
            {
                this.LoadData();
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            if (this.dgUCWorksComments.Visible)
                this.dgUCWorksComments.InvokeBuildDataSource();
            else if (this.dgUCWorksCommentsDetail.Visible)
                this.dgUCWorksCommentsDetail.InvokeBuildDataSource();
        }
        #endregion

        #region IUCWorksCommentsView 成员

        public GUIDEx WorkID
        {
            get
            {
                object obj = this.ViewState["WorkID"];
                return obj == null ? GUIDEx.Null : new GUIDEx(obj);
            }
            set
            {
                this.ViewState["WorkID"] = value;
            }
        }

        public void LoadData(GUIDEx workID, bool showDeleteButtom)
        {
            this.LoadData(workID, 15, showDeleteButtom);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workID"></param>
        /// <param name="pageSize"></param>
        /// <param name="showDeleteButtom"></param>
        public void LoadData(GUIDEx workID, int pageSize, bool showDeleteButtom)
        {
            this.WorkID = workID;
            if (showDeleteButtom)
            {
                this.dgUCWorksCommentsDetail.PageSize = pageSize;
                this.dgUCWorksCommentsDetail.Visible = true;
                this.dgUCWorksComments.Visible = false;
            }
            else
            {
                this.dgUCWorksComments.PageSize = pageSize;
                this.dgUCWorksCommentsDetail.Visible = false;
                this.dgUCWorksComments.Visible = true;
            }
            this.panelControl.Visible = showDeleteButtom;
            this.LoadData();
        }
        #endregion
    }
}