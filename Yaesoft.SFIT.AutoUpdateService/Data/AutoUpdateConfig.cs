//================================================================================
//  FileName: AutoUpdateConfig.cs
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
using System.IO;
using System.Xml.Serialization;
namespace Yaesoft.SFIT.AutoUpdateService.Data
{
    /// <summary>
    /// 自动更新配置。
    /// </summary>
    [Serializable]
    public class AutoUpdateConfig
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public AutoUpdateConfig()
        {
            this.Title = "自动更新服务器配置文件";
            this.Versions = new AutoUpdateVersions();
        }
        #endregion

        /// <summary>
        /// 获取或设置配置文件名称。
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 获取或设置更新版本。
        /// </summary>
        public AutoUpdateVersions Versions { get; set; }

        #region 序列化与反序列化。
        /// <summary>
        /// 序列化。
        /// </summary>
        /// <param name="path"></param>
        public void Serializer(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(AutoUpdateConfig));
                    ser.Serialize(fs, this);
                }
            }
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AutoUpdateConfig DeSerializer(string path)
        {
            AutoUpdateConfig result = null;
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(AutoUpdateConfig));
                    result = ser.Deserialize(fs) as AutoUpdateConfig;
                }
            }
            return result;
        }
        #endregion
    }
}