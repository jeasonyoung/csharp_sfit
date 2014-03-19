//================================================================================
//  FileName: ClassStudent.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-4-19
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
using iPower;
using iPower.Data;
using iPower.Data.ORM;
using iPower.WinService.Logs;
namespace Yaesoft.SFIT.FurongSyncService.Entity
{
    /// <summary>
    /// 班级学生。
    /// </summary>
    [DbTable("tblSFITClassStudents")]
    internal class ClassStudent
    {
        ///<summary>
        ///获取或设置班级ID。
        ///</summary>
        [DbField("ClassID", DbFieldUsage.PrimaryKey)]
        public GUIDEx ClassID { get; set; }
         ///<summary>
        ///获取或设置学生ID。
        ///</summary>
        [DbField("StudentID", DbFieldUsage.PrimaryKey)]
        public GUIDEx StudentID { get; set; }
         ///<summary>
        ///获取或设置同步时间。
        ///</summary>
        [DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime LastSyncTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("ClassID:{0},StudentID:{1},LastSyncTime:{2:yyyy-MM-dd HH:mm:ss}",
                this.ClassID, this.StudentID, this.LastSyncTime);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    internal class ClassStudentEntity : DbModuleEntity<ClassStudent>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access"></param>
        /// <param name="log"></param>
        public ClassStudentEntity(IDBAccess access, WinServiceLog log)
            : base(access, log)
        {
        }
        /// <summary>
        /// 删除班级下关联的所有学生。
        /// </summary>
        /// <param name="classID"></param>
        public int DeleteClassStudents(GUIDEx classID)
        {
            return this.DatabaseAccess.ExecuteNonQuery(string.Format("delete from {0} where ClassID='{1}'", this.TableName, classID));
        }
    }
}