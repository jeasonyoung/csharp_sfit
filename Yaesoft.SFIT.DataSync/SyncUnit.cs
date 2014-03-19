//================================================================================
//  FileName: SyncUnit.cs
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

namespace Yaesoft.SFIT.DataSync
{
    /// <summary>
    /// 同步单位。
    /// </summary>
    [Serializable]
    public class SyncUnit
    {
        /// <summary>
        /// 获取或设置单位代码。
        /// </summary>
        public string UnitCode { get; set; }
        /// <summary>
        /// 获取或设置单位名称。
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 获取或设置单位类型。
        /// </summary>
        public string UnitType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("code:{0},name:{1},type:{2}", this.UnitCode, this.UnitName, this.UnitType);
        }
    }
    /// <summary>
    /// 同步单位集合。
    /// </summary>
    [Serializable]
    public class SyncUnits : BaseCollection<SyncUnit>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitCode"></param>
        /// <returns></returns>
        public override SyncUnit this[string unitCode]
        {
            get
            {
                SyncUnit unit = this.Items.Find(new Predicate<SyncUnit>(delegate(SyncUnit sender)
                {
                    return (sender != null) && (sender.UnitCode == unitCode);
                }));
                return unit;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(SyncUnit x, SyncUnit y)
        {
            return string.Compare(x.UnitName, y.UnitName);
        }
    }
}