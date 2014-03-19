//================================================================================
//  FileName: CommTcpService.cs
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
using System.Net;
using System.Net.Sockets;
using Yaesoft.SFIT.Client.Net.MSG;
namespace Yaesoft.SFIT.Client.Net
{
    /// <summary>
    /// TCP通讯基础类。
    /// </summary>
    public abstract class CommTcpService : Comm
    {
        /// <summary>
        /// 是否正在运行。
        /// </summary>
        public bool IsRuning { get; protected set; }
        /// <summary>
        /// 发送数据。
        /// </summary>
        /// <param name="netWorkStream"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        protected virtual void SendData(NetworkStream netWorkStream, Msg data, string message)
        {
            if (netWorkStream != null && data != null)
            {
                byte[] buf = this.Serialize(data);
                if (buf != null && buf.Length > 0)
                {
                    netWorkStream.Write(buf, 0, buf.Length);
                    this.RaiseChanged(string.Format("{0}【{1}...】", data.Time, message));
                }
            }
        }
        /// <summary>
        /// 发送应答数据给客户端。
        /// </summary>
        /// <param name="netWorkStream"></param>
        /// <param name="sendkind"></param>
        /// <param name="message"></param>
        protected virtual void SendAnswer(NetworkStream netWorkStream, MSGKind sendkind, string message)
        {
            Answer answer = new Answer(sendkind, message);
            answer.Time = DateTime.Now;
            this.SendData(netWorkStream, answer, message);
        }
        /// <summary>
        /// 获取客户端消息数据。
        /// </summary>
        /// <param name="netWorkStream"></param>
        /// <returns></returns>
        protected virtual Msg ReciveData(NetworkStream netWorkStream)
        {
            if (netWorkStream == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] buf = new byte[1024];
                int len = 0;
                while ((len = netWorkStream.Read(buf, 0, buf.Length)) > 0)
                {
                    ms.Write(buf, 0, len);
                }
                return this.DeSerialize(ms);
            }
        }
        /// <summary>
        /// 获取客户端应答数据。
        /// </summary>
        /// <param name="netWorkStream"></param>
        /// <returns></returns>
        protected virtual Answer ReciveAnswer(NetworkStream netWorkStream)
        {
            return this.ReciveData(netWorkStream) as Answer;
        }
    }
}