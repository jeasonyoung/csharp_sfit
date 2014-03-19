//================================================================================
// FileName: SecurityRoleEmployeeEntity.cs
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
using System.Collections.Specialized;
using System.Text;
using System.Data;

using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.SFIT.SyncService
{
    ///<summary>
    ///tblSecurityRoleEmployee映射类。
    ///</summary>
    [DbTable("tblSecurityRoleEmployee")]
    internal class SecurityRoleEmployee
    {
        #region 属性。
        ///<summary>
        ///获取或设置RoleID。
        ///</summary>
        [DbField("RoleID", DbFieldUsage.PrimaryKey)]
        public GUIDEx RoleID
        {
            get;
            set;

        }

        ///<summary>
        ///获取或设置EmployeeID。
        ///</summary>
        [DbField("EmployeeID", DbFieldUsage.PrimaryKey)]
        public GUIDEx EmployeeID
        {
            get;
            set;

        }

        ///<summary>
        ///获取或设置EmployeeName。
        ///</summary>
        [DbField("EmployeeName")]
        public string EmployeeName
        {
            get;
            set;

        }

        #endregion
    }
	///<summary>
	///SecurityRoleEmployeeEntity实体类。
	///</summary>
	internal class SecurityRoleEmployeeEntity: DbModuleEntity<SecurityRoleEmployee>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SecurityRoleEmployeeEntity()
		{

		}
		#endregion
	}
}