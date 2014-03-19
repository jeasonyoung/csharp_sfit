//================================================================================
//  FileName: CreateCredentials.ashx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/10/18
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
using System.Web.Services;
using System.Xml;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 创建访问密钥。
    /// </summary>
    public class CreateCredentials : IHttpHandler, ICreateCredentialsView
    {
        #region 成员变量，构造函数。
        CreateCredentialsPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public CreateCredentials()
        {
            this.presenter = new CreateCredentialsPresenter(this);
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            if (context != null)
            {
                XmlDocument data = this.presenter.BuildCredentials();
                if (data != null)
                {
                    context.Response.AddHeader("Content-Disposition", "attachment;filename=SFIT_Credentials.bin");
                    context.Response.ContentType = "application/OCTET-STREAM";
                    //context.Response.BinaryWrite(data);
                    data.Save(context.Response.OutputStream);
                    context.Response.Flush();
                    context.Response.End();
                }
                else
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("没有获取到密钥文件数据！");
                }
            }
           
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #endregion

        #region ICreateCredentialsView 成员
        /// <summary>
        /// 
        /// </summary>
        public string ClientServiceUrl
        {
            get
            {
                string url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);
                if (!string.IsNullOrEmpty(url))
                {
                    int end = url.LastIndexOf('/');
                    if (end > 0)
                        url = url.Substring(0, end);
                }
                return string.Format("{0}/TeaClientService.asmx", url);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string[] AccessID
        {
            get
            {
                string str = HttpContext.Current.Request["AccessID"];
                if (!string.IsNullOrEmpty(str))
                    return str.Split(',');
                return null;
            }
        }

        #endregion
    }
}
