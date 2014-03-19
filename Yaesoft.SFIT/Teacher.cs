//================================================================================
//  FileName: Teacher.cs
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
using System.Xml.Serialization;
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 教师信息类。
    /// </summary>
    [Serializable]
    public class Teacher
    {
        #region 成员变量，构造函数。
        Grades grades = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Teacher()
        {
            this.grades = new Grades();
        }
        #endregion

        /// <summary>
        /// 获取或设置教师ID。
        /// </summary>
        public string TeacherID { get; set; }
        /// <summary>
        /// 获取或设置教师代码。
        /// </summary>
        public string TeacherCode { get; set; }
        /// <summary>
        /// 获取或设置教师名称。
        /// </summary>
        public string TeacherName { get; set; }

        /// <summary>
        /// 获取或设置年级集合。
        /// </summary>
        public Grades Grades
        {
            get { return this.grades; }
            set { this.grades = value; }
        }

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("ID:{0},Code:{1},Name:{2}",
                               this.TeacherID,
                               this.TeacherCode,
                               this.TeacherName);
        }
        #endregion
    }
}
