//================================================================================
//  FileName: AuthenticationProvider.cs
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

using iPower;
using iPower.IRMP.SSO;

using Yaesoft.SFIT;
namespace Yaesoft.Furong
{
    /// <summary>
    /// 提供单点登录身份认证接口。
    /// </summary>
    public class AuthenticationProvider : IAuthenticationProvider, IUser
    {
        #region 成员变量，构造函数。
        IUserAuthentication authentication = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public AuthenticationProvider()
        {
            this.authentication = new DataSyncFactory();
        }
        #endregion

        #region IUser 成员
        /// <summary>
        /// 
        /// </summary>
        public GUIDEx CurrentUserID
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string CurrentUserName
        {
            get;
            set;
        }

        #endregion

        #region IAuthenticationProvider 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userSign"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool ChangePassword(string userSign, string oldPassword, string newPassword, out string err)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userSign"></param>
        /// <param name="password"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public IUser UserAuthorizationVerification(string userSign, string password, out string err)
        {
            try
            {
                int type = 1;
                string account = userSign;
                if (account.IndexOf('#') > 0)
                {
                    string[] usr = account.Split('#');
                    try
                    {
                        type = int.Parse(usr[0]);
                    }
                    catch (Exception) { }
                    account = usr[1];
                }

                string code = this.authentication.VerifyUser(type, account, password, out err);
                if (string.IsNullOrEmpty(code))
                    throw new Exception(string.IsNullOrEmpty(err) ? "用户账号或密码不正确！" : err);

                IGetUserInfo getInfo = ModuleConfiguration.ModuleConfig.GetUserInfoAssembly;
                if (getInfo == null)
                    throw new Exception("获取用户信息程序集未配置！");
                string employeeID = null, employeeCode = null, employeeName = null;
                if (getInfo.GetUserInfo(type, code, out employeeID, out employeeCode, out employeeName))
                {
                    this.CurrentUserID = employeeID;
                    this.CurrentUserName = employeeName;
                    return this;
                }
                else
                    throw new Exception("获取用户信息失败，用户信息未同步到本地数据中！");
            }
            catch (Exception e)
            {
                err = e.Message;
            }
            return null;
        }

        #endregion
    }
}