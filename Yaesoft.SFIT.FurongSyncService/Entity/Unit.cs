//================================================================================
//  FileName: Unit.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-4-18
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
    /// 学校单位。
    /// </summary>
    [DbTable("tblSFITSchools")]
    internal class Unit
    {
        ///<summary>
        ///获取或设置SchoolID。
        ///</summary>
        [DbField("SchoolID", DbFieldUsage.PrimaryKey)]
        public GUIDEx UnitID { get; set; }
        ///<summary>
        ///获取或设置SchoolCode。
        ///</summary>
        [DbField("SchoolCode")]
        public string UnitCode { get; set; }
        ///<summary>
        ///获取或设置SchoolName。
        ///</summary>
        [DbField("SchoolName")]
        public string UnitName { get; set; }
        ///<summary>
        ///获取或设置SchoolType。
        ///</summary>
        [DbField("SchoolType")]
        public int SchoolType { get; set; }
        ///<summary>
        ///获取或设置OrderNO。
        ///</summary>
        [DbField("OrderNO")]
        public int OrderNO { get; set; }
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
            return string.Format("UnitID:{0},UnitCode:{1},UnitName:{2},SchoolType:{3},OrderNO:{4},SyncStatus:{5},LastSyncTime:{6:yyyy-MM-dd:HH:mm:ss}",
                    this.UnitID, this.UnitCode, this.UnitName, this.SchoolType, this.OrderNO, this.SyncStatus, this.LastSyncTime);
        }
    }
    /// <summary>
    /// 学校单位操作。
    /// </summary>
    internal class UnitsEntity : DbModuleEntity<Unit>
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="access"></param>
        /// <param name="log"></param>
        public UnitsEntity(IDBAccess access, WinServiceLog log)
            : base(access, log)
        {
        }

        /// <summary>
        /// 根据学校代码获取学校编号。
        /// </summary>
        /// <param name="unitCode"></param>
        /// <returns></returns>
        public GUIDEx LoadUnitID(string unitCode)
        {
            const string sql = "select SchoolID from {0} where SchoolCode = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, unitCode));
            return obj == null ? GUIDEx.Null : new GUIDEx(obj);
        }
        /// <summary>
        /// 加载全部同步数据。
        /// </summary>
        /// <returns></returns>
        public List<Unit> LoadAllowSyncData()
        {
            return this.LoadRecord("SyncStatus <> 0x00");
        }
        /// <summary>
        /// 加载全部不允许同步数据。
        /// </summary>
        /// <returns></returns>
        public List<Unit> LoadNotAllowSyncData()
        {
            return this.LoadRecord("SyncStatus = 0x00");
        }
    }
}