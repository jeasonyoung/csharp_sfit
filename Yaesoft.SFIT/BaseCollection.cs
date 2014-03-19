//================================================================================
//  FileName: BaseCollection.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/25
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
using System.ComponentModel;
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 集合基类。
    /// </summary>
    [Serializable]
    public abstract class BaseCollection<T> : ICollection<T>, IComparer<T>, IListSource
    {
        #region 成员变量，构造函数。
        List<T> list = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public BaseCollection()
        {
            this.list = new List<T>();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取集合对象。
        /// </summary>
        [XmlIgnore]
        protected virtual List<T> Items
        {
            get
            {
                this.list.Sort(this);
                return this.list;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [XmlIgnore]
        public virtual T this[int index]
        {
            get
            {
                return this.Items[index];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        [XmlIgnore]
        public abstract T this[string itemID]
        {
            get;
        }
        #endregion

        #region ICollection<T> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(T item)
        {
            if (item != null)
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
        public virtual bool Contains(T item)
        {
            return this.list.Contains(item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
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
        public virtual bool Remove(T item)
        {
            return this.list.Remove(item);
        }
        #endregion

        #region IEnumerable<T> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            this.Items.Sort(this);
            foreach (T data in this.Items)
                yield return data;
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            this.Items.Sort(this);
            return this.Items.GetEnumerator();
        }

        #endregion

        #region IComparer<T> 成员
        /// <summary>
        ///  排序比较。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract int Compare(T x, T y);
        #endregion

        #region IListSource 成员
        /// <summary>
        /// 
        /// </summary>
        bool IListSource.ContainsListCollection
        {
            get { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.IList IListSource.GetList()
        {
            this.Items.Sort(this);
            return this.Items;
        }

        #endregion
    }
}
