//================================================================================
//  FileName: CreateCredentialsPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/10/18
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
using System.Xml;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICreateCredentialsView
    {
        /// <summary>
        /// 获取客户端服务URL。
        /// </summary>
        string ClientServiceUrl { get; }
        /// <summary>
        /// 获取访问ID集合。
        /// </summary>
        string[] AccessID { get; }
    }
    /// <summary>
    /// 创建用户访问密钥行为类。
    /// </summary>
    public class CreateCredentialsPresenter
    {
        #region 成员变量，构造函数。
        ICreateCredentialsView view = null;
        SFITCenterAccessEntity centerAccessEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public CreateCredentialsPresenter(ICreateCredentialsView view)
        {
            this.view = view;
            this.centerAccessEntity = new SFITCenterAccessEntity();
        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 生成密钥Xml。
        /// </summary>
        /// <param name="accessID"></param>
        /// <returns></returns>
        public XmlDocument BuildCredentials()
        {
            XmlDocument doc = null;
            if (this.view.AccessID != null && this.view.AccessID.Length > 0)
            {
                CredentialsCollection collection = this.centerAccessEntity.CreateCredentialsCollection(this.view.AccessID, this.view.ClientServiceUrl);
                if (collection != null && collection.Count > 0)
                {
                    doc = CredentialsFactory.Serialize(collection);
                }
            }
            return doc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static string[] GetAccessID(string employeeID)
        {
            return new SFITCenterAccessEntity().GetAccessID(employeeID);
        }
        #endregion
    }
}
