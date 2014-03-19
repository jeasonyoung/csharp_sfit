//================================================================================
//  FileName: IHotkeys.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/14
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

namespace Yaesoft.SFIT.Client.Forms
{
    /// <summary>
    /// 热键处理接口。
    /// </summary>
    public interface IHotkeys
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotKey"></param>
        void ProcessHotkey(string hotKey);
    }
}
