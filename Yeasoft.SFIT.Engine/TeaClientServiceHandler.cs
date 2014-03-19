//================================================================================
//  FileName: TeaClientServiceHandler.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-10-11
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
using System.Web.Services;
using System.Web.Services.Protocols;

using iPower;
using iPower.Handlers;
using Yaesoft.SFIT;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Engine
{
    /// <summary>
    /// 教师机客户端服务类。
    /// </summary>
    [WebService(Namespace = "http://ipower.org/",
               Name = "教师机客户端通信服务。",
               Description = "提供与教师机客户端之间的通信服务。")]
    [System.ComponentModel.ToolboxItem(false)]
    public class TeaClientServiceHandler : WebServiceHandler
    {
        #region 成员变量，构造函数。
        CredentialSoapHeader credentials = null;
        TeaClientServiceProvider provider = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public TeaClientServiceHandler()
        {
            this.credentials = new CredentialSoapHeader();
            this.provider = new TeaClientServiceProvider();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置验证。
        /// </summary>
        public CredentialSoapHeader Credentials
        {
            get { return this.credentials; }
            set
            {
                if (value != null) this.credentials = value;
            }
        }
        #endregion

        #region 公开函数。
        /// <summary>
        /// 验证用户。
        /// </summary>
        /// <param name="type">类型（1-教师，2-学生。）。</param>
        /// <param name="account">账号。</param>
        /// <param name="password">密码。</param>
        /// <returns></returns>
        [SoapHeader("Credentials")]
        [WebMethod(Description = "验证用户。")]
        public CallResult VerifyUserIdentity(int type, string account, string password)
        {
            try
            {
                CallResult callResult = null;
                GUIDEx schoolID = GUIDEx.Null;
                if (this.VerifyCredential(this, out schoolID))
                {
                    return this.provider.VerifyUserIdentity(schoolID, type, account, password);
                }
                return callResult;
            }
            catch (Exception e)
            {
                return new CallResult(-1, e.Message);
            }
        }
        /// <summary>
        /// 下载教师同步数据。
        /// </summary>
        /// <param name="teacherID">教师ID</param>
        /// <returns></returns>
        [SoapHeader("Credentials")]
        [WebMethod(Description = "下载教师同步数据。")]
        public GeneralCallResult<TeaSyncData> DownloadTeaSyncData(string teacherID)
        {
            try
            {
                GeneralCallResult<TeaSyncData> callResult = new GeneralCallResult<TeaSyncData>(-1, null,"未获取数据！");
                GUIDEx schoolID = GUIDEx.Null;
                if (this.VerifyCredential(this, out schoolID))
                {
                    if (string.IsNullOrEmpty(teacherID))
                        return new GeneralCallResult<TeaSyncData>(-1, null, "教师ID为空！");
                    TeaSyncData data = this.provider.DownloadTeaSyncData(schoolID, teacherID);
                    if (data != null)
                        return new GeneralCallResult<TeaSyncData>(0, data, "已成功获取数据。");
                }
                return callResult;
            }
            catch (Exception e)
            {
                return new GeneralCallResult<TeaSyncData>(-1, null, e.Message);
            }
        }
        /// <summary>
        /// 教师机上传学生作品。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [SoapHeader("Credentials")]
        [WebMethod(Description = "教师机上传学生作品。")]
        public CallResult UploadStudentWorks(StudentWorkTeaUpload data)
        {
            try
            {
                CallResult callResult = null;
                GUIDEx schoolID = GUIDEx.Null;
                if (this.VerifyCredential(this, out schoolID))
                {
                    if (data == null)
                        throw new Exception("学生作品信息为空！");
                    bool result = this.provider.UploadStudentWorks(schoolID, data);
                    callResult = new CallResult(result ? 0 : -1, result ? "上传作品成功。" : "上传失败！");
                }
                return callResult;
            }
            catch (Exception e)
            {
                return new CallResult(-1, e.Message);
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 验证访问授权。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="schoolID"></param>
        /// <returns></returns>
        bool VerifyCredential(TeaClientServiceHandler service, out GUIDEx schoolID)
        {
            bool result = false;
            schoolID = GUIDEx.Null;
            try
            {
                if (service != null && service.Credentials != null)
                {
                    CredentialSoapHeader credentials = service.Credentials;
                    schoolID = credentials.SchoolID;
                    CallResult callback = this.provider.VerifyAccessAuthorization(credentials.SchoolID, credentials.AccessAccount, credentials.AccessPassword);
                    if (!(result = (callback.ResultCode == 0)))
                    {
                        throw new Exception(callback.ResultMessage);
                    }
                }
            }
            catch (Exception e)
            {
                throw new SoapException(e.Message, SoapException.ClientFaultCode, e);
            }
            return result;
        }
        #endregion
    }
    #region 授权访问的验证。
    /// <summary>
    /// 授权访问的验证。
    /// </summary>
    public class CredentialSoapHeader : SoapHeader
    {
        #region 属性。
        /// <summary>
        /// 获取或设置学校ID。
        /// </summary>
        public string SchoolID { get; set; }
        /// <summary>
        /// 获取或设置授权访问账号。
        /// </summary>
        public string AccessAccount { get; set; }
        /// <summary>
        /// 获取或设置授权访问密码。
        /// </summary>
        public string AccessPassword { get; set; }
        #endregion
    }
    #endregion

    #region 通用返回泛型类。
    /// <summary>
    ///  通用返回泛型类。
    /// </summary>
    /// <typeparam name="T">数据类型。</typeparam>
    [Serializable]
    public class GeneralCallResult<T> : CallResult
        where T : class, new()
    {
        #region 成员变量，构造函数。
        T data = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public GeneralCallResult()
        {
            this.data = default(T);
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="resultCode">返回代码。</param>
        /// <param name="data">返回数据。</param>
        /// <param name="resultMessage">返回信息。</param>
        public GeneralCallResult(int resultCode, T data, string resultMessage)
            : base(resultCode, resultMessage)
        {
            this.data = data;
        }
        #endregion

        /// <summary>
        /// 获取或设置数据。
        /// </summary>
        public T Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
    }
    #endregion
}