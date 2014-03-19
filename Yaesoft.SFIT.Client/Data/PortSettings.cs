//================================================================================
//  FileName: PortSettings.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/29
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
using System.IO;
using System.Xml.Serialization;
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.Client.Data
{
    /// <summary>
    /// 端口设置。
    /// </summary>
    [Serializable]
    public class PortSettings
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public PortSettings()
        {
            this.HostBroadcast = 5000;
            this.BroadcastInterval = 1;
            this.HostOrder = 5001;
            this.ClientCallback = 5002;
            this.FileUpTransfer = 5003;
            this.FileDownTransfer = 5004;
            this.MaxFileSize = 50;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置主机广播端口。
        /// </summary>
        public int HostBroadcast { get; set; }
        /// <summary>
        /// 获取或设置广播间隔时间(秒)
        /// </summary>
        public int BroadcastInterval { get; set; }
        /// <summary>
        /// 获取或设置主机指令端口。
        /// </summary>
        public int HostOrder { get; set; }
        /// <summary>
        /// 获取或设置客户端反馈端口。
        /// </summary>
        public int ClientCallback { get; set; }
        /// <summary>
        /// 获取或设置文件上传端口。
        /// </summary>
        public int FileUpTransfer { get; set; }
        /// <summary>
        /// 获取或设置文件下发端口。
        /// </summary>
        public int FileDownTransfer { get; set; }
        /// <summary>
        /// 获取或设置最大文件传输大小(M)。
        /// </summary>
        public int MaxFileSize { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("HostBroadcast:").Append(this.HostBroadcast).Append(",")
              .Append("BroadcastInterval:").Append(this.BroadcastInterval).Append(",")
              .Append("HostOrder:").Append(this.HostOrder).Append(",")
              .Append("ClientCallback:").Append(this.ClientCallback).Append(",")
              .Append("FileUpTransfer:").Append(this.FileUpTransfer).Append(",")
              .Append("FileDownTransfer:").Append(this.FileDownTransfer).Append(",")
              .Append("MaxFileSize:").Append(this.MaxFileSize);
            return sb.ToString();
        }
    }
}
