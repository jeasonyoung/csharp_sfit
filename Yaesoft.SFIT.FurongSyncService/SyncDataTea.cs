//================================================================================
//  FileName: SyncDataTea.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-4-19
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
using iPower;
using iPower.Utility;
using iPower.WinService.Logs;
using Yaesoft.SFIT.DataSync;
using Yaesoft.SFIT.FurongSyncService.Entity;
namespace Yaesoft.SFIT.FurongSyncService
{
    /// <summary>
    /// 同步教师数据。
    /// </summary>
    internal class SyncDataTea : SyncData
    {
        private UnitsEntity unitsEntity;
        private TeachersEntity teasEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conf"></param>
        /// <param name="log"></param>
        /// <param name="source"></param>
        public SyncDataTea(SyncJobConfigurations conf, WinServiceLog log, IDataSync source)
            : base(conf, log, source)
        {
            this.unitsEntity = new UnitsEntity(this.Config.ModuleDefaultDatabase, log);
            this.teasEntity = new TeachersEntity(this.Config.ModuleDefaultDatabase, log);
        }
        /// <summary>
        /// 
        /// </summary>
        public override string Name
        {
            get { return "同步教师数据"; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Sync()
        {
            if (this.Source == null) return;
            List<Unit> units = this.unitsEntity.LoadAllowSyncData();
            if (units == null || units.Count == 0)
            {
                this.Log.ContentLog("没有须同步的教师所在的单位！");
            }
            for (int i = 0; i < units.Count; i++)
            {
                try
                {
                    SyncTeachers sources = this.Source.SyncAllTeachers(units[i].UnitName);
                    if (sources == null || sources.Count == 0)
                    {
                        this.Log.ContentLog(string.Format("[{0},{1}]下的没有同步的教师数据！", i + 1, units[i]));
                        continue;
                    }
                    Entity.Teacher data = null;
                    for (int j = 0; j < sources.Count; j++)
                    {
                        try
                        {
                            data = new Entity.Teacher();
                            data.TeaID = this.teasEntity.LoadTeaID(sources[j].TeaCode);
                            if (data.TeaID.IsValid && this.teasEntity.LoadRecord(ref data))
                            {
                                if (data.SyncStatus == 0x00)
                                {
                                    continue;
                                }
                            }
                            data.TeaCode = sources[j].TeaCode;
                            data.TeaName = sources[j].TeaName;
                            data.UnitID = units[i].UnitID;
                            data.SyncStatus = 0x02;
                            data.LastSyncTime = DateTime.Now;

                            if (!data.TeaID.IsValid)
                            {
                                data.TeaID = GUIDEx.New;
                            }
                            string log = string.Format("同步第[{0},{1}]条数据[{2}]", i + 1, j + 1, data);
                            if (this.teasEntity.UpdateRecord(data))
                            {
                                this.Log.ContentLog(log + "[成功]");
                            }
                            else
                            {
                                this.Log.ContentLog(log + "[失败]");
                            }
                        }
                        catch (Exception ex)
                        {
                            string err = string.Format("同步[{0},{1}]教师数据[{2}]异常：{3}", i + 1, j + 1, data, ex.Message);
                            this.Log.ContentLog(err);
                            this.Log.ErrorLog(new Exception(err, ex));
                        }
                    }
                }
                catch (Exception e)
                {
                    string err = string.Format("同步[{0},{1}]下的教师时异常:{2}", i + 1, units[i], e.Message);
                    this.Log.ContentLog(err);
                    this.Log.ErrorLog(new Exception(err, e));
                }
            }
        }
    }
}