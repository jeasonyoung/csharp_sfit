//================================================================================
// FileName: SecurityRoleEmployee.cs
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
	///tblSecurityRoleEmployeeӳ���ࡣ
	///</summary>
	[DbTable("tblSecurityRoleEmployee")]
	public class SecurityRoleEmployee
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SecurityRoleEmployee()
		{

		}
		#endregion
		#region ���ԡ�
		///<summary>
		///��ȡ������RoleID��
		///</summary>
		[DbField("RoleID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	RoleID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������EmployeeID��
		///</summary>
		[DbField("EmployeeID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	EmployeeID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������EmployeeName��
		///</summary>
		[DbField("EmployeeName")]
		public	string	EmployeeName
		{
			get;set;

		}
			
		#endregion

	}

}
