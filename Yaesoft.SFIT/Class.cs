//================================================================================
//  FileName: Class.cs
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
    /// 班级信息类。
    /// </summary>
    [Serializable]
    public class Class
    {
        #region 成员变量，构造函数。
        Students students = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Class()
        {
            this.students = new Students();
        }
        #endregion
        /// <summary>
        /// 获取或设置班级ID。
        /// </summary>
        public string ClassID { get; set; }
        /// <summary>
        /// 获取或设置班级代码。
        /// </summary>
        public string ClassCode { get; set; }
        /// <summary>
        /// 获取或设置班级名称。
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 获取或设置排序号。
        /// </summary>
        public int OrderNO { get; set; }

        /// <summary>
        /// 获取或设置学生。
        /// </summary>
        public Students Students
        {
            get { return this.students; }
            set { this.students = value;}
        }

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ClassID:").Append(this.ClassID).Append(",")
              .Append("ClassCode:").Append(this.ClassCode).Append(",")
              .Append("ClassName:").Append(this.ClassName).Append(",")
              .Append("OrderNO:").Append(this.OrderNO).Append(",")
              .Append("Students:[").Append(this.Students).Append("]");

            return sb.ToString();
        }
        #endregion
    }
    /// <summary>
    /// 班级集合。
    /// </summary>
    [Serializable]
    public class Classes : BaseCollection<Class>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public override Class this[string classID]
        {
            get
            {
                Class c = this.Items.Find(new Predicate<Class>(delegate(Class sender)
                {
                    return (sender != null) && (sender.ClassID == classID);
                }));
                return c;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(Class x, Class y)
        {
            return x.OrderNO - y.OrderNO;
        }
    }
}
