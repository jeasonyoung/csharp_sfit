//================================================================================
//  FileName: WorkStorageFactory.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-8
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using iPower;
using iPower.Utility;
using iPower.FileStorage;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine
{
    /// <summary>
    /// 作业附件存储工厂。
    /// </summary>
    public class WorkStorageFactory : IFileStorageFactory
    {
        #region 成员变量，构造函数。
        private string root;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public WorkStorageFactory()
        {
            IStorageConfig cfg = (new ModuleConfiguration()) as IStorageConfig;

            if (cfg == null) throw new ArgumentNullException("未实现附件存储源接口：" + typeof(IStorageConfig).FullName);
            if (string.IsNullOrEmpty(cfg.StorageSource)) throw new ArgumentNullException("StorageSource", "未配置附件存储根目录。");

            this.root = Path.GetFullPath(cfg.StorageSource);
            if (!Directory.Exists(this.root)) Directory.CreateDirectory(this.root);
        }
        #endregion

        #region IFileStorageFactory 成员
        /// <summary>
        /// 上传文件。
        /// </summary>
        /// <param name="fileName">文件名称。</param>
        /// <param name="offSet">偏移量。</param>
        /// <param name="content">文件内容。</param>
        /// <returns>成功返回True，失败False。</returns>
        public bool Upload(string fileName, long offSet, byte[] content)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException("fileName", "文件名不能为空！");
            bool result = false;
            if (content != null && content.Length > 0)
            {
                string path = Path.GetFullPath(this.root + "\\" + fileName);
                string dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                if (offSet < 0) offSet = 0;
                using (FileStream fs = new FileStream(path, (offSet > 0 ? FileMode.OpenOrCreate : FileMode.Create), (offSet > 0 ? FileAccess.ReadWrite : FileAccess.Write), FileShare.ReadWrite))
                {
                    if (offSet > 0) fs.Seek(offSet, SeekOrigin.Begin);
                    fs.Write(content, 0, content.Length);
                    fs.Flush();
                    fs.Close();
                    result = true;
                }
            }
            return result;
        }
        /// <summary>
        /// 删除文件。
        /// </summary>
        /// <param name="fileName">文件名称。</param>
        /// <returns>成功返回true,失败返回false。</returns>
        public bool DeleteFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException("fileName", "文件名不能为空！");
            string path = Path.GetFullPath(this.root + "\\" + fileName);
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    return true;
                }
                catch (Exception) { };
            }
            return false;
        }
        /// <summary>
        /// 下载文件。
        /// </summary>
        /// <param name="fileName">文件名称。</param>
        /// <returns>文件数据。</returns>
        public byte[] Download(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException("fileName", "文件名不能为空！");
            byte[] data = null;
            string path = Path.GetFullPath(this.root + "\\" + fileName);
            if (File.Exists(path))
            {
                using (BufferBlockUtil block = new BufferBlockUtil())
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        int count = 0;
                        byte[] buffer = new byte[1024];
                        while ((count = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            block.Write(buffer, 0, count);
                        }
                        fs.Close();
                    }
                    data = block.ToArray();
                }
            }
            return data;

        }
        #endregion
    }
}