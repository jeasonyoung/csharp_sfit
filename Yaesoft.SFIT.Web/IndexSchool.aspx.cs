//================================================================================
//  FileName: IndexSchool.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-14
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
    /// 学校主页。
    /// </summary>
    public partial class IndexSchool : ModuleBasePage, IIndexSchoolView
    {
        #region 成员变量，构造函数。
        IndexSchoolPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public IndexSchool()
        {
            this.presenter = new IndexSchoolPresenter(this);
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.presenter.InitializeComponent();
            }
        }
        #endregion

        #region IIndexSchoolView 成员
        /// <summary>
        /// 
        /// </summary>
        public GUIDEx SchoolID
        {
            get
            {
                return this.RequestGUIEx("UID");
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

        #endregion
    }
}
