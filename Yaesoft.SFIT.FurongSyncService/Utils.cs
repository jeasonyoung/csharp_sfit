//================================================================================
//  FileName: Utils.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-9-11
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
using System.Reflection;
using System.Xml.Serialization;
namespace Yaesoft.SFIT.FurongSyncService
{
    /// <summary>
    /// 工具类.
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// 从资源中反序列化对象.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourceFullName"></param>
        /// <returns></returns>
        public static T DeSerializationFromResources<T>(string resourceFullName)
            where T : class, new()
        {
            T result = default(T);
            if (!string.IsNullOrEmpty(resourceFullName))
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceFullName))
                {
                    if (stream != null)
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));
                        result = ser.Deserialize(stream) as T;
                    }
                }
            }
            return result;
        }
    }
}
