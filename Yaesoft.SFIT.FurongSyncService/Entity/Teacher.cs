//================================================================================
//  FileName: Teacher.cs
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
    /// 教师映射。
    /// </summary>
    [DbTable("tblSFITeachers")]
    internal class Teacher
    {
        ///<summary>
        ///获取或设置TeacherID。
        ///</summary>
        [DbField("TeacherID", DbFieldUsage.PrimaryKey)]
        public GUIDEx TeaID { get; set; }
        ///<summary>
        ///获取或设置TeacherCode。
        ///</summary>
        [DbField("TeacherCode")]
        public string TeaCode { get; set; }
        ///<summary>
        ///获取或设置TeacherName。
        ///</summary>
        [DbField("TeacherName")]
        public string TeaName { get; set; }
        ///<summary>
        ///获取或设置SchoolID。
        ///</summary>
        [DbField("SchoolID")]
        public GUIDEx UnitID { get; set; }
        ///<summary>
        ///获取或设置SyncStatus。
        ///</summary>
        [DbField("SyncStatus")]
        public int SyncStatus { get; set; }
         ///<summary>
        ///获取或设置LastSyncTime。
        ///</summary>
        [DbField("LastSyncTime")]
        public DateTime LastSyncTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("TeaID:{0},TeaCode:{1},TeaName:{2},UnitID:{3},SyncStatus:{4},LastSyncTime:{5:yyyy-MM-dd HH:mm:ss}", 
                this.TeaID, this.TeaCode, this.TeaName, this.UnitID, this.SyncStatus, this.LastSyncTime);
        }
    }
    /// <summary>
    /// 教师映射实体。
    /// </summary>
    internal class TeachersEntity : DbModuleEntity<Teacher>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access"></param>
        /// <param name="log"></param>
        public TeachersEntity(IDBAccess access, WinServiceLog log)
            : base(access, log)
        {
        }

        /// <summary>
        /// 获取教师ID。
        /// </summary>
        /// <param name="teaCode"></param>
        /// <returns></returns>
        public GUIDEx LoadTeaID(string teaCode)
        {
            const string sql = "select top 1 TeacherID from {0} where TeacherCode = '{1}'";
            if (!string.IsNullOrEmpty(teaCode))
            {
                object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, teaCode));
                if (obj != null)
                {
                    return new GUIDEx(obj);
                }
            }
            return GUIDEx.Null;
        }
    }
}