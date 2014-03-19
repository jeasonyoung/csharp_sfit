//================================================================================
//  FileName: DataSyncFactory.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-12-14
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
using Yaesoft.SFIT;
using Yaesoft.SFIT.DataSync;
using Yaesoft.iCampus.Poxy;
namespace Yaesoft.iCampus
{
    /// <summary>
    /// 数据同步工厂类。
    /// </summary>
    public sealed class DataSyncFactory : IDataSync, IUserAuthentication
    {
        #region 成员变量，构造函数。
        DataInterfaceWS_SFIT poxy = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DataSyncFactory()
        {
            ServicePoxyAccount sp = ModuleConfiguration.ModuleConfig.SyncDataService;
            CredentialSoapHeader csh = new CredentialSoapHeader();
            csh.UserID = sp.Username;
            csh.UserPass = sp.Password;
            this.poxy = new DataInterfaceWS_SFIT();
            this.poxy.CredentialSoapHeaderValue = csh;
            this.poxy.Url = sp.Url;
        }
        #endregion

        #region IDataSync 成员
        /// <summary>
        /// 获取全部的学校单位。
        /// </summary>
        /// <returns></returns>
        public SyncUnits SyncAllUnit()
        {
            string err = null;
            DataTable dtSource = this.poxy.SyncAllUnit(out err);
            if (!string.IsNullOrEmpty(err))
            {
                throw new Exception("获取学校单位数据时发生异常：" + err);
            }
            SyncUnits units = new SyncUnits();
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    SyncUnit su = new SyncUnit();
                    su.UnitCode = string.Format("{0}", row["UnitCode"]);
                    su.UnitName = string.Format("{0}", row["UnitName"]);
                    su.UnitType = string.Format("{0}", row["UnitType"]);
                    units.Add(su);
                }
            }
            return units;
        }
        /// <summary>
        /// 同步所有的教师数据。
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public SyncTeachers SyncAllTeachers(string unitName)
        {
            string err = null;
            DataTable dtSource = this.poxy.SyncAllTeachers(unitName, out err);
            if (!string.IsNullOrEmpty(err))
            {
                throw new Exception("同步学校[" + unitName + "]下教师数据发生异常：" + err);
            }
            SyncTeachers teachers = new SyncTeachers();
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    SyncTeacher st = new SyncTeacher();
                    st.TeaName = string.Format("{0}", row["TeaName"]);
                    st.TeaCode = string.Format("{0}", row["TeaCode"]);
                    teachers.Add(st);
                }
            }
            return teachers;
        }
        /// <summary>
        /// 同步所有班级。
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public SyncClasses SyncAllClasses(string unitName)
        {
            string err = null;
            DataTable dtSource = this.poxy.SyncAllClasses(unitName, out err);
            if (!string.IsNullOrEmpty(err))
            {
                throw new Exception("同步学校[" + unitName + "]下班级数据发生异常：" + err);
            }
            SyncClasses classes = new SyncClasses();
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    SyncClass sc = new SyncClass();
                    sc.Code = string.Format("{0}", row["Code"]);
                    sc.Name = string.Format("{0}", row["Name"]);
                    sc.Grade = string.Format("{0}", row["Grade"]);
                    sc.JoinYear = string.Format("{0}", row["JoinYear"]);
                    sc.LearnLevel = (EnumLearnLevel)Enum.Parse(typeof(EnumLearnLevel), string.Format("{0}", row["LearnLevel"]), true);
                    classes.Add(sc);
                }
            }
            return classes;
        }
        /// <summary>
        /// 同步学生数据。
        /// </summary>
        /// <param name="unitName"></param>
        /// <param name="joinYear"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public SyncStudents SyncAllStudents(string unitName, string joinYear, string className)
        {
            string err = null;
            DataTable dtSource = this.poxy.SyncAllStudents(unitName, joinYear, className, out err);
            if (!string.IsNullOrEmpty(err))
            {
                throw new Exception("同步学校[" + unitName + "]下班级[" + joinYear + "#" + className + "]学生数据发生异常：" + err);
            }
            SyncStudents students = new SyncStudents();
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    SyncStudent item = new SyncStudent();
                    item.Code = string.Format("{0}", row["Code"]);
                    item.Name = string.Format("{0}", row["Name"]);
                    item.Gender = string.Format("{0}", row["Gender"]);
                    item.IDCard = string.Format("{0}", row["IDCard"]);
                    item.JoinYear = string.Format("{0}", row["JoinYear"]);
                    students.Add(item);
                }
            }
            return students;
        }

        #endregion

        #region IUserAuthentication 成员
        /// <summary>
        /// 验证用户。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public string VerifyUser(int type, string account, string password, out string err)
        {
            return this.poxy.UserAuthorizationVerification(type, account, password, out err);
        }

        #endregion
    }
}