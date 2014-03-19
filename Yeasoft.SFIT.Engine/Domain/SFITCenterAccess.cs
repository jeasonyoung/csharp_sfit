//================================================================================
// FileName: SFITCenterAccess.cs
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
	///�������ӳ���ࡣ
	///</summary>
	[DbTable("tblSFITCenterAccess")]
	public class SFITCenterAccess
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITCenterAccess()
		{

		}
		#endregion

		#region ���ԡ�
		///<summary>
		///��ȡ�����ý���ID��
		///</summary>
		[DbField("AccessID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	AccessID
		{
			get;
            set;
		}
		///<summary>
		///��ȡ�����ý����˺š�
		///</summary>
		[DbField("AccessAccount")]
		public	string	AccessAccount
		{
			get;
            set;
		}
		///<summary>
		///��ȡ�����ý������롣
		///</summary>
		[DbField("AccessPassword")]
		public	string	AccessPassword
		{
			get;
            set;
		}
		///<summary>
		///��ȡ�����ý���ѧУ��
		///</summary>
		[DbField("SchoolID")]
		public	GUIDEx	SchoolID
		{
			get;
            set;
		}
		///<summary>
		///��ȡ�����ý���ѧУ���ơ�
		///</summary>
		[DbField("SchoolName")]
		public	string	SchoolName
		{
			get;
            set;
		}
        /// <summary>
        /// ��ȡ�����ý���״̬��
        /// </summary>
        [DbField("AccessStatus")]
        public int AccessStatus
        {
            get;
            set;
        }
		///<summary>
		///��ȡ�����ý���������
		///</summary>
		[DbField("Description")]
		public	string	Description
		{
			get;
            set;
		}
        /// <summary>
        /// ��ȡ�����ô�����ID��
        /// </summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�����ô��������ơ�
        /// </summary>
        [DbField("CreateEmployeeName")]
        public string CreateEmployeeName
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�����ô���ʱ�䡣
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
