//================================================================================
//  FileName: Student.cs
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
    /// 学生信息映射类。
    /// </summary>
    [DbTable("tblSFITStudents")]
    internal class Student
    {
        ///<summary>
        ///获取或设置学生ID。
        ///</summary>
        [DbField("StudentID", DbFieldUsage.PrimaryKey)]
        public GUIDEx StudentID { get; set; }
        ///<summary>
        ///获取或设置学生学号。
        ///</summary>
        [DbField("StudentCode", DbFieldUsage.UniqueKey)]
        public string StudentCode { get; set; }
        ///<summary>
        ///获取或设置姓名。
        ///</summary>
        [DbField("StudentName")]
        public string StudentName { get; set; }
        /// <summary>
        /// 获取或设置性别。
        /// </summary>
        [DbField("Gender")]
        public int Gender { get; set; }
        /// <summary>
        /// 获取或设置入学年份。
        /// </summary>
        [DbField("JoinYear")]
        public int JoinYear { get; set; }
        /// <summary>
        /// 获取或设置身份证号。
        /// </summary>
        [DbField("IDNumber")]
        public string IDNumber { get; set; }
        ///<summary>
        ///获取或设置SyncStatus。
        ///</summary>
        [DbField("SyncStatus")]
        public int SyncStatus { get; set; }
        ///<summary>
        ///获取或设置LastSyncTime。
        ///</summary>
        [DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime LastSyncTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("StudentID:{0},StudentCode:{1},StudentName:{2},Gender:{3},JoinYear:{4}",
                    this.StudentID, this.StudentCode, this.StudentName, this.Gender, this.JoinYear);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    internal class StudentsEntity : DbModuleEntity<Student>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access"></param>
        /// <param name="log"></param>
        public StudentsEntity(IDBAccess access, WinServiceLog log)
            : base(access, log)
        {
        }
        /// <summary>
        /// 根据学号获取学生代码。
        /// </summary>
        /// <param name="stuCode"></param>
        /// <returns></returns>
        public GUIDEx LoadStudentIDByCode(string stuCode)
        {
            const string sql = "select StudentID from {0} where StudentCode = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, stuCode));
            return obj == null ? GUIDEx.Null : new GUIDEx(obj);
        }
    }
}
