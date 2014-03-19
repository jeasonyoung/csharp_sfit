//================================================================================
//  FileName: ServicePoxyAccount.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-12-14
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
    /// 服务代理账号信息。
    /// </summary>
    [Serializable]
    public class ServicePoxyAccount
    {
        /// <summary>
        /// 获取或设置Url。
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 获取或设置帐号。
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 获取或设置密码。
        /// </summary>
        public string Password { get; set; }
    }
}