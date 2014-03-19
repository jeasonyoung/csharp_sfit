//================================================================================
//  FileName: SyncData.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-4-18
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
using System.Text.RegularExpressions;
using iPower.WinService.Logs;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.SFIT.FurongSyncService
{
    /// <summary>
    /// 同步数据抽象类。
    /// </summary>
    internal abstract class SyncData
    {
        #region 成员变量，构造函数。
        private static Regex STATIC_REGEX = new Regex(@"(?<Code>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conf"></param>
        /// <param name="log"></param>
        /// <param name="source"></param>
        public SyncData(SyncJobConfigurations conf,WinServiceLog log, IDataSync source)
        {
            this.Config = conf;
            this.Log = log;
            this.Source = source;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        protected SyncJobConfigurations Config { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        protected WinServiceLog Log { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        protected IDataSync Source { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public abstract void Sync();
        /// <summary>
        /// 设置排序。
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        protected int SetOrderNo(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                try
                {
                    Match m = STATIC_REGEX.Match(code);
                    if (m.Success)
                    {
                        string order = m.Groups["Code"].Value;
                        if (!string.IsNullOrEmpty(order) && order.Length >= 2)
                        {
                            order = order.Substring(order.Length - 2);
                        }
                        return int.Parse(order);
                    }
                }
                catch (Exception) { }
            }
            return 0;
        }
    }
}
