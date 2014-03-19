//================================================================================
//  FileName: EnumSchoolType.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-01-15 
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
    /// 学校类型枚举。
    /// </summary>
    [Serializable]
    public enum EnumSchoolType
    {
        /// <summary>
        /// 幼儿园。
        /// </summary>
        Nursery = 0x00,
        /// <summary>
        /// 小学。
        /// </summary>
        PrimarySchool = 0x01,
        /// <summary>
        /// 初中。
        /// </summary>
        JuniorHighSchool = 0x02,
        /// <summary>
        /// 高中。
        /// </summary>
        HighSchool = 0x03,
        /// <summary>
        /// 一贯制学校。
        /// </summary>
        ConsistentSystemSchool = 0x04,
        /// <summary>
        /// 二级机构。
        /// </summary>
        TwoUnit = 0x05,
        /// <summary>
        /// 局机关
        /// </summary>
        Bureau = 0x06
    }
    /// <summary>
    /// 学校类型枚举操作类。。
    /// </summary>
    public static class EnumSchoolTypeOperaTools
    {
        /// <summary>
        /// 获取中文名称。
        /// </summary>
        /// <param name="schoolType"></param>
        /// <returns></returns>
        public static string GetCHName(EnumSchoolType schoolType)
        {
            string result = string.Empty;
            switch (schoolType)
            {
                case EnumSchoolType.Nursery:
                    result = "幼儿园";
                    break;
                case EnumSchoolType.PrimarySchool:
                    result = "小学";
                    break;
                case EnumSchoolType.JuniorHighSchool:
                    result = "初中";
                    break;
                case EnumSchoolType.HighSchool:
                    result = "高中";
                    break;
                case EnumSchoolType.ConsistentSystemSchool:
                    result = "一贯制学校";
                    break;
                case EnumSchoolType.TwoUnit:
                    result = "二级机构";
                    break;
                case EnumSchoolType.Bureau:
                    result = "局机关";
                    break;
            }
            return result;
        }
    }
}
