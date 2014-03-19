//================================================================================
// FileName: SFITEvaluateItems.cs
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
	///tblSFITEvaluateItems映射类。
	///</summary>
	[DbTable("tblSFITEvaluateItems")]
	public class SFITEvaluateItems
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITEvaluateItems()
		{

		}
		#endregion
		#region 属性。
		///<summary>
		///获取或设置ItemID。
		///</summary>
		[DbField("ItemID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	ItemID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置ItemName。
		///</summary>
		[DbField("ItemName")]
		public	string	ItemName
		{
			get;set;

		}
			
		///<summary>
		///获取或设置ItemValue。
		///</summary>
		[DbField("ItemValue")]
		public	string	ItemValue
		{
			get;set;

		}
			
		///<summary>
		///获取或设置EvaluateID。
		///</summary>
		[DbField("EvaluateID")]
		public	GUIDEx	EvaluateID
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
