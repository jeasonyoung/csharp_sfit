//================================================================================
// FileName: SFITGroupCatalog.cs
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
	///tblSFITGroupCatalogӳ���ࡣ
	///</summary>
	[DbTable("tblSFITGroupCatalog")]
	public class SFITGroupCatalog
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITGroupCatalog()
		{

		}
		#endregion
		#region ���ԡ�
		///<summary>
		///��ȡ������GroupID��
		///</summary>
		[DbField("GroupID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	GroupID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������CatalogID��
		///</summary>
		[DbField("CatalogID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	CatalogID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������CatalogName��
		///</summary>
		[DbField("CatalogName")]
		public	string	CatalogName
		{
			get;set;

		}
			
		#endregion

	}

}
