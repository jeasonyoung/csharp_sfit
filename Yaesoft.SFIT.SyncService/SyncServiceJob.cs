//================================================================================
//  FileName: SyncServiceJob.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-01-05 
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

using iPower.WinService;
using iPower.WinService.Jobs;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.SFIT.SyncService
{
    /// <summary>
    /// 同步Windows服务。
    /// </summary>
    public class SyncServiceJob : Job<ModuleConfiguration>,IJobFunction
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public SyncServiceJob()
        {
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        protected override ModuleConfiguration JobConfig
        {
            get { return ModuleConfiguration.ModuleConfig; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override IJobFunction JobFunction
        {
            get { return this; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override string JobName
        {
            get { return "学生信息技术档案系统数据同步服务"; }
        }

        #region IJobFunction 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void Run(params string[] args)
        {
            IDataSync dataSyncPoxy = this.JobConfig.DataSyncPoxyFactory;
            if (dataSyncPoxy != null)
            {
                SyncDataBase[] syncArray = new SyncDataBase[] 
                {
                    new SyncUnitData(dataSyncPoxy,"学校单位"),
                    new SyncTeaData(dataSyncPoxy,"教师"),
                    new SyncClassData(dataSyncPoxy,"班级"),
                    new SyncStudentsData(dataSyncPoxy,"学生"),
                    new SyncClearData(dataSyncPoxy,"清理")
                };
                int len = 0;
                if (syncArray != null && (len = syncArray.Length) > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        try
                        {
                            syncArray[i].Sync(this.JobLog);
                        }
                        catch (Exception e)
                        {
                            this.JobLog.ErrorLog(string.Format("{0}:{1},{2}", syncArray[i].SyncName, e.Message, e.TargetSite));
                        }
                    }
                }
            }
            else
            {
                this.ServiceLog.ErrorLog("未能获取数据同步接口代理程序集的对象。");
            }
        }

        #endregion
    }
}