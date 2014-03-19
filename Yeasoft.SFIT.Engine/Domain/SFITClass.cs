//================================================================================
// FileName: SFITClass.cs
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
	///�༶ӳ���ࡣ
	///</summary>
	[DbTable("tblSFITClass")]
	public class SFITClass
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITClass()
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
		///��ȡ�����ð༶���롣
		///</summary>
		[DbField("ClassCode")]
		public	string	ClassCode
		{
			get;
            set;
		}
		///<summary>
		///��ȡ�����ð༶���ơ�
		///</summary>
		[DbField("ClassName")]
		public	string	ClassName
		{
			get;
            set;
		}
		///<summary>
		///��ȡ����������š�
		///</summary>
		[DbField("OrderNO")]
		public	int	OrderNO
		{
			get;
            set;
		}
		///<summary>
		///��ȡ������ѧУID��
		///</summary>
		[DbField("SchoolID")]
		public	GUIDEx	SchoolID
		{
			get;
            set;
		}

        /// <summary>
        /// ��ȡ������ѧУ���ơ�
        /// </summary>
        public string SchoolName
        {
            get;
            set;
        }

        /// <summary>
        /// ��ȡ�������꼶ID��
        /// </summary>
        public string GradeID
        {
            get;
            set;
        }

        /// <summary>
        /// ��ȡ��������ѧ��ݡ�
        /// </summary>
        [DbField("JoinYear")]
        public int JoinYear
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�����õ�ǰ�꼶��
        /// </summary>
        [DbField("GradeValue")]
        public int GradeValue
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ������ѧϰ�׶Ρ�
        /// </summary>
        [DbField("LearnLevel")]
        public int LearnLevel
        {
            get;
            set;
        }	
		///<summary>
		///��ȡ������SyncStatus��
		///</summary>
		[DbField("SyncStatus")]
		public	int	SyncStatus
		{
			get;set;

		}
		///<summary>
		///��ȡ������LastSyncTime��
		///</summary>
		[DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
		public	DateTime	LastSyncTime
		{
			get;set;

		}
			
		#endregion

	}

}
