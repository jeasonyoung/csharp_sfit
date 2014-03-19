//================================================================================
//  FileName: Credentials.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/10/10
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
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 教师机客户端访问密钥。
    /// </summary>
    [Serializable]
    public class Credentials
    {
        /// <summary>
        /// 获取或设置服务器URL。
        /// </summary>
        public string ServiceURL { get; set; }
        /// <summary>
        /// 获取或设置学校ID。
        /// </summary>
        public string SchoolID { get; set; }
        /// <summary>
        /// 获取或设置学校代码。
        /// </summary>
        public string SchoolCode { get; set; }
        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 获取或设置访问账号。
        /// </summary>
        public string AccessAccount { get; set; }
        /// <summary>
        /// 获取或设置访问密码。
        /// </summary>
        public string AccessPassword { get; set; }
        /// <summary>
        /// 获取或设置描述信息。
        /// </summary>
        public string Description { get; set; }
    }
    /// <summary>
    /// 教师机客户端访问密钥集合。
    /// </summary>
    [Serializable]
    public class CredentialsCollection : ICollection<Credentials>,IListSource
    {
        #region 成员变量，构造函数。
        List<Credentials> list = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public CredentialsCollection()
        {
            this.list = new List<Credentials>();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 根据学校ID获取访问密钥。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <returns></returns>
        public Credentials this[string schoolID]
        {
            get
            {
                if (this.list.Count > 0 && !string.IsNullOrEmpty(schoolID))
                {
                    Credentials data = this.list.Find(new Predicate<Credentials>(delegate(Credentials sender)
                    {
                        return (sender != null) && (sender.SchoolID == schoolID);
                    }));
                }
                return null;
            }
        }
        /// <summary>
        /// 根据索引获取访问密钥。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Credentials this[int index]
        {
            get
            {
                if (index >= 0)
                {
                    return this.list[index];
                }
                return null;
            }
        }
        #endregion

        #region ICollection<Credentials> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(Credentials item)
        {
            this.list.Add(item);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.list.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(Credentials item)
        {
            if (item != null)
                return this[item.SchoolID] != null;
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(Credentials[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return this.list.Count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(Credentials item)
        {
            if (item != null)
                return this.list.Remove(item);
            return false;
        }

        #endregion

        #region IEnumerable<Credentials> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Credentials> GetEnumerator()
        {
            foreach (Credentials d in this.list)
                yield return d;
        }

        #endregion

        #region IEnumerable 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion

        #region IListSource 成员

        bool IListSource.ContainsListCollection
        {
            get { return true; }
        }

        System.Collections.IList IListSource.GetList()
        {
            return this.list;
        }

        #endregion
    }

    /// <summary>
    /// 访问密钥序列化与反序列化。
    /// </summary>
    public static class CredentialsFactory
    {
        /// <summary>
        /// 序列化密钥集合。
        /// </summary>
        /// <param name="credentialsCollection">密钥集合。</param>
        /// <returns></returns>
        public static XmlDocument Serialize(CredentialsCollection credentialsCollection)
        {
            lock (typeof(CredentialsFactory))
            {
                XmlDocument doc = null;
                if (credentialsCollection != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(CredentialsCollection));
                        serializer.Serialize(ms, credentialsCollection);

                        ms.Position = 0;
                        doc = new XmlDocument();
                        doc.Load(ms);
                    }

                    if (doc != null)
                    {
                        EncryptorXmlData.EncryptorXml(doc);
                    }
                }
                return doc;
            }
        }
        /// <summary>
        /// 序列化密钥集合。
        /// </summary>
        /// <param name="data">密钥集合数据。</param>
        /// <param name="path">保存路径。</param>
        public static void Serialize(CredentialsCollection data, string path)
        {
            lock (typeof(CredentialsFactory))
            {
                if (data != null && !string.IsNullOrEmpty(path))
                {
                    XmlDocument doc = Serialize(data);
                    if (doc != null)
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                        {
                            doc.Save(fs);
                        }
                    }
                }
            }
        }
        /// <summary>
        ///  反序列化。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static CredentialsCollection DeSerialize(string path)
        {
            lock (typeof(CredentialsFactory))
            {
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(fs);
                        EncryptorXmlData.DecryptorXml(doc);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            doc.Save(ms);
                            ms.Position = 0;

                            XmlSerializer serializer = new XmlSerializer(typeof(CredentialsCollection));
                            return serializer.Deserialize(ms) as CredentialsCollection;
                        }
                    }
                }
                return null;
            }
        }
    }
}
