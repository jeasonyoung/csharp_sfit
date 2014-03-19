//================================================================================
//  FileName: Program.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-11-18
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
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace FileStorageTransferTools
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }

        /// <summary>
        /// 异常处理记录。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="type"></param>
        public static void OnExceptionRecord(Exception e, Type type)
        {
            if (type == null)
                type = typeof(Program);
            if (e == null)
                return;
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object sender)
            {
                lock (typeof(Program))
                {
                    string path = Path.GetFullPath(string.Format("{0}\\{1}_{2:yyyyMMdd}.log", AppDomain.CurrentDomain.BaseDirectory, type.FullName, DateTime.Now));
                    using (StreamWriter sw = new StreamWriter(path, true, UTF8Encoding.UTF8))
                    {

                        sw.WriteLine(new String('=', 50));
                        sw.WriteLine(string.Format("Message:{0}", e.Message));
                        sw.WriteLine(string.Format("Source:{0}", e.Source));
                        sw.WriteLine(string.Format("StackTrace:{0}", e.StackTrace));
                        sw.WriteLine(string.Format("DateTime:{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));

                        Exception inner = e.InnerException;
                        int deep = 1;
                        while (inner != null)
                        {
                            sw.WriteLine(new String('-', 50));
                            sw.WriteLine("InnerException:" + (deep++));
                            sw.WriteLine(new String('-', 50));

                            sw.WriteLine(string.Format("Message:{0}", inner.Message));
                            sw.WriteLine(string.Format("Source:{0}", inner.Source));
                            sw.WriteLine(string.Format("StackTrace:{0}", inner.StackTrace));

                            inner = inner.InnerException;
                        }
                        sw.WriteLine(new String('=', 50));
                    }
                }
            }));
        }
    }
}
