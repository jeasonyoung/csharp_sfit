//================================================================================
//  FileName: SyncClearData.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-12-13
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
    /// 清理数据。
    /// </summary>
    internal class SyncClearData : SyncDataBase
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity = null;
        SFITClassEntity classEntity = null;
        SFITStudentsEntity studentsEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="dataPoxy"></param>
        /// <param name="syncName"></param>
        public SyncClearData(IDataSync dataPoxy, string syncName)
            : base(dataPoxy, syncName)
        {
            this.schoolsEntity = new SFITSchoolsEntity();
            this.classEntity = new SFITClassEntity();
            this.studentsEntity = new SFITStudentsEntity();
        }
        #endregion

        protected override void DataSync(StringBuilder logBuilder, StringBuilder insertBuilder, StringBuilder updateBuilder, StringBuilder hiddenBuilder, int insertCount, int updateCount, int hiddenCount)
        {
            List<SFITSchools> list = this.schoolsEntity.LoadNotAllowSyncData();
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    List<SFITClass> classes = this.classEntity.LoadAllData(list[i].SchoolID);
                    if (classes != null && classes.Count > 0)
                    {
                        for (int j = 0; j < classes.Count; j++)
                        {
                            //设置班级的隐藏。
                            classes[j].SyncStatus = 0x00;
                            if (this.classEntity.UpdateRecord(classes[j]))
                            {
                                this.AppendLog(hiddenBuilder, string.Format(string.Format("(班级ID：{0})[代码：{1}][名称：{2}][入学年份：{3}][学习阶段：{4}],由于；",
                                    classes[j].ClassID, classes[j].ClassCode, classes[j].ClassName, classes[j].JoinYear, classes[j].LearnLevel)));
                                hiddenCount++;
                                //设置班级下所有学生的隐藏。
                                this.studentsEntity.StopSync(classes[j].ClassID, null, ref hiddenBuilder, ref hiddenCount);
                            }
                        }
                    }
                }
            }
        }
    }
}
