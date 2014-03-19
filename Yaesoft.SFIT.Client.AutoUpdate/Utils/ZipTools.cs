//================================================================================
//  FileName: ZipTools.cs
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
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;

namespace Yaesoft.SFIT.Client.AutoUpdate.Utils
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="stream"></param>
    internal delegate void UnZipStreamHanlder(string filename, Stream stream);
    /// <summary>
    /// Zip工具类。
    /// </summary>
    internal static class ZipTools
    {
        /// <summary>
        /// 解压数据。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="handler"></param>
        public static void UnZip(string path, UnZipStreamHanlder handler)
        {
            if (File.Exists(path) && handler != null)
            {
                lock (typeof(ZipTools))
                {
                    using (ZipFile zip = new ZipFile(File.Open(path, FileMode.Open, FileAccess.Read)))
                    {
                        foreach (ZipEntry entry in zip)
                        {
                            if (entry.IsFile && !string.IsNullOrEmpty(entry.Name))
                            {
                                using (Stream stream = zip.GetInputStream(entry))
                                {
                                    if (stream != null)
                                    {
                                        handler(entry.Name, stream);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
