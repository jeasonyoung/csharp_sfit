//================================================================================
// FileName: SFITGrade.cs
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
	///年级映射类。
	///</summary>
	[DbTable("tblSFITGrade")]
	public class SFITGrade
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITGrade()
		{

		}
		#endregion

		#region 属性。
		///<summary>
		///获取或设置年级ID。
		///</summary>
		[DbField("GradeID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	GradeID
		{
			get;
            set;
		}
		///<summary>
		///获取或设置年级代码。
		///</summary>
		[DbField("GradeCode")]
		public	string	GradeCode
		{
			get;
            set;
		}
		///<summary>
		///获取或设置年级名称。
		///</summary>
		[DbField("GradeName")]
		public	string	GradeName
		{
			get;
            set;
		}
        /// <summary>
        /// 获取或设置年级值。
        /// </summary>
        [DbField("GradeValue")]
        public int GradeValue
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置学习阶段。
        /// </summary>
        [DbField("LearnLevel")]
        public int LearnLevel
        {
            get;
            set;
        }
		///<summary>
		///获取或设置OrderNO。
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
