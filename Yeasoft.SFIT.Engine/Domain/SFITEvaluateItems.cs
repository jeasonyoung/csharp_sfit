//================================================================================
// FileName: SFITEvaluateItems.cs
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
	///tblSFITEvaluateItemsӳ���ࡣ
	///</summary>
	[DbTable("tblSFITEvaluateItems")]
	public class SFITEvaluateItems
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITEvaluateItems()
		{

		}
		#endregion
		#region ���ԡ�
		///<summary>
		///��ȡ������ItemID��
		///</summary>
		[DbField("ItemID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	ItemID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������ItemName��
		///</summary>
		[DbField("ItemName")]
		public	string	ItemName
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������ItemValue��
		///</summary>
		[DbField("ItemValue")]
		public	string	ItemValue
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������EvaluateID��
		///</summary>
		[DbField("EvaluateID")]
		public	GUIDEx	EvaluateID
		{
			get;set;

		}
			
        /////<summary>
        /////��ȡ������SyncStatus��
        /////</summary>
        //[DbField("SyncStatus")]
        //public	int	SyncStatus
        //{
        //    get;set;

        //}
			
        /////<summary>
        /////��ȡ������LastSyncTime��
        /////</summary>
        //[DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        //public	DateTime	LastSyncTime
        //{
        //    get;set;

        //}
			
		#endregion

	}

}
