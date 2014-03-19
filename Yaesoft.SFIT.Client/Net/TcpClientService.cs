//================================================================================
//  FileName: TcpClientService.cs
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
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Yaesoft.SFIT.Client.Net.MSG;
namespace Yaesoft.SFIT.Client.Net
{
    /// <summary>
    /// 客户端发送服务抽象类。
    /// </summary>
    public abstract class TcpClientService : CommTcpService
    {
        #region 成员变量，构造函数。
        private IPEndPoint host = null;
        private int maxDataSize = 0;
        private int uploadFileMaxCount = 10;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="host"></param>
        /// <param name="maxDataSize">(M)</param>
        public TcpClientService(IPEndPoint host, int maxDataSize)
        {
            this.host = host;
            this.maxDataSize = maxDataSize;
        }
        #endregion

        #region 操作函数。
        /// <summary>
        /// 上传文件。
        /// </summary>
        /// <param name="data"></param>
        public bool Upload(FileMSG data)
        {
            bool result = false;
            if (data == null) return result;
            int dataSize = 0;
            if (this.maxDataSize > 0 && !this.ValidDataSize(this.maxDataSize, data, out dataSize))
            {
                string msg = string.Format("数据过大({0}M，超过了规定传输的{1:N2}M)!", dataSize, dataSize - this.maxDataSize);
                MessageBox.Show(msg, "上传文件", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result;
            }
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    if (!client.Connected)
                    {
                        client.Connect(this.host);
                        this.RaiseChanged(string.Format("{0}【与{1}:{2}建立连接...】", DateTime.Now, this.host.Address, this.host.Port));
                    }

                    data.UIP = string.Format("{0}", this.host.Address);
                    NetworkStream stream = client.GetStream();
                    if (stream != null)
                    {
                        try
                        {
                            result = this.DataTransfer(stream, data);
                        }
                        catch (Exception e)
                        {
                            this.SendAnswer(stream, MSGKind.UploadFile, "上传文件异常：" + e.Message);
                            throw e;
                        }
                        finally
                        {
                            client.Close();
                        }
                    }
                   
                }
            }
            catch (SocketException e)
            {
                this.RaiseChanged(string.Format("{0}【发生网络故障，{1}】", DateTime.Now, e.SocketErrorCode));
                this.OnExceptionRecord(e, typeof(TcpClientService));
            }
            catch (Exception e)
            {
                this.OnExceptionRecord(e, typeof(TcpClientService));
                if (this.uploadFileMaxCount-- > 0)
                {
                    result = this.Upload(data);
                }
            }
            return result;
        }
        /// <summary>
        /// 验证最大数据大小。
        /// </summary>
        /// <param name="maxDataSize"></param>
        /// <param name="data"></param>
        /// <param name="dataSize"></param>
        /// <returns></returns>
        protected abstract bool ValidDataSize(int maxDataSize, FileMSG data, out int dataSize);
        /// <summary>
        /// 数据传输。
        /// </summary>
        /// <param name="netWorkStream"></param>
        /// <param name="data"></param>
        protected abstract bool DataTransfer(NetworkStream netWorkStream, FileMSG data);
        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 释放资源。
        /// </summary>
        public override void Dispose()
        {
            this.IsRuning = false;
        }

        #endregion
    }
}