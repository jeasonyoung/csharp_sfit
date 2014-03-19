//================================================================================
//  FileName: Default.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/5
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

using iPower.Platform.UI;
using iPower.Platform.WebPart;

using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 默认首页。
    /// </summary>
    public partial class Default : ModuleBasePage, IDefaultView
    {
        #region 成员变量，构造函数。
        DefaultPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Default()
        {
            this.presenter = new DefaultPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.LoadWebPart(this.leftPanel, new WebPartQueryCollectionHandler(delegate()
            {
                return this.presenter.GetWebPartQueryCollection(EnumWebPartAlignment.Left);
            }));
            this.LoadWebPart(this.middlePanel, new WebPartQueryCollectionHandler(delegate()
            {
                return this.presenter.GetWebPartQueryCollection(EnumWebPartAlignment.Middle);
            }));
            this.LoadWebPart(this.rightPanel, new WebPartQueryCollectionHandler(delegate()
            {
                return this.presenter.GetWebPartQueryCollection(EnumWebPartAlignment.Right);
            }));
        }
        #endregion

        #region IDefaultView 成员
        /// <summary>
        /// 页面重定向。
        /// </summary>
        /// <param name="targetUrl"></param>
        public void Redirect(string targetUrl)
        {
            if (!string.IsNullOrEmpty(targetUrl))
            {
                this.Response.Redirect(targetUrl, true);
            }
        }

        #endregion
    }
}
