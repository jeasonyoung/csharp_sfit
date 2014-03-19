//================================================================================
// FileName: SFITStudents.cs
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
using System.Text;
	
using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.SFIT.Engine.Domain
{
	///<summary>
	///学生信息映射类。
	///</summary>
	[DbTable("tblSFITStudents")]
	public class SFITStudents
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITStudents()
		{

		}
		#endregion

		#region 属性。
        /// <summary>
        /// 获取或设置学校ID。
        /// </summary>
        public GUIDEx SchoolID
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        public string SchoolName
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置年级ID。
        /// </summary>
        public GUIDEx GradeID
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置班级ID。
        /// </summary>
        public GUIDEx ClassID
        {
            get;
            set;
        }
		///<summary>
		///获取或设置学生ID。
		///</summary>
        [DbField("StudentID", DbFieldUsage.PrimaryKey)]
        public GUIDEx StudentID
        {
            get;
            set;
        }
 		///<summary>
		///获取或设置学生学号。
		///</summary>
        [DbField("StudentCode")]
        public string StudentCode
        {
            get;
            set;
        }
 		///<summary>
		///获取或设置姓名。
		///</summary>
        [DbField("StudentName")]
        public string StudentName
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置性别。
        /// </summary>
        [DbField("Gender")]
        public int Gender
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
        /// 获取或设置身份证号。
        /// </summary>
        [DbField("IDNumber")]
        public string IDNumber
        {
            get;
            set;
        }
 		///<summary>
		///获取或设置SyncStatus。
		///</summary>
		[DbField("SyncStatus")]
		public	int	SyncStatus
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
}
