//================================================================================
//  FileName: IndexClasses.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-16
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
    public partial class IndexClasses : ModuleBasePage, IIndexClassesView
    {
        #region 成员变量，构造函数。
        IndexClassesPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public IndexClasses()
        {
            this.presenter = new IndexClassesPresenter(this);
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

        #region IIndexClassesView 成员
        /// <summary>
        /// 
        /// </summary>
        public GUIDEx ClassID
        {
            get { return this.RequestGUIEx("cid"); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CatalogID
        {
            get { return this.RequestGUIEx("sid"); }
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
        public string SchoolID
        {
            get
            {
                object o = this.ViewState["SchoolID"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["SchoolID"] = value;
            }
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
        public string GradeID
        {
            get
            {
                object o = this.ViewState["GradeID"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["GradeID"] = value;
            }
        }

        #endregion
    }
}