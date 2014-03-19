//================================================================================
//  FileName: DefaultThumbnailFormat.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/20
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
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 默认缩略图格式。
    /// </summary>
    public static class DefaultThumbnailFormat
    {
        /// <summary>
        /// 缩略图的宽度。
        /// </summary>
        public const int ThumbnailWidth = 60;
        /// <summary>
        /// 缩略图的高度。
        /// </summary>
        public const int ThumbnailHeight = 45;
        /// <summary>
        /// 缩略图片格式后缀数组。
        /// </summary>
        public readonly static string[] ThumbnailExts = new string[] { ".gif", ".bmp", ".jpeg", ".jpg", ".png" };
                
        /// <summary>
        /// 是否存在缩略图格式。
        /// </summary>
        /// <param name="sourceExts"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static bool IsExistThumbnailFormat(string[] sourceExts, out string ext)
        {
            ext = null;
            if (sourceExts != null && sourceExts.Length > 0)
            {
                foreach (string str in sourceExts)
                {
                    ext = Array.Find<string>(ThumbnailExts, new Predicate<string>(delegate(string sender)
                    {
                        return (!string.IsNullOrEmpty(sender)) && (sender == str.ToLower());
                    }));
                    if (!string.IsNullOrEmpty(ext))
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断文件名是否为图片文件。
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool IsExistThumbnailFormat(string filename)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(filename))
            {
                string ext = Path.GetExtension(filename).ToLower();
                result = Array.Exists<string>(ThumbnailExts, new Predicate<string>(delegate(string sender)
                {
                    return sender.Equals(ext, StringComparison.InvariantCultureIgnoreCase);
                }));
            }
            return result;
        }
    }
}
