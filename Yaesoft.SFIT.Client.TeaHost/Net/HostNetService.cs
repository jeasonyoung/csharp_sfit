//================================================================================
//  FileName: HostNetService.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using Yaesoft.SFIT.Client;
using Yaesoft.SFIT.Client.Net;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Net
{
    /// <summary>
    /// 更新学生控件委托。
    /// </summary>
    /// <param name="students"></param>
    internal delegate void UpdateStudentControlsHandler(StudentEx students);
    /// <summary>
    /// 主机网络服务。
    /// </summary>
    internal class HostNetService : IDisposable
    {
        #region 成员变量，构造函数。
        private UserInfo info = null;
        private StartClassInfo sci = null;
        private PortSettings ports = null;
        private HostAddress hostAddress = null;

        private HostListenService hostListenService = null;
        private HostBroadcastService hostBroadcast = null;

        private static Hashtable cache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 构造函数。
        /// </summary>
        private HostNetService(ICoreService service, StartClassInfo sci)
        {
            this.info = service["userinfo"] as UserInfo;
            this.ports = service["portsettings"] as PortSettings;
            this.hostAddress = service["hostaddress"] as HostAddress;
            //主机广播。
            this.hostBroadcast = new HostBroadcastService(info);
            this.hostBroadcast.Changed += this.OnRaiseChanged;
            //主机侦听。
            this.hostListenService = new HostListenService(this.sci = sci, this.info, this.ports);
            this.hostListenService.Changed += this.OnRaiseChanged;
            this.hostListenService.UpdateControls += this.OnUpdateControls;
        }
        #endregion

        #region 单件类。
        /// <summary>
        /// 获取对象实例。
        /// </summary>
        public static HostNetService Instance(ICoreService service)
        {
            lock (typeof(HostNetService))
            {
                StartClassInfo sci = service["startclassinfo"] as StartClassInfo;
                if (sci == null) return null;
                HostNetService hns = cache[sci] as HostNetService;
                if (hns == null)
                {
                    hns = new HostNetService(service, sci);
                    if (hns != null) cache[sci] = hns;
                }
                return hns;
            }
        }
        #endregion

        #region 事件。
        /// <summary>
        /// 外部消息事件。
        /// </summary>
        public event RaiseChangedHandler RaiseChanged;
        /// <summary>
        ///  触发外部消息事件。
        /// </summary>
        /// <param name="content"></param>
        protected void OnRaiseChanged(string content)
        {
            RaiseChangedHandler handler = this.RaiseChanged;
            if (handler != null && !string.IsNullOrEmpty(content))
            {
                handler(content);
            }
        }
        /// <summary>
        /// 更新学生状态事件。
        /// </summary>
        public event UpdateStudentControlsHandler UpdateControls;
        /// <summary>
        /// 触发更新学生状态事件。
        /// </summary>
        /// <param name="stu"></param>
        internal protected void OnUpdateControls(StudentEx stu)
        {
            UpdateStudentControlsHandler handler = this.UpdateControls;
            if (handler != null && stu != null)
                handler(stu);
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 开始上课。
        /// </summary>
        public void Start()
        {
            if (this.sci != null && this.sci.ClassInfo != null && this.sci.ClassInfo.Students != null
                    && this.ports != null
                    && this.hostAddress != null)
            {
                #region 主机广播。
                this.hostBroadcast.Start(this.sci, this.hostAddress, this.ports);
                #endregion

                #region 启动主机侦听。
                this.hostListenService.StartListen(new StudentsEx(sci.ClassInfo.Students));
                #endregion
            }
            else
            {
                throw new Exception("开始上课失败！[hostAddress:{" + this.hostAddress + "},ports:{" + this.ports + "},sci:{" + this.sci + "}]");
            }
        }
        /// <summary>
        /// 分发作品文件。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void SendIssueWork(IssueWorkFile data)
        {
            lock (this)
            {
                if (data != null && Program.STUDENTS != null)
                {
                    StudentEx stuEx = Program.STUDENTS[data.StudentID];
                    if (stuEx != null && !string.IsNullOrEmpty(stuEx.IP))
                    {
                        data.UID = this.info.UserID;
                        data.Time = DateTime.Now;
                        IPEndPoint host = new IPEndPoint(IPAddress.Parse(stuEx.IP), this.ports.FileDownTransfer);

                        ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object sender)
                        {
                            using (FileDownTcpClient client = new FileDownTcpClient((IPEndPoint)sender))
                            {
                                client.Changed += this.OnRaiseChanged;
                                client.Upload(data);
                            }
                        }), host);
                    }
                }
            }
        }
        /// <summary>
        /// 用广播端口发送消息。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ip"></param>
        public bool SendBroadcastPortMSG(Msg data, string ip)
        {
            bool result = false;
            if (data != null && !string.IsNullOrEmpty(ip))
            {
                data.Time = DateTime.Now;
                result = this.hostListenService.SendData(data, ip, this.ports.HostBroadcast);
            }
            return result;
        }
        /// <summary>
        /// 结束上课。
        /// </summary>
        public void Close()
        {
            //停止主机广播。
            if (this.hostBroadcast != null) this.hostBroadcast.Stop();
            //关闭主机侦听。
            if (this.hostListenService != null) this.hostListenService.StopListen();
        }
        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Close();
        }

        #endregion
    }
}