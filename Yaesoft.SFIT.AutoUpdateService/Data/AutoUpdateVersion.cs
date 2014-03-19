//================================================================================
//  FileName: AutoUpdateVersion.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-31
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

namespace Yaesoft.SFIT.AutoUpdateService.Data
{
    /// <summary>
    /// 更新版本。
    /// </summary>
    [Serializable]
    public class AutoUpdateVersion
    {
        /// <summary>
        /// 获取或设置更新版本。
        /// </summary>
        public int Ver { get; set; }
        /// <summary>
        /// 获取或设置更新ID。
        /// </summary>
        public string UpdateID { get; set; }
        /// <summary>
        /// 获取或设置更新包路径。
        /// </summary>
        public string PackPath { get; set; }
        /// <summary>
        /// 获取或设置描述信息。
        /// </summary>
        public string Description { get; set; }
    }
}
