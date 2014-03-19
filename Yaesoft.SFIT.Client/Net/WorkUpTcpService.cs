//================================================================================
//  FileName: WorkUpTcpService.cs
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
using System.Threading;
using Yaesoft.SFIT.Client.Net.MSG;
namespace Yaesoft.SFIT.Client.Net
{
    /// <summary>
    /// 学生作品上传TCP服务器类。
    /// </summary>
    public class WorkUpTcpService : TcpListenerService
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="port"></param>
        public WorkUpTcpService(int port)
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
            Msg data = this.ReciveData(netWorkStream);
            if (data == null)
            {
                this.RaiseChanged("作业数据解码失败，请稍后重新上传！");
                data = this.ReciveData(netWorkStream);
                //return;
            }
            this.RaiseChanged(string.Format("{0}【已经与学生机客户端建立连接...】", DateTime.Now));
            if (data is UploadFileMSG)
            {
                this.RaiseChanged(string.Format("{0}【获取[{0},{1}]作品数据成功，转存储...】", DateTime.Now, data.UID, data.UIP));
                this.OnDataArrival(data as UploadFileMSG);
                this.SendAnswer(netWorkStream, MSGKind.UploadFile, "服务器已经得到数据，作品上传成功！");
            }
            else if (data is Answer)
            {
                this.RaiseChanged(((Answer)data).Message);
            }
            else
            {
                //this.SendAnswer(netWorkStream, MSGKind.UploadFile, "作业上传失败，请稍后重新上传！[" + data + "]");
                this.RaiseChanged(string.Format("{0}【作业上传失败,上传数据未被解析[{1}]！】", DateTime.Now, data));
            }
            this.RaiseChanged(string.Format("{0}【准备与学生机客户端断开连接...】", DateTime.Now));
        }
    }
}