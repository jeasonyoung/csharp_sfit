//================================================================================
//  FileName: EnumLearnLevel.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/1
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
    /// 学习阶段枚举。
    /// </summary>
    [Serializable]
    public enum EnumLearnLevel
    {
        /// <summary>
        /// 幼儿园。
        /// </summary>
        Nursery = 0x00,
        /// <summary>
        /// 小学。
        /// </summary>
        PrimarySchool =0x01,
        /// <summary>
        /// 初中。
        /// </summary>
        JuniorHighSchool = 0x02,
        /// <summary>
        /// 高中。
        /// </summary>
        HighSchool = 0x03
    }
}
