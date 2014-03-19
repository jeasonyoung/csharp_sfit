//================================================================================
//  FileName: MouseThumbnailWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-11-15
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
using System.Windows.Forms;
using Yaesoft.SFIT;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Utils;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 鼠标缩略图。
    /// </summary>
    public partial class MouseThumbnailWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        LocalStudentWorkStore store;
        LocalStudent ls;
        Image image = null;
        Point point = Point.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="ls"></param>
        public MouseThumbnailWindow(LocalStudentWorkStore store, LocalStudent ls, Point point)
        {
            this.store = store;
            this.ls = ls;
            this.point = point;
            InitializeComponent();
        }
        #endregion

        #region 事件注册。
        /// <summary>
        /// 查看缩略图原图。
        /// </summary>
        public event EventHandler ViewThumbnailHandler;
        /// <summary>
        /// 
        /// </summary>
        protected void OnViewThumbnail()
        {
            EventHandler handler = this.ViewThumbnailHandler;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseThumbnailWindow_Load(object sender, EventArgs e)
        {
            bool isShow = false;
            if (this.store != null && this.ls != null && ls.Work != null)
            {
                this.image = ThumbnailsHelpers.CreateThumbnailFrist(this.store, ls.StudentID, 400, 300);
                if (isShow = (this.image != null))
                {
                    if (this.point != Point.Empty)
                        this.Bounds = new Rectangle(this.point, this.image.Size);
                    else
                        this.Size = this.image.Size;
                    this.Refresh();
                }
            }
            if (!isShow) this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseThumbnailWindow_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            this.OnViewThumbnail();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseThumbnailWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
            this.OnViewThumbnail();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.image != null)
            {
                e.Graphics.DrawImage(this.image, 0, 0);
            }
        }
        #endregion
    }
}