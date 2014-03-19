//================================================================================
//  FileName: UserInfo.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/30
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

namespace Yaesoft.SFIT.Client.Data
{
    /// <summary>
    /// 用户信息。
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        /// <summary>
        /// 获取或设置用户ID。
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 获取或设置用户代码。
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 获取或设置用户名称。
        /// </summary>
        public string UserName { get; set; }
    }
}
