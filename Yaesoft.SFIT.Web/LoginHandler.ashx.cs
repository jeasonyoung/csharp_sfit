//================================================================================
//  FileName: LoginHandler.ashx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/18
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
using iPower;
using iPower.IRMP.SSOClient;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 用户登录验证。
    /// </summary>
    public class LoginHandler : IHttpHandler
    {
        #region 成员变量，构造函数。
        int status = 0;
        string err = string.Empty;
        SSOClientModule sso = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public LoginHandler()
        {
            this.sso = new SSOClientModule();
        }
        #endregion

        public void ProcessRequest(HttpContext context)
        {
            string userName = context.Request["username"];
            string password = context.Request["password"];
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                this.status = this.sso.SignInNotRedirect(userName, password, out this.err) ? 0 : -1;
            }
            else
            {
                this.status = -1;
                this.err = "用户名或密码为空！";
            }
            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Write("{\"result\":" + this.status.ToString() + ",\"err\":\"" + this.err + "\"}");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
