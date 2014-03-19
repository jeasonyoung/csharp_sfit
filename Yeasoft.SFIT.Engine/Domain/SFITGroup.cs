//================================================================================
// FileName: SFITGroup.cs
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
	///tblSFITGroupӳ���ࡣ
	///</summary>
	[DbTable("tblSFITGroup")]
	public class SFITGroup
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITGroup()
		{

		}
		#endregion

		#region ���ԡ�
		///<summary>
		///��ȡ������GroupID��
		///</summary>
		[DbField("GroupID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	GroupID
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������GroupName��
		///</summary>
		[DbField("GroupName")]
		public	string	GroupName
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������GroupType��
		///</summary>
		[DbField("GroupType")]
		public	int	GroupType
		{
			get;set;

		}
			
		///<summary>
		///��ȡ������UnitID��
		///</summary>
		[DbField("UnitID")]
		public	GUIDEx	UnitID
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
		///��ȡ������Description��
		///</summary>
		[DbField("Description")]
		public	string	Description
		{
			get;set;

		}
        /// <summary>
        /// 
        /// </summary>
        [DbField("LastModifyEmployeeID")]
        public GUIDEx LastModifyEmployeeID
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DbField("LastModifyEmployeeName")]
        public string LastModifyEmployeeName
        {
            get;
            set;
        }
        /// <summary>
        /// 
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
