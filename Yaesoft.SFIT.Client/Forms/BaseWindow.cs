//================================================================================
//  FileName: BaseWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/29
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
using System.Threading;
using System.Windows.Forms;

namespace Yaesoft.SFIT.Client.Forms
{
    /// <summary>
    /// 窗口基类。
    /// </summary>
    public partial class BaseWindow : Form, IWindow
    {
        #region 成员变量，构造函数。
        ICoreService coreService;
        string strHostID;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public BaseWindow(ICoreService coreService)
        {
            this.coreService = coreService;
            //初始化页面设置数据。
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数,设计时调用。
        /// </summary>
        public BaseWindow()
            : this(null)
        {
            if (this.DesignMode)
            {
                throw new Exception("须调用带参构造函数！");
            }
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取核心服务接口。
        /// </summary>
        protected virtual ICoreService CoreService
        {
            get { return this.coreService; }
        }
        #endregion

        #region 重载。
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            if (!this.DesignMode && this.coreService != null)
            {
                this.coreService.Changed += this.OnCoreServiceChanged;
            }
        }
        #endregion

        #region IWindow 成员
        /// <summary>
        /// 获取或设置当前宿主ID。
        /// </summary>
        public string HostID
        {
            get
            {
                if (!string.IsNullOrEmpty(this.strHostID))
                    this.strHostID = this.Name;
                return this.strHostID;
            }
            set { this.strHostID = value; }
        }
        /// <summary>
        /// 获取或设置标题。
        /// </summary>
        public virtual string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public event MessageHanlder MessageEvent;

        public event ToolTipHandler ToolTipEvent;

        public event SetErrorHandler SetErrorEvent;

        public event MethodInvoker ClearErrorEvent;

        /// <summary>
        ///在指定的控件中添加用户控件。
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="userControl"></param>
        public virtual void AddUseControls(Control parent, IWindow userControl)
        {
            if (parent != null && userControl != null)
            {
                UserControl uc = userControl as UserControl;
                if (uc != null)
                {
                    uc.AutoSize = true;
                    parent.Controls.Add(uc);

                    userControl.MessageEvent += this.OnMessageEvent;
                    userControl.ToolTipEvent += this.OnToolTipEvent;
                    userControl.SetErrorEvent += this.OnSetErrorEvent;
                    userControl.ClearErrorEvent += this.OnClearErrorEvent;
                }
            }
        }

        #endregion

        #region 辅助函数。
        /// <summary>
        /// 处理核心服务消息。
        /// </summary>
        /// <param name="context"></param>
        protected virtual void OnCoreServiceChanged(string context)
        {
            this.OnMessageEvent(MessageType.Normal, context);
        }
        /// <summary>
        /// 线程安全方法调用。
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="method"></param>
        public virtual void ThreadSafeMethod(Control ctrl, MethodInvoker method)
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
        /// <summary>
        /// 线程安全方法调用。
        /// </summary>
        /// <param name="method"></param>
        public virtual void ThreadSafeMethod(MethodInvoker method)
        {
            this.ThreadSafeMethod(this, method);
        }
        /// <summary>
        /// 触发消息处理。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        protected virtual void OnMessageEvent(MessageType type, string content)
        {
            MessageHanlder handler = this.MessageEvent;
            if (handler != null)
                handler(type, content);
            else
            {
                if ((type & MessageType.PopupInfo) == MessageType.PopupInfo)
                {
                    this.ThreadSafeMethod(new MethodInvoker(delegate()
                    {
                        MessageBox.Show(content, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
                else if ((type & MessageType.PopupWarn) == MessageType.PopupWarn)
                {
                    this.ThreadSafeMethod(new MethodInvoker(delegate()
                    {
                        MessageBox.Show(content, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }));
                }
            }
        }
        /// <summary>
        /// 触发工具提示。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="toolTip"></param>
        protected virtual void OnToolTipEvent(Control control, string toolTip)
        {
            ToolTipHandler handler = this.ToolTipEvent;
            if (handler != null)
            {
                handler(control, toolTip);
            }
            else
            {
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    this.toolTip.SetToolTip(control, toolTip);
                }));
            }
        }
        /// <summary>
        /// 触发设置错误提示。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="err"></param>
        protected virtual void OnSetErrorEvent(Control control, string err)
        {
            SetErrorHandler handler = this.SetErrorEvent;
            if (handler != null)
            {
                handler(control, err);
            }
            else
            {
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    this.errorProvider.SetError(control, err);
                }));
            }
        }
        /// <summary>
        /// 触发清除错误信息。
        /// </summary>
        protected virtual void OnClearErrorEvent()
        {
            MethodInvoker handler = this.ClearErrorEvent;
            if (handler != null)
            {
                handler();
            }
            else
            {
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    this.errorProvider.Clear();
                }));
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 关闭窗体。
        /// </summary>
        public new void Close()
        {
            this.ThreadSafeMethod(new MethodInvoker(delegate() { base.Close(); }));
        }
        #endregion
    }
}