//================================================================================
//  FileName: Program.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-30
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

namespace Yaesoft.SFIT.Client.AutoUpdate
{
    /// <summary>
    /// 主程序入口。
    /// </summary>
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //MessageBox.Show(string.Join("|", args));
            //args = new string[] { "http://xssy.furongedu.com/AutoUpdate.ashx", "false" };
            if (args != null && args.Length > 0)
            {
                try
                {
                    using (AutoUpdateClient client = new AutoUpdateClient(args[0]))
                    {
                        if (client.CheckforUpdates())
                        {
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new MainForm(client));
                        }
                        bool show = false;
                        if (args.Length > 1 && bool.TryParse(args[1], out show))
                        {
                            if (show)
                            {
                                MessageBox.Show("已经是最新的啦~！", "自动更新", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "自动更新程序发生致命异常：", MessageBoxButtons.OK);
                }
            }
        }
    }
}