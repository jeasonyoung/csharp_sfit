//================================================================================
//  FileName: StudentWork.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/26
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Text;
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 学生作品基础类。
    /// </summary>
    [Serializable]
    public class StudentWork
    {
        #region 成员变量，构造函数。
        EnumWorkType type;
        DateTime time;
        Student student = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public StudentWork()
        {
            this.time = DateTime.Now;
            this.Status = EnumWorkStatus.None;
            this.type = EnumWorkType.Public;
            this.student = new Student();
        }
        #endregion

        /// <summary>
        /// 获取或设置作品ID。
        /// </summary>
        public string WorkID { get; set; }
        /// <summary>
        /// 获取或设置作品名称
        /// </summary>
        public string WorkName { get; set; }
        /// <summary>
        /// 获取或设置年级ID。
        /// </summary>
        public string GradeID { get; set; }
        /// <summary>
        /// 获取或设置班级ID。
        /// </summary>
        public string ClassID { get; set; }
        /// <summary>
        /// 获取或设置作品状态。
        /// </summary>
        public EnumWorkStatus Status { get; set; }
        /// <summary>
        /// 获取或设置目录ID。
        /// </summary>
        public string CatalogID { get; set; }
        /// <summary>
        /// 获取或设置目录名称。
        /// </summary>
        public string CatalogName { get; set; }
        /// <summary>
        /// 获取或设置作品校验码。
        /// </summary>
        public string CheckCode { get; set; }
        /// <summary>
        /// 获取或设置作品类型。
        /// </summary>
        public EnumWorkType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        /// <summary>
        /// 获取或设置学生信息。
        /// </summary>
        public Student Student
        {
            get { return this.student; }
            set { this.student = value; }
        }
       
        /// <summary>
        /// 获取或设置处理时间。
        /// </summary>
        public DateTime Time
        {
            get { return this.time; }
            set { this.time = value; }
        }
        /// <summary>
        /// 作品描述。
        /// </summary>
        public string Description
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 教师机上传学生作品(传递)。
    /// </summary>
    [Serializable]
    public class StudentWorkTeaUpload : StudentWork
    {
        #region 成员变量，构造函数。
        TeacherReview review;
        StudentWorkFile files;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public StudentWorkTeaUpload()
        {
            this.review = new TeacherReview();
            this.files = new StudentWorkFile();
        }
        #endregion

        /// <summary>
        /// 获取或设置作品文件集合。
        /// </summary>
        public StudentWorkFile Files
        {
            get { return this.files; }
            set { this.files = value; }
        }
        /// <summary>
        /// 获取或设置教师评阅。
        /// </summary>
        public TeacherReview Review
        {
            get { return this.review; }
            set { this.review = value; }
        }
    }
}