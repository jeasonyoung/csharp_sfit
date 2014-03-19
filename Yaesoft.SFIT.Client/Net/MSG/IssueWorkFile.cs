//================================================================================
//  FileName: IssueWorkFile.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/12
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

namespace Yaesoft.SFIT.Client.Net.MSG
{
    /// <summary>
    /// 分发作品文件。
    /// </summary>
    [Serializable]
    public class IssueWorkFile : FileMSG
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public IssueWorkFile()
        {
            this.Kind = MSGKind.IssueWorkFile;
            this.Time = DateTime.Now;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置学生ID。
        /// </summary>
        public string StudentID { get; set; }
        /// <summary>
        /// 获取或设置作品名称。
        /// </summary>
        public string WorkName { get; set; }
        /// <summary>
        /// 获取或设置作品数据(.zip)。
        /// </summary>
        public byte[] Data { get; set; }
        #endregion
    }
}
