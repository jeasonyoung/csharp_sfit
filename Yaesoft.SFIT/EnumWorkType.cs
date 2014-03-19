//================================================================================
//  FileName: EnumWorkType.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/2
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
    /// 学生作品类型。
    /// </summary>
    [Serializable]
    public enum EnumWorkType
    {
        /// <summary>
        /// 公开。
        /// </summary>
        Public = 0x00,
        /// <summary>
        /// 不公开。
        /// </summary>
        Protected = 0x01
    }
    /// <summary>
    /// 学生作品类型操作工具类。
    /// </summary>
    public static class EnumWorkTypeOperaTools
    {
        /// <summary>
        /// 获取类型名称。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeName(EnumWorkType type)
        {
            if (type == EnumWorkType.Protected)
                return "不公开";
            return "公开";
        }
    }
}
