//================================================================================
//  FileName: ModifyWorkDetailsWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/12
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Yaesoft.SFIT;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
using Yaesoft.SFIT.Client.TeaHost.Net;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Poxy;
using Yaesoft.SFIT.Client.TeaHost.Utils;
using Yaesoft.SFIT.Client.TeaHost.Controls;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 学生作品明细。
    /// </summary>
    public partial class ModifyWorkDetailsWindow : BaseWindow, IPluginHost
    {
        #region 成员变量，构造函数。
        private HostNetService hostNetService = null;
        private LoadingPluginService pluginService = null;
        private LocalStudentWorkStore store = null;
        private LocalStudents localStudentCollection = null;
        private bool isPrevEnabled = false, isNextEnabled = false, isDialogResult = false;
        private int index = 0;
        private MouseThumbnailWindow mouseThumbnailWindow = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="store"></param>
        /// <param name="students"></param>
        /// <param name="studentID"></param>
        public ModifyWorkDetailsWindow(ICoreService service, LocalStudentWorkStore store, string studentID)
            : base(service)
        {
            this.pluginService = new LoadingPluginService(service, this);
            //及时加载作业索引文件，同步修改信息。
            this.store = LocalStudentWorkStore.DeSerializer(store.FileSavePath());
            this.localStudentCollection = this.store.HasWorks();
            if (this.localStudentCollection != null && this.localStudentCollection.Count > 0 && !string.IsNullOrEmpty(studentID))
            {
                this.index = this.localStudentCollection.FindIndex(studentID);
            }
            this.InitializeComponent();
        }
        #endregion

        #region 属性。
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
        /// 加载数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyWorkDetailsWindow_Load(object sender, EventArgs e)
        {
            try
            {
                this.CoreService.ForceQuit = false;

                #region 加载插件。
                PluginCfgs plugins = this.CoreService["plugins"] as PluginCfgs;
                if (plugins != null && plugins.Count > 0)
                {
                    PluginCfgs cfgs = plugins.GetPluginCfgs("details");
                    if (cfgs != null && cfgs.Count > 0)
                    {
                        this.pluginService.Load(cfgs);
                        this.Update();
                    }
                }
                #endregion

                #region 加载提示信息。
                this.OnToolTipEvent(this.btnPrev, "快捷键：Alt + ←");
                this.OnToolTipEvent(this.btnSave, "快捷键：Alt + S 或 回车键");
                this.OnToolTipEvent(this.btnDelete, "快捷键：Alt + D");
                this.OnToolTipEvent(this.btnClose, "快捷键：Alt + C 或 ESC");
                this.OnToolTipEvent(this.btnNext, "快捷键：Alt + →");
                this.OnToolTipEvent(this.linkDownloadWork, "快捷键：Alt + V");

                this.OnToolTipEvent(this.chkUpload, "选中，将会弹出作业上传界面！(会影响批阅效率建议批阅完后批量上传到网站)");
                #endregion

                #region 加载数据信息。
                if (this.store != null)
                {
                    #region 设置评阅。
                    Tools.SetEvaluateToWin(this.cbbReviewValue, this.store.Evaluate, new ToolTipHandler(delegate(Control ctrl, string tooltip)
                    {
                        this.OnToolTipEvent(ctrl, tooltip);
                    }));
                    #endregion

                    this.btnSave.Enabled = this.btnDelete.Enabled = false;
                    this.LoadData(this.index);
                }
                #endregion
            }
            catch (Exception x)
            {
                Program.GlobalExceptionHandler(x);
            }
        }
        /// <summary>
        /// 查看附件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkDownloadWork_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LinkLabel link = sender as LinkLabel;
                if (link != null && link.Tag != null && this.store != null)
                {
                    string target = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string dir = this.store.OutputWorkFile(link.Tag.ToString(), target, new RaiseChangedHandler(delegate(string content)
                    {
                        this.OnMessageEvent(MessageType.Normal, content);
                    }));
                    if (Directory.Exists(dir))
                    {
                        System.Diagnostics.Process.Start(dir);
                    }
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, "发生异常：" + x.Message);
                Program.GlobalExceptionHandler(x);
            }
        }
        /// <summary>
        /// 查看图片附件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            this.linkDownloadWork_LinkClicked(this.linkDownloadWork, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.mouseThumbnailWindow != null)
            {
                this.mouseThumbnailWindow.Close();
                this.mouseThumbnailWindow = null;
            }
        }
        /// <summary>
        /// 鼠标进入。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null && this.mouseThumbnailWindow == null)
            {
                Point p = new Point(this.Left + pb.Left + pb.Width + 4, this.Top + 1);
                this.mouseThumbnailWindow = new MouseThumbnailWindow(this.store, pb.Tag as LocalStudent, p);
                this.mouseThumbnailWindow.Show(this);
            }
        }
        /// <summary>
        /// 鼠标移出。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (this.mouseThumbnailWindow != null)
            {
                this.mouseThumbnailWindow.Close();
                this.mouseThumbnailWindow = null;
                this.Focus();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region 设置按钮状态。
                this.btnSave.Enabled = this.btnDelete.Enabled = this.btnClose.Enabled = false;
                if (this.isPrevEnabled)
                {
                    this.btnPrev.Enabled = false;
                }
                if (this.isNextEnabled)
                {
                    this.btnNext.Enabled = false;
                }
                #endregion

                if (this.store != null && this.store.Students != null && this.Tag != null)
                {
                    LocalStudent ls = this.Tag as LocalStudent;
                    if (ls != null && ls.HasWork())
                    {
                        #region 装载数据。
                        ls.Work.WorkName = this.txtWorkName.Text.Trim();
                        ls.Work.Type = (this.chkPublic.Checked ? EnumWorkType.Public : EnumWorkType.Protected);
                        ls.Work.Description = this.txtDescription.Text.Trim();
                        if ((ls.Work.Review = Tools.GetEvaluateFromWin(this.store, this.cbbReviewValue, this.txtSubjectiveReviews)) != null)
                        {
                            ls.Work.Status |= EnumWorkStatus.Review;
                        }
                        else if ((ls.Work.Status & EnumWorkStatus.Review) == EnumWorkStatus.Review)
                        {
                            ls.Work.Status &= ~EnumWorkStatus.Review;
                        }
                        if (this.chkPublish.Checked)
                        {
                            ls.Work.Status |= EnumWorkStatus.Release;
                        }
                        else if ((ls.Work.Status & EnumWorkStatus.Release) == EnumWorkStatus.Release)
                        {
                            ls.Work.Status &= ~EnumWorkStatus.Release;
                        }
                        if (((int)ls.Work.Status) < -1)
                        {
                            ls.Work.Status = EnumWorkStatus.Recive;
                        }
                        #endregion

                        WorkStoreHelper.UpdateWorkInfoQueueEntity entity = new WorkStoreHelper.UpdateWorkInfoQueueEntity(ls.StudentID, ls.Work, this.store.FileSavePath(), this.chkUpload.Checked);
                        entity.Changed += new RaiseChangedHandler(delegate(string msg)
                        {
                            this.OnMessageEvent(MessageType.Normal, msg);
                        });
                        entity.UpdateComplete += new WorkStoreHelper.UpdateWorkInfoCompleteHandler(delegate(StudentEx student, bool upload)
                        {
                            if (this.NetService != null) this.NetService.OnUpdateControls(student);
                            if (upload)
                            {
                                this.ThreadSafeMethod(new MethodInvoker(delegate()
                                {
                                    WorkUploadToServer win = new WorkUploadToServer(this.CoreService, this.store, new string[] { ls.StudentID });
                                    win.StartPosition = FormStartPosition.CenterParent;
                                    win.Changed += new RaiseChangedHandler(delegate(string msg)
                                    {
                                        this.OnMessageEvent(MessageType.Normal, msg);
                                    });
                                    win.ShowDialog(this);
                                }));
                            }
                        });
                        WorkStoreHelper.UpdateWorkInfoToQueueStore(entity);
                        this.OnMessageEvent(MessageType.Normal, string.Format("开始保存[{0}]作品[{1}]...！", ls.StudentName, ls.Work.WorkName));
                        this.isDialogResult = true;
                    }
                }
            }
            catch (Exception x)
            {
                Program.GlobalExceptionHandler(x);
                this.OnMessageEvent(MessageType.Normal, "发生异常：" + x.Message);
            }
            finally
            {
                this.btnSave.Enabled = this.btnDelete.Enabled = this.btnClose.Enabled = true;
                if (this.isPrevEnabled)
                {
                    this.btnPrev.Enabled = this.isPrevEnabled;
                }
                if (this.isNextEnabled)
                {
                    this.btnNext.Enabled = this.isNextEnabled;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "确认删除？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    if (this.store != null && this.store.Students != null && this.localStudentCollection != null && this.Tag != null)
                    {
                        LocalStudent ls = this.Tag as LocalStudent;
                        if (ls != null)
                        {
                            WorkStoreHelper.DeleteWorkQueueEntity entity = new WorkStoreHelper.DeleteWorkQueueEntity(ls.StudentID, ls.Work.WorkID, this.store.FileSavePath());
                            entity.Changed += new RaiseChangedHandler(delegate(string msg)
                            {
                                this.OnMessageEvent(MessageType.Normal, msg);
                            });
                            if (this.NetService != null) entity.UpdateControls += this.NetService.OnUpdateControls;
                            WorkStoreHelper.DeleteWorkToQueueStore(entity);
                            this.OnMessageEvent(MessageType.Normal, string.Format("开始删除作业[{0},{1}]...", ls.StudentName, ls.Work.WorkName));
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                    this.btnClose_Click(sender, e);
                }
            }
            catch (Exception x)
            {
                Program.GlobalExceptionHandler(x);
                this.OnMessageEvent(MessageType.Normal, "发生异常：" + x.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.index--;
            this.LoadData(this.index);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.index++;
            this.LoadData(this.index);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.isDialogResult)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyWorkDetailsWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.V:
                        {
                            if (this.linkDownloadWork.Enabled)
                            {
                                this.linkDownloadWork_LinkClicked(this.linkDownloadWork, null);
                            }
                        } 
                        break;
                    case Keys.S:
                        {
                            //保存。
                            if (this.btnSave.Enabled)
                            {
                                this.btnSave_Click(this.btnSave, e);
                            }
                        }
                        break;
                    case Keys.D:
                        {
                            //删除。
                            if (this.btnDelete.Enabled)
                            {
                                this.btnDelete_Click(this.btnDelete, e);
                            }
                        }
                        break;
                    case Keys.C:
                        {
                            //关闭。
                            if (this.btnClose.Enabled)
                            {
                                this.btnClose_Click(this.btnClose, e);
                            }
                        }
                        break;
                    case Keys.Left:
                        {
                            //上一个。
                            if (this.btnPrev.Enabled)
                            {
                                this.btnPrev_Click(this.btnPrev, e);
                            }
                        }
                        break;
                    case Keys.Right:
                        {
                            //下一个。
                            if (this.btnNext.Enabled)
                            {
                                this.btnNext_Click(this.btnNext, e);
                            }
                        }
                        break;
                }
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="index">学生索引。</param>
        private void LoadData(int index)
        {
            lock (this)
            {
                if (this.store == null) return;

                this.isDialogResult = false;

                this.store = LocalStudentWorkStore.DeSerializer(this.store.FileSavePath());

                if (this.store.Students != null && this.localStudentCollection != null)
                {
                    this.Tag = null;
                    int count = this.localStudentCollection.Count;
                    this.isPrevEnabled = this.btnPrev.Enabled = (index > 0);
                    this.isNextEnabled = this.btnNext.Enabled = (index < (count - 1));
                    if ((index > -1) && (index < count))
                    {
                        LocalStudent ls = this.localStudentCollection[index];
                        if (ls != null)
                        {
                            ls = this.store.Students[ls.StudentID];
                            if (ls != null)
                            {
                                this.Tag = ls;

                                #region 填充数据。
                                LocalStudentWork lsw = ls.Work;
                                this.linkDownloadWork.Tag = ls.StudentID;
                                if (lsw != null)
                                {
                                    this.Title = this.txtWorkName.Text = lsw.WorkName;
                                    this.txtWorkstatusName.Text = EnumWorkStatusOperaTools.GetStatusName(lsw.Status);
                                    this.txtUploadIP.Text = lsw.UploadIP;
                                    this.chkPublic.Checked = (lsw.Type == EnumWorkType.Public);
                                    this.txtTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", lsw.Time);
                                    //this.txtCheckCode.Text = lsw.CheckCode;
                                    this.txtDescription.Text = lsw.Description == null ?  new CDATA() : lsw.Description;
                                    this.chkPublish.Checked = ((lsw.Status & EnumWorkStatus.Release) == EnumWorkStatus.Release);
                                }
                                else
                                {
                                    this.Title = this.txtWorkName.Text = string.Empty;
                                    this.txtWorkstatusName.Text = string.Empty;
                                    this.txtUploadIP.Text = string.Empty;
                                    this.chkPublic.Checked = false;
                                    this.txtTime.Text = string.Empty;
                                    //this.txtCheckCode.Text = string.Empty;
                                    this.txtDescription.Text = string.Empty;
                                    this.chkPublish.Checked = false;
                                }
                                this.OnToolTipEvent(this.txtWorkName, string.Format("所属科目：{0}", this.store.CatalogName));
                                this.txtStudentName.Text = string.Format("{0}[{1}]", ls.StudentName, ls.StudentCode);
                                this.OnToolTipEvent(this.txtStudentName, string.Format("所属年级：{0},所属班级：{1}", this.store.GradeName, this.store.ClassName));
                                #endregion

                                #region 加载缩略图。
                                int len = 0;
                                if (lsw.WorkFiles != null && (len = lsw.WorkFiles.Count) > 0)
                                {
                                    this.pictureBox.Image = ThumbnailsHelpers.CreateThumbnailFrist(this.store, ls.StudentID, 200, 150);
                                    this.pictureBox.Tag = ls;
                                    this.OnToolTipEvent(this.pictureBox, "学生作品缩略图，双击将查看作品文件！");
                                }
                                else
                                {
                                    this.pictureBox.Image = null;
                                }
                                #endregion

                                this.linkDownloadWork.Text = string.Format(this.linkDownloadWork.Text, len);

                                #region 加载评阅信息。
                                this.cbbReviewValue.SelectedIndex = -1;
                                this.txtSubjectiveReviews.Text = string.Empty;
                                if (this.store.Evaluate != null && lsw.Review != null)
                                {
                                    this.txtSubjectiveReviews.Text = lsw.Review.SubjectiveReviews;
                                    if (this.store.Evaluate.Type == EnumEvaluateType.Hierarchy)
                                    {
                                        if (!string.IsNullOrEmpty(lsw.Review.ReviewValue))
                                        {
                                            this.cbbReviewValue.SelectedValue = lsw.Review.ReviewValue;
                                        }
                                    }
                                    else
                                    {
                                        this.cbbReviewValue.Text = lsw.Review.ReviewValue;
                                    }
                                }
                                #endregion

                            }
                            else
                            {
                                this.OnMessageEvent(MessageType.PopupInfo, "该学生或被删除，请刷新界面或重新查询！");
                                this.btnClose_Click(this.btnClose, null);
                            }
                        }
                    }
                    this.btnDelete.Enabled = this.btnSave.Enabled = (this.Tag != null);
                }
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        protected override void OnMessageEvent(MessageType type, string content)
        {
            if ((type & MessageType.Normal) == MessageType.Normal)
            {
                if (this.pluginService != null)
                    this.pluginService.SendCrossPluginData(this, new CrossPluginEventArgs(DockStyle.Bottom, new object[] { "msg", content }));
            }
            base.OnMessageEvent(type, content);
        }
        #endregion

        #region IPluginHost 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="plug"></param>
        public void AddPlugin(DockStyle position, IWindow plug)
        {
            if (position == DockStyle.Bottom)
            {
                this.AddUseControls(this.panelBottom, plug);
            }
        }

        #endregion        
    }
}