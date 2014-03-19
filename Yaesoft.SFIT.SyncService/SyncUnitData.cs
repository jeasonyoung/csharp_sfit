//================================================================================
//  FileName: SyncUnitData.cs
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

using iPower;
using iPower.Data.ORM;
using iPower.WinService.Logs;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.SFIT.SyncService
{
    /// <summary>
    /// 同步单位数据。
    /// </summary>
    internal class SyncUnitData : SyncDataBase
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity entity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="dataPoxy"></param>
        /// <param name="syncName"></param>
        public SyncUnitData(IDataSync dataPoxy, string syncName)
            : base(dataPoxy, syncName)
        {
            this.entity = new SFITSchoolsEntity();
        }
        #endregion

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
        protected override void DataSync(StringBuilder logBuilder, StringBuilder insertBuilder, StringBuilder updateBuilder, StringBuilder hiddenBuilder, int insertCount, int updateCount, int hiddenCount)
        {
            this.entity.DbEntityDataChangeLogEvent += new DbEntityDataChangeLogHandler(delegate(string head, string content)
            {
                this.AppendLog(logBuilder, string.Format("head:{0},content:{1}", head, content));
            });
            SyncUnits syncUnits = this.DataPoxy.SyncAllUnit();
            if (syncUnits != null && syncUnits.Count > 0)
            {
                Maps.Converts schoolTypeConverts = ModuleConfiguration.ModuleConfig.SchoolTypeConverts;
                if (schoolTypeConverts == null || schoolTypeConverts.Count == 0)
                {
                    this.AppendLog(logBuilder, "加载学校单位类型转换配置时失败,同步失败!");
                    return;
                }
                foreach (SyncUnit su in syncUnits)
                {
                    SFITSchools data = new SFITSchools();
                    data.SchoolID = this.entity.GetSchoolID(su.UnitCode);
                    if (data.SchoolID.IsValid && this.entity.LoadRecord(ref data))
                    {
                        if (data.SyncStatus == 0x00)
                        {
                            continue;
                        }
                    }
                    data.SchoolCode = su.UnitCode;
                    data.SchoolName = su.UnitName;

                    string strType = schoolTypeConverts[su.UnitType];
                    if (string.IsNullOrEmpty(strType))
                    {
                        this.AppendLog(logBuilder, "学校[" + su.ToString() + "]类型[" + su.UnitType + "]没有设置转化,本条记录同步失败!");
                        continue;
                    }

                    try
                    {
                        data.SchoolType = int.Parse(strType);
                    }
                    catch (Exception e)
                    {
                        this.AppendLog(logBuilder, "学校[" + su.ToString() + "]类型[" + su.UnitType + "=>(" + strType + ")--转换为int型失败]异常[" + e.Message + "],本条记录同步失败!");
                        continue;
                    }

                    data.SyncStatus = 0x02;
                    data.LastSyncTime = DateTime.Now;
                    data.OrderNO = this.SetOrderNo(data.SchoolCode);
                     
                    if (!data.SchoolID.IsValid)
                    {
                        data.SchoolID = GUIDEx.New;
                        this.AppendLog(insertBuilder, string.Format("(学校ID：{0})[代码：{1}][名称：{2}][类型：{3}]；", data.SchoolID, data.SchoolCode, data.SchoolName, data.SchoolType));
                        insertCount++;
                    }
                    else
                    {
                        this.AppendLog(updateBuilder, string.Format("(学校ID：{0})[代码：{1}][名称：{2}][类型：{3}]；", data.SchoolID, data.SchoolCode, data.SchoolName, data.SchoolType));
                        updateCount++;
                    }
                    this.entity.UpdateRecord(data);
                }
            }
        }
    }
}