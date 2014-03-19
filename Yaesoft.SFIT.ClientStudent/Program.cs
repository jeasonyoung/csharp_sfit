//================================================================================
//  FileName: Program.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/9
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
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Yaesoft.SFIT;
using Yaesoft.SFIT.Client;
using Yaesoft.SFIT.Client.Net;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.ClientStudent.Data;
using Yaesoft.SFIT.ClientStudent.Forms;
namespace Yaesoft.SFIT.ClientStudent
{
    /// <summary>
    /// 主运行程序。
    /// </summary>
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                #region 进程数据传递。
                try
                {
                    string path = string.Join(" ", args);
                    if (File.Exists(args[0]))
                    {
                        path = args[0];
                    }
                    //跨进程传递数据。
                    ProcessDataComm.WriteProcessData("学生机客户端", path.Trim());
                }
                catch (Exception x)
                {
                    UtilTools.OnExceptionRecord(x, typeof(Program));
                }
                #endregion
            }
            else
            {
                #region 运行主程序。
                bool isRun;
                Mutex run = new Mutex(true, "run_stu_client_only_one", out isRun);
                if (isRun)
                {
                    try
                    {
                        bool rest = false;

                        #region 主运行区。
                        //处理未捕获的异常。
                        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                        //处理UI线程异常。
                        Application.ThreadException += new ThreadExceptionEventHandler(delegate(object sender, ThreadExceptionEventArgs e)
                        {
                            if (e != null && e.Exception != null)
                            {
                                GlobalExceptionHandler(e.Exception);
                            }
                        });
                        //处理非UI线程异常。
                        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(delegate(object sender, UnhandledExceptionEventArgs e)
                        {
                            Exception ex = e.ExceptionObject as Exception;
                            if (ex != null)
                            {
                                GlobalExceptionHandler(ex);
                            }
                        });

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        using (ClientInitialService service = new ClientInitialService())
                        {
                            service["portsettings"] = ClientNetPortSettingsMgr.DeSerializer();
                            service.AddForm(new WaitHostBroadcastWindow(service));
                            service.Run();
                            rest = service.Rest;
                        }
                        #endregion
                        
                        #region 重新启动系统。
                        if (rest)
                        {
                            Thread.Sleep(250);
                            System.Diagnostics.Process.Start(Application.ExecutablePath);
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
                    MessageBox.Show("已经运行了一个实例！");
                }
                #endregion
            }
        }

        /// <summary>
        /// 全局异常处理。
        /// </summary>
        /// <param name="e"></param>
        public static void GlobalExceptionHandler(Exception e)
        {
            UtilTools.OnExceptionRecord(e, typeof(Program));
            MessageBox.Show(e.Message, "程序发生致命异常", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}