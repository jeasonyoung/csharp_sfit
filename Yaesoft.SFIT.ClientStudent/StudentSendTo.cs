//================================================================================
//  FileName: StudentSendTo.cs
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
using System.Windows.Forms;
using Microsoft.Win32;
namespace Yaesoft.SFIT.ClientStudent
{
    /// <summary>
    /// 学生上传作品的快捷方式。
    /// </summary>
    public class StudentSendTo : IDisposable
    {
        #region 成员变量，构造函数。
        string menuName, commandName;
        RegistryKey shell = null, custom = null, cmd = null;
         /// <summary>
        /// 构造函数。
        /// </summary>
        public StudentSendTo()
        {
            this.menuName = "上传作品到教师机客户端";
            this.commandName = "command";
        }
        #endregion

        /// <summary>
        /// 创建。
        /// </summary>
        public void Create()
        {
            lock (this)
            {
                try
                {
                    using (this.shell = Registry.ClassesRoot.OpenSubKey(@"*\shell", true))
                    {
                        if (this.shell == null)
                        {
                            this.shell = Registry.ClassesRoot.CreateSubKey(@"*\shell");
                        }
                        using (this.custom = this.shell.CreateSubKey(this.menuName))
                        {
                            if (this.custom != null)
                            {
                                using (this.cmd = this.custom.CreateSubKey(this.commandName))
                                {
                                    if (this.cmd != null)
                                    {
                                        this.cmd.SetValue(null, Application.ExecutablePath + " %1");
                                        //Application.ExecutablePath 是本程序自身的路径
                                        //%1 是传入打开的文件路径.
                                        this.cmd.Close();
                                    }
                                }
                                this.custom.Close();
                            }
                        }
                        this.shell.Close();
                    }
                }
                catch (Exception) { }
            }
        }

        #region IDisposable 成员
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            lock (this)
            {
                using (this.shell = Registry.ClassesRoot.OpenSubKey(@"*\shell", true))
                {
                    try
                    {
                        if (this.shell != null)
                        {
                            this.shell.DeleteSubKeyTree(this.menuName);
                        }
                    }
                    catch (Exception) { }
                    finally
                    {
                        if (this.shell != null)
                        {
                            this.shell.Close();
                        }
                    }
                }
            }
        }

        #endregion
    }
}