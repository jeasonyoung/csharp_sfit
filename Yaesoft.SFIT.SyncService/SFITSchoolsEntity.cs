//================================================================================
// FileName: SFITSchoolsEntity.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;

using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.SFIT.SyncService
{
    ///<summary>
    ///tblSFITSchools映射类。
    ///</summary>
    [DbTable("tblSFITSchools")]
    internal class SFITSchools
    {
        #region 属性。
        ///<summary>
        ///获取或设置SchoolID。
        ///</summary>
        [DbField("SchoolID", DbFieldUsage.PrimaryKey)]
        public GUIDEx SchoolID
        {
            get;
            set;

        }

        ///<summary>
        ///获取或设置SchoolCode。
        ///</summary>
        [DbField("SchoolCode", DbFieldUsage.UniqueKey)]
        public string SchoolCode
        {
            get;
            set;

        }

        ///<summary>
        ///获取或设置SchoolName。
        ///</summary>
        [DbField("SchoolName")]
        public string SchoolName
        {
            get;
            set;

        }

        ///<summary>
        ///获取或设置SchoolType。
        ///</summary>
        [DbField("SchoolType")]
        public int SchoolType
        {
            get;
            set;

        }

        ///<summary>
        ///获取或设置OrderNO。
        ///</summary>
        [DbField("OrderNO")]
        public int OrderNO
        {
            get;
            set;

        }

        ///<summary>
        ///获取或设置SyncStatus。
        ///</summary>
        [DbField("SyncStatus")]
        public int SyncStatus
        {
            get;
            set;

        }

        ///<summary>
        ///获取或设置LastSyncTime。
        ///</summary>
        [DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime LastSyncTime
        {
            get;
            set;

        }

        #endregion
    }
	///<summary>
	///SFITSchoolsEntity实体类。
	///</summary>
	internal class SFITSchoolsEntity: DbModuleEntity<SFITSchools>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITSchoolsEntity()
		{

		}
		#endregion

        #region 数据操作。
        /// <summary>
        /// 根据学校代码获取学校编号。
        /// </summary>
        /// <param name="schoolCode"></param>
        /// <returns></returns>
        public GUIDEx GetSchoolID(string schoolCode)
        {
            const string sql = "select SchoolID from {0} where SchoolCode = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, schoolCode));
            return obj == null ? GUIDEx.Null : new GUIDEx(obj);
        }
        /// <summary>
        /// 加载全部同步数据。
        /// </summary>
        /// <returns></returns>
        public List<SFITSchools> LoadAllowSyncData()
        {
            return this.LoadRecord("SyncStatus <> 0x00");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SFITSchools> LoadNotAllowSyncData()
        {
            return this.LoadRecord("SyncStatus = 0x00");
        }
        #endregion
    }
}