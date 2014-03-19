//================================================================================
//  FileName: UDPSocket.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/4
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
using System.Collections;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Yaesoft.SFIT.Client.Net.MSG;
namespace Yaesoft.SFIT.Client.Net
{
    /// <summary>
    /// UDP协议组件。
    /// </summary>
    public class UDPSocket : Comm
    {
        #region 成员变量，构造函数。
        private int port = -1;
        private bool active = false;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UDPSocket(int port)
            : base()
        {
            this.port = port;
        }
        #endregion

        #region 事件。
        /// <summary>
        /// 数据到达事件。
        /// </summary>
        public event SocketDataArrivalEventHandler<Msg> DataArrival;
        /// <summary>
        ///  触发数据到达事件。
        /// </summary>
        /// <param name="data"></param>
        protected void OnDataArrival(Msg data)
        {
            SocketDataArrivalEventHandler<Msg> handler = this.DataArrival;
            if (handler != null && data != null)
            {
                handler(data);
            }
        }
        #endregion

        #region 处理函数。
        ///<summary>
        /// 发送数据。
        /// </summary>
        /// <param name="msg">消息数据</param>
        /// <param name="remoteAddr">远程地址。</param>
        public bool Send(Msg msg, IPEndPoint remoteAddr)
        {
            lock (this)
            {
                bool result = false;
                try
                {
                    if (msg != null && remoteAddr != null)
                    {
                        byte[] data = this.Serialize(msg);
                        using (UdpClient client = new UdpClient())
                        {
                            result = client.Send(data, data.Length, remoteAddr) > 0;
                        }
                    }
                }
                catch (Exception e)
                {
                    this.RaiseChanged(string.Format("发送数据异常:{0}", e.Message));
                    this.OnExceptionRecord(e, this.GetType());
                }
                return result;
            }
        }
        /// <summary>
        /// 关闭侦听端口。
        /// </summary>
        public void Close()
        {
            this.active = false;
        }
        /// <summary>
        /// 开始侦听端口。
        /// </summary>
        public void Start()
        {
            try
            {
                string err = null;
                if (this.port < 0)
                {
                    this.RaiseChanged(err = "端口[" + this.port + "]设置错误！");
                    MessageBox.Show(err, "通信错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.active)
                {
                    this.RaiseChanged(err = string.Format("端口:{0} 正在被监听中,请先关闭！", this.port));
                    MessageBox.Show(err, "通信错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Thread thread = UDPSocket.PortThreadCache[this.port] as Thread;
                if (thread != null)
                {
                    this.RaiseChanged(err = string.Format("端口:{0} 已经被使用！", port));
                    MessageBox.Show(err, "通信错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                thread = new Thread(new ThreadStart(delegate()
                {
                    this.active = true;
                    this.RaiseChanged(string.Format("开始启动UDP监听 端口 {0}...", this.port));
                    using (UdpClient client = new UdpClient(this.port))
                    {
                        while (this.active)
                        {
                            try
                            {
                                if (client.Available > 0)
                                {
                                    IPEndPoint remoteIP = new IPEndPoint(IPAddress.Any, port);
                                    byte[] buffer = client.Receive(ref remoteIP);
                                    if (buffer != null && buffer.Length > 0)
                                    {
                                        Msg msg = this.DeSerialize(buffer);
                                        if (msg != null && msg.Kind != MSGKind.None)
                                        {
                                            msg.UIP = string.Format("{0}", remoteIP.Address);
                                            new Thread(new ThreadStart(delegate()
                                            {
                                                this.OnDataArrival(msg);
                                            })).Start();
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                this.RaiseChanged(string.Format("监听UDP[{0}]接收数据时发生异常：{1}", port, ex.Message));
                                this.OnExceptionRecord(ex, this.GetType());
                            }
                        }
                        //关闭监听。
                        client.Close();
                    }
                    //移除缓存。
                    UDPSocket.PortThreadCache[this.port] = null;
                }));
                thread.IsBackground = true;
                UDPSocket.PortThreadCache[this.port] = thread;
                thread.Start();
            }
            catch (Exception e)
            {
                this.Close();
                if (UDPSocket.PortThreadCache.ContainsKey(this.port))
                {
                    UDPSocket.PortThreadCache[this.port] = null;
                }
                this.RaiseChanged(string.Format("监听UDP[{0}]发生异常：{1}", port, e.Message));
                this.OnExceptionRecord(e, this.GetType());
            }

        }
        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 
        /// </summary>
        public override void Dispose()
        {
            this.Close();
        }
        #endregion
    }
}