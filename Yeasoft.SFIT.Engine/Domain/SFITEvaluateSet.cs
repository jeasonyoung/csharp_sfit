//================================================================================
// FileName: SFITEvaluateSet.cs
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
    ///�͹���������ӳ���ࡣ
	///</summary>
	[DbTable("tblSFITEvaluateSet")]
	public class SFITEvaluateSet
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITEvaluateSet()
		{

		}
		#endregion

		#region ���ԡ�
		///<summary>
		///��ȡ�����ÿ͹�����ID��
		///</summary>
		[DbField("EvaluateID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	EvaluateID
		{
			get;
            set;
		}
		///<summary>
		///��ȡ�����������꼶ID��
		///</summary>
		[DbField("GradeID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	GradeID
		{
			get;
            set;
		}
        /// <summary>
        /// ��ȡ����������ʱ�䡣
        /// </summary>
        [DbField("ModifyTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime ModifyTime
        {
            get;
            set;
        }
		#endregion
	}

}
