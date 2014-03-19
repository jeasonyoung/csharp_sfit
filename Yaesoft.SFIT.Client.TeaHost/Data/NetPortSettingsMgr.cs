//================================================================================
//  FileName: PortSettingsMgr.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/2
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
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 网络端口配置文件。
    /// </summary>
    public static class NetPortSettingsMgr
    {
        /// <summary>
        /// 序列化。
        /// </summary>
        /// <param name="conf"></param>
        public static void Serializer(PortSettings data)
        {
            if (data != null)
            {
                string path = FolderStructure.NetPortSettingsFile;
                UtilTools.Serializer<PortSettings>(data, path);
            }
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <returns></returns>
        public static PortSettings DeSerializer()
        {
            string path = FolderStructure.NetPortSettingsFile;
            PortSettings cfg = UtilTools.DeSerializer<PortSettings>(path);
            if (cfg == null)
                cfg = new PortSettings();
            return cfg;
        }

    }
}
