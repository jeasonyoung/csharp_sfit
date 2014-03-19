//================================================================================
// FileName: SFITGroupStudents.cs
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
	///tblSFITGroupStudents映射类。
	///</summary>
	[DbTable("tblSFITGroupStudents")]
	public class SFITGroupStudents
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITGroupStudents()
		{

		}
		#endregion
		#region 属性。
		///<summary>
		///获取或设置GroupID。
		///</summary>
		[DbField("GroupID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	GroupID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置StudentID。
		///</summary>
		[DbField("StudentID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	StudentID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置StudentCode。
		///</summary>
		[DbField("StudentCode")]
		public	string	StudentCode
		{
			get;set;

		}
			
		///<summary>
		///获取或设置StudentName。
		///</summary>
		[DbField("StudentName")]
		public	string	StudentName
		{
			get;set;

		}
			
		#endregion

	}

}
