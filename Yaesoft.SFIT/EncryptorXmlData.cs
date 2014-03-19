//================================================================================
//  FileName: EncryptorXmlData.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-01-04 
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
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 加密Xml数据。
    /// </summary>
    internal static class EncryptorXmlData
    {
        #region 成员变量，构造函数。
        static SymmetricAlgorithm keyAlgorithm;
        /// <summary>
        /// 构造函数。
        /// </summary>
        static EncryptorXmlData()
        {
            keyAlgorithm = (SymmetricAlgorithm)(new RijndaelManaged());
            keyAlgorithm.Key = new byte[] { 0x01, 0x02, 0x03, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x04, 0x05, 0x06 };
            keyAlgorithm.IV = new byte[] { 0x08, 0x09, 0x10, 0x01, 0x02, 0x03, 0x04, 0x05, 0x13, 0x14, 0x15, 0x16, 0x06, 0x07, 0x11, 0x12 };
        }
        #endregion

        /// <summary>
        /// 加密Xml。
        /// </summary>
        /// <param name="doc"></param>
        public static void EncryptorXml(XmlDocument doc)
        {
            if (doc != null)
            {
                XmlElement encElement = doc.DocumentElement;
                EncryptedXml encXml = new EncryptedXml(doc);
                encXml.AddKeyNameMapping("session", keyAlgorithm);
                EncryptedData encData = encXml.Encrypt(encElement, "session");
                EncryptedXml.ReplaceElement(encElement, encData, false);
            }
        }
        /// <summary>
        /// 解密Xml。
        /// </summary>
        /// <param name="doc"></param>
        public static void DecryptorXml(XmlDocument doc)
        {
            if (doc != null)
            {
                EncryptedXml encXml = new EncryptedXml(doc);
                encXml.AddKeyNameMapping("session", keyAlgorithm);
                encXml.DecryptDocument();
            }
        }
    }
}
