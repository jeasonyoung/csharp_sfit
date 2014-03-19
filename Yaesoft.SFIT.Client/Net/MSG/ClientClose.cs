//================================================================================
//  FileName: ClientClose.cs
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
    /// 学生客户端关闭。
    /// </summary>
    [Serializable]
    public class ClientClose: Msg
    {
         #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ClientClose()
        {
            this.Kind = MSGKind.ClientClose;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置学生ID。
        /// </summary>
        public string StudentID { get; set; }
        #endregion
    }
}
