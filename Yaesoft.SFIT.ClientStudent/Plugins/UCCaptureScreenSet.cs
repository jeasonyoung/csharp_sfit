//================================================================================
//  FileName: UCCaptureScreenPlugin.cs
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.ClientStudent.Plugins
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCCaptureScreenSet : BaseUserControl
    {
        #region 成员变量，构造函数。
        bool bShowWin = false;
        CaptureScreenWindow csw = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public UCCaptureScreenSet(ICoreService service)
            : base(service)
        {
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreenSet_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnToolTipEvent(this, "截屏工具,按F4可直接进入截屏.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreenSet_MouseEnter(object sender, EventArgs e)
        {
            if (this.Enabled)
                this.BackgroundImage = Properties.Resources.CaptureScreenMove;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreenSet_MouseLeave(object sender, EventArgs e)
        {
            if (this.Enabled)
                this.BackgroundImage = Properties.Resources.CaptureScreen;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreenSet_EnabledChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = this.Enabled ? Properties.Resources.CaptureScreen : Properties.Resources.CaptureScreenDisabled;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreenSet_Click(object sender, EventArgs e)
        {
            this.UCCaptureScreenSet_DoubleClick(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreenSet_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = !(this.bShowWin = true);
                this.csw = new CaptureScreenWindow();
                FileUploadItems items = null;
                this.csw.CopyScreenCutEvent += new CaptureScreenHandler(delegate(Image data)
                {
                    if (data != null)
                    {
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        Catalog c = this.CoreService["catalog"] as Catalog;
                        if (c != null)
                        {
                            path += string.Format("\\{0}_截屏_{1:HHmmss}.jpg", c.CatalogName, DateTime.Now);
                        }
                        else
                        {
                            path += string.Format("\\截屏_{0:HHmmss}.jpg", DateTime.Now);
                        }
                        data.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

                        if (System.IO.File.Exists(path))
                        {
                            items = new FileUploadItems();
                            string strFileName = System.IO.Path.GetFileName(path);
                            string strExt = System.IO.Path.GetExtension(path);

                            items.Add(new FileUploadItem(strFileName, strExt, path));
                        }
                    }
                });
                this.csw.CopyScreenWindowClosed += new EventHandler(delegate(object o, EventArgs x)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object obj)
                    {
                        Thread.Sleep(100);
                        this.ThreadSafeMethod(new MethodInvoker(delegate()
                        {
                            this.AddUploadWindow(items);
                        }));
                    }));
                });
                this.csw.ShowDialog(this);
            }
            catch (Exception x)
            {
                Program.GlobalExceptionHandler(x);
                this.OnMessageEvent(MessageType.PopupWarn, "截图异常：" + x.Message);
            }
            finally
            {
                this.Enabled = !(this.bShowWin = false);
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotKey"></param>
        public override void ProcessHotkey(string hotKey)
        {
            if (!this.bShowWin)
            {
                this.UCCaptureScreenSet_Click(this, EventArgs.Empty);
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        protected void AddUploadWindow(FileUploadItems items)
        {
            StudentMainWindow mainForm = this.ParentForm as StudentMainWindow;
            if (mainForm != null && items != null && items.Count > 0)
            {
                mainForm.AddScreenFileObserver(items[0]);
                mainForm.ShowUploadWindowDialog(items);
            }
        }
        #endregion
    }
}