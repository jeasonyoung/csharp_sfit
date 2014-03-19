//================================================================================
// FileName: SFITGroupCatalog.cs
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
	///tblSFITGroupCatalog映射类。
	///</summary>
	[DbTable("tblSFITGroupCatalog")]
	public class SFITGroupCatalog
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITGroupCatalog()
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
		///获取或设置CatalogID。
		///</summary>
		[DbField("CatalogID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	CatalogID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置CatalogName。
		///</summary>
		[DbField("CatalogName")]
		public	string	CatalogName
		{
			get;set;

		}
			
		#endregion

	}

}
