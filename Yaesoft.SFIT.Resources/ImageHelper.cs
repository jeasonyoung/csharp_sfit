//================================================================================
//  FileName: ImageHelper.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/18
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
using System.Drawing.Drawing2D;
using System.IO;
namespace Yaesoft.SFIT.Resources
{
    /// <summary>
    /// 图形操作帮助类。
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// 制作图片的缩略图。
        /// </summary>
        /// <param name="originalImage"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image MakeThumbnail(Image originalImage, int width, int height)
        {
            if (originalImage != null && width > 0 && height > 0)
            {
                int x = 0, y = 0;
                int ow = originalImage.Width, oh = originalImage.Height;
                //width = ow * height / oh;
                height = oh * width / ow;
                //创建目标图像。
                Image bitmap = new Bitmap(width, height);
                //新建一个画板。
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    //设置高质量插值法。
                    g.InterpolationMode = InterpolationMode.High;
                    //设置高质量，低速度呈现平滑程度。
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    //清空画布并以透明背景色填空。
                    g.Clear(Color.White);
                    //在指定位置并且按指定大小绘制原图片的指定部分。
                    g.DrawImage(originalImage, new Rectangle(0, 0, width, height), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);
                }
                return bitmap;
            }
            return originalImage;
        }
        /// <summary>
        /// 制作图片的缩略图。
        /// </summary>
        /// <param name="imageStream">图片数据流。</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image MakeThumbnail(Stream imageStream, int width, int height)
        {
            if (imageStream != null)
            {
                Image source = Image.FromStream(imageStream);
                if (source != null)
                    return MakeThumbnail(source, width, height);
            }
            return null;
        }
    }
}
