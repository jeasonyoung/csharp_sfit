//================================================================================
//  FileName: IUserAuthentication.cs
//  Desc:用户认证接口。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/10/28
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

namespace Yaesoft.SFIT
{
    /// <summary>
    /// 用户认证接口。
    /// </summary>
    public interface IUserAuthentication
    {
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="type">类型：1-教师，2-学生。</param>
        /// <param name="account">用户账号。</param>
        /// <param name="password">用户密码。</param>
        /// <param name="err">错误信息。</param>
        /// <returns>返回用户ID。</returns>
        string VerifyUser(int type, string account, string password, out string err);
    }
}
