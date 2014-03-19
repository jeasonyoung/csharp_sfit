//================================================================================
//  FileName: JobConfiguration.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using iPower.Data;
using iPower.Data.DataAccess;
using iPower.WinService.Jobs;
using iPower.Utility;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.SFIT.FurongSyncService
{
    /// <summary>
    /// 
    /// </summary>
    internal class SyncJobConfigurationKeys : JobConfigurationKey
    {
        /// <summary>
        /// 数据同步接口代理程序集。
        /// </summary>
        public const string DataSyncPoxyAssemblyKey = "DataSyncPoxyAssembly";
        /// <summary>
        /// 学生用户角色ID。
        /// </summary>
        public const string StudentUserRoleIDKey = "StudentUserRoleID";
    }
    /// <summary>
    /// 
    /// </summary>
    public class SyncJobConfigurations:JobConfiguration
    {
        #region 成员变量，构造函数。
        static Hashtable cache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 
        /// </summary>
        public SyncJobConfigurations()
            : base("SFITSyncService")
        {
        }
        #endregion

        /// <summary>
        /// 获取学生用户角色ID。
        /// </summary>
        public string StudentUserRoleID
        {
            get { return this[SyncJobConfigurationKeys.StudentUserRoleIDKey]; }
        }
        /// <summary>
        /// 获取学校类型映射转换。
        /// </summary>
        internal Maps.Converts UnitTypeConverts
        {
            get
            {
                return Utils.DeSerializationFromResources<Maps.Converts>("Yaesoft.SFIT.FurongSyncService.Maps.SchoolTypeConvert.xml");
            }
        }
        /// <summary>
        /// 获取年级值映射转换。
        /// </summary>
        internal Maps.Converts GradeValueConverts
        { 
            get
            {
                return Utils.DeSerializationFromResources<Maps.Converts>("Yaesoft.SFIT.FurongSyncService.Maps.GradeValueConvert.xml");
            }
        }
        /// <summary>
        /// 获取数据同步接口代理工厂。
        /// </summary>
        public IDataSync DataSyncPoxyFactory
        {
            get
            {
                IDataSync sync = cache[typeof(IDataSync)] as IDataSync;
                if (sync == null)
                {
                    sync = TypeHelper.Create(this[SyncJobConfigurationKeys.DataSyncPoxyAssemblyKey]) as IDataSync;
                    if (sync != null)
                    {
                        cache[typeof(IDataSync)] = sync;
                    }
                }
                return sync;
            }
        }
        /// <summary>
        /// 默认数据连接。
        /// </summary>
        public IDBAccess ModuleDefaultDatabase
        {
            get
            {
                if (this.DefaultDataConnectionString != null)
                {
                    return DatabaseFactory.Instance(this.DefaultDataConnectionString);
                }
                return null;
            }
        }
    }
}