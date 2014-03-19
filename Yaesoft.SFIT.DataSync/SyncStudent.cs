//================================================================================
//  FileName: SyncStudent.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/3
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
using Yaesoft.SFIT;
namespace Yaesoft.SFIT.DataSync
{
    /// <summary>
    /// 同步学生。
    /// </summary>
    [Serializable]
    public class SyncStudent
    {
        #region 成员变量，构造函数。
        SyncUnit school = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public SyncStudent()
        {
            this.school = new SyncUnit();
        }
        #endregion
        /// <summary>
        /// 获取或设置学号。
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 获取或设置姓名。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置性别。
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 获取或设置身份证号。
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 获取或设置入学年份。
        /// </summary>
        public string JoinYear { get; set; }
        /// <summary>
        /// 获取或设置学校。
        /// </summary>
        public SyncUnit School
        {
            get
            {
                return this.school;
            }
            set
            {
                this.school = value;
            }
        }
    }
    /// <summary>
    /// 同步学生集合。
    /// </summary>
    [Serializable]
    public class SyncStudents : BaseCollection<SyncStudent>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public override SyncStudent this[string code]
        {
            get
            {
                SyncStudent stu = this.Items.Find(new Predicate<SyncStudent>(delegate(SyncStudent sender)
                {
                    return (sender != null) && (sender.Code == code);
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
        public override int Compare(SyncStudent x, SyncStudent y)
        {
            int result = string.Compare(x.School.UnitCode, y.School.UnitCode);
            if (result == 0)
                result = string.Compare(x.Name, y.Name);
            return result;
        }
    }
}