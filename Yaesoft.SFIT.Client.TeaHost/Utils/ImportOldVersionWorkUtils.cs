//================================================================================
//  FileName: ImportOldVersionWorkUtils.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-11-6
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
    /// 导入旧版本学生作业数据工具类。
    /// </summary>
    internal class ImportOldVersionWorkUtils
    {
        #region 成员变量，构造函数。
        ZipFile zipFile = null;
        string teacherID = null, teacherName = null;
        bool isImportFile = false;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="teacherName"></param>
        /// <param name="zipFile"></param>
        /// <param name="manifest"></param>
        /// <param name="isImportFile"></param>
        public ImportOldVersionWorkUtils(string teacherID, string teacherName, ZipFile zipFile,bool isImportFile)
        {
            this.teacherID = teacherID;
            this.teacherName = teacherName;
            this.zipFile = zipFile;
            this.isImportFile = isImportFile;
        }
        #endregion

        #region 公开函数。
        /// <summary>
        /// 导入。
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="teacherId"></param>
        /// <param name="handler"></param>
        public void Import(WorkExportImportManifest mainfest,RaiseChangedHandler handler)
        {
            if (!string.IsNullOrEmpty(this.teacherID) && !string.IsNullOrEmpty(this.teacherName) && 
                mainfest != null && mainfest.Storages != null && mainfest.Storages.Count > 0)
            {
                for (int i = 0; i < mainfest.Storages.Count; i++)
                {
                    this.ImportWorkData(mainfest.Storages[i], handler);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="handler"></param>
        private void ImportWorkData(StudentWorkTeaStorage storage,RaiseChangedHandler handler)
        {
            lock (this)
            {
                if (string.IsNullOrEmpty(this.teacherID) || string.IsNullOrEmpty(this.teacherName))
                {
                    return;
                }
                if (this.zipFile != null && storage != null && !string.IsNullOrEmpty(storage.CatalogID) && !string.IsNullOrEmpty(storage.ClassID) &&
                    (storage.Student != null) && !string.IsNullOrEmpty(storage.Student.StudentID))
                {
                    LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(this.teacherID, storage.CatalogID, storage.ClassID);
                    #region 初始化数据。
                    if (store == null)
                    {
                        store = new LocalStudentWorkStore();
                        store.TeacherID = this.teacherID;
                        store.TeacherName = this.teacherName;

                        store.GradeID = storage.GradeID;
                        store.GradeName = null;

                        store.CatalogID = storage.CatalogID;
                        store.CatalogName = storage.CatalogName;

                        store.ClassID = storage.ClassID;
                        store.ClassName = null;

                        store.Evaluate = null;
                    }
                    #endregion

                    if (store.Students == null)
                    {
                        store.Students = new LocalStudents();
                    }

                    LocalStudent ls = store.Students[storage.Student.StudentID];
                    if (ls == null)
                    {
                        ls = new LocalStudent();
                        ls.StudentID = storage.Student.StudentID;
                        ls.StudentCode = storage.Student.StudentCode;
                        ls.StudentName = storage.Student.StudentName;
                        store.Students.Add(ls);
                    }

                    if (ls.Work == null) ls.Work = new LocalStudentWork();
                    ls.Work.WorkID = storage.WorkID;
                    ls.Work.WorkName = storage.WorkName;
                    ls.Work.UploadIP = storage.UploadIP;
                    ls.Work.Type = storage.Type;
                    ls.Work.Time = storage.Time;
                    ls.Work.Status = storage.Status;
                    if (storage.Review != null)
                    {
                        ls.Work.Review = new LocalWorkReview();
                        ls.Work.Review.ReviewValue = storage.Review.ReviewValue;
                        ls.Work.Review.SubjectiveReviews = storage.Review.SubjectiveReviews;
                        ls.Work.Review.TeacherID = storage.Review.TeacherID;
                        ls.Work.Review.TeacherName = storage.Review.TeacherName;
                    }
                    ls.Work.FileExt = storage.FileExt;
                    ls.Work.Description = storage.Description;
                    //ls.Work.CheckCode = storage.CheckCode;

                    this.RaiseChanged(handler, string.Format("导入[{0},{1}]作品数据...", ls.StudentName, ls.StudentCode));
                    if (this.isImportFile && !string.IsNullOrEmpty(storage.WorkPath))
                    {
                        //导入文件。
                        ls.Work.WorkFiles = new LocalStudentWorkFiles();
                        this.ImportWorkFiles(storage.WorkPath, store, ls, ls.Work, handler);
                    }
                    //序列化保存。
                    WorkStoreHelper.Serializer(ref store);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipWorkPath"></param>
        /// <param name="store"></param>
        /// <param name="ls"></param>
        /// <param name="lsw"></param>
        /// <param name="handler"></param>
        private void ImportWorkFiles(string zipWorkPath, LocalStudentWorkStore store, LocalStudent ls, LocalStudentWork lsw, RaiseChangedHandler handler)
        {
            if (this.zipFile != null && !string.IsNullOrEmpty(zipWorkPath))
            {
                Stream stream = stream = ZipUtils.ZipFileData(this.zipFile, zipWorkPath);
                if (stream != null)
                {
                    if (string.Equals(Path.GetExtension(zipWorkPath), ".zip", StringComparison.InvariantCultureIgnoreCase))
                    {
                        #region 压缩文件解压。
                        using (ZipInputStream zipStream = new ZipInputStream(stream))
                        {
                            if (zipStream == null)
                            {
                                return;
                            }
                            ZipEntry entry = null;
                            while ((entry = zipStream.GetNextEntry()) != null)
                            {
                                if (entry != null && entry.IsFile && !string.IsNullOrEmpty(entry.Name))
                                {
                                    LocalStudentWorkFile lswf = new LocalStudentWorkFile();
                                    lswf.FileID = string.Format("{0}", Guid.NewGuid()).Replace("-", string.Empty);
                                    lswf.FileExt = Path.GetExtension(entry.Name);
                                    lswf.FileName = Path.GetFileNameWithoutExtension(entry.Name);
                                    if (string.IsNullOrEmpty(lsw.FileExt))
                                    {
                                        lsw.FileExt = lswf.FileExt;
                                    }
                                    else if (lsw.FileExt.IndexOf(lswf.FileExt) == -1)
                                    {
                                        lsw.FileExt += "|" + lswf.FileExt;
                                    }
                                    lswf.Size = entry.Size;
                                    lsw.WorkFiles.Add(lswf);
                                    this.RaiseChanged(handler, string.Format("导入作品{0}{1}...", lswf.FileName, lswf.FileExt));
                                    using (FileStream fs = new FileStream(lsw.StudentWorkFilePath(store, ls, lswf), FileMode.Create, FileAccess.Write))
                                    {
                                        byte[] buf = new byte[512];
                                        int len = 0;
                                        while ((len = zipStream.Read(buf, 0, buf.Length)) > 0)
                                        {
                                            fs.Write(buf, 0, len);
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region 导入单独文件。
                        LocalStudentWorkFile lswf = new LocalStudentWorkFile();
                        lswf.FileID = string.Format("{0}", Guid.NewGuid()).Replace("-", string.Empty);
                        lswf.FileName = lsw.WorkName;
                        lswf.FileExt = Path.GetExtension(zipWorkPath);
                        if (string.IsNullOrEmpty(lsw.FileExt))
                        {
                            lsw.FileExt = lswf.FileExt;
                        }
                        else if (lsw.FileExt.IndexOf(lswf.FileExt) == -1)
                        {
                            lsw.FileExt += "|" + lswf.FileExt;
                        }
                        lswf.Size = stream.Length;
                        lsw.WorkFiles.Add(lswf);
                        this.RaiseChanged(handler, string.Format("导入作品{0}{1}...", lswf.FileName, lswf.FileExt));
                        using (FileStream fs = new FileStream(lsw.StudentWorkFilePath(store, ls, lswf), FileMode.Create, FileAccess.Write))
                        {
                            byte[] buf = new byte[512];
                            StreamUtils.Copy(stream, fs, buf);
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        void RaiseChanged(RaiseChangedHandler handler, string message)
        {
            if (handler != null)
            {
                handler(message);
            }
        }
        #endregion
    }
}
