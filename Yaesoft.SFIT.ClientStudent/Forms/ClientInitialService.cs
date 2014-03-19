//================================================================================
//  FileName: ClientInitialService.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/17
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
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

using Yaesoft.SFIT.Client.Net;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.Forms;
namespace Yaesoft.SFIT.ClientStudent.Forms
{
    /// <summary>
    /// 客户端初始化服务。
    /// </summary>
    public class ClientInitialService : InitialService
    {
        #region 成员变量，构造函数。
        private UDPSocket udpBroadcast = null;
        private FileDownTcpService fileDownTcpService = null;
        private PortSettings ports = null;
        private bool isHostClose = false;
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置是否重新启动。
        /// </summary>
        public bool Rest { get; set; }
        #endregion

        #region 重载处理。
        /// <summary>
        /// 
        /// </summary>
        protected override void BeginRun()
        {
            if ((this.ports = this["portsettings"] as PortSettings) != null)
            {
                (this.udpBroadcast = new UDPSocket(this.ports.HostBroadcast)).Start();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        protected override void PreRunForm(Form form)
        {
            form.Load += new EventHandler(delegate(object obj, EventArgs e)
            {
                if (this.udpBroadcast != null) this.udpBroadcast.DataArrival += this.ReceiveDataArrival;
                if (this.fileDownTcpService != null) this.fileDownTcpService.Changed += this.RaiseChanged;
            });
            form.FormClosed += new FormClosedEventHandler(delegate(object obj, FormClosedEventArgs e)
            {
                if (this.udpBroadcast != null) this.udpBroadcast.DataArrival -= this.ReceiveDataArrival;
                if (this.fileDownTcpService != null) this.fileDownTcpService.Changed -= this.RaiseChanged;
            });
            if (form is WaitHostBroadcastWindow)
            {
                this.isHostClose = false;
            }
            else if ((form is StudentMainWindow) && (this.ports != null))
            {
                (this.fileDownTcpService = new FileDownTcpService(this.ports.FileDownTransfer)).StartListen();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((sender is StudentMainWindow) && !this.isHostClose)
            {
                Student student = this["student"] as Student;
                if (!e.Cancel && student != null)
                {
                    ClientClose clientClose = new ClientClose();
                    clientClose.UID = clientClose.StudentID = student.StudentID;

                    IPAddress hostIP = IPAddress.Parse(string.Format("{0}", this["host_ip"]));
                    PortSettings ps = this["portsettings"] as PortSettings;
                    if (ps != null)
                    {
                        this.udpBroadcast.Send(clientClose, new IPEndPoint(hostIP, ps.ClientCallback));
                        this.fileDownTcpService.StopListen();
                    }
                }
            }
            base.FormClosing(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Dispose()
        {
            if (this.udpBroadcast != null)
            {
                this.udpBroadcast.Close();
                this.udpBroadcast.DataArrival -= this.ReceiveDataArrival;
                this.udpBroadcast = null;
            }
            if (this.fileDownTcpService != null)
            {
                this.fileDownTcpService.StopListen();
                this.fileDownTcpService.DataArrival -= this.ReceiveIssueWorkFile;
            }
            base.Dispose();
        }
        #endregion

        #region 广播消息处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void ReceiveDataArrival(Msg data)
        {
            if (data is Broadcast)
            {
                this.ReceiveHostBroadcast(data as Broadcast);
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void ReceiveHostBroadcast(Broadcast data)
        {
            if (data != null)
            {
                try
                {
                    Form frm = Application.OpenForms[0];
                    if (frm != null 
                        && (frm is IReceiveBroadcast) 
                        && !frm.IsDisposed
                        && frm.IsHandleCreated)
                    {
                        if (frm.InvokeRequired)
                        {
                            frm.Invoke(new MethodInvoker(delegate()
                            {
                                ((IReceiveBroadcast)frm).ReceiveBroadcast(data);
                            }));
                        }
                    }
                    if (data is HostCloseBroadcast)
                    {
                        #region 主机关闭广播。
                        if ((((HostCloseBroadcast)data).HostID == (string)this["host_id"]) && 
                            (((HostCloseBroadcast)data).UIP == (string)this["host_ip"]))
                        {
                            MessageBox.Show("教师主机结束上课或被强制下线！", "学生客户端关闭", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.isHostClose = this.ForceQuit = true;
                            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object obj)
                            {
                                Thread.Sleep(500);
                                this.ForceQuit = true;

                                while (Application.OpenForms.Count > 0)
                                {
                                    Form f = Application.OpenForms[0];
                                    if (f != null)
                                    {
                                        f.Invoke(new MethodInvoker(delegate()
                                        {
                                            f.Close();
                                        }));
                                    }
                                }

                                this.Rest = true;
                            }));
                        }
                        #endregion
                    }
                }
                catch (Exception e)
                {
                    this.RaiseChanged("发送异常错误：" + e.Message);
                }
            }
        }
        #endregion

        #region 接收服务器下发作品文件。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void ReceiveIssueWorkFile(FileMSG data)
        {
            try
            {
                IssueWorkFile file = data as IssueWorkFile;
                if (file != null)
                {
                    lock (this)
                    {
                        string hostIP = string.Format("{0}", this["host_ip"]);
                        Student stu = this["student"] as Student;
                        if ((hostIP == file.UIP) && (stu != null && stu.StudentID == file.StudentID) && (file.Data != null))
                        {
                            string path = this.CreateFilePath(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), file.WorkName, string.Empty, ".zip", 1);
                            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                byte[] buf = file.Data;
                                stream.Write(buf, 0, buf.Length);
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "接收下发数据时发生异常");
                Program.GlobalExceptionHandler(x);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initPath"></param>
        /// <returns></returns>
        private string CreateFilePath(string dir, string name, string addName, string ext, int i)
        {
            string path = Path.Combine(dir, string.Format("{0}{1}{2}", name, addName, ext));
            if (File.Exists(path))
            {
                return this.CreateFilePath(dir, name, string.Format("({0})", i), ext, i + 1);
            }
            return path;
        }
        #endregion
    }
}