//================================================================================
// FileName: SFITGrade.cs
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
	///�꼶ӳ���ࡣ
	///</summary>
	[DbTable("tblSFITGrade")]
	public class SFITGrade
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITGrade()
		{

		}
		#endregion

		#region ���ԡ�
		///<summary>
		///��ȡ�������꼶ID��
		///</summary>
		[DbField("GradeID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	GradeID
		{
			get;
            set;
		}
		///<summary>
		///��ȡ�������꼶���롣
		///</summary>
		[DbField("GradeCode")]
		public	string	GradeCode
		{
			get;
            set;
		}
		///<summary>
		///��ȡ�������꼶���ơ�
		///</summary>
		[DbField("GradeName")]
		public	string	GradeName
		{
			get;
            set;
		}
        /// <summary>
        /// ��ȡ�������꼶ֵ��
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
		///��ȡ������OrderNO��
		///</summary>
		[DbField("OrderNO")]
		public	int	OrderNO
		{
			get;
            set;
		}			
		#endregion

	}

}
