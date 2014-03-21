//================================================================================
//  FileName: ModuleConfiguration.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/5
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using iPower;
using iPower.Utility;
using iPower.FileStorage;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Persistence
{
    /// <summary>
    ///  模块配置键。
    /// </summary>
    public class ModuleConfigurationKeys : BaseModuleConfigurationKeys
    {
        /// <summary>
        /// 用户认证程序集。
        /// </summary>
        public const string UserAuthenticationAssemblyKey = "SFIT.UserAuthenticationAssembly";
        /// <summary>
        /// 任课教师用户角色ID。
        /// </summary>
        public const string TeaClassRoleIDKey = "SFIT.TeaClassRoleID";
        /// <summary>
        /// 作业附件存储位置。
        /// </summary>
        public const string WorkStorageLocationKey = "SFIT.WorkStorageLocation";
        /// <summary>
        /// 作业缩略图缓存位置。
        /// </summary>
        public const string WorkTempImageCacheKey = "SFIT.WorkTempImageCache";
        /// <summary>
        /// 作业缩略图默认文件名。
        /// </summary>
        public const string WorkTempDefaultImagePathKey = "SFIT.WorkTempDefaultImagePath";
    }

    /// <summary>
    /// 模块配置类。
    /// </summary>
    public class ModuleConfiguration : BaseModuleConfiguration, IStorageConfig
    {
        #region 成员变量，构造函数。
        private static Hashtable cache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ModuleConfiguration()
            : base("SFIT")
        {

        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取用户认证程接口序集对象。
        /// </summary>
        public IUserAuthentication UserAuthentication
        {
            get
            {
                string key = ModuleConfigurationKeys.UserAuthenticationAssemblyKey;
                IUserAuthentication obj = cache[key] as IUserAuthentication;
                if (obj == null)
                {
                    string assembly = this[key];
                    if (string.IsNullOrEmpty(assembly))
                        throw new Exception("未配置用户认证接口程序集。");
                    obj = TypeHelper.Create(assembly) as IUserAuthentication;
                    if (obj == null)
                        throw new Exception("程序集没有继承用户认证接口。");
                    cache[key] = obj;
                }
                return obj;
            }
        }
        /// <summary>
        /// 获取上传文件存储对象。
        /// </summary>
        public IFileStorageFactory FileStorageFactory
        {
            get
            {
                return FileStorageFactoryInstance.Instance;
            }
        }
        /// <summary>
        /// 获取任课教师用户角色ID。
        /// </summary>
        public GUIDEx TeaClassRoleID
        {
            get { return this[ModuleConfigurationKeys.TeaClassRoleIDKey]; }
        }
        /// <summary>
        /// 获取作业缩略图缓存根目录。
        /// </summary>
        public string WorkTempImageCache
        {
            get
            {
                string root = this[ModuleConfigurationKeys.WorkTempImageCacheKey];
                if (string.IsNullOrEmpty(root))
                {
                    throw new ArgumentNullException("作业缩略图缓位置路径未配置(" + ModuleConfigurationKeys.WorkTempImageCacheKey + ")！");
                }
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                return root;
            }
        }
        /// <summary>
        /// 获取作业缩略图默认路径。
        /// </summary>
        public string WorkTempDefaultImagePath
        {
            get
            {
                string path = this[ModuleConfigurationKeys.WorkTempDefaultImagePathKey];
                if (string.IsNullOrEmpty(path))
                {
                    throw new ArgumentNullException("作业缩略图默认路径未配置(" + ModuleConfigurationKeys.WorkTempDefaultImagePathKey + ")！");
                }

                if (!File.Exists(path))
                {
                    path = Path.GetFullPath(string.Format("{0}/{1}", AppDomain.CurrentDomain.BaseDirectory, path));
                }

                if (!File.Exists(path))
                {
                    throw new ArgumentNullException("作业缩略图默认路径不存在(" + path + ")！");
                }
                return path;
            }
        }
        #endregion
        
        #region IStorageConfig 成员
        /// <summary>
        /// 获取作业存储目录位置路径。
        /// </summary>
        public string StorageSource
        {
            get
            {
                lock (this)
                {
                    string dir = this[ModuleConfigurationKeys.WorkStorageLocationKey];
                    if (string.IsNullOrEmpty(dir))
                    {
                        throw new ArgumentNullException("作业存储目录位置路径未配置(" + ModuleConfigurationKeys.WorkStorageLocationKey + ")！");
                    }
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    return dir;
                }
            }
        }

        #endregion
    }
}