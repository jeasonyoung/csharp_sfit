//================================================================================
// FileName: SFITStudents.cs
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
	///ѧ����Ϣӳ���ࡣ
	///</summary>
	[DbTable("tblSFITStudents")]
	public class SFITStudents
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITStudents()
		{

		}
		#endregion

		#region ���ԡ�
        /// <summary>
        /// ��ȡ������ѧУID��
        /// </summary>
        public GUIDEx SchoolID
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
        public GUIDEx GradeID
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�����ð༶ID��
        /// </summary>
        public GUIDEx ClassID
        {
            get;
            set;
        }
		///<summary>
		///��ȡ������ѧ��ID��
		///</summary>
        [DbField("StudentID", DbFieldUsage.PrimaryKey)]
        public GUIDEx StudentID
        {
            get;
            set;
        }
 		///<summary>
		///��ȡ������ѧ��ѧ�š�
		///</summary>
        [DbField("StudentCode")]
        public string StudentCode
        {
            get;
            set;
        }
 		///<summary>
		///��ȡ������������
		///</summary>
        [DbField("StudentName")]
        public string StudentName
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�������Ա�
        /// </summary>
        [DbField("Gender")]
        public int Gender
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
        /// ��ȡ���������֤�š�
        /// </summary>
        [DbField("IDNumber")]
        public string IDNumber
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
			get;
            set;
 		}
 		///<summary>
		///��ȡ������LastSyncTime��
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
