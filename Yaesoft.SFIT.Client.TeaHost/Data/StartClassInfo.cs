//================================================================================
//  FileName: StartClassInfo.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/1
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

using Yaesoft.SFIT.Client.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 开始上课信息。
    /// </summary>
    [Serializable]
    public class StartClassInfo
    {
        /// <summary>
        /// 获取或设置年级ID。
        /// </summary>
        public string GradeID { get; set; }
        /// <summary>
        /// 获取或设置年级名称。
        /// </summary>
        public string GradeName { get; set; }
        /// <summary>
        /// 获取或设置评阅。
        /// </summary>
        public Evaluate Evaluate { get; set; }
        /// <summary>
        /// 获取或设置班级信息。
        /// </summary>
        public Class ClassInfo { get; set; }
        /// <summary>
        /// 获取或设置目录信息。
        /// </summary>
        public Catalog CatalogInfo { get; set; }
        /// <summary>
        /// 获取或设置登录方式。
        /// </summary>
        public EnumLoginMethod LoginMethod { get; set; }
        /// <summary>
        /// 获取或设置密码。
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("GradeID:").Append(this.GradeID).Append(",")
              .Append("GradeName:").Append(this.GradeName).Append(",")
              .Append("Evaluate:{").Append(this.Evaluate).Append("},")
              .Append("ClassInfo:{").Append(this.ClassInfo).Append("},")
              .Append("CatalogInfo:{").Append(this.CatalogInfo).Append("},")
              .Append("LoginMethod:").Append(this.LoginMethod).Append(",")
              .Append("Password:").Append(this.Password);
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string HashCode()
        {
            return Yaesoft.SFIT.Client.Utils.UtilTools.SummaryEncry(UTF8Encoding.UTF8.GetBytes(this.ToString()));
        }
    }
}