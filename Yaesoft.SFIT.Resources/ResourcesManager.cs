//================================================================================
//  FileName: PicturesResources.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/16
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.IO;
namespace Yaesoft.SFIT.Resources
{
    /// <summary>
    /// 资源管理
    /// </summary>
    public static class ResourcesManager
    {
        #region 成员变量，构造函数。
        static Assembly assembly;
        static ResourcesManager()
        {
            assembly = Assembly.GetExecutingAssembly();
        }
        #endregion

        /// <summary>
        /// 资源文件全名称格式。
        /// </summary>
        const string RESOURCES_FULLNAME_FORMAT = "Yaesoft.SFIT.Resources.Pictures.{0}";
        /// <summary>
        /// 默认未知图片名称。
        /// </summary>
        const string DEFAULT_NUKNOW_IMAGE_FILENAME = "unknow.gif";
        /// <summary>
        /// 获取图片资源。
        /// </summary>
        /// <param name="fileName">文件名称。</param>
        /// <param name="width">图片宽度。</param>
        /// <param name="height">图片高度。</param>
        /// <returns></returns>
        static Image GetImageResource(string fileName, int width, int height)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    string strFileName = string.Format(RESOURCES_FULLNAME_FORMAT, Path.GetFileName(fileName));
                    Stream stream = assembly.GetManifestResourceStream(strFileName);
                    if (stream == null)
                        return null;
                    Image sourceImage = Image.FromStream(stream);
                    if (sourceImage != null && width > 0 && height > 0)
                    {
                        return ImageHelper.MakeThumbnail(sourceImage, width, height);
                    }
                    return sourceImage;
                }
                catch (Exception e)
                {
                    CreateErrorLog(e);
                }
            }
            return null;
        }
        /// <summary>
        /// 获取扩展名图片。
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static Image GetExtImageResource(string ext)
        {
            Image img = null;
            int width = 48, height = 48;
            if (!string.IsNullOrEmpty(ext))
            {
                string[] arr = ext.Split('.');
                if (arr != null && arr.Length > 0)
                    ext = arr[arr.Length - 1];
                string fileName = string.Format("{0}.gif", ext);
                img = GetImageResource(fileName, width, height);
            }
            if (img != null)
                return img;
            return GetDefaultNullImageResource(width, height);
        }
        /// <summary>
        /// 获取默认为空的图片。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image GetDefaultNullImageResource(int width, int height)
        {
            return GetImageResource(DEFAULT_NUKNOW_IMAGE_FILENAME, width, height);
        }
        /// <summary>
        /// 记录错误日志。
        /// </summary>
        /// <param name="e"></param>
        public static void CreateErrorLog(Exception e)
        {
            if (e == null)
                return;
            string path = Path.GetFullPath(string.Format("{0}\\{1}.log", AppDomain.CurrentDomain.BaseDirectory, typeof(ResourcesManager).FullName));
            using (StreamWriter sw = new StreamWriter(path, true, UTF8Encoding.UTF8))
            {
                sw.WriteLine(new String('-', 50));
                sw.WriteLine(string.Format("Message:{0}", e.Message));
                sw.WriteLine(string.Format("Source:{0}", e.Source));
                sw.WriteLine(string.Format("StackTrace:{0}", e.StackTrace));
                sw.WriteLine(string.Format("DateTime:{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
                sw.WriteLine(new String('-', 50));
            }
        }
    }
}
