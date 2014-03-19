//================================================================================
//  FileName: BatchUploadWaitWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-11-14
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
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Poxy;
using Yaesoft.SFIT.Client.TeaHost.Utils;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BatchUploadWaitWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        private LocalStudentWorkStore store;
        private LocalStudents students;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="store"></param>
        /// <param name="students"></param>
        public BatchUploadWaitWindow(ICoreService service, LocalStudentWorkStore store, LocalStudents students)
            : base(service)
        {
            this.store = store;
            this.students = students;
            InitializeComponent();
        }
        #endregion

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

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatchUploadWaitWindow_Load(object sender, EventArgs e)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
                {
                    Thread.Sleep(5000);
                    if (this.store != null && this.store.Students != null && this.students != null && this.students.Count > 0)
                    {
                        int success = 0, failure = 0;
                        List<string> listFailure = null;

                        //上传数据。
                        this.uploadWorks(this.store, this.students, out success, out failure, out listFailure);

                        #region 消息处理。
                        this.OnChanged("批量上传完毕！");
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("上传成功：{0},失败：{1}", success, failure);
                        sb.AppendLine();
                        if (listFailure.Count > 0)
                        {
                            for (int k = 0; k < listFailure.Count; k++)
                            {
                                sb.AppendFormat("{0}.{1}", k + 1, listFailure[k]);
                                sb.AppendLine();
                            }
                            sb.AppendLine("查看详细列表请点击[确定].");
                        }
                        #endregion

                        #region 显示结果。
                        this.ThreadSafeMethod(new MethodInvoker(delegate()
                        {
                            if (MessageBox.Show(this, sb.ToString(), "批量上传", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                            {
                                DateTime dt = DateTime.Now;
                                string path = Path.GetFullPath(string.Format("{0}\\BatchUpload_{1:yyyyMMddHHmmss}.log", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), dt));
                                using (StreamWriter sw = new StreamWriter(path, true, UTF8Encoding.UTF8))
                                {
                                    sw.WriteLine(new String('#', 50));
                                    sw.WriteLine(string.Format("批量上传[{0:yyyy-MM-dd HH:mm:ss}]", DateTime.Now));
                                    sw.WriteLine(string.Format("成功：{0},失败：{1}", success, failure));
                                    if (listFailure.Count > 0)
                                    {
                                        sw.WriteLine(new String('-', 50));
                                        for (int n = 0; n < listFailure.Count; n++)
                                        {
                                            sw.WriteLine(string.Format("{0}.{1}", n + 1, listFailure[n]));
                                        }
                                    }
                                }
                                if (File.Exists(path))
                                {
                                    System.Diagnostics.Process.Start(path);
                                }
                            }
                            this.Close();
                        }));
                        #endregion
                    }
                }));
            }
            catch (Exception x)
            {
                Program.GlobalExceptionHandler(x);
                this.OnChanged(string.Format("批量上传异常：{0}", x.Message));
                this.Close();
            }
        }
        #endregion

        #region 辅助函数。
        private void uploadWorks(LocalStudentWorkStore store, LocalStudents students, out int success,out int failure, out List<string> listFailure)
        {
            success = 0;
            failure = 0;
            listFailure = new List<string>();
            ///TODO:老师上传作业。
            //if (store != null && store.Students != null && store.Students.Count > 0 && students != null && students.Count > 0)
            //{
            //    string storeFielPath = store.FileSavePath();
            //    using (TeaClientServicePoxyFactory factory = TeaClientServicePoxyFactory.Instance(this.CoreService, new RaiseChangedHandler(delegate(string content)
            //    {
            //        this.OnChanged(content);
            //    })))
            //    {
            //        bool complete = false;
            //        for (int i = 0; i < students.Count; i++)
            //        {
            //            LocalStudent ls = this.students[i];
            //            #region 处理作品。
            //            ls = this.store.Students[ls.StudentID];
            //            if (ls != null && ls.Works != null && ls.Works.Count > 0)
            //            {
            //                if (((ls.Works[0].Status & EnumWorkStatus.Review) == EnumWorkStatus.Review))
            //                {
            //                    if ((ls.Works[0].Status & EnumWorkStatus.Upload) != EnumWorkStatus.Upload)
            //                    {
            //                        this.OnChanged(string.Format("开始上传：[{0},{1}]作品[{2}]...", ls.StudentName, ls.StudentCode, ls.Works[0].WorkName));
            //                        string content = null;
            //                        if (complete = factory.UploadStudentWorks(ref this.store, ref ls, out content))
            //                        {
            //                            success++;
            //                            ls.Works[0].Status |= EnumWorkStatus.Upload;
            //                            WorkStoreHelper.UpdateWorkStatusToQueueStore(new WorkStoreHelper.WorkReviewQueueEntity(ls.StudentID, ls.Works[0].WorkID, ls.Works[0].Status, null, storeFielPath));
            //                        }
            //                        else
            //                        {
            //                            failure++;
            //                            listFailure.Add(string.Format("[{0},{1}] {2} {3}", ls.StudentName, ls.StudentCode, ls.Works[0].WorkName, content));
            //                        }
            //                        this.OnChanged(string.Format("上传：[{0},{1}]作品[{2}] {3}", ls.StudentName, ls.StudentCode, ls.Works[0].WorkName, complete ? "成功" : "失败"));
            //                    }
            //                    else
            //                    {
            //                        this.OnChanged(string.Format("已上传：[{0},{1}]作品[{2}]", ls.StudentName, ls.StudentCode, ls.Works[0].WorkName));
            //                    }
            //                }
            //                else
            //                {
            //                    failure++;
            //                    listFailure.Add(string.Format("[{0},{1}] {2} {3}", ls.StudentName, ls.StudentCode, ls.Works[0].WorkName, "未批阅"));
            //                    this.OnChanged(string.Format("不能上传：[{0},{1}]作品[{2}],{3}", ls.StudentName, ls.StudentCode, ls.Works[0].WorkName, "未批阅！"));
            //                }
            //            }
            //            #endregion
            //        }
            //    }
            //}
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            base.OnFormClosing(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        protected override void OnMessageEvent(MessageType type, string content)
        {
            if ((type & MessageType.Normal) == MessageType.Normal)
            {
                this.ThreadSafeMethod(this.lbMessage, new MethodInvoker(delegate()
                {
                    this.lbMessage.Text = string.Empty;
                    this.lbMessage.Text = content;
                }));
            }
            base.OnMessageEvent(type, content);
        }
        #endregion
    }
}