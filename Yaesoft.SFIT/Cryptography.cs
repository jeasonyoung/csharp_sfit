//================================================================================
//  FileName: Cryptography.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/1
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

using System.IO;
using System.Security.Cryptography;
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 加密数据。
    /// </summary>
    public static class Cryptography
    {
        #region 成员变量，构造函数。
        static SymmetricAlgorithm keyAlgorithm;
        /// <summary>
        /// 构造函数。
        /// </summary>
        static Cryptography()
        {
            byte[] key = new byte[] { 0x01, 0x02, 0x03, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x04, 0x05, 0x06 };
            byte[] iv = new byte[] { 0x08, 0x09, 0x10, 0x01, 0x02, 0x03, 0x04, 0x05, 0x13, 0x14, 0x15, 0x16, 0x06, 0x07, 0x11, 0x12 };

            keyAlgorithm = (SymmetricAlgorithm)(new RijndaelManaged());
            keyAlgorithm.Key = key;
            keyAlgorithm.IV = iv;
        }
        #endregion

        #region 加密。
        /// <summary>
        /// 加密数据。
        /// </summary>
        /// <param name="data">明文数据。</param>
        /// <returns>密文数据。</returns>
        public static byte[] Encrypt(byte[] data)
        {
            byte[] output = null;
            if (data != null && data.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream encStream = new CryptoStream(ms, keyAlgorithm.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        encStream.Write(data, 0, data.Length);
                    }
                    output = ms.ToArray();
                }
            }
            return output;
        }
        /// <summary>
        /// 解密数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] data)
        {
            byte[] result = null;
            if (data != null && data.Length > 0)
            {
                using (MemoryStream output = new MemoryStream())
                {
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        using (CryptoStream encStream = new CryptoStream(ms, keyAlgorithm.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            byte[] buf = new byte[512];
                            int len = 0;
                            while ((len = encStream.Read(buf, 0, buf.Length)) > 0)
                            {
                                output.Write(buf, 0, len);
                            }
                        }
                    }
                    result = output.ToArray();
                }
            }
            return result;
        }
        #endregion
    }
}
