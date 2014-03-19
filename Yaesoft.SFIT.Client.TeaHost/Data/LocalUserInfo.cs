//================================================================================
//  FileName: LocalUserInfo.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/30
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
using System.Runtime.Serialization.Formatters.Binary;
using Yaesoft.SFIT;
using Yaesoft.SFIT.Client.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 本地用户信息。
    /// </summary>
    [Serializable]
    public class LocalUserInfo : UserInfo
    {
        /// <summary>
        /// 获取或设置学校ID。
        /// </summary>
        public string SchoolID { get; set; }
        /// <summary>
        /// 获取或设置用户账号。
        /// </summary>
        public string UserAccount { get; set; }
        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LocalUserInfoCollection : BaseCollection<LocalUserInfo>
    {
        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public override LocalUserInfo this[string userAccount]
        {
            get
            {
                LocalUserInfo info = this.Items.Find(new Predicate<LocalUserInfo>(delegate(LocalUserInfo sender)
                {
                    return (sender != null) && (sender.UserAccount == userAccount);
                }));

                return info;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public override void Add(LocalUserInfo item)
        {
            if (item != null)
            {
                int index = this.Items.FindIndex(new Predicate<LocalUserInfo>(delegate(LocalUserInfo sender)
                {
                    return (sender != null) && (sender.UserAccount == item.UserAccount);
                }));
                if (index > -1)
                {
                    this.Items.RemoveAt(index);
                }
                base.Add(item);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(LocalUserInfo x, LocalUserInfo y)
        {
            return string.Compare(x.UserAccount, y.UserAccount);
        }
        #endregion

        #region 序列化与反序列化。
        /// <summary>
        ///序列化。
        /// </summary>
        public void Serialize()
        {
            lock (typeof(LocalUserInfoCollection))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    new BinaryFormatter().Serialize(ms, this);
                    byte[] raw = ms.ToArray();
                    using (FileStream fs = new FileStream(FolderStructure.UserCertificationFile, FileMode.Create, FileAccess.Write))
                    {
                        byte[] encrypt = Cryptography.Encrypt(raw);
                        fs.Write(encrypt, 0, encrypt.Length);
                    }
                }
            }
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <returns></returns>
        public static LocalUserInfoCollection DeSerialize()
        {
            lock (typeof(LocalUserInfoCollection))
            {
                string path = FolderStructure.UserCertificationFile;
                if (File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        if (fs.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                byte[] buf = new byte[512];
                                int len = 0;
                                while ((len = fs.Read(buf, 0, buf.Length)) > 0)
                                {
                                    ms.Write(buf, 0, len);
                                }
                                byte[] raw = ms.ToArray();
                                if (raw != null && raw.Length > 0)
                                {
                                    byte[] output = Cryptography.Decrypt(raw);
                                    if (output != null && output.Length > 0)
                                    {
                                        using (MemoryStream stream = new MemoryStream())
                                        {
                                            stream.Write(output, 0, output.Length);
                                            stream.Position = 0;
                                            return new BinaryFormatter().Deserialize(stream) as LocalUserInfoCollection;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            }
        }
        #endregion
    }
}
