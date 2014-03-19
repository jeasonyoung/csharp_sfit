//================================================================================
//  FileName: WebException.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/8
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

using iPower.Logs;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 应用程序级的异常消息处理。
    /// </summary>
    public class WebException : IHttpModule
    {
        #region 成员变量，构造函数。
        /// <summary>
        ///构造函数。
        /// </summary>
        public WebException()
        {

        }
        #endregion

        #region IHttpModule 成员
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.Error += new EventHandler(delegate(object sender, EventArgs e)
            {
                HttpApplication app = (HttpApplication)sender;
                try
                {
                    app.Response.Clear();
                }
                catch (System.Threading.ThreadAbortException) { }
                finally
                {
                    app.Server.Transfer("~/ErrorPage.aspx", false);
                }

            });
        }

        #endregion
    }
}
