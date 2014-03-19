//================================================================================
//  FileName: WorkThumbnailsService.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/25
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
using System.Drawing;
using System.Drawing.Imaging;

using iPower;
using iPower.FileStorage;

using Yaesoft.SFIT;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
using Yaesoft.SFIT.Engine.Service;
using Yaesoft.SFIT.Resources;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
namespace Yaesoft.SFIT.Engine
{
    /// <summary>
    /// 作品缩略图服务。
    /// </summary>
    public class WorkThumbnailsService
    {
        #region 成员变量，构造函数。
        private string imageCacheRoot, imageDefaultPath;
        private WorkDownloadService workDownloadService;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public WorkThumbnailsService()
        {
            ModuleConfiguration cfg = new ModuleConfiguration();
            this.imageCacheRoot = cfg.WorkTempImageCache;
            this.imageDefaultPath = cfg.WorkTempDefaultImagePath;
            this.workDownloadService = new WorkDownloadService();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workID"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public Image LoadThumbnails(GUIDEx workID, int w, int h)
        {
            lock (this)
            {
                Image image = null;
                if (workID.IsValid)
                {
                    #region 初始化宽高。
                    if (w <= 0)
                    {
                        w = 200;
                    }
                    if (h <= 10)
                    {
                        h = 133;
                    }
                    #endregion

                    string path = string.Empty;
                    try
                    {
                        path = this.LoadImageCachePath(workID, w, h);
                        if (File.Exists(path))
                        {
                            image = Image.FromFile(path);
                        }
                        else
                        {
                            #region 抽取缩略图。
                            string fileName, contentType;
                            byte[] data = this.workDownloadService.Download(workID, out fileName, out contentType);
                            if (data != null && data.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    ms.Write(data, 0, data.Length);
                                    ms.Position = 0;
                                    using (ZipFile zipFile = new ZipFile(ms))
                                    {
                                        ZipEntry imageEntry = null;
                                        foreach (ZipEntry entry in zipFile)
                                        {
                                            if (entry.IsFile && DefaultThumbnailFormat.IsExistThumbnailFormat(entry.Name))
                                            {
                                                imageEntry = entry;
                                                break;
                                            }
                                        }
                                        if (imageEntry != null)
                                        {
                                            using (Stream stream = zipFile.GetInputStream(imageEntry))
                                            {
                                                if (stream != null)
                                                {
                                                    image = ImageHelper.MakeThumbnail(stream, w, h);
                                                }
                                            }
                                            if (image != null)
                                            {
                                                image.Save(path, ImageFormat.Jpeg);
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                    catch (Exception x)
                    {
                        #region 异常处理。
                        using (StreamWriter sw = new StreamWriter(string.Format("{0}\\WorkThumbnailsService_{1:yyyyMMdd}.log", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now)))
                        {
                            sw.WriteLine(new String('*',60));
                            sw.WriteLine(String.Format("Path:{0}", path));
                            sw.WriteLine(string.Format("[{0:yyyy-MM-dd HH:mm:ss}]{1}", DateTime.Now, x.Message));
                            sw.WriteLine("Source:" + x.Source);
                            sw.WriteLine("StackTrace:" + x.StackTrace);
                            sw.WriteLine(new String('*', 60));
                        }
                        #endregion
                    }
                    finally
                    {
                        #region 加载默认图片。
                        if (image == null && !string.IsNullOrEmpty(this.imageDefaultPath) && File.Exists(this.imageDefaultPath))
                        {
                            image = Image.FromFile(this.imageDefaultPath);
                        }
                        #endregion
                    }
                }
                return image;
            }
        }

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="work"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        private string LoadImageCachePath(GUIDEx workID, int w, int h)
        {
            return Path.GetFullPath(string.Format("{0}\\{1}_{2}_{3}.jpg", this.imageCacheRoot, workID, w, h));
        }
        #endregion
    }
}
