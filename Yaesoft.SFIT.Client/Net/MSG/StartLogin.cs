//================================================================================
//  FileName: StartLogin.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/5
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
    /// 开始登录。
    /// </summary>
    [Serializable]
    public class StartLogin : Msg
    {
         #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public StartLogin()
        {
            this.Kind = MSGKind.Logining;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置学生电脑名称。
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// 获取或设置学生账号。
        /// </summary>
        public string UserAccount { get; set; }
        /// <summary>
        /// 获取或设置学生密码。
        /// </summary>
        public string UserPassword { get; set; }
        #endregion
    }
}
