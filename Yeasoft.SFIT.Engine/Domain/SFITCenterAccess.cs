//================================================================================
// FileName: SFITCenterAccess.cs
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
	///接入管理映射类。
	///</summary>
	[DbTable("tblSFITCenterAccess")]
	public class SFITCenterAccess
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITCenterAccess()
		{

		}
		#endregion

		#region 属性。
		///<summary>
		///获取或设置接入ID。
		///</summary>
		[DbField("AccessID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	AccessID
		{
			get;
            set;
		}
		///<summary>
		///获取或设置接入账号。
		///</summary>
		[DbField("AccessAccount")]
		public	string	AccessAccount
		{
			get;
            set;
		}
		///<summary>
		///获取或设置接入密码。
		///</summary>
		[DbField("AccessPassword")]
		public	string	AccessPassword
		{
			get;
            set;
		}
		///<summary>
		///获取或设置接入学校。
		///</summary>
		[DbField("SchoolID")]
		public	GUIDEx	SchoolID
		{
			get;
            set;
		}
		///<summary>
		///获取或设置接入学校名称。
		///</summary>
		[DbField("SchoolName")]
		public	string	SchoolName
		{
			get;
            set;
		}
        /// <summary>
        /// 获取或设置接入状态。
        /// </summary>
        [DbField("AccessStatus")]
        public int AccessStatus
        {
            get;
            set;
        }
		///<summary>
		///获取或设置接入描述。
		///</summary>
		[DbField("Description")]
		public	string	Description
		{
			get;
            set;
		}
        /// <summary>
        /// 获取或设置创建者ID。
        /// </summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置创建者名称。
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
        [DbField("CreateDateTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime CreateDateTime
        {
            get;
            set;
        }
		#endregion
	}

}
