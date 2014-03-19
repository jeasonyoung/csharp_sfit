//================================================================================
//  FileName: SyncDataBase.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/9
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
namespace Yaesoft.SFIT.SyncService
{
    /// <summary>
    /// 同步数据基类
    /// </summary>
    internal abstract class SyncDataBase
    {
        #region 成员变量，构造函数。
        StringBuilder logBuilder, insertBuilder, updateBuilder, hiddenBuilder;
        int insertCount = 0, updateCount = 0, hiddenCount = 0;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="dataPoxy"></param>
        public SyncDataBase(IDataSync dataPoxy, string syncName)
        {
            this.DataPoxy = dataPoxy;
            this.SyncName = syncName;
        }
        #endregion

        #region 属性。        
        /// <summary>
        /// 获取同步名称。
        /// </summary>
        public string SyncName
        {
            get;
            private set;
        }
        /// <summary>
        /// 获取配置信息。
        /// </summary>
        protected IDataSync DataPoxy
        {
            get;
            private set;
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 同步数据。
        /// </summary>
        /// <param name="log">服务日志对象。</param>
        public void Sync(WinServiceLog log)
        {
            try
            {
                if (this.DataPoxy == null)
                {
                    return;
                }

                this.logBuilder = new StringBuilder(this.SyncName);
                this.insertBuilder = new StringBuilder("新增" + this.SyncName + "数据：");
                this.updateBuilder = new StringBuilder("更新" + this.SyncName + "数据：");
                this.hiddenBuilder = new StringBuilder("隐藏" + this.SyncName + "数据：");
                this.insertCount = this.updateCount = this.hiddenCount = 0;
                                 
                this.DataSync(this.logBuilder, this.insertBuilder, this.updateBuilder, this.hiddenBuilder,
                    this.insertCount, this.updateCount, this.hiddenCount);
            }
            catch (Exception e)
            {
                this.AppendLog(this.logBuilder, string.Format("发生异常：{0}\r\n{1}\r\n{2}", e.Message, e.Source, e.StackTrace));
                throw e;
            }
            finally
            {
                this.AppendLog(this.logBuilder, null);
                StringBuilder sb = new StringBuilder();
                if (insertCount > 0)
                {
                    this.AppendLog(this.logBuilder, this.insertBuilder.ToString());
                    sb.AppendFormat("共新增：{0}；", insertCount);
                }
                if (updateCount > 0)
                {
                    this.AppendLog(this.logBuilder, this.updateBuilder.ToString());
                    sb.AppendFormat("共更新：{0}；", updateCount);
                }
                if (hiddenCount > 0)
                {
                    this.AppendLog(this.logBuilder, this.hiddenBuilder.ToString());
                    sb.AppendFormat("共隐藏：{0}；", hiddenCount);
                }
                if (sb.Length > 0)
                {
                    this.AppendLog(this.logBuilder, sb.ToString());
                }
                if (log != null)
                {
                    log.ContentLog(this.logBuilder.ToString());
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logBuilder"></param>
        /// <param name="insertBuilder"></param>
        /// <param name="updateBuilder"></param>
        /// <param name="hiddenBuilder"></param>
        /// <param name="insertCount"></param>
        /// <param name="updateCount"></param>
        /// <param name="hiddenCount"></param>
        protected abstract void DataSync(StringBuilder logBuilder, StringBuilder insertBuilder, StringBuilder updateBuilder, StringBuilder hiddenBuilder, int insertCount, int updateCount, int hiddenCount);
        /// <summary>
        /// 追加日志。
        /// </summary>
        /// <param name="builder">日志容器。</param>
        /// <param name="content">日志内容。</param>
        protected void AppendLog(StringBuilder builder, string content)
        {
            if (builder != null)
            {
                builder.AppendLine();
                if (!string.IsNullOrEmpty(content))
                {
                    builder.Append(content);
                }
            }
        }
        static Regex STATIC_REGEX = new Regex(@"(?<Code>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
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
                        string str = m.Groups["Code"].Value;
                        if (!string.IsNullOrEmpty(str) && str.Length >= 2)
                        {
                            string sub = str.Substring(str.Length - 2);
                            return int.Parse(sub);
                        }
                    }
                }
                catch (Exception) { }
            }
            return 0;
        }
        #endregion
    }
}