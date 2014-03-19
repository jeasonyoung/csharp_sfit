//================================================================================
//  FileName: ExportWorkUtils.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-24
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
using System.Windows.Forms;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;

using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Utils
{
    /// <summary>
    /// 导出学生作品工具类。
    /// </summary>
    internal class ExportWorkUtils
    {
        #region 成员变量，构造函数。
        string teacherID = null;
        List<TreeNode> nodes = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="nodes"></param>
        public ExportWorkUtils(string teacherID, List<TreeNode> nodes)
        {
            this.teacherID = teacherID;
            this.nodes = nodes;
        }
        #endregion

        #region 公开函数。
        /// <summary>
        /// 导出数据。
        /// </summary>
        /// <param name="outputFilePath"></param>
        /// <param name="handler"></param>
        public void Export(string outputFilePath, RaiseChangedHandler handler)
        {
            lock (this)
            {
                if (nodes != null && nodes.Count > 0 && !string.IsNullOrEmpty(outputFilePath))
                {
                    this.RaiseChanged(handler, "开始检索数据...");
                    Stack<NodeValue> stack = null;
                    Dictionary<String, List<String>> dict = new Dictionary<string, List<string>>();
                    foreach (TreeNode n in nodes)
                    {
                        stack = new Stack<NodeValue>();
                        this.GetAllNodeValue(n, stack);
                        if (stack.Count > 0)
                        {
                            this.SetOutputData(stack.ToArray(), ref dict);
                        }
                    }
                    ExportImportManifest mainfset = new ExportImportManifest("2.0");
                    mainfset.TeacherID = this.teacherID;
                    List<String> list_ClassID_CatalogID = new List<string>();
                    List<LocalStudentWorkStore> listStore = new List<LocalStudentWorkStore>();
                    if (dict != null && dict.Count > 0)
                    {
                        #region 检索存储文件。
                        this.RaiseChanged(handler, "开始加载检索文件...");
                        foreach (string key in dict.Keys)
                        {
                            string[] arr = key.Split('_');
                            if (arr != null && arr.Length > 1)
                            {
                                LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(this.teacherID, arr[1], arr[0]);
                                if (store != null && store.Students != null)
                                {
                                    list_ClassID_CatalogID.Add(key);
                                    List<String> list = dict[key];
                                    if (list != null && list.Count > 0 && (list.Count != store.Students.Count))
                                    {
                                        List<LocalStudent> removeStudents = new List<LocalStudent>();
                                        foreach (LocalStudent ls in store.Students)
                                        {
                                            if (!list.Contains(ls.StudentID))
                                            {
                                                removeStudents.Add(ls);
                                            }
                                        }
                                        if (removeStudents.Count > 0)
                                        {
                                            store.Students.Remove(removeStudents.ToArray());
                                        }
                                    }
                                    listStore.Add(store);
                                }
                            }
                        }
                        #endregion
                    }
                    if (listStore.Count > 0)
                    {
                        mainfset.ClassID_CatalogID = list_ClassID_CatalogID.ToArray();
                        this.RaiseChanged(handler, "创建导出清单文件...");
                        outputFilePath = outputFilePath.Replace(Path.GetExtension(outputFilePath), ".zip");
                        using (FileStream outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                        {
                            this.RaiseChanged(handler, "创建压缩文件...");
                            Crc32 crc = new Crc32();
                            using (ZipOutputStream zipStream = new ZipOutputStream(outputStream))
                            {
                                zipStream.SetLevel(9);
                                byte[] data = UtilTools.Serializer<ExportImportManifest>(mainfset);
                                if (data != null)
                                {
                                    this.RaiseChanged(handler, "压缩导出清单文件...");
                                    ZipEntry entry = new ZipEntry("ExportImportManifest.xml");
                                    entry.DateTime = DateTime.Now;
                                    entry.Size = data.Length;
                                    crc.Reset();
                                    crc.Update(data);
                                    entry.Crc = crc.Value;
                                    zipStream.PutNextEntry(entry);
                                    zipStream.Write(data, 0, data.Length);
                                    zipStream.CloseEntry();
                                }
                                this.RaiseChanged(handler, "开始抽取压缩作品数据...");
                                this.BuildZipFile(zipStream,crc, listStore, handler);
                                this.RaiseChanged(handler, "压缩作品数据完成");
                            }
                        }
                        this.RaiseChanged(handler, "作品数据导出完成");
                    }
                }
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipStream"></param>
        /// <param name="crc"></param>
        /// <param name="listStore"></param>
        /// <param name="handler"></param>
        private void BuildZipFile(ZipOutputStream zipStream,Crc32 crc, List<LocalStudentWorkStore> listStore, RaiseChangedHandler handler)
        {
            foreach (LocalStudentWorkStore store in listStore)
            {
                string root = string.Format("{0}_{1}", store.ClassID, store.CatalogID);
                byte[] data = UtilTools.Serializer<LocalStudentWorkStore>(store);
                if (data != null && data.Length > 0)
                {
                    this.RaiseChanged(handler, string.Format("开始压缩[{0},{1}]...", store.ClassName, store.CatalogName));
                    this.BuildZipData(zipStream, crc, data, string.Format("{0}{1}TSW_{2}_{3}.cfg.xml", root, Path.DirectorySeparatorChar,store.ClassID, store.CatalogID));
                    if (store.Students != null && store.Students.Count > 0)
                    {
                        this.RaiseChanged(handler, "开始压缩学生作品...");
                        foreach (LocalStudent ls in store.Students)
                        {
                            string dir = string.Format("{0}{1}{2}{1}", root, Path.DirectorySeparatorChar,ls.StudentID);
                            if (ls.HasWork())
                            {
                                LocalStudentWork lsw = ls.Work;
                                if (lsw.WorkFiles != null && lsw.WorkFiles.Count > 0)
                                {
                                    foreach (LocalStudentWorkFile f in lsw.WorkFiles)
                                    {
                                        string path = lsw.StudentWorkFilePath(store, ls, f);
                                        if (File.Exists(path))
                                        {
                                            this.RaiseChanged(handler, string.Format("开始压缩学生作品[{0},{1}{2}]...", ls.StudentName, f.FileName, f.FileExt));
                                            using (MemoryStream ms = new MemoryStream())
                                            {
                                                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                                                {
                                                    int len = 0;
                                                    byte[] buf = new byte[512];
                                                    while ((len = fs.Read(buf, 0, buf.Length)) > 0)
                                                    {
                                                        ms.Write(buf, 0, len);
                                                    }
                                                }
                                                this.BuildZipData(zipStream, crc, ms.ToArray(), string.Format("{0}{1}{2}", dir, f.FileID, f.FileExt));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        this.RaiseChanged(handler, "压缩学生作品完成");
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipStream"></param>
        /// <param name="crc"></param>
        /// <param name="data"></param>
        /// <param name="filename"></param>
        private void BuildZipData(ZipOutputStream zipStream,Crc32 crc,byte[] data,string filename)
        {
            if (zipStream != null && data != null && !string.IsNullOrEmpty(filename))
            {
                ZipEntry entry = new ZipEntry(filename);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        private void RaiseChanged(RaiseChangedHandler handler,string message)
        {
            if (handler != null)
            {
                handler(message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dict"></param>
        private void SetOutputData(NodeValue[] data, ref Dictionary<string, List<string>> dict)
        {
            if (data != null && data.Length > 0)
            {
                string classID = this.OutputDataValue(data, "ClassID");
                string catalogID = this.OutputDataValue(data, "CatalogID");
                string studentID = this.OutputDataValue(data, "StudentID");

                string key = string.Format("{0}_{1}", classID, catalogID);
                if (dict.ContainsKey(key))
                {
                    List<string> list = dict[key];
                    if (list == null)
                    {
                        list = new List<string>();
                    }
                    list.Add(studentID);
                    dict[key] = list;
                }
                else
                {
                    List<string> list = null;
                    if (!string.IsNullOrEmpty(studentID))
                    {
                        list = new List<string>();
                        list.Add(studentID);
                    }
                    dict[key] = list;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        private string OutputDataValue(NodeValue[] data, string itemName)
        {
            if (data != null && data.Length > 0 && !string.IsNullOrEmpty(itemName))
            {
                List<NodeValue> list = new List<NodeValue>();
                list.AddRange(data);
                NodeValue v = list.Find(new Predicate<NodeValue>(delegate(NodeValue sender)
                {
                    return (sender != null) && string.Equals(sender.Name, itemName, StringComparison.InvariantCultureIgnoreCase);
                }));
                if (v != null)
                {
                    return v.Value;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="stack"></param>
        private void GetAllNodeValue(TreeNode node, Stack<NodeValue> stack)
        {
            if (node != null && stack != null)
            {
                NodeValue item = this.GetNodeValue(node);
                if (item != null)
                {
                    stack.Push(item);
                }
                this.GetAllNodeValue(node.Parent, stack);
            }
        }
        /// <summary>
        /// 获取节点的值数据。
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private NodeValue GetNodeValue(TreeNode node)
        {
            if (node != null && node.Tag != null)
            {
                string[] array = string.Format("{0}", node.Tag).Split('#');
                if (array != null && array.Length > 0)
                {
                    return new NodeValue(array[0], array[1]);
                }
            }
            return null;
        }
        #endregion

        #region 内置类。
        /// <summary>
        /// 
        /// </summary>
        class NodeValue
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <param name="value"></param>
            public NodeValue(string name, string value)
            {
                this.Name = name;
                this.Value = value;
            }
            /// <summary>
            /// 
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Value { get; set; }
        }
        #endregion
    }
}
