//================================================================================
// FileName: SFITeachers.cs
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
	///tblSFITeachers映射类。
	///</summary>
	[DbTable("tblSFITeachers")]
	public class SFITeachers
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITeachers()
		{

		}
		#endregion

		#region 属性。
		///<summary>
		///获取或设置TeacherID。
		///</summary>
		[DbField("TeacherID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	TeacherID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置TeacherCode。
		///</summary>
		[DbField("TeacherCode")]
		public	string	TeacherCode
		{
			get;set;

		}
			
		///<summary>
		///获取或设置TeacherName。
		///</summary>
		[DbField("TeacherName")]
		public	string	TeacherName
		{
			get;set;

		}
			
		///<summary>
		///获取或设置SchoolID。
		///</summary>
		[DbField("SchoolID")]
		public	GUIDEx	SchoolID
		{
			get;set;

		}

        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        public string SchoolName
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
			get;set;

		}
			
		///<summary>
		///获取或设置LastSyncTime。
		///</summary>
		[DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
		public	DateTime	LastSyncTime
		{
			get;set;

		}
			
		#endregion

	}

}
