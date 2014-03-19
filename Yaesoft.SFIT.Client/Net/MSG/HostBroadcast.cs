//================================================================================
//  FileName: BroadcastMSG.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/4
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
using Yaesoft.SFIT.Client.Data;
namespace Yaesoft.SFIT.Client.Net.MSG
{
    /// <summary>
    /// 广播消息。
    /// </summary>
    [Serializable]
    public class HostBroadcast : Broadcast
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public HostBroadcast()
        {
            this.Kind = MSGKind.Broadcast;
            this.Ports = new PortSettings();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置主机名称。
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// 获取或设置端口。
        /// </summary>
        public PortSettings Ports { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SName:").Append(this.SName).Append(",")
              .Append("Ports:{").Append(this.Ports).Append("},")
              .Append(base.ToString());
            return sb.ToString();
        }
    }
}
