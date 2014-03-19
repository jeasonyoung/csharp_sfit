//================================================================================
//  FileName: Comm.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.Net.MSG;
namespace Yaesoft.SFIT.Client.Net
{
    /// <summary>
    /// UDP数据到达委托。
    /// </summary>
    /// <param name="msg">消息对象。</param>
    public delegate void SocketDataArrivalEventHandler<T>(T msg);
    /// <summary>
    /// 通讯基础类。
    /// </summary>
    public abstract class Comm : IDisposable
    {
        #region 成员变量，构造函数。
        BinaryFormatter binaryFormatter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Comm()
        {
            this.binaryFormatter = new BinaryFormatter();
        }
        #endregion

        /// <summary>
        /// 端口线程缓存设置。
        /// </summary>
        protected static Hashtable PortThreadCache = Hashtable.Synchronized(new Hashtable());

        #region 事件处理。
        /// <summary>
        /// 通知外部消息。
        /// </summary>
        public event RaiseChangedHandler Changed;
        /// <summary>
        /// 触发通知外部消息。
        /// </summary>
        /// <param name="content"></param>
        protected void RaiseChanged(string content)
        {
            RaiseChangedHandler handler = this.Changed;
            if (handler != null) handler(content);
        }
        #endregion

        #region 消息处理。
        /// <summary>
        /// 序列化消息。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected byte[] Serialize(Msg data)
        {
            lock (this)
            {
                byte[] buf = null;
                if (data != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        this.binaryFormatter.Serialize(ms, data);
                        buf = ms.ToArray();
                    }
                }
                return buf;
            }
        }
        /// <summary>
        /// 反序列化消息。
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        protected Msg DeSerialize(MemoryStream ms)
        {
            Msg data = null;
            if (ms != null && ms.Length > 0)
            {
                ms.Position = 0;
                data = this.binaryFormatter.Deserialize(ms) as Msg;
            }
            return data;
        }
         /// <summary>
        /// 反序列化消息。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Msg DeSerialize(byte[] data)
        {
            lock (this)
            {
                if (data != null && data.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(data, 0, data.Length);
                        ms.Position = 0;
                        return this.DeSerialize(ms);
                    }
                }
                return null;
            }
        }
        #endregion

        #region 异常处理。
        /// <summary>
        /// 异常处理记录。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="type"></param>
        protected void OnExceptionRecord(Exception e, Type type)
        {
            UtilTools.OnExceptionRecord(e, type);
        }
        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 释放资源。
        /// </summary>
        public virtual void Dispose()
        {
             
        }

        #endregion
    }
}