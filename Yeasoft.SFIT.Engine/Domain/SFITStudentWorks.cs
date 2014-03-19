//================================================================================
// FileName: SFITStudentWorks.cs
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
    ///学生作品映射类。
    ///</summary>
    [DbTable("tblSFITStudentWorks")]
    public class SFITStudentWorks
    {
        #region 成员变量，构造函数。
        ///<summary>
        ///构造函数。
        ///</summary>
        public SFITStudentWorks()
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
        ///<summary>
        ///获取或设置作品名称。
        ///</summary>
        [DbField("WorkName")]
        public string WorkName { get; set; }
        ///<summary>
        ///获取或设置作品状态。
        ///</summary>
        [DbField("WorkStatus")]
        public int WorkStatus { get; set; }
        ///<summary>
        ///获取或设置作品状态。
        ///</summary>
        [DbField("WorkType")]
        public int WorkType { get; set; }
        ///<summary>
        ///获取或设置校验码。
        ///</summary>
        [DbField("CheckCode")]
        public string CheckCode { get; set; }
        ///<summary>
        ///获取或设置学校ID。
        ///</summary>
        [DbField("SchoolID")]
        public GUIDEx SchoolID { get; set; }
        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        [DbField("SchoolName")]
        public string SchoolName { get; set; }
        ///<summary>
        ///获取或设置年级ID。
        ///</summary>
        [DbField("GradeID")]
        public GUIDEx GradeID { get; set; }
        /// <summary>
        /// 获取或设置年级名称。
        /// </summary>
        [DbField("GradeName")]
        public string GradeName { get; set; }
        ///<summary>
        ///获取或设置班级ID。
        ///</summary>
        [DbField("ClassID")]
        public GUIDEx ClassID { get; set; }
        /// <summary>
        ///获取或设置班级名称。
        /// </summary>
        [DbField("ClassName")]
        public string ClassName { get; set; }
        ///<summary>
        ///获取或设置学生ID。
        ///</summary>
        [DbField("StudentID")]
        public GUIDEx StudentID { get; set; }
        /// <summary>
        /// 获取或设置学生代码。
        /// </summary>
        public string StudentCode { get;set; }
        /// <summary>
        /// 获取或设置学生名称。
        /// </summary>
        public string StudentName { get; set; }
        ///<summary>
        ///获取或设置目录ID。
        ///</summary>
        [DbField("CatalogID")]
        public GUIDEx CatalogID { get; set; }
        /// <summary>
        /// 获取或设置目录名称。
        /// </summary>
        [DbField("CatalogName")]
        public string CatalogName { get; set; }
        ///<summary>
        ///获取或设置创建用户ID。
        ///</summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID { get; set; }
        ///<summary>
        ///获取或设置创建用户名称。
        ///</summary>
        [DbField("CreateEmployeeName")]
        public string CreateEmployeeName { get; set; }
        ///<summary>
        ///获取或设置创建时间。
        ///</summary>
        [DbField("CreateDateTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime CreateDateTime { get; set; }
        ///<summary>
        ///获取或设置作品描述。
        ///</summary>
        [DbField("WorkDescription")]
        public string WorkDescription { get; set; }
        /// <summary>
        /// 获取或设置点击量。
        /// </summary>
        [DbField("Hits")]
        public int Hits { get; set; }
        #endregion
    }
}