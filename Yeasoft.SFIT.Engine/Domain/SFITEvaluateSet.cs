//================================================================================
// FileName: SFITEvaluateSet.cs
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
    ///客观评价设置映射类。
	///</summary>
	[DbTable("tblSFITEvaluateSet")]
	public class SFITEvaluateSet
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITEvaluateSet()
		{

		}
		#endregion

		#region 属性。
		///<summary>
		///获取或设置客观评价ID。
		///</summary>
		[DbField("EvaluateID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	EvaluateID
		{
			get;
            set;
		}
		///<summary>
		///获取或设置所属年级ID。
		///</summary>
		[DbField("GradeID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	GradeID
		{
			get;
            set;
		}
        /// <summary>
        /// 获取或设置设置时间。
        /// </summary>
        [DbField("ModifyTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime ModifyTime
        {
            get;
            set;
        }
		#endregion
	}

}
