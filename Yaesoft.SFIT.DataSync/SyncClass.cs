//================================================================================
//  FileName: SyncClass.cs
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
    /// 同步班级。
    /// </summary>
    [Serializable]
    public class SyncClass
    {
        #region 成员变量，构造函数。
        SyncUnit syncUnit;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public SyncClass()
        {
            this.syncUnit = new SyncUnit();
        }
        #endregion
        /// <summary>
        /// 获取或设置班级代码。
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 获取或设置班级名称。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置入学年份。
        /// </summary>
        public string JoinYear { get; set; }
        /// <summary>
        /// 获取或设置学习阶段。
        /// </summary>
        public EnumLearnLevel LearnLevel { get; set; }
        /// <summary>
        /// 获取或设置当前年级。
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// 获取或设置学校。
        /// </summary>
        public SyncUnit School
        {
            get { return this.syncUnit; }
            set { this.syncUnit = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ((this.School == null) ? string.Empty : this.School.ToString()) + string.Format(",Code:{0},Name:{1},JoinYear:{2},LearnLevel:{3},Grade:{4}",
                    this.Code, this.Name, this.JoinYear, this.LearnLevel, this.Grade);
        }
    }
    /// <summary>
    /// 同步班级集合。
    /// </summary>
    [Serializable]
    public class SyncClasses : BaseCollection<SyncClass>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public override SyncClass this[string code]
        {
            get
            {
                SyncClass sc = this.Items.Find(new Predicate<SyncClass>(delegate(SyncClass sender)
                {
                    return (sender != null) && (sender.Code == code);
                }));
                return sc;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(SyncClass x, SyncClass y)
        {
            int result = string.Compare(x.School.UnitName, y.School.UnitName);
            if (result == 0)
                result = string.Compare(x.Name, y.Name);
            return result;
        }
    }
}