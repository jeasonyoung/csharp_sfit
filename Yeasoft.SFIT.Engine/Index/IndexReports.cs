//================================================================================
//  FileName: IndexReports.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-23
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
    [Serializable]
    public class IndexReport
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
        /// 获取或设置班级ID。
        /// </summary>
        public string ClassID { get; set; }
        /// <summary>
        /// 获取或设置班级名称。
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 获取或设置班级数。
        /// </summary>
        public int ClassCount { get; set; }
        /// <summary>
        /// 获取或设置学生ID。
        /// </summary>
        public string StudentID { get; set; }
        /// <summary>
        /// 获取或设置学生名称。
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 获取或设置学生人数。
        /// </summary>
        public int StudentCount { get; set; }
        /// <summary>
        /// 获取或设置科目名称。
        /// </summary>
        public string CatalogName { get; set; }
        /// <summary>
        /// 获取或设置作品ID。
        /// </summary>
        public string WorkID { get; set; }
        /// <summary>
        /// 获取或设置作品名称。
        /// </summary>
        public string WorkName { get; set; }
        /// <summary>
        /// 获取或设置作品总数。
        /// </summary>
        public int WorkCount { get; set; }
        /// <summary>
        /// 获取或设置作品评分。
        /// </summary>
        public string ReviewValue { get; set; }
        /// <summary>
        /// 获取或设置评语总数。
        /// </summary>
        public int SRCount { get; set; }
        /// <summary>
        /// 获取或设置人均作品数。
        /// </summary>
        public float AvgCount { get; set; }
        /// <summary>
        /// 获取或设置成绩等第。
        /// </summary>
        public string Score { get; set; }
        /// <summary>
        /// 作业提交时间。
        /// </summary>
        public string CreateTime { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class IndexReports : DataCollection<IndexReport>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(IndexReport x, IndexReport y)
        {
            int result = y.WorkCount - x.WorkCount;
            if (result == 0)
            {
                result = (int)(y.AvgCount - x.AvgCount);
                if (result == 0)
                {
                    result = string.Compare(x.Score, y.Score);
                }
            }
            return result;
        }
    }
}
