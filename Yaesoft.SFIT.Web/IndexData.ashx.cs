using System;
using System.Collections.Generic;
using System.Web;

using Yaesoft.SFIT.Engine.Index;
using Newtonsoft.Json;
namespace Yaesoft.SFIT.Web
{

    /// <summary>
    /// 异步数据获取。
    /// </summary>
    public class IndexData : IHttpHandler
    {
        #region  成员变量，构造函数。
        IndexDataService service = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public IndexData()
        {
            this.service = new IndexDataService();
        }
        #endregion

        #region IHttpHandler。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            lock (this)
            {
                context.Response.ContentType = "text/plain";
                string type = context.Request["type"];
                string uid = context.Request["uid"];
                string gid = context.Request["gid"];
                string cid = context.Request["cid"];
                string sid = context.Request["sid"];
                string st = context.Request["st"];
                string strPage = context.Request["page"];
                string rows = context.Request["rows"];
                string strIndex = context.Request["index"];
                string sort = context.Request["sort"];
                string order = context.Request["order"];
                int page = 20, index = 0;
                try
                {
                    int p = 0;
                    if (!string.IsNullOrEmpty(strPage) && int.TryParse(strPage, out p))
                    {
                        page = p;
                    }
                }
                catch (Exception) { }
                try
                {
                    int i = 0;
                    if (!string.IsNullOrEmpty(strIndex) && int.TryParse(strIndex, out i))
                    {
                        index = i;
                    }
                }
                catch (Exception) { }

                CallAjaxResult result = null;
                try
                {
                    if (type == "rpt")
                    {
                        index = page;
                        if (int.TryParse(rows, out page))
                        {
                            //index = rows
                        }
                    }
                    result = this.service.Run(type, uid, gid, cid, sid, st, page, index, sort, order);
                    if (result == null)
                    {
                        result = new CallAjaxResult();
                        result.Success = false;
                        result.Message = "没有返回数据！";
                    }
                }
                catch (Exception x)
                {
                    result = new CallAjaxResult();
                    result.Success = false;
                    result.Message = x.Message;
                }
                finally
                {
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    context.Response.Flush();
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
    }
}
