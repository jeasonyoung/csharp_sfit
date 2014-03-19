//================================================================================
//  FileName: HostBroadcast.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/2
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
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Net;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Net
{
    /// <summary>
    /// 主机广播。
    /// </summary>
    public class HostBroadcastService : Comm
    {
        #region 成员变量，构造函数。
        private UserInfo info = null;
        private bool isStart = false;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public HostBroadcastService(UserInfo userInfo)
        {
            this.info = userInfo;
        }
        #endregion

        #region 公开函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sci"></param>
        /// <param name="hostAddress"></param>
        /// <param name="ports"></param>
        public void Start(StartClassInfo sci, HostAddress hostAddress, PortSettings ports)
        {
            try
            {
                if (sci == null || ports == null || hostAddress == null) return;
                int broadcastPort = ports.HostBroadcast;

                Thread thread = HostBroadcastService.PortThreadCache[broadcastPort] as Thread;

                #region 如果当前广播未关闭，强制关闭。
                if (thread != null)
                {
                    try
                    {
                        this.Stop();
                        thread.Abort();
                    }
                    finally
                    {
                        thread = null;
                    }
                }
                #endregion

                this.RaiseChanged("开启主机广播...");

                IPEndPoint broadcastAddr = new IPEndPoint(hostAddress.BroadcastAddress, broadcastPort);

                HostBroadcast data = new HostBroadcast();
                data.SName = string.Format("{0}[{1}]{2}({3})", this.info.UserName, sci.ClassInfo.ClassName, sci.CatalogInfo.CatalogName, sci.CatalogInfo.TypeName);
                data.Ports = ports;
                data.UID = this.info.UserID;
                data.Time = DateTime.Now;

                int interval = ports.BroadcastInterval;

                thread = new Thread(new ThreadStart(delegate()
                {
                    this.isStart = true;
                    //主机广播。
                    this.sendHostBroadcast(data, broadcastAddr, interval);
                    //发送主机关闭广播。
                    this.sendHostCloseBroadcast(broadcastAddr);
                    //移除缓存。
                    HostBroadcastService.PortThreadCache[broadcastPort] = null;
                }));
                thread.IsBackground = true;
                HostBroadcastService.PortThreadCache[broadcastPort] = thread;
                thread.Start();
            }
            catch (Exception x)
            {
                this.OnExceptionRecord(x, this.GetType());
                this.RaiseChanged(x.Message);
                MessageBox.Show(x.Message, "循环广播时发生异常：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 停止广播。
        /// </summary>
        public void Stop()
        {
            this.isStart = false;
            this.RaiseChanged("关闭主机广播.");
        }
        #endregion

        #region 辅助函数。
        private void sendHostBroadcast(HostBroadcast data, IPEndPoint broadcastAddr, int interval)
        {
            try
            {
                if (data == null || broadcastAddr == null) return;
                if (interval < 0) interval = 1;
                while (this.isStart)
                {
                    try
                    {
                        data.Time = DateTime.Now;
                        using (UdpClient udpClient = new UdpClient())
                        {
                            byte[] buffer = this.Serialize(data);
                            if (buffer != null && buffer.Length > 0)
                            {
                                udpClient.Send(buffer, buffer.Length, broadcastAddr);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        this.OnExceptionRecord(e, this.GetType());
                        this.RaiseChanged("广播主机位置发生异常：" + e.Message);
                    }
                    finally
                    {
                        Thread.Sleep(interval * 1000 + 1600);
                    }
                }
            }
            catch (Exception e)
            {
                this.OnExceptionRecord(new Exception("循环广播时发生异常[" + data + "]", e), this.GetType());
                MessageBox.Show(e.Message, "循环广播时发生异常：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void sendHostCloseBroadcast(IPEndPoint broadcastAddr)
        {
            try
            {
                if (broadcastAddr == null) return;
                using (UdpClient udpClient = new UdpClient())
                {
                    HostCloseBroadcast hostClose = new HostCloseBroadcast();
                    hostClose.UID = hostClose.HostID = this.info.UserID;

                    byte[] buf = this.Serialize(hostClose);
                    if (buf != null && buf.Length > 0)
                    {
                        this.RaiseChanged("发送主机关闭广播...");
                        udpClient.Send(buf, buf.Length, broadcastAddr);
                    }
                }
                this.RaiseChanged("广播发送已停止！");
            }
            catch (Exception ex)
            {
                this.OnExceptionRecord(ex, this.GetType());
                this.RaiseChanged("发送主机关闭广播异常：" + ex.Message);
            }
        }
        #endregion
    }
}