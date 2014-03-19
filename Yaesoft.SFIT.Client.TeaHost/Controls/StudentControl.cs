//================================================================================
//  FileName: StudentControl.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/1
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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.ComponentModel;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Controls;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Controls
{
    /// <summary>
    /// 拖拽事件委托。
    /// </summary>
    /// <param name="sc"></param>
    /// <param name="urls"></param>
    public delegate void DragDropEventHandler(StudentControl sc, string[] urls);
    /// <summary>
    /// 右键菜单事件委托。
    /// </summary>
    /// <param name="sc"></param>
    /// <param name="type"></param>
    public delegate void ContextMenuEventHandler(StudentControl sc, StudentControl.EnumContextMenuType type);
    /// <summary>
    /// 学生控件。
    /// </summary>
    public class StudentControl : RoundRectBox
    {
        #region 成员变量，构造函数。
        EnumStudentState state;
        private ContextMenuStrip contextMenuStrip;
        private IContainer components;
        private ToolStripMenuItem menuItemOffline, menuItemTemplateDelete;
        MonitorUIColorSettings colorSettings;
       // FiveStartControlGroup fiveStartControlGroup = null;
        /// <summary>
        ///构造函数。
        /// </summary>
        public StudentControl()
            : base()
        {
            this.state = EnumStudentState.Offline;
            this.colorSettings = new MonitorUIColorSettings();
            this.MouseMoveColor = this.colorSettings.MoveColor;

            this.InitializeComponent();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置计算机名称。
        /// </summary>
        [Category("Data")]
        [Description("获取或设置计算机名称。")]
        public string MachineName { get; set; }
        /// <summary>
        /// 获取或设置用户IP。
        /// </summary>
        [Category("Data")]
        [Description("获取或设置用户IP。")]
        public string UserIP { get; set; }
        /// <summary>
        /// 获取或设置用户信息。
        /// </summary>
        [Category("Data")]
        [Description("获取或设置用户信息。")]
        public UserInfo UserInfo { get; set; }
        /// <summary>
        /// 获取或设置颜色设置。
        /// </summary>
        [Category("Styles")]
        [Description("获取或设置颜色设置。")]
        public MonitorUIColorSettings ColorSettings
        {
            get { return this.colorSettings; }
            set
            {
                if (value != null)
                {
                    this.colorSettings = value;
                    this.MouseMoveColor = this.colorSettings.MoveColor;
                }
            }
        }
        /// <summary>
        /// 获取或设置状态。
        /// </summary>
        [Category("State")]
        [Description("获取或设置状态。")]
        public EnumStudentState State
        {
            get { return this.state; }
            set
            {
                this.BackColor = this.CreateBackgroundColor(this.state = value);
                //this.OnPropertyChanged(string.Format("学生机状态${0}|课堂纪律${1}颗星", EnumStudentStateOperaTools.GetCHName(this.state), this.fiveStartControlGroup.CheckCount));
                this.OnPropertyChanged(string.Format("学生机状态${0}", EnumStudentStateOperaTools.GetCHName(this.state)));
            }
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 拖拽数据处理。
        /// </summary>
        public event DragDropEventHandler DragDropData;
        /// <summary>
        /// 触发拖拽数据处理。
        /// </summary>
        /// <param name="urls"></param>
        protected void OnDragDropData(string[] urls)
        {
            DragDropEventHandler handler = this.DragDropData;
            if (handler != null && (urls != null && urls.Length > 0))
            {
                handler(this, urls);
            }
        }
        /// <summary>
        /// 右键菜单事件。
        /// </summary>
        public event ContextMenuEventHandler ContextHandler;
        /// <summary>
        /// 触发右键菜单处理。
        /// </summary>
        /// <param name="type"></param>
        protected void OnContextHandler(EnumContextMenuType type)
        {
            ContextMenuEventHandler handler = this.ContextHandler;
            if (handler != null)
            {
                handler(this, type);
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 获取或设置提示文本。
        /// </summary>
        public override string Text
        {
            get
            {
                if (string.IsNullOrEmpty(base.Text) && this.UserInfo != null)
                    return string.Format("{0},{1}", this.UserInfo.UserCode, this.UserInfo.UserName);
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected override void OnPropertyChanged(string propertyName)
        {
            StringBuilder sb = new StringBuilder();
            if (this.UserInfo != null)
            {
                if (!string.IsNullOrEmpty(this.UserInfo.UserCode))
                    sb.AppendFormat("学生学号：{0}", this.UserInfo.UserCode);
                if (!string.IsNullOrEmpty(this.UserInfo.UserName))
                {
                    if (sb.Length > 0)
                        sb.Append("\r\n");
                    sb.AppendFormat("学生姓名：{0}", this.UserInfo.UserName);
                }
            }
            if (!string.IsNullOrEmpty(this.MachineName))
            {
                if (sb.Length > 0)
                    sb.Append("\r\n");
                sb.AppendFormat("学生机名称：{0}", this.MachineName);
            }
            if (!string.IsNullOrEmpty(propertyName))
            {
                string[] split = propertyName.Split('|');
                if (split != null && split.Length > 0)
                {
                    foreach (string s in split)
                    {
                        string[] arr = s.Split('$');
                        if (arr != null && arr.Length > 1)
                        {
                            if (sb.Length > 0)
                                sb.Append("\r\n");
                            sb.AppendFormat("{0}：{1}", arr[0], arr[1]);
                        }
                    }
                }
            }
            if (this.UserIP != null)
            {
                if (sb.Length > 0)
                    sb.Append("\r\n");
                sb.AppendFormat("学生机IP：{0}", this.UserIP);
            }
            if (sb.Length > 0)
            {
                base.OnPropertyChanged(sb.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="drgevent"></param>
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            string[] strFileArray = (string[])drgevent.Data.GetData(DataFormats.FileDrop);
            if (strFileArray != null && strFileArray.Length > 0)
            {
                this.OnDragDropData(strFileArray);
            }
            base.OnDragDrop(drgevent);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="drgevent"></param>
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
            {
                drgevent.Effect = DragDropEffects.Link;
            }
            else
            {
                drgevent.Effect = DragDropEffects.None;
            }
            base.OnDragEnter(drgevent);
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        private void initComponent()
        {
            //this.fiveStartControlGroup = new FiveStartControlGroup(5,3);
            //this.fiveStartControlGroup.Click += new EventHandler(delegate(object sender, EventArgs e)
            //{ 
            //    this.OnPropertyChanged(string.Format("课堂纪律${0}颗星", this.fiveStartControlGroup.CheckCount));
            //});
            //this.SuspendLayout();
            //this.fiveStartControlGroup.Width = this.Width;
            //int h = this.Height;
            //if (h > 0)
            //{
            //    int lh = h / 3;
            //    int x = this.Location.X;
            //    int y = this.Location.Y;
            //    this.fiveStartControlGroup.Height = lh;

            //    this.fiveStartControlGroup.Location = new Point(x, y + (h - lh));
            //    this.Controls.Add(this.fiveStartControlGroup);
            //}
            //this.ResumeLayout(false);
        }
        /// <summary>
        /// 创建背景颜色。
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected virtual Color CreateBackgroundColor(EnumStudentState state)
        {
            Color background = Color.Transparent;
            if ((state & EnumStudentState.Offline) == EnumStudentState.Offline)
            {
                background = ((state & EnumStudentState.Upload) == EnumStudentState.Upload) ? this.colorSettings.OfflineUploadColor : this.colorSettings.OfflineColor;
                this.SetAllowDrop(this, false);
            }
            else if ((state & EnumStudentState.Online) == EnumStudentState.Online)
            {
                background = ((state & EnumStudentState.Upload) == EnumStudentState.Upload) ? this.colorSettings.UploadColor : this.colorSettings.OnlineColor;
                this.SetAllowDrop(this, true);
            }
            if ((state & EnumStudentState.Review) == EnumStudentState.Review)
            {
                background = this.colorSettings.ReviewColor;
            }
            return background;
        }
        /// <summary>
        /// 重载绘制内容。
        /// </summary>
        /// <param name="g"></param>
        /// <param name="re"></param>
        /// <param name="e"></param>
        protected override void DrawBoxContent(Graphics g, Rectangle re, PaintEventArgs e)
        {
            this.DrawString(g);
        }
        /// <summary>
        /// 绘制文字。
        /// </summary>
        /// <param name="gr"></param>
        protected void DrawString(Graphics gr)
        {
            if (gr != null && this.UserInfo != null)
            {
                int width = this.Width, height = this.Height;
                if (!string.IsNullOrEmpty(this.UserInfo.UserName))
                {
                    int nameWidth = 0, nameHeight = 0;
                    int offsetX = 0, offsetY = 0;
                    if (!string.IsNullOrEmpty(this.UserInfo.UserCode))
                    {
                        using (Font nameF = new Font(this.Font, FontStyle.Bold))
                        {
                            int codeWidth = 0, codeHeight = 0;
                            string strCode = this.UserInfo.UserCode;
                            if (strCode.Length > 2)
                                strCode = strCode.Substring(strCode.Length - 2);
                            if (!string.IsNullOrEmpty(this.MachineName))
                                strCode += "(" + this.MachineName + ")";

                            nameHeight = (int)gr.MeasureString(strCode, nameF).Height;
                            using (Font codeF = new Font(this.Font, FontStyle.Regular))
                            {
                                codeWidth = (int)gr.MeasureString(strCode, codeF).Width;
                                codeHeight = (int)gr.MeasureString(strCode, codeF).Height;

                                offsetX = (width - codeWidth) / 2;
                                offsetY = (height - codeHeight - nameHeight) / 2;

                                gr.DrawString(strCode, codeF, new SolidBrush(this.ForeColor), new PointF(offsetX, offsetY));
                            }
                            nameWidth = (int)gr.MeasureString(this.UserInfo.UserName, nameF).Width;
                            offsetY += codeHeight + 1;
                            offsetX = (width - nameWidth) / 2;
                            gr.DrawString(this.UserInfo.UserName, nameF, new SolidBrush(this.ForeColor), new PointF(offsetX, offsetY));
                        }
                    }
                    else
                    {
                        using (Font f = new Font(this.Font, FontStyle.Bold))
                        {
                            nameWidth = (int)gr.MeasureString(this.UserInfo.UserName, f).Width;
                            nameHeight = (int)gr.MeasureString(this.UserInfo.UserName, f).Height;

                            offsetX = (width - nameWidth) / 2;
                            offsetY = (height - nameHeight) / 2;

                            gr.DrawString(this.UserInfo.UserName, f, new SolidBrush(this.ForeColor), new PointF(offsetX, offsetY));
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="allow"></param>
        protected void SetAllowDrop(Control control, bool allow)
        {
            if (control != null)
            {
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    control.AllowDrop = allow;
                    if (control.Parent != null)
                    {
                        this.SetAllowDrop(control.Parent, allow);
                    }
                }));
            }
        }
        #endregion

        #region 内置枚举。
        /// <summary>
        /// 右键菜单事件枚举。
        /// </summary>
        public enum EnumContextMenuType
        {
            /// <summary>
            /// 强制离线。
            /// </summary>
            Offline,
            /// <summary>
            /// 本节课删除。
            /// </summary>
            TemplateDelete
        }
        /// <summary>
        /// 学生状态枚举。
        /// </summary>
        [Flags]
        public enum EnumStudentState
        {
            /// <summary>
            /// 离线。
            /// </summary>
            Offline = 0x01,
            /// <summary>
            /// 在线。
            /// </summary>
            Online = 0x02,
            /// <summary>
            /// 上传。
            /// </summary>
            Upload = 0x04,
            /// <summary>
            /// 已批阅。
            /// </summary>
            Review = 0x08
        }
        /// <summary>
        /// 学生状态枚举工具类。
        /// </summary>
        public static class EnumStudentStateOperaTools
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="state"></param>
            /// <returns></returns>
            public static string GetCHName(EnumStudentState state)
            {
                List<string> list = new List<string>();
                if ((state & EnumStudentState.Offline) == EnumStudentState.Offline)
                {
                    list.Add("离线");
                }
                else if ((state & EnumStudentState.Online) == EnumStudentState.Online)
                {
                    list.Add("在线");
                }
                if ((state & EnumStudentState.Upload) == EnumStudentState.Upload)
                {
                    list.Add("学生已上传");
                }
                if ((state & EnumStudentState.Review) == EnumStudentState.Review)
                {
                    list.Add("已评阅");
                }
                return string.Join(",", list.ToArray());
            }
        }
        #endregion

        #region 右键菜单事件处理。
        /// <summary>
        /// 初始化右键菜单。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentControl));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemOffline = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTemplateDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOffline,
            this.menuItemTemplateDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // menuItemOffline
            // 
            this.menuItemOffline.Name = "menuItemOffline";
            resources.ApplyResources(this.menuItemOffline, "menuItemOffline");
            this.menuItemOffline.Click += new System.EventHandler(this.menuItemOffline_Click);
            // 
            // menuItemTemplateDelete
            // 
            this.menuItemTemplateDelete.Name = "menuItemTemplateDelete";
            resources.ApplyResources(this.menuItemTemplateDelete, "menuItemTemplateDelete");
            this.menuItemTemplateDelete.Click += new System.EventHandler(this.menuItemTemplateDelete_Click);
            // 
            // StudentControl
            // 
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "StudentControl";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        /// <summary>
        /// 弹出右键菜单事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.menuItemOffline.Enabled = ((this.state & EnumStudentState.Online) == EnumStudentState.Online);
        }
        /// <summary>
        /// 强制离线。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemOffline_Click(object sender, EventArgs e)
        {
            string msg = string.Format("是否确定学生[{0}]强制下线？\r\n(恢复须该学生重新登录)", this.Text);
            if (MessageBox.Show(this, msg, "强制下线提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.OnContextHandler(EnumContextMenuType.Offline);
            }
        }
        /// <summary>
        /// 本节课删除学生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemTemplateDelete_Click(object sender, EventArgs e)
        {
            if ((this.state & EnumStudentState.Online) == EnumStudentState.Online)
            {
                string msg = string.Format("请先将学生[{0}]强制下线？", this.Text);
                MessageBox.Show(this, msg, "本节课删除学生提示", MessageBoxButtons.OK);
            }
            else
            {
                string msg = string.Format("是否确定在本节课中被删除学生[{0}]？\r\n(恢复须重新上课)", this.Text);
                if (MessageBox.Show(this, msg, "本节课删除学生提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.OnContextHandler(EnumContextMenuType.TemplateDelete);
                }
            }
        }
        #endregion
    }
    /// <summary>
    /// 学生控件集合。
    /// </summary>
    public class StudentControls : RoundRectBoxCollection<StudentControl>
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public StudentControls()
        {
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 是否存在。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool Contains(StudentControl item)
        {
            if (item != null)
            {
                int index = this.Items.FindIndex(new Predicate<StudentControl>(delegate(StudentControl sender)
                {
                    return (sender != null) && (sender.UserInfo != null) && (item.UserInfo != null) && (sender.UserInfo.UserID == item.UserInfo.UserID);
                }));
                return index > -1;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(StudentControl x, StudentControl y)
        {
            if (x.UserInfo != null && y.UserInfo != null)
            {
                int x_code = this.getOrderNo(x.UserInfo.UserCode);
                int y_code = this.getOrderNo(y.UserInfo.UserCode);

                int result = x_code - y_code;
                if (result == 0)
                {
                    result = string.Compare(x.UserInfo.UserCode, y.UserInfo.UserCode);
                }
                return result;
            }
            return string.Compare(x.Text, y.Text);
        }
        #endregion

        #region 辅助函数。
        static Regex STATIC_REGEX = new Regex(@"(?<Code>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        int getOrderNo(string orderNo)
        {
            if (!string.IsNullOrEmpty(orderNo))
            {
                try
                {
                    Match m = STATIC_REGEX.Match(orderNo);
                    if (m.Success)
                    {
                        string str = m.Groups["Code"].Value;
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str.Length > 2)
                            {
                                str = str.Substring(str.Length - 2);
                            }
                            return int.Parse(str);
                        }
                    }
                }
                catch (Exception) { }
            }
            return 0;
        }
        #endregion
    }
}
