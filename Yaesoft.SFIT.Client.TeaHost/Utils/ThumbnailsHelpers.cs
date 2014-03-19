//================================================================================
//  FileName: ThumbnailsHelpers.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-19
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Yaesoft.SFIT.Resources;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Controls;
namespace Yaesoft.SFIT.Client.TeaHost.Utils
{
    /// <summary>
    /// 缩略图帮助类。
    /// </summary>
    internal static class ThumbnailsHelpers
    {
        #region 成员变量，构造函数。
        private static Image Def_NULL_Image;
        private static Hashtable DEF_IMG_CACHE = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 静态构造函数。
        /// </summary>
        static ThumbnailsHelpers()
        {
            Def_NULL_Image = ResourcesManager.GetDefaultNullImageResource(DefaultThumbnailFormat.ThumbnailWidth, DefaultThumbnailFormat.ThumbnailHeight);
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        private static Image LoadDefaultNULLImage(int w, int h)
        {
            string key = w + "x" + h;
            Image img = DEF_IMG_CACHE[key] as Image;
            if (img == null && Def_NULL_Image != null)
            {
                img = ImageHelper.MakeThumbnail(Def_NULL_Image, w, h);
                if (img != null)
                {
                    DEF_IMG_CACHE[key] = img;
                }
            }
            return img;
        }
        #endregion

        #region 构建学生作品缩略图对象。
        /// <summary>
        /// 创建缩略图。
        /// </summary>
        /// <param name="store"></param>
        /// <param name="studentID"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Image CreateThumbnailFrist(LocalStudentWorkStore store, string studentID, int w, int h)
        {
            if (store != null && !string.IsNullOrEmpty(studentID) && store.Students != null)
            {
                LocalStudentWork lsw = null;
                LocalStudent ls = store.Students[studentID];
                if (ls != null && ((lsw = ls.Work) != null) && (lsw.WorkFiles != null && lsw.WorkFiles.Count > 0))
                {
                    foreach (LocalStudentWorkFile wf in lsw.WorkFiles)
                    {
                        Image img = CreateThumbnail(store, ls, wf, w, h);
                        if (img != null)
                        {
                            return img;
                        }
                    }
                    return LoadDefaultNULLImage(w, h);
                }
            }
            return null;
        }
        /// <summary>
        /// 创建缩略图。
        /// </summary>
        /// <param name="store"></param>
        /// <param name="studentID"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Image[] CreateThumbnails(LocalStudentWorkStore store, string studentID, int w, int h)
        {
            List<Image> list = new List<Image>();
            if (store != null && store.Students != null && !string.IsNullOrEmpty(studentID))
            {
                LocalStudentWork lsw = null;
                LocalStudent ls = store.Students[studentID];
                if (ls != null && ((lsw = ls.Work) != null) && (lsw.WorkFiles != null && lsw.WorkFiles.Count > 0))
                {
                    foreach (LocalStudentWorkFile wf in lsw.WorkFiles)
                    {
                        Image img = CreateThumbnail(store, ls, wf, w, h);
                        if (img != null)
                        {
                            list.Add(img);
                        }
                    }
                }
            }
            if (list.Count == 0) return new Image[] { LoadDefaultNULLImage(w, h) };
            return list.ToArray();
        }
        /// <summary>
        /// 创建缩略图。
        /// </summary>
        /// <param name="store"></param>
        /// <param name="ls"></param>
        /// <param name="wf"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Image CreateThumbnail(LocalStudentWorkStore store, LocalStudent ls, LocalStudentWorkFile wf, int w, int h)
        {
            if (store != null && ls != null && wf != null)
            {
                try
                {
                    string root = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\SFIT_TeaClient\\" + store.TeacherID + "_" + store.CatalogID;
                    if (!Directory.Exists(root)) Directory.CreateDirectory(root);
                    string path = Path.GetFullPath(string.Format("{0}\\{1}_{2}_{3}x{4}.jpg", root, ls.StudentID, wf.FileID, w, h));
                    if (File.Exists(path)) return Image.FromFile(path);
                    if (DefaultThumbnailFormat.IsExistThumbnailFormat(wf.FileExt))
                    {
                        string source = ls.Work.StudentWorkFilePath(store, ls, wf);
                        if (File.Exists(source))
                        {
                            Image img = ImageHelper.MakeThumbnail(Image.FromFile(source), w, h);
                            if (img != null)
                            {
                                img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                                return img;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    UtilTools.OnExceptionRecord(e, typeof(ThumbnailsHelpers));
                }
            }
            return null;
        }
        /// <summary>
        /// 创建学生作业缩略图集合。
        /// </summary>
        /// <param name="store"></param>
        /// <param name="localStudents"></param>
        /// <param name="container"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static ImageList ThumbnailImageList(LocalStudentWorkStore store, LocalStudents students, IContainer container, int w, int h)
        {
            if (store == null || students == null || students.Count == 0) return null;
            ImageList imgList = container == null ? new ImageList() : new ImageList(container);
            imgList.ImageSize = new Size(w, h);
            imgList.TransparentColor = Color.Transparent;
            foreach (LocalStudent ls in students)
            {
                Image img = CreateThumbnailFrist(store, ls.StudentID, w, h);
                if (img != null)
                {
                    imgList.Images.Add(ls.StudentID, img);
                }
            }
            return imgList;
        }
        #endregion

        //#region 对象绘制。
        
        
        
        //#endregion
    }
}