//================================================================================
// FileName: SFITCatalogKnowledgePoints.cs
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
	///tblSFITCatalogKnowledgePointsӳ���ࡣ
	///</summary>
	[DbTable("tblSFITCatalogKnowledgePoints")]
	public class SFITCatalogKnowledgePoints
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITCatalogKnowledgePoints()
		{

		}
		#endregion
		#region ���ԡ�
		///<summary>
		///��ȡ������CatalogID��
		///</summary>
		[DbField("CatalogID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	CatalogID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������PointID��
		///</summary>
		[DbField("PointID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	PointID
		{
			get;set;

		}
			
		#endregion

	}

}
