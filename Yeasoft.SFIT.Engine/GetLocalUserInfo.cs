//================================================================================
//  FileName: GetLocalUserInfo.cs
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

using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine
{
    /// <summary>
    /// 获取本地用户信息。
    /// </summary>
    public class GetLocalUserInfo : IGetUserInfo
    {
        #region 成员变量，构造函数。
        SFITeachersEntity teachersEntity = null;
        SFITStudentsEntity studentsEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public GetLocalUserInfo()
        {
            this.teachersEntity = new SFITeachersEntity();
            this.studentsEntity = new SFITStudentsEntity();
        }
        #endregion

        #region IGetUserInfo 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="userCode"></param>
        /// <param name="employeeID"></param>
        /// <param name="employeeCode"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public bool GetUserInfo(int type, string userCode, out string employeeID, out string employeeCode, out string employeeName)
        {
            bool result = false;
            employeeID = employeeCode = employeeName = null;
            switch (type)
            {
                case 1:
                    {
                        //教师。
                        SFITeachers teacher = this.teachersEntity.FindTeacher(userCode);
                        if (teacher != null)
                        {
                            employeeID = teacher.TeacherID;
                            employeeCode = teacher.TeacherCode;
                            employeeName = teacher.TeacherName;
                            result = true;
                        }
                    }
                    break;
                case 2:
                    {
                        //学生。
                        SFITStudents stu = this.studentsEntity.FindStudentByCode(userCode);
                        if (stu != null)
                        {
                            employeeID = stu.StudentID;
                            employeeCode = stu.StudentCode;
                            employeeName = stu.StudentName;
                            result = true;
                        }
                    }
                    break;
                default:
                    throw new ArgumentNullException("用户类型错误：" + type);
            }
            return result;
        }

        #endregion
    }
}
