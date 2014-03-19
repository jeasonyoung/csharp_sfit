//================================================================================
//  FileName: WorkUploadToServer.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-10-14
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
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Controls;

using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Poxy;
using Yaesoft.SFIT.Client.TeaHost.Utils;

namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 作业上传（网站服务器）
    /// </summary>
    public partial class WorkUploadToServer : BaseWindow
    {
        #region 成员变量，构造函数。
        private List<StudentWorkUpload> uploadStudents;
        private int repeatNumber = 0;
        private Queue uploadFailureQueue = Queue.Synchronized(new Queue());
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="store"></param>
        /// <param name="studentIDs"></param>
        public WorkUploadToServer(ICoreService service, LocalStudentWorkStore store,string[] studentIDs)
            : base(service)
        {
            this.Store = store;
            InitializeComponent();
            this.LoadControls(studentIDs);
        }
        #endregion

        /// <summary>
        /// 获取作业存储。
        /// </summary>
        protected LocalStudentWorkStore Store { get; set; }

        #region 事件定义。
        /// <summary>
        /// 
        /// </summary>
        public event RaiseChangedHandler Changed;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        protected void OnChanged(string content)
        {
            this.OnMessageEvent(MessageType.Normal, content);
            RaiseChangedHandler handler = this.Changed;
            if (handler != null)
            {
                handler(content);
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            if (this.uploadStudents.Count == 0) return DialogResult.Yes;
            return base.ShowDialog(owner);
        }
        protected void LoadControls(string[] studentIDs)
        {
            this.btnStartUpload.Enabled = false;
            string err = null;
            if (studentIDs == null || studentIDs.Length == 0)
            {
                this.btnStartUpload.Enabled = true;
                this.OnChanged(err = "未选择上传作业的学生！");
                MessageBox.Show(err);
                return;
            }
            this.Store = LocalStudentWorkStore.DeSerializer(this.Store.FileSavePath());
            if (this.Store == null || this.Store.Students == null || this.Store.Students.Count == 0)
            {
                this.btnStartUpload.Enabled = true;
                this.OnChanged(err = "加载作业存储索引文件失败或索引中没有学生作业数据！");
                MessageBox.Show(err);
                return;
            }
            this.uploadStudents = new List<StudentWorkUpload>();
            for (int i = 0; i < studentIDs.Length; i++)
            {
                LocalStudent ls = this.Store.Students[studentIDs[i]];
                if (ls != null && ls.HasWork())
                {
                    this.uploadStudents.Add(new StudentWorkUpload(this.Store, ls));
                }
            }
            if (this.uploadStudents.Count == 0)
            {
                this.btnStartUpload.Enabled = true;
                this.OnChanged(err = "没有找到学生的作业数据！");
                MessageBox.Show(err);
                return;
            }

            this.uploadFailureQueue.Clear();

            this.SuspendLayout();
            this.panel.SuspendLayout();
            int w = this.panel.Width - 5;
            for (int i = 0; i < this.uploadStudents.Count; i++)
            {
                StudentWorkUpload swp = this.uploadStudents[i];
                WorkUploadProgress workProgress = new WorkUploadProgress(string.Format("{0}.{1}", i + 1, swp.Title));
                workProgress.Width = w;
                workProgress.Margin = new Padding(3);
                workProgress.Location = new Point(0, workProgress.Height * i + 3);
                this.panel.Controls.Add(swp.Progress = workProgress);
            }
            this.panel.ResumeLayout(true);
            this.ResumeLayout(true);
            this.btnStartUpload.Enabled = true;
        }
        /// <summary>
        /// 上传作业
        /// </summary>
        /// <param name="poxy"></param>
        /// <param name="swp"></param>
        private void uploadWorks(TeaClientServicePoxyFactory poxy, StudentWorkUpload swp)
        {
            try
            {
                if (swp.Number > this.repeatNumber)
                {
                    swp.Progress.UploadFailure("已重复上传[" + (swp.Number - 1) + "]次达到最大限定次数！");
                    return;
                }
                string err = null;
                swp.Number += 1;
                if ((swp.Status = poxy.UploadStudentWorks(swp, out err) ? 1 : -1) == 1)
                {
                    WorkStoreHelper.WorkReviewQueueEntity entity = new WorkStoreHelper.WorkReviewQueueEntity(swp.Student.StudentID, swp.Student.Work.WorkID, EnumWorkStatus.Upload, null, swp.Store.FileSavePath());
                    entity.Changed += this.OnChanged;
                    WorkStoreHelper.UpdateWorkStatusToQueueStore(entity);
                    this.OnChanged("开始保存[" + swp.Student.StudentName + "," + swp.Title + "]作业状态...");
                }
                else if (!string.IsNullOrEmpty(err))
                {
                    this.OnChanged("[" + swp.Title + "]" + err);
                }

                if (swp.Status == -1 && swp.Number <= this.repeatNumber)
                {
                    this.uploadFailureQueue.Enqueue(swp);
                }
            }
            catch (Exception exp)
            {
                swp.Progress.UploadFailure(exp.Message);
                this.OnChanged("上传[" + swp.Student.StudentName + "," + swp.Title + "]时发生异常：" + exp.Message);
                Yaesoft.SFIT.Client.Utils.UtilTools.OnExceptionRecord(exp, this.GetType());
            }
        }
        private void repeatUploadFailureWorks(TeaClientServicePoxyFactory poxy)
        {
            if (this.uploadFailureQueue == null || this.uploadFailureQueue.Count == 0) return;
            while (this.uploadFailureQueue.Count > 0)
            {
                StudentWorkUpload swp = this.uploadFailureQueue.Dequeue() as StudentWorkUpload;
                if (swp != null)
                {
                    string msg = "开始[" + swp.Title + "]第[" + swp.Number + "]次上传作业!";
                    swp.Progress.UpdateProgressToolTipMessage(msg);
                    this.OnChanged(msg);
                    this.uploadWorks(poxy, swp);

                    Thread.Sleep(100);
                }
            }
        }
        #endregion

        #region 内部类。
        /// <summary>
        /// 学生作业上传。
        /// </summary>
        public class StudentWorkUpload
        {
            #region 成员变量，构造函数。
            /// <summary>
            /// 构造函数。
            /// </summary>
            /// <param name="store"></param>
            /// <param name="ls"></param>
            public StudentWorkUpload(LocalStudentWorkStore store, LocalStudent ls)
            {
                this.Status = 0;
                this.Store = store;
                this.Student = ls;
                this.Number = 1;
            }
            #endregion

            #region 属性。
            /// <summary>
            /// 获取学生作业名称。
            /// </summary>
            public string Title
            {
                get
                {
                    return string.Format("{0}:{1}", this.Student.StudentName, this.Student.Work.WorkName);
                }
            }
            /// <summary>
            /// 获取本地存储索引文件。
            /// </summary>
            public LocalStudentWorkStore Store { get; private set; }
            /// <summary>
            /// 获取本地学生信息。
            /// </summary>
            public LocalStudent Student { get; private set; }
            /// <summary>
            /// 获取或设置状态。
            /// 0-初始化。
            /// 1-上传成功。
            /// -1-上传失败。
            /// </summary>
            public int Status { get; set; }
            /// <summary>
            /// 获取或设置上传次数。
            /// </summary>
            public int Number { get; set; }
            /// <summary>
            /// 获取或设置进度条组件。
            /// </summary>
            public WorkUploadProgress Progress { get; set; }
            #endregion

            /// <summary>
            /// 检查作业是否满足上传条件。
            /// </summary>
            /// <returns></returns>
            private bool CheckWork(out string err)
            {
                err = null;
                if (this.Progress == null) throw new ArgumentNullException(err = "未与进度条控件关联！");
                if (this.Store == null || this.Student == null) return false;
                this.Store = LocalStudentWorkStore.DeSerializer(this.Store.FileSavePath());
                if (this.Store == null || this.Store.Students == null || this.Store.Students.Count == 0)
                {
                    this.Progress.UploadFailure(err = "加载索引文件异常或者索引文件下学生信息异常！");
                    return false;
                }
                this.Student = this.Store.Students[this.Student.StudentID];
                if (this.Student == null)
                {
                    this.Progress.UploadFailure(err = "学生已被删除！");
                    return false;
                }
                if (!this.Student.HasWork())
                {
                    this.Progress.UploadFailure(err = "学生没有作业或者作业已被删除！");
                    return false;
                }
                if ((this.Student.Work.Status & EnumWorkStatus.Review) != EnumWorkStatus.Review)
                {
                    this.Progress.UploadFailure(err = "学生作业未被批阅或批阅信息正在保存中...请稍后再试！(只能上传已批阅保存的作业)");
                    return false;
                }
                return true;
            }

            /// <summary>
            /// 创建压缩字节数组。
            /// </summary>
            public byte[] LoadZipFiles(out string err)
            {
                if (this.CheckWork(out err))
                {
                    LocalStudentWork lsw = this.Student.Work;
                    if (lsw != null && lsw.WorkFiles != null && lsw.WorkFiles.Count > 0)
                    {
                        List<String> paths = new List<string>();
                        for (int i = 0; i < lsw.WorkFiles.Count; i++)
                        {
                            string path = lsw.StudentWorkFilePath(this.Store, this.Student, lsw.WorkFiles[i]);
                            if (File.Exists(path)) paths.Add(path); 
                        }
                        if (paths.Count > 0) return ZipUtils.Zip(paths.ToArray());
                    }
                    err = "没有找到作业数据文件！";
                }
                return null;
            }
        }
        #endregion

        #region 事件处理。
        private void btnStartUpload_Click(object sender, EventArgs e)
        {
            if (this.uploadStudents != null && this.uploadStudents.Count > 0)
            {
                this.btnStartUpload.Enabled = false;
                this.repeatNumber = (int)this.numericUpDown.Value;
                if (this.repeatNumber <= 0)
                {
                    string err = "";
                    this.OnChanged(err);
                    MessageBox.Show("上传不成功次数必须大于[0]！");
                    return;
                }
                System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
                {
                    try
                    {
                        TeaClientServicePoxyFactory poxy = TeaClientServicePoxyFactory.Instance(this.CoreService, new RaiseChangedHandler(delegate(string msg)
                        {
                            this.OnChanged(msg);
                            this.toolStripStatusLabel.Text = msg;
                        }));
                        for (int i = 0; i < this.uploadStudents.Count; i++)
                        {
                            StudentWorkUpload swp = this.uploadStudents[i];
                            if (swp != null && swp.Status <= 0)
                            {
                                swp.Number = 0;
                                this.uploadWorks(poxy, swp);
                                Thread.Sleep(100);
                            }
                        }
                        //开始重复上传失败的作业。
                        this.repeatUploadFailureWorks(poxy);
                    }
                    catch (Exception ex)
                    {
                        this.OnChanged("分段上传时发生异常：" + ex.Message);
                        Yaesoft.SFIT.Client.Utils.UtilTools.OnExceptionRecord(ex, this.GetType());
                        MessageBox.Show(ex.Message, "发生异常：");
                    }
                    finally
                    {
                        //恢复按钮状态。
                        this.btnStartUpload.Invoke(new MethodInvoker(delegate() { this.btnStartUpload.Enabled = true; }));
                    }
                }));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!this.btnStartUpload.Enabled)
            {
                MessageBox.Show(this, "正在上传作业，请稍后...", "提示", MessageBoxButtons.OK);
                return;
            }
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!this.btnStartUpload.Enabled)
            {
                string msg = "正在上传作业,请稍后...";
                this.OnChanged(msg);
                MessageBox.Show(msg);
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
        #endregion
    }
}