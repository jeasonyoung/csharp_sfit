//================================================================================
//  FileName: ListViewColumnSorter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-11-12
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
using System.Windows.Forms;
namespace Yaesoft.SFIT.Client.TeaHost.Utils
{
    /// <summary>
    /// 列表按字段排序。
    /// </summary>
    internal class ListViewColumnSorter : IComparer
    {
        #region 成员变量，构造函数。
        CaseInsensitiveComparer objectCompare;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ListViewColumnSorter()
        {
            this.SortColumnIndex = 0;
            this.Order = SortOrder.None;
            this.objectCompare = new CaseInsensitiveComparer();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置排序列索引。
        /// </summary>
        public int SortColumnIndex { get; set; }
        /// <summary>
        /// 获取或设置排序方式。
        /// </summary>
        public SortOrder Order { get; set; }
        #endregion

        #region IComparer 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            ListViewItem itemX = x as ListViewItem, itemY = y as ListViewItem;
            if (itemX != null && itemY != null)
            {
                int result = this.objectCompare.Compare(itemX.SubItems[this.SortColumnIndex].Text, itemY.SubItems[this.SortColumnIndex].Text);
                if (this.Order == SortOrder.Ascending)
                {
                    return result;
                }
                else if (this.Order == SortOrder.Descending)
                {
                    return -result;
                }
            }
            return 0;
        }

        #endregion
    }
}