//================================================================================
// FileName: SFITeaReviewStudent.cs
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
	///��ʦ����ѧ����Ʒӳ���ࡣ
	///</summary>
	[DbTable("tblSFITeaReviewStudent")]
	public class SFITeaReviewStudent
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITeaReviewStudent()
		{
            this.CreateDateTime = DateTime.Now;
		}
		#endregion

		#region ���ԡ�
		///<summary>
		///��ȡ��������ƷID��
		///</summary>
        [DbField("WorkID", DbFieldUsage.PrimaryKey)]
        public GUIDEx WorkID { get; set; }
        /// <summary>
        ///��Ʒ���� 
        /// </summary>
        public string WorkName { get; set; }
 		///<summary>
		///��ȡ�����ý�ʦID��
		///</summary>
        [DbField("TeacherID")]
        public GUIDEx TeacherID { get; set; }
        /// <summary>
        /// ��ȡ�����ý�ʦ���ơ�
        /// </summary>
        [DbField("TeacharName")]
        public string TeacharName { get; set; }
		///<summary>
		///��ȡ�������������͡�
		///</summary>
        [DbField("EvaluateType")]
        public int EvaluateType { get; set; }
		///<summary>
		///��ȡ���������Ľ����
		///</summary>
        [DbField("ReviewValue")]
        public string ReviewValue { get; set; }
 		///<summary>
		///��ȡ�������������
		///</summary>
        [DbField("SubjectiveReviews")]
        public string SubjectiveReviews { get; set; }
		///<summary>
		///��ȡ�����ô�����ID��
		///</summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID { get; set; }
		///<summary>
		///��ȡ�����ô��������ơ�
		///</summary>
        [DbField("CreateEmployeeName")]
        public string CreateEmployeeName { get; set; }
		///<summary>
		///��ȡ�����ô���ʱ�䡣
		///</summary>
        [DbField("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }
		#endregion
	}
}