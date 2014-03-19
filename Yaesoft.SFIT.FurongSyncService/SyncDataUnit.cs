//================================================================================
//  FileName: SyncDataUnit.cs
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
using iPower;
using iPower.Utility;
using iPower.WinService.Logs;
using Yaesoft.SFIT.DataSync;
using Yaesoft.SFIT.FurongSyncService.Entity;
namespace Yaesoft.SFIT.FurongSyncService
{
    /// <summary>
    /// 
    /// </summary>
    internal class SyncDataUnit :SyncData
    {
        private UnitsEntity unitEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conf"></param>
        /// <param name="log"></param>
        /// <param name="source"></param>
        public SyncDataUnit(SyncJobConfigurations conf, WinServiceLog log, IDataSync source)
            : base(conf, log, source)
        {
            this.unitEntity = new UnitsEntity(conf.ModuleDefaultDatabase, log);
        }
        /// <summary>
        /// 
        /// </summary>
        public override string Name
        {
            get { return "同步单位数据"; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Sync()
        {
            try
            {
                SyncUnits sources = this.Source.SyncAllUnit();
                if (sources == null || sources.Count == 0)
                {
                    this.Log.ContentLog("没有单位数据同步！");
                }

                Maps.Converts schoolTypeConverts = this.Config.UnitTypeConverts;
                if (schoolTypeConverts == null || schoolTypeConverts.Count == 0)
                {
                    string err = "加载学校单位类型转换配置时失败,同步失败!";
                    this.Log.ContentLog(err);
                    this.Log.ErrorLog(err);
                    return;
                }

                Unit data = null;
                for (int i = 0; i < sources.Count; i++)
                {
                    try
                    {
                        data = new Unit();
                        data.UnitID = this.unitEntity.LoadUnitID(sources[i].UnitCode);
                        if (data.UnitID.IsValid && this.unitEntity.LoadRecord(ref data))
                        {
                            if (data.SyncStatus == 0x00)
                            {
                                continue;
                            }
                        }
                        data.UnitCode = sources[i].UnitCode;
                        data.UnitName = sources[i].UnitName;

                        string strType = schoolTypeConverts[sources[i].UnitType];
                        if (string.IsNullOrEmpty(strType))
                        {
                            string err = "学校[" + sources[i].ToString() + "]类型[" + sources[i].UnitType + "]没有设置转化,本条记录同步失败!";
                            this.Log.ContentLog(err);
                            this.Log.ErrorLog(err);
                            continue;
                        }

                        try
                        {
                            data.SchoolType = int.Parse(strType);
                        }
                        catch (Exception e)
                        {
                            string err = "学校[" + sources[i].ToString() + "]类型[" + sources[i].UnitType + "=>(" + strType + ")--转换为int型失败]异常[" + e.Message + "],本条记录同步失败!";
                            this.Log.ContentLog(err);
                            this.Log.ErrorLog(new Exception(err, e));
                            continue;
                        }

                        data.SyncStatus = 0x02;
                        data.LastSyncTime = DateTime.Now;
                        data.OrderNO = this.SetOrderNo(data.UnitCode);

                        if (!data.UnitID.IsValid)
                        {
                            data.UnitID = GUIDEx.New;
                        }

                        string log = string.Format("同步第{0}条数据[{1}]", i+1, data);
                        if (this.unitEntity.UpdateRecord(data))
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
                        string err = string.Format("同步第{0}条数据[{1}]时发生异常：{2}", i + 1, data, ex.Message);
                        this.Log.ContentLog(err);
                        this.Log.ErrorLog(new Exception(err, ex));
                    }
                }
            }
            catch (Exception e)
            {
                this.Log.ContentLog(e.Message);
                this.Log.ErrorLog(e);
            }
        }
    }
}