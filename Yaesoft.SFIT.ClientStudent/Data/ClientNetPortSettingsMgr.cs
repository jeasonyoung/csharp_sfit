//================================================================================
//  FileName: ClientNetPortSettingsMgr.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/17
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
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.ClientStudent.Data
{
    /// <summary>
    /// 客户段端口设置管理类。
    /// </summary>
    public static class ClientNetPortSettingsMgr
    {
        static string path = Path.GetFullPath(string.Format("{0}\\ClientNetPortSettings.xml", AppDomain.CurrentDomain.BaseDirectory));

        /// <summary>
        /// 序列化。
        /// </summary>
        /// <param name="conf"></param>
        public static void Serializer(PortSettings data)
        {
            if (data != null)
                UtilTools.Serializer<PortSettings>(data, path);
        }
         /// <summary>
        /// 反序列化。
        /// </summary>
        /// <returns></returns>
        public static PortSettings DeSerializer()
        {
            PortSettings result = null;
            if (File.Exists(path))
                result = UtilTools.DeSerializer<PortSettings>(path);

            if (result == null)
                result = new PortSettings();
            return result;
        }
    }
}