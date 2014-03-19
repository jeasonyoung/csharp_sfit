//================================================================================
//  FileName: UtilTools.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-30
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
using System.Security.Cryptography;
using System.Xml.Serialization;
namespace Yaesoft.SFIT.Client.AutoUpdate.Utils
{
    /// <summary>
    /// 工具类。
    /// </summary>
    internal static class UtilTools
    {
        /// <summary>
        /// 序列化对象到文件。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="path"></param>
        public static void Serializer<T>(T data, string path)
            where T : class
        {
            lock (typeof(T))
            {
                if (data != null && !string.IsNullOrEmpty(path))
                {
                    path = Path.GetFullPath(path);
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));
                        ser.Serialize(fs, data);
                    }
                }
            }
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T DeSerializer<T>(string path)
            where T : class
        {
            lock (typeof(T))
            {
                T result = default(T);
                if (File.Exists(path))
                {
                    try
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                        {
                            XmlSerializer ser = new XmlSerializer(typeof(T));
                            result = ser.Deserialize(fs) as T;
                        }
                    }
                    catch (System.Xml.XmlException)
                    {
                        File.Delete(path);
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// 生成校验码。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Checksum(byte[] source)
        {
            if (source != null && source.Length > 0)
            {
                byte[] result = null;
                using (HashAlgorithm hash = HashAlgorithm.Create())
                {
                    result = hash.ComputeHash(source);
                    hash.Clear();
                }
                return UtilTools.ConvertToX2(result);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Checksum(Stream stream)
        {
            if (stream != null)
            {
                byte[] result = null;
                using (HashAlgorithm hash = HashAlgorithm.Create())
                {
                    result = hash.ComputeHash(stream);
                    hash.Clear();
                }
                return UtilTools.ConvertToX2(result);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static string ConvertToX2(byte[] data)
        {
            string result = string.Empty;
            if (data != null && data.Length > 0)
            {
                foreach (byte b in data)
                {
                    result += string.Format("{0:X2}", b);
                }
            }
            return result;
        }
    }
}
