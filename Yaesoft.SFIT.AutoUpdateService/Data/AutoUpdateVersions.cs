//================================================================================
//  FileName: AutoUpdateVersions.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-31
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
namespace Yaesoft.SFIT.AutoUpdateService.Data
{
    /// <summary>
    /// 更新版本集合。
    /// </summary>
    [Serializable]
    public class AutoUpdateVersions : ICollection<AutoUpdateVersion>, IComparer<AutoUpdateVersion>
    {
        #region 成员变量，构造函数。
        List<AutoUpdateVersion> list;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public AutoUpdateVersions()
        {
            this.list = new List<AutoUpdateVersion>();
        }
        #endregion

        /// <summary>
        /// 根据版本号获取更新版本数据。
        /// </summary>
        /// <param name="ver"></param>
        /// <returns></returns>
        public AutoUpdateVersion this[int ver]
        {
            get
            {
                if (this.list == null || this.list.Count == 0)
                {
                    return null;
                }
                AutoUpdateVersion item = this.list.Find(new Predicate<AutoUpdateVersion>(delegate(AutoUpdateVersion sender)
                {
                    return (sender != null) && (sender.Ver == ver);
                }));
                return item;
            }
        }
        /// <summary>
        /// 根据更新ID获取更新版本数据。
        /// </summary>
        /// <param name="updateID"></param>
        /// <returns></returns>
        public AutoUpdateVersion this[string updateID]
        {
            get
            {
                if (string.IsNullOrEmpty(updateID) || this.list == null || this.list.Count == 0)
                {
                    return null;
                }
                AutoUpdateVersion item = this.list.Find(new Predicate<AutoUpdateVersion>(delegate(AutoUpdateVersion sender)
                {
                    return (sender != null) && (string.Equals(sender.UpdateID,updateID, StringComparison.InvariantCultureIgnoreCase));
                }));
                return item;
            }
        }


        #region ICollection<AutoUpdateVersion> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(AutoUpdateVersion item)
        {
            if (item != null && !this.Contains(item))
            {
                this.list.Add(item);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            if (this.list != null && this.list.Count > 0)
            {
                this.list.Clear();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(AutoUpdateVersion item)
        {
            if (item != null && this.list != null && this.list.Count > 0)
            {
                return (this[item.Ver] != null) || (this[item.UpdateID] != null);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(AutoUpdateVersion[] array, int arrayIndex)
        {
            if (this.list != null)
            {
                this.list.CopyTo(array, arrayIndex);
            }
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
        public bool Remove(AutoUpdateVersion item)
        {
            if (item != null)
            {
                return this.list.Remove(item);
            }
            return false;
        }

        #endregion

        #region IEnumerable<AutoUpdateVersion> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<AutoUpdateVersion> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (AutoUpdateVersion v in this)
            {
                yield return v;
            }
        }

        #endregion

        #region IComparer<AutoUpdateVersion> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(AutoUpdateVersion x, AutoUpdateVersion y)
        {
            return y.Ver - x.Ver;
        }

        #endregion
    }
}