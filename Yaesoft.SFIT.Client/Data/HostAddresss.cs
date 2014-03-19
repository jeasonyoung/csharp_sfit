//================================================================================
//  FileName: HostAddresss.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/30
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
using System.Net;
namespace Yaesoft.SFIT.Client.Data
{
    /// <summary>
    /// 主机地址。
    /// </summary>
    [Serializable]
    public class HostAddress
    {
        /// <summary>
        /// 获取或设置主机IP。
        /// </summary>
        public IPAddress HostIP { get; set; }
        /// <summary>
        /// 获取或设置广播地址。
        /// </summary>
        public IPAddress BroadcastAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("HostIP:{0}", this.HostIP).Append(",").AppendFormat("BroadcastAddress:{0}", this.BroadcastAddress);
            return sb.ToString();
        }
    }
}