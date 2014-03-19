//================================================================================
//  FileName: IndexHotWorks.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-7
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
    /// 点击率最高作品。
    /// </summary>
    [Serializable]
    public class IndexHotWork
    {
        /// <summary>
        /// 获取或设置作品ID。
        /// </summary>
        public string WID { get; set; }
        /// <summary>
        /// 获取或设置作品名称。
        /// </summary>
        public string WName { get; set; }
        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        public string UName { get; set; }
        /// <summary>
        /// 获取或设置班级名称。
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 获取或设置学生名称。
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// 获取或设置点击率。
        /// </summary>
        public int Hits { get; set; }
        /// <summary>
        /// 获取或设置作品时间。
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.WID.GetHashCode();
        }
    }
    /// <summary>
    /// 点击率最高作品集合。
    /// </summary>
    [Serializable]
    public class IndexHotWorks : DataCollection<IndexHotWork>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(IndexHotWork x, IndexHotWork y)
        {
            return y.Hits - x.Hits;
        }
    }
}
