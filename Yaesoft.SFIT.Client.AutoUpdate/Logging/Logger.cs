//================================================================================
//  FileName: Logger.cs
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
    /// 日志.
    /// </summary>
    public class Logger
    {
        #region 成员变量,构造函数.
        private const int EVENT_ID = 0xCA5;
        private Category category;
        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="category"></param>
        public Logger(Category category)
        {
            this.category = category;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        public void Debug(string message, params object[] parameters)
        {
            this.Trace(TraceEventType.Verbose, message, parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        public void Info(string message, params object[] parameters)
        {
            this.Trace(TraceEventType.Information, message, parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        public void Warn(string message, params object[] parameters)
        {
            this.Trace(TraceEventType.Warning, message, parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        public void Error(string message, params object[] parameters)
        {
            this.Trace(TraceEventType.Error, message, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        private void Trace(TraceEventType type, string message, params object[] parameters)
        {
            if (this.category.Source.Switch.ShouldTrace(type))
            {
                this.category.Source.TraceEvent(type, EVENT_ID, message, parameters);
            }
        }
    }
}