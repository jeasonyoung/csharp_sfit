//================================================================================
//  FileName: IndexComments.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-21
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
    /// 评论数据。
    /// </summary>
    [Serializable]
    public class IndexComment
    {
        /// <summary>
        /// 
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Time { get; set; }
    }
    /// <summary>
    /// 评论数据集合。
    /// </summary>
    [Serializable]
    public class IndexComments : DataCollection<IndexComment>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(IndexComment x, IndexComment y)
        {
            return -DateTime.Compare(x.Time, y.Time);
        }
    }
}