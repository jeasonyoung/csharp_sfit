//================================================================================
//  FileName: ModifyWorkWindow.cs
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
using System.Threading;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Utils;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 作品评阅管理。
    /// </summary>
    public partial class ModifyWorkWindow : BaseWindow, IPluginHost
    {
        #region 成员变量，构造函数。
        UserInfo userInfo = null;
        LocalStudentWorkStore store = null;
        LoadingPluginService pluginService = null;
        WorkThumbnailsWindow workThumbnailsWindow = null;
        string classID = null, catalogID = null;
        LocalStudents students = null;
        ListViewColumnSorter columnSorter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="userInfo"></param>
        public ModifyWorkWindow(ICoreService service)
            : this(service, null, null)
        {

        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="classID"></param>
        /// <param name="catalogID"></param>
        public ModifyWorkWindow(ICoreService service, string classID, string catalogID)
            : base(service)
        {
            this.classID = classID;
            this.catalogID = catalogID;
            this.userInfo = this.CoreService["userinfo"] as UserInfo;

            this.pluginService = new LoadingPluginService(service, this);
            this.InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyWorkWindow_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;

            #region 加载插件。
            PluginCfgs plugins = this.CoreService["plugins"] as PluginCfgs;
            if (plugins != null && plugins.Count > 0)
            {
                PluginCfgs cfgs = plugins.GetPluginCfgs("work");
                if (cfgs != null && cfgs.Count > 0)
                {
                    this.pluginService.Load(cfgs);
                    this.Update();
                }
            }
            #endregion

            #region 视图。
            if (this.cbbView != null)
            {
                this.cbbView.DataSource = ListViewModel.Models;
                this.cbbView.DisplayMember = "Text";
                this.cbbView.ValueMember = "View";
            }
            if (this.listView != null && (this.cbbView.SelectedItem is ListViewModel))
            {
                this.listView.View = ((ListViewModel)this.cbbView.SelectedItem).View;
            }
            #endregion

            #region 数据加载。
            if (this.listView != null)
            {
                this.listView.Columns.Add("学生名称");
                this.listView.Columns.Add("作品名称");
                this.listView.Columns.Add("状态");
                this.listView.Columns.Add("时间");
                this.listView.Columns.Add("评阅");
                this.listView.Columns.Add("描述");
                this.listView.ListViewItemSorter = this.columnSorter = new ListViewColumnSorter();
            }
            this.LoadLeftTreeData(this.CoreService["teasyncdata"] as TeaSyncData);
            #endregion

            #region 默认数据处理。
            if (!string.IsNullOrEmpty(this.classID) && !string.IsNullOrEmpty(this.catalogID) && this.treeView != null)
            {
                TreeNode node = null;
                #region 定位节点。
                int len = 0;
                if (this.treeView.Nodes != null && (len = this.treeView.Nodes.Count) > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        TreeNode tn = this.treeView.Nodes[i];
                        if (tn != null && this.LeftTreeNodeValue(tn, "CatalogID") == this.catalogID)
                        {
                            if (tn.Nodes != null && (len = tn.Nodes.Count) > 0)
                            {
                                for (int j = 0; j < len; j++)
                                {
                                    TreeNode n = tn.Nodes[j];
                                    if (n != null && this.LeftTreeNodeValue(n, "ClassID") == this.classID)
                                    {
                                        node = n;
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
                #endregion

                if (node != null)
                {
                    this.treeView.SelectedNode = node;
                    this.treeView_NodeMouseClick(this.treeView, new TreeNodeMouseClickEventArgs(node, MouseButtons.Left, 1, 0, 0));
                }
            }
            #endregion
        }
        /// <summary>
        /// 已批阅。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkReview_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkReview.Checked && !this.chkNoReview.Checked)
            {
                return;
            }
            this.chkNoReview.Checked = !this.chkReview.Checked;
        }
        /// <summary>
        /// 未批阅。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkNoReview_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkReview.Checked && !this.chkNoReview.Checked)
            {
                return;
            }
            this.chkReview.Checked = !this.chkNoReview.Checked;
        }
        /// <summary>
        /// 已上传。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkUpload_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkUpload.Checked && !this.chkNoUpload.Checked)
            {
                return;
            }
            this.chkNoUpload.Checked = !this.chkUpload.Checked;
        }
        /// <summary>
        /// 未上传。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkNoUpload_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkUpload.Checked && !this.chkNoUpload.Checked)
            {
                return;
            }
            this.chkUpload.Checked = !this.chkNoUpload.Checked;
        }
        /// <summary>
        /// 列表模式。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo != null && this.listView != null)
            {
                ListViewModel model = combo.SelectedItem as ListViewModel;
                if (model != null)
                {
                    this.listView.View = model.View;
                    this.listView.Update();
                }
            }
        }
        /// <summary>
        /// 左边菜单树。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null && (e.Button == MouseButtons.Left))
            {
                this.Text = string.Format("{0}|{1}", this.Text.Split('|')[0], e.Node.FullPath);
                this.OnMessageEvent(MessageType.Normal, e.Node.FullPath);
                this.treeView.SelectedNode = e.Node;
                this.btnQuery_Click(sender, e);
            }
        }
        /// <summary>
        /// 查询数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string catalogID = null, classID = null;
            TreeNode node = this.treeView.SelectedNode;
            if (node == null || string.IsNullOrEmpty(classID = this.LeftTreeNodeValue(node, "ClassID")))
            {
                return;
            }
            catalogID = this.LeftTreeNodeValue(node.Parent, "CatalogID");
            this.store = LocalStudentWorkStore.DeSerializer(this.userInfo.UserID, catalogID, classID);
            
            #region 查询数据。
            if (this.store != null && this.store.Students != null)
            {
                string workName = this.txtWorkName.Text.Trim();
                string studentName = this.txtStudentName.Text.Trim();
                EnumWorkStatus status = EnumWorkStatus.None;
                if (this.chkReview.Checked)
                {
                    status |= EnumWorkStatus.Review;
                }
                if (this.chkUpload.Checked)
                {
                    status |= EnumWorkStatus.Upload;
                }
                if (this.chkRelease.Checked)
                {
                    status |= EnumWorkStatus.Release;
                }
                if (status != EnumWorkStatus.None)
                {
                    status &= ~EnumWorkStatus.None;
                }

                this.students = this.store.HasWorks();
                if (!string.IsNullOrEmpty(studentName))
                {
                    this.students = this.students.FindStudents(studentName);
                }
                if (!string.IsNullOrEmpty(workName) || (status != EnumWorkStatus.None))
                {
                    this.students = this.students.FindStudents(workName, status);
                }

                #region 未批阅。
                if (this.chkNoReview.Checked && this.students != null && this.students.Count > 0)
                {//未批阅。
                    List<LocalStudent> list = new List<LocalStudent>();
                    for (int i = 0; i < this.students.Count; i++)
                    {
                        LocalStudent ls = this.students[i];
                        if (ls.HasWork() && ((ls.Work.Status & EnumWorkStatus.Review) == EnumWorkStatus.Review))
                        {
                            list.Add(ls);
                        }
                    }
                    if (list.Count > 0)
                    {
                        this.students.Remove(list.ToArray());
                    }
                }
                #endregion

                #region 未上传。
                if (this.chkNoUpload.Checked && this.students != null && this.students.Count > 0)
                {//未上传。
                    List<LocalStudent> list = new List<LocalStudent>();
                    for (int i = 0; i < this.students.Count; i++)
                    {
                        LocalStudent ls = this.students[i];
                        if (ls.HasWork() && ((ls.Work.Status & EnumWorkStatus.Upload) == EnumWorkStatus.Upload))
                        {
                            list.Add(ls);
                        }
                    }
                    if (list.Count > 0)
                    {
                        this.students.Remove(list.ToArray());
                    }
                }
                #endregion
            }
            #endregion;

            #region 绘制数据。
            this.listView.BeginUpdate();
            this.listView.Items.Clear();
            if (this.store != null && this.students != null && this.students.Count > 0)
            {
                 ImageList images = ThumbnailsHelpers.ThumbnailImageList(this.store, this.students, this.components, 100, 75);
                 this.listView.LargeImageList = images;
                 this.listView.SmallImageList = images;
                 List<ListViewItem> items = new List<ListViewItem>();
                 for (int i = 0; i < this.students.Count; i++)
                 {
                     LocalStudent ls = this.students[i];
                     if (ls.Work != null)
                     {
                         ListViewItem item = new ListViewItem(ls.StudentName, ls.StudentID);
                         item.Tag = ls.StudentID;
                         item.ToolTipText = ls.Work.Description;
                         item.SubItems.Add(ls.Work.WorkName);
                         item.SubItems.Add(EnumWorkStatusOperaTools.GetStatusName(ls.Work.Status));
                         item.SubItems.Add(string.Format("{0:yyyy-MM-dd HH:mm:ss}", ls.Work.Time));
                         if (ls.Work.Review != null)
                         {
                             item.SubItems.Add(string.Format("评阅：{0}", ls.Work.Review.ReviewValue));
                         }
                         item.SubItems.Add(ls.Work.Description);
                         items.Add(item);
                     }
                 }
                 this.listView.Items.AddRange(items.ToArray());
            }
            this.listView.EndUpdate();
            #endregion
        }
        /// <summary>
        /// 启动左边树菜单右键菜单。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip strip = sender as ContextMenuStrip;
            if (strip != null && (strip.SourceControl is TreeView))
            {
                strip.Enabled = !string.IsNullOrEmpty(this.LeftTreeNodeValue(this.treeView.SelectedNode, "ClassID"));
            }
        }
        /// <summary>
        /// 启动列表右键菜单。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStripListView_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip strip = sender as ContextMenuStrip;
            if (strip != null && this.listView != null)
            {
                strip.Enabled = this.listView.Items.Count > 0;
            }
        }
        /// <summary>
        /// 批量批阅处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemBatch_Click(object sender, EventArgs e)
        {
            try
            {
                string classID = null;
                TreeNode node = this.treeView.SelectedNode;
                if (node != null && this.userInfo != null && !string.IsNullOrEmpty(classID = this.LeftTreeNodeValue(node, "ClassID")))
                {
                    string catalogID = this.LeftTreeNodeValue(node.Parent, "CatalogID");
                    this.workThumbnailsWindow = new WorkThumbnailsWindow(this.CoreService, node.FullPath, classID, catalogID);
                    this.workThumbnailsWindow.StartPosition = FormStartPosition.CenterScreen;
                    if (this.workThumbnailsWindow.ShowDialog(this) == DialogResult.OK)
                    {
                        this.btnQuery_Click(this.btnQuery, e);
                    }
                }
            }
            catch (Exception x)
            {
                Program.GlobalExceptionHandler(x);
            }
        }
        /// <summary>
        /// 批量导出处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemOutput_Click(object sender, EventArgs e)
        {
            try
            {
                string classID = null;
                TreeNode node = this.treeView.SelectedNode;
                if (node != null && this.userInfo != null && !string.IsNullOrEmpty(classID = this.LeftTreeNodeValue(node, "ClassID")))
                {
                    this.folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                    if (this.folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        string catalogID = this.LeftTreeNodeValue(node.Parent, "CatalogID");
                        LocalStudentWorkStore workStore = LocalStudentWorkStore.DeSerializer(this.userInfo.UserID, catalogID, classID);
                        if (workStore != null)
                        {
                            workStore.OutputAllWorkFiles(this.folderBrowserDialog.SelectedPath, new RaiseChangedHandler(delegate(string content)
                            {
                                this.OnMessageEvent(MessageType.Normal, content);
                            }));
                        }
                        else
                        {
                            this.OnMessageEvent(MessageType.PopupInfo, "没有数据导出！");
                        }
                    }
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, x.Message);
                Program.GlobalExceptionHandler(x);
            }
        }
        /// <summary>
        /// 批量上传处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemBatchUpload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "将上传已批阅学生作品，您确认？", "批量上传提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                try
                {
                    WorkUploadToServer win = new WorkUploadToServer(this.CoreService, this.store, this.students.ToStudentIDs());
                    win.StartPosition = FormStartPosition.CenterParent;
                    win.Changed += new RaiseChangedHandler(delegate(string msg)
                    {
                        this.OnMessageEvent(MessageType.Normal, msg);
                    });
                    win.ShowDialog(this);
                    this.btnQuery_Click(this.btnQuery, e);
                }
                catch (Exception x)
                {
                    Program.GlobalExceptionHandler(x);
                    this.OnMessageEvent(MessageType.Normal, string.Format("批量上传异常：{0}", x.Message));
                }
            }
        }
        /// <summary>
        /// 删除本节课全部作品。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemAllDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确认删除本节课全部学生作品数据吗？\r\n(删除后将无法恢复，请慎重操作！)", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                try
                {
                    if (this.store != null && this.store.Students != null)
                    {
                        this.store.Students.RemoveAllWorks();
                        if (!WorkStoreHelper.Serializer(ref this.store))
                        {
                            this.OnMessageEvent(MessageType.PopupInfo, "保存到索引文件失败，请稍后再试！");
                            return;
                        }
                        this.btnQuery_Click(this.btnQuery, null);
                    }
                    this.OnMessageEvent(MessageType.Normal, "删除完毕！");
                }
                catch (Exception x)
                {
                    Program.GlobalExceptionHandler(x);
                }
            }
        }
        /// <summary>
        /// 触发列表数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                ListView lv = sender as ListView;
                if (lv != null && lv.SelectedItems != null && lv.SelectedItems.Count > 0 && this.store != null && this.students != null)
                {
                    ModifyWorkDetailsWindow win = new ModifyWorkDetailsWindow(this.CoreService, this.store, string.Format("{0}", lv.SelectedItems[0].Tag));
                    win.StartPosition = FormStartPosition.CenterScreen;
                    if (win.ShowDialog(this) == DialogResult.OK)
                    {
                        this.btnQuery_Click(this.btnQuery, e);
                    }
                }
            }
            catch (Exception x)
            {
                Program.GlobalExceptionHandler(x);
            }
        }
        /// <summary>
        /// 触发列排序。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv != null && this.columnSorter != null)
            {
                if (e.Column == this.columnSorter.SortColumnIndex)
                {
                    if (this.columnSorter.Order == SortOrder.Ascending)
                    {
                        this.columnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        this.columnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    this.columnSorter.SortColumnIndex = e.Column;
                    this.columnSorter.Order = SortOrder.Ascending;
                }
                lv.Sort();
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 加载左边树数据。
        /// </summary>
        private void LoadLeftTreeData(TeaSyncData data)
        {
            if (this.userInfo != null && data != null && data.School != null && data.School.Teacher != null)
            {
                Teacher teacher = data.School.Teacher;
                if (teacher.TeacherID.Equals(this.userInfo.UserID, StringComparison.InvariantCultureIgnoreCase))
                {
                    List<TreeNode> roots = new List<TreeNode>();
                    if (teacher.Grades != null && teacher.Grades.Count > 0)
                    {
                        foreach (Grade g in teacher.Grades)
                        {
                            foreach (Catalog catalog in g.Catalogs)
                            {
                                //科目。
                                TreeNode node = new TreeNode();
                                node.Text = node.ToolTipText = string.Format("[{0}]{1}", g.GradeName, catalog.CatalogName);
                                node.Tag = string.Format("CatalogID#{0}", catalog.CatalogID);
                                foreach (Class c in g.Classes)
                                {
                                    //班级。
                                    TreeNode child = new TreeNode();
                                    child.Text = child.ToolTipText = c.ClassName;
                                    child.Tag = string.Format("ClassID#{0}", c.ClassID);
                                    child.ContextMenuStrip = this.contextMenuStrip;
                                    node.Nodes.Add(child);
                                }
                                roots.Add(node);
                            }
                        }
                    }
                    #region 重新加载树。
                    if (this.treeView != null)
                    {
                        this.treeView.BeginUpdate();
                        this.treeView.Nodes.Clear();
                        if (roots != null && roots.Count > 0)
                        {
                            this.treeView.Nodes.AddRange(roots.ToArray());
                        }
                        this.treeView.EndUpdate();
                    }
                    #endregion
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string LeftTreeNodeValue(TreeNode node, string name)
        {
            if (node != null && node.Tag != null && !string.IsNullOrEmpty(name))
            {
                string[] array = node.Tag.ToString().Split('#');
                if (array[0].Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return array[1];
                }
            }
            return null;
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

        #region 内置类。
        /// <summary>
        /// 列表视图模式。
        /// </summary>
        private class ListViewModel
        {
            /// <summary>
            /// 构造函数。
            /// </summary>
            /// <param name="text"></param>
            /// <param name="view"></param>
            public ListViewModel(string text, View view)
            {
                this.Text = text;
                this.View = view;
            }
            /// <summary>
            /// 获取或设置名称。
            /// </summary>
            public string Text { get; set; }
            /// <summary>
            /// 获取或设置显示方式。
            /// </summary>
            public View View { get; set; }

            /// <summary>
            /// 获取视图模式。
            /// </summary>
            public static List<ListViewModel> Models
            {
                get
                {
                    List<ListViewModel> list = new List<ListViewModel>();
                    list.Add(new ListViewModel("缩略图", View.LargeIcon));
                    list.Add(new ListViewModel("平铺", View.Tile));
                    // list.Add(new ListViewModel("图标", View.SmallIcon));
                    list.Add(new ListViewModel("列表", View.List));
                    list.Add(new ListViewModel("详细信息", View.Details));
                    return list;
                }
            }
        }
        #endregion
    }
}