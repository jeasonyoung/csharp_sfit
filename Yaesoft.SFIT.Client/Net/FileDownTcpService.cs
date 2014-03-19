//================================================================================
//  FileName: FileDownTcpService.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/6/8
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
using System.Net.Sockets;
using Yaesoft.SFIT.Client.Net.MSG;
namespace Yaesoft.SFIT.Client.Net
{
    /// <summary>
    /// 文件下发Tcp服务端。
    /// </summary>
    public class FileDownTcpService : TcpListenerService
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="port"></param>
        public FileDownTcpService(int port)
            : base(port)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netWorkStream"></param>
        protected override void DataTransfer(NetworkStream netWorkStream)
        {
            if (netWorkStream == null) return;
            this.RaiseChanged(string.Format("{0}【已经与教师机客户端建立连接...】", DateTime.Now));
            Msg data = this.ReciveData(netWorkStream);
            if (data != null && data.Kind == MSGKind.IssueWorkFile)
            {
                this.RaiseChanged(string.Format("{0}【已经获取教师机客户端[{0},{1}]下发文件数据】", DateTime.Now, data.UID, data.UIP));
                IssueWorkFile file = data as IssueWorkFile;
                if (file != null)
                {
                    this.RaiseChanged(string.Format("{0}【分析教师机客户端[{0},{1}]下发文件数据成功，转存储...】", DateTime.Now, file.UID, file.UIP));
                    this.OnDataArrival(file);
                    this.SendAnswer(netWorkStream, MSGKind.IssueWorkFile, "学生机客户端已经得到数据，文件下发成功！");
                }
                else
                {
                    this.RaiseChanged(string.Format("{0}【分析教师机客户端[{0},{1}]下发文件数据失败】", DateTime.Now, data.UID, data.UIP));
                    this.SendAnswer(netWorkStream, MSGKind.IssueWorkFile, "学生机客户端未得到数据，文件下发失败！");
                }
            }
            else
            {
                this.RaiseChanged(string.Format("{0}【已经获取教师机客户端[{0},{1}]下发文件数据，分发失败】", DateTime.Now, data.UID, data.UIP));
                this.SendAnswer(netWorkStream, MSGKind.IssueWorkFile, "文件下发失败！");
            }
            this.RaiseChanged(string.Format("{0}【准备与教师机客户端断开连接...】", DateTime.Now));
        }
    }
}