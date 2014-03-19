//================================================================================
//  FileName: ModuleConfiguration.cs
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
using iPower.Utility;
using iPower.Data.DataAccess;
using iPower.Configuration;
using iPower.WinService.Jobs;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.SFIT.SyncService
{
    /// <summary>
    /// 模块配置键名。
    /// </summary>
    internal class ModuleConfigurationKeys : JobConfigurationKey
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
    /// 模块配置类。
    /// </summary>
    public class ModuleConfiguration : JobConfiguration
    {
        #region 成员变量，构造函数。
        static Hashtable cache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ModuleConfiguration()
            : base("SFITSyncService")
        {

        }
        #endregion

        #region 静态实例。
        static ModuleConfiguration mconfig;
        /// <summary>
        /// 获取静态实例。
        /// </summary>
        public static ModuleConfiguration ModuleConfig
        {
            get
            {
                lock (typeof(ModuleConfiguration))
                {
                    if (mconfig == null)
                        mconfig = new ModuleConfiguration();
                    return mconfig;
                }
            }
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取学生用户角色ID。
        /// </summary>
        public string StudentUserRoleID
        {
            get { return this[ModuleConfigurationKeys.StudentUserRoleIDKey]; }
        }
        /// <summary>
        /// 获取学校类型转换.
        /// </summary>
        public Maps.Converts SchoolTypeConverts
        {
            get { return Maps.Converts.DeSerializeInstance("Yaesoft.SFIT.SyncService.Maps.SchoolTypeConvert.xml"); }
        }
        /// <summary>
        /// 获取年级值转换.
        /// </summary>
        public Maps.Converts GradeValueConverts
        {
            get { return Maps.Converts.DeSerializeInstance("Yaesoft.SFIT.SyncService.Maps.GradeValueConvert.xml"); }
        }
        /// <summary>
        /// 获取数据同步接口代理工厂。
        /// </summary>
        public IDataSync DataSyncPoxyFactory
        {
            get
            {
                lock (this)
                {
                    IDataSync sync = null;
                    string assembly = this[ModuleConfigurationKeys.DataSyncPoxyAssemblyKey];
                    if (!string.IsNullOrEmpty(assembly))
                    {
                        string key = iPower.Cryptography.HashCrypto.Hash(assembly, "md5");
                        sync = cache[key] as IDataSync;
                        if (sync == null)
                        {
                            sync = TypeHelper.Create(assembly) as IDataSync;
                            if (sync != null)
                            {
                                cache[key] = sync;
                            }
                        }
                    }
                    return sync;
                }
            }
        }
        /// <summary>
        /// 默认数据连接。
        /// </summary>
        public IDBAccess ModuleDefaultDatabase
        {
            get
            {
                lock (this)
                {
                    ConnectionStringConfiguration conn = this.DefaultDataConnectionString;
                    if (conn == null)
                        return null;
                    return DatabaseFactory.Instance(conn);
                }
            }
        }
        #endregion
    }
}