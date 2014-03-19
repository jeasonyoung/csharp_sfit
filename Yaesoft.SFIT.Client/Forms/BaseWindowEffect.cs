//================================================================================
//  FileName: BaseWindowEffect.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/2
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
using System.Runtime.InteropServices;
namespace Yaesoft.SFIT.Client.Forms
{
    /// <summary>
    /// 
    /// </summary>
    partial class BaseWindow
    {
        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case BaseWindowEffect.WM_MOVING://如果鼠标移动。
                    base.WndProc(ref m);//调用基类的窗口过程一WndProc方法处理这个消息
                    if (m.Result == (IntPtr)BaseWindowEffect.HTCLIENT)
                    {
                        m.Result = (IntPtr)BaseWindowEffect.HTCAPTION;
                        return;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BaseWindowEffect.ReleaseCapture();
                BaseWindowEffect.SendMessage(this.Handle, BaseWindowEffect.WM_SYSCOMMAND,
                                             BaseWindowEffect.SC_MOVE + BaseWindowEffect.HTCAPTION, 0);
            }
            base.OnMouseMove(e);
        }
        #endregion

        #region 内置类。
        /// <summary>
        /// 窗体效果内置类。
        /// </summary>
        class BaseWindowEffect
        {
            [DllImport("user32.dll")]
            public static extern bool ReleaseCapture();

            [DllImport("user32.dll")]
            public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

            /// <summary>
            /// 点击窗口左上角那个图标时的系统信息。
            /// </summary>
            public const int WM_SYSCOMMAND = 0x0112;
            /// <summary>
            /// 鼠标移动消息。
            /// </summary>
            public const int WM_MOVING = 0x216;
            /// <summary>
            /// 移动信息。
            /// </summary>
            public const int SC_MOVE = 0xF010;
            /// <summary>
            /// 表示鼠标在窗口标题栏时的系统信息。
            /// </summary>
            public const int HTCAPTION = 0x0002;
            /// <summary>
            /// 鼠标在窗体客户区（除标题栏和边框以外的部分）时发送的消息。
            /// </summary>
            public const int WM_NCHITEST = 0x84;
            /// <summary>
            /// 表示鼠标在窗口客户区的系统消息。
            /// </summary>
            public const int HTCLIENT = 0x1;
            /// <summary>
            /// 最大化信息。
            /// </summary>
            public const int SC_MAXIMIZE = 0xF030;
            /// <summary>
            /// 最小化信息。
            /// </summary>
            public const int SC_MINIMIZE = 0xF020;
        }
        #endregion
    }
}
