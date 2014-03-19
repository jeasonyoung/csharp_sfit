//================================================================================
//  FileName: IndexRpt.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-22
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

using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class IndexRpt : ModuleBasePage, IIndexRptView
    {
        #region 成员变量，构造函数。
        IndexRptPresenter presenter = null;
        /// <summary>
        /// 
        /// </summary>
        public IndexRpt()
        {
            this.presenter = new IndexRptPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.presenter.InitializeComponent();
            }
        }
        #endregion

        #region IIndexRptView 成员

        public string RptType
        {
            get { return this.Request["type"]; }
        }

        public string UnitID
        {
            get { return this.Request["uid"]; }
        }

        public string UnitName
        {
            get
            {
                object o = this.ViewState["UnitName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["UnitName"] = value;
            }
        }

        public string ClassID
        {
            get { return this.Request["cid"]; }
        }

        public string ClassName
        {
            get
            {
                object o = this.ViewState["ClassName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["ClassName"] = value;
            }
        }

        public string StudentID
        {
            get { return this.Request["StudentID"]; }
        }

        public string StudentName
        {
            get
            {
                object o = this.ViewState["StudentName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["StudentName"] = value;
            }
        }

        public string CatalogID
        {
            get { return this.Request["sid"]; }
        }

        public string CatalogName
        {
            get
            {
                object o = this.ViewState["CatalogName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["CatalogName"] = value;
            }
        }

        public string Time
        {
            get { return this.Request["st"]; }
        }
        #endregion
    }
}