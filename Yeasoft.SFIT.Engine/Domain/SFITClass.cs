//================================================================================
// FileName: SFITClass.cs
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
	///班级映射类。
	///</summary>
	[DbTable("tblSFITClass")]
	public class SFITClass
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITClass()
		{

		}
		#endregion

		#region 属性。
		///<summary>
		///获取或设置班级ID。
		///</summary>
        [DbField("ClassID", DbFieldUsage.PrimaryKey)]
        public GUIDEx ClassID
        {
            get;
            set;
        }
		///<summary>
		///获取或设置班级代码。
		///</summary>
		[DbField("ClassCode")]
		public	string	ClassCode
		{
			get;
            set;
		}
		///<summary>
		///获取或设置班级名称。
		///</summary>
		[DbField("ClassName")]
		public	string	ClassName
		{
			get;
            set;
		}
		///<summary>
		///获取或设置排序号。
		///</summary>
		[DbField("OrderNO")]
		public	int	OrderNO
		{
			get;
            set;
		}
		///<summary>
		///获取或设置学校ID。
		///</summary>
		[DbField("SchoolID")]
		public	GUIDEx	SchoolID
		{
			get;
            set;
		}

        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        public string SchoolName
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置年级ID。
        /// </summary>
        public string GradeID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置入学年份。
        /// </summary>
        [DbField("JoinYear")]
        public int JoinYear
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置当前年级。
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
		///获取或设置SyncStatus。
		///</summary>
		[DbField("SyncStatus")]
		public	int	SyncStatus
		{
			get;set;

		}
		///<summary>
		///获取或设置LastSyncTime。
		///</summary>
		[DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
		public	DateTime	LastSyncTime
		{
			get;set;

		}
			
		#endregion

	}

}
