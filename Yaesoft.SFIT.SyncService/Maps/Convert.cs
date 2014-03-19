//================================================================================
//  FileName: Convert.cs
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
using System.Xml.Serialization;
namespace Yaesoft.SFIT.SyncService.Maps
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Convert
    {
        /// <summary>
        /// 获取或设置转换源.
        /// </summary>
        [XmlAttribute("source")]
        public string Source { get; set; }
        /// <summary>
        /// 获取或设置转换目标.
        /// </summary>
        [XmlAttribute("target")]
        public string Target { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Source + "=>" + this.Target;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Converts : ICollection<Convert>
    {
        #region 成员变量,构造函数.
        private List<Convert> list;
        /// <summary>
        /// 构造函数.
        /// </summary>
        public Converts()
        {
            this.list = new List<Convert>();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceFullName"></param>
        /// <returns></returns>
        public static Converts DeSerializeInstance(string resourceFullName)
        {
            if (string.IsNullOrEmpty(resourceFullName)) return null;
            return Utils.DeSerializationFromResources<Converts>(resourceFullName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string this[string source]
        {
            get
            {
                if (!string.IsNullOrEmpty(source))
                {
                    Convert c = this.list.Find(new Predicate<Convert>(delegate(Convert sender)
                    {
                        return string.Equals(source, sender.Source, StringComparison.InvariantCultureIgnoreCase);
                    }));
                    if (c != null) return c.Target;
                }
                return null;
            }
        }

        #region ICollection<Convert> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(Convert item)
        {
            if (item != null) this.list.Add(item);
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
        public bool Contains(Convert item)
        {
            if (item == null) return false;
            return this.list.Contains(item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(Convert[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public int Count
        {
            get { return this.list.Count; }
        }
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public bool IsReadOnly
        {
            get { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(Convert item)
        {
            if (item == null) return false;
            return this.list.Remove(item);
        }

        #endregion

        #region IEnumerable<Convert> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Convert> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (Convert c in this.list)
                yield return c;
        }
        #endregion
    }
}
