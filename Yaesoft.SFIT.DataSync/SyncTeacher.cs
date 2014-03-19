//================================================================================
//  FileName: SyncTeacher.cs
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
    /// 同步教师。
    /// </summary>
    [Serializable]
    public class SyncTeacher
    {
        #region 成员变量，构造函数。
        SyncUnit unit = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public SyncTeacher()
        {
            this.unit = new SyncUnit();
        }
        #endregion

        /// <summary>
        /// 获取或设置教师代码（教师账号）
        /// </summary>
        public string TeaCode { get; set; }
        /// <summary>
        /// 获取或设置教师名称。
        /// </summary>
        public string TeaName { get; set; }
        /// <summary>
        /// 获取或设置性别。
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 获取或设置科室名称。
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 获取或设置学校信息。
        /// </summary>
        public SyncUnit School
        {
            get { return this.unit; }
            set { this.unit = value; }
        }
        /// <summary>
        /// 获取或设置职称。
        /// </summary>
        public string Titles { get; set; }
        /// <summary>
        /// 获取或设置电话。
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 获取或设置出生日期。
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 获取或设置职务类别。
        /// </summary>
        public string JobCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},TeaCode:{1},TeaName:{2}", this.School == null ? string.Empty : this.School.ToString(), this.TeaCode, this.TeaName);
        }
    }
    /// <summary>
    /// 同步教师集合。
    /// </summary>
    [Serializable]
    public class SyncTeachers: BaseCollection<SyncTeacher>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teaCode"></param>
        /// <returns></returns>
        public override SyncTeacher this[string teaCode]
        {
            get
            {
                SyncTeacher tea = this.Items.Find(new Predicate<SyncTeacher>(delegate(SyncTeacher sender)
                {
                    return (sender != null) && (sender.TeaCode == teaCode);
                }));
                return tea;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(SyncTeacher x, SyncTeacher y)
        {
            int result = string.Compare(x.School.UnitName, y.School.UnitName);
            if (result == 0)
                result = string.Compare(x.TeaName, y.TeaName);
            return result;
        }
    }
}