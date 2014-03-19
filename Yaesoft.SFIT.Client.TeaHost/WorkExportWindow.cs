//================================================================================
//  FileName: WorkExportWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/16
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
using System.Threading;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Utils;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 作品数据导出。
    /// </summary>
    public partial class WorkExportWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public WorkExportWindow(ICoreService service)
            : base(service)
        {
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkExportWindow_Load(object sender, EventArgs e)
        {
            try
            {
                this.panelBottom.Visible = false;
                this.LoadData(this.CoreService["teasyncdata"] as TeaSyncData, this.chkStudents.Checked);
                this.btnExport.Enabled = (this.treeView != null && this.treeView.Nodes != null && this.treeView.Nodes.Count > 0);
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, string.Format("发生异常：\r\n{0}", x.Message));
                Program.GlobalExceptionHandler(x);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkStudents_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = null;
            try
            {
                if ((box = sender as CheckBox) != null)
                {
                    box.Enabled = false;
                    this.LoadData(this.CoreService["teasyncdata"] as TeaSyncData, box.Checked);
                }   
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, string.Format("发生异常：\r\n{0}", x.Message));
                Program.GlobalExceptionHandler(x);
            }
            finally
            {
                if (box != null)
                {
                    box.Enabled = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                Tools.SetTreeNodeCheckedStatus(e.Node, e.Node.Checked);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo info = this.CoreService["userinfo"] as UserInfo;
                if (info != null && this.treeView.Nodes != null && this.treeView.Nodes.Count > 0)
                {
                    List<TreeNode> list = new List<TreeNode>();
                    foreach (TreeNode node in this.treeView.Nodes)
                    {
                        this.CheckedTreeViewNodes(node, list);
                    }
                    if (this.panelBottom.Visible = (list.Count > 0))
                    {
                        this.saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
                            {
                                ExportWorkUtils export = new ExportWorkUtils(info.UserID, list);
                                export.Export(this.saveFileDialog.FileName, new RaiseChangedHandler(delegate(string content)
                                {
                                    this.OnMessageEvent(MessageType.Normal, content);
                                }));
                                this.ThreadSafeMethod(new MethodInvoker(delegate()
                                {
                                    MessageBox.Show(this, "导出数据完成！", this.Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    this.Close();
                                }));
                            }));
                        }
                    }
                    else
                    {
                        this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, "请选中需要导出的数据！");
                    }
                }
            }
            catch (Exception x)
            {
                Program.GlobalExceptionHandler(x);
                this.OnMessageEvent(MessageType.Normal, "导出的数据发生异常：" + x.Message);
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bShowStudents"></param>
        void LoadData(TeaSyncData data, bool bShowStudents)
        {
            if (data != null && data.School != null && data.School.Teacher != null)
            {
                List<TreeNode> roots = new List<TreeNode>();
                Teacher teacher = data.School.Teacher;
                if (teacher.Grades != null && teacher.Grades.Count > 0)
                {
                    foreach (Grade g in teacher.Grades)
                    {
                        foreach (Class c in g.Classes)
                        {
                            TreeNode node = new TreeNode();
                            node.Text = node.ToolTipText = string.Format("{0}[{1}]", c.ClassName, g.GradeName);
                            node.Tag = string.Format("ClassID#{0}", c.ClassID);
                            //科目。
                            foreach (Catalog catalog in g.Catalogs)
                            {
                                TreeNode child = new TreeNode();
                                child.Text = child.ToolTipText = catalog.CatalogName;
                                child.Tag = string.Format("CatalogID#{0}", catalog.CatalogID);
                                if (bShowStudents && c.Students != null)
                                {
                                    foreach (Student s in c.Students)
                                    {
                                        TreeNode sn = new TreeNode();
                                        sn.Text = child.ToolTipText = string.Format("{0}[{1}]", s.StudentName, s.StudentCode);
                                        sn.Tag = string.Format("StudentID#{0}", s.StudentID);
                                        child.Nodes.Add(sn);
                                    }
                                }
                                node.Nodes.Add(child);
                            }
                            //添加。
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="chkList"></param>
        void CheckedTreeViewNodes(TreeNode node,List<TreeNode> chkList)
        {
            if (node != null)
            {
                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    foreach (TreeNode p in node.Nodes)
                    {
                        this.CheckedTreeViewNodes(p, chkList);
                    }
                }
                else if (node.Checked && chkList != null)
                {
                    chkList.Add(node);
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
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    this.lbMessage.Text = content;
                }));
            }
            base.OnMessageEvent(type, content);
        }
        #endregion

        
    }
}