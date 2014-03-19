//================================================================================
//  FileName: ProcessDataComm.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/18
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

using System.Runtime.InteropServices;
namespace Yaesoft.SFIT.Client.Net
{
    /// <summary>
    /// 进程数据通讯。
    /// </summary>
    public static class ProcessDataComm
    {
        #region 成员变量。
        /// <summary>
        /// WM_COPYDATA消息。
        /// </summary>
        public const int WM_COPYDATA = 0x004A;
        #endregion
 
        /// <summary>
        /// 跨进程传递数据。
        /// </summary>
        /// <param name="windowName">窗口名称。</param>
        /// <param name="data">传递数据。</param>
        public static void WriteProcessData(string windowName, string data)
        {
            if (!string.IsNullOrEmpty(windowName) && !string.IsNullOrEmpty(data))
            {
                int wm_handler = FindWindow(null, windowName);
                if (wm_handler != 0)
                {
                    byte[] array = Encoding.Default.GetBytes(data);
                    CopyDataStruct cds = new CopyDataStruct();
                    cds.dwData = (IntPtr)100;
                    cds.lpData = data;
                    cds.cbData = array.Length + 1;
                    SendMessage(wm_handler, WM_COPYDATA, 0, ref cds);
                }
            }
        }

        #region 静态方法。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd">目标窗口的handle。</param>
        /// <param name="msg">消息。</param>
        /// <param name="wParam">第一个消息参数。</param>
        /// <param name="lParam">第二个消息参数。</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int msg, int wParam, ref CopyDataStruct lParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);
        #endregion
    }
    #region 内置结构。
    /// <summary>
    /// 传递数据结构。
    /// </summary>
    public struct CopyDataStruct
    {
        /// <summary>
        /// 
        /// </summary>
        public IntPtr dwData;
        /// <summary>
        /// 
        /// </summary>
        public int cbData;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;
    }
    #endregion
}
