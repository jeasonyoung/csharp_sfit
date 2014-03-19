//================================================================================
//  FileName: IndexSearch.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-17
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
    /// <summary>
    /// 
    /// </summary>
    public partial class IndexSearch : ModuleBasePage,IIndexSearchView
    {
        #region 成员变量，构造函数。
        IndexSearchPresenter presenter = null;
        /// <summary>
        /// 
        /// </summary>
        public IndexSearch()
        {
            this.presenter = new IndexSearchPresenter(this);
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

        #region IIndexSearchView 成员
        /// <summary>
        /// 
        /// </summary>
        public string SchoolID
        {
            get { return this.RequestGUIEx("UID"); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SchoolName
        {
            get
            {
                object o = this.ViewState["SchoolName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["SchoolName"] = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassID
        {
            get { return this.RequestGUIEx("CID"); }
        }
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public string CatalogID
        {
            get { return this.RequestGUIEx("SID"); }
        }
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public string WorkTime
        {
            get { return this.RequestGUIEx("ST"); }
        }

        #endregion
    }
}