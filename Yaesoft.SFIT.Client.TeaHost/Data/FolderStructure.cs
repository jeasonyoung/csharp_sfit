//================================================================================
//  FileName: FolderStructure.cs
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
using System.IO;
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 教师机目录结构。
    /// </summary>
    internal static class FolderStructure
    {
        #region 成员变量，构造函数。
        static string appDataRoot;
        /// <summary>
        /// 构造函数。
        /// </summary>
        static FolderStructure()
        {
            appDataRoot = Path.GetFullPath(string.Format("{0}/HostData", AppDomain.CurrentDomain.BaseDirectory));
            if (!Directory.Exists(appDataRoot))
                Directory.CreateDirectory(appDataRoot);
        }
        #endregion

        /// <summary>
        /// 获取认证文件。
        /// </summary>
        public static string CredentialsFile
        {
            get { return Path.GetFullPath(string.Format("{0}/Credentials.bin", appDataRoot)); }
        }
        /// <summary>
        /// 获取用户认证文件。
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string UserCertificationFile
        {
            get { return Path.GetFullPath(string.Format("{0}/Certification.bin", appDataRoot)); }
        }
        /// <summary>
        /// 获取监视界面颜色设置文件。
        /// </summary>
        public static string MonitorUIColorSettingsFile
        {
            get { return Path.GetFullPath(string.Format("{0}/MonitorUIColorSettings.xml", appDataRoot)); }
        }
        /// <summary>
        /// 获取网络端口设置。
        /// </summary>
        public static string NetPortSettingsFile
        {
            get { return Path.GetFullPath(string.Format("{0}/PortSettings.cfg.xml", appDataRoot)); }
        }
        /// <summary>
        /// 获取教师数据根目录。
        /// </summary>
        /// <param name="teaId">教师ID。</param>
        /// <returns></returns>
        public static string GetUserDataRoot(string teaId)
        {
            if (string.IsNullOrEmpty(teaId))
                throw new ArgumentNullException("teacherID", "教师ID为空！");
            string root = Path.GetFullPath(string.Format("{0}/{1}", appDataRoot, teaId));
            if (!string.IsNullOrEmpty(root) && !Directory.Exists(root))
                Directory.CreateDirectory(root);
            return root;
        }
        /// <summary>
        /// 获取教师同步数据文件。
        /// </summary>
        /// <param name="teaId"></param>
        /// <returns></returns>
        public static string UserSyncDataFile(string teaId)
        {
            string root = GetUserDataRoot(teaId);
            return Path.GetFullPath(string.Format("{0}/UserSyncData_{1}.xml", root, teaId));
        }
        /// <summary>
        /// 获取用户学生作品记录文件。
        /// </summary>
        /// <param name="teaId"></param>
        /// <returns></returns>
        public static string TeaStudentWorksFile(string teaId)
        {
            string root = GetUserDataRoot(teaId);
            return Path.GetFullPath(string.Format("{0}/TeaStudentWorks_{1}.xml", root, teaId));
        }
    }
}
