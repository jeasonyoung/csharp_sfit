//================================================================================
//  FileName: ZipUtils.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-23
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
namespace Yaesoft.SFIT.Client.TeaHost.Utils
{
    /// <summary>
    /// Zip工具类。
    /// </summary>
    internal static class ZipUtils
    {
        /// <summary>
        /// 将文件或目录压缩。
        /// </summary>
        /// <param name="paths">路径集合。</param>
        /// <returns>压缩后数据</returns>
        public static byte[] Zip(string[] paths)
        {
            byte[] data = null;
            if (paths != null && paths.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    //压缩数据保存到临时文件。
                    using (ZipOutputStream zipStream = new ZipOutputStream(ms))
                    {
                        zipStream.SetLevel(9);
                        for (int i = 0; i < paths.Length; i++)
                        {
                            if (File.Exists(paths[i]))
                            {
                                ZipFileData(zipStream, paths[i], null, null);
                            }
                            else if (Directory.Exists(paths[i]))
                            {
                                ZipFolderData(zipStream, paths[i], string.Empty);
                            }
                        }
                        zipStream.IsStreamOwner = true;
                        zipStream.Close();
                    }
                    data = ms.ToArray();
                }
            }
            return data;
        }
        /// <summary>
        /// 压缩文件。
        /// </summary>
        /// <param name="zipStream"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="crc"></param>
        static void ZipFileData(ZipOutputStream zipStream, string path, string fileName, Crc32 crc)
        {
            if (zipStream != null && File.Exists(path))
            {
                using (BufferBlockUtil block = new BufferBlockUtil())
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        byte[] buf = new byte[1024];
                        int len = 0;
                        while ((len = fs.Read(buf, 0, buf.Length)) > 0)
                        {
                            block.Write(buf, 0, len);
                        }
                    }
                    byte[] data = block.ToArray();
                    if (string.IsNullOrEmpty(fileName))
                    {
                        fileName = Path.GetFileName(path);
                    }
                    ZipEntry entry = new ZipEntry(fileName);
                    entry.DateTime = DateTime.Now;
                    entry.Size = data.Length;
                    if (crc != null)
                    {
                        crc.Reset();
                        crc.Update(data);
                        entry.Crc = crc.Value;
                    }
                    zipStream.PutNextEntry(entry);
                    zipStream.Write(data, 0, data.Length);
                    zipStream.CloseEntry();
                }
            }
        }
        /// <summary>
        /// 压缩目录。
        /// </summary>
        /// <param name="zipStream"></param>
        /// <param name="path"></param>
        /// <param name="parentFolderPath"></param>
        static void ZipFolderData(ZipOutputStream zipStream, string path, string parentFolderPath)
        {
            if (zipStream != null && Directory.Exists(path))
            {
                if (path[path.Length - 1] != Path.DirectorySeparatorChar)
                {
                    path += Path.DirectorySeparatorChar;
                }
                Crc32 crc = new Crc32();
                string[] folders = Directory.GetFileSystemEntries(path);
                if (folders != null && folders.Length > 0)
                {
                    foreach (String f in folders)
                    {
                        //先当作目录处理如果存在这个目录就递归Copy该目录下面的文件。
                        if (Directory.Exists(f))
                        {
                            string p = string.Format("{0}{1}{2}", parentFolderPath, Path.GetFileName(f), Path.DirectorySeparatorChar);
                            ZipFolderData(zipStream, f, p);
                        }
                        else if (File.Exists(f))
                        {
                            //直接压缩文件。
                            string fileName = string.Format("{0}{1}", parentFolderPath, Path.GetFileName(f));
                            ZipFileData(zipStream, f, fileName, crc);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  从压缩文件中获取给定文件名的文件流。
        /// </summary>
        /// <param name="zip">压缩文件对象。</param>
        /// <param name="filename">文件名。</param>
        /// <returns>文件数据流</returns>
        public static Stream ZipFileData(ZipFile zipFile, string filename)
        {
            if (zipFile != null && !string.IsNullOrEmpty(filename))
            {
                ZipEntry entry = zipFile.GetEntry(filename);
                if (entry != null && entry.IsFile)
                {
                    return zipFile.GetInputStream(entry);
                }
            }
            return null;
        }
    }
}