//================================================================================
//  FileName: PluginsConfig.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/29
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
using System.IO;
using System.Xml.Serialization;
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.Client.Plugins
{
    /// <summary>
    /// 插件配置。
    /// </summary>
    [Serializable]
    [XmlRoot("Plug-in")]
    public class PluginsConfiguration
    {
        #region 成员变量，构造函数。
        PluginCfgs pluginCfgs;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public PluginsConfiguration()
        {
            this.pluginCfgs = new PluginCfgs();
        }
        #endregion

        /// <summary>
        /// 获取或设置插件配置集合。
        /// </summary>
        public PluginCfgs Plugins
        {
            get { return this.pluginCfgs; }
            set { this.pluginCfgs = value; }
        }

        #region 序列化与反序列化。
        /// <summary>
        /// 序列化。
        /// </summary>
        /// <param name="conf"></param>
        public static void Serializer(PluginsConfiguration conf)
        {
            if (conf != null)
            {
                string path = Path.GetFullPath(string.Format("{0}\\Plug-in.cfg.xml", AppDomain.CurrentDomain.BaseDirectory));
                UtilTools.Serializer<PluginsConfiguration>(conf, path);
            }
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <returns></returns>
        public static PluginsConfiguration DeSerializer()
        {
            string path = Path.GetFullPath(string.Format("{0}\\Plug-in.cfg.xml", AppDomain.CurrentDomain.BaseDirectory));
            return UtilTools.DeSerializer<PluginsConfiguration>(path);
        }
        #endregion
    }
}
