//================================================================================
// FileName: SecurityRoleEmployeeEntity.cs
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
using System.Collections.Specialized;
using System.Text;
using System.Data;
	
using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SecurityRoleEmployeeEntityʵ���ࡣ
	///</summary>
	internal class SecurityRoleEmployeeEntity: DbModuleEntity<SecurityRoleEmployee>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯��
		///</summary>
		public SecurityRoleEmployeeEntity()
		{

		}
		#endregion

        /// <summary>
        /// ����ɾ���ον�ʦ�û���
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public bool BatchDeleteTeaClassUser(string[] teacherID)
        {
            return this.DeleteRecord(string.Format("RoleID = '{0}' and (EmployeeID in ('{1}'))", this.ModuleConfig.TeaClassRoleID, string.Join("','", teacherID)));
        }
	}

}
