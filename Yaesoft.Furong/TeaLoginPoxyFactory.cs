//================================================================================
//  FileName: TeaLoginPoxyFactory.cs
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
using System.Data;
using iPower;
using Yaesoft.SFIT;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.Furong
{
    /// <summary>
    /// 教师登陆代理工厂类。
    /// </summary>
    internal class TeaLoginPoxyFactory : IUserAuthentication
    {
        #region 成员变量，构造函数。
        Yaesoft.Furong.Proxy.TeaProxy.TeaLoginService poxy = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public TeaLoginPoxyFactory()
        {
            ServicePoxyAccount sp = ModuleConfiguration.ModuleConfig.TeaLoginService;
            Yaesoft.Furong.Proxy.TeaProxy.AuthHeader ah = new Yaesoft.Furong.Proxy.TeaProxy.AuthHeader();
            ah.UserName = sp.Username;
            ah.PassWord = sp.Password;
            this.poxy = new Yaesoft.Furong.Proxy.TeaProxy.TeaLoginService();
            this.poxy.AuthHeaderValue = ah;
            this.poxy.Url = sp.Url;
        }
        #endregion

        #region IUserAuthentication 成员
        /// <summary>
        /// 验证教师用户。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public string VerifyUser(int type, string account, string password, out string err)
        {
            string result = err = null;
            try
            {
                if (this.poxy.VerifyUser(account, password))
                {
                    result = account;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
            }
            return result;
        }

        #endregion
    }
}