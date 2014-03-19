//================================================================================
//  FileName: EndLogin.cs
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

using Yaesoft.SFIT;
namespace Yaesoft.SFIT.Client.Net.MSG
{
    /// <summary>
    /// 登录结束。
    /// </summary>
    [Serializable]
    public class EndLogin : Msg
    {
         #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public EndLogin()
        {
            this.Kind = MSGKind.Logined;
        }
        #endregion
        /// <summary>
        /// 获取或设置登录结果，是否成功。
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// 获取或设置学生信息。
        /// </summary>
        public Student Student { get; set; }
        /// <summary>
        /// 获取或设置错误信息。
        /// </summary>
        public string Error { get; set; }
    }
}
