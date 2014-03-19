//================================================================================
//  FileName: FileDownTcpClient.cs
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
using System.Net;
using System.Net.Sockets;
using Yaesoft.SFIT.Client.Net.MSG;
namespace Yaesoft.SFIT.Client.Net
{
    /// <summary>
    /// 文件数据下发客户端。
    /// </summary>
    public class FileDownTcpClient : TcpClientService
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="host"></param>
        public FileDownTcpClient(IPEndPoint host)
            : base(host, 0)
        {
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxDataSize"></param>
        /// <param name="data"></param>
        /// <param name="dataSize"></param>
        /// <returns></returns>
        protected override bool ValidDataSize(int maxDataSize, FileMSG data, out int dataSize)
        {
            dataSize = 0;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netWorkStream"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override bool DataTransfer(NetworkStream netWorkStream, FileMSG data)
        {
            IssueWorkFile file = data as IssueWorkFile;
            this.RaiseChanged(string.Format("{0}【准备下发文件{1}...】", DateTime.Now, file.WorkName));
            this.SendData(netWorkStream, file, string.Format("开始下发文件{0}...", file.WorkName));
            this.RaiseChanged(string.Format("{0}【下发文件{1}完毕！】", DateTime.Now, file.WorkName));
            Answer answer = this.ReciveAnswer(netWorkStream);
            if (answer != null && answer.SourceKind == MSGKind.IssueWorkFile)
            {
                this.RaiseChanged(answer.Message);
            }
            this.RaiseChanged(DateTime.Now + @"【将与学生机客户端断开连接】");
            return true;
        }
        #endregion
    }
}