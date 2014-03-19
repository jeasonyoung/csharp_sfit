//================================================================================
//  FileName: IndexUnitData.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-12-31
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
    ///  首页单位学校数据。
    /// </summary>
    [Serializable]
    public class IndexUnitData
    {
        /// <summary>
        /// 获取或设置单位ID。
        /// </summary>
        public string UnitID { get; set; }
        /// <summary>
        /// 获取或设置单位名称。
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (!string.IsNullOrEmpty(this.UnitID))
            {
                return this.UnitID.GetHashCode();
            }
            return base.GetHashCode();
        }
    }
    /// <summary>
    /// 首页单位学校数据集合。
    /// </summary>
    [Serializable]
    public class IndexUnitDataCollection : ICollection<IndexUnitData>,IComparer<IndexUnitData>
    {
        #region 成员变量，构造函数。
        List<IndexUnitData> list = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public IndexUnitDataCollection()
        {
            this.list = new List<IndexUnitData>();
        }
        #endregion

        #region ICollection<IndexUnitData> 成员

        public void Add(IndexUnitData item)
        {
            this.list.Add(item);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(IndexUnitData item)
        {
            return this.list.Contains(item);
        }

        public void CopyTo(IndexUnitData[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(IndexUnitData item)
        {
            return this.list.Remove(item);
        }

        #endregion

        #region IEnumerable<IndexUnitData> 成员

        public IEnumerator<IndexUnitData> GetEnumerator()
        {
            this.list.Sort(this);
            return this.list.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            this.list.Sort(this);
            foreach (IndexUnitData data in this.list)
            {
                yield return data;
            }
        }

        #endregion

        #region IComparer<IndexUnitData> 成员

        public int Compare(IndexUnitData x, IndexUnitData y)
        {
            return string.Compare(x.UnitName, y.UnitName);
        }

        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class IndexUnitDataResult : IndexDataResult<IndexUnitDataCollection>
    {
    }
}