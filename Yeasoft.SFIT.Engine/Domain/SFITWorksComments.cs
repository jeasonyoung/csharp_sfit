//================================================================================
// FileName: SFITWorksComments.cs
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
	///tblSFITWorksCommentsӳ���ࡣ
	///</summary>
	[DbTable("tblSFITWorksComments")]
	public class SFITWorksComments
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITWorksComments()
		{

		}
		#endregion
		#region ���ԡ�
		///<summary>
		///��ȡ������CommentID��
		///</summary>
		[DbField("CommentID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	CommentID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������WorkID��
		///</summary>
		[DbField("WorkID")]
		public	GUIDEx	WorkID
		{
			get;set;

		}
        /// <summary>
        /// ��ȡ��������Ʒ���ơ�
        /// </summary>
        public string WorkName { get; set; }
        /// <summary>
        /// ��ȡ������ѧ����Ϣ��
        /// </summary>
        public string StudentInfo { get; set; }
		///<summary>
		///��ȡ������Status��
		///</summary>
		[DbField("Status")]
		public	int	Status
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������Comment��
		///</summary>
		[DbField("Comment")]
		public	string	Comment
		{
			get;set;

		}

        [DbField("UserName")]
        public string UserName { get; set; }
			
		///<summary>
		///��ȡ������ClientIP��
		///</summary>
		[DbField("ClientIP")]
		public	string	ClientIP
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������CreateDateTime��
		///</summary>
		[DbField("CreateDateTime", DbFieldUsage.EmptyOrNullNotUpdate)]
		public	DateTime	CreateDateTime
		{
			get;set;

		}
			
		#endregion

	}

}
