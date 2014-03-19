//================================================================================
//  FileName: MonitorStudentsWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/30
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
using System.Windows.Forms;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 监视学生上课窗口。
    /// </summary>
    public partial class MonitorStudentsWindow : BaseWindow, IPluginHost
    {
        #region 成员变量，构造函数。
        Size oldSize = Size.Empty;
        int x = 0, y = 0, maxH = 0;
        LoadingPluginService pluginService;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service">核心服务接口。</param>
        public MonitorStudentsWindow(ICoreService service)
            : base(service)
        {
            this.pluginService = new LoadingPluginService(service, this);
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonitorStudentsWindow_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.oldSize = this.Size;
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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonitorStudentsWindow_ResizeEnd(object sender, EventArgs e)
        {
            //固定最小尺寸。
            if (this.oldSize != Size.Empty)
            {
                if (this.Width <= this.oldSize.Width)
                {
                    this.Width = this.oldSize.Width;
                }

                if (this.Height <= this.oldSize.Height)
                {
                    this.Height = this.oldSize.Height;
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
            if (plug != null)
            {
                switch (position)
                {
                    case DockStyle.Top:
                        this.AddFillPlugin(this.panelTop, plug);
                        break;
                    case DockStyle.Right:
                        this.AddRightPlugin(this.panelRight, plug);
                        break;
                    case DockStyle.Bottom:
                        this.AddFillPlugin(this.panelBottom, plug);
                        break;
                    case DockStyle.Left:
                    case DockStyle.Fill:
                        this.AddFillPlugin(this.splitContainer.Panel1, plug);
                        break;
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
                {
                    this.pluginService.SendCrossPluginData(this, new CrossPluginEventArgs(DockStyle.Bottom, new object[] { "msg", content }));
                }
            }
            base.OnMessageEvent(type, content);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="userControl"></param>
        public override void AddUseControls(Control parent, IWindow userControl)
        {
            Panel p = parent as Panel;
            if (p != null)
            {
                p.SuspendLayout();
                base.AddUseControls(parent, userControl);
                p.ResumeLayout();
            }
            else
            {
                base.AddUseControls(parent, userControl);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="userControl"></param>
        protected virtual void AddFillPlugin(Control parent, IWindow userControl)
        {
            UserControl uc = userControl as UserControl;
            if (uc != null)
            {
                uc.Dock = DockStyle.Fill;
                this.AddUseControls(parent, (IWindow)uc);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="userControl"></param>
        protected virtual void AddRightPlugin(Control parent, IWindow userControl)
        {
            UserControl uc = userControl as UserControl;
            if (uc != null)
            {
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
        #endregion
    }
}