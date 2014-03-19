//================================================================================
// FileName: SFITEvaluate.cs
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
	///tblSFITEvaluateӳ���ࡣ
	///</summary>
	[DbTable("tblSFITEvaluate")]
	public class SFITEvaluate
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITEvaluate()
		{

		}
		#endregion
		#region ���ԡ�
		///<summary>
		///��ȡ������EvaluateID��
		///</summary>
		[DbField("EvaluateID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	EvaluateID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������EvaluateName��
		///</summary>
		[DbField("EvaluateName")]
		public	string	EvaluateName
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������EvaluateType��
		///</summary>
		[DbField("EvaluateType")]
		public	int	EvaluateType
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������OrderNO��
		///</summary>
		[DbField("OrderNO")]
		public	int	OrderNO
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������MinValue��
		///</summary>
		[DbField("MinValue")]
		public	int	MinValue
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������MaxValue��
		///</summary>
		[DbField("MaxValue")]
		public	int	MaxValue
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
