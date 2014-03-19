//================================================================================
//  FileName: SplitContainerEx.cs
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
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Yaesoft.SFIT.Client.Controls
{
    /// <summary>
    /// 分离器扩展。
    /// </summary>
    [ToolboxBitmap(typeof(SplitContainer))]
    public class SplitContainerEx : SplitContainer
    {
        #region 成员变量，构造函数。
        bool mCollpased = false;
        bool mIsSplitterFixed = true;
        int heightOrWidth;
        MouseState mMouseState;
        SplitterPanelEnum mCollpasePanel;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public SplitContainerEx()
        {
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.mCollpasePanel = SplitterPanelEnum.Panel2;
            this.mMouseState = MouseState.Normal;
            this.SplitterWidth = 9;
            this.Panel1MinSize = this.Panel2MinSize = 0;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int SplitterWidth
        {
            get
            {
                return base.SplitterWidth;
            }
            set
            {
                base.SplitterWidth = 9;//(value < 9) ? 9 : value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int Panel1MinSize
        {
            get
            {
                return base.Panel1MinSize;
            }
            set
            {
                base.Panel1MinSize = 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int Panel2MinSize
        {
            get
            {
                return base.Panel2MinSize;
            }
            set
            {
                base.Panel2MinSize = 0;
            }
        }
        /// <summary>
        /// 获取或设置进行折叠或展开的SplitterPanel。
        /// </summary>
        [DefaultValue(SplitterPanelEnum.Panel2)]
        public SplitterPanelEnum CollpasePanel
        {
            get { return this.mCollpasePanel; }
            set
            {
                if (value != this.mCollpasePanel)
                {
                    this.mCollpasePanel = value;
                    this.Invalidate(this.ControlRect);
                }
            }
        }
        /// <summary>
        /// 获取是否为折叠状态。
        /// </summary>
        public bool IsCollpased
        {
            get { return this.mCollpased; }
        }
        /// <summary>
        /// 
        /// </summary>
        public new bool IsSplitterFixed
        {
            get { return base.IsSplitterFixed; }
            set
            {
                base.IsSplitterFixed = value;
                //此处设计防止运行时更改base.IsSplitterFixed属性时导致mIsSplitterFixed变量判断失效。
                if (value && (this.mIsSplitterFixed == false))
                {
                    this.mIsSplitterFixed = true;
                }
            }
        }
        /// <summary>
        /// 获取控制器绘制区域。
        /// </summary>
        private Rectangle ControlRect
        {
            get
            {
                Rectangle mRect = new Rectangle();
                if (this.Orientation == Orientation.Horizontal)
                {
                    mRect.X = this.Width <= 80 ? 0 : this.Width / 2 - 40;
                    mRect.Y = this.SplitterDistance;
                    mRect.Width = 80;
                    mRect.Height = 9;
                }
                else
                {
                    mRect.X = this.SplitterDistance;
                    mRect.Y = this.Height <= 80 ? 0 : this.Height / 2 - 40;
                    mRect.Width = 9;
                    mRect.Height = 80;
                }
                return mRect;
            }
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
            //绘制参数。
            bool collpase = false;
            if ((this.CollpasePanel == SplitterPanelEnum.Panel1 && this.mCollpased == false) ||
               (this.CollpasePanel == SplitterPanelEnum.Panel2 && this.mCollpased))
            {
                collpase = true;
            }
            Color color = (this.mMouseState == MouseState.Normal) ? SystemColors.ButtonShadow : SystemColors.ControlDarkDark;
            //需要绘制的图片。
            Bitmap bmp = this.CreateControlImage(collpase, color);
            //绘制区域。
            if (this.Orientation == Orientation.Vertical)
                bmp.RotateFlip(RotateFlipType.Rotate90FlipX);
            //清除绘制区域。
            //这里需要注意一点就是需要清除拆分器整个区域，如果仅清除绘制按钮区域，则会出现虚线状态。
            e.Graphics.SetClip(this.SplitterRectangle);
            e.Graphics.Clear(this.BackColor);
            //绘制。
            e.Graphics.DrawImage(bmp, this.ControlRect);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //鼠标在控制按钮区域。
            if (this.SplitterRectangle.Contains(e.Location))
            {
                if (this.ControlRect.Contains(e.Location))
                {
                    //如果拆分器可移动，则鼠标在控制按钮范围内时临时关闭拆分器。
                    if (this.IsSplitterFixed == false)
                    {
                        this.IsSplitterFixed = true;
                        this.mIsSplitterFixed = false;
                    }
                    this.Cursor = Cursors.Hand;
                    this.mMouseState = MouseState.Hover;
                    this.Invalidate(this.ControlRect);
                }
                else
                {
                    //如果拆分器为临时关闭，则开启拆分器。
                    if (this.mIsSplitterFixed == false)
                    {
                        this.IsSplitterFixed = false;
                        if (this.Orientation == Orientation.Horizontal)
                            this.Cursor = Cursors.HSplit;
                        else
                            this.Cursor = Cursors.VSplit;
                    }
                    else
                        this.Cursor = Cursors.Default;
                    this.mMouseState = MouseState.Normal;
                    this.Invalidate(this.ControlRect);
                }
            }
            base.OnMouseMove(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.mMouseState = MouseState.Normal;
            this.Invalidate(this.ControlRect);
            base.OnMouseLeave(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (this.ControlRect.Contains(e.Location))
                this.CollpaseOrExpand();
            base.OnMouseClick(e);
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 需要绘制的用于折叠窗口的按钮样式。
        /// </summary>
        /// <param name="collapse"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        protected Bitmap CreateControlImage(bool collapse, Color color)
        {
            Bitmap bmp = new Bitmap(80, 9);
            for (int x = 5; x <= 30; x += 5)
            {
                for (int y = 1; y <= 7; y += 3)
                {
                    bmp.SetPixel(x, y, color);
                }
            }
            for (int x = 50; x <= 75; x += 5)
            {
                for (int y = 1; y <= 7; y += 3)
                {
                    bmp.SetPixel(x, y, color);
                }
            }
            //控制小三角
            if (collapse)
            {
                int k = 0;
                for (int y = 7; y >= 1; y--)
                {
                    for (int x = 35 + k; x <= 45 - k; x++)
                    {
                        bmp.SetPixel(x, y, color);
                    }
                    k++;
                }
            }
            else
            {
                int k = 0;
                for (int y = 1; y <= 7; y++)
                {
                    for (int x = 35 + k; x <= 45 - k; x++)
                    {
                        bmp.SetPixel(x, y, color);
                    }
                    k++;
                }
            }
            return bmp;
        }
        /// <summary>
        /// 折叠或展开。
        /// </summary>
        public void CollpaseOrExpand()
        {
            if (this.mCollpased)
            {
                this.mCollpased = false;
                this.SplitterDistance = this.heightOrWidth;
            }
            else
            {
                this.mCollpased = true;
                this.heightOrWidth = this.SplitterDistance;
                if (this.CollpasePanel == SplitterPanelEnum.Panel1)
                    this.SplitterDistance = 0;
                else
                {
                    if (this.Orientation == Orientation.Horizontal)
                        this.SplitterDistance = this.Height - 9;
                    else
                        this.SplitterDistance = this.Width - 9;
                }
            }
            //局部刷新绘制。
            this.Invalidate(this.ControlRect);
        }
        #endregion

        #region 内置类。
        enum MouseState
        {
            /// <summary>
            /// 正常。
            /// </summary>
            Normal,
            /// <summary>
            /// 鼠标移入。
            /// </summary>
            Hover
        }
        /// <summary>
        /// 
        /// </summary>
        public enum SplitterPanelEnum
        {
            Panel1,
            Panel2
        }
        #endregion
    }
}
