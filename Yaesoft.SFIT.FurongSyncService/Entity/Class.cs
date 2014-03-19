//================================================================================
//  FileName: Class.cs
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
    /// 班级映射。
    /// </summary>
    [DbTable("tblSFITClass")]
    internal class Class
    {
         ///<summary>
        ///获取或设置ClassID。
        ///</summary>
        [DbField("ClassID", DbFieldUsage.PrimaryKey)]
        public GUIDEx ClassID { get; set; }
         ///<summary>
        ///获取或设置ClassCode。
        ///</summary>
        [DbField("ClassCode", DbFieldUsage.UniqueKey)]
        public string ClassCode { get; set; }
         ///<summary>
        ///获取或设置ClassName。
        ///</summary>
        [DbField("ClassName")]
        public string ClassName { get; set; }
        ///<summary>
        ///获取或设置OrderNO。
        ///</summary>
        [DbField("OrderNO")]
        public int OrderNO { get; set; }
        ///<summary>
        ///获取或设置SchoolID。
        ///</summary>
        [DbField("SchoolID")]
        public GUIDEx UnitID { get; set; }
         /// <summary>
        /// 获取或设置入学年份。
        /// </summary>
        [DbField("JoinYear")]
        public int JoinYear { get; set; }
        /// <summary>
        /// 获取或设置当前年级。
        /// </summary>
        [DbField("GradeValue")]
        public int GradeValue { get; set; }
         /// <summary>
        /// 获取或设置学习阶段。
        /// </summary>
        [DbField("LearnLevel")]
        public int LearnLevel { get; set; }
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
            return string.Format("ClassID:{0},ClassCode:{1},ClassName:{2},UnitID:{3}",
                this.ClassID, this.ClassCode, this.ClassName, this.UnitID);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    internal class ClassesEntity : DbModuleEntity<Class>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access"></param>
        /// <param name="log"></param>
        public ClassesEntity(IDBAccess access, WinServiceLog log)
            : base(access, log)
        {
        }
        /// <summary>
        /// 根据班级代码获取班级ID。
        /// </summary>
        /// <param name="classCode"></param>
        /// <returns></returns>
        public GUIDEx LoadClassIDByCode(GUIDEx classCode)
        {
            const string sql = "select ClassID from {0} where ClassCode = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, classCode));
            return obj == null ? GUIDEx.Null : new GUIDEx(obj);
        }
        /// <summary>
        /// 获取允许同步的学校下的班级。
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public List<Class> LoadAllowSyncData(GUIDEx unitID)
        {
            return this.LoadRecord(string.Format("(SyncStatus <> 0x00) and (SchoolID = '{0}')", unitID));
        }
        /// <summary>
        /// 获取学校下的班级。
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public List<Class> LoadAllData(GUIDEx unitID)
        {
            return this.LoadRecord(string.Format("SchoolID = '{0}'", unitID));
        }
    }
}