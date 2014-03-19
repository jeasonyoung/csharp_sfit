//================================================================================
//  FileName: HostCloseBroadcast.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/4
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

namespace Yaesoft.SFIT.Client.Net.MSG
{
    /// <summary>
    /// 主机关闭广播。
    /// </summary>
    [Serializable]
    public class HostCloseBroadcast : Broadcast
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public HostCloseBroadcast()
        {
            this.Kind = MSGKind.HostClose;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置主机ID。
        /// </summary>
        public string HostID { get; set; }
        #endregion
    }
}
