//================================================================================
//  FileName: FileMSG.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/5
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
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.Client.Net.MSG
{
    /// <summary>
    /// 文件传递消息。
    /// </summary>
    [Serializable]
    public class UploadFileMSG : FileMSG
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UploadFileMSG()
        {
            this.Kind = MSGKind.UploadFile;
            this.WorkType = EnumWorkType.Public;
            this.Student = new Student();
            this.Files = new StudentWorkFiles();
        }
        #endregion
        /// <summary>
        /// 获取或设置作品ID。
        /// </summary>
        public string WorkID { get; set; }
        /// <summary>
        /// 获取或设置作品名称
        /// </summary>
        public string WorkName { get; set; }
        /// <summary>
        /// 获取或设置作品类型。
        /// </summary>
        public EnumWorkType WorkType { get; set; }
        /// <summary>
        /// 作品描述。
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 获取或设置目录ID。
        /// </summary>
        public string CatalogID { get; set; }
        /// <summary>
        /// 获取或设置学生信息。
        /// </summary>
        public Student Student { get; set; }
        /// <summary>
        /// 获取或设置学生上传。
        /// </summary>
        public StudentWorkFiles Files { get; set; }
    }
}