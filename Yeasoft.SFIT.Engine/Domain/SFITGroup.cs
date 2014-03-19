//================================================================================
// FileName: SFITGroup.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
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
	///tblSFITGroup映射类。
	///</summary>
	[DbTable("tblSFITGroup")]
	public class SFITGroup
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITGroup()
		{

		}
		#endregion

		#region 属性。
		///<summary>
		///获取或设置GroupID。
		///</summary>
		[DbField("GroupID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	GroupID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置GroupName。
		///</summary>
		[DbField("GroupName")]
		public	string	GroupName
		{
			get;set;

		}
			
		///<summary>
		///获取或设置GroupType。
		///</summary>
		[DbField("GroupType")]
		public	int	GroupType
		{
			get;set;

		}
			
		///<summary>
		///获取或设置UnitID。
		///</summary>
		[DbField("UnitID")]
		public	GUIDEx	UnitID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置OrderNO。
		///</summary>
		[DbField("OrderNO")]
		public	int	OrderNO
		{
			get;set;

		}
			
		///<summary>
		///获取或设置Description。
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
