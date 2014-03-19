//================================================================================
//  FileName: Program.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 主程序。
    /// </summary>
    static class Program
    {
        #region 全局变量。
        /// <summary>
        /// 全局当前上课班级学生数据集合。
        /// </summary>
        public static StudentsEx STUDENTS;
        #endregion

        #region 函数。
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isRun;
            Mutex run = new Mutex(true, "run_only_one", out isRun);
            if (isRun)
            {
                try
                {
                    #region 主运行区。
                    //处理未捕获的异常。
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    //处理UI线程异常。
                    Application.ThreadException += new ThreadExceptionEventHandler(delegate(object sender, ThreadExceptionEventArgs e)
                    {
                        GlobalExceptionHandler(e == null ? null : e.Exception);
                    });
                    //处理非UI线程异常。
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(delegate(object sender, UnhandledExceptionEventArgs e)
                    {
                        GlobalExceptionHandler(e.ExceptionObject as Exception);
                    });

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //设置线程池。
                    ThreadPool.SetMaxThreads(300, 200);
                    ThreadPool.SetMinThreads(100, 50);
                    //
                    using (InitialService service = new InitialService())
                    {
                        service.AddForm(new InitializeWindow(service));
                        service.Run();
                    }
                    #endregion
                }
                catch (Exception e)
                {
                    GlobalExceptionHandler(e);
                }
                finally
                {
                    run.ReleaseMutex();
                    Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("已有一个实例在运行!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 全局异常处理。
        /// </summary>
        /// <param name="e"></param>
        public static void GlobalExceptionHandler(Exception e)
        {
            if (e == null) return;
            UtilTools.OnExceptionRecord(e, typeof(Program));
            MessageBox.Show(e.Message, "程序发生致命异常", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        #endregion
    }
}
