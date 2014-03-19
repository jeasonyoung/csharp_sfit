//================================================================================
//  FileName: StudentWorkFile.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/26
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

namespace Yaesoft.SFIT
{
    /// <summary>
    /// 学生作品文件。
    /// </summary>
    [Serializable]
    public class StudentWorkFile
    {
        /// <summary>
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
        /// 获取或设置内容类型。
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 获取或设置文件大小（字节）。
        /// </summary>
        public double Size { get; set; }
        /// <summary>
        /// 获取或设置文件数据偏移量。
        /// </summary>
        public long OffSet { get; set; }
        /// <summary>
        /// 获取或设置文件数据。
        /// </summary>
        public byte[] Data { get; set; }
    }
    /// <summary>
    /// 学生作品文件集合。
    /// </summary>
    [Serializable]
    public class StudentWorkFiles : BaseCollection<StudentWorkFile>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public override StudentWorkFile this[string fileName]
        {
            get
            {
                StudentWorkFile file = this.Items.Find(new Predicate<StudentWorkFile>(delegate(StudentWorkFile sender)
                {
                    return (sender != null) && string.Equals(sender.FileName, fileName);
                }));
                return file;
            }
        }
        /// <summary>
        /// 获取所有的文件大小(M)。
        /// </summary>
        /// <returns></returns>
        public float FileSizeCount()
        {
            float count = 0;
            int len = 0;
            if ((len = this.Count) > 0)
            {
                for (int i = 0; i < len; i++)
                {
                    StudentWorkFile swf = this[i];
                    if (swf != null && swf.Size > 0)
                    {
                        count += (float)swf.Size;
                    }
                }
                if (count > 0)
                {
                    count = (count / 1024 / 1024);
                }
            }
            return count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(StudentWorkFile x, StudentWorkFile y)
        {
            return string.Compare(x.FileName, y.FileName);
        }
    }
}