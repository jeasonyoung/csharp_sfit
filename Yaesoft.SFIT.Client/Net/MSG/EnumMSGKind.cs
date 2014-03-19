//================================================================================
//  FileName: EnumMSGKind.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/4
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
    /// 消息类型枚举。
    /// </summary>
    [Serializable]
    public enum MSGKind
    {
        /// <summary>
        /// 无类型。
        /// </summary>
        None = 0x00,
        /// <summary>
        /// 广播。
        /// </summary>
        Broadcast,
        /// <summary>
        /// 应答消息。
        /// </summary>
        Answer,

        #region 登录。
        /// <summary>
        /// 请求登录。
        /// </summary>
        ReqLogin,
        /// <summary>
        /// 请求登录返回。
        /// </summary>
        RespLogin,
        /// <summary>
        /// 开始登录。
        /// </summary>
        Logining,
        /// <summary>
        /// 登录结果。
        /// </summary>
        Logined,
        #endregion

        #region 文件上传。
        /// <summary>
        ///上传文件。
        /// </summary>
        UploadFile,
        /// <summary>
        /// 分发作品文件。
        /// </summary>
        IssueWorkFile,
        #endregion

        /// <summary>
        ///  学生下线。
        /// </summary>
        ClientClose,
        /// <summary>
        /// 主机关闭。
        /// </summary>
        HostClose
    }
}
