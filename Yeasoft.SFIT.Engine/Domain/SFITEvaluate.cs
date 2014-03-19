//================================================================================
// FileName: SFITEvaluate.cs
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
	///tblSFITEvaluate映射类。
	///</summary>
	[DbTable("tblSFITEvaluate")]
	public class SFITEvaluate
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITEvaluate()
		{

		}
		#endregion
		#region 属性。
		///<summary>
		///获取或设置EvaluateID。
		///</summary>
		[DbField("EvaluateID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	EvaluateID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置EvaluateName。
		///</summary>
		[DbField("EvaluateName")]
		public	string	EvaluateName
		{
			get;set;

		}
			
		///<summary>
		///获取或设置EvaluateType。
		///</summary>
		[DbField("EvaluateType")]
		public	int	EvaluateType
		{
			get;set;

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
		///获取或设置MinValue。
		///</summary>
		[DbField("MinValue")]
		public	int	MinValue
		{
			get;set;

		}
			
		///<summary>
		///获取或设置MaxValue。
		///</summary>
		[DbField("MaxValue")]
		public	int	MaxValue
		{
			get;set;

		}
			
        /////<summary>
        /////获取或设置SyncStatus。
        /////</summary>
        //[DbField("SyncStatus")]
        //public	int	SyncStatus
        //{
        //    get;set;

        //}
			
        /////<summary>
        /////获取或设置LastSyncTime。
        /////</summary>
        //[DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        //public	DateTime	LastSyncTime
        //{
        //    get;set;

        //}
			
		#endregion

	}

}
