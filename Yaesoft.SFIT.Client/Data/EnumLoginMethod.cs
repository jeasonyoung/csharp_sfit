//================================================================================
//  FileName: Enums.cs
//  Desc:枚举文件。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/10
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
using System.ComponentModel;
namespace Yaesoft.SFIT.Client.Data
{
    /// <summary>
    /// 学生登录方式枚举。
    /// </summary>
    [Serializable]
    public enum EnumLoginMethod
    {
        /// <summary>
        /// 选择姓名。
        /// </summary>
        SelectName = 0x00,
        /// <summary>
        /// 统一登录。
        /// </summary>
        UnifiedLogin = 0x01,
        /// <summary>
        /// 指定密码。
        /// </summary>
        Password = 0x02
    }

    /// <summary>
    /// 学生登录方式枚举操作工具。
    /// </summary>
    public static class EnumLoginMethodOperaTools
    {
        /// <summary>
        /// 获取中文名称。
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string GetCHName(EnumLoginMethod method)
        {
            string result = string.Empty;
            switch (method)
            {
                case EnumLoginMethod.SelectName:
                    result = "选择姓名";
                    break;
                case EnumLoginMethod.Password:
                    result = "指定密码";
                    break;
                case EnumLoginMethod.UnifiedLogin:
                    result = "统一登录";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 获取绑定数据源。
        /// </summary>
        /// <returns></returns>
        public static IListSource BindSource()
        {
            return new NameValueCollection();
        }

        #region 内置类。
        /// <summary>
        /// 名称和值的集合。
        /// </summary>
        public class NameValueCollection : IListSource
        {

            #region IListSource 成员

            public bool ContainsListCollection
            {
                get { return false; }
            }

            public System.Collections.IList GetList()
            {
                BindingList<NameValue> bel = new BindingList<NameValue>();
                bel.Add(new NameValue(GetCHName(EnumLoginMethod.SelectName), (int)EnumLoginMethod.SelectName));
                bel.Add(new NameValue(GetCHName(EnumLoginMethod.Password), (int)EnumLoginMethod.Password));
                bel.Add(new NameValue(GetCHName(EnumLoginMethod.UnifiedLogin), (int)EnumLoginMethod.UnifiedLogin));
                return bel;
            }

            #endregion

            #region 内置类。
            /// <summary>
            /// 名称和值。
            /// </summary>
            public class NameValue
            {
                public NameValue(string name, int value)
                {
                    this.Name = name;
                    this.Value = value;
                }
                public string Name { get; set; }
                public int Value { get; set; }
            }
            #endregion
        }
        #endregion
    }
}
