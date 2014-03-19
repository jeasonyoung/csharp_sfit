//================================================================================
//  FileName: Grade.cs
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
    /// 年级类。
    /// </summary>
    [Serializable]
    public class Grade
    {
        #region 成员变量，构造函数。
        Evaluate evaluate = null;
        Catalogs catalogs = null;
        Classes classes = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Grade()
        {
            this.evaluate = new Evaluate();
            this.catalogs = new Catalogs();
            this.classes = new Classes();
        }
        #endregion
        /// <summary>
        /// 获取或设置年级ID。
        /// </summary>
        public string GradeID { get; set; }
        /// <summary>
        /// 获取或设置年级代码。
        /// </summary>
        public string GradeCode { get; set; }
        /// <summary>
        /// 获取或设置年级名称。
        /// </summary>
        public string GradeName { get; set; }
        /// <summary>
        /// 获取或设置排序字段。
        /// </summary>
        public int OrderNO { get; set; }
        /// <summary>
        /// 获取或设置客观评价。
        /// </summary>
        public Evaluate Evaluate
        {
            get { return this.evaluate; }
            set { this.evaluate = value; }
        }
        /// <summary>
        /// 获取或设置目录。
        /// </summary>
        public Catalogs Catalogs
        {
            get { return this.catalogs; }
            set { this.catalogs = value; }
        }
        /// <summary>
        /// 获取或设置班级集合。
        /// </summary>
        public Classes Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("ID:{0},Name:{1},Order:{2}",
                                this.GradeID,
                                this.GradeName,
                                this.OrderNO);
        }
        #endregion
    }
    /// <summary>
    /// 获取或设置年级集合。
    /// </summary>
    [Serializable]
    public class Grades : BaseCollection<Grade>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gradeID"></param>
        /// <returns></returns>
        public override Grade this[string gradeID]
        {
            get
            {
                Grade g = this.Items.Find(new Predicate<Grade>(delegate(Grade sender)
                {
                    return (sender != null) && (sender.GradeID == gradeID);
                }));
                return g;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(Grade x, Grade y)
        {
            return x.OrderNO - y.OrderNO;
        }
    }
}
