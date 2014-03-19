//================================================================================
//  FileName: StartControl.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/7/9
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

using Yaesoft.SFIT.Client.Controls;
namespace Yaesoft.SFIT.Client.TeaHost.Controls
{
    /// <summary>
    /// 五角星。
    /// </summary>
    public class FiveStartControl : Control
    {
        #region 成员变量，构造函数。
        Color checkedColor = Color.Red, borderColor = Color.Yellow;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public FiveStartControl()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                           ControlStyles.UserPaint |
                           ControlStyles.ResizeRedraw |
                           ControlStyles.OptimizedDoubleBuffer |
                           ControlStyles.StandardDoubleClick, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetAutoSizeMode(AutoSizeMode.GrowOnly);
            this.BackColor = Color.Transparent;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 默认尺寸。
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(18, 18);
            }
        }
        /// <summary>
        /// 获取或设置是否选中（选中会有填充色）。
        /// </summary>
        public bool Checked
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置选中颜色。
        /// </summary>
        public Color CheckedColor
        {
            get { return this.checkedColor; }
            set { this.checkedColor = value; }
        }
        /// <summary>
        /// 获取或设置边框颜色。
        /// </summary>
        public Color BorderColor
        {
            get { return this.borderColor; }
            set { this.borderColor = value; }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 创建坐标。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        protected Point[] CreatePoints(int width, int height)
        {
            int cx = width;
            int cy = height;
            Point[] apt = new Point[5];
            for (int i = 0; i < apt.Length; i++)
            {
                double dAngle = (i * 0.8 - 0.5) * Math.PI;
                int x = (int)(cx * (0.25 + 0.24 * Math.Cos(dAngle)));
                int y = (int)(cy * (0.5 + 0.48 * Math.Sin(dAngle)));
                apt[i] = new Point(x, y);
            }
            return apt;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 单击事件。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            this.Checked = !this.Checked;
            base.OnClick(e);
            this.Refresh();
        }
        /// <summary>
        /// 
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

                Point[] points = this.CreatePoints(this.Width, this.Height);
                if (points != null && points.Length > 0)
                {
                    if (this.Checked)
                    {
                        g.FillPolygon(new SolidBrush(this.CheckedColor), points, FillMode.Winding);
                    }
                    else
                    {
                        g.FillPolygon(new SolidBrush(this.borderColor), points, FillMode.Winding);
                    }
                }
            }
        }
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class FiveStartControlGroup : UserControl,IComparer<FiveStartControl>
    {
        #region 成员变量，构造函数。
        List<FiveStartControl> list = null;
        Color oldColor = Color.Transparent;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public FiveStartControlGroup()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                         ControlStyles.UserPaint |
                         ControlStyles.ResizeRedraw |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.StandardDoubleClick, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetAutoSizeMode(AutoSizeMode.GrowOnly);
            this.BackColor = Color.Transparent;
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="count">五角星个数。</param>
        /// <param name="defSelected">默认选中个数。</param>
        public FiveStartControlGroup(int count, int defSelected)
            : this()
        {
            this.list = new List<FiveStartControl>();
            if ((count > 0) && (defSelected >= 0) && (defSelected <= count))
            {
                for (int i = 0; i < count; i++)
                {
                    this.list.Add(new FiveStartControl());
                }
                //
                if (defSelected > 0)
                {
                    for (int j = 0; j < defSelected; j++)
                    {
                        this.list[j].Checked = true;
                    }
                }
                this.initComponent();
            }
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="count">五角星个数。</param>
        public FiveStartControlGroup(int count)
            : this(count, 0)
        {
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取选中的五角星个数。
        /// </summary>
        public int CheckCount
        {
            get
            {
                int result = 0;
                if (this.list != null && this.list.Count > 0)
                {
                    this.list.Sort(this);
                    foreach (FiveStartControl fsc in this.list)
                    {
                        if (fsc.Checked)
                        {
                            result++;
                        }
                    }
                }
                return result;
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
            RoundRectBox parent = this.Parent as RoundRectBox;
            if (parent != null)
            {
                this.oldColor = parent.BackColor;
                this.BackColor = parent.MouseMoveColor;
            }
        }
        /// <summary>
        /// 重载鼠标移出。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            RoundRectBox parent = this.Parent as RoundRectBox;
            if (parent != null)
            {
                this.BackColor = this.oldColor;
            }
        }
        #endregion
        
        #region IComparer<FiveStartControl> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(FiveStartControl x, FiveStartControl y)
        {
            return x.Checked.CompareTo(y.Checked);
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 
        /// </summary>
        private void initComponent()
        {
            if (this.list != null && this.list.Count > 0)
            {
                this.SuspendLayout();
                int x = this.Location.X;
                int y = this.Location.Y;

                int height = this.Height;
                int h = height;
               
                for (int i = 0; i < this.list.Count; i++)
                {
                    int w = this.list[i].Width;
                    if (i == 0)
                    {
                        x += 2;
                    }
                    this.list[i].Location = new Point(x + (i * w), y + (height - h));
                    this.list[i].Click += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        this.OnClick(e);
                    });
                }
                this.list.Sort(this);
                this.Controls.AddRange(this.list.ToArray());
                this.ResumeLayout(false);
            }
        }
        #endregion
    }
}
