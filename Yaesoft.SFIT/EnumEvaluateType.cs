//================================================================================
//  FileName: EnumEvaluateType.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/5
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
    /// 客观评价类型。
    /// </summary>
    [Serializable]
    public enum EnumEvaluateType
    {
        /// <summary>
        /// 等级制。
        /// </summary>
        Hierarchy = 0x00,
        /// <summary>
        /// 分数制。
        /// </summary>
        Score = 0x01
    }
}
