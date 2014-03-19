//================================================================================
//  FileName: IAuthentication.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/2
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
    /// 获取用户信息接口。
    /// </summary>
    public interface IGetUserInfo
    {
        /// <summary>
        /// 获取用户信息。
        /// </summary>
        /// <param name="type">类型：1-教师，2-学生。</param>
        /// <param name="userCode">用户代码。</param>
        /// <param name="employeeID">用户ID。</param>
        /// <param name="employeeCode">用户代码。</param>
        /// <param name="employeeName">用户名称。</param>
        /// <returns></returns>
        bool GetUserInfo(int type, string userCode, out string employeeID, out string employeeCode, out string employeeName);
    }
}
