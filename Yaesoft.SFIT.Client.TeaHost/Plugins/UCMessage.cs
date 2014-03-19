//================================================================================
//  FileName: UCMessage.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/2
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
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
namespace Yaesoft.SFIT.Client.TeaHost.Plugins
{
    /// <summary>
    /// 消息插件。
    /// </summary>
    public partial class UCMessage : BaseUserControl
    {
        #region 成员变量，构造函数。
        string message = string.Empty;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        public UCMessage(ICoreService service)
            : base(service)
        {
            InitializeComponent();
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                this.OnToolTipEvent(this, message);
                this.message = Regex.Replace(message, "\\r\\n", string.Empty);
                this.Refresh();
            }
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCMessage_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.message))
            {
                int count = this.message.Length;
                SizeF size = e.Graphics.MeasureString(this.message, this.Font);
                int len = (int)((this.Width * count) / size.Width);
                if ((count > len) && (len > 3))
                {
                    this.message = this.message.Substring(0, len - 3) + "...";
                }

                int y = (int)((this.Height - size.Height) / 2);
                if (y < 0)
                {
                    y = 0;
                }
                e.Graphics.DrawString(this.message, this.Font, new SolidBrush(this.ForeColor), 4, y);
            }
            base.OnPaint(e);
        }
        #endregion
    }
}