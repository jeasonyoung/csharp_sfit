//================================================================================
// FileName: SFITCatalogKnowledgePoints.cs
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
	///tblSFITCatalogKnowledgePoints映射类。
	///</summary>
	[DbTable("tblSFITCatalogKnowledgePoints")]
	public class SFITCatalogKnowledgePoints
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITCatalogKnowledgePoints()
		{

		}
		#endregion
		#region 属性。
		///<summary>
		///获取或设置CatalogID。
		///</summary>
		[DbField("CatalogID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	CatalogID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置PointID。
		///</summary>
		[DbField("PointID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	PointID
		{
			get;set;

		}
			
		#endregion

	}

}
