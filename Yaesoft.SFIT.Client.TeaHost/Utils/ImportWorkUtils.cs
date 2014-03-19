//================================================================================
//  FileName: ImportWorkUtils.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-25
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
using System.Xml;
using System.Windows.Forms;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;

using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Data.OldVersion;
namespace Yaesoft.SFIT.Client.TeaHost.Utils
{
    /// <summary>
    /// 导入学生作品数据工具类。
    /// </summary>
    internal class ImportWorkUtils
    {
        #region 成员变量，构造函数。
        string teacherID = null,teacherName = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="teacherName"></param>
        public ImportWorkUtils(string teacherID, string teacherName)
        {
            this.teacherID = teacherID;
            this.teacherName = teacherName;
        }
        #endregion

        #region 公开函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="isImportFile"></param>
        /// <param name="handler"></param>
        public void Import(string filepath, bool isImportFile, RaiseChangedHandler handler)
        {
            if (!string.IsNullOrEmpty(filepath) && File.Exists(filepath))
            {
                this.RaiseChanged(handler, "读取文件...");
                if (!string.Equals(Path.GetExtension(filepath), ".zip", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.RaiseChanged(handler, "文件后缀非zip格式！");
                    return;
                }
                try
                {
                    using (FileStream inputStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    {
                        this.RaiseChanged(handler, "校验文件格式...");
                        using (ZipFile zipFile = new ZipFile(inputStream))
                        {
                            using (Stream stream = ZipUtils.ZipFileData(zipFile, "ExportImportManifest.xml"))
                            {
                                if (stream == null)
                                {
                                    this.RaiseChanged(handler, "该压缩文件不是学生作品数据文件！");
                                    return;
                                }
                                else
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        int len = 0;
                                        byte[] buf = new byte[512];
                                        while ((len = stream.Read(buf, 0, buf.Length)) > 0)
                                        {
                                            ms.Write(buf, 0, len);
                                        }
                                        ms.Position = 0;
                                        XmlDocument docfest = new XmlDocument();
                                        docfest.Load(ms);
                                        ms.Position = 0;
                                        XmlElement ver = docfest.SelectSingleNode("//Ver") as XmlElement;
                                        if (ver != null && !string.IsNullOrEmpty(ver.InnerText))
                                        {
                                            float fVer = 0;
                                            if (float.TryParse(ver.InnerText, out fVer))
                                            {
                                                if (fVer == 1.0)
                                                {
                                                    #region 旧版本。
                                                    WorkExportImportManifest mainfest = UtilTools.DeSerializer<WorkExportImportManifest>(ms);
                                                    if (mainfest == null)
                                                    {
                                                        this.RaiseChanged(handler, "该学生作品数据文件版本不能被解析！");
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        ImportOldVersionWorkUtils oldImport = new ImportOldVersionWorkUtils(this.teacherID, this.teacherName, zipFile, isImportFile);
                                                        oldImport.Import(mainfest, handler);
                                                        this.RaiseChanged(handler, "学生作品数据导入完成！");
                                                    }
                                                    #endregion
                                                }
                                                else if (fVer == 2.0)
                                                {
                                                    #region 新版本。
                                                    ExportImportManifest mainfest = UtilTools.DeSerializer<ExportImportManifest>(ms);
                                                    if (mainfest == null)
                                                    {
                                                        this.RaiseChanged(handler, "该学生作品数据文件版本不能被解析！");
                                                        return;
                                                    }
                                                    else if (!string.IsNullOrEmpty(mainfest.TeacherID) &&
                                                        string.Equals(mainfest.TeacherID, this.teacherID, StringComparison.InvariantCultureIgnoreCase))
                                                    {
                                                        this.RaiseChanged(handler, "开始导入学生作品数据信息...");
                                                        this.ImportWorkData(mainfest, zipFile, isImportFile, handler);
                                                        this.RaiseChanged(handler, "学生作品数据信息导入完成");
                                                    }
                                                    else
                                                    {
                                                        this.RaiseChanged(handler, "该学生作品数据文件不属于当前教师用户，不能导入！");
                                                        return;
                                                    }
                                                    #endregion
                                                }
                                                else
                                                {
                                                    this.RaiseChanged(handler, string.Format("该学生作品数据文件版本号[{0}]不能被解析！", ver.InnerText));
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                this.RaiseChanged(handler, string.Format("该学生作品数据文件版本号[{0}]格式不正确，不能被解析！", ver.InnerText));
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            this.RaiseChanged(handler, "该学生作品数据文件版本不能被解析！");
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception x)
                {
                    this.RaiseChanged(handler, x.Message);
                    MessageBox.Show("发生异常：" + x.Message);
                }
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="students"></param>
        /// <param name="dir"></param>
        /// <param name="zipFile"></param>
        /// <param name="handler"></param>
        private void ImportWorkFiles(LocalStudentWorkStore store, LocalStudents students, string dir, ZipFile zipFile, RaiseChangedHandler handler)
        {
            if (store != null && students != null && students.Count > 0 && zipFile != null)
            {
                foreach (LocalStudent ls in students)
                {
                    if (ls.HasWork())
                    {
                        LocalStudentWork lsw = ls.Work;
                        if (lsw.WorkFiles != null && lsw.WorkFiles.Count > 0)
                        {
                            string zipDir = string.Format("{0}{1}{2}{1}", dir, Path.DirectorySeparatorChar, ls.StudentID);
                            this.RaiseChanged(handler, string.Format("导入[{0},{1}]作品数据...", ls.StudentName, ls.StudentCode));
                            foreach (LocalStudentWorkFile lswf in lsw.WorkFiles)
                            {
                                string sPath = string.Format("{0}{1}{2}", zipDir, lswf.FileID, lswf.FileExt);
                                try
                                {
                                    using (Stream stream = ZipUtils.ZipFileData(zipFile, sPath))
                                    {
                                        if (stream != null)
                                        {
                                            this.RaiseChanged(handler, string.Format("导入作品{0}{1}...", lswf.FileName, lswf.FileExt));
                                            using (FileStream fs = new FileStream(lsw.StudentWorkFilePath(store, ls, lswf), FileMode.Create, FileAccess.Write))
                                            {
                                                byte[] buf = new byte[512];
                                                int len = 0;
                                                while ((len = stream.Read(buf, 0, buf.Length)) > 0)
                                                {
                                                    fs.Write(buf, 0, len);
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception x)
                                {
                                    Exception t = new Exception(string.Format("[{0},{1}]{2}{3}:{4}", ls.StudentName, ls.StudentCode, lswf.FileName, lswf.FileExt, sPath), x);
                                    UtilTools.OnExceptionRecord(t, typeof(ImportWorkUtils));
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="classID"></param>
        /// <param name="catalogID"></param>
        /// <param name="zipFile"></param>
        /// <param name="isImportFile"></param>
        /// <param name="handler"></param>
        private void ImportWorkData(string dir, string classID, string catalogID, ZipFile zipFile, bool isImportFile, RaiseChangedHandler handler)
        {
            string filename = string.Format("{0}{1}TSW_{2}_{3}.cfg.xml", dir, Path.DirectorySeparatorChar,classID, catalogID);
            using (Stream stream = ZipUtils.ZipFileData(zipFile, filename))
            {
                LocalStudentWorkStore importStore = UtilTools.DeSerializer<LocalStudentWorkStore>(stream);
                if (importStore != null && (importStore.Students != null) && (importStore.Students.Count > 0) && !string.IsNullOrEmpty(this.teacherID))
                {
                    LocalStudentWorkStore localStore = LocalStudentWorkStore.DeSerializer(this.teacherID, catalogID, classID);
                    if (localStore != null)
                    {
                        #region 更新学生作品信息数据。
                        this.RaiseChanged(handler, string.Format("导入[{0},{1}]", importStore.ClassName, importStore.CatalogName));
                        if (localStore.Students == null)
                        {
                            localStore.Students = new LocalStudents();
                        }

                        foreach (LocalStudent ls in importStore.Students)
                        {
                            LocalStudent student = localStore.Students[ls.StudentID];
                            if (student == null)
                            {
                                localStore.Students.Add(ls);
                            }
                            else
                            {
                                student = ls;
                            }
                        }
                        #endregion
                        this.RaiseChanged(handler, string.Format("更新[{0},{1}]记录文件...", localStore.ClassName, localStore.CatalogName));
                        //更新记录文件。
                        this.CorrectWorkFileSuffix(localStore);
                        WorkStoreHelper.Serializer(ref localStore);
                        //localStore.Serializer();
                        //导入学生作品数据。
                        if (isImportFile)
                        {
                            this.RaiseChanged(handler, string.Format("开始导入[{0},{1}]学生作品数据...", localStore.ClassName, localStore.CatalogName));
                            this.ImportWorkFiles(localStore, importStore.Students, dir, zipFile, handler);
                        }
                    }
                    else
                    {
                        this.RaiseChanged(handler, string.Format("更新[{0},{1}]记录文件...", importStore.ClassName, importStore.CatalogName));
                        this.CorrectWorkFileSuffix(importStore);
                        WorkStoreHelper.Serializer(ref importStore);
                        //importStore.Serializer();
                        //导入作品数据。
                        this.RaiseChanged(handler, string.Format("开始导入[{0},{1}]学生作品数据...", importStore.ClassName, importStore.CatalogName));
                        this.ImportWorkFiles(importStore, importStore.Students, dir, zipFile, handler);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainfest"></param>
        /// <param name="zipFile"></param>
        /// <param name="isImportFile"></param>
        private void ImportWorkData(ExportImportManifest mainfest, ZipFile zipFile, bool isImportFile, RaiseChangedHandler handler)
        {
            if (mainfest != null && mainfest.ClassID_CatalogID != null && mainfest.ClassID_CatalogID.Length > 0 && zipFile != null)
            {
                for (int i = 0; i < mainfest.ClassID_CatalogID.Length; i++)
                {
                    if (!string.IsNullOrEmpty(mainfest.ClassID_CatalogID[i]))
                    {
                        string[] arr = mainfest.ClassID_CatalogID[i].Split('_');
                        if (arr != null && arr.Length > 1)
                        {
                            this.ImportWorkData(mainfest.ClassID_CatalogID[i], arr[0], arr[1], zipFile, isImportFile, handler);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        private void RaiseChanged(RaiseChangedHandler handler, string message)
        {
            if (handler != null)
            {
                handler(message);
            }
        }
        /// <summary>
        /// 修正作业文件后缀。
        /// </summary>
        private void CorrectWorkFileSuffix(LocalStudentWorkStore store)
        {
            if (store != null && store.Students != null && store.Students.Count > 0)
            {
                for (int i = 0; i < store.Students.Count; i++)
                {
                    LocalStudent ls = store.Students[i];
                    if (ls != null && ls.HasWork())
                    {
                        LocalStudentWork lsw = ls.Work;
                        if (lsw != null && lsw.WorkFiles != null && lsw.WorkFiles.Count > 0)
                        {
                            for (int k = 0; k < lsw.WorkFiles.Count; k++)
                            {
                                LocalStudentWorkFile lswf = lsw.WorkFiles[k];
                                if (lswf != null)
                                {
                                    lswf.FileName = Path.GetFileNameWithoutExtension(lswf.FileName);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}