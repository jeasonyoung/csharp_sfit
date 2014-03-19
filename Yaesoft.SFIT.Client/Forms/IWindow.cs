//================================================================================
//  FileName: IWindow.cs
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
using System.Text;
using System.Windows.Forms;
namespace Yaesoft.SFIT.Client.Forms
{
    /// <summary>
    /// 消息委托。
    /// </summary>
    /// <param name="type">消息类型。</param>
    /// <param name="content">消息内容。</param>
    public delegate void MessageHanlder(MessageType type, string content);
    /// <summary>
    /// 工具提示委托。
    /// </summary>
    /// <param name="control">指定的控件。</param>
    /// <param name="toolTip">提示信息。</param>
    public delegate void ToolTipHandler(Control control, string toolTip);
    /// <summary>
    /// 设置错误提示委托。
    /// </summary>
    /// <param name="control">指定控件。</param>
    /// <param name="err">错误信息。</param>
    public delegate void SetErrorHandler(Control control, string err);

    /// <summary>
    /// 窗体接口。
    /// </summary>
    public interface IWindow
    {
        /// <summary>
        /// 获取或设置宿主ID。
        /// </summary>
        string HostID { get; set; }
        /// <summary>
        /// 获取或设置标题。
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 消息事件。
        /// </summary>
        event MessageHanlder MessageEvent;
        /// <summary>
        /// 工具提示事件。
        /// </summary>
        event ToolTipHandler ToolTipEvent;
        /// <summary>
        /// 设置错误提示事件。
        /// </summary>
        event SetErrorHandler SetErrorEvent;
        /// <summary>
        /// 清除错误信息事件。
        /// </summary>
        event MethodInvoker ClearErrorEvent;

        /// <summary>
        /// 添加用户控件。
        /// </summary>
        /// <param name="parent">父容器。</param>
        /// <param name="userControl">用户控件。</param>
        void AddUseControls(Control parent, IWindow userControl);
    }
    /// <summary>
    /// 消息类型。
    /// </summary>
    [Flags]
    public enum MessageType
    {
        /// <summary>
        /// 普通一般消息。
        /// </summary>
        Normal = 0x2,
        /// <summary>
        /// 弹出提示消息。
        /// </summary>
        PopupInfo = 0x4,
        /// <summary>
        /// 弹出警告消息。
        /// </summary>
        PopupWarn = 0x8,
        /// <summary>
        /// 通讯消息。
        /// </summary>
        communication = 0x10
    }
}
