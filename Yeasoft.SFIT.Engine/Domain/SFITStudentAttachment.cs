//================================================================================
// FileName: SFITStudentAttachment.cs
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
	///tblSFITStudentAttachmentӳ���ࡣ
	///</summary>
	[DbTable("tblSFITStudentAttachment")]
	public class SFITStudentAttachment
    {
        #region ��Ա���������캯����
        /// <summary>
        /// ���캯����
        /// </summary>
        public SFITStudentAttachment()
        {
            this.CreateDateTime = DateTime.Now;
        }
        #endregion

        #region ���ԡ�
        ///<summary>
		///��ȡ������WorkID��
		///</summary>
        [DbField("WorkID", DbFieldUsage.PrimaryKey)]
        public GUIDEx WorkID { get; set; }
		///<summary>
		///��ȡ������AccessoriesID��
		///</summary>
        [DbField("AccessoriesID", DbFieldUsage.PrimaryKey)]
        public GUIDEx AccessoriesID { get; set; }
		///<summary>
		///��ȡ������CreateEmployeeID��
		///</summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID { get; set; }
		///<summary>
		///��ȡ������CreateEmployeeName��
		///</summary>
        [DbField("CreateEmployeeName")]
        public string CreateEmployeeName { get; set; }
		///<summary>
		///��ȡ������CreateDateTime��
		///</summary>
        [DbField("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }
		#endregion
	}
}