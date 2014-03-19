//================================================================================
// FileName: SFITCatalog.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Text;
	
using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.SFIT.Engine.Domain
{
	///<summary>
	///课程目录映射类。
	///</summary>
    [DbTable("tblSFITCatalog")]
    public class SFITCatalog
    {
        #region 成员变量，构造函数。
        ///<summary>
        ///构造函数。
        ///</summary>
        public SFITCatalog()
        {

        }
        #endregion

        #region 属性。
        ///<summary>
        ///获取或设置学校ID。
        ///</summary>
        [DbField("SchoolID")]
        public GUIDEx SchoolID
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        public string SchoolName
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置GradeID。
        ///</summary>
        [DbField("GradeID")]
        public GUIDEx GradeID
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置目录ID。
        ///</summary>
        [DbField("CatalogID", DbFieldUsage.PrimaryKey)]
        public GUIDEx CatalogID
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置目录代码。
        ///</summary>
        [DbField("CatalogCode")]
        public string CatalogCode
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置目录名称。
        ///</summary>
        [DbField("CatalogName")]
        public string CatalogName
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置目录类型。
        ///</summary>
        [DbField("CatalogType")]
        public int CatalogType
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置排序。
        ///</summary>
        [DbField("OrderNO")]
        public int OrderNO
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置创建用户ID
        /// </summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置创建用户名称。
        /// </summary>
        [DbField("CreateEmployeeName")]
        public string CreateEmployeeName
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置创建时间。
        /// </summary>
        [DbField("LastModifyTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime LastModifyTime
        {
            get;
            set;
        }
        #endregion
    }
}
