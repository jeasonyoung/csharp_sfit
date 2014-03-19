//================================================================================
//  FileName: School.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/25
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

using System.Xml.Serialization;
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 学校信息类。
    /// </summary>
    [Serializable]
    public class School
    {
        #region 成员变量，构造函数。
        Teacher teacher = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public School()
        {
            this.teacher = new Teacher();
        }
        #endregion

        /// <summary>
        /// 获取或设置学校ID。
        /// </summary>
        public string SchoolID { get; set; }
        /// <summary>
        /// 获取或设置学校代码。
        /// </summary>
        public string SchoolCode { get; set; }
        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 获取或设置学校类型。
        /// </summary>
        public EnumSchoolType SchoolType { get; set; }
        /// <summary>
        /// 获取或设置教师信息。
        /// </summary>
        public Teacher Teacher
        {
            get { return this.teacher; }
            set { this.teacher = value; }
        }

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("ID:{0},Code:{1},Name:{2},Type:{3}",
                                 this.SchoolID,
                                 this.SchoolCode,
                                 this.SchoolName,
                                 this.SchoolType);
        }
        #endregion
    }
}
