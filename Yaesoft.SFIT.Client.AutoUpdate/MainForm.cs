//================================================================================
//  FileName: MainForm.cs
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.AutoUpdate.Utils;
using Yaesoft.SFIT.Client.AutoUpdate.Logging;
namespace Yaesoft.SFIT.Client.AutoUpdate
{
    /// <summary>
    /// 自动更新主界面。
    /// </summary>
    public partial class MainForm : Form
    {
        #region 成员变量，构造函数。
        private static Logger logger = new Logger(new Category("AutoUpdateClient"));
        private AutoUpdateClient client;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public MainForm(AutoUpdateClient client)
        {
            this.client = client;
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread.Sleep(1500);
            this.client.Updates(new RaiseChangedHandler(delegate(string messge)
            {
                logger.Info(messge);
                this.ShowMessage(messge);
            }));
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMessage(string msg)
        {
            if (this.lbMessage.InvokeRequired)
            {
                this.lbMessage.Invoke(new MethodInvoker(delegate()
                {
                    this.lbMessage.Text = msg;
                    this.lbMessage.Update();
                }));
            }
            else
            {
                this.lbMessage.Text = msg;
                this.lbMessage.Update();
            }
            this.toolTip.SetToolTip(this.lbMessage, msg);
        }
        #endregion
    }
}