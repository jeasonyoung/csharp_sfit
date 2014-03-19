//================================================================================
//  FileName: DefaultPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/13
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
using System.Text;

using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 默认首页视图。
    /// </summary>
    public interface IDefaultView : IModuleView
    {
        /// <summary>
        /// 页面重定向。
        /// </summary>
        /// <param name="targetUrl"></param>
        void Redirect(string targetUrl);
    }
    /// <summary>
    /// 默认首页行为类。
    /// </summary>
    public class DefaultPresenter : ModulePresenter<IDefaultView>
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DefaultPresenter(IDefaultView view)
            : base(view)
        {
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            IDefaultView view = this.View as IDefaultView;
            if (view != null)
            {
                string url = this.ModuleConfig.MyDefaultURL;
                if (!string.IsNullOrEmpty(url))
                {
                    view.Redirect(url);
                }
            }
        }
        #endregion
    }
}
