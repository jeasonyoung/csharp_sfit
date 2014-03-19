//================================================================================
//  FileName: LastUpdateConf.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-30
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
using System.Windows.Forms;

using Yaesoft.SFIT.Client.AutoUpdate.Utils;
namespace Yaesoft.SFIT.Client.AutoUpdate.Data
{
    /// <summary>
    /// 本地更新。
    /// </summary>
    [Serializable]
    public class LocalUpdateRecord
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public LocalUpdateRecord()
        {
            this.Ver = 0;
            this.Time = DateTime.Now;
        }
        #endregion

        /// <summary>
        /// 获取或设置更新版本号。
        /// </summary>
        public int Ver { get; set; }
        /// <summary>
        /// 获取或设置更新时间。
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 获取或设置服务器地址。
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 获取或设置校验码。
        /// </summary>
        public string Checksum { get; set; }

        #region 函数。
        /// <summary>
        /// 生成校验码。
        /// </summary>
        public string CreateChecksum()
        {
            string source = string.Format("{0}|{1:yyyyMMddHHmmss}#{2}", this.Ver, this.Time, this.URL);
            if (!string.IsNullOrEmpty(source))
            {
                byte[] data = Encoding.ASCII.GetBytes(source);
                return UtilTools.Checksum(data);
            }
            return null;
        }
        /// <summary>
        /// 验证校验码。
        /// </summary>
        /// <returns></returns>
        public bool VerifyChecksum()
        {
            if (!string.IsNullOrEmpty(this.Checksum))
            {
                return (this.Checksum == this.CreateChecksum());
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static string SaveFilePath()
        {
            return Path.GetFullPath(string.Format("{0}/{1}.xml", Application.StartupPath, typeof(LocalUpdateRecord).Name));
        }
        /// <summary>
        /// 序列化。
        /// </summary>
        public void Serializer()
        {
            try
            {
                UtilTools.Serializer<LocalUpdateRecord>(this, LocalUpdateRecord.SaveFilePath());
            }
            catch (Exception x)
            {
                MessageBox.Show("本地更新记录文件序列化异常："+ x.Message);
            }
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <returns></returns>
        public static LocalUpdateRecord DeSerializer()
        {
            try
            {
                return UtilTools.DeSerializer<LocalUpdateRecord>(LocalUpdateRecord.SaveFilePath());
            }
            catch (Exception x)
            {
                MessageBox.Show("本地更新记录文件反序列化异常：" + x.Message);
            }
            return null;
        }
        #endregion
    }
}
