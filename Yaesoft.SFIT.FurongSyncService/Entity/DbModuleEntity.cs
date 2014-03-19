//================================================================================
//  FileName: DbModuleEntity.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-4-18
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
using iPower.Data;
using iPower.Data.ORM;
using iPower.WinService.Logs;
namespace Yaesoft.SFIT.FurongSyncService.Entity
{
    /// <summary>
    /// 实体操作类。
    /// </summary>
    internal class DbModuleEntity<T> : ORMDbEntity<T>
        where T : new()
    {
        #region 构造函数。
        private IDBAccess access;
        private WinServiceLog log;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access"></param>
        /// <param name="log"></param>
        public DbModuleEntity(IDBAccess access,WinServiceLog log)
        {
            this.access = access;
            this.log = log;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 创建数据访问接口。
        /// </summary>
        /// <returns></returns>
        protected override IDBAccess CreateDBAccess()
        {
            return this.access;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <param name="logContent"></param>
        protected override void OnDbEntityDataChangeLogHandler(string head, string logContent)
        {
            if (this.log != null)
            {
                this.log.ContentLog(head + "#" + logContent);
            }
        }
        #endregion
    }
}