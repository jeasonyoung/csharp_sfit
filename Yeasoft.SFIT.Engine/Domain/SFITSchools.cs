//================================================================================
// FileName: SFITSchools.cs
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
	///tblSFITSchools映射类。
	///</summary>
	[DbTable("tblSFITSchools")]
	public class SFITSchools
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITSchools()
		{

		}
		#endregion

		#region 属性。
		///<summary>
		///获取或设置SchoolID。
		///</summary>
		[DbField("SchoolID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	SchoolID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置SchoolCode。
		///</summary>
		[DbField("SchoolCode")]
		public	string	SchoolCode
		{
			get;set;

		}
			
		///<summary>
		///获取或设置SchoolName。
		///</summary>
		[DbField("SchoolName")]
		public	string	SchoolName
		{
			get;set;

		}

        /// <summary>
        /// 
        /// </summary>
        [DbField("SchoolType")]
        public int SchoolType
        {
            get;
            set;
        }
			
		///<summary>
		///获取或设置OrderNO。
		///</summary>
		[DbField("OrderNO")]
		public	int	OrderNO
		{
			get;set;

		}
			
		///<summary>
		///获取或设置SyncStatus。
		///</summary>
		[DbField("SyncStatus")]
		public	int	SyncStatus
		{
			get;set;

		}
			
		///<summary>
		///获取或设置LastSyncTime。
		///</summary>
		[DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
		public	DateTime	LastSyncTime
		{
			get;set;

		}
			
		#endregion
	}

}
