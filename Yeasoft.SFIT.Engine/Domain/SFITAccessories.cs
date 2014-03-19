//================================================================================
// FileName: SFITAccessories.cs
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
	///tblSFITAccessories映射类。
	///</summary>
	[DbTable("tblSFITAccessories")]
	public class SFITAccessories
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public SFITAccessories()
        {
            this.LastModify = DateTime.Now;
        }
        #endregion

        #region 属性。
        ///<summary>
		///获取或设置AccessoriesID。
		///</summary>
        [DbField("AccessoriesID", DbFieldUsage.PrimaryKey)]
        public GUIDEx AccessoriesID { get; set; }
		///<summary>
		///获取或设置AccessoriesName。
		///</summary>
        [DbField("AccessoriesName")]
        public string AccessoriesName { get; set; }
		///<summary>
		///获取或设置ContentType。
		///</summary>
        [DbField("ContentType")]
        public string ContentType { get; set; }
		///<summary>
		///获取或设置AccessoriesSize。
		///</summary>
        [DbField("AccessoriesSize")]
        public float AccessoriesSize { get; set; }
		///<summary>
		///获取或设置Suffix。
		///</summary>
        [DbField("Suffix")]
        public string Suffix { get; set; }
		///<summary>
		///获取或设置CheckCode。
		///</summary>
        [DbField("CheckCode")]
        public string CheckCode { get; set; }
		///<summary>
		///获取或设置LastModify。
		///</summary>
        [DbField("LastModify")]
        public DateTime LastModify { get; set; }
		#endregion
	}
}