//================================================================================
// FileName: SFITClassStudents.cs
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
	///�༶ѧ��ӳ���ࡣ
	///</summary>
	[DbTable("tblSFITClassStudents")]
	public class SFITClassStudents
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITClassStudents()
		{

		}
		#endregion

		#region ���ԡ�
        ///<summary>
        ///��ȡ�����ð༶ID��
        ///</summary>
        [DbField("ClassID", DbFieldUsage.PrimaryKey)]
        public GUIDEx ClassID
        {
            get;
            set;
        }
		///<summary>
		///��ȡ������ѧ��ID��
		///</summary>
		[DbField("StudentID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	StudentID
		{
			get;
            set;
		}
        ///<summary>
        ///��ȡ������ͬ��ʱ�䡣
        ///</summary>
        [DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime LastSyncTime
        {
            get;
            set;
        }
		#endregion

	}

}
