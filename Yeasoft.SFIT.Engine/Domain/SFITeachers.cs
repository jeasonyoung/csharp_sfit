//================================================================================
// FileName: SFITeachers.cs
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
	///tblSFITeachersӳ���ࡣ
	///</summary>
	[DbTable("tblSFITeachers")]
	public class SFITeachers
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITeachers()
		{

		}
		#endregion

		#region ���ԡ�
		///<summary>
		///��ȡ������TeacherID��
		///</summary>
		[DbField("TeacherID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	TeacherID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������TeacherCode��
		///</summary>
		[DbField("TeacherCode")]
		public	string	TeacherCode
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������TeacherName��
		///</summary>
		[DbField("TeacherName")]
		public	string	TeacherName
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������SchoolID��
		///</summary>
		[DbField("SchoolID")]
		public	GUIDEx	SchoolID
		{
			get;set;

		}

        /// <summary>
        /// ��ȡ������ѧУ���ơ�
        /// </summary>
        public string SchoolName
        {
            get;
            set;
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
