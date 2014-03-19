//================================================================================
//  FileName: CaptureScreenWindow.cs
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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.Client.Forms
{
    /// <summary>
    /// 获取屏幕图片。
    /// </summary>
    /// <param name="image"></param>
    public delegate void CaptureScreenHandler(Image image);
    /// <summary>
    /// 捕获屏幕。
    /// </summary>
    public partial class CaptureScreenWindow : Form
    {
        #region 成员变量，构造函数。
        string strMousePointsFormater, strCatcherSizeFormater;
        Bitmap screenImage = null;
        Point startCatcherPoint = Point.Empty;
        bool isMouseLeftDown = false, isMoveCatcherBorder = false;
        Cursor createCatcherCursor = null, defaultCursor = Cursors.Default;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public CaptureScreenWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region 设置事件。
        /// <summary>
        /// 截图事件。
        /// </summary>
        public event CaptureScreenHandler CopyScreenCutEvent;
        /// <summary>
        /// 触发截图事件。
        /// </summary>
        /// <param name="img"></param>
        protected void OnCopyScreenCutEvent(Image img)
        {
            CaptureScreenHandler handler = this.CopyScreenCutEvent;
            if (img != null && handler != null)
            {
                handler(img);
            }
        }
        /// <summary>
        /// 截屏窗体关闭。
        /// </summary>
        public event EventHandler CopyScreenWindowClosed;
        /// <summary>
        /// 触发截屏窗体关闭。
        /// </summary>
        protected void OnCopyScreenWindowClosed()
        {
            EventHandler handler = this.CopyScreenWindowClosed;
            if (handler != null)
                handler(null, EventArgs.Empty);
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureScreenWindow_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.strMousePointsFormater = this.lbMousePoints.Text;
            this.strCatcherSizeFormater = this.lbCatcherSize.Text;

            this.lbMousePoints.Text = string.Format(this.strMousePointsFormater, 0, 0);
            this.lbCatcherSize.Text = string.Format(this.strCatcherSizeFormater, 0, 0);

            #region 设置光标。
            byte[] curBuffer = Properties.Resources.Cur;
            if (curBuffer != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(curBuffer, 0, curBuffer.Length);
                    ms.Position = 0;
                    this.createCatcherCursor = new Cursor(ms);
                }
            }
            this.Cursor = this.defaultCursor;
            #endregion

            #region 设置窗体大小和背景图片。
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.screenImage = this.CaptureScreen(this.Bounds.Size);
            this.BackgroundImage = CaptureScreenWindow.GrayImage(this.screenImage);
            #endregion

            #region 加载捕获窗口事件。
            this.panelScreenCatcher.Visible = false;
            this.panelScreenCatcher.MouseUp += this.CaptureScreenWindow_MouseUp;
            this.panelScreenCatcher.MouseDown += this.catcher_MouseDown;
            this.panelScreenCatcher.MouseMove += this.catcher_MouseMove;
            this.panelScreenCatcher.MouseDoubleClick += this.CaptureScreenWindow_MouseDoubleClick;
            this.panelScreenCatcher.Paint += this.catcher_Paint;
            this.panelScreenCatcher.Resize += new EventHandler(delegate(object obj, EventArgs args)
            {
                Panel p = obj as Panel;
                if (p != null)
                {
                    p.Refresh();
                }
            });
            #endregion
        }
        /// <summary>
        /// 首次按下键时事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureScreenWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.CaptureScreenWindow_MouseDown(sender, new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
            }
        }
        /// <summary>
        /// 鼠标移动事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureScreenWindow_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbMousePoints.Text = string.Format(this.strMousePointsFormater, e.X, e.Y);
            if (this.isMouseLeftDown)
            {
                this.Cursor = this.createCatcherCursor;
                Rectangle rect = this.CreateCatcherRectangle(this.startCatcherPoint, e.Location);
                this.lbCatcherSize.Text = string.Format(this.strCatcherSizeFormater, rect.Width, rect.Height);
                this.panelScreenCatcher.Bounds = rect;
                if (!this.panelScreenCatcher.Visible)
                {
                    this.panelScreenCatcher.Visible = true;
                }
            }
            else if(!this.panelScreenCatcher.ClientRectangle.Contains(e.Location))
            {
                this.Cursor = this.defaultCursor;
            }
        }
        /// <summary>
        /// 鼠标按下事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureScreenWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //右键退出。
                if (this.panelScreenCatcher.Visible)
                {
                    this.startCatcherPoint = Point.Empty;
                    this.panelScreenCatcher.Visible = false;
                }
                this.Close();
            }
            else if (e.Button == MouseButtons.Left && !this.panelScreenCatcher.Visible)
            {
                //左键开始截图。
                this.startCatcherPoint = e.Location;
                this.isMouseLeftDown = true;
            }
        }
        /// <summary>
        /// 鼠标抬起事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureScreenWindow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.isMouseLeftDown)
            {
                this.isMouseLeftDown = false;
                this.startCatcherPoint = Point.Empty;
            }
        }
        /// <summary>
        /// 鼠标双击。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureScreenWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!this.panelScreenCatcher.Visible)
                {
                    MessageBox.Show(this, "请截取图片！", "截图工具", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Rectangle rect = this.panelScreenCatcher.Bounds;
                    if (rect != Rectangle.Empty && this.screenImage != null)
                    {
                        using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height))
                        {
                            using (Graphics g = Graphics.FromImage(bitmap))
                            {
                                Rectangle dest = new Rectangle(0, 0, rect.Width, rect.Height);
                                g.DrawImage(this.screenImage, dest, rect.X, rect.Y, rect.Width, rect.Height, GraphicsUnit.Pixel);
                            }
                            Clipboard.SetImage(bitmap);
                            this.OnCopyScreenCutEvent(bitmap);
                        }
                    }
                    this.Close();
                }
            }
            catch (Exception x)
            {
                UtilTools.OnExceptionRecord(x, typeof(CaptureScreenWindow));
                MessageBox.Show(x.Message, "截图保存时发生异常：", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        /// <summary>
        /// 界面关闭事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureScreenWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.OnCopyScreenWindowClosed();
        }
        /// <summary>
        /// 鼠标移入Panel时事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_MouseEnter(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                int x = 10, y = 10;
                if (p.Right < this.Width / 2)
                {
                    x = this.Width - p.Width - 20;
                }
                p.Location = new Point(x, y);
            }
        }

        #region 捕获窗口事件。
        /// <summary>
        /// 捕获窗口鼠标按下。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void catcher_MouseDown(object sender, MouseEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null && e.Button == MouseButtons.Right)
            {
                p.Visible = false;
            }
        }
        /// <summary>
        ///  捕获窗口鼠标移动。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void catcher_MouseMove(object sender, MouseEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                this.lbMousePoints.Text = string.Format(this.strMousePointsFormater, p.Left + e.X, p.Top + e.Y);
                int d = 7;
                if (e.X < d)
                {
                    #region 左
                    if (e.Y < d)
                    {
                        p.Cursor = Cursors.SizeNWSE;//左上。
                        if (e.Button == MouseButtons.Left)
                        {
                            this.isMoveCatcherBorder = true;
                            this.ResizeCatcher(p, 0, e.Location);
                        }
                    }
                    else if (Math.Abs(e.Y - p.Height) < d)
                    {
                        p.Cursor = Cursors.SizeNESW;//左下。
                        if (e.Button == MouseButtons.Left)
                        {
                            this.isMoveCatcherBorder = true;
                            this.ResizeCatcher(p, 5, e.Location);
                        }
                    }
                    else
                    {
                        p.Cursor = Cursors.SizeWE;//左。
                        if (e.Button == MouseButtons.Left)
                        {
                            this.isMoveCatcherBorder = true;
                            this.ResizeCatcher(p, 3, e.Location);
                        }
                    }
                    #endregion
                }
                else if (Math.Abs(e.X - p.Width) < d)
                {
                    #region 右。
                    if (e.Y < d)
                    {
                        p.Cursor = Cursors.SizeNESW;//右上。
                        if (e.Button == MouseButtons.Left)
                        {
                            this.isMoveCatcherBorder = true;
                            this.ResizeCatcher(p, 2, e.Location);
                        }
                    }
                    else if (Math.Abs(e.Y - p.Height) < d)
                    {
                        p.Cursor = Cursors.SizeNWSE;//右下。
                        if (e.Button == MouseButtons.Left)
                        {
                            this.isMoveCatcherBorder = true;
                            this.ResizeCatcher(p, 7, e.Location);
                        }
                    }
                    else
                    {
                        p.Cursor = Cursors.SizeWE;//右。
                        if (e.Button == MouseButtons.Left)
                        {
                            this.isMoveCatcherBorder = true;
                            this.ResizeCatcher(p, 4, e.Location);
                        }
                    }
                    #endregion
                }
                else if (e.Y < d || Math.Abs(e.Y - p.Height) < d)
                {
                    p.Cursor = Cursors.SizeNS;//中上 中下。
                    if (e.Button == MouseButtons.Left)
                    {
                        this.isMoveCatcherBorder = true;
                        if (p.Height - e.Y >= e.Y)
                        {
                            //中上
                            this.ResizeCatcher(p, 1, e.Location);
                        }
                        else
                        {
                            //中下
                            this.ResizeCatcher(p, 6, e.Location);
                        }
                    }
                }
                else
                {
                    p.Cursor = Cursors.SizeAll;//非边缘区域。
                    Rectangle activeRect = new Rectangle(p.Width / 4, p.Height / 4, p.Width / 2, p.Height / 2);
                    if (activeRect.Contains(e.Location))
                    {
                        this.isMoveCatcherBorder = false;
                    }
                    if (e.Button == MouseButtons.Left && !this.isMoveCatcherBorder)
                    {
                        //按下鼠标左键并拖动窗口，改变窗口位置。
                        p.Location = new Point(p.Left + e.X - p.Width / 2, p.Top + e.Y - p.Height / 2);
                    }
                }
            }
        }
        /// <summary>
        /// 绘制。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void catcher_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null && p.Bounds != Rectangle.Empty)
            {
                Rectangle rect = p.Bounds;
                if (rect.Width > 0 && rect.Height > 0)
                {
                    using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            //裁剪背景图片。
                            if (this.screenImage != null)
                            {
                                Rectangle dest = new Rectangle(0, 0, rect.Width, rect.Height);
                                g.DrawImage(this.screenImage, dest, rect.X, rect.Y, rect.Width, rect.Height, GraphicsUnit.Pixel);
                            }
                            //绘制矩形边框与8个小方块。
                            Pen pen = new Pen(Color.Red);
                            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                            pen.DashPattern = new float[] { 2, 3 };
                            g.DrawRectangle(pen, new Rectangle(1, 1, rect.Width - 2, rect.Height - 2));
                            //绘制小方块。
                            for (int i = 0; i <= 7; i++)
                            {
                                g.FillRectangle(Brushes.Red, this.GetBoundsOfSmallBlock(rect, i));
                            }
                        }
                        e.Graphics.DrawImage(bitmap, 0, 0);
                    }
                }
            }
        }
        #endregion
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 创建捕获窗口。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private Rectangle CreateCatcherRectangle(Point start, Point end)
        {
            Rectangle rect = new Rectangle();
            rect.X = Math.Min(start.X, end.X);
            rect.Y = Math.Min(start.Y, end.Y);
            rect.Width = Math.Abs(end.X - start.X);
            rect.Height = Math.Abs(end.Y - start.Y);
            return rect;
        }
        /// <summary>
        /// 捕获当前屏幕。
        /// </summary>
        private Bitmap CaptureScreen(Size size)
        {
            Bitmap img = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.CopyFromScreen(0, 0, 0, 0, size);
            }
            return img;
        }
        /// <summary>
        /// 灰色位图。
        /// </summary>
        /// <param name="sourceImg">源图。</param>
        /// <returns>目标结果图。</returns>
        private static Image GrayImage(Image sourceImg)
        {
            if (sourceImg != null)
            {
                Bitmap bitmap = new Bitmap(sourceImg.Width, sourceImg.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    ColorMatrix colorMatrix = new ColorMatrix(new float[][] { 
                        new float[] {.3f, .3f, .3f, 0, 0}, 
                        new float[] {.59f, .59f, .59f, 0, 0},
                        new float[] {.11f, .11f, .11f, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                    });
                    using (ImageAttributes attributes = new ImageAttributes())
                    {
                        attributes.SetColorMatrix(colorMatrix);
                        g.DrawImage(sourceImg, new Rectangle(0, 0, sourceImg.Width, sourceImg.Height), 
                            0, 0, sourceImg.Width, sourceImg.Height, GraphicsUnit.Pixel, attributes);
                    }
                }
                return bitmap;
            }
            return null;
        }
        /// <summary>
        /// 获取指定序号的小方块的位置。
        /// </summary>
        /// <param name="sourceRect"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private Rectangle GetBoundsOfSmallBlock(Rectangle sourceRect,int index)
        {
            int x = 0, y = 0, oWidth = sourceRect.Width, oHeight = sourceRect.Height;
            #region 定位坐标。
            switch (index)
            {
                case 0:
                    {
                        x = 0;
                        y = 0;
                    }
                    break;
                case 1:
                    {
                        x = oWidth / 2 - 3;
                        y = 0;
                    }
                    break;
                case 2:
                    {
                        x = oWidth - 4;
                        y = 0;
                    }
                    break;
                case 3:
                    {
                        x = 0;
                        y = oHeight / 2 - 3;
                    }
                    break;
                case 4:
                    {
                        x = oWidth - 4;
                        y = oHeight / 2 - 3;
                    }
                    break;
                case 5:
                    {
                        x = 0;
                        y = oHeight - 4;
                    }
                    break;
                case 6:
                    {
                        x = oWidth / 2 - 3;
                        y = oHeight - 4;
                    }
                    break;
                case 7:
                    {
                        x = oWidth - 4;
                        y = oHeight - 4;
                    }
                    break;
            }
            #endregion

            return new Rectangle(x, y, 4, 4);
        }
        /// <summary>
        /// 重绘捕获框大小。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="index"></param>
        /// <param name="e"></param>
        private void ResizeCatcher(Panel p, int index, Point e)
        {
            int left = p.Left, top = p.Top;
            Point point = new Point(left + e.X, top + e.Y);
            int w = p.Width, h = p.Height;
            this.lbCatcherSize.Text = string.Format(this.strCatcherSizeFormater, w, h);
            switch (index)
            {
                case 0:
                    {
                        //左上。
                        p.Bounds = this.CreateCatcherRectangle(point, new Point(left + w, top + h));
                    }
                    break;
                case 1:
                    {
                        //中上。
                        p.Bounds = this.CreateCatcherRectangle(new Point(left, point.Y), new Point(left + w, top + h));
                    }
                    break;
                case 2:
                    {
                        //右上。
                        p.Bounds = this.CreateCatcherRectangle(new Point(left, top + h), point);
                    }
                    break;
                case 3:
                    {
                        //左。
                        p.Bounds = this.CreateCatcherRectangle(new Point(point.X, p.Top), new Point(left + w, top + h));
                    }
                    break;
                case 4:
                    {
                        //右。
                        p.Bounds = this.CreateCatcherRectangle(new Point(left, top + h), new Point(point.X, top));
                    }
                    break;
                case 5:
                    {
                        //左下。
                        p.Bounds = this.CreateCatcherRectangle(point, new Point(left + w, p.Top));
                    }
                    break;
                case 6:
                    {
                        //中下。
                        p.Bounds = this.CreateCatcherRectangle(new Point(left, top), new Point(left + w, point.Y));
                    }
                    break;
                case 7:
                    {
                        //右下。
                        p.Bounds = this.CreateCatcherRectangle(p.Location, point);
                    }
                    break;
            }
        }
        #endregion
    }
}