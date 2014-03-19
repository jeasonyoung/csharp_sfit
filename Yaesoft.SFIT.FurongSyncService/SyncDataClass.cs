//================================================================================
//  FileName: SyncDataClass.cs
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
    /// 同步班级。
    /// </summary>
    internal class SyncDataClass : SyncData
    {
        private UnitsEntity unitsEntity;
        private ClassesEntity classesEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conf"></param>
        /// <param name="log"></param>
        /// <param name="source"></param>
        public SyncDataClass(SyncJobConfigurations conf, WinServiceLog log, IDataSync source)
            : base(conf, log, source)
        {
            this.unitsEntity = new UnitsEntity(this.Config.ModuleDefaultDatabase, this.Log);
            this.classesEntity = new ClassesEntity(this.Config.ModuleDefaultDatabase, this.Log);
        }
        /// <summary>
        /// 
        /// </summary>
        public override string Name
        {
            get { return "同步班级数据"; }
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
                this.Log.ContentLog("没有须同步的班级所在的单位！");
            }
            Maps.Converts gradeValueConverts = this.Config.GradeValueConverts;
            if (gradeValueConverts == null || gradeValueConverts.Count == 0)
            {
                string err = "加载年级值转换配置时失败,同步失败!";
                this.Log.ContentLog(err);
                this.Log.ErrorLog(err);
                return;
            }
            for (int i = 0; i < units.Count; i++)
            {
                try
                {
                    SyncClasses sources = this.Source.SyncAllClasses(units[i].UnitName);
                    if (sources == null || sources.Count == 0)
                    {
                        this.Log.ContentLog(string.Format("[{0},{1}]下的没有同步的班级数据！", i + 1, units[i]));
                        continue;
                    }
                    Entity.Class data = null;
                    for (int j = 0; j < sources.Count; j++)
                    {
                        try
                        {
                            data = new Entity.Class();
                            data.ClassID = this.classesEntity.LoadClassIDByCode(sources[j].Code);
                            if (data.ClassID.IsValid && this.classesEntity.LoadRecord(ref data))
                            {
                                if (data.SyncStatus == 0x00)
                                {
                                    continue;
                                }
                            }
                            data.ClassCode = sources[j].Code;
                            data.ClassName = sources[j].Name;
                            data.UnitID = units[i].UnitID;
                            try
                            {
                                data.JoinYear = int.Parse(sources[j].JoinYear);
                            }
                            catch (Exception e)
                            {
                                string err = "班级[" + sources[j].ToString() + "]入学年级[" + sources[j].JoinYear + "]转换为int型时异常[" + e.Message + "],本条记录同步失败!";
                                this.Log.ContentLog(err);
                                this.Log.ErrorLog(new Exception(err, e));
                                continue;
                            }

                            string strGrade = gradeValueConverts[sources[j].Grade];
                            if (string.IsNullOrEmpty(strGrade))
                            {
                                string err = "班级[" + sources[j].ToString() + "]当前年级[" + sources[j].Grade + "]没有设置转化,将强制转换成0年级[毕业]!";
                                this.Log.ContentLog(err);
                                this.Log.ErrorLog(err);
                                //continue;
                                strGrade = "0";
                            }
                            try
                            {
                                data.GradeValue = int.Parse(strGrade);
                            }
                            catch (Exception e)
                            {
                                string err = "班级[" + sources[j].ToString() + "]当前年级[" + sources[j].Grade + "=>(" + strGrade + ")--转换为int型失败]异常[" + e.Message + "],本条记录同步失败!";
                                this.Log.ContentLog(err);
                                this.Log.ErrorLog(new Exception(err, e));
                                continue;
                            }

                            data.LearnLevel = (int)sources[j].LearnLevel;
                            data.LastSyncTime = DateTime.Now;
                            data.SyncStatus = 0x02;
                            data.OrderNO = this.SetOrderNo(data.ClassCode);

                            if (!data.ClassID.IsValid)
                            {
                                data.ClassID = GUIDEx.New;
                            }
                            string log = string.Format("同步第[{0},{1}]条数据[{2}]", i + 1, j + 1, data);
                            if (this.classesEntity.UpdateRecord(data))
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
                            string err = string.Format("同步[{0},{1}]班级数据[{2}]异常：{3}", i + 1, j + 1, data, ex.Message);
                            this.Log.ContentLog(err);
                            this.Log.ErrorLog(new Exception(err, ex));
                        }
                    }
                }
                catch (Exception e)
                {
                    string err = string.Format("同步[{0},{1}]下的班级时异常:{2}", i + 1, units[i], e.Message);
                    this.Log.ContentLog(err);
                    this.Log.ErrorLog(new Exception(err, e));
                }
            }
        }
    }
}