//================================================================================
//  FileName: DataContainer.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Yaesoft.SFIT.Client
{
    /// <summary>
    /// 数据容器用于宿主与插件之间传递数据。
    /// </summary>
    public class DataContainer : Container<object>
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DataContainer()
        {

        }
        #endregion
    }
}
