//================================================================================
//  FileName: Student.cs
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
using System.Text.RegularExpressions;
using System.Xml.Serialization;
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 学生信息。
    /// </summary>
    [Serializable]
    public class Student
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Student()
        {
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        public Student(string id, string code, string name)
        {
            this.StudentID = id;
            this.StudentCode = code;
            this.StudentName = name;
        }
        #endregion

        /// <summary>
        ///  获取或设置学生ID。
        /// </summary>
        public string StudentID { get; set; }
        /// <summary>
        /// 获取或设置学生代码。
        /// </summary>
        public string StudentCode { get; set; }
        /// <summary>
        /// 获取或设置学生名称。
        /// </summary>
        public string StudentName { get; set; }

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("ID:{0},Code:{1},Name:{2}", 
                                this.StudentID,
                                this.StudentCode,
                                this.StudentName);
        }
        #endregion
    }
    /// <summary>
    /// 学生集合。
    /// </summary>
    [Serializable]
    public class Students : BaseCollection<Student>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public override Student this[string studentID]
        {
            get
            {
                Student stu = this.Items.Find(new Predicate<Student>(delegate(Student sender)
                {
                    return (sender != null) && (sender.StudentID == studentID);
                }));
                return stu;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(Student x, Student y)
        {
            int x_code = this.getOrderNo(x.StudentCode);
            int y_code = this.getOrderNo(y.StudentCode);
            if (x_code == y_code)
            {
                return string.Compare(x.StudentCode, y.StudentCode);
            }
            else
            {
                return x_code - y_code;
            }
        }

        #region 辅助函数。
        static Regex STATIC_REGEX = new Regex(@"(?<Code>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        int getOrderNo(string orderNo)
        {
            if (!string.IsNullOrEmpty(orderNo))
            {
                try
                {
                    Match m = STATIC_REGEX.Match(orderNo);
                    if (m.Success)
                    {
                        string str = m.Groups["Code"].Value;
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str.Length > 2)
                            {
                                str = str.Substring(str.Length - 2);
                            }
                            return int.Parse(str);
                        }
                    }
                }
                catch (Exception) { }
            }
            return 0;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Items != null && this.Items.Count > 0)
            {
                foreach (Student item in this)
                {
                    if (sb.Length > 0) sb.Append(",");
                    sb.Append("{").Append(item).Append("}");
                }
            }
            return sb.ToString();
        }
    }
}
