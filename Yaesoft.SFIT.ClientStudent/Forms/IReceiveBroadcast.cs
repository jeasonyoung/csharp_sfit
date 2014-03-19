//================================================================================
//  FileName: IReceiveBroadcast.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/17
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

using Yaesoft.SFIT.Client.Net.MSG;
namespace Yaesoft.SFIT.ClientStudent.Forms
{
    /// <summary>
    /// 接收主机广播。
    /// </summary>
    public interface IReceiveBroadcast
    {
        /// <summary>
        /// 接收广播信息。
        /// </summary>
        /// <param name="data"></param>
        void ReceiveBroadcast(Broadcast data);
    }
}