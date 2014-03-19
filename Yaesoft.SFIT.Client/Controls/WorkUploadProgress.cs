//================================================================================
//  FileName: WorkUploadProgress.cs
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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Yaesoft.SFIT.Client.Controls
{

    /// <summary>
    /// 作业上传进度条。
    /// </summary>
    public class WorkUploadProgress : UserControl
    {
        #region 成员变量，构造函数。
        private ToolTip tip;
        private ProgressBar progressBar;
        private Panel panel;
        private Label lbProgress, lbTitle;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public WorkUploadProgress()
        {
            this.tip = this.Container != null ? new ToolTip(this.Container) : new ToolTip();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                           ControlStyles.UserPaint |
                           ControlStyles.ResizeRedraw |
                           ControlStyles.OptimizedDoubleBuffer |
                           ControlStyles.StandardDoubleClick, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetAutoSizeMode(AutoSizeMode.GrowOnly);
            this.BackColor = Color.Transparent;

            this.InitializeComponent();
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="title">上传标题。</param>
        /// <param name="size">上传大小。</param>
        public WorkUploadProgress(string title, int size)
            : this()
        {
            this.lbTitle.Text = title;
            this.tip.SetToolTip(this.lbTitle, title);
            this.progressBar.Minimum = 0;
            if (size > 0) this.progressBar.Maximum = size;
            this.progressBar.Value = 0;
            this.progressBar.BackColor = this.lbTitle.ForeColor = this.lbProgress.ForeColor = Color.Green;
            this.lbProgress.Text = "0%";
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="title">上传标题。</param>
        public WorkUploadProgress(string title)
            : this(title, -1)
        {
        }
        #endregion

        /// <summary>
        /// 获取或设置进度条最大值。
        /// </summary>
        public int ProgressMaximum
        {
            get
            {
                 int max = 0;
                 this.ThreadSafeMethod(this.progressBar, new MethodInvoker(delegate()
                 {
                     max = this.progressBar.Maximum;
                 }));
                 return max;
            }
            set
            {
                this.ThreadSafeMethod(this.progressBar, new MethodInvoker(delegate()
                {
                    this.progressBar.Maximum = value;
                }));
            }
        }

        /// <summary>
        /// 获取进度百分比。
        /// </summary>
        public double SpeedPer { get; private set; }
        /// <summary>
        /// 更新进度。
        /// </summary>
        /// <param name="value"></param>
        public void UpdateProgress(int value)
        {
            this.ThreadSafeMethod(this, new MethodInvoker(delegate()
            {
                int count = (this.progressBar.Value += value);
                int size = this.progressBar.Maximum;

                this.SpeedPer = Math.Round(((count / (double)size) * 100), 2);

                string per = this.SpeedPer + "%";

                this.lbProgress.Text = per;
                this.tip.SetToolTip(this.progressBar, per);
                this.tip.SetToolTip(this.lbProgress, per);

                this.progressBar.Update();
                this.lbProgress.Update();
            }));
        }
        /// <summary>
        /// 更新进度条上的消息。
        /// </summary>
        /// <param name="msg"></param>
        public void UpdateProgressToolTipMessage(string msg)
        {
            this.ThreadSafeMethod(this, new MethodInvoker(delegate()
            {
                this.tip.SetToolTip(this.progressBar, msg);
            }));
        }
        /// <summary>
        /// 更新失败信息。
        /// </summary>
        /// <param name="err">失败信息。</param>
        public void UploadFailure(string err)
        {
            err = "上传失败：" + err;
            this.ThreadSafeMethod(this, new MethodInvoker(delegate()
            {
                this.progressBar.BackColor = this.lbTitle.ForeColor = this.lbProgress.ForeColor = Color.Red;
                this.lbProgress.Text = this.SpeedPer + "%[失败]";
                this.tip.SetToolTip(this.lbProgress, err);
            }));
            this.UpdateProgressToolTipMessage(err);
        }
        /// <summary>
        /// 
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(this.Width, 50);
            }
        }

        #region 辅助函数。
        /// <summary>
        /// 线程安全方法调用。
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="method"></param>
        private void ThreadSafeMethod(Control ctrl, MethodInvoker method)
        {
            if (ctrl != null && method != null)
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(method);
                }
                else
                {
                    method.Invoke();
                }
            }  
        }
        private void InitializeComponent()
        {
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbProgress = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.ForeColor = System.Drawing.Color.Green;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(150, 23);
            this.progressBar.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.lbTitle);
            this.panel.Controls.Add(this.lbProgress);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(150, 22);
            this.panel.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(47, 12);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "[title]";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbProgress.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbProgress.Location = new System.Drawing.Point(121, 0);
            this.lbProgress.Margin = new System.Windows.Forms.Padding(2);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(29, 12);
            this.lbProgress.TabIndex = 2;
            this.lbProgress.Text = "[0%]";
            // 
            // WorkUploadProgress
            // 
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel);
            this.Name = "WorkUploadProgress";
            this.Size = new System.Drawing.Size(150, 46);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
    }
}