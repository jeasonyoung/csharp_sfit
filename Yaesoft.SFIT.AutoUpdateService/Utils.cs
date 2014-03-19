//================================================================================
//  FileName: Utils.cs
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
using System.IO;
namespace Yaesoft.SFIT.AutoUpdateService
{
    /// <summary>
    /// 工具类。
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// 计算文件路径。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string CalPathToFile(string path)
        {
            if (!File.Exists(path))
            {
                return Path.GetFullPath(string.Format("{0}/{1}", AppDomain.CurrentDomain.BaseDirectory, path));
            }
            return path;
        }
    }
}