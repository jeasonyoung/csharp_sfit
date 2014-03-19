//================================================================================
// FileName: SFITStudentWorks.cs
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
    ///ѧ����Ʒӳ���ࡣ
    ///</summary>
    [DbTable("tblSFITStudentWorks")]
    public class SFITStudentWorks
    {
        #region ��Ա���������캯����
        ///<summary>
        ///���캯����
        ///</summary>
        public SFITStudentWorks()
        {
            this.CreateDateTime = DateTime.Now;
        }
        #endregion

        #region ���ԡ�
        ///<summary>
        ///��ȡ��������ƷID��
        ///</summary>
        [DbField("WorkID", DbFieldUsage.PrimaryKey)]
        public GUIDEx WorkID { get; set; }
        ///<summary>
        ///��ȡ��������Ʒ���ơ�
        ///</summary>
        [DbField("WorkName")]
        public string WorkName { get; set; }
        ///<summary>
        ///��ȡ��������Ʒ״̬��
        ///</summary>
        [DbField("WorkStatus")]
        public int WorkStatus { get; set; }
        ///<summary>
        ///��ȡ��������Ʒ״̬��
        ///</summary>
        [DbField("WorkType")]
        public int WorkType { get; set; }
        ///<summary>
        ///��ȡ������У���롣
        ///</summary>
        [DbField("CheckCode")]
        public string CheckCode { get; set; }
        ///<summary>
        ///��ȡ������ѧУID��
        ///</summary>
        [DbField("SchoolID")]
        public GUIDEx SchoolID { get; set; }
        /// <summary>
        /// ��ȡ������ѧУ���ơ�
        /// </summary>
        [DbField("SchoolName")]
        public string SchoolName { get; set; }
        ///<summary>
        ///��ȡ�������꼶ID��
        ///</summary>
        [DbField("GradeID")]
        public GUIDEx GradeID { get; set; }
        /// <summary>
        /// ��ȡ�������꼶���ơ�
        /// </summary>
        [DbField("GradeName")]
        public string GradeName { get; set; }
        ///<summary>
        ///��ȡ�����ð༶ID��
        ///</summary>
        [DbField("ClassID")]
        public GUIDEx ClassID { get; set; }
        /// <summary>
        ///��ȡ�����ð༶���ơ�
        /// </summary>
        [DbField("ClassName")]
        public string ClassName { get; set; }
        ///<summary>
        ///��ȡ������ѧ��ID��
        ///</summary>
        [DbField("StudentID")]
        public GUIDEx StudentID { get; set; }
        /// <summary>
        /// ��ȡ������ѧ�����롣
        /// </summary>
        public string StudentCode { get;set; }
        /// <summary>
        /// ��ȡ������ѧ�����ơ�
        /// </summary>
        public string StudentName { get; set; }
        ///<summary>
        ///��ȡ������Ŀ¼ID��
        ///</summary>
        [DbField("CatalogID")]
        public GUIDEx CatalogID { get; set; }
        /// <summary>
        /// ��ȡ������Ŀ¼���ơ�
        /// </summary>
        [DbField("CatalogName")]
        public string CatalogName { get; set; }
        ///<summary>
        ///��ȡ�����ô����û�ID��
        ///</summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID { get; set; }
        ///<summary>
        ///��ȡ�����ô����û����ơ�
        ///</summary>
        [DbField("CreateEmployeeName")]
        public string CreateEmployeeName { get; set; }
        ///<summary>
        ///��ȡ�����ô���ʱ�䡣
        ///</summary>
        [DbField("CreateDateTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime CreateDateTime { get; set; }
        ///<summary>
        ///��ȡ��������Ʒ������
        ///</summary>
        [DbField("WorkDescription")]
        public string WorkDescription { get; set; }
        /// <summary>
        /// ��ȡ�����õ������
        /// </summary>
        [DbField("Hits")]
        public int Hits { get; set; }
        #endregion
    }
}