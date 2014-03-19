//================================================================================
//  FileName: IPluginHost.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/31
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
using System.Windows.Forms;
namespace Yaesoft.SFIT.Client.Forms
{
    /// <summary>
    /// 插件宿主接口。
    /// </summary>
    public interface IPluginHost
    {
        /// <summary>
        /// 添加插件。
        /// </summary>
        /// <param name="position">位置。</param>
        /// <param name="plug">插件界面接口。</param>
        void AddPlugin(DockStyle position, IWindow plug);
    }
}
