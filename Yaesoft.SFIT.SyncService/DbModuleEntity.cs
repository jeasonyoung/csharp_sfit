//================================================================================
//  FileName: DbModuleEntity.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-01-05 
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//  2012-12-12
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Text;

using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.SFIT.SyncService
{
    /// <summary>
    /// 数据实体基础类。
    /// </summary>
    internal class DbModuleEntity<T> : ORMDbEntity<T>
        where T : new()
    {
        #region 构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DbModuleEntity()
        {
        }
        #endregion

        /// <summary>
        /// 创建数据访问接口。
        /// </summary>
        /// <returns></returns>
        protected override IDBAccess CreateDBAccess()
        {
            return ModuleConfiguration.ModuleConfig.ModuleDefaultDatabase;
        }
    }
}