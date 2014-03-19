using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Text;

using iPower;
using iPower.FileStorage;
using Yaesoft.SFIT.Engine.Service;

namespace Yaesoft.SFIT.Web
{

    /// <summary>
    /// 附件下载。
    /// </summary>
    public class AccessoriesDownload : IHttpHandler
    {
        #region 成员变量，构造函数。
        private WorkDownloadService workDownloadService;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public AccessoriesDownload()
        {
            this.workDownloadService = new WorkDownloadService();
        }
        #endregion

        #region IHttpHandler
        /// <summary>
        /// 请求处理函数。
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            GUIDEx fileID = context.Request["FileID"];
            if (fileID.IsValid)
            {
                this.Download(context.Response, fileID);
            }
            else
            {
                context.Response.Write("请输入参数：FileID");
            }
        }
        /// <summary>
        /// 是否重用实例。
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
        #endregion

        #region 辅助函数。
        void Download(HttpResponse resp, GUIDEx fileID)
        {
            lock (this)
            {
                if (resp != null)
                {
                    string fullFileName = null, contentType = null;
                    byte[] data = this.workDownloadService.Download(fileID, out fullFileName, out contentType);
                    if (data != null && data.Length > 0)
                    {
                        resp.Buffer = true;
                        resp.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fullFileName, System.Text.Encoding.UTF8));
                        resp.ContentEncoding = Encoding.GetEncoding("gb2312");//设置输出流为简体中文
                        resp.ContentType = contentType;//"application/OCTET-STREAM";
                        // resp.BufferOutput = true;
                        resp.BinaryWrite(data);
                        resp.Flush();
                        resp.End();
                    }
                    else
                    {
                        resp.Write("文件不存在！" + fileID);
                    }
                }
            }
        }
        #endregion
    }
}