//================================================================================
//  FileName: Job.cs
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
using iPower.WinService.Jobs;

using Yaesoft.SFIT.DataSync;
namespace Yaesoft.SFIT.FurongSyncService
{
    /// <summary>
    /// 
    /// </summary>
    public class SyncJob :Job<SyncJobConfigurations>,IJobFunction
    {
        /// <summary>
        /// 
        /// </summary>
        public override string JobName
        {
            get { return "同步城域网数据"; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override SyncJobConfigurations JobConfig
        {
            get { return new SyncJobConfigurations(); }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override IJobFunction JobFunction
        {
            get { return this; }
        }

        #region IJobFunction 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void Run(params string[] args)
        {
            IDataSync source = this.JobConfig.DataSyncPoxyFactory;
            if (source == null)
            {
                this.JobLog.ErrorLog("未能获取数据同步接口代理程序集的对象。");
            }
            else
            {
                SyncData[] array = new SyncData[]{
                    new SyncDataUnit(this.JobConfig, this.JobLog, source),//同步单位。
                    new SyncDataTea(this.JobConfig, this.JobLog, source),//同步教师。
                    new SyncDataClass(this.JobConfig, this.JobLog, source),//同步班级。
                    new SyncDataStu(this.JobConfig, this.JobLog, source)//同步学生。
                };
                foreach (SyncData sd in array)
                {
                    try
                    {
                        sd.Sync();
                    }
                    catch (Exception e)
                    {
                        this.JobLog.ErrorLog(new Exception(sd.Name, e));
                    }
                }
            }
        }

        #endregion
    }
}
