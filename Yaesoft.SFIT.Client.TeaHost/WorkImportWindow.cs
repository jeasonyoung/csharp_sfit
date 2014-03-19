//================================================================================
//  FileName: WorkImportWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/17
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
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Utils;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 作品导入。
    /// </summary>
    public partial class WorkImportWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        string inputFilePath;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="inputFilePath"></param>
        public WorkImportWindow(ICoreService service, string inputFilePath)
            : base(service)
        {
            this.inputFilePath = inputFilePath;
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkImportWindow_Load(object sender, EventArgs e)
        {
            this.txtFilePath.Text = this.inputFilePath;
            this.OnMessageEvent(MessageType.Normal, string.Format("导入文件名称：{0}", Path.GetFileName(this.inputFilePath)));
            this.panelBottom.Visible = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo info = this.CoreService["userinfo"] as UserInfo;
                if (info != null)
                {
                    this.panelBottom.Visible = true;
                    this.btnImport.Enabled = false;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
                    {
                        ImportWorkUtils importWork = new ImportWorkUtils(info.UserID, info.UserName);
                        importWork.Import(this.inputFilePath, !this.chkWorkInfo.Checked, new RaiseChangedHandler(delegate(string content)
                        {
                            this.OnMessageEvent(MessageType.Normal, content);
                        }));

                        this.ThreadSafeMethod(new MethodInvoker(delegate()
                        {
                            this.btnImport.Enabled = true;
                        }));
                    }));
                }
                else
                {
                    this.OnMessageEvent(MessageType.PopupInfo, "无法获取用户信息！");
                }
            }
            catch (Exception x)
            {
                this.btnImport.Enabled = true;
                this.OnMessageEvent(MessageType.Normal | MessageType.PopupWarn, x.Message);
                Program.GlobalExceptionHandler(x);
            }
        }
        #endregion
        
        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        protected override void OnMessageEvent(MessageType type, string content)
        {
            if ((type & MessageType.Normal) == MessageType.Normal)
            {
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    this.lbMessage.Text = content;
                }));
            }
            base.OnMessageEvent(type, content);
        }
        #endregion
    }
}