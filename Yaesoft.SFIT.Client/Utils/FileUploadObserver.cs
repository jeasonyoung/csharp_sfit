//================================================================================
//  FileName: FileUploadObserver.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/19
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
namespace Yaesoft.SFIT.Client.Utils
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="items"></param>
    public delegate void UpdateFileUploadHandler(FileUploadItems items);
    /// <summary>
    /// 文件上传信息。
    /// </summary>
    public class FileUploadObserver
    {
        #region 成员变量，构造函数。
        Hashtable htCache;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public FileUploadObserver()
        {
            this.htCache = Hashtable.Synchronized(new Hashtable());
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        public event UpdateFileUploadHandler UpdateFileUpload;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        protected void OnUpdateFileUpload(FileUploadItems items)
        {
            UpdateFileUploadHandler handler = this.UpdateFileUpload;
            if (handler != null)
                handler(items);
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUri"></param>
        public void AddObserver(string fileUri)
        {
            if (!string.IsNullOrEmpty(fileUri))
            {
                FileUploadItems items = new FileUploadItems();
                if (File.Exists(fileUri))
                {
                    //如果是文件。
                    FileUploadItem item = this.CreateItem(fileUri);
                    if (item != null)
                    {
                        items.Add(item);
                    }
                }
                else
                {
                    //如果是目录。
                    this.CreateItemByFolder(fileUri, ref items);
                }
                this.AddObserver(items);            
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void AddObserver(FileUploadItem item)
        {
            if (item != null && !string.IsNullOrEmpty(item.FileName))
            {
                FileUploadItems items = new FileUploadItems();
                items.Add(item);
                this.AddObserver(items);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        protected void AddObserver(FileUploadItems items)
        {
            if (items != null && items.Count > 0)
            {
                FileUploadItems outputs = new FileUploadItems();
                foreach (FileUploadItem itm in items)
                {
                    if (itm != null && !string.IsNullOrEmpty(itm.FileName) 
                        && !this.htCache.ContainsKey(itm.FileName))
                    {
                        this.htCache.Add(itm.FileName, itm);
                        outputs.Add(itm);
                    }
                }
                if (outputs.Count > 0)
                {
                    this.OnUpdateFileUpload(outputs);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUri"></param>
        public void RemoveObserver(string fileName)
        {
            if ((this.htCache.Count > 0) && !string.IsNullOrEmpty(fileName) && this.htCache.ContainsKey(fileName))
            {
                this.htCache.Remove(fileName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(FileUploadItem item)
        {
            if (item != null && !string.IsNullOrEmpty(item.FileName))
            {
                this.htCache.Remove(item.FileName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void RemoveAll()
        {
            this.htCache.Clear();
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        protected FileUploadItem CreateItem(string filePath)
        {
            FileUploadItem item = null;
            if (File.Exists(filePath))
            {
                item = new FileUploadItem();
                item.Path = filePath;
                item.FileName = Path.GetFileName(filePath);
                item.Ext = Path.GetExtension(filePath);
            }
            return item;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="items"></param>
        protected void CreateItemByFolder(string folderPath, ref FileUploadItems items)
        {
            if (!string.IsNullOrEmpty(folderPath) && Directory.Exists(folderPath))
            {
                //获取目录下文件。
                string[] files = Directory.GetFiles(folderPath);
                if (files != null && files.Length > 0)
                {
                    foreach (string strFile in files)
                    {
                        if (File.Exists(strFile))
                        {
                            FileUploadItem item = this.CreateItem(strFile);
                            if (item != null)
                            {
                                items.Add(item);
                            }
                        }
                    }
                }
                //获取目录下子目录。
                string[] folders = Directory.GetDirectories(folderPath);
                if (folders != null && folders.Length > 0)
                {
                    foreach (string strFolder in folders)
                    {
                        this.CreateItemByFolder(strFolder, ref items);
                    }
                }
            }
        }
        #endregion
    }
    /// <summary>
    /// 上传文件。.
    /// </summary>
    public class FileUploadItem
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public FileUploadItem()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ext"></param>
        /// <param name="path"></param>
        public FileUploadItem(string name, string ext, string path)
        {
            this.FileName = name;
            this.Ext = ext;
            this.Path = path;
        }
        #endregion
        /// <summary>
        /// 获取或设置文件名。
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        ///  获取或设置文件后缀名。
        /// </summary>
        public string Ext { get; set; }
        /// <summary>
        /// 获取或设置文件路径。
        /// </summary>
        public string Path { get; set; }
    }
    /// <summary>
    /// 上传文件集合。
    /// </summary>
    public class FileUploadItems : BaseCollection<FileUploadItem>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public override FileUploadItem this[string fileName]
        {
            get
            {
                FileUploadItem item = this.Items.Find(new Predicate<FileUploadItem>(delegate(FileUploadItem sender)
                {
                    return (sender != null) && (sender.FileName == fileName);
                }));
                return item;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(FileUploadItem x, FileUploadItem y)
        {
            return string.Compare(x.FileName, y.FileName);
        }
    }
}
