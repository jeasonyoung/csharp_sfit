//================================================================================
//  FileName: SyncStudentsData.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/10
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
    /// 同步学生数据。
    /// </summary>
    internal class SyncStudentsData : SyncDataBase
    {
        #region 成员变量，构造函数。
        SFITStudentsEntity studentsEntity = null;
        SFITClassStudentsEntity classStudentEntity = null;
        SecurityRoleEmployeeEntity roleEmployeeEntity = null;
        GUIDEx studentUserRoleID = GUIDEx.Null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="dataPoxy"></param>
        /// <param name="syncName"></param>
        public SyncStudentsData(IDataSync dataPoxy,string syncName)
            : base(dataPoxy, syncName)
        {
            this.studentsEntity = new SFITStudentsEntity();
            this.classStudentEntity = new SFITClassStudentsEntity();
            this.roleEmployeeEntity = new SecurityRoleEmployeeEntity();
            this.studentUserRoleID = ModuleConfiguration.ModuleConfig.StudentUserRoleID;
        }
        #endregion

        protected override void DataSync(StringBuilder logBuilder, StringBuilder insertBuilder, StringBuilder updateBuilder, StringBuilder hiddenBuilder, int insertCount, int updateCount, int hiddenCount)
        {
            this.studentsEntity.DbEntityDataChangeLogEvent += new DbEntityDataChangeLogHandler(delegate(string head, string content)
            {
                this.AppendLog(logBuilder, string.Format("head:{0},content:{1}", head, content));
            });
            this.classStudentEntity.DbEntityDataChangeLogEvent += new DbEntityDataChangeLogHandler(delegate(string head, string content)
            {
                this.AppendLog(logBuilder, string.Format("head:{0},content:{1}", head, content));
            });
            List<SFITSchools> schools = new SFITSchoolsEntity().LoadAllowSyncData();
            IDataSync dataSync = this.DataPoxy;
            int count = 0;
            if (schools != null && dataSync != null && (count = schools.Count) > 0)
            {
                SFITClassEntity classEntity = new SFITClassEntity();
                for (int i = 0; i < count; i++)
                {
                    List<SFITClass> listClass = classEntity.LoadAllowSyncData(schools[i].SchoolID);
                    if (listClass != null && listClass.Count > 0)
                    {
                        foreach (SFITClass c in listClass)
                        {
                            List<GUIDEx> list = new List<GUIDEx>();
                            SyncStudents students = dataSync.SyncAllStudents(schools[i].SchoolName, string.Format("{0}", c.JoinYear), c.ClassName);
                            if (students != null && students.Count > 0)
                            {
                                for (int k = 0; k < students.Count; k++)
                                {
                                    #region 更新数据。
                                    SFITStudents data = new SFITStudents();
                                    data.StudentID = this.studentsEntity.GetStudentIDByCode(students[k].Code);
                                    if (data.StudentID.IsValid)
                                    {
                                        this.studentsEntity.LoadRecord(ref data);
                                    }
                                    data.StudentCode = students[k].Code;
                                    data.StudentName = students[k].Name;
                                    data.IDNumber = students[k].IDCard;
                                    data.JoinYear = int.Parse(students[k].JoinYear);
                                    data.Gender = this.TransGender(students[k].Gender);
                                    data.LastSyncTime = DateTime.Now;
                                    data.SyncStatus = 0x02;

                                    if (!data.StudentID.IsValid)
                                    {
                                        data.StudentID = GUIDEx.New;
                                        this.AppendLog(insertBuilder, string.Format("(学生ID：{0})[学号：{1}][名称：{2}][性别：{3}][入学年份：{4}][身份证号：{5}]；",
                                            data.StudentID, data.StudentCode, data.StudentName, data.Gender, data.JoinYear, data.IDNumber));
                                        insertCount++;
                                    }
                                    else
                                    {
                                        this.AppendLog(updateBuilder, string.Format("(学生ID：{0})[学号：{1}][名称：{2}][性别：{3}][入学年份：{4}][身份证号：{5}]；",
                                            data.StudentID, data.StudentCode, data.StudentName, data.Gender, data.JoinYear, data.IDNumber));
                                        updateCount++;
                                    }

                                    if (this.studentsEntity.UpdateRecord(data))
                                    {
                                        //添加到集合。
                                        list.Add(data.StudentID);
                                        //建立学生班级关系。
                                        this.classStudentEntity.Delete(data.StudentID);
                                        if (!this.classStudentEntity.ExistsData(c.ClassID, data.StudentID))
                                        {
                                            SFITClassStudents csdata = new SFITClassStudents();
                                            csdata.ClassID = c.ClassID;
                                            csdata.StudentID = data.StudentID;
                                            csdata.LastSyncTime = DateTime.Now;
                                            
                                            this.AppendLog(insertBuilder, string.Format("班级学生关系：[班级ID：{0}][班级代码：{1}][班级名称：{2}] -> [学生ID:{3}][学号：{4}][姓名：{5}]",
                                                                        c.ClassID, c.ClassCode, c.ClassName, data.StudentID, data.StudentCode, data.StudentName));
                                            this.classStudentEntity.UpdateRecord(csdata);
                                        }
                                        //设置学生角色。
                                        this.SetStudentAccessRole(data);
                                    }
                                    #endregion
                                }
                            }
                            //未同步的学生将设置为停止同步。
                            this.studentsEntity.StopSync(c.ClassID, list, ref hiddenBuilder, ref hiddenCount);
                        }
                    }
                }
            }
        }

        #region 辅助函数。
        /// <summary>
        /// 性别转换。
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        int TransGender(string gender)
        {
            if (gender.IndexOf("男") > -1)
                return 1;
            else if (gender.IndexOf("女") > -1)
                return 2;
            return 0;
        }
        /// <summary>
        /// 设置学生角色。
        /// </summary>
        /// <param name="data"></param>
        void SetStudentAccessRole(SFITStudents data)
        {
            if (data != null)
            {
                SecurityRoleEmployee roleEmp = new SecurityRoleEmployee();
                roleEmp.EmployeeID = data.StudentID;
                roleEmp.EmployeeName = data.StudentName;
                roleEmp.RoleID = this.studentUserRoleID;
                if (roleEmp.RoleID.IsValid)
                {
                    this.roleEmployeeEntity.UpdateRecord(roleEmp);
                }
            }
        }
        #endregion
    }
}