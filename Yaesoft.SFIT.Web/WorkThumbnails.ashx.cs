//================================================================================
//  FileName: WorkThumbnails.ashx.cs
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
using System.Drawing;
using System.Drawing.Imaging;

using iPower;
using Yaesoft.SFIT.Engine;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 作业缩略图。
    /// </summary>
    public class WorkThumbnails : IHttpHandler
    {
        #region 成员变量，构造函数。
        WorkThumbnailsService service = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public WorkThumbnails()
        {
            this.service = new WorkThumbnailsService();
        }
        #endregion

        #region IHttpHandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.Clear();   
                GUIDEx workId = context.Request["id"];
                if (workId.IsValid)
                {
                    context.Response.ContentType = "image/jpeg";
                    string strW = context.Request["w"];
                    string strH = context.Request["h"];

                    int w = 0, h = 0;
                    if (!string.IsNullOrEmpty(strW) || !string.IsNullOrEmpty(strH))
                    {
                        int.TryParse(strW, out w);
                        int.TryParse(strH, out h);
                    }
                    Image image = this.service.LoadThumbnails(workId, w, h);
                    if (image != null)
                    {
                        image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    }
                }
                else
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("作业id为空！");
                }
            }
            catch (Exception x)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(x.Message);
            }
            finally
            {
                context.Response.Flush();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
        #endregion
    }
}