//================================================================================
//  FileName: ThumbnailsControl.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/6
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
    /// 缩略图控件。
    /// </summary>
    public class ThumbnailsControl : RoundRectBox
    {
        #region 成员变量，构造函数。
        Color colorStuName = Color.Gray;
        CheckBox chkBox = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ThumbnailsControl()
            : base()
        {
            this.chkBox = new CheckBox();
            this.chkBox.BackColor = Color.Transparent;
            this.Controls.Add(this.chkBox);
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置作品ID。
        /// </summary>
        public string WorkID { get; set; }
        /// <summary>
        /// 获取或设置学生ID。
        /// </summary>
        public string StudentID { get; set; }
        /// <summary>
        /// 获取或设置学生名称。
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 获取或设置作品时间。
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 获取或设置学生名称前景色。
        /// </summary>
        public Color StudentNameForeColor
        {
            get { return this.colorStuName; }
            set { this.colorStuName = value; }
        }
        /// <summary>
        /// 获取或设置缩略图。
        /// </summary>
        public Image Thumbnails { get; set; }
        /// <summary>
        /// 获取或设置是否选中。
        /// </summary>
        public bool Checked
        {
            get { return this.chkBox.Checked; }
            set { this.chkBox.Checked = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, 150);
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 绘制内容。
        /// </summary>
        /// <param name="g"></param>
        /// <param name="re"></param>
        /// <param name="e"></param>
        protected override void DrawBoxContent(Graphics g, Rectangle re, PaintEventArgs e)
        {
            float height = 0;
            if (!string.IsNullOrEmpty(this.StudentName))
                height = g.MeasureString(this.StudentName, this.Font).Height;
            else
                height = this.chkBox.Height;

            Rectangle rImg = new Rectangle(re.X, re.Y, re.Width, (int)(re.Height - height));
            if (this.Thumbnails != null)
            {
                g.DrawImage(this.Thumbnails, rImg);
            }
            if (!string.IsNullOrEmpty(this.Text))
            {
                SizeF sizef = g.MeasureString(this.Text, this.Font, rImg.Width);
                g.DrawString(this.Text, this.Font,
                    new SolidBrush(this.ForeColor),
                    (rImg.Width - (int)sizef.Width) / 2,
                    rImg.Height - sizef.Height);
            }

            if (!string.IsNullOrEmpty(this.StudentName))
            {
                this.chkBox.ForeColor = this.StudentNameForeColor;
                this.chkBox.Text = this.StudentName;
            }
            int y = rImg.Height + (re.Height - rImg.Height - this.chkBox.Height) / 2;
            this.chkBox.Location = new Point(2, y);
            this.chkBox.Width = re.Width - 2;
        }
        #endregion
    }
    /// <summary>
    /// 缩略图控件集合。
    /// </summary>
    public class ThumbnailsControls : RoundRectBoxCollection<ThumbnailsControl>
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ThumbnailsControls()
        {
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool Contains(ThumbnailsControl item)
        {
            if (item != null)
            {
                int index = this.Items.FindIndex(new Predicate<ThumbnailsControl>(delegate(ThumbnailsControl sender)
                {
                    return (sender != null) && (sender.WorkID == item.WorkID);
                }));
                return index > -1;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(ThumbnailsControl x, ThumbnailsControl y)
        {
            int result = DateTime.Compare(x.Time, y.Time);
            if (result == 0)
            {
                string strX = string.Format("{0}-{1}", x.StudentName, x.Text);
                string strY = string.Format("{0}-{1}", y.StudentName, y.Text);
                result = string.Compare(strX, strY);
            }
            if (result != 0)
                return -result;
            return result;
        }
        #endregion
    }
}
