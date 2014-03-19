//================================================================================
//  FileName: ModuleConfiguration.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/2
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

using iPower;
using iPower.Configuration;

using Yaesoft.SFIT;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.Furong
{
    /// <summary>
    /// 模块配置键。
    /// </summary>
    internal class ModuleConfigurationKeys : iPowerConfigurationKeys
    {
        /// <summary>
        /// 获取同步数据接口URL地址键名。
        /// </summary>
        public const string SyncDataServiceUrlKey = "SyncDataServiceUrl";
        /// <summary>
        /// 获取同步数据接口用户键名。
        /// </summary>
        public const string SyncDataServiceUsernameKey = "SyncDataServiceUsername";
        /// <summary>
        /// 获取同步数据接口用户密码键名。
        /// </summary>
        public const string SyncDataServicePasswordKey = "SyncDataServicePassword";
        /// <summary>
        /// 获取教师登陆验证接口URL地址键名。
        /// </summary>
        public const string TeaLoginServiceUrlKey = "TeaLoginServiceUrl";
        /// <summary>
        /// 获取教师登陆验证接口用户键名。
        /// </summary>
        public const string TeaLoginServiceUsernameKey = "TeaLoginServiceUsername";
        /// <summary>
        /// 获取教师登陆验证接口密码键名。
        /// </summary>
        public const string TeaLoginServicePasswordKey = "TeaLoginServicePassword";
        /// <summary>
        /// 获取用户信息程序集键名。
        /// </summary>
        public const string GetUserInfoAssemblyKey = "GetUserInfoAssembly";
    }
    /// <summary>
    /// 模块配置。
    /// </summary>
    internal class ModuleConfiguration : iPowerConfiguration
    {
        #region 成员变量，构造函数。
        static Hashtable Cache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 构造函数。
        /// </summary>
        private ModuleConfiguration()
            : base("Furong")
        {
        }
        #endregion

        #region 静态函数。
        static ModuleConfiguration m_config;
        /// <summary>
        /// 获取静态实例。
        /// </summary>
        public static ModuleConfiguration ModuleConfig
        {
            get
            {
                lock (typeof(ModuleConfiguration))
                {
                    if (m_config == null)
                        m_config = new ModuleConfiguration();
                    return m_config;
                }
            }
        }
        #endregion

        /// <summary>
        /// 获取数据同步服务配置。
        /// </summary>
        public ServicePoxyAccount SyncDataService
        {
            get
            {
                lock (this)
                {
                    ServicePoxyAccount sp = Cache["SyncDataService"] as ServicePoxyAccount;
                    if (sp == null)
                    {
                        sp = new ServicePoxyAccount();
                        sp.Url = this[ModuleConfigurationKeys.SyncDataServiceUrlKey];
                        sp.Username = this[ModuleConfigurationKeys.SyncDataServiceUsernameKey];
                        sp.Password = this[ModuleConfigurationKeys.SyncDataServicePasswordKey];
                        if (!string.IsNullOrEmpty(sp.Url))
                        {
                            Cache["SyncDataService"] = sp;
                        }
                    }
                    return sp;
                }
            }
        }
        /// <summary>
        /// 获取教师登陆服务配置。
        /// </summary>
        public ServicePoxyAccount TeaLoginService
        {
            get
            {
                lock (this)
                {
                    ServicePoxyAccount sp = Cache["TeaLoginService"] as ServicePoxyAccount;
                    if (sp == null)
                    {
                        sp = new ServicePoxyAccount();
                        sp.Url = this[ModuleConfigurationKeys.TeaLoginServiceUrlKey];
                        sp.Username = this[ModuleConfigurationKeys.TeaLoginServiceUsernameKey];
                        sp.Password = this[ModuleConfigurationKeys.TeaLoginServicePasswordKey];
                        if (!string.IsNullOrEmpty(sp.Url))
                        {
                            Cache["TeaLoginService"] = sp;
                        }
                    }
                    return sp;
                }
            }
        }
        /// <summary>
        /// 获取用户信息程序集。
        /// </summary>
        public IGetUserInfo GetUserInfoAssembly
        {
            get
            {
                IGetUserInfo info = Cache["GetUserInfoAssembly"] as IGetUserInfo;
                if (info == null)
                {
                    string assembly = this[ModuleConfigurationKeys.GetUserInfoAssemblyKey];
                    if (!string.IsNullOrEmpty(assembly))
                    {
                        info = iPower.Utility.TypeHelper.Create(assembly) as IGetUserInfo;
                        if (info != null)
                        {
                            Cache["GetUserInfoAssembly"] = info;
                        }
                    }
                }
                return info;
            }
        }
    }
}