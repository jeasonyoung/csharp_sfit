//================================================================================
//  FileName: SyncTeaData.cs
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
    /// 同步教师数据。
    /// </summary>
    internal class SyncTeaData : SyncDataBase
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity;
        SFITeachersEntity teachersEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="dataPoxy"></param>
        /// <param name="syncName"></param>
        public SyncTeaData(IDataSync dataPoxy, string syncName)
            : base(dataPoxy, syncName)
        {
            this.schoolsEntity = new SFITSchoolsEntity();
            this.teachersEntity = new SFITeachersEntity();
        }
        #endregion

        protected override void DataSync(StringBuilder logBuilder, StringBuilder insertBuilder, StringBuilder updateBuilder, StringBuilder hiddenBuilder, int insertCount, int updateCount, int hiddenCount)
        {
            this.teachersEntity.DbEntityDataChangeLogEvent += new DbEntityDataChangeLogHandler(delegate(string head, string content)
            {
                this.AppendLog(logBuilder, string.Format("head:{0},content:{1}", head, content));
            });
            IDataSync sync = this.DataPoxy;
            if (sync == null)
            {
                return;
            }
            List<SFITSchools> schools = this.schoolsEntity.LoadAllowSyncData();
            int count = 0;
            if (schools != null && (count = schools.Count) > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    SyncTeachers teachers = sync.SyncAllTeachers(schools[i].SchoolName);
                    if (teachers != null && teachers.Count > 0)
                    {
                        foreach (SyncTeacher tea in teachers)
                        {
                            SFITeachers data = new SFITeachers();
                            data.TeacherID = this.teachersEntity.GetTeacherID(tea.TeaCode);
                            if (data.TeacherID.IsValid && this.teachersEntity.LoadRecord(ref data))
                            {
                                if (data.SyncStatus == 0x00)
                                {
                                    continue;
                                }
                            }
                            data.TeacherCode = tea.TeaCode;
                            data.TeacherName = tea.TeaName;
                            data.SchoolID = schools[i].SchoolID;
                            data.SyncStatus = 0x02;
                            data.LastSyncTime = DateTime.Now;
                            if (!data.TeacherID.IsValid)
                            {
                                data.TeacherID = GUIDEx.New;
                                this.AppendLog(insertBuilder, string.Format("(教师ID：{0})[代码：{1}][名称：{2}]；", data.TeacherID, data.TeacherCode, data.TeacherName));
                                insertCount++;
                            }
                            else
                            {
                                this.AppendLog(updateBuilder, string.Format("(教师ID：{0})[代码：{1}][名称：{2}]；", data.TeacherID, data.TeacherCode, data.TeacherName));
                                updateCount++;
                            }
                            this.teachersEntity.UpdateRecord(data);
                        }
                    }
                }
            }
        }
    }
}