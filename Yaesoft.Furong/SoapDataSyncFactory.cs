//================================================================================
//  FileName: SoapDataSyncFactory.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-9-10
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
using System.Net;
using System.IO;
using System.Xml;

using iPower;
using Yaesoft.SFIT;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.Furong
{
    /// <summary>
    /// 基于Soap1.2协议的Webservice访问实现.
    /// </summary>
    public sealed class SoapDataSyncFactory : IDataSync, IUserAuthentication
    {
        #region 成员变量,构造函数.
        /// <summary>
        /// 构造函数.
        /// </summary>
        public SoapDataSyncFactory()
        {
        }
        #endregion

        #region 辅助函数.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private XmlDocument WebSoap12Post(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";//请求方式。
            request.ContentType = "application/soap+xml; charset=utf-8";
            byte[] post = Encoding.UTF8.GetBytes(data);//编码方式.
            request.ContentLength = post.Length;
            //提交数据。
            using (Stream writer = request.GetRequestStream())
            {
                writer.Write(post, 0, post.Length);
            }
            //获取返回数据。
            string callback;
            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                if (status == HttpStatusCode.OK)
                {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        callback = reader.ReadToEnd();
                    }
                }
                else
                {
                    throw new Exception(string.Format("状态码：{0}({1})", status, (int)status));
                }
            }
            
            if (!string.IsNullOrEmpty(callback))
            {
                if (callback[0] != '<')
                {
                    int index = callback.IndexOf('<', 0);
                    if (index > 0) callback = callback.Substring(index);
                }

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(callback);
                    return doc;
                }
                catch (Exception e)
                {
                    throw new Exception("转化为Xml时出错[" + e.Message + "]\r\n" + callback, e);
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private string getElementValue(XmlElement e, string xpath)
        {
            if (e != null)
            {
                if (!string.IsNullOrEmpty(xpath))
                {
                   XmlNode node = e.SelectSingleNode(xpath);
                   if (node is XmlElement)
                   {
                       return ((XmlElement)node).InnerText;
                   }
                }
                return e.InnerText;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="bodyInner"></param>
        /// <returns></returns>
        private string createSoap12Message(ServicePoxyAccount sp, string bodyInner)
        {
            StringBuilder post = new StringBuilder();
            post.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>")
                .Append("<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">")
                .Append("<soap12:Header>")
                .Append("<AuthHeader xmlns=\"http://tempuri.org/\">")
                .Append("<UserName>" + sp.Username + "</UserName>")
                .Append("<PassWord>" + sp.Password + "</PassWord>")
                .Append("</AuthHeader>")
                .Append("</soap12:Header>")
                .Append("<soap12:Body>")
                .Append(bodyInner)
                .Append("</soap12:Body>")
                .Append("</soap12:Envelope>");
            return post.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="el"></param>
        /// <returns></returns>
        private delegate T SoapCallbackParserHandler<T>(XmlElement el)
            where T : class, new();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sp"></param>
        /// <param name="bodyInner"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        private List<T> PostSoapWebService<T>(ServicePoxyAccount sp, string bodyInner, SoapCallbackParserHandler<T> handler)
            where T: class, new()
        {
            if (sp != null && !string.IsNullOrEmpty(bodyInner))
            {
                XmlDocument doc = this.WebSoap12Post(sp.Url, this.createSoap12Message(sp, bodyInner));
                if (doc != null)
                {
                    XmlNodeList list = doc.SelectNodes("//NewDataSet/Datas");
                    if (list != null && list.Count > 0 && handler != null)
                    {
                        List<T> result = new List<T>();
                        foreach (XmlNode node in list)
                        {
                            if (node is XmlElement)
                            {
                                T t = handler((XmlElement)node);
                                if (t != null)
                                    result.Add(t);
                            }
                        }
                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region IDataSync 成员
        /// <summary>
        /// 同步全部单位数据。
        /// </summary>
        /// <returns>单位数据集合。</returns>
        public SyncUnits SyncAllUnit()
        {
            ServicePoxyAccount sp = ModuleConfiguration.ModuleConfig.SyncDataService;
            List<SyncUnit> list = this.PostSoapWebService<SyncUnit>(sp, "<GetAllSchool xmlns=\"http://tempuri.org/\" />", new SoapCallbackParserHandler<SyncUnit>(delegate(XmlElement el) {
                SyncUnit su = new SyncUnit();
                su.UnitCode = this.getElementValue(el, "./dwdm");
                su.UnitName = this.getElementValue(el, "./dwmc");
                su.UnitType = this.getElementValue(el, "./dwlbm");
                return su;
            }));
            if (list != null && list.Count > 0)
            {
                SyncUnits units = new SyncUnits();
                foreach (SyncUnit su in list)
                {
                    units.Add(su);
                }
                return units;
            }
            return null;
        }
        /// <summary>
        /// 同步学校名称下的教师数据。
        /// </summary>
        /// <param name="unitName">单位名称。</param>
        /// <returns>教师数据集合。</returns>
        public SyncTeachers SyncAllTeachers(string unitName)
        {
            ServicePoxyAccount sp = ModuleConfiguration.ModuleConfig.SyncDataService;
            StringBuilder body = new StringBuilder();
            body.Append("<GetTeacher xmlns=\"http://tempuri.org/\">")
                .Append("<dwmc>" + unitName + "</dwmc>")
                .Append("</GetTeacher>");
            List<SyncTeacher> list = this.PostSoapWebService<SyncTeacher>(sp, body.ToString(), new SoapCallbackParserHandler<SyncTeacher>(delegate(XmlElement el) {
                SyncTeacher st = new SyncTeacher();
                st.TeaCode = this.getElementValue(el, "./account");
                st.TeaName = this.getElementValue(el, "./xm");
                st.School.UnitCode = this.getElementValue(el, "./dwdm");
                st.School.UnitName = this.getElementValue(el, "./dwmc");
                return st;
            }));
            if (list != null && list.Count > 0)
            {
                SyncTeachers teachers = new SyncTeachers();
                foreach (SyncTeacher st in list)
                {
                    teachers.Add(st);
                }
                return teachers;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public SyncClasses SyncAllClasses(string unitName)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        #endregion
    }
}