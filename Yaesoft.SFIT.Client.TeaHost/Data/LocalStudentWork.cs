//================================================================================
//  FileName: LocalStudentWork.cs
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
using System.Collections.Generic;
using System.Text;
using System.IO;
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 学生作品接口。
    /// </summary>
    public interface IStudentWork
    {
        /// <summary>
        /// 获取或设置作品ID。
        /// </summary>
        string WorkID { get; set; }
        /// <summary>
        /// 获取或设置作品名称。
        /// </summary>
        string WorkName { get; set; }
        /// <summary>
        /// 获取或设置作品状态。
        /// </summary>
        EnumWorkStatus Status { get; set; }
        /// <summary>
        /// 获取或设置作品类型。
        /// </summary>
        EnumWorkType Type { get; set; }
        /// <summary>
        /// 获取或设置处理时间。
        /// </summary>
        DateTime Time { get; set; }
        /// <summary>
        /// 获取或设置作品描述。
        /// </summary>
        CDATA Description { get; set; }
        /// <summary>
        /// 获取或设置作品评阅。
        /// </summary>
        LocalWorkReview Review { get; set; }
    }
    /// <summary>
    /// 本地学生作品。
    /// </summary>
    [Serializable]
    public class LocalStudentWork : IStudentWork
    {
        #region 构造函数。
        /// <summary>
        ///  构造函数。
        /// </summary>
        public LocalStudentWork()
        {
            this.Status = EnumWorkStatus.Recive;
            this.Type = EnumWorkType.Public;
            this.Time = DateTime.Now;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置作品ID。
        /// </summary>
        public string WorkID { get; set; }
        /// <summary>
        /// 获取或设置作品名称。
        /// </summary>
        public string WorkName { get; set; }
        /// <summary>
        /// 获取或设置作品文件集合。
        /// </summary>
        public LocalStudentWorkFiles WorkFiles { get; set; }
        /// <summary>
        /// 获取或设置文件扩展名(多个扩展名用|分隔)。
        /// </summary>
        public string FileExt { get; set; }
        /// <summary>
        /// 获取或设置上传IP地址。
        /// </summary>
        public string UploadIP { get; set; }
        /// <summary>
        /// 获取或设置作品状态。
        /// </summary>
        public EnumWorkStatus Status { get; set; }
        /// <summary>
        /// 获取或设置作品类型。
        /// </summary>
        public EnumWorkType Type { get; set; }
        /// <summary>
        /// 获取或设置处理时间。
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 获取或设置作品描述。
        /// </summary>
        public CDATA Description { get; set; }
        /// <summary>
        /// 获取或设置作品评阅。
        /// </summary>
        public LocalWorkReview Review { get; set; }
        #endregion

        #region 函数。
        /// <summary>
        /// 保存数据。
        /// </summary>
        /// <param name="store">学生作品存储。</param>
        /// <param name="ls">学生信息。</param>
        /// <param name="files">文件数据。</param>
        public void SaveFiles(LocalStudentWorkStore store, LocalStudent ls, StudentWorkFiles files)
        {
            if (store != null && ls != null && files != null && files.Count > 0)
            {
                if (this.WorkFiles == null)
                    this.WorkFiles = new LocalStudentWorkFiles();
                else
                    this.WorkFiles.Clear();
                for (int i = 0; i < files.Count; i++)
                {
                    StudentWorkFile swf = files[i];
                    if (swf.Data != null && swf.Data.Length > 0)
                    {
                        LocalStudentWorkFile file = new LocalStudentWorkFile();
                        file.FileID = swf.FileID;
                        file.FileName = Path.GetFileNameWithoutExtension(swf.FileName);
                        file.FileExt = swf.FileExt;
                        file.Size = swf.Size > 0 ? swf.Size : swf.Data.Length;

                        if (this.FileExt == null)
                            this.FileExt = file.FileExt;
                        else if (this.FileExt.IndexOf(file.FileExt) == -1)
                            this.FileExt += string.Format("|{0}", file.FileExt);

                        string path = this.StudentWorkFilePath(store, ls, file);
                        if (!string.IsNullOrEmpty(path))
                        {
                            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                            {
                                fs.Write(swf.Data, 0, swf.Data.Length);
                            }
                            this.WorkFiles.Add(file);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 删除作业文件。
        /// </summary>
        /// <param name="store"></param>
        /// <param name="ls"></param>
        public bool DeleteFiles(LocalStudentWorkStore store, LocalStudent ls)
        {
            if (store == null || ls == null) return false;
            if (this.WorkFiles == null || this.WorkFiles.Count == 0) return true;
            for (int i = 0; i < this.WorkFiles.Count; i++)
            {
                try
                {
                    string path = this.StudentWorkFilePath(store, ls, this.WorkFiles[i]);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        this.WorkFiles.Remove(this.WorkFiles[i]);
                    }
                }
                catch (Exception e)
                {
                    UtilTools.OnExceptionRecord(e, this.GetType());
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 获取学生作品路径。
        /// </summary>
        /// <param name="store"></param>
        /// <param name="ls"></param>
        /// <param name="workFile"></param>
        /// <returns></returns>
        public string StudentWorkFilePath(LocalStudentWorkStore store, LocalStudent ls, LocalStudentWorkFile workFile)
        {
            if (store != null && ls != null && workFile != null)
            {
                string rootDir = store.RootDir();
                if (!string.IsNullOrEmpty(rootDir) && Directory.Exists(rootDir))
                {
                    string dir = Path.GetFullPath(string.Format("{0}/{1}", rootDir, ls.StudentID));
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    return Path.GetFullPath(string.Format("{0}/{1}{2}", dir, workFile.FileID, workFile.FileExt));
                }
            }
            return null;
        }
        #endregion
    }
}