//================================================================================
//  FileName: AutoUpdateHandler.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-31
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
using System.Web;
using System.IO;
using Yaesoft.SFIT.AutoUpdateService.Data;
namespace Yaesoft.SFIT.AutoUpdateService
{
    /// <summary>
    /// 自动更新处理程序。
    /// </summary>
    public class AutoUpdateHandler : IHttpHandler
    {
        #region 成员变量，构造函数。
        AutoUpdateConfig updates;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public AutoUpdateHandler()
        {
            string path = ModuleConfiguration.ModuleConfig.AutoUpdateConfigFile;
            if (!string.IsNullOrEmpty(path))
            {
                this.updates = AutoUpdateConfig.DeSerializer(path);
            }
        }
        #endregion

        #region IHttpHandler 成员
        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            lock (this)
            {
                context.Response.Clear();
                if (this.updates != null && this.updates.Versions != null && this.updates.Versions.Count > 0)
                {
                    string strVer = context.Request["LVER"];
                    string strUID = context.Request["UID"];
                    if (!string.IsNullOrEmpty(strVer))
                    {
                        #region 获取更新版本。
                        int ver = 0;
                        if (int.TryParse(strVer, out ver))
                        {
                            AutoUpdateVersion updateVersion = this.updates.Versions[ver + 1];
                            if (updateVersion != null && !string.IsNullOrEmpty(updateVersion.PackPath))
                            {
                                context.Response.ContentType = "text/plain";
                                context.Response.ContentEncoding = Encoding.UTF8;
                                context.Response.Write(string.Format("UID={0}", updateVersion.UpdateID));
                            }
                        }
                        #endregion
                    }
                    else if (!string.IsNullOrEmpty(strUID))
                    {
                        #region 下载更新。
                        AutoUpdateVersion updateVersion = this.updates.Versions[strUID];
                        if (updateVersion != null && !string.IsNullOrEmpty(updateVersion.PackPath))
                        {
                            string path = Utils.CalPathToFile(updateVersion.PackPath);
                            if (File.Exists(path))
                            {
                                context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=update_{0}_{1}", updateVersion.Ver, Path.GetFileName(path)));
                                context.Response.ContentType = "application/OCTET-STREAM";
                                context.Response.WriteFile(path);
                            }
                        }
                        #endregion
                    }
                }
                context.Response.Flush();
                context.Response.End();
            }
        }
        #endregion
    }
}
