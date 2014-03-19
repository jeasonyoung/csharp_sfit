//================================================================================
// FileName: SFITClassStudents.cs
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
	///班级学生映射类。
	///</summary>
	[DbTable("tblSFITClassStudents")]
	public class SFITClassStudents
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITClassStudents()
		{

		}
		#endregion

		#region 属性。
        ///<summary>
        ///获取或设置班级ID。
        ///</summary>
        [DbField("ClassID", DbFieldUsage.PrimaryKey)]
        public GUIDEx ClassID
        {
            get;
            set;
        }
		///<summary>
		///获取或设置学生ID。
		///</summary>
		[DbField("StudentID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	StudentID
		{
			get;
            set;
		}
        ///<summary>
        ///获取或设置同步时间。
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
