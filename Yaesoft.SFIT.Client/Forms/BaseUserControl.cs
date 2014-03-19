//================================================================================
//  FileName: BaseUserControl.cs
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Yaesoft.SFIT.Client.Forms
{
    /// <summary>
    /// 用控件基类。
    /// </summary>
    public partial class BaseUserControl : UserControl, IWindow,IHotkeys
    {
        #region 成员变量，构造函数。
        string strHostID, strTitle;
        ICoreService coreService;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public BaseUserControl(ICoreService service)
        {
            this.coreService = service;
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数，设计时调用。
        /// </summary>
        public BaseUserControl()
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

        #region IWindow 成员
        /// <summary>
        /// 获取或设置宿主ID。
        /// </summary>
        public string HostID
        {
            get
            {
                if (!string.IsNullOrEmpty(this.strHostID))
                    this.strHostID = this.Name;
                return this.strHostID;
            }
            set
            {
                this.strHostID = value;
            }
        }
        /// <summary>
        /// 获取或设置标题。
        /// </summary>
        public string Title
        {
            get
            {
                if (!string.IsNullOrEmpty(this.strTitle))
                    return this.ParentForm.Text;
                return this.strTitle;
            }
            set
            {
                this.ParentForm.Text = this.strTitle = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public event MessageHanlder MessageEvent;
        /// <summary>
        /// 
        /// </summary>
        public event ToolTipHandler ToolTipEvent;
        /// <summary>
        /// 
        /// </summary>
        public event SetErrorHandler SetErrorEvent;
        /// <summary>
        /// 
        /// </summary>
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
                    if (uc.Dock == DockStyle.Fill)
                        parent.Controls.Clear();
                    parent.Controls.Add(uc);
                    parent.Update();

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
                    MessageBox.Show(content, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if ((type & MessageType.PopupWarn) == MessageType.PopupWarn)
                {
                    MessageBox.Show(content, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                handler(control, toolTip);
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
                handler(control, err);
        }
        /// <summary>
        /// 触发清除错误信息。
        /// </summary>
        protected virtual void OnClearErrorEvent()
        {
            MethodInvoker handler = this.ClearErrorEvent;
            if (handler != null)
                handler();
        }
        #endregion

        #region IHotkeys 成员
        /// <summary>
        /// 快捷键触发的动作。
        /// </summary>
        /// <param name="hotKey"></param>
        public virtual void ProcessHotkey(string hotKey)
        {
            
        }

        #endregion
    }
}
