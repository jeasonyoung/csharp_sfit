//================================================================================
//  FileName: ExportImportManifest.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/16
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
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    ///作品导出导入数据列表清单。
    /// </summary>
    [Serializable]
    public class ExportImportManifest
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ExportImportManifest()
        {
            this.Ver = "2.0";
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="ver"></param>
        /// <param name="storages"></param>
        public ExportImportManifest(string ver)
            : this()
        {
            this.Ver = ver; 
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置版本信息。
        /// </summary>
        public string Ver { get; set; }
        /// <summary>
        /// 获取或设置教师ID。
        /// </summary>
        public string TeacherID { get; set; }
        /// <summary>
        /// 获取或设置班级目录数组。
        /// </summary>
        public string[] ClassID_CatalogID { get; set; }
        /// <summary>
        /// 获取或设置描述信息。
        /// </summary>
        public string Description { get; set; }
        #endregion

        #region 序列化与反序列化。
        /// <summary>
        /// 序列化。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Serializer(ExportImportManifest data)
        {
            return UtilTools.Serializer<ExportImportManifest>(data);
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static ExportImportManifest DeSerializer(byte[] data)
        {
            return UtilTools.DeSerializer<ExportImportManifest>(data);
        }
        #endregion
    }
}
