//================================================================================
//  FileName: OrgFactory.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/2
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
using System.Data;

using iPower;
using iPower.IRMP.Org;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine
{
    /// <summary>
    /// 用户信息工厂类。
    /// </summary>
    public class OrgFactory : IOrgFactory
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity = null;
        SFITeachersEntity teacherEntity = null;
        SFITStudentsEntity studentsEntity = null;
        /// <summary> 
        /// 
        /// </summary>
        public OrgFactory()
        {
            this.schoolsEntity = new SFITSchoolsEntity();
            this.teacherEntity = new SFITeachersEntity();
            this.studentsEntity = new SFITStudentsEntity();
        }
        #endregion

        #region IOrgFactory 成员
        /// <summary>
        /// 获取学校数据。
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public OrgDepartmentCollection GetAllDepartment(string departmentID)
        {
            return this.schoolsEntity.GetAllDepartment(departmentID);
        }
        /// <summary>
        /// 获取教师和学生。
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public OrgEmployeeCollection GetAllEmployee(string employeeID)
        {
            OrgEmployeeCollection collection = new OrgEmployeeCollection();
            //教师。
            OrgEmployeeCollection teachers = this.teacherEntity.GetAllEmployee(employeeID);
            if (teachers != null && teachers.Count > 0)
                collection.Add(teachers);
            //学生。
            OrgEmployeeCollection schools = this.studentsEntity.GetAllEmployee(employeeID);
            if (schools != null && schools.Count > 0)
                collection.Add(schools);

            return collection;
        }

        public OrgPostCollection GetAllPost(string postID)
        {
            return new OrgPostCollection();
        }

        public OrgRankCollection GetAllRank(string rankID)
        {
            return new OrgRankCollection();
        }

        public OrgDepartmentCollection GetSubCharge(string employeeID)
        {
            OrgDepartmentCollection depts = new OrgDepartmentCollection();
            if (!string.IsNullOrEmpty(employeeID))
            {
                SFITeachers data = new SFITeachers();
                data.TeacherID = employeeID;
                if (this.teacherEntity.LoadRecord(ref data))
                {
                    OrgDepartment dept = new OrgDepartment();
                    dept.DepartmentID = data.SchoolID;
                    dept.DepartmentName = data.SchoolName;
                    depts.Add(dept);
                }
            }
            return depts;
        }

        #endregion
    }
}
