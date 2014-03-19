//================================================================================
//  FileName: UCMonitor.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/31
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Controls;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.TeaHost.Net;
using Yaesoft.SFIT.Client.TeaHost.Utils;
namespace Yaesoft.SFIT.Client.TeaHost.Plugins
{
    /// <summary>
    /// 监控学生。
    /// </summary>
    public partial class UCMonitor : BaseUserControl
    {
        #region 成员变量，构造函数。
        private Size oldSize = Size.Empty;
        MonitorUIColorSettings settings;
        private HostNetService hostNetService = null;
        static Hashtable htUpdateStudentControlIndexCache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public UCMonitor(ICoreService service)
            : base(service)
        {
            InitializeComponent();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置年级ID。
        /// </summary>
        public string GradeID { get; set; }
        /// <summary>
        /// 获取或设置班级ID。
        /// </summary>
        public string ClassID { get; set; }
        /// <summary>
        /// 获取或设置目录ID。
        /// </summary>
        public string CatalogID { get; set; }
        #endregion

        #region 事件。
        /// <summary>
        /// 
        /// </summary>
        public event CrossPluginHandler CrossPluginSendEvent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void OnCrossPluginSend(CrossPluginEventArgs e)
        {
            CrossPluginHandler handler = this.CrossPluginSendEvent;
            if (handler != null && e != null)
                handler(this, e);
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取当前用户信息。
        /// </summary>
        protected UserInfo UserInfo
        {
            get { return this.CoreService["userinfo"] as UserInfo; }
        }
        /// <summary>
        /// 获取主机网络服务。
        /// </summary>
        internal HostNetService NetService
        {
            get
            {
                if (this.hostNetService == null)
                {
                    this.hostNetService = HostNetService.Instance(this.CoreService);
                    if (this.hostNetService != null)
                    {
                        hostNetService.RaiseChanged += new RaiseChangedHandler(delegate(string context)
                        {
                            this.ThreadSafeMethod(new MethodInvoker(delegate()
                            {
                                this.OnMessageEvent(MessageType.Normal, context);
                            }));
                        });
                    }
                }
                return this.hostNetService;
            }
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCMonitor_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            Form mainForm = this.ParentForm;
            if (mainForm != null) mainForm.MouseWheel += mainFormMouseWheel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelWork_Resize(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null && p.HasChildren)
            {
                int wspan = Math.Abs(p.Size.Width - this.oldSize.Width);
                if ((this.oldSize != Size.Empty) && (wspan > 15))
                {
                    this.DrawStudents(Program.STUDENTS);
                }
                this.oldSize = p.Size;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainFormMouseWheel(object sender, MouseEventArgs e)
        {
            //处理鼠标滚动事件。
            //判断鼠标是否在PanelWork区域中，如果不在则不响应滚动。
            Rectangle panelWorkToForm = this.panelWork.ClientRectangle;//获的PanelWork的区域。
            if (panelWorkToForm != null)
            {
                this.SuspendLayout();
                //将Panel区域转换为在Form空间中的占据区域。
                panelWorkToForm.Offset(this.panelWork.Location);
                //当前鼠标位置点在Panel局域内时。
                if (panelWorkToForm.Contains(e.Location))
                {
                    if (e.Delta < 0)
                    {
                        //向下滚动。
                        Point pos = new Point();
                        //由于获取AutoScrollPosition的值为实际滚动值的负值。
                        pos.X = -this.panelWork.AutoScrollPosition.X;
                        //故在此重新设置需要的滚动到的新值（位置值）。
                        pos.Y = -this.panelWork.AutoScrollPosition.Y + 50;
                        //切记获取AutoScrollPosition 与设置它的值所得结果并不相同。
                        this.panelWork.AutoScrollPosition = pos;
                    }
                    else
                    {
                        //向上滚动。
                        Point pos = new Point();
                        pos.X = -this.panelWork.AutoScrollPosition.X;
                        pos.Y = -this.panelWork.AutoScrollPosition.Y - 50;
                        this.panelWork.AutoScrollPosition = pos;
                    }
                }
                this.ResumeLayout();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentControlPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            StudentControl sc = sender as StudentControl;
            string msg = e.PropertyName;
            if (sc != null && !string.IsNullOrEmpty(msg))
            {
                this.OnToolTipEvent(sc, msg);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentControlDoubleClick(object sender, EventArgs e)
        {
            UserInfo info = this.UserInfo;
            if (info == null)
            {
                MessageBox.Show("当前用户信息丢失，请重新启动系统登录！");
                return;
            }
            StudentControl sc = sender as StudentControl;
            if (sc != null && (sc.State & StudentControl.EnumStudentState.Upload) == StudentControl.EnumStudentState.Upload)
            {
                LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(info.UserID, this.CatalogID, this.ClassID);
                if (store == null)
                {
                    this.OnMessageEvent(MessageType.PopupInfo, "未能找到作业索引文件！" + LocalStudentWorkStore.SavePath(info.UserID, this.CatalogID, this.ClassID));
                    return;
                }
                LocalStudent ls = store.Students[sc.UserInfo.UserID];
                if (ls == null)
                {
                    this.OnMessageEvent(MessageType.PopupInfo, string.Format("学生[{0},{1}]在作业索引文件中未注册，上传作业后会自动注册！", sc.UserInfo.UserName, sc.UserInfo.UserCode));
                    return;
                }
                if (!ls.HasWork())
                {
                    this.OnMessageEvent(MessageType.PopupInfo, string.Format("学生[{0},{1}]作业已被删除，状态更新延迟！", ls.StudentName, ls.StudentCode));
                    StudentEx stuEx = Program.STUDENTS[ls.StudentID];
                    stuEx.Status &= ~StudentControl.EnumStudentState.Upload;
                    this.UpdateStudentControl(stuEx);
                    return;
                }
                //明细。
                ModifyWorkDetailsWindow modifyWorkDetailsWindow = new ModifyWorkDetailsWindow(this.CoreService, store, ls.StudentID);
                modifyWorkDetailsWindow.StartPosition = FormStartPosition.CenterParent;
                if (modifyWorkDetailsWindow.ShowDialog(this) == DialogResult.OK)
                {
                    this.UpdateStudentControl(Program.STUDENTS[ls.StudentID]);
                } 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.contextMenuStrip.Enabled = (this.panelWork != null && this.panelWork.Controls != null && this.panelWork.Controls.Count > 0);
        }
        /// <summary>
        /// 刷新。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemRefresh_Click(object sender, EventArgs e)
        {
            if (Program.STUDENTS != null)
            {
                this.DrawStudents(Program.STUDENTS);
            }
        }
        /// <summary>
        /// 查看全部作品。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemQueryWorks_Click(object sender, EventArgs e)
        {
            if (this.UserInfo != null)
            {
                ModifyWorkWindow win = new ModifyWorkWindow(this.CoreService, this.ClassID, this.CatalogID);
                win.StartPosition = FormStartPosition.CenterScreen;
                win.Show(this);
            }
        }
        /// <summary>
        /// 下发学生作品。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemIssueWorks_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo info = this.UserInfo;
                if (info != null)
                {
                    IssueWorkHelpers helper = new IssueWorkHelpers(this.CoreService, this.panelWork);
                    helper.Issue(LocalStudentWorkStore.DeSerializer(info.UserID, this.CatalogID, this.ClassID), new RaiseChangedHandler(delegate(string content)
                    {
                        this.OnMessageEvent(MessageType.Normal, content);
                    }));
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.Normal, "下发作业数据异常：" + x.Message);
                Program.GlobalExceptionHandler(x);
            }
        }
        /// <summary>
        /// 导出学生作品。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemOutputAll_Click(object sender, EventArgs e)
        {
            UserInfo info = this.UserInfo;
            if (info != null)
            {
                if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(info.UserID, this.CatalogID, this.ClassID);
                    if (store == null)
                    {
                        this.OnMessageEvent(MessageType.PopupInfo, "没有找到学生作品索引文件！" + LocalStudentWorkStore.SavePath(info.UserID, this.CatalogID, this.ClassID));
                    }
                    else
                    {
                        store.OutputAllWorkFiles(this.folderBrowserDialog.SelectedPath, this.RaiseChanged);
                    }
                }
            }
            else
            {
                this.OnMessageEvent(MessageType.PopupInfo, "没有获取到当前用户信息！");
            }
        }
        #endregion

        #region 公共处理函数。
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="students"></param>
        public void Start(StudentsEx students)
        {
            lock (this)
            {
                this.settings = this.CoreService["monitoruicolorsettings"] as MonitorUIColorSettings;
                if (this.settings == null) this.settings = new MonitorUIColorSettings();
                this.DrawStudents(students);
            }
        }
        /// <summary>
        /// 更新学生状态。
        /// </summary>
        /// <param name="student"></param>
        public void UpdateStudentControl(StudentEx student)
        {
            lock (this)
            {
                int len = 0;
                if (student != null && this.panelWork != null &&
                    this.panelWork.Controls != null && ((len = this.panelWork.Controls.Count) > 0))
                {
                    int index = -1;
                    if (htUpdateStudentControlIndexCache.ContainsKey(student.StudentID))
                    {
                        index = (int)htUpdateStudentControlIndexCache[student.StudentID];
                        if (index < 0 || index > len - 1)
                        {
                            index = -1;
                        }
                    }
                    if (index > -1)
                    {
                        StudentControl sc = this.panelWork.Controls[index] as StudentControl;
                        if (sc != null && (sc.UserInfo.UserID == student.StudentID))
                        {
                            this.ThreadSafeMethod(new MethodInvoker(delegate()
                            {
                                sc.UserInfo.UserCode = student.StudentCode;
                                sc.UserInfo.UserName = student.StudentName;
                                sc.ColorSettings = this.settings;
                                sc.MachineName = student.MachineName;
                                sc.UserIP = student.IP;
                                sc.State = student.Status;
                                sc.Update();
                            }));
                            return;
                        }
                        else
                        {
                            index = -1;
                        }
                    }
                    if (index == -1)
                    {
                        for (int i = 0; i < len; i++)
                        {
                            StudentControl sc = this.panelWork.Controls[i] as StudentControl;
                            if (sc != null && (sc.UserInfo.UserID == student.StudentID))
                            {
                                htUpdateStudentControlIndexCache[student.StudentID] = i;
                                this.ThreadSafeMethod(new MethodInvoker(delegate()
                                {
                                    sc.UserInfo.UserCode = student.StudentCode;
                                    sc.UserInfo.UserName = student.StudentName;
                                    sc.MachineName = student.MachineName;
                                    sc.UserIP = student.IP;
                                    sc.State = student.Status;
                                    sc.Update();
                                }));
                                break;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 结束上课。
        /// </summary>
        public void Close()
        {
            StudentsEx students = null;
            if ((students = Program.STUDENTS) != null)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if ((students[i].Status & StudentControl.EnumStudentState.Online) == StudentControl.EnumStudentState.Online)
                    {
                        students[i].Status &= ~StudentControl.EnumStudentState.Online;
                    }
                    students[i].Status |= StudentControl.EnumStudentState.Offline;
                }
                this.DrawStudents(students);
            }
        }
        /// <summary>
        /// 处理外部消息。
        /// </summary>
        /// <param name="content"></param>
        public void RaiseChanged(string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                this.OnMessageEvent(MessageType.Normal, content);
            }
        }
        /// <summary>
        /// 绘制学生控件。
        /// </summary>
        /// <param name="students"></param>
        protected void DrawStudents(StudentsEx students)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object sender)
            {
                int len = 0;
                StudentControls controls = new StudentControls();
                if (students != null && (len = students.Count) > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (students[i] != null)
                        {
                            StudentControl sc = new StudentControl();
                            sc.ColorSettings = this.settings;
                            sc.MachineName = students[i].MachineName;
                            sc.UserIP = students[i].IP;
                            sc.UserInfo = new UserInfo();
                            sc.UserInfo.UserID = students[i].StudentID;
                            sc.UserInfo.UserCode = students[i].StudentCode;
                            sc.UserInfo.UserName = students[i].StudentName;
                            sc.PropertyChanged += this.StudentControlPropertyChanged;
                            sc.DoubleClick += this.StudentControlDoubleClick;
                            sc.State = students[i].Status;
                            sc.DragDropData += this.IssueResourceData;
                            sc.ContextHandler += this.SCContextMenu;
                            controls.Add(sc);
                        }
                    }
                }
                //绘制界面。
                this.ThreadSafeMethod(this.panelWork, new MethodInvoker(delegate()
                {
                    controls.DrawToPanel(this.panelWork, 4, 5);
                }));

            }));
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 分发资源数据。
        /// </summary>
        /// <param name="sc"></param>
        /// <param name="urls"></param>
        protected void IssueResourceData(StudentControl sc, string[] urls)
        {
            try
            {
                UserInfo info = this.UserInfo;
                if (info != null && this.NetService != null &&
                    sc != null && ((sc.State & StudentControl.EnumStudentState.Online) == StudentControl.EnumStudentState.Online) &&
                    urls != null && urls.Length > 0)
                {
                    IssueWorkFile data = new IssueWorkFile();
                    data.UID = info.UserID;
                    data.StudentID = sc.UserInfo.UserID;
                    data.WorkName = System.IO.Path.GetFileName(urls[0]);
                    data.Data = ZipUtils.Zip(urls);

                    this.OnMessageEvent(MessageType.Normal, string.Format("给[{0},{1}]下发资源：{2}", sc.UserInfo.UserName, sc.UserInfo.UserCode, data.WorkName));
                    this.NetService.SendIssueWork(data);
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, string.Format("分发资源时发生异常：{0}", x.Message));
                Program.GlobalExceptionHandler(x);
            }
        }
        /// <summary>
        /// 右键菜单处理。
        /// </summary>
        /// <param name="sc"></param>
        /// <param name="type"></param>
        protected void SCContextMenu(StudentControl sc, StudentControl.EnumContextMenuType type)
        {
            try
            {
                UserInfo info = this.UserInfo;
                if (sc == null || sc.UserInfo == null || info == null)
                {
                    return;
                }
                StudentEx stu = Program.STUDENTS[sc.UserInfo.UserID];
                if (stu == null)
                {
                    return;
                }
                switch (type)
                {
                    case StudentControl.EnumContextMenuType.Offline:
                        {
                            #region 强制学生离线。
                            if (this.NetService != null)
                            {
                                HostCloseBroadcast data = new HostCloseBroadcast();
                                data.HostID = data.UID = info.UserID;
                                if (this.NetService.SendBroadcastPortMSG(data, sc.UserIP))
                                {
                                    if ((stu.Status & StudentControl.EnumStudentState.Online) == StudentControl.EnumStudentState.Online)
                                    {
                                        stu.Status &= ~StudentControl.EnumStudentState.Online;
                                    }
                                    stu.Status |= StudentControl.EnumStudentState.Offline;
                                    this.UpdateStudentControl(stu);
                                }
                            }
                            #endregion
                        }
                        break;
                    case StudentControl.EnumContextMenuType.TemplateDelete:
                        {
                            #region 删除学生。
                            if (!string.IsNullOrEmpty(this.ClassID) && !string.IsNullOrEmpty(this.CatalogID))
                            {
                                LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(info.UserID, this.CatalogID, this.ClassID);
                                if (store != null && store.Students != null)
                                {
                                    LocalStudent ls = store.Students[sc.UserInfo.UserID];
                                    if (ls != null && store.Students.Remove(ls))
                                    {
                                        WorkStoreHelper.DeleteStudentToQueueStore(new WorkStoreHelper.DeleteStudentQueueEntity(ls.StudentID, store.FileSavePath()));
                                        StudentEx stuEx = Program.STUDENTS[ls.StudentID];
                                        if (Program.STUDENTS.Remove(stuEx))
                                        {
                                            this.menuItemRefresh_Click(null, null);
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        break;
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, string.Format("右键菜单处理：{0}", x.Message));
                Program.GlobalExceptionHandler(x);
            }
        }
        #endregion
    }
}