//================================================================================
//  FileName: SyncDataStu.cs
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
    /// 同步学生。
    /// </summary>
    internal class SyncDataStu :SyncData
    {
        private UnitsEntity unitsEntity;
        private ClassesEntity classesEntity;
        private StudentsEntity stusEntity;
        private ClassStudentEntity classStusEntity;
        private DbModuleEntity<SecurityRoleEmployee> roleEmpsEntity;
        private GUIDEx roleId = GUIDEx.Null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conf"></param>
        /// <param name="log"></param>
        /// <param name="source"></param>
        public SyncDataStu(SyncJobConfigurations conf, WinServiceLog log, IDataSync source)
            : base(conf, log, source)
        {
            this.unitsEntity = new UnitsEntity(this.Config.ModuleDefaultDatabase, this.Log);
            this.classesEntity = new ClassesEntity(this.Config.ModuleDefaultDatabase, this.Log);
            this.stusEntity = new StudentsEntity(this.Config.ModuleDefaultDatabase, this.Log);
            this.classStusEntity = new ClassStudentEntity(this.Config.ModuleDefaultDatabase, this.Log);
            this.roleEmpsEntity = new DbModuleEntity<SecurityRoleEmployee>(this.Config.ModuleDefaultDatabase, this.Log);
            this.roleId = this.Config.StudentUserRoleID;
        }
        /// <summary>
        /// 
        /// </summary>
        public override string Name
        {
            get { return "同步学生数据"; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Sync()
        {
            if (this.Source == null) return;
            List<Unit> listUnits = this.unitsEntity.LoadAllowSyncData();
            if (listUnits == null || listUnits.Count == 0)
            {
                this.Log.ContentLog("没有允许同步学生的学校！");
                return;
            }
            for (int i = 0; i < listUnits.Count; i++)
            {
                try
                {
                    List<Entity.Class> listClasses = this.classesEntity.LoadAllowSyncData(listUnits[i].UnitID);
                    if (listClasses == null || listClasses.Count == 0)
                    {
                        this.Log.ContentLog(string.Format("学校[{0},{1}]下没有允许同步学生的班级！", i + 1, listUnits[i]));
                        continue;
                    }
                    for (int j = 0; j < listClasses.Count; j++)
                    {
                        try
                        {

                            int count = this.classStusEntity.DeleteClassStudents(listClasses[j].ClassID);
                            this.Log.ContentLog(string.Format("删除班级[{0}]下关联的学生[{1}]人！", listClasses[j], count));

                            SyncStudents sources = this.Source.SyncAllStudents(listUnits[i].UnitName, string.Format("{0}", listClasses[j].JoinYear), listClasses[j].ClassName);
                            if (sources == null || sources.Count == 0)
                            {
                                this.Log.ContentLog(string.Format("第[{0},{1}]条学校[{2}]下班级[{3}]下没有学生同步！", i + 1, j + 1, listUnits[i], listClasses[j]));
                                continue;
                            }
                            Entity.Student data = null;
                            for (int k = 0; k < sources.Count; k++)
                            {
                                try
                                {
                                    data = new Entity.Student();
                                    data.StudentID = this.stusEntity.LoadStudentIDByCode(sources[k].Code);
                                    if (data.StudentID.IsValid && this.stusEntity.LoadRecord(ref data))
                                    {
                                        if (data.SyncStatus == 0x00)
                                        {
                                            continue;
                                        }
                                    }
                                    data.StudentCode = sources[k].Code;
                                    data.StudentName = sources[k].Name;
                                    data.IDNumber = sources[k].IDCard;
                                    data.JoinYear = int.Parse(sources[k].JoinYear);
                                    data.Gender = this.TransGender(sources[k].Gender);
                                    data.LastSyncTime = DateTime.Now;
                                    data.SyncStatus = 0x02;

                                    bool isInsert = false;
                                    if (!data.StudentID.IsValid)
                                    {
                                        data.StudentID = GUIDEx.New;
                                        isInsert = true;
                                    }
                                    string log = string.Format("同步第[{0},{1},{2}]条数据[{3}]", i + 1, j + 1, k + 1, data);
                                    if (this.stusEntity.UpdateRecord(data))
                                    {
                                        this.Log.ContentLog(log + "[成功]");
                                        if (isInsert)//新生插入权限。
                                        {
                                            this.SetStudentAccessRole(data, this.roleId);
                                        }
                                        //建立班级学生关系。
                                        ClassStudent cs = new ClassStudent();
                                        cs.ClassID = listClasses[j].ClassID;
                                        cs.StudentID = data.StudentID;
                                        cs.LastSyncTime = DateTime.Now;

                                        log = string.Format("[{0},{1},{2}]建立学校[{3}]班级({4})学生({5})关联关系[{6}]", i + 1, j + 1, k + 1, listUnits[i], listClasses[j], sources[k], cs);
                                        if (this.classStusEntity.UpdateRecord(cs))
                                        {
                                            this.Log.ContentLog(log + "[成功]");
                                        }
                                        else
                                        {
                                            this.Log.ContentLog(log + "[失败]");
                                        }
                                    }
                                    else
                                    {
                                        this.Log.ContentLog(log + "[失败]");
                                    }
                                }
                                catch (Exception x)
                                {
                                    string err = string.Format("同步[{0},{1},{2}]学生数据[{2}]异常：{3}", i + 1, j + 1, k + 1, data, x.Message);
                                    this.Log.ContentLog(err);
                                    this.Log.ErrorLog(new Exception(err, x));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            string err = string.Format("同步第[{0},{1}]条学校[{2}]下班级[{3}]下学生数据时发生异常：{4}",
                                i + 1, j + 1, listUnits[i], listClasses[j], ex.Message);
                            this.Log.ContentLog(err);
                            this.Log.ErrorLog(new Exception(err, ex));
                        }
                    }
                }
                catch (Exception e)
                {
                    string err = string.Format("同步学校[{0},{1}]下的学生发生异常：{2}", i + 1, listUnits[i], e.Message);
                    this.Log.ContentLog(err);
                    this.Log.ErrorLog(new Exception(err, e));
                }
            }
        }
        /// <summary>
        /// 设置学生角色权限。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="roleId"></param>
        private void SetStudentAccessRole(Entity.Student data,GUIDEx roleId)
        {
            try
            {
                SecurityRoleEmployee sre = new SecurityRoleEmployee();
                sre.EmployeeID = data.StudentID;
                sre.EmployeeName = data.StudentName;
                sre.RoleID = roleId;
                if (this.roleEmpsEntity.UpdateRecord(sre))
                {
                    this.Log.ContentLog(string.Format("设置学生[{0}]访问角色({1})成功！", data, roleId));
                }
            }
            catch (Exception e)
            {
                string err = string.Format("设置学生[{0}]访问角色({1})异常：{2}", data, roleId, e.Message);
                this.Log.ContentLog(err);
                this.Log.ErrorLog(new Exception(err, e));
            }
        }
        /// <summary>
        /// 性别转换。
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        private int TransGender(string gender)
        {
            if (gender.IndexOf("男") > -1)
                return 1;
            else if (gender.IndexOf("女") > -1)
                return 2;
            return 0;
        }
    }
}