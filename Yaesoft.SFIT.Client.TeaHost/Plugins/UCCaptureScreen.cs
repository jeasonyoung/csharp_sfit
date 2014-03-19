//================================================================================
//  FileName: UCCaptureScreen.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/13
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

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.Client.TeaHost.Plugins
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCCaptureScreen : BaseUserControl
    {
        #region 构造函数。
        bool bShowWin = false;
        CaptureScreenWindow csw = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCCaptureScreen(ICoreService service)
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
        private void UCCaptureScreen_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnToolTipEvent(this, "截屏工具,按F4可直接进入截屏.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreen_MouseEnter(object sender, EventArgs e)
        {
            if (this.Enabled)
                this.BackgroundImage = Properties.Resources.CaptureScreenMove;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreen_MouseLeave(object sender, EventArgs e)
        {
            if (this.Enabled)
                this.BackgroundImage = Properties.Resources.CaptureScreen;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreen_EnabledChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = this.Enabled ? Properties.Resources.CaptureScreen : Properties.Resources.CaptureScreenDisabled;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreen_Click(object sender, EventArgs e)
        {
            this.UCCaptureScreen_DoubleClick(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCaptureScreen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = !(this.bShowWin = true);
                this.csw = new CaptureScreenWindow();
                this.csw.CopyScreenCutEvent += new CaptureScreenHandler(delegate(Image data)
                {
                    if (data != null)
                    {
                        string path = string.Format("{0}\\截屏图片_{1:HH-mm-ss}.jpg", System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop), DateTime.Now);
                        data.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
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
                this.UCCaptureScreen_Click(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}