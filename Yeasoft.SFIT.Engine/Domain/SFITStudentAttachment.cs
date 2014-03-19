//================================================================================
// FileName: SFITStudentAttachment.cs
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
	///tblSFITStudentAttachment映射类。
	///</summary>
	[DbTable("tblSFITStudentAttachment")]
	public class SFITStudentAttachment
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public SFITStudentAttachment()
        {
            this.CreateDateTime = DateTime.Now;
        }
        #endregion

        #region 属性。
        ///<summary>
		///获取或设置WorkID。
		///</summary>
        [DbField("WorkID", DbFieldUsage.PrimaryKey)]
        public GUIDEx WorkID { get; set; }
		///<summary>
		///获取或设置AccessoriesID。
		///</summary>
        [DbField("AccessoriesID", DbFieldUsage.PrimaryKey)]
        public GUIDEx AccessoriesID { get; set; }
		///<summary>
		///获取或设置CreateEmployeeID。
		///</summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID { get; set; }
		///<summary>
		///获取或设置CreateEmployeeName。
		///</summary>
        [DbField("CreateEmployeeName")]
        public string CreateEmployeeName { get; set; }
		///<summary>
		///获取或设置CreateDateTime。
		///</summary>
        [DbField("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }
		#endregion
	}
}