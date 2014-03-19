//================================================================================
//  FileName: Category.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-10-8
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
using System.Diagnostics;
namespace Yaesoft.SFIT.Client.AutoUpdate.Logging
{
    /// <summary>
    /// 定义日志类别.
    /// </summary>
    public class Category
    {
        #region 成员变量,构造函数.
        private TraceSource source;
        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="name"></param>
        public Category(string name)
        {
            this.source = new TraceSource(name);
        }
        #endregion

        #region 属性.
        /// <summary>
        /// 
        /// </summary>
        public TraceSource Source
        {
            get { return this.source; }
        }
        /// <summary>
        /// 获取日志类别名称.
        /// </summary>
        public string Name
        {
            get { return this.source.Name; }
        }
        #endregion
    }
}