//================================================================================
// FileName: SFITGroupStudents.cs
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
	///tblSFITGroupStudentsӳ���ࡣ
	///</summary>
	[DbTable("tblSFITGroupStudents")]
	public class SFITGroupStudents
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITGroupStudents()
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
		///��ȡ������StudentID��
		///</summary>
		[DbField("StudentID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	StudentID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������StudentCode��
		///</summary>
		[DbField("StudentCode")]
		public	string	StudentCode
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������StudentName��
		///</summary>
		[DbField("StudentName")]
		public	string	StudentName
		{
			get;set;

		}
			
		#endregion

	}

}
