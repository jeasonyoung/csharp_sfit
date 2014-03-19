//================================================================================
//  FileName: DataCollection.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-5
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

namespace Yaesoft.SFIT.Engine.Index
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class DataCollection<T> : ICollection<T>, IComparer<T>
        where T:class
    {
        #region 成员变量，构造函数。
        List<T> list = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DataCollection()
        {
            this.list = new List<T>();
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
            {
                this.list.Add(item);
            }
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
        public bool Contains(T item)
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
        public bool Remove(T item)
        {
            if (item != null)
            {
                return this.list.Remove(item);
            }
            return false;
        }

        #endregion

        #region IEnumerable<T> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            this.list.Sort(this);
            return this.list.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            this.list.Sort(this);
            foreach (T o in this.list)
            {
                yield return o;
            }
        }

        #endregion

        #region IComparer<T> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract int Compare(T x, T y);

        #endregion
    }
}
