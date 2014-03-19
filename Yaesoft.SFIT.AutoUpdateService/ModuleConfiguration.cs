//================================================================================
//  FileName: ModuleConfiguration.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-31
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
using iPower.Configuration;
namespace Yaesoft.SFIT.AutoUpdateService
{
    /// <summary>
    /// 模块配置键。
    /// </summary>
    internal class ModuleConfigurationKeys : iPowerConfigurationKeys
    {
        /// <summary>
        /// 自动更新配置文件路径配置键。
        /// </summary>
        public static string AutoUpdateConfigFileKey = "AutoUpdateConfigFile";
    }
    /// <summary>
    /// 模块配置。
    /// </summary>
    internal class ModuleConfiguration : iPowerConfiguration
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ModuleConfiguration()
            : base("AutoUpdate")
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
        /// 获取自动更新配置文件路径。
        /// </summary>
        public string AutoUpdateConfigFile
        {
            get
            {
                string path = this[ModuleConfigurationKeys.AutoUpdateConfigFileKey];
                return Utils.CalPathToFile(path);
            }
        }
    }
}
