//================================================================================
//  FileName: RespLoginMSG.cs
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
using Yaesoft.SFIT.Client.Data;
namespace Yaesoft.SFIT.Client.Net.MSG
{
    /// <summary>
    /// 登录请求返回。
    /// </summary>
    [Serializable]
    public class RespLogin : Msg
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public RespLogin()
        {
            this.Kind = MSGKind.RespLogin;
        }
        #endregion

        /// <summary>
        /// 获取或设置登录方式。
        /// </summary>
        public EnumLoginMethod Method { get; set; }
        /// <summary>
        /// 获取或设置目录信息。
        /// </summary>
        public Catalog Catalog { get; set; }
        /// <summary>
        /// 获取或设置学生数据。
        /// </summary>
        public Students Students { get; set; }
    }
}
