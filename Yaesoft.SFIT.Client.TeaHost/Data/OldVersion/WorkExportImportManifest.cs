//================================================================================
//  FileName: WorkExportImportManifest.cs
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

using Yaesoft.SFIT;
namespace Yaesoft.SFIT.Client.TeaHost.Data.OldVersion
{
    /// <summary>
    /// 旧版本导出导入清单。
    /// </summary>
    [Serializable, Obsolete("旧版本导出导入清单，新版本中将不在使用！")]
    public class WorkExportImportManifest
    {
        /// <summary>
        /// 获取或设置版本信息。
        /// </summary>
        public string Ver { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public StudentWorkTeaStorages Storages { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable,Obsolete("不再使用的类！")]
    public class StudentWorkTeaStorage
    {
        /// <summary>
        /// 获取或设置作业ID。
        /// </summary>
        public string WorkID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WorkName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GradeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClassID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CatalogID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CatalogName { get; set; }
        /// <summary>
        /// 获取或设置文件扩展名(多个扩展名用|分隔)。
        /// </summary>
        public string FileExt { get; set; }
        /// <summary>
        /// 获取或设置上传IP地址。
        /// </summary>
        public string UploadIP { get; set; }
        /// <summary>
        /// 获取或设置作品校验码。
        /// </summary>
        public string CheckCode { get; set; }
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
        public string Description { get; set; }
        /// <summary>
        /// 获取或设置作品评阅。
        /// </summary>
        public TeacherReview Review { get; set; }
        /// <summary>
        /// 获取或设置学生信息。
        /// </summary>
        public Student Student { get; set; }
        /// <summary>
        /// 获取或设置文件路径。
        /// </summary>
        public string WorkPath { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable, Obsolete("不再使用的类！")]
    public class StudentWorkTeaStorages : BaseCollection<StudentWorkTeaStorage>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        public override StudentWorkTeaStorage this[string workID]
        {
            get
            {
                if (!string.IsNullOrEmpty(workID))
                {
                    StudentWorkTeaStorage data = this.Items.Find(new Predicate<StudentWorkTeaStorage>(delegate(StudentWorkTeaStorage sender)
                    {
                        return (sender != null) && sender.WorkID == workID;
                    }));
                    return data;
                }
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(StudentWorkTeaStorage x, StudentWorkTeaStorage y)
        {
            return DateTime.Compare(x.Time, y.Time);
        }
    }
}
