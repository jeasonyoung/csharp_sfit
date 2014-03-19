//================================================================================
//  FileName: ReviewTeacher.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/26
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
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 教师评阅。
    /// </summary>
    [Serializable]
    public class TeacherReview
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public TeacherReview()
        {
            this.EvaluateType = EnumEvaluateType.Hierarchy;
        }
        #endregion

        /// <summary>
        /// 获取或设置教师ID。
        /// </summary>
        public string TeacherID { get; set; }
        /// <summary>
        /// 获取或设置教师名称。
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 获取或设置评价类型(0-等级制，1-分数制)。
        /// </summary>
        public EnumEvaluateType EvaluateType { get; set; }
        /// <summary>
        /// 获取或设置客观评价结果。
        /// </summary>
        public string ReviewValue { get; set; }
        /// <summary>
        /// 获取或设置评语。
        /// </summary>
        public string SubjectiveReviews { get; set; }
    }
}
