//================================================================================
// FileName: SFITTeaClass.cs
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
	///��ʦ�οΰ༶ӳ���ࡣ
	///</summary>
	[DbTable("tblSFITTeaClass")]
	public class SFITTeaClass
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITTeaClass()
		{

		}
		#endregion

		#region ���ԡ�
		///<summary>
		///��ȡ�������ον�ʦID��
		///</summary>
        [DbField("TeacherID", DbFieldUsage.PrimaryKey)]
        public GUIDEx TeacherID
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherName { get; set; }
		///<summary>
		///��ȡ�����ð༶ID��
		///</summary>
        [DbField("ClassID", DbFieldUsage.PrimaryKey)]
        public GUIDEx ClassID
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
        /// ��ȡ����������޸�ʱ�䡣
        /// </summary>
        [DbField("LastModifyTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime LastModifyTime
        {
            get;
            set;
        }
		#endregion

	}

}
