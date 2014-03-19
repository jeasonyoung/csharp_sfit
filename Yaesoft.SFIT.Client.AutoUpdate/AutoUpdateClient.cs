//================================================================================
//  FileName: AutoUpdateClient.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-30
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
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using Yaesoft.SFIT.Client.AutoUpdate.Data;
using Yaesoft.SFIT.Client.AutoUpdate.Utils;
using Yaesoft.SFIT.Client.AutoUpdate.Logging;

namespace Yaesoft.SFIT.Client.AutoUpdate
{
    /// <summary>
    ///  通知外部消息委托。
    /// </summary>
    /// <param name="message">消息内容。</param>
    public delegate void RaiseChangedHandler(string message);
    /// <summary>
    /// 自动更新客户端。
    /// </summary>
    public class AutoUpdateClient : IDisposable
    {
        #region 成员变量，构造函数。
        private static Logger logger = new Logger(new Category("AutoUpdateClient"));
        private string serverUrl, updateID;
        private LocalUpdateRecord localUpdateRecord = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="url"></param>
        public AutoUpdateClient(string url)
        {
            this.serverUrl = url;            
        }
        #endregion
        
        #region 函数。
        /// <summary>
        /// 检查更新。
        /// </summary>
        /// <returns></returns>
        public bool CheckforUpdates()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.serverUrl))
                {
                    this.localUpdateRecord = LocalUpdateRecord.DeSerializer();
                    if (this.localUpdateRecord == null || !this.localUpdateRecord.VerifyChecksum())
                    {
                        this.localUpdateRecord = new LocalUpdateRecord();
                    }
                    byte[] data = this.OpenReadWeb(this.serverUrl, new string[] { string.Format("LVER={0}", this.localUpdateRecord.Ver) });
                    if (data != null && data.Length > 0)
                    {
                        string result = Encoding.UTF8.GetString(data);
                        if (!string.IsNullOrEmpty(result))
                        {
                            string[] array = result.Split('=');
                            if ((array != null) && (array.Length == 2) && string.Equals(array[0], "UID", StringComparison.InvariantCultureIgnoreCase))
                            {
                                return !string.IsNullOrEmpty(this.updateID = array[1]);
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                logger.Error("检查更新发生异常：" + e.Message);
                return false;
            }
        }
        /// <summary>
        /// 更新程序。
        /// </summary>
        /// <param name="handler">消息委托。</param>
        /// <returns></returns>
        public bool Updates(RaiseChangedHandler handler)
        {
            handler("开始下载更新，请稍后...");
            string path = string.Format("{0}/Update_{1:yyyyMMddHHmmss}.zip", Application.StartupPath, DateTime.Now);
            if (this.Download(path))
            {
                handler("下载完毕，准备更新...");

                List<string> kills = new List<string>();

                #region 关闭宿主程序。
                handler("关闭宿主程序...");
                string[] runs = Directory.GetFiles(Application.StartupPath, "*.exe");
                string current = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
                for (int i = 0; i < runs.Length; i++)
                {
                    if (runs[i].ToLower().IndexOf(current.ToLower()) == -1)
                    {
                        string pn = Path.GetFileNameWithoutExtension(runs[i]);
                        Process[] pros = Process.GetProcessesByName(pn);
                        if (pros != null && pros.Length > 0)
                        {
                            foreach (Process p in pros)
                            {
                                if (!p.HasExited)
                                {
                                    try
                                    {
                                        p.Kill();
                                        if (runs[i].ToLower().IndexOf(".vshosts.") == -1)
                                        {
                                            kills.Add(runs[i]);
                                        }
                                        Thread.Sleep(500);
                                    }
                                    catch (Exception e)
                                    {
                                        logger.Error("关闭宿主程序[" + p + "]发生异常：" + e.Message);
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 解压更新。
                handler("解压更新中，请稍后...");
                string dir = Application.StartupPath;
                ZipTools.UnZip(path, new UnZipStreamHanlder(delegate(string filename, Stream stream)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(filename) && stream != null)
                        {
                            handler("update:" + Path.GetFileNameWithoutExtension(filename));
                            string fp = Path.GetFullPath(string.Format("{0}/{1}", dir, filename));
                            using (FileStream fs = new FileStream(fp, FileMode.Create, FileAccess.Write))
                            {
                                int len = 0;
                                byte[] buf = new byte[1024];
                                while ((len = stream.Read(buf, 0, buf.Length)) > 0)
                                {
                                    fs.Write(buf, 0, len);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string err = string.Format("更新文件[{0}]发生异常:{1}", filename, e.Message);
                        logger.Error(err);
                        handler(err);
                    }
                }));
                #endregion

                handler("更新完成，启动宿主程序...");
                this.UpdateSuccess();

                #region 启动宿主程序。
                if (kills.Count > 0)
                {
                    foreach (string s in kills)
                    {
                        if (File.Exists(s))
                        {
                            try
                            {
                                Process.Start(s);
                            }
                            catch (Exception e)
                            {
                                logger.Error("启动宿主程序[" + s + "]发生异常：" + e.Message);
                                continue;
                            }
                        }
                    }
                }
                #endregion

                return true;
            }
            return false;
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 下载更新。
        /// </summary>
        /// <param name="savePath"></param>
        protected bool Download(string savePath)
        {
            bool result = false;
            try
            {
                if (!string.IsNullOrEmpty(savePath) && !string.IsNullOrEmpty(this.serverUrl) && !string.IsNullOrEmpty(this.updateID))
                {
                    byte[] data = this.OpenReadWeb(this.serverUrl, new string[] { string.Format("UID={0}", this.updateID) });
                    if (data != null && data.Length > 0)
                    {
                        using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception x)
            {
                logger.Error("下载更新发生异常：" + x.Message);
                MessageBox.Show(x.Message, "下载更新发生异常：", MessageBoxButtons.OK);
            }
            return result;
        }
        /// <summary>
        /// 更新成功。
        /// </summary>
        protected void UpdateSuccess()
        {
            if (this.localUpdateRecord != null)
            {
                this.localUpdateRecord.Ver += 1;
                this.localUpdateRecord.URL = this.serverUrl;
                this.localUpdateRecord.Time = DateTime.Now;
                this.localUpdateRecord.Checksum = this.localUpdateRecord.CreateChecksum();
                this.localUpdateRecord.Serializer();
            }
        }
        /// <summary>
        /// 下载程序更新数据。
        /// </summary>
        /// <param name="url">url。</param>
        /// <param name="postdata">提交数据。</param>
        /// <returns>程序更新数据。</returns>
        private byte[] OpenReadWeb(string url, string[] data)
        {
            byte[] result = null;
            if (!string.IsNullOrEmpty(url))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                if (data != null && data.Length > 0)
                {
                    request.Method = "POST";
                    request.Accept = "text/html, application/xhtml+xml, */*";
                    request.ContentType = "application/x-www-form-urlencoded";
                    byte[] buf = Encoding.UTF8.GetBytes(string.Join("&", data));
                    request.ContentLength = buf.Length;
                    request.GetRequestStream().Write(buf, 0, buf.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (Stream stream = response.GetResponseStream())
                            {
                                int len = 0;
                                byte[] buf = new byte[512];
                                while ((len = stream.Read(buf, 0, buf.Length)) > 0)
                                {
                                    ms.Write(buf, 0, len);
                                }
                            }
                            result = ms.ToArray();
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {

        }
        #endregion
    }
}
