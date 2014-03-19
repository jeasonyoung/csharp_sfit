//================================================================================
//  FileName: SyncDataPoxyFactory.cs
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
using Yaesoft.SFIT;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.Furong
{
    /// <summary>
    /// 数据同步工厂类。
    /// </summary>
    public sealed class DataSyncFactory : IDataSync, IUserAuthentication
    {
        #region 成员变量，构造函数。
        TeaLoginPoxyFactory teaProxy = null;
        StuLoginProxyFactory stuProxy = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DataSyncFactory()
        {
            this.teaProxy = new TeaLoginPoxyFactory();
            this.stuProxy = new StuLoginProxyFactory();
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 获取单位信息集合。
        /// </summary>
        /// <returns></returns>
        public SyncUnits SyncAllUnit()
        {
            return this.stuProxy.SyncAllUnit();
        }
        /// <summary>
        /// 获取学校名称下的教师数据。
        /// </summary>
        /// <param name="unitName">单位名称。</param>
        /// <returns>教师数据集合</returns>
        public SyncTeachers SyncAllTeachers(string unitName)
        {
            return this.stuProxy.SyncAllTeachers(unitName);
        }
        /// <summary>
        ///  获取学校名称下的班级数据。
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public SyncClasses SyncAllClasses(string unitName)
        {
            return this.stuProxy.SyncAllClasses(unitName);
        }
        /// <summary>
        /// 获取学校名称下的学生数据。
        /// </summary>
        /// <param name="unitName">学校名称。</param>
        /// <param name="joinYear">入学年份。</param>
        /// <param name="className">班级名称。</param>
        /// <returns></returns>
        public SyncStudents SyncAllStudents(string unitName, string joinYear, string className)
        {
            return this.stuProxy.SyncAllStudents(unitName, joinYear, className);
        }
        #endregion

        #region IUserAuthentication 成员
        /// <summary>
        /// 验证用户。
        /// </summary>
        /// <param name="type">用户类型，1-教师，2-学生。</param>
        /// <param name="account">账号。</param>
        /// <param name="password">密码。</param>
        /// <param name="err">错误信息。</param>
        /// <returns>学生验证成功返回学生学号，教师返回账号。</returns>
        public string VerifyUser(int type, string account, string password, out string err)
        {
            string result = err = null;
            try
            {
                IUserAuthentication auth = null;
                if (type == 1)//验证教师登录。
                {
                    auth = this.teaProxy;
                }
                else if (type == 2)////验证学生登录。
                {
                    auth = this.stuProxy;
                }

                if (auth == null)
                {
                    err = "用户类型错误！" + type;
                }
                else
                {
                    result = auth.VerifyUser(type, account, password, out err);
                }
            }
            catch (Exception x)
            {
                result = null;
                err = x.Message;
            }
            return result;
        }

        #endregion
    }
}