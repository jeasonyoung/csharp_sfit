//================================================================================
//  FileName: HostListenService.cs
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
using System.IO;
using System.Xml;
using Yaesoft.SFIT.Client.Net;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Utils;
using Yaesoft.SFIT.Client.TeaHost.Controls;
namespace Yaesoft.SFIT.Client.TeaHost.Net
{
    /// <summary>
    /// 主机侦听服务。
    /// </summary>
    internal class HostListenService : Comm
    {
        #region 成员变量，构造函数。
        private ICoreService service = null;
        private UserInfo userInfo = null;
        private StartClassInfo sci = null;
        private PortSettings ports = null;
        private UDPSocket udpSocket = null;
        private WorkUpTcpService workUpTcpService = null;
        private string classId = null;

        private static Hashtable STU_Login_Cache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="sci"></param>
        /// <param name="userInfo"></param>
        /// <param name="ports"></param>
        public HostListenService(StartClassInfo sci,UserInfo userInfo, PortSettings ports)
        {
            this.sci = sci;
            this.userInfo = userInfo;
            this.ports = ports;

            this.udpSocket = new UDPSocket(this.ports.ClientCallback);
            this.udpSocket.Changed += this.RaiseChanged;
            this.udpSocket.DataArrival += new SocketDataArrivalEventHandler<Msg>(delegate(Msg sender)
            {
                try
                {
                    Thread thread = new Thread(new ThreadStart(delegate()
                    {
                        this.ReceiveClientData(sender);
                    }));
                    thread.IsBackground = true;
                    thread.Start();
                }
                catch (Exception e)
                {
                    UtilTools.OnExceptionRecord(e, typeof(UDPSocket));
                }
            });
            this.workUpTcpService = new WorkUpTcpService(this.ports.FileUpTransfer);
            this.workUpTcpService.Changed += this.RaiseChanged;
            this.workUpTcpService.DataArrival += new SocketDataArrivalEventHandler<FileMSG>(delegate(FileMSG sender)
            {
                this.ReceiveClientData(sender as UploadFileMSG);
            });
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 更新学生状态事件。
        /// </summary>
        public event UpdateStudentControlsHandler UpdateControls;
        /// <summary>
        /// 触发更新学生状态事件。
        /// </summary>
        /// <param name="students"></param>
        protected void OnUpdateControls(StudentEx student)
        {
            UpdateStudentControlsHandler handler = this.UpdateControls;
            if (handler != null && student != null)
                handler(student);
        }
        #endregion

        #region 消息处理。
        /// <summary>
        /// 接收客户端消息数据。
        /// </summary>
        /// <param name="data"></param>
        protected virtual void ReceiveClientData(Msg data)
        {
            if (data == null) return;
            this.RaiseChanged("监听:" + data.ToString());
            switch (data.Kind)
            {
                case MSGKind.ClientClose://学生机下线。
                    {
                        ClientClose cc = data as ClientClose;
                        if (cc != null)
                        {
                            StudentEx student = Program.STUDENTS[cc.StudentID];
                            if (student != null)
                            {
                                if ((student.Status & StudentControl.EnumStudentState.Online) == StudentControl.EnumStudentState.Online)
                                {
                                    student.Status &= ~StudentControl.EnumStudentState.Online;
                                }
                                student.Status |= StudentControl.EnumStudentState.Offline;
                                this.RaiseChanged(string.Format("学生机：({0}){1}[{2}] 关闭客户端！", student.MachineName, student.StudentName, student.IP));
                                this.OnUpdateControls(student);
                            }
                        }
                    }
                    break;
                case MSGKind.ReqLogin://请求登录。
                    {
                        ReqLogin req = data as ReqLogin;
                        if (req != null)
                        {
                            this.RaiseChanged(string.Format("学生机IP：{0},{1:HH-mm-ss} 请求登录！", req.UIP, req.Time));
                            RespLogin resp = new RespLogin();
                            resp.Method = this.sci.LoginMethod;
                            resp.Students = this.sci.ClassInfo.Students;
                            resp.Catalog = this.sci.CatalogInfo;
                            resp.Time = DateTime.Now;
                            resp.UID = this.userInfo.UserID;

                            bool result = this.SendOrderToClient(resp, req.UIP);
                            this.RaiseChanged(string.Format("学生机IP：{0},{1:HH-mm-ss} 请求登录，{2}！", req.UIP, req.Time, result ? "成功" : "失败"));
                        }
                    }
                    break;
                case MSGKind.Logining://开始登录。
                    {
                        StartLogin s = data as StartLogin;
                        if (s != null)
                        {
                            object o = STU_Login_Cache[s.UserAccount];
                            if (o == null)
                            {
                                STU_Login_Cache[s.UserAccount] = s.UserAccount;
                                this.VerifyLogin(s);
                            }
                            else
                            {
                                EndLogin end = new EndLogin();
                                end.UID = this.userInfo.UserID;
                                end.Time = DateTime.Now;
                                end.Result = false;
                                end.Error = string.Format("学生[{0}]正在登录中,请稍后...", s.UserAccount);
                                this.SendOrderToClient(end, s.UIP);
                            }
                        }
                    }
                    break;
            }
        }
        /// <summary>
        ///  接收客户端文件数据。
        /// </summary>
        /// <param name="data"></param>
        protected virtual void ReceiveClientData(UploadFileMSG data)
        {
            if (data != null)
            {
                string teacherId = this.userInfo.UserID, classId = this.sci.ClassInfo.ClassID;
                WorkStoreHelper.WorkAddQueueEntity entity = new WorkStoreHelper.WorkAddQueueEntity(teacherId, classId, data);
                entity.Changed += new RaiseChangedHandler(delegate(string content) { this.RaiseChanged(content); });
                entity.UpdateControls += new UpdateStudentControlsHandler(delegate(StudentEx stuEx)
                {
                    this.OnUpdateControls(stuEx);
                    this.RaiseChanged(string.Format("[{0},{1}]更新状态,队列处理完毕！", stuEx.StudentName, stuEx.StudentCode));
                });
                WorkStoreHelper.AddWorkToQueueStore(entity);
                this.RaiseChanged(string.Format("[{0},{1},{2}]上传作业已接收并进入队列处理...", data.Student.StudentName, data.Student.StudentCode, data.WorkName));
            }
        }
        #endregion

        
        #region 函数。
        /// <summary>
        /// 启动侦听。
        /// </summary>
        /// <param name="students"></param>
        public void StartListen(StudentsEx students)
        {
            if (students == null)
            {
                throw new ArgumentNullException("students", "学生未准备就绪");
            }
            students.SetOfflineStatus();
            #region 初始化学生作品存储。
            if (this.userInfo != null && this.sci != null)
            {
                lock (this)
                {
                    this.classId = this.sci.ClassInfo.ClassID;
                    LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(this.userInfo.UserID, this.sci.CatalogInfo.CatalogID, this.sci.ClassInfo.ClassID);
                    #region 初始化。
                    if (store == null)
                    {
                        store = new LocalStudentWorkStore();
                        store.TeacherID = this.userInfo.UserID;
                        store.GradeID = this.sci.GradeID;
                        store.CatalogID = this.sci.CatalogInfo.CatalogID;
                        store.ClassID = this.sci.ClassInfo.ClassID;
                        store.Evaluate = this.sci.Evaluate;
                    }
                    #endregion

                    #region 更新。
                    store.TeacherName = this.userInfo.UserName;
                    store.GradeName = this.sci.GradeName;
                    store.CatalogName = this.sci.CatalogInfo.CatalogName;
                    store.ClassName = this.sci.ClassInfo.ClassName;
                    store.Evaluate = this.sci.Evaluate;
                    #endregion

                    #region 更新学生信息。
                    if (students != null && students.Count > 0)
                    {
                        if (store.Students == null) store.Students = new LocalStudents();
                        string sId = null;
                        for (int i = 0; i < students.Count; i++)
                        {
                            sId = students[i].StudentID;
                            if (!string.IsNullOrEmpty(sId))
                            {
                                LocalStudent ls = store.Students[sId];
                                if (ls == null)
                                {
                                    ls = new LocalStudent(students[i]);
                                    store.Students.Add(ls);
                                }
                                //恢复关联。
                                Tools.RecoveryWorkAssociation(ref store, ls.StudentID);
                                if (ls.HasWork())
                                {
                                    students[i].Status |= StudentControl.EnumStudentState.Upload;
                                    if ((ls.Work.Status & EnumWorkStatus.Review) == EnumWorkStatus.Review)
                                    {
                                        students[i].Status |= StudentControl.EnumStudentState.Review;
                                    }
                                }

                            }
                        }
                    }
                    #endregion

                    //序列化数据。
                    if (!WorkStoreHelper.Serializer(ref store))
                    {
                        throw new Exception("生成索引文件失败（索引文件被占用），请稍后重试！");
                    }
                    //设置当前班级学生。
                    Program.STUDENTS = students;
                }
            }
            #endregion

            this.RaiseChanged("开启端口监听...");
            this.udpSocket.Start();

            this.RaiseChanged("打开文件上传端口侦听...");
            this.workUpTcpService.StartListen();
        }
        /// <summary>
        /// 停止侦听。
        /// </summary>
        public void StopListen()
        {
            this.RaiseChanged("关闭端口监听...");
            this.udpSocket.Close();
            this.RaiseChanged("关闭Tcp端口侦听...");
            this.workUpTcpService.StopListen();
        }
        #endregion

        #region 辅助函数。

        #region 验证学生登录。
        /// <summary>
        /// 验证登录。
        /// </summary>
        /// <param name="s"></param>
        protected void VerifyLogin(StartLogin s)
        {
            if (this.userInfo == null || Program.STUDENTS == null || this.sci == null || this.sci.ClassInfo == null) return;
            this.RaiseChanged(string.Format("学生机IP：({0})[{1}],{2:HH-mm-ss} 开始登录！", s.MachineName, s.UIP, s.Time));
            StudentEx stu = Program.STUDENTS[s.UserAccount];
            EndLogin end = new EndLogin();
            end.UID = this.userInfo.UserID;
            end.Time = DateTime.Now;
            if ((stu == null) && (this.sci.LoginMethod != EnumLoginMethod.UnifiedLogin))
            {
                end.Result = false;
                end.Error = string.Format("学生[{0},{1}]不属于本班级[{2}].", s.MachineName, s.UIP, this.sci.ClassInfo.ClassName);
                this.VerifyLoginEndHandler(s, stu, end);
            }
            else if ((stu != null) && ((stu.Status & StudentControl.EnumStudentState.Online) == StudentControl.EnumStudentState.Online))
            {
                end.Result = false;
                end.Error = string.Format("学生[{0},{1}]已经登录！", s.MachineName, s.UIP);
                this.VerifyLoginEndHandler(s, stu, end);
            }
            else
            {
                #region 验证账号。
                switch (this.sci.LoginMethod)
                {
                    case EnumLoginMethod.SelectName:
                    case EnumLoginMethod.Password:
                        {
                            end.Result = true;
                            end.Student = new Student(stu.StudentID, stu.StudentCode, stu.StudentName);
                            if (this.sci.LoginMethod == EnumLoginMethod.Password)
                            {
                                if (!(end.Result = (this.sci.Password == s.UserPassword)))
                                {
                                    end.Result = false;
                                    end.Student = null;
                                    end.Error = "密码错误！";
                                }
                            }
                            end.Time = DateTime.Now;
                            this.VerifyLoginEndHandler(s, stu, end);
                        }
                        break;
                    case EnumLoginMethod.UnifiedLogin:
                        {
                            Poxy.TeaClientServicePoxyFactory.Instance(this.service, this.RaiseChanged).Authentication(Yaesoft.SFIT.Client.TeaHost.Poxy.EnumUserAuthen.Student, s.UserAccount, s.UserPassword,
                                new Yaesoft.SFIT.Client.TeaHost.Poxy.UserAuthenticationHandler(delegate(LocalUserInfo userInfo, Exception e)
                            {
                                if (end.Result = (userInfo != null))
                                {
                                    if ((stu = Program.STUDENTS[userInfo.UserID]) == null)
                                    {
                                        end.Result = false;
                                        end.Error = string.Format("学生[{0},{1}]不属于本班级[{2}].", s.MachineName, s.UIP, this.sci.ClassInfo.ClassName);
                                    }
                                }
                                else
                                {
                                    end.Error = e.Message;
                                }
                                this.VerifyLoginEndHandler(s, stu, end);
                            }));
                        }
                        break;
                }
                #endregion
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="stu"></param>
        /// <param name="end"></param>
        private void VerifyLoginEndHandler(StartLogin s,StudentEx stu,EndLogin end)
        {
            if (s != null && end != null)
            {
                STU_Login_Cache[s.UserAccount] = null;
                this.RaiseChanged(string.Format("学生机IP：({0})[{1}],{2:HH-mm-ss} 登录{3}！{4}", s.MachineName, s.UIP, s.Time, end.Result ? "成功" : "失败", end.Error));
                if (end.Result && (stu != null))
                {
                    end.Student = new Student(stu.StudentID, stu.StudentCode, stu.StudentName);
                    stu.MachineName = s.MachineName;
                    stu.IP = s.UIP;
                    if ((stu.Status & StudentControl.EnumStudentState.Offline) == StudentControl.EnumStudentState.Offline)
                    {
                        stu.Status &= ~StudentControl.EnumStudentState.Offline;
                    }
                    stu.Status |= StudentControl.EnumStudentState.Online;
                }
                this.SendOrderToClient(end, s.UIP);
                if (end.Result)
                {
                    this.OnUpdateControls(stu);
                }
            }
        }
        #endregion
        /// <summary>
        /// 发送指令到客户端。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="clientIP"></param>
        protected bool SendOrderToClient(Msg data, string clientIP)
        {
            if (!string.IsNullOrEmpty(clientIP) && (data != null) && (this.ports != null))
            {
                return this.SendData(data, clientIP, this.ports.HostOrder);
            }
            return false;
        }
        /// <summary>
        /// 发送消息。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="clientIP"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool SendData(Msg data, string clientIP, int port)
        {
            lock (this)
            {
                bool result = false;
                if (!string.IsNullOrEmpty(clientIP) && (data != null))
                {
                    IPEndPoint remote = new IPEndPoint(IPAddress.Parse(clientIP), port);
                    byte[] buf = this.Serialize(data);
                    using (UdpClient udp = new UdpClient())
                    {
                        return udp.Send(buf, buf.Length, remote) > 0;
                    }
                }
                return result;
            }
        }
        #endregion
    }
}