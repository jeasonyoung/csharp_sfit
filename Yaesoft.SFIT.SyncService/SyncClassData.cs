//================================================================================
//  FileName: SyncClassData.cs
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
using iPower;
using iPower.Data.ORM;
using iPower.WinService.Logs;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.SFIT.SyncService
{
    /// <summary>
    /// 同步班级数据。
    /// </summary>
    internal class SyncClassData : SyncDataBase
    {
        #region 成员变量，构造函数。
        SFITClassEntity classEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="dataPoxy"></param>
        /// <param name="syncName"></param>
        public SyncClassData(IDataSync dataPoxy, string syncName)
            : base(dataPoxy, syncName)
        {
            this.classEntity = new SFITClassEntity();
        }
        #endregion

        protected override void DataSync(StringBuilder logBuilder, StringBuilder insertBuilder, StringBuilder updateBuilder, StringBuilder hiddenBuilder, int insertCount, int updateCount, int hiddenCount)
        {
            this.classEntity.DbEntityDataChangeLogEvent += new DbEntityDataChangeLogHandler(delegate(string head, string content)
            {
                this.AppendLog(logBuilder, string.Format("head:{0},content:{1}", head, content));
            });
            List<SFITSchools> schools = new SFITSchoolsEntity().LoadAllowSyncData();
            IDataSync dataSync = this.DataPoxy;
            if (schools != null && schools.Count > 0 && dataSync != null)
            {
                Maps.Converts gradeValueConverts = ModuleConfiguration.ModuleConfig.GradeValueConverts;
                if (gradeValueConverts == null || gradeValueConverts.Count == 0)
                {
                    this.AppendLog(logBuilder, "加载年级值转换配置时失败,同步失败!");
                    return;
                }
                foreach (SFITSchools sch in schools)
                {
                    SyncClasses classes = dataSync.SyncAllClasses(sch.SchoolName);
                    if (classes != null && classes.Count > 0)
                    {
                        foreach (SyncClass c in classes)
                        {
                            SFITClass data = new SFITClass();
                            data.ClassID = this.classEntity.GetClassIDByCode(c.Code);
                            if (data.ClassID.IsValid && this.classEntity.LoadRecord(ref data))
                            {
                                if (data.SyncStatus == 0x00)
                                {
                                    continue;
                                }
                            }

                            data.ClassCode = c.Code;
                            data.ClassName = c.Name;
                            data.SchoolID = sch.SchoolID;
                            data.LastSyncTime = DateTime.Now;
                            data.SyncStatus = 0x02;

                            try
                            {
                                data.JoinYear = int.Parse(c.JoinYear);
                            }
                            catch (Exception e)
                            {
                                this.AppendLog(logBuilder, "班级[" + c.ToString() + "]入学年级[" + c.JoinYear + "]转换为int型时异常[" + e.Message + "],本条记录同步失败!");
                                continue;
                            }

                            string strGrade = gradeValueConverts[c.Grade];
                            if (string.IsNullOrEmpty(strGrade))
                            {
                                this.AppendLog(logBuilder, "班级[" + c.ToString() + "]当前年级[" + c.Grade + "]没有设置转化,本条记录同步失败!");
                                continue;
                            }

                            try
                            {
                                data.GradeValue = int.Parse(strGrade);
                            }
                            catch (Exception e)
                            {
                                this.AppendLog(logBuilder, "班级[" + c.ToString() + "]当前年级[" + c.Grade + "=>("+strGrade+")--转换为int型失败]异常["+e.Message+"],本条记录同步失败!");
                                continue;
                            }

                            data.LearnLevel = (int)c.LearnLevel;
                            data.OrderNO = this.SetOrderNo(data.ClassCode);
                            
                            if (!data.ClassID.IsValid)
                            {
                                data.ClassID = GUIDEx.New;
                                this.AppendLog(insertBuilder, string.Format("(班级ID：{0})[代码：{1}][名称：{2}][入学年份：{3}][学习阶段：{4}]；", data.ClassID, data.ClassCode, data.ClassName, data.JoinYear, data.LearnLevel));
                                insertCount++;
                            }
                            else
                            {
                                this.AppendLog(updateBuilder, string.Format("(班级ID：{0})[代码：{1}][名称：{2}][入学年份：{3}][学习阶段：{4}]；", data.ClassID, data.ClassCode, data.ClassName, data.JoinYear, data.LearnLevel));
                                updateCount++;
                            }
                            this.classEntity.UpdateRecord(data);
                        }
                    }
                }
            }
        }
    }
}