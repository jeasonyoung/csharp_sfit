//================================================================================
// FileName: SFITWorksComments.cs
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
	///tblSFITWorksComments映射类。
	///</summary>
	[DbTable("tblSFITWorksComments")]
	public class SFITWorksComments
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITWorksComments()
		{

		}
		#endregion
		#region 属性。
		///<summary>
		///获取或设置CommentID。
		///</summary>
		[DbField("CommentID",DbFieldUsage.PrimaryKey)]
		public	GUIDEx	CommentID
		{
			get;set;

		}
			
		///<summary>
		///获取或设置WorkID。
		///</summary>
		[DbField("WorkID")]
		public	GUIDEx	WorkID
		{
			get;set;

		}
        /// <summary>
        /// 获取或设置作品名称。
        /// </summary>
        public string WorkName { get; set; }
        /// <summary>
        /// 获取或设置学生信息。
        /// </summary>
        public string StudentInfo { get; set; }
		///<summary>
		///获取或设置Status。
		///</summary>
		[DbField("Status")]
		public	int	Status
		{
			get;set;

		}
			
		///<summary>
		///获取或设置Comment。
		///</summary>
		[DbField("Comment")]
		public	string	Comment
		{
			get;set;

		}

        [DbField("UserName")]
        public string UserName { get; set; }
			
		///<summary>
		///获取或设置ClientIP。
		///</summary>
		[DbField("ClientIP")]
		public	string	ClientIP
		{
			get;set;

		}
			
		///<summary>
		///获取或设置CreateDateTime。
		///</summary>
		[DbField("CreateDateTime", DbFieldUsage.EmptyOrNullNotUpdate)]
		public	DateTime	CreateDateTime
		{
			get;set;

		}
			
		#endregion

	}

}
