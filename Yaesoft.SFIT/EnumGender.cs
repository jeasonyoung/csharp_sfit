//================================================================================
//  FileName: EnumGender.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/14
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
    /// 性别枚举。
    /// </summary>
    [Serializable]
    public enum EnumGender
    {
        /// <summary>
        /// 未知。
        /// </summary>
        None = 0x00,
        /// <summary>
        /// 男。
        /// </summary>
        Male = 0x01,
        /// <summary>
        /// 女。
        /// </summary>
        Female = 0x02
    }
}
