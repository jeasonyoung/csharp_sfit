//================================================================================
//  FileName: SyncEmployee.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/25
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

using Yaesoft.SFIT;
namespace Yaesoft.SFIT.DataSync
{
    /// <summary>
    /// 同步用户信息。
    /// </summary>
    public class SyncEmployee
    {
        #region 成员变量，构造函数。
        SyncUnit syncUnit = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public SyncEmployee()
        {
            this.syncUnit = new SyncUnit();
        }
        #endregion

        /// <summary>
        /// 获取或设置用户ID。
        /// </summary>
        public string EmployeeID { get; set; }
        /// <summary>
        /// 获取或设置用户代码（用户名）。
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// 获取或设置用户名称。
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 获取或设置所属单位。
        /// </summary>
        public SyncUnit Unit
        {
            get { return this.syncUnit; }
            set { this.syncUnit = value; }
        }
    }
    /// <summary>
    /// 同步用户信息集合。
    /// </summary>
    public class SyncEmployees : BaseCollection<SyncEmployee>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public override SyncEmployee this[string employeeCode]
        {
            get
            {
                SyncEmployee data = this.Items.Find(new Predicate<SyncEmployee>(delegate(SyncEmployee sender)
                {
                    return (sender != null) && (sender.EmployeeCode == employeeCode);
                }));
                return data;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(SyncEmployee x, SyncEmployee y)
        {
            return string.Compare(x.EmployeeName, y.EmployeeName);
        }
    }
}