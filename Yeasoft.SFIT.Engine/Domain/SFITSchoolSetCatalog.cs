//================================================================================
// FileName: SFITSchoolSetCatalog.cs
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
	///tblSFITSchoolSetCatalogӳ���ࡣ
	///</summary>
	[DbTable("tblSFITSchoolSetCatalog")]
	public class SFITSchoolSetCatalog
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITSchoolSetCatalog()
		{

		}
		#endregion
		#region ���ԡ�
		///<summary>
		///��ȡ������SchoolID��
		///</summary>
		[DbField("SchoolID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	SchoolID
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
		///��ȡ������StartTime��
		///</summary>
		[DbField("StartTime")]
		public	DateTime	StartTime
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������EndTime��
		///</summary>
		[DbField("EndTime")]
		public	DateTime	EndTime
		{
			get;set;

		}
			
		#endregion

	}

}
