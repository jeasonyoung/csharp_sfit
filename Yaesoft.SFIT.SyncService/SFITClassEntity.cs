//================================================================================
// FileName: SFITClassEntity.cs
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
    ///tblSFITClass映射类。
    ///</summary>
    [DbTable("tblSFITClass")]
    internal class SFITClass
    {
        #region 属性。
        ///<summary>
        ///获取或设置ClassID。
        ///</summary>
        [DbField("ClassID", DbFieldUsage.PrimaryKey)]
        public GUIDEx ClassID
        {
            get;
            set;

        }
        ///<summary>
        ///获取或设置ClassCode。
        ///</summary>
        [DbField("ClassCode", DbFieldUsage.UniqueKey)]
        public string ClassCode
        {
            get;
            set;

        }
        ///<summary>
        ///获取或设置ClassName。
        ///</summary>
        [DbField("ClassName")]
        public string ClassName
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
        ///获取或设置SchoolID。
        ///</summary>
        [DbField("SchoolID")]
        public GUIDEx SchoolID
        {
            get;
            set;

        }
        /// <summary>
        /// 获取或设置入学年份。
        /// </summary>
        [DbField("JoinYear")]
        public int JoinYear
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置当前年级。
        /// </summary>
        [DbField("GradeValue")]
        public int GradeValue
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置学习阶段。
        /// </summary>
        [DbField("LearnLevel")]
        public int LearnLevel
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
        [DbField("LastSyncTime")]
        public DateTime LastSyncTime
        {
            get;
            set;

        }
        #endregion
    }
	///<summary>
	///SFITClassEntity实体类。
	///</summary>
	internal class SFITClassEntity: DbModuleEntity<SFITClass>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITClassEntity()
		{

		}
		#endregion
        
        #region 数据操作。
        /// <summary>
        /// 根据班级代码获取班级ID。
        /// </summary>
        /// <param name="classCode"></param>
        /// <returns></returns>
        public GUIDEx GetClassIDByCode(GUIDEx classCode)
        {
            const string sql = "select ClassID from {0} where ClassCode = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, classCode));
            return obj == null ? GUIDEx.Null : new GUIDEx(obj);
        }
        /// <summary>
        /// 获取允许同步的学校下的班级。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <returns></returns>
        public List<SFITClass> LoadAllowSyncData(GUIDEx schoolID)
        {
            return this.LoadRecord(string.Format("(SyncStatus <> 0x00) and (SchoolID = '{0}')", schoolID));
        }
         /// <summary>
        /// 获取学校下的班级。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <returns></returns>
        public List<SFITClass> LoadAllData(GUIDEx schoolID)
        {
            return this.LoadRecord(string.Format("SchoolID = '{0}'", schoolID));
        }
        #endregion
    }
}