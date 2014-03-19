//================================================================================
//  FileName: StudentMainWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/20
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
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Net;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.Plugins;
using Yaesoft.SFIT.ClientStudent.Forms;
namespace Yaesoft.SFIT.ClientStudent
{
    /// <summary>
    /// 
    /// </summary>
    public partial class StudentMainWindow : BaseWindow, IPluginHost, IReceiveBroadcast, IDisposable
    {
        #region 成员变量，构造函数。
        FileUploadObserver fileUploadObserver = null;
        StudentSendTo sendTo = null;
        LoadingPluginService pluginService = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public StudentMainWindow(ICoreService service)
            : base(service)
        {
            this.fileUploadObserver = new FileUploadObserver();
            this.sendTo = new StudentSendTo();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentMainWindow_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            //this.lbBroadcast.Text = string.Empty;
            this.sendTo.Create();
            this.fileUploadObserver.UpdateFileUpload += this.DragFileObserver;

            this.listView.ListViewItemSorter = new ListViewIndexComparer();
            this.listView.InsertionMark.Color = Color.Red;
            this.listView.AllowDrop = true;

            this.OnMessageEvent(MessageType.Normal, "【请勾选需要上传的作品】");

            #region 用户信息。
            StringBuilder info = new StringBuilder();
            Student stu = this.CoreService["student"] as Student;
            if (stu != null)
            {
                UserInfo userInfo = new UserInfo();
                userInfo.UserID = stu.StudentID;
                userInfo.UserCode = stu.StudentCode;
                userInfo.UserName = stu.StudentName;
                this.CoreService["userinfo"] = userInfo;
                info.AppendFormat("学生姓名：{0}[{1}]", stu.StudentName, stu.StudentCode);
            }
            Catalog c = this.CoreService["catalog"] as Catalog;
            if (c != null)
            {
                if (info.Length > 0)
                    info.Append("\r\n");
                info.AppendFormat("课程目录：{0}({1})", c.CatalogName, c.TypeName);
                this.OnToolTipEvent(this.lbUserinfo, string.Format("知识要点：\r\n{0}", Utilities.BuildKnowledgePointsToolTip(c.Points)));
            }
            if (info.Length > 0)
                info.Append("\r\n");
            info.AppendFormat("教师主机：{0}", this.CoreService["host_ip"]);
            info.Append("\r\n");
            info.AppendFormat("本机名称：{0}", Dns.GetHostName());
            this.lbUserinfo.Text = info.ToString();
            this.OnToolTipEvent(this.lbUserinfo, info.ToString());
            #endregion

            this.btnUpload.Enabled = false;
            #region 插件初始化。
            this.pluginService = new LoadingPluginService(this.CoreService, this);
            PluginCfgs plugins = this.CoreService["plugins"] as PluginCfgs;
            if (plugins != null && plugins.Count > 0)
            {
                PluginCfgs cfgs = plugins.GetPluginCfgs("main");
                if (cfgs != null && cfgs.Count > 0)
                {
                    this.pluginService.Load(cfgs);
                    this.Update();
                }
            }
            #endregion

            #region 初始化鼠标右键。
            if (this.sendTo != null)
            {
                try
                {
                    this.sendTo.Create();
                }
                catch (Exception) { }
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.sendTo != null)
            {
                try
                {
                    this.sendTo.Dispose();
                }
                catch (Exception) { }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentMainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string[] strFileList = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (strFileList != null && strFileList.Length > 0)
            {
                foreach (string file in strFileList)
                {
                    this.fileUploadObserver.AddObserver(file);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentMainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) != null)
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListView lv = sender as ListView;
                if (lv != null)
                {
                    int targetIndex = lv.InsertionMark.Index;
                    if (targetIndex == -1)
                        return;
                    else
                    {
                        lv.BeginUpdate();
                        if (lv.InsertionMark.AppearsAfterItem)
                            targetIndex++;
                        ListViewItem item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                        lv.Items.Insert(targetIndex, (ListViewItem)item.Clone());
                        lv.Items.Remove(item);
                        lv.EndUpdate();
                    }
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] strFileList = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (strFileList != null && strFileList.Length > 0)
                {
                    foreach (string file in strFileList)
                    {
                        this.fileUploadObserver.AddObserver(file);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DragLeave(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv != null)
            {
                lv.BeginUpdate();
                if (lv.SelectedItems != null && lv.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in lv.SelectedItems)
                    {
                        this.fileUploadObserver.Remove(item.Tag as FileUploadItem);
                        lv.Items.Remove(item);
                    }
                }
                lv.InsertionMark.Index = -1;
                lv.EndUpdate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DragOver(object sender, DragEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv != null)
            {
                lv.BeginUpdate();
                Point targetPoint = lv.PointToClient(new Point(e.X, e.Y));
                int targetIndex = lv.InsertionMark.NearestIndex(targetPoint);
                if (targetIndex > -1)
                {
                    Rectangle itemBounds = lv.GetItemRect(targetIndex);
                    if (targetPoint.X > itemBounds.Left + (itemBounds.Width / 2))
                        lv.InsertionMark.AppearsAfterItem = true;
                    else
                        lv.InsertionMark.AppearsAfterItem = false;
                }
                lv.InsertionMark.Index = targetIndex;
                lv.EndUpdate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv != null)
            {
                lv.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv != null && e != null && e.Item != null)
            {
                ListViewItem item = e.Item;
                if (item.Checked)
                {
                    item.BackColor = Color.YellowGreen;
                }
                else
                {
                    item.BackColor = lv.BackColor;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                FileUploadItems items = new FileUploadItems();
                this.listView.BeginUpdate();
                foreach (ListViewItem lvi in this.listView.Items)
                {
                    if (lvi.Checked && (lvi.Tag is FileUploadItem))
                    {
                        items.Add((FileUploadItem)lvi.Tag);
                    }
                }
                this.listView.EndUpdate();
                if (items.Count == 0)
                {
                    this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, "请勾选需要上传的作品附件！");
                    return;
                }
                this.ShowUploadWindowDialog(items);
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.Normal | MessageType.PopupWarn, "发生异常：" + x.Message);
            }
        }
        /// <summary>
        /// 显示上传模态界面。
        /// </summary>
        /// <param name="items"></param>
        public void ShowUploadWindowDialog(FileUploadItems items)
        {
            try
            {
                if (new WorkUploadWindow(this.CoreService, items).ShowDialog(this) == DialogResult.Yes)
                {
                    this.listView.BeginUpdate();
                    foreach (ListViewItem lvi in this.listView.Items)
                    {
                        if (lvi.Checked)
                        {
                            lvi.Checked = false;
                            lvi.ForeColor = Color.Red;
                            lvi.ToolTipText = "已经上传成功！";
                        }
                    }
                    this.listView.EndUpdate();
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.Normal | MessageType.PopupWarn, "发生异常：" + x.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
                this.Hide();
            else
                this.Show();
        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        protected void DragFileObserver(FileUploadItems items)
        {
            if (items != null && items.Count > 0)
            {
                this.listView.BeginUpdate();
                foreach (FileUploadItem fi in items)
                {
                    ListViewItem lvi = new ListViewItem(fi.FileName);
                    lvi.ToolTipText = string.Format("文件名：{0}\r\n后缀名：{1}\r\n文件地址：{2}", fi.FileName, fi.Ext, fi.Path);
                    lvi.Tag = fi;
                    lvi.Checked = true;
                    this.listView.Items.Add(lvi);
                }
                this.listView.EndUpdate();

                if (!this.btnUpload.Enabled)
                {
                    this.btnUpload.Enabled = true;
                }
            }
        }
        /// <summary>
        /// 添加截屏文件。
        /// </summary>
        /// <param name="item"></param>
        public void AddScreenFileObserver(FileUploadItem item)
        {
            this.fileUploadObserver.AddObserver(item);
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void DefWndProc(ref Message m)
        {
            //获取进程间的通讯数据。
            if (m.Msg == ProcessDataComm.WM_COPYDATA)
            {
                CopyDataStruct cds = new CopyDataStruct();
                cds = (CopyDataStruct)m.GetLParam(cds.GetType());
                string data = cds.lpData;
                if (!string.IsNullOrEmpty(data))
                {
                    this.fileUploadObserver.AddObserver(data);
                }
            }
            base.DefWndProc(ref m);
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
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    this.lbMessage.Text = content;
                    this.OnToolTipEvent(this.lbMessage, content);
                }));
            }
            base.OnMessageEvent(type, content);
        }
        #endregion

        #region IReceiveBroadcast 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void ReceiveBroadcast(Broadcast data)
        {
            //if (data != null)
            //{
            //    this.ThreadSafeMethod(this.lbBroadcast, new MethodInvoker(delegate()
            //    {
            //        this.lbBroadcast.Text = data.ToString();
            //        this.lbBroadcast.Update();
            //    }));
            //}
        }
        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 
        /// </summary>
        void IDisposable.Dispose()
        {
            this.sendTo.Dispose();
            base.Dispose();
        }

        #endregion

        #region 内置类。
        /// <summary>
        /// 对ListView里的各项根据索引进行排序。
        /// </summary>
        class ListViewIndexComparer : System.Collections.IComparer
        {

            #region IComparer 成员

            public int Compare(object x, object y)
            {
                if ((x is ListViewItem) && (y is ListViewItem))
                {
                    return ((ListViewItem)x).Index - ((ListViewItem)y).Index;
                }
                return 0;
            }

            #endregion
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
                this.AddBottomPlugin(this.panelPlugins, plug);
            }
        }
        #endregion

        #region 辅助函数。
        int x = 0, y = 0, maxH = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="userControl"></param>
        protected virtual void AddBottomPlugin(Control parent, IWindow userControl)
        {
            UserControl uc = userControl as UserControl;
            if (uc != null)
            {
                uc.Height -= 8;
                uc.Width -= 10;
                int tw = parent.Width, offx = 6, offy = 5;
                if (maxH < uc.Height)
                    maxH = uc.Height;

                if (x + offx + uc.Width > tw)
                {
                    x = offx;
                    y += maxH + offy;
                }
                else
                {
                    x += offx;
                    if (y == 0)
                        y = offy;
                }
                uc.Location = new Point(x, y);
                x += uc.Width;
                this.AddUseControls(parent, (IWindow)uc);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="userControl"></param>
        public override void AddUseControls(Control parent, IWindow userControl)
        {
            if (parent != null && userControl != null)
            {
                parent.SuspendLayout();
                base.AddUseControls(parent, userControl);
                parent.ResumeLayout();
            }
        }
        #endregion

        #region Context处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                bool isCount = this.listView.Items.Count > 0;
                this.selectAllToolStripMenuItem.Enabled = isCount;
                this.invertToolStripMenuItem.Enabled = isCount;
                this.selectRemoveToolStripMenuItem.Enabled = isCount;
                this.removeAllToolStripMenuItem.Enabled = isCount;
                ListView.SelectedListViewItemCollection selectItems = this.listView.SelectedItems;
                if (isCount && (selectItems != null && selectItems.Count > 0))
                {
                    ListViewItem item = selectItems[0];
                    if (item != null)
                    {
                        this.openFiletoolStripMenuItem.Tag = item.Tag as FileUploadItem;
                        this.openFoldertoolStripMenuItem.Tag = item.Tag as FileUploadItem;
                        this.openFiletoolStripMenuItem.Enabled = this.openFoldertoolStripMenuItem.Enabled = isCount;
                    }
                }
                else
                {
                    this.openFiletoolStripMenuItem.Enabled = false;
                    this.openFoldertoolStripMenuItem.Enabled = false;
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, x.Message);
            }
        }  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //全选。
            if (this.listView.Items.Count > 0)
            {
                this.listView.BeginUpdate();
                foreach (ListViewItem lvi in this.listView.Items)
                {
                    lvi.Checked = true;
                }
                this.listView.EndUpdate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //反选。
            if (this.listView.Items.Count > 0)
            {
                this.listView.BeginUpdate();
                foreach (ListViewItem lvi in this.listView.Items)
                {
                    lvi.Checked = !lvi.Checked;
                }
                this.listView.EndUpdate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //移除选中。
            if (this.listView.Items.Count > 0)
            {
                this.listView.BeginUpdate();
                List<ListViewItem> list = new List<ListViewItem>();
                foreach (ListViewItem lvi in this.listView.Items)
                {
                    if (lvi.Checked)
                        list.Add(lvi);
                }
                if (list.Count > 0)
                {
                    foreach (ListViewItem item in list)
                    {
                        this.fileUploadObserver.Remove(item.Tag as FileUploadItem);
                        this.listView.Items.Remove(item);
                    }
                }
                this.listView.EndUpdate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //全部移除。
            if (this.listView.Items.Count > 0)
            {
                this.listView.BeginUpdate();
                this.listView.Items.Clear();
                this.fileUploadObserver.RemoveAll();
                this.listView.EndUpdate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowserFilesAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //浏览文件添加。
            this.openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string[] fileNames = this.openFileDialog.FileNames;
                if (fileNames != null && fileNames.Length > 0)
                {
                    foreach (string strFile in fileNames)
                    {
                        if (File.Exists(strFile))
                        {
                            this.fileUploadObserver.AddObserver(strFile);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowserFoldersAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //浏览目录添加。
            this.folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            if (this.folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.fileUploadObserver.AddObserver(this.folderBrowserDialog.SelectedPath);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFiletoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem menu = sender as ToolStripMenuItem;
                if (menu != null)
                {
                    FileUploadItem item = menu.Tag as FileUploadItem;
                    if (item != null && File.Exists(item.Path))
                    {
                        Process.Start(item.Path);
                    }
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, x.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFoldertoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem menu = sender as ToolStripMenuItem;
                if (menu != null)
                {
                    FileUploadItem item = menu.Tag as FileUploadItem;
                    if (item != null && File.Exists(item.Path))
                    {
                        string folder = Path.GetDirectoryName(item.Path);
                        Process.Start(folder);
                    }
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, x.Message);
            }
        }
        #endregion
    }
}