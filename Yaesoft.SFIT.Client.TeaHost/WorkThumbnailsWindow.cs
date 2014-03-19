//================================================================================
//  FileName: WorkThumbnailsWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/6
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
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
using Yaesoft.SFIT.Client.TeaHost.Net;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Poxy;
using Yaesoft.SFIT.Client.TeaHost.Controls;
using Yaesoft.SFIT.Client.TeaHost.Utils;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 作品缩略图。
    /// </summary>
    public partial class WorkThumbnailsWindow : BaseWindow,IPluginHost
    {
        #region 成员变量，构造函数。
        private string strTitle, classID, catalogID; 
        private Size oldSize = Size.Empty;
        private HostNetService hostNetService = null;
        private LoadingPluginService pluginService = null;
        private ThumbnailsControls thumbnailsControls = null;
        private LocalStudentWorkStore store = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="classID"></param>
        /// <param name="catalogID"></param>
        /// <param name="title"></param>
        public WorkThumbnailsWindow(ICoreService service, string title, string classID, string catalogID)
            : base(service)
        {
            this.strTitle = title;
            this.classID = classID;
            this.catalogID = catalogID;
            this.pluginService = new LoadingPluginService(this.CoreService, this);
            
            InitializeComponent();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取用户信息。
        /// </summary>
        protected UserInfo UserInfo
        {
            get { return this.CoreService["userinfo"] as UserInfo; }
        }
        /// <summary>
        ///获取网络主机服务。
        /// </summary>
        internal HostNetService NetService
        {
            get
            {
                if (this.hostNetService == null)
                    this.hostNetService = HostNetService.Instance(this.CoreService); 
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
        private void WorkThumbnailsWindow_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            if (!string.IsNullOrEmpty(this.strTitle))
            {
                this.Text += "-" + this.strTitle;
            }

            #region 加载插件。
            PluginCfgs plugins = this.CoreService["plugins"] as PluginCfgs;
            if (plugins != null && plugins.Count > 0)
            {
                PluginCfgs cfgs = plugins.GetPluginCfgs("thumbnails");
                if (cfgs != null && cfgs.Count > 0)
                {
                    this.pluginService.Load(cfgs);
                    this.Update();
                }
            }
            #endregion

            #region 加载数据。
            this.OnToolTipEvent(this.chkPublish, "选中发布后，只有作品类型为公开且已经评阅的方将状态设置为发布！");
            UserInfo info = this.UserInfo;
            if (info != null) this.LoadData(info.UserID, this.catalogID, this.classID); 
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelWork_Resize(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null && p.HasChildren && this.thumbnailsControls != null)
            {
                int span = Math.Abs(p.Size.Width - this.oldSize.Width);
                if ((this.oldSize != Size.Empty) && span > 15)
                {
                    ThumbnailsDrawToPanel(this.thumbnailsControls, p);
                }
                this.oldSize = p.Size;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSelectedAll_Click(object sender, EventArgs e)
        {
            CheckBox obj = sender as CheckBox;
            if (obj != null) SetAllThumbnailsSelected(this.panelWork, obj.Checked);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPublish_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPublish.Checked) this.chkUpload.Checked = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string btnStr = string.Empty;
            try
            {
                if (btn != null)
                {
                    btnStr = btn.Text;
                    btn.Text = "处理中...";
                    btn.Enabled = false;
                }
                string[] checkStudentWorks = GetSelectedThumbnails(this.panelWork);
                if (checkStudentWorks == null || checkStudentWorks.Length == 0)
                {
                    this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, "请选中学生作业后方可保存！");
                    btn.Text = btnStr;
                    btn.Enabled = true;
                    return;
                }
                LocalWorkReview teaReview = Tools.GetEvaluateFromWin(this.store, this.cbbReviewValue, this.txtSubjectiveReviews);
                if (teaReview == null)
                {
                    this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, "请评阅后方可保存！");
                    btn.Text = btnStr;
                    btn.Enabled = true;
                    return;
                }
                btn.Text = "保存中..";
                bool bPublish = this.chkPublish.Checked, bUpload = this.chkUpload.Checked;
                this.store = LocalStudentWorkStore.DeSerializer(this.store.FileSavePath());
                for (int i = 0; i < checkStudentWorks.Length; i++)
                {
                    LocalStudent ls = this.store.Students[checkStudentWorks[i]];
                    if (ls != null && ls.Work != null)
                    {
                        WorkStoreHelper.WorkReviewQueueEntity entity = new WorkStoreHelper.WorkReviewQueueEntity(ls.StudentID,
                                                                                                         ls.Work.WorkID,
                                                                                                         bPublish ? (EnumWorkStatus.Review | EnumWorkStatus.Release) : EnumWorkStatus.Review,
                                                                                                         teaReview,
                                                                                                         this.store.FileSavePath());
                        entity.Changed += new RaiseChangedHandler(delegate(string msg)
                        {
                            this.OnMessageEvent(MessageType.Normal, msg);
                        });
                        //添加到保存队列。
                        WorkStoreHelper.ReviewWorkToQueueStore(entity);
                        this.OnMessageEvent(MessageType.Normal, string.Format("开始保存[{0},{1}]作业批阅...",ls.StudentName, ls.Work.WorkName));
                    }
                }

                if (bUpload)
                {
                    btn.Text = "上传中...";
                    WorkUploadToServer win = new WorkUploadToServer(this.CoreService, this.store, checkStudentWorks);
                    win.StartPosition = FormStartPosition.CenterParent;
                    win.Changed += new RaiseChangedHandler(delegate(string msg)
                    {
                        this.OnMessageEvent(MessageType.Normal, msg);
                    });
                    win.ShowDialog(this);
                }

                btn.Text = "刷新状态...";
                //刷新学生作品评阅状态。
                for (int i = 0; i < checkStudentWorks.Length; i++)
                {
                    StudentEx stuEx = Program.STUDENTS != null ? Program.STUDENTS[checkStudentWorks[i]] : null;
                    if (stuEx != null && ((stuEx.Status & StudentControl.EnumStudentState.Review) != StudentControl.EnumStudentState.Review))
                    {
                        stuEx.Status |= StudentControl.EnumStudentState.Review;
                        if (this.NetService != null) this.NetService.OnUpdateControls(stuEx);
                    }
                }

                //
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                Program.GlobalExceptionHandler(ex);
                this.OnMessageEvent(MessageType.Normal, "发生异常：" + ex.Message);
            }
            finally
            {
                if (btn != null)
                {
                    btn.Text = btnStr;
                    btn.Enabled = true;
                }
            }
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

        #region 辅助函数。
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="catalogID"></param>
        /// <param name="classID"></param>
        private void LoadData(string teacherID,string catalogID, string classID)
        {
            if (!string.IsNullOrEmpty(teacherID) && !string.IsNullOrEmpty(catalogID) && !string.IsNullOrEmpty(classID))
            {
                this.store = LocalStudentWorkStore.DeSerializer(teacherID, catalogID, classID);
                if ((this.btnSave.Enabled = (this.store != null)))
                {
                    Tools.SetEvaluateToWin(this.cbbReviewValue, this.store.Evaluate, new ToolTipHandler(delegate(Control ctrl, string tooltip)
                    {
                        this.OnToolTipEvent(ctrl, tooltip);
                    }));
                    this.thumbnailsControls = BuildThumbnails(this.store, new EventHandler(delegate(object sender, EventArgs e)
                    {
                        ThumbnailsControl tc = sender as ThumbnailsControl;
                        if (tc != null && this.store != null)
                        {
                            ModifyWorkDetailsWindow mw = new ModifyWorkDetailsWindow(this.CoreService, this.store, tc.StudentID);
                            mw.StartPosition = FormStartPosition.CenterParent;
                            UserInfo info = this.UserInfo;
                            if (mw.ShowDialog(this) == DialogResult.OK && info != null)
                            {
                                this.LoadData(info.UserID, this.catalogID, this.classID);
                            }
                        }
                    }));
                    if (this.thumbnailsControls != null) ThumbnailsDrawToPanel(this.thumbnailsControls, this.panelWork);
                }
            }
        }
        #endregion

        #region 静态辅助函数。
        /// <summary>
        /// 获取选中的缩略图学生ID集合。
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        private static string[] GetSelectedThumbnails(Panel panel)
        {
            if (panel != null && panel.HasChildren)
            {
                List<string> list = new List<string>();
                foreach (Control c in panel.Controls)
                {
                    ThumbnailsControl tc = c as ThumbnailsControl;
                    if (tc != null && tc.Checked)
                    {
                        if (!string.IsNullOrEmpty(tc.StudentID) && !list.Contains(tc.StudentID))
                        {
                            list.Add(tc.StudentID);
                        }
                    }
                }
                return list.ToArray();
            }
            return null;
        }
        /// <summary>
        /// 设置所有缩略图选择状态。
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="selected"></param>
        private static void SetAllThumbnailsSelected(Panel panel, bool selected)
        {
            if (panel != null && panel.HasChildren)
            {
                foreach (Control c in panel.Controls)
                {
                    ThumbnailsControl tc = c as ThumbnailsControl;
                    if (tc != null && tc.Checked != selected)
                    {
                        tc.Checked = selected;
                        tc.Update();
                    }
                }
            }
        }
        /// <summary>
        /// 将作品缩略图对象集合绘制到面板上。
        /// </summary>
        /// <param name="thumbnails"></param>
        /// <param name="panel"></param>
        private static void ThumbnailsDrawToPanel(ThumbnailsControls thumbnails, Panel panel)
        {
            if (thumbnails != null && thumbnails.Count > 0 && panel != null)
            {
                panel.SuspendLayout();
                if (panel.HasChildren)
                {
                    panel.Controls.Clear();
                }
                thumbnails.DrawToPanel(panel, 3, 4);
                panel.ResumeLayout();
            }
        }
        private static ThumbnailsControls BuildThumbnails(LocalStudentWorkStore store, EventHandler doubleClickHandler)
        {
            if (store != null && store.Students != null && store.Students.Count > 0)
            {
                ThumbnailsControls thumbnails = new ThumbnailsControls();

                for (int i = 0; i < store.Students.Count; i++)
                {
                    ThumbnailsControl tc = BuildThumbnail(store, store.Students[i]);
                    if (tc != null)
                    {
                        tc.Cursor = Cursors.Hand;
                        if (doubleClickHandler != null) tc.DoubleClick += doubleClickHandler;
                        thumbnails.Add(tc);
                    }
                }
                return thumbnails;
            }
            return null;
        }
        private static ThumbnailsControl BuildThumbnail(LocalStudentWorkStore store, LocalStudent ls)
        {
            if (store == null || ls == null) return null;
            if (ls.Work != null)
            {
                ThumbnailsControl control = new ThumbnailsControl();
                Image img = ThumbnailsHelpers.CreateThumbnailFrist(store, ls.StudentID, control.Width, control.Height);
                if (img != null)
                {
                    control.WorkID = ls.Work.WorkID;
                    control.StudentID = ls.StudentID;
                    control.Text = ls.Work.WorkName;
                    control.StudentName = ls.StudentName;
                    control.Time = ls.Work.Time;
                    control.ToolTip = string.Format("学生姓名：{0}\r\n作品名称：{1}\r\n目录名称：{2}\r\n作品状态：{3}\r\n作品类型：{4}\r\n描述：{5}\r\n提交时间：{6:yyyy-MM-dd HH:mm:ss}",
                        ls.StudentName, ls.Work.WorkName, store.CatalogName, EnumWorkStatusOperaTools.GetStatusName(ls.Work.Status), EnumWorkTypeOperaTools.GetTypeName(ls.Work.Type),
                        ls.Work.Description, ls.Work.Time);
                    control.Thumbnails = img;
                    return control;
                }
            }
            return null;
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
                {
                    this.pluginService.SendCrossPluginData(this, new CrossPluginEventArgs(DockStyle.Bottom, new object[] { "msg", content }));
                }
            }
            base.OnMessageEvent(type, content);
        }
        #endregion
    }
}