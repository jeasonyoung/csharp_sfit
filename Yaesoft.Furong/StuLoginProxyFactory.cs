//================================================================================
//  FileName: StuLoginProxyFactory.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-4-12
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
namespace Yaesoft.Furong
{
    /// <summary>
    /// 学生登录代理工厂类。
    /// </summary>
    internal class StuLoginProxyFactory : IDataSync, IUserAuthentication
    {
        #region 成员变量，构造函数。
        Yaesoft.Furong.Proxy.StuProxy.StuLoginService poxy = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public StuLoginProxyFactory()
        {
            ServicePoxyAccount sp = ModuleConfiguration.ModuleConfig.SyncDataService;
            Yaesoft.Furong.Proxy.StuProxy.AuthHeader ah = new Yaesoft.Furong.Proxy.StuProxy.AuthHeader();
            ah.UserName = sp.Username;
            ah.PassWord = sp.Password;

            this.poxy = new Yaesoft.Furong.Proxy.StuProxy.StuLoginService();
            this.poxy.AuthHeaderValue = ah;
            this.poxy.Url = sp.Url;
        }
        #endregion

        #region IDataSync 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SyncUnits SyncAllUnit()
        {
            SyncUnits collection = new SyncUnits();
            DataTable dtSource = this.poxy.GetAllSchool();
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    SyncUnit data = new SyncUnit();
                    data.UnitCode = Convert.ToString(row["DWDM"]);
                    data.UnitName = Convert.ToString(row["DWMC"]);
                    data.UnitType = Convert.ToString(row["DWLBM"]);
                    collection.Add(data);
                }
            }
            return collection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public SyncTeachers SyncAllTeachers(string unitName)
        {
            SyncTeachers collection = new SyncTeachers();
            DataTable dtSource = this.poxy.GetTeacher(unitName);
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    SyncTeacher data = new SyncTeacher();
                    data.TeaCode = Convert.ToString(row["ACCOUNT"]);
                    data.TeaName = Convert.ToString(row["XM"]);
                    data.School.UnitCode = Convert.ToString(row["DWDM"]);
                    data.School.UnitName = Convert.ToString(row["DWMC"]);
                    try
                    {
                        data.Sex = Convert.ToString(row["XB"]);
                    }
                    catch (Exception) { }
                    try
                    {
                        data.Titles = Convert.ToString(row["ZC"]);
                    }
                    catch (Exception) { }
                    try
                    {
                        data.Phone = Convert.ToString(row["DH"]);
                    }
                    catch (Exception) { }
                    try
                    {
                        data.Birthday = Convert.ToString(row["CSRQ"]);
                    }
                    catch (Exception) { }
                    try
                    {
                        data.JobCategory = Convert.ToString(row["ZWLB"]);
                    }
                    catch (Exception) { }
                    collection.Add(data);
                }
            }
            return collection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public SyncClasses SyncAllClasses(string unitName)
        {
            SyncClasses collection = new SyncClasses();
            DataTable dtSource = this.poxy.GetClass(unitName);
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    SyncClass data = new SyncClass();
                    data.Code = Convert.ToString(row["BJDM"]);
                    data.Name = Convert.ToString(row["BJMC"]);
                    data.JoinYear = Convert.ToString(row["RXNF"]);
                    data.Grade = Convert.ToString(row["dqnj"]);
                    data.LearnLevel = this.GetLearnLevel(Convert.ToString(row["bjlx"]));
                    data.School.UnitCode = Convert.ToString(row["LSDWM"]);
                    data.School.UnitName = Convert.ToString(row["LSDWMC"]);
                    collection.Add(data);
                }
            }
            return collection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitName"></param>
        /// <param name="joinYear"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public SyncStudents SyncAllStudents(string unitName, string joinYear, string className)
        {
            SyncStudents collection = new SyncStudents();
            DataTable dtSource = this.poxy.GetStudent(unitName, joinYear, className, string.Empty);
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    SyncStudent data = new SyncStudent();
                    data.Code = Convert.ToString(row["XH"]);
                    data.Name = Convert.ToString(row["XM"]);
                    data.IDCard = Convert.ToString(row["SFZH"]);
                    data.Gender = Convert.ToString(row["XB"]);
                    data.JoinYear = Convert.ToString(row["RXNF"]);
                    data.School.UnitCode = Convert.ToString(row["xxdm"]);
                    data.School.UnitName = Convert.ToString(row["xxmc"]);
                    collection.Add(data);
                }
            }
            return collection;
        }

        #endregion

        #region IUserAuthentication 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public string VerifyUser(int type, string account, string password, out string err)
        {
            string result = err = null;
            try
            {
                DataTable dt = this.poxy.VerifyUser(account, password);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = Convert.ToString(dt.Rows[0]["xh"]);
                }
            }
            catch (Exception e)
            {
                err = e.Message;
            }
            return result;
        }

        #endregion


        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bjlx"></param>
        /// <returns></returns>
        private EnumLearnLevel GetLearnLevel(string bjlx)
        {
            if (!string.IsNullOrEmpty(bjlx))
            {
                switch (bjlx.ToLower().Trim())
                {
                    case "幼儿园":
                        return EnumLearnLevel.Nursery;
                    case "小学":
                        return EnumLearnLevel.PrimarySchool;
                    case "初中":
                        return EnumLearnLevel.JuniorHighSchool;
                    case "高中":
                        return EnumLearnLevel.HighSchool;
                }
            }
            return EnumLearnLevel.PrimarySchool;
        }
        #endregion
    }
}