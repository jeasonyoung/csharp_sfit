//================================================================================
//  FileName: WorkUpTcpClient.cs
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
    /// 学生作品上传TCP客户端类。
    /// </summary>
    public class WorkUpTcpClient: TcpClientService
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="host"></param>
        /// <param name="maxDataSize"></param>
        public WorkUpTcpClient(IPEndPoint host, int maxDataSize)
            : base(host, maxDataSize)
        {
        }
        #endregion
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
            UploadFileMSG file = data as UploadFileMSG;
            if (file != null && file.Files != null && file.Files.Count > 0)
            {
                foreach (StudentWorkFile swf in file.Files)
                {
                    dataSize += (int)swf.Size;
                }
                dataSize = dataSize / 1024 / 1024;
                return maxDataSize - dataSize > 0;
            }
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
            this.SendData(netWorkStream, data, "开始上传文件...");
            Answer answer = this.ReciveAnswer(netWorkStream);
            if (answer != null) this.RaiseChanged(answer.Message);
            this.RaiseChanged(DateTime.Now + @"【与教师机客户端断开连接】");
            return true;
        }
    }
}