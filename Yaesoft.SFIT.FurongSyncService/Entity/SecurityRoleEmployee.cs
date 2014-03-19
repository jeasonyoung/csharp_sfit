//================================================================================
//  FileName: SecurityRoleEmployee.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-4-19
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.SFIT.FurongSyncService.Entity
{
    /// <summary>
    /// 角色用户授权。
    /// </summary>
    [DbTable("tblSecurityRoleEmployee")]
    internal class SecurityRoleEmployee
    {
        ///<summary>
        ///获取或设置RoleID。
        ///</summary>
        [DbField("RoleID", DbFieldUsage.PrimaryKey)]
        public GUIDEx RoleID { get; set; }
        ///<summary>
        ///获取或设置EmployeeID。
        ///</summary>
        [DbField("EmployeeID", DbFieldUsage.PrimaryKey)]
        public GUIDEx EmployeeID { get; set; }
        ///<summary>
        ///获取或设置EmployeeName。
        ///</summary>
        [DbField("EmployeeName")]
        public string EmployeeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("RoleID:{0},EmployeeID:{1},EmployeeName:{2}", this.RoleID, this.EmployeeID, this.EmployeeName);
        }
    }
}