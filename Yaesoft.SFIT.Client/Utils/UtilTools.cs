//================================================================================
//  FileName: Utils.cs
//  Desc:工具类。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/10
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
using System.Threading;
using System.Reflection;
using System.Xml.Serialization;
using System.Security.Cryptography;
namespace Yaesoft.SFIT.Client.Utils
{
    /// <summary>
    /// 工具类。
    /// </summary>
    public static class UtilTools
    {
        /// <summary>
        /// 序列化。
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
                    try
                    {
                        path = Path.GetFullPath(path);
                        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                        {
                            XmlSerializer ser = new XmlSerializer(typeof(T));
                            ser.Serialize(fs, data);
                        }
                    }
                    catch (Exception e)
                    {
                        UtilTools.OnExceptionRecord(e, typeof(UtilTools));
                    }
                }
            }
        }
        /// <summary>
        /// 序列化。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Serializer<T>(T data)
            where T : class
        {
            lock (typeof(T))
            {
                byte[] result = null;
                if (data != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        XmlSerializer seri = new XmlSerializer(typeof(T));
                        seri.Serialize(ms, data);
                        result = ms.ToArray();
                    }
                }
                return result;
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
                    catch(System.Xml.XmlException)
                    {
                        File.Delete(path);
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T DeSerializer<T>(Stream stream)
            where T : class
        {
            lock (typeof(T))
            {
                T result = default(T);
                if (stream != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int len = 0;
                        byte[] buf = new byte[512];
                        while ((len = stream.Read(buf, 0, buf.Length)) > 0)
                        {
                            ms.Write(buf, 0, len);
                        }
                        ms.Position = 0;
                        XmlSerializer ser = new XmlSerializer(typeof(T));
                        result = ser.Deserialize(ms) as T;
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DeSerializer<T>(byte[] data)
            where T : class
        {
            lock (typeof(T))
            {
                T result = default(T);
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(data, 0, data.Length);
                    ms.Position = 0;
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    result = ser.Deserialize(ms) as T;
                }
                return result;
            }
        }
        /// <summary>
        /// 反射生成对象。
        /// </summary>
        /// <param name="className">类全名称。</param>
        /// <param name="assemblyName">程序集名称。</param>
        /// <returns></returns>
        public static object Create(string className, string assemblyName)
        {
            if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                if (assembly != null)
                    return assembly.CreateInstance(className);
            }
            return null;
        }
        /// <summary>
        ///  反射生成对象。
        /// </summary>
        /// <param name="classNameAssemblyName">格式（类全名称,程序集名称）</param>
        /// <returns></returns>
        public static object Create(string classNameAssemblyName)
        {
            if (!string.IsNullOrEmpty(classNameAssemblyName))
            {
                string[] strArray = classNameAssemblyName.Split(',');
                return Create(strArray[0], strArray[1]);
            }
            return null;
        }

        /// <summary>
        /// 异常处理记录。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="type"></param>
        public static void OnExceptionRecord(Exception e, Type type)
        {
            if (type == null)
                type = typeof(UtilTools);
            if (e == null)
                return;
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object sender)
            {
                lock (typeof(UtilTools))
                {
                    string path = Path.GetFullPath(string.Format("{0}\\{1}_{2:yyyyMMdd}.log", AppDomain.CurrentDomain.BaseDirectory, type.FullName, DateTime.Now));
                    using (StreamWriter sw = new StreamWriter(path, true, UTF8Encoding.UTF8))
                    {

                        sw.WriteLine(new String('=', 50));
                        sw.WriteLine(string.Format("Message:{0}", e.Message));
                        sw.WriteLine(string.Format("Source:{0}", e.Source));
                        sw.WriteLine(string.Format("StackTrace:{0}", e.StackTrace));
                        sw.WriteLine(string.Format("DateTime:{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));

                        Exception inner = e.InnerException;
                        int deep = 1;
                        while (inner != null)
                        {
                            sw.WriteLine(new String('-', 50));
                            sw.WriteLine("InnerException:" + (deep++));
                            sw.WriteLine(new String('-', 50));

                            sw.WriteLine(string.Format("Message:{0}", inner.Message));
                            sw.WriteLine(string.Format("Source:{0}", inner.Source));
                            sw.WriteLine(string.Format("StackTrace:{0}", inner.StackTrace));

                            inner = inner.InnerException;
                        }
                        sw.WriteLine(new String('=', 50));
                    }
                }
            }));
        }
        /// <summary>
        /// 数据的摘要加密获取校验码。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SummaryEncry(byte[] data)
        {
            string result = string.Empty;
            if (data != null && data.Length > 0)
            {
                //Array.Sort<byte>(data);
                HashAlgorithm hashCrypto = MD5.Create();
                byte[] buf = hashCrypto.ComputeHash(data);
                if (buf != null && buf.Length > 0)
                {
                    StringBuilder sb = new StringBuilder(buf.Length * 2);
                    for (int i = 0; i < buf.Length; i++)
                        sb.Append(buf[i].ToString("x2", System.Globalization.CultureInfo.InvariantCulture));
                    result = sb.ToString();
                }
            }
            return result;
        }
        /// <summary>
        /// 数据的摘要加密获取校验码。
        /// </summary>
        /// <param name="fs"></param>
        /// <returns></returns>
        public static string SummaryEncry(FileStream fs)
        {
            string checkCode = null;
            if (fs != null && fs.Length > 0)
            {
                fs.Seek(0, SeekOrigin.Begin);
                using (MemoryStream ms = new MemoryStream())
                {
                    int count = 0;
                    byte[] buffer = new byte[1024];
                    while ((count = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, count);
                    }
                    checkCode = SummaryEncry(ms.ToArray());
                }
                fs.Seek(0, SeekOrigin.Begin);
            }
            return checkCode;
        }
    }
}
