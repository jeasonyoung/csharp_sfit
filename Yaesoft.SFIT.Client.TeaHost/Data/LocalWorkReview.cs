//================================================================================
//  FileName: LocalWorkReview.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-29
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
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 作品评阅。
    /// </summary>
    [Serializable]
    public class LocalWorkReview
    {
        /// <summary>
        /// 获取或设置教师ID。
        /// </summary>
        public string TeacherID { get; set; }
        /// <summary>
        /// 获取或设置教师名称。
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 获取或设置客观评价结果。
        /// </summary>
        public string ReviewValue { get; set; }
        /// <summary>
        /// 获取或设置评语。
        /// </summary>
        public CDATA SubjectiveReviews { get; set; }
    }
}