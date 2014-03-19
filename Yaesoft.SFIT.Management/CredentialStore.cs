//================================================================================
//  FileName: CredentialsSerializationUtils.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-11-23
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
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.Management
{
    /// <summary>
    /// 密钥存储。
    /// </summary>
    internal class CredentialStore
    {
        #region 成员变量，构造函数。
        static string path = Path.GetFullPath(string.Format("{0}\\CredentialStore.xml", AppDomain.CurrentDomain.BaseDirectory));
        CredentialsCollection collection;
        /// <summary>
        /// 
        /// </summary>
        public CredentialStore()
        {
            this.collection = new CredentialsCollection();
        }
        #endregion

        public CredentialsCollection Data
        {
            get { return this.collection; }
        }

        /// <summary>
        /// 添加数据。
        /// </summary>
        /// <param name="credentials"></param>
        public void Add(Credentials credentials)
        {
            if (credentials != null && !string.IsNullOrEmpty(credentials.SchoolID))
            {
                Credentials data = this.Data[credentials.SchoolID];
                if (data != null)
                {
                    data = credentials;
                }
                else
                {
                    this.Data.Add(credentials);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials"></param>
        public void Remove(Credentials credentials)
        {
            if (credentials != null && !string.IsNullOrEmpty(credentials.SchoolID))
            {
                Credentials data = this.Data[credentials.SchoolID];
                if (data != null)
                {
                    this.Data.Remove(data);
                }
            }
        }

        /// <summary>
        /// 序列化。
        /// </summary>
        public void Serializer()
        {
            UtilTools.Serializer<CredentialsCollection>(this.collection, path);
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <returns></returns>
        public static CredentialStore DeSerializer()
        {
            string strPath = path;
            if (File.Exists(strPath))
            {
                CredentialsCollection data = UtilTools.DeSerializer<CredentialsCollection>(strPath);
                if (data != null)
                {
                    CredentialStore store = new CredentialStore();
                    store.collection = data;
                    return store;
                }
            }
            return null;
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static CredentialsCollection DeSerializer(string path)
        {
            if (File.Exists(path))
            {
                return UtilTools.DeSerializer<CredentialsCollection>(path);
            }
            return null;
        }
    }
}
