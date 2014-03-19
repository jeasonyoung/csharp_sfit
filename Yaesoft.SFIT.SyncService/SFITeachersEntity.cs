//================================================================================
// FileName: SFITeachersEntity.cs
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
    ///tblSFITeachers映射类。
    ///</summary>
    [DbTable("tblSFITeachers")]
    internal class SFITeachers
    {
        #region 属性。
        ///<summary>
        ///获取或设置TeacherID。
        ///</summary>
        [DbField("TeacherID", DbFieldUsage.PrimaryKey)]
        public GUIDEx TeacherID
        {
            get;
            set;

        }

        ///<summary>
        ///获取或设置TeacherCode。
        ///</summary>
        [DbField("TeacherCode", DbFieldUsage.UniqueKey)]
        public string TeacherCode
        {
            get;
            set;

        }

        ///<summary>
        ///获取或设置TeacherName。
        ///</summary>
        [DbField("TeacherName")]
        public string TeacherName
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
	///SFITeachersEntity实体类。
	///</summary>
	internal class SFITeachersEntity: DbModuleEntity<SFITeachers>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITeachersEntity()
		{

		}
		#endregion

        #region 数据操作。
        /// <summary>
        /// 获取教师ID。
        /// </summary>
        /// <param name="teacherCode"></param>
        /// <returns></returns>
        public GUIDEx GetTeacherID(string teacherCode)
        {
            const string sql = "select TeacherID from {0} where TeacherCode = '{1}'";
            if (!string.IsNullOrEmpty(teacherCode))
            {
                object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, teacherCode));
                if (obj != null)
                    return new GUIDEx(obj);
            }
            return GUIDEx.Null;
        }
        #endregion
    }
}