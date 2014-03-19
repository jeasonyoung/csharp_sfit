//================================================================================
//  FileName: IndexNewWorks.cs
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
    /// 最新作业数据。
    /// </summary>
    [Serializable]
    public class IndexNewWork
    {
        /// <summary>
        /// 获取或设置学校ID。
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        public string UName { get; set; }
        /// <summary>
        /// 获取或设置班级ID。
        /// </summary>
        public string CID { get; set; }
        /// <summary>
        /// 获取或设置班级名称。
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 获取或设置科目ID。
        /// </summary>
        public string SID { get; set; }
        /// <summary>
        /// 获取或设置科目名称。
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// 获取或设置作业数。
        /// </summary>
        public int Works { get; set; }
        /// <summary>
        /// 获取或设置上传时间。
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string str = string.Format("{0}_{1}_{2}", this.UID, this.CID, this.SID);
            if (!string.IsNullOrEmpty(str))
            {
                return str.GetHashCode();
            }
            return base.GetHashCode();
        }
    }
    /// <summary>
    /// 最新作业数据集合。
    /// </summary>
    [Serializable]
    public class IndexNewWorks : DataCollection<IndexNewWork>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(IndexNewWork x, IndexNewWork y)
        {
            return -DateTime.Compare(x.Time, y.Time);
        }
    }
}