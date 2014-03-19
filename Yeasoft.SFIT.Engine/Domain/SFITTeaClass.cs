//================================================================================
// FileName: SFITTeaClass.cs
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
	///教师任课班级映射类。
	///</summary>
	[DbTable("tblSFITTeaClass")]
	public class SFITTeaClass
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITTeaClass()
		{

		}
		#endregion

		#region 属性。
		///<summary>
		///获取或设置任课教师ID。
		///</summary>
        [DbField("TeacherID", DbFieldUsage.PrimaryKey)]
        public GUIDEx TeacherID
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherName { get; set; }
		///<summary>
		///获取或设置班级ID。
		///</summary>
        [DbField("ClassID", DbFieldUsage.PrimaryKey)]
        public GUIDEx ClassID
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置创建者ID。
        /// </summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置创建者名称。
        /// </summary>
        [DbField("CreateEmployeeName")]
        public string CreateEmployeeName
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置最后修改时间。
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
