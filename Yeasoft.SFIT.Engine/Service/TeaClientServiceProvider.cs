//================================================================================
//  FileName: TeaClientServiceProvider.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/10/10
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
using Yaesoft.SFIT;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 教师机客户端服务提供累。
    /// </summary>
    public class TeaClientServiceProvider
    {
        #region 成员变量，构造函数。
        SFITCenterAccessEntity centerAccessEntity = null;
        SFITeachersEntity teachersEntity = null;
        SFITTeaClassEntity teaClassEntity = null;
        SFITSchoolsEntity schoolsEntity = null;
        SFITGradeEntity gradeEntity = null;
        SFITEvaluateEntity evaluateEntity = null;
        SFITClassEntity classEntity = null;
        SFITStudentsEntity studentsEntity = null;
        SFITCatalogEntity catalogEntity = null;
        SFITStudentWorksEntity studentWorksEntity = null;

        SFITSchoolSetCatalogEntity schoolSetCatalogEntity = null;
        GetLocalUserInfo localUserInfo = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public TeaClientServiceProvider()
        {
            this.centerAccessEntity = new SFITCenterAccessEntity();
            this.teaClassEntity = new SFITTeaClassEntity();

            this.teachersEntity = new SFITeachersEntity();
            this.schoolsEntity = new SFITSchoolsEntity();
            this.gradeEntity = new SFITGradeEntity();
            this.evaluateEntity = new SFITEvaluateEntity();
            this.classEntity = new SFITClassEntity();
            this.studentsEntity = new SFITStudentsEntity();
            this.catalogEntity = new SFITCatalogEntity();

            this.schoolSetCatalogEntity = new SFITSchoolSetCatalogEntity();
            this.studentWorksEntity = new SFITStudentWorksEntity();

            this.localUserInfo = new GetLocalUserInfo();
        }
        #endregion

        #region 处理函数。
        /// <summary>
        /// 验证访问授权。
        /// </summary>
        /// <param name="schoolID">学校ID。</param>
        /// <param name="accessAccount">授权账号。</param>
        /// <param name="accessPassword">授权密码。</param>
        /// <returns></returns>
        public CallResult VerifyAccessAuthorization(GUIDEx schoolID, string accessAccount, string accessPassword)
        {
            if (string.IsNullOrEmpty(schoolID))
                return new CallResult(-1, "验证授权_学校ID为空。");

            if (string.IsNullOrEmpty(accessAccount) || string.IsNullOrEmpty(accessPassword))
                return new CallResult(-1, "验证授权_授权账号或密码为空。");

            SFITCenterAccess data = this.centerAccessEntity.LoadRecord(schoolID);
            if (data == null)
                return new CallResult(-1, "验证授权_学校ID未创建授权信息。");

            if (data.AccessAccount != accessAccount)
                return new CallResult(-1, string.Format("验证授权_学校[{0}]授权账号（{1}）错误。", data.SchoolName, accessAccount));

            if (data.AccessPassword != accessPassword)
                return new CallResult(-1, "授权密码错误。");

            return new CallResult(0, "授权验证通过。");
        }
        /// <summary>
        /// 验证用户身份。
        /// </summary>
        /// <param name="schoolID">学校ID。</param>
        /// <param name="type">类型。</param>
        /// <param name="account">账号。</param>
        /// <param name="password">密码。</param>
        /// <returns></returns>
        public CallResult VerifyUserIdentity(GUIDEx schoolID, int type, string account, string password)
        {
            try
            {
                IUserAuthentication auth = new ModuleConfiguration().UserAuthentication;
                if (auth != null)
                {
                    string err = null;
                    SFITSchools school = new SFITSchools();
                    school.SchoolID = schoolID;
                    if (!this.schoolsEntity.LoadRecord(ref school))
                    {
                        throw new Exception("学校ID不存在或被修改删除！");
                    }
                    
                    GUIDEx userCode = auth.VerifyUser(type, account, password, out err);
                    if (!userCode.IsValid)
                        throw new Exception(string.IsNullOrEmpty(err) ? "未知错误" : err);
                    string employeeID = null, employeeCode = null, employeeName = null;
                    if (this.localUserInfo.GetUserInfo(type, userCode, out employeeID, out employeeCode, out employeeName))
                    {
                        if (type == 1)
                        {
                            //是否为任课教师。
                            if (!this.teaClassEntity.VerifyInstructor(schoolID, employeeID))
                            {
                                throw new Exception(string.Format("教师[{0},{1}]不属于学校[{2},{3}]的任课教师！", employeeCode, employeeName,
                                    school.SchoolCode, school.SchoolName));
                            }
                        }
                    }
                    else
                        throw new Exception(string.Format("账号[{0}]对应的信息不存在！", account));
                    return new CallResult(0, string.Join(",", new string[] { employeeID, employeeCode, employeeName }));
                }
                return new CallResult(-1, "未接入城域网。");
            }
            catch (Exception e)
            {
                return new CallResult(-1, e.Message);
            }
        }
        /// <summary>
        /// 下载教师同步数据。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public TeaSyncData DownloadTeaSyncData(GUIDEx schoolID, GUIDEx teacherID)
        {
            if (!schoolID.IsValid || !teacherID.IsValid)
            {
                return null;
            }
            TeaSyncData result = null;

            School scInfo = new School();
            #region 学校信息。
            if (this.schoolsEntity.LoadTeaSyncSchool(ref scInfo, schoolID))
            {
                result = new TeaSyncData();
                result.School = scInfo;
            }
            #endregion

            Teacher teaInfo = new Teacher();
            #region 教师信息。
            if (this.teachersEntity.LoadTeaSyncTeacher(ref teaInfo, teacherID))
            {
                scInfo.Teacher = teaInfo;
            }
            #endregion

            #region 年级。
            Grades grades = this.gradeEntity.LoadTeaSyncGrades(schoolID, teaInfo.TeacherID);
            if (grades != null && grades.Count > 0)
            {
                for (int i = 0; i < grades.Count; i++)
                {
                    //目录,要点。
                    this.catalogEntity.LoadTeaSyncCatalogKnowledgePoints(grades[i], schoolID);
                    //客观评价方式。
                    this.evaluateEntity.LoadTeaSyncEvaluate(grades[i]);
                    //班级，学生。
                    this.classEntity.LoadTeaSyncClassStudents(grades[i], teaInfo.TeacherID);
                }
                teaInfo.Grades = grades;
            }
            #endregion

            return result;
        }
        /// <summary>
        /// 上传学生作品。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="stuWorks"></param>
        /// <returns></returns>
        public bool UploadStudentWorks(GUIDEx schoolID, StudentWorkTeaUpload data)
        {
            bool result = false;
            if (data != null && schoolID.IsValid)
            {
                //判断提交时间是否过期。
               // if (this.schoolSetCatalogEntity.ValidWorkUploadExpired(schoolID, data.CatalogID))
                 //   throw new Exception("作品已经超过上传的制定时间段！");
                //检查作品是否已经发布。
                //SFITStudentWorks work = new SFITStudentWorks();
                //work.WorkID = data.WorkID;
                //if (this.studentWorksEntity.LoadRecord(ref work))
                //{
                //    if ((((EnumWorkStatus)work.WorkStatus) & EnumWorkStatus.Release) == EnumWorkStatus.Release)
                //    {
                //        throw new Exception(string.Format("学生作品[{0},{1}]已经发布不允许重新上传！", data.Student.StudentName, data.WorkName));
                //    }
                //}
                //上传作品入库。
                result = this.studentWorksEntity.UploadWorks(schoolID, data);
            }
            return result;
        }
        
        #endregion
    }
}
