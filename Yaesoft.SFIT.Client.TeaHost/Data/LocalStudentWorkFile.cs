//================================================================================
//  FileName: LocalStudentWorkFile.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-17
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
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 本地学生文件记录。
    /// </summary>
    [Serializable]
    public class LocalStudentWorkFile
    {
        // <summary>
        /// 获取或设置文件ID。
        /// </summary>
        public string FileID { get; set; }
        /// <summary>
        /// 获取或设置文件名称。
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 获取或设置文件扩展。
        /// </summary>
        public string FileExt { get; set; }
        /// <summary>
        /// 获取或设置文件大小（字节）。
        /// </summary>
        public double Size { get; set; }
    }
    /// <summary>
    /// 本地学生文件记录集合。
    /// </summary>
    [Serializable]
    public class LocalStudentWorkFiles : BaseCollection<LocalStudentWorkFile>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public override LocalStudentWorkFile this[string fileID]
        {
            get
            {
                LocalStudentWorkFile result = this.Items.Find(new Predicate<LocalStudentWorkFile>(delegate(LocalStudentWorkFile sender)
                {
                    return (sender != null) && (sender.FileID == fileID);
                }));
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(LocalStudentWorkFile x, LocalStudentWorkFile y)
        {
            return String.Compare(x.FileName, y.FileName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public LocalStudentWorkFile FindWorkFile(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                LocalStudentWorkFile result = this.Items.Find(new Predicate<LocalStudentWorkFile>(delegate(LocalStudentWorkFile sender)
                {
                    return (sender != null) && (sender.FileName.IndexOf(fileName) > -1);
                }));
                return result;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public LocalStudentWorkFile FindWorkFileID(string fileID)
        {
            if (!string.IsNullOrEmpty(fileID))
            {
                LocalStudentWorkFile result = this.Items.Find(new Predicate<LocalStudentWorkFile>(delegate(LocalStudentWorkFile sender)
                {
                    return (sender != null) && (sender.FileID == fileID);
                }));
                return result;
            }
            return null;
        }
    }
}