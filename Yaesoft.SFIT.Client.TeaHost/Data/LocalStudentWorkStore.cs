//================================================================================
//  FileName: LocalStudentWorkStore.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-16
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

using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.TeaHost.Utils;
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 本地学生作品存储。
    /// </summary>
    [Serializable]
    public class LocalStudentWorkStore
    {
        #region 属性。
        /// <summary>
        /// 获取或设置教师ID。
        /// </summary>
        public string TeacherID { get; set; }
        /// <summary>
        /// 获取或设置教师名称。
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 获取或设置年级ID。
        /// </summary>
        public string GradeID { get; set; }
        /// <summary>
        /// 获取或设置年级名称。
        /// </summary>
        public string GradeName { get; set; }
        /// <summary>
        /// 获取或设置目录ID。
        /// </summary>
        public string CatalogID { get; set; }
        /// <summary>
        /// 获取或设置目录名称。
        /// </summary>
        public string CatalogName { get; set; }
        /// <summary>
        /// 获取或设置班级ID。
        /// </summary>
        public string ClassID { get; set; }
        /// <summary>
        /// 获取或设置班级名称。
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 获取或设置客观评价。
        /// </summary>
        public Evaluate Evaluate { get; set; }
        /// <summary>
        /// 获取或设置学生信息。
        /// </summary>
        public LocalStudents Students { get; set; }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 获取有作业数据的学生集合。
        /// </summary>
        /// <returns></returns>
        public LocalStudents HasWorks()
        {
            if (this.Students != null && this.Students.Count > 0)
            {
                LocalStudents stus = new LocalStudents();
                for (int i = 0; i < this.Students.Count; i++)
                {
                    LocalStudent ls = this.Students[i];
                    if (ls != null && ls.HasWork())
                    {
                        stus.Add(ls);
                    }
                }
                stus.Sort();
                return stus;
            }
            return null;
        }
        /// <summary>
        /// 导出所有学生作品数据。
        /// </summary>
        /// <param name="target">目标目录。</param>
        /// <param name="Changed">消息处理。</param>
        public void OutputAllWorkFiles(string target, RaiseChangedHandler changed)
        {
            lock (this)
            {
                int len = 0;
                if (this.Students != null && (len = this.Students.Count) > 0)
                {
                    for(int i = 0; i < len; i++)
                    {
                        LocalStudent ls = this.Students[i];
                        this.OutputWorkFile(ls.StudentID, target, changed);
                    }
                }
            }
        }
        /// <summary>
        /// 导出学生作品文件。
        /// </summary>
        /// <param name="studentID">学生ID。</param>
        /// <param name="target">目标目录。</param>
        /// <param name="changed"></param>
        /// <returns>导出作品目录。</returns>
        public string OutputWorkFile(string studentID, string target, RaiseChangedHandler changed)
        {
            lock (this)
            {
                if (!string.IsNullOrEmpty(studentID) && !string.IsNullOrEmpty(target))
                {
                    string targetDir = Path.GetFullPath(string.Format("{0}/{1}/{2}/{3}", target, this.TeacherName, this.CatalogName, this.ClassName));
                    if (!Directory.Exists(targetDir))
                    {
                        this.OnChanged(changed, "创建目录：" + targetDir);
                        Directory.CreateDirectory(targetDir);
                    }
                    if (this.Students != null && this.Students.Count > 0)
                    {
                        LocalStudent ls = this.Students[studentID];
                        if (ls != null && ls.HasWork())
                        {
                            #region 创建导出目录。
                            string targetRoot = Path.GetFullPath(string.Format("{0}/{1}", targetDir, ls.StudentName));
                            if (!Directory.Exists(targetRoot))
                            {
                                Directory.CreateDirectory(targetRoot);
                                this.OnChanged(changed, "创建目录：" + ls.StudentName);
                            }
                            else
                            {
                                try
                                {
                                    //删除目录下的文件。
                                    string[] files = Directory.GetFiles(targetRoot, "*.*");
                                    if (files != null && files.Length > 0)
                                    {
                                        for (int k = 0; k < files.Length; k++)
                                        {
                                            if (File.Exists(files[k]))
                                            {
                                                File.Delete(files[k]);
                                            }
                                        }
                                    }
                                }
                                catch (Exception) { }
                            }
                            #endregion
 
                            #region 作业。
                            int fcount = 0;
                            if (ls.Work.WorkFiles != null && (fcount = ls.Work.WorkFiles.Count) > 0)
                            {
                                for(int i = 0; i < fcount; i++)
                                {
                                    #region 作业数据。
                                    LocalStudentWorkFile f = ls.Work.WorkFiles[i];
                                    string sourcePath = ls.Work.StudentWorkFilePath(this, ls, f);
                                    if (File.Exists(sourcePath))
                                    {
                                        try
                                        {
                                            string targetPath = Path.GetFullPath(string.Format("{0}/{1}{2}", targetRoot, f.FileName, f.FileExt));
                                            using (FileStream source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                                            {
                                                using (FileStream output = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                                                {
                                                    this.OnChanged(changed, "开始创建文件：" + f.FileName);
                                                    byte[] buf = new byte[512];
                                                    int len = 0;
                                                    while ((len = source.Read(buf, 0, buf.Length)) > 0)
                                                    {
                                                        output.Write(buf, 0, len);
                                                    }
                                                    this.OnChanged(changed, "创建文件：" + f.FileName + "完成");
                                                }
                                            }
                                        }
                                        catch (Exception x)
                                        {
                                            this.OnChanged(changed, "创建文件[" + f.FileName + "]时发生异常：" + x.Message);
                                            Program.GlobalExceptionHandler(x);
                                        }
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                             
                            return targetRoot;
                        }
                    }
                }
                return null;
            }
        }
        ///// <summary>
        ///// 清理冗余作品。
        ///// </summary>
        ///// <param name="changed"></param>
        //public bool ClearWorks(RaiseChangedHandler changed)
        //{
        //    lock (this)
        //    {
        //        bool result = false;
        //        try
        //        {
        //            if (this.Students != null && this.Students.Count > 0)
        //            {
        //                Hashtable htCache = Hashtable.Synchronized(new Hashtable());
        //                for (int i = 0; i < this.Students.Count; i++)
        //                {
        //                    LocalStudent ls = this.Students[i];
        //                    if (ls != null && ls.Works != null && ls.Works.Count > 0)
        //                    {
        //                        #region 剔除重复学生。
        //                        if (htCache.ContainsKey(ls.StudentID))
        //                        {
        //                            result = true;
        //                            LocalStudent old = ((object[])htCache[ls.StudentID])[0] as LocalStudent;
        //                            if (old.Works != null && old.Works.Count > 0)
        //                            {
        //                                if (ls.Works != null && ls.Works.Count > 0)
        //                                {
        //                                    if (ls.Works[0].Time < old.Works[0].Time)
        //                                    {
        //                                        this.OnChanged(changed, string.Format("清理{0}的冗余作品", ls.StudentName));
        //                                        this.Students.Remove(i);
        //                                        continue;
        //                                    }
        //                                    else
        //                                    {
        //                                        this.OnChanged(changed, string.Format("清理{0}的冗余作品", old.StudentName));
        //                                        this.Students.Remove((int)(((object[])htCache[ls.StudentID])[1]));
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    this.OnChanged(changed, string.Format("清理{0}的冗余作品", ls.StudentName));
        //                                    this.Students.Remove(i);
        //                                    continue;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                this.OnChanged(changed, string.Format("清理{0}的冗余作品", old.StudentName));
        //                                this.Students.Remove((int)(((object[])htCache[ls.StudentID])[1]));
        //                            }
        //                        }
        //                        #endregion

        //                        #region 剔除冗余作业。
        //                        if (ls.Works != null && ls.Works.Count > 1)
        //                        {
        //                            ls.Works.Sort();
        //                            LocalStudentWork lsw = ls.Works[0];
        //                            if (lsw != null)
        //                            {
        //                                this.OnChanged(changed, string.Format("清理{0}的冗余作品,保留作品:{1}", ls.StudentName, lsw.WorkName));
        //                                ls.Works = new LocalStudentWorks();
        //                                ls.Works.Add(lsw);
        //                                result = true;
        //                            }
        //                        }
        //                        #endregion
        //                        //缓存数据。
        //                        htCache[ls.StudentID] = new object[] { ls, i };
        //                    }
        //                }
        //            }
        //            if (result)
        //            {
        //                this.Serializer();
        //            }
        //            this.OnChanged(changed, "清理完毕！");
        //        }
        //        catch (Exception x)
        //        {
        //            this.OnChanged(changed, string.Format("清理发生异常：{0}", x.Message));
        //        }
        //        return result;
        //    }
        //}
        /// <summary>
        /// 消息处理。
        /// </summary>
        /// <param name="changed"></param>
        /// <param name="message"></param>
        private void OnChanged(RaiseChangedHandler changed, string message)
        {
            if (changed != null)
            {
                changed(message);
            }
        }
        #endregion

        #region 查询数据。
        /// <summary>
        /// 查询学生作品。
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="workName"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public LocalStudents FindWorks(string studentName,string workName, EnumWorkStatus status)
        {
            if (this.Students != null && this.Students.Count > 0)
            {
                LocalStudents students = this.Students.FindStudents(studentName);
                if (students != null && students.Count > 0)
                {
                    students = students.FindStudents(workName, status);
                }
                return students;
            }
            return null;
        }
        #endregion

        #region 序列化处理函数。
        /// <summary>
        /// 获取文件根目录。
        /// </summary>
        /// <returns></returns>
        public string RootDir()
        {
            if (string.IsNullOrEmpty(this.TeacherID) || string.IsNullOrEmpty(this.CatalogID) || string.IsNullOrEmpty(this.ClassID))
            {
                return string.Empty;
            }
            string dir = Path.GetFullPath(string.Format("{0}/{1}_{2}", FolderStructure.GetUserDataRoot(this.TeacherID), this.ClassID, this.CatalogID));
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }
        /// <summary>
        /// 文件保存路径。
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="catalogID"></param>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static string SavePath(string teacherID, string catalogID, string classID)
        {
             string path = Path.GetFullPath(string.Format("{0}/{1}_{2}/TSW_{1}_{2}.cfg.xml", FolderStructure.GetUserDataRoot(teacherID), classID, catalogID));
             if (!File.Exists(path))
             {
                 string dir = Path.GetDirectoryName(path);
                 if (!Directory.Exists(dir))
                 {
                     Directory.CreateDirectory(dir);
                 }
             }
             return path;
        }
        /// <summary>
        /// 获取作业存储文件唯一标示。
        /// </summary>
        /// <returns></returns>
        public string StoreKeyID()
        {
            return this.TeacherID + "_" + this.CatalogID + "_" + this.ClassID;
        }
        /// <summary>
        /// 文件保存路径。
        /// </summary>
        /// <returns></returns>
        public string FileSavePath()
        {
            return SavePath(this.TeacherID, this.CatalogID, this.ClassID);
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <param name="teacherID">教师ID。</param>
        /// <param name="catalogID">科目ID。</param>
        /// <param name="classID">班级ID。</param>
        /// <returns></returns>
        public static LocalStudentWorkStore DeSerializer(string teacherID, string catalogID, string classID)
        {
            return DeSerializer(SavePath(teacherID, catalogID, classID));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static LocalStudentWorkStore DeSerializer(string filepath)
        {
            if (string.IsNullOrEmpty(filepath)) return null;
            if (File.Exists(filepath))
            {
                return UtilTools.DeSerializer<LocalStudentWorkStore>(filepath);
            }
            return null;
        }
        #endregion
    }
}