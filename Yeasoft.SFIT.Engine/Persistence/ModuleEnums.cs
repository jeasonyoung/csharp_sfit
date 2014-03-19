//================================================================================
//  FileName: ModuleEnums.cs
//  Desc:枚举类文件。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/5
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

namespace Yaesoft.SFIT.Engine.Persistence
{
    /// <summary>
    /// 显示类型枚举。
    /// </summary>
    public enum EnumDisplayType
    {
        /// <summary>
        /// 不显示。
        /// </summary>
        None = 0x00,
        /// <summary>
        /// 显示。
        /// </summary>
        Display = 0x01
    }
    /// <summary>
    /// 访问状态枚举。
    /// </summary>
    public enum EnumAccessStatus
    {
        /// <summary>
        /// 禁止。
        /// </summary>
        Non = 0x00,
        /// <summary>
        /// 允许。
        /// </summary>
        Allow = 0x01
    }
    /// <summary>
    /// 目录类型枚举。
    /// </summary>
    public enum EnumCatalogType
    {
        /// <summary>
        /// 必修。
        /// </summary>
        Required = 0x00,
        /// <summary>
        /// 自增。
        /// </summary>
        Custom = 0x01
    }
    /// <summary>
    /// 同步状态枚举。
    /// </summary>
    public enum EnumSyncStatus
    {
        /// <summary>
        /// 停止同步。
        /// </summary>
        None = 0x00,
        /// <summary>
        /// 允许同步。
        /// </summary>
        Sync = 0x01,
        /// <summary>
        /// 已同步。
        /// </summary>
        Complete = 0x02 
    }
    /// <summary>
    /// 评论状态枚举。
    /// </summary>
    public enum EnumCommentStatus
    {
        /// <summary>
        /// 展示。
        /// </summary>
        Show = 0x00,
        /// <summary>
        /// 隐藏。
        /// </summary>
        Hide = 0x01
    }
}
