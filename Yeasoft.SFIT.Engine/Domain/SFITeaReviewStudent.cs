//================================================================================
// FileName: SFITeaReviewStudent.cs
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
	///教师评价学生作品映射类。
	///</summary>
	[DbTable("tblSFITeaReviewStudent")]
	public class SFITeaReviewStudent
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITeaReviewStudent()
		{
            this.CreateDateTime = DateTime.Now;
		}
		#endregion

		#region 属性。
		///<summary>
		///获取或设置作品ID。
		///</summary>
        [DbField("WorkID", DbFieldUsage.PrimaryKey)]
        public GUIDEx WorkID { get; set; }
        /// <summary>
        ///作品名称 
        /// </summary>
        public string WorkName { get; set; }
 		///<summary>
		///获取或设置教师ID。
		///</summary>
        [DbField("TeacherID")]
        public GUIDEx TeacherID { get; set; }
        /// <summary>
        /// 获取或设置教师名称。
        /// </summary>
        [DbField("TeacharName")]
        public string TeacharName { get; set; }
		///<summary>
		///获取或设置评阅类型。
		///</summary>
        [DbField("EvaluateType")]
        public int EvaluateType { get; set; }
		///<summary>
		///获取或设置评阅结果。
		///</summary>
        [DbField("ReviewValue")]
        public string ReviewValue { get; set; }
 		///<summary>
		///获取或设置主观评语。
		///</summary>
        [DbField("SubjectiveReviews")]
        public string SubjectiveReviews { get; set; }
		///<summary>
		///获取或设置创建者ID。
		///</summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID { get; set; }
		///<summary>
		///获取或设置创建者名称。
		///</summary>
        [DbField("CreateEmployeeName")]
        public string CreateEmployeeName { get; set; }
		///<summary>
		///获取或设置创建时间。
		///</summary>
        [DbField("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }
		#endregion
	}
}