//================================================================================
//  FileName: TcpListenerService.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/24
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
using System.Windows.Forms;
using Yaesoft.SFIT.Client.Net.MSG;
namespace Yaesoft.SFIT.Client.Net
{
    /// <summary>
    /// 服务器端侦听服务。
    /// </summary>
    public abstract class TcpListenerService : CommTcpService
    {
        #region 成员变量，构造函数。
        private int port = -1;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public TcpListenerService(int port)
        {
            this.port = port;
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 数据接收事件。
        /// </summary>
        public event SocketDataArrivalEventHandler<FileMSG> DataArrival;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        protected void OnDataArrival(FileMSG data)
        {
            SocketDataArrivalEventHandler<FileMSG> handler = this.DataArrival;
            if (handler != null && data != null)
                handler(data);
        }
        #endregion

        #region 操作函数。
        /// <summary>
        /// 停止监听。
        /// </summary>
        public void StopListen()
        {
            this.IsRuning = false;
        }
        /// <summary>
        /// 启动监听。
        /// </summary>
        public void StartListen()
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
                if (this.IsRuning)
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
                    this.IsRuning = true;
                    this.RaiseChanged(string.Format("开始启动UDP监听 端口 {0}...", port));
                    TcpListener listener = null;
                    try
                    {
                        listener = new TcpListener(IPAddress.Any, this.port);
                        listener.Start((int)SocketOptionName.MaxConnections);
                        //同步监听循环。
                        while (this.IsRuning)
                        {
                            try
                            {
                                if (listener.Pending())
                                {
                                    TcpClient client = listener.AcceptTcpClient();
                                    if (client == null) continue;
                                    ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object sender)
                                    {
                                        this.networkDataTransfer(sender as TcpClient);
                                    }), client);
                                }
                            }
                            catch (Exception e)
                            {
                                this.RaiseChanged(err = string.Format("数据传输时发生异常：{0},{1},{2}", e.Message, e.Source, e.StackTrace));
                                this.OnExceptionRecord(new Exception(err, e), typeof(TcpListenerService));
                            }
                            finally
                            {
                                Thread.Sleep(10);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        if (listener != null)  listener.Stop();
                        //移除缓存。
                        UDPSocket.PortThreadCache[this.port] = null;
                    }
                }));
                thread.IsBackground = true;
                UDPSocket.PortThreadCache[this.port] = thread;
                thread.Start();
            }
            catch (Exception e)
            {
                this.StopListen();
                this.RaiseChanged(string.Format("监听TCP[{0}]发生异常：{1}", port, e.Message));
                this.OnExceptionRecord(e, this.GetType());
            }
        }
        private void networkDataTransfer(TcpClient client)
        {
            try
            {
                if (client == null) return;
                this.DataTransfer(client.GetStream());
            }
            catch (Exception ex)
            {
                string err = null;
                this.RaiseChanged(err = string.Format("数据分析时发生异常：{0},{1},{2}", ex.Message, ex.Source, ex.StackTrace));
                this.OnExceptionRecord(new Exception(err, ex), typeof(TcpListenerService));
            }
        }

        /// <summary>
        /// 数据传输。
        /// </summary>
        /// <param name="netWorkStream"></param>
        protected abstract void DataTransfer(NetworkStream netWorkStream);
        /// <summary>
        /// 释放资源。
        /// </summary>
        public override void Dispose()
        {
            this.StopListen();
            base.Dispose();
        }
        #endregion
    }
}