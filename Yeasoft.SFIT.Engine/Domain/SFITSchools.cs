//================================================================================
// FileName: SFITSchools.cs
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
	///tblSFITSchoolsӳ���ࡣ
	///</summary>
	[DbTable("tblSFITSchools")]
	public class SFITSchools
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITSchools()
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
		///��ȡ������SchoolCode��
		///</summary>
		[DbField("SchoolCode")]
		public	string	SchoolCode
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������SchoolName��
		///</summary>
		[DbField("SchoolName")]
		public	string	SchoolName
		{
			get;set;

		}

        /// <summary>
        /// 
        /// </summary>
        [DbField("SchoolType")]
        public int SchoolType
        {
            get;
            set;
        }
			
		///<summary>
		///��ȡ������OrderNO��
		///</summary>
		[DbField("OrderNO")]
		public	int	OrderNO
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������SyncStatus��
		///</summary>
		[DbField("SyncStatus")]
		public	int	SyncStatus
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������LastSyncTime��
		///</summary>
		[DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
		public	DateTime	LastSyncTime
		{
			get;set;

		}
			
		#endregion
	}

}
