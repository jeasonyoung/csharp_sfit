//================================================================================
//  FileName: TopBanner.ascx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/2/23
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
using System.IO;

using iPower;
using iPower.Platform.UI;
using iPower.Platform.Engine.Persistence;
using iPower.Platform.Engine.Service;

using iPower.IRMP.Engine.Service;
using iPower.IRMP.Engine.Persistence;
namespace Yaesoft.SFIT.Web.Controls
{
    /// <summary>
    /// Banne头用户控件。
    /// </summary>
    public partial class TopBanner : ModuleBaseControl, ITopBannerView
    {
        #region 成员变量，构造函数。
        TopBannerPresenter<ModuleConfiguration> presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public TopBanner()
        {
            this.presenter = new TopBannerPresenter<ModuleConfiguration>(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 构造Banner资源。
        /// </summary>
        /// <param name="banner"></param>
        /// <returns></returns>
        protected string BuilderBanner(string[] banner)
        {
            if (banner == null || banner.Length != 2)
                return string.Empty;
            else
            {
                if (Path.GetExtension(banner[0]).ToUpper().Equals(".SWF"))
                    return string.Format(WebUIConst.BannerFlashDesc, banner);
                return string.Format(WebUIConst.BannerImageDesc, banner);
            }
        }
        #endregion

        #region ITopBannerView 成员
        ///// <summary>
        ///// 获取或设置导航内容。
        ///// </summary>
        //public string NavigationContent
        //{
        //    get
        //    {
        //        return this.ViewState["NavigationContent"] as string;
        //    }
        //    set
        //    {
        //        this.ViewState["NavigationContent"] = value;
        //    }
        //}
        /// <summary>
        /// 获取顶部菜单。
        /// </summary>
        public TopBannerMenuCollection TopBannerMenus
        {
            get
            {
                object obj = this.ViewState["TopBannerMenus"];
                return obj == null ? new TopBannerMenuCollection() : (TopBannerMenuCollection)obj;
            }
            set
            {
                this.ViewState["TopBannerMenus"] = value;
            }
        }

        #endregion
    }
}