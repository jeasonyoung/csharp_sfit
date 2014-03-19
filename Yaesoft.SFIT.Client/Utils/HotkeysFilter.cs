//================================================================================
//  FileName: HotkeysTool.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/14
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
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Yaesoft.SFIT.Client.Utils
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hotkey"></param>
    public delegate void HotkeyEventHandler(string hotkey);
    /// <summary>
    /// 快捷键设置。
    /// </summary>
    public class HotkeysFilter : IMessageFilter
    {
        #region 成员变量，构造函数。
        IntPtr hWnd = IntPtr.Zero;
        Hashtable hotkeyIds;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="hWnd"></param>
        public HotkeysFilter(IntPtr hWnd)
        {
            this.hWnd = hWnd;
            this.hotkeyIds = Hashtable.Synchronized(new Hashtable());
        }
        #endregion

        #region 注册事件。
        /// <summary>
        /// 快捷键触发事件。
        /// </summary>
        public event HotkeyEventHandler Hotkey;
        /// <summary>
        /// 触发快捷键事件。
        /// </summary>
        /// <param name="hotkey"></param>
        protected void OnHotkey(string hotkey)
        {
            HotkeyEventHandler handler = this.Hotkey;
            if (handler != null && !string.IsNullOrEmpty(hotkey))
                handler(hotkey);
        }
        #endregion

        #region 公开函数。
        /// <summary>
        /// 注册快捷键。
        /// </summary>
        /// <param name="hotkeys"></param>
        public void RegisterHotkey(params string[] hotkeys)
        {
            if (hotkeys != null && hotkeys.Length > 0)
            {
                Application.AddMessageFilter(this);
                KeyModifiers km = KeyModifiers.None;
                Keys key = Keys.None;
                UInt32 hotkeyid = 0;
                foreach (string strKey in hotkeys)
                {
                    if (!string.IsNullOrEmpty(strKey) && !this.hotkeyIds.ContainsKey(strKey))
                    {
                        if (this.SplitConvertHotKeys(strKey, out km, out key))
                        {
                            hotkeyid = GlobalAddAtom(Guid.NewGuid().ToString());
                            RegisterHotKey(this.hWnd, hotkeyid, (UInt32)km, (UInt32)key);
                            this.hotkeyIds.Add(strKey, hotkeyid);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 注销快捷键。
        /// </summary>
        public void UnregisterHotKey()
        {
            if (this.hotkeyIds.Count > 0)
            {
                Application.RemoveMessageFilter(this);
                foreach (string hotKey in this.hotkeyIds.Keys)
                {
                    UInt32 key = (UInt32)this.hotkeyIds[hotKey];
                    UnregisterHotKey(this.hWnd, key);
                    GlobalDeleteAtom(key);
                }
                this.hotkeyIds.Clear();
            }
        }
        #endregion

        #region IMessageFilter 成员

        public bool PreFilterMessage(ref Message m)
        {
            if ((m.Msg == 0x312) && (this.hotkeyIds.Count > 0))
            {
                foreach (string hotKey in this.hotkeyIds.Keys)
                {
                    UInt32 key = (UInt32)this.hotkeyIds[hotKey];
                    if ((UInt32)m.WParam == key)
                    {
                        this.OnHotkey(hotKey);
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region 辅助函数。
        /// <summary>
        /// 拆分转换快捷键。
        /// </summary>
        /// <param name="hotkey"></param>
        /// <param name="km"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        bool SplitConvertHotKeys(string hotkey, out KeyModifiers km, out Keys key)
        {
            bool result = false;
            km = KeyModifiers.None;
            key = Keys.None;
            if (!string.IsNullOrEmpty(hotkey))
            {
                if (hotkey.IndexOf('+') <= 0)
                {
                    key = (Keys)Enum.Parse(typeof(Keys), hotkey);
                    result = (key != Keys.None);
                }
                else
                {
                    string[] keys = hotkey.Split('+');
                    km = (KeyModifiers)Enum.Parse(typeof(KeyModifiers), keys[0]);
                    if (keys.Length == 2)
                    {
                        key = (Keys)Enum.Parse(typeof(Keys), keys[1]);
                    }
                    else if (keys.Length == 3)
                    {
                        km |= (KeyModifiers)Enum.Parse(typeof(KeyModifiers), keys[1]);
                        key = (Keys)Enum.Parse(typeof(Keys), keys[2]);
                    }
                    else if (keys.Length == 4)
                    {
                        km |= (KeyModifiers)Enum.Parse(typeof(KeyModifiers), keys[1]);
                        km |= (KeyModifiers)Enum.Parse(typeof(KeyModifiers), keys[2]);
                        key = (Keys)Enum.Parse(typeof(Keys), keys[3]);
                    }
                    result = (key != Keys.None);
                }
            }
            return result;
        }
        #endregion

        #region Win32API。
        /// <summary>
        /// 注册快捷键。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);
        /// <summary>
        /// 注销快捷键。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);
        [DllImport("kernel32.dll")]
        private static extern UInt32 GlobalAddAtom(String lpString);
        [DllImport("kernel32.dll")]
        private static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);
        #endregion

        #region 内置枚举。
        /// <summary>
        /// 组合键枚举。
        /// </summary>
        [Flags]
        enum KeyModifiers
        {
            None = 0x00,
            Alt = 0x01,
            Ctrl = 0x02,
            Shift = 0x04,
            Win = 0x08
        }
        #endregion
    }
}
