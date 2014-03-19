//================================================================================
//  FileName: RectBox.cs
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Yaesoft.SFIT.Client.Controls
{
    /// <summary>
    /// 圆角矩形框。
    /// </summary>
    public class RoundRectBox : UserControl, INotifyPropertyChanged
    {
        #region 成员变量，构造函数。
        Color mouseMoveColor = Color.Transparent, oldColor = Color.Transparent;
        string strText, strToolTip;
        ToolTip tip;
        /// <summary>
        ///构造函数。
        /// </summary>
        public RoundRectBox()
        {
            this.tip = this.Container != null ? new ToolTip(this.Container) : new ToolTip();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                           ControlStyles.UserPaint |
                           ControlStyles.ResizeRedraw |
                           ControlStyles.OptimizedDoubleBuffer |
                           ControlStyles.StandardDoubleClick, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetAutoSizeMode(AutoSizeMode.GrowOnly);
            this.BackColor = Color.Transparent;

            this.mouseMoveColor = Color.Violet;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置文本名称。
        /// </summary>
        [Category("Data")]
        [Description("获取或设置文本名称。")]
        public override string Text
        {
            get
            {
                return this.strText;
            }
            set
            {
                if (this.strText != value)
                {
                    this.strText = value;
                    this.Refresh();
                }
            }
        }
        /// <summary>
        /// 获取或设置工具提示文本。
        /// </summary>
        [Category("Data")]
        [Description("获取或设置工具提示文本。")]
        public string ToolTip
        {
            get { return this.strToolTip; }
            set
            {
                if (this.strToolTip != value)
                {
                    this.strToolTip = value;
                }
            }
        }
        /// <summary>
        /// 获取或设置鼠标滑过时的颜色。
        /// </summary>
        [Category("Data")]
        [Description("获取或设置鼠标滑过时的颜色。")]
        public Color MouseMoveColor
        {
            get { return this.mouseMoveColor; }
            set
            {
                if (this.mouseMoveColor != value)
                {
                    this.mouseMoveColor = value;
                }
            }
        }
        /// <summary>
        /// 获取默认控件尺寸。
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(90, 60);
            }
        }
        /// <summary>
        /// 获取圆角半径。
        /// </summary>
        protected virtual int Radius
        {
            get { return 6; }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 重载创建控件。
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.DrawSmoothRectangle();
        }
        /// <summary>
        /// 重载。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            this.DrawSmoothRectangle();
            base.OnResize(e);
        }
        /// <summary>
        /// 重载绘制控件内容。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (g != null)
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.High;

                GraphicsPath path = new GraphicsPath();
                Rectangle re = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
                this.DrawArc(re, path, this.Radius);
                this.DrawBoxContent(g, re, e);
                g.DrawPath(new Pen(this.ForeColor, 1), path);
            }
        }
        #endregion

        #region 重载鼠标事件。
        /// <summary>
        /// 重载鼠标进入。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.tip != null && !string.IsNullOrEmpty(this.ToolTip))
                this.tip.SetToolTip(this, this.ToolTip);

            this.oldColor = this.BackColor;
            this.BackColor = this.MouseMoveColor;
        }
        /// <summary>
        /// 重载鼠标移出。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = this.oldColor;
        }
        #endregion

        #region INotifyPropertyChanged 成员
        /// <summary>
        /// 属性值发生变更事件。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region 辅助函数。
        /// <summary>
        /// 触发属性值发生变更事件。
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null && !string.IsNullOrEmpty(propertyName))
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region 线程安全。
        /// <summary>
        /// 线程安全方法调用。
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="method"></param>
        public virtual void ThreadSafeMethod(Control ctrl, MethodInvoker method)
        {
            if (ctrl != null && method != null)
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(method);
                }
                else
                {
                    method.Invoke();
                }
            }
        }
        /// <summary>
        /// 线程安全方法调用。
        /// </summary>
        /// <param name="method"></param>
        public virtual void ThreadSafeMethod(MethodInvoker method)
        {
            this.ThreadSafeMethod(this, method);
        }
        #endregion

        #region 绘制函数。
        /// <summary>
        /// 绘制平滑矩形区域。
        /// </summary>
        protected void DrawSmoothRectangle()
        {
            Rectangle r = new Rectangle(new Point(-1, -1), new Size(this.Width + this.Radius, this.Height + this.Radius));
            //变化平滑的矩形区域。
            if (this.Size != null)
            {
                GraphicsPath pathregion = new GraphicsPath();
                this.DrawArc(r, pathregion, this.Radius);
                this.Region = new Region(pathregion);
            }
        }
        /// <summary>
        /// 绘制弧形。
        /// </summary>
        /// <param name="re"></param>
        /// <param name="pa"></param>
        /// <param name="radius"></param>
        protected void DrawArc(Rectangle re, GraphicsPath pa, int radius)
        {
            if (re != null && pa != null)
            {
                int radiusX0Y0 = radius, radiusXFY0 = radius, radiusX0YF = radius, radiusXFYF = radius;

                pa.AddArc(re.X, re.Y, radiusX0Y0, radiusX0Y0, 180, 90);
                pa.AddArc(re.Width - radiusXFY0, re.Y, radiusXFY0, radiusXFY0, 270, 90);
                pa.AddArc(re.Width - radiusXFYF, re.Height - radiusXFYF, radiusXFYF, radiusXFYF, 0, 90);
                pa.AddArc(re.X, re.Height - radiusX0YF, radiusX0YF, radiusX0YF, 90, 90);
                pa.CloseFigure();
            }
        }
        /// <summary>
        /// 绘制方块内容。
        /// </summary>
        /// <param name="g"></param>
        /// <param name="re"></param>
        /// <param name="e"></param>
        protected virtual void DrawBoxContent(Graphics g, Rectangle re, PaintEventArgs e)
        {
        }
        #endregion
    }
    /// <summary>
    /// 圆角矩形框集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RoundRectBoxCollection<T> : ICollection<T>, IComparer<T>
       where T : RoundRectBox
    {
        #region 成员变量，构造函数。
        List<T> list;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public RoundRectBoxCollection()
        {
            this.list = new List<T>();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取集合数据。
        /// </summary>
        protected List<T> Items
        {
            get { return this.list; }
        }
        #endregion

        #region ICollection<T> 成员
        /// <summary>
        /// 添加对象。
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (item == null)
                return;
            if (!this.Contains(item))
                this.list.Add(item);
        }
        /// <summary>
        /// 清空集合。
        /// </summary>
        public void Clear()
        {
            this.list.Clear();
        }
        /// <summary>
        /// 是否存在。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool Contains(T item)
        {
            return this.list.Contains(item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array != null && arrayIndex > -1)
                this.list.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// 获取集合总数。
        /// </summary>
        public int Count
        {
            get { return this.list.Count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }
        /// <summary>
        /// 移除指定的对象。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool Remove(T item)
        {
            if (item != null)
            {
                return this.list.Remove(item);
            }
            return false;
        }

        #endregion

        #region IEnumerable<T> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            this.list.Sort(this);
            return this.list.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            this.list.Sort(this);
            foreach (T item in this.list)
                yield return item;
        }

        #endregion

        #region IComparer<T> 成员
        /// <summary>
        /// 排序。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual int Compare(T x, T y)
        {
            return string.Compare(x.Text, y.Text);
        }

        #endregion

        #region 处理函数。
        /// <summary>
        /// 绘制到控件上。
        /// </summary>
        /// <param name="panel">面板对象。</param>
        /// <param name="offsetX">横向间隔。</param>
        /// <param name="offsetY">纵向间隔。</param>
        public virtual void DrawToPanel(Panel panel, int offsetX, int offsetY)
        {
            if (panel != null)
            {
                int x = 0, y = 0;
                int width = panel.Width;
                List<T> list = new List<T>();

                #region 定位坐标。
                foreach (T item in this)
                {
                    if (x + offsetX + item.Width + 1 > width)
                    {
                        x = 0;
                        y += item.Height;
                    }
                    if (x == 0)
                    {
                        x += offsetX;
                        y += offsetY;
                    }
                    else
                    {
                        x += offsetX;
                    }
                    item.Location = new Point(x, y);
                    x += item.Width;
                    list.Add(item);
                }
                #endregion

                panel.SuspendLayout();
                panel.Controls.Clear();
                if (list.Count > 0)
                {
                    list.Sort(this);
                    panel.Controls.AddRange(list.ToArray());
                }
                panel.ResumeLayout(false);
                panel.Update();
            }
        }
        #endregion
    }
}
