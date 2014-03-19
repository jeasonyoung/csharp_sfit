//================================================================================
// FileName: SFITCatalog.cs
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
	///�γ�Ŀ¼ӳ���ࡣ
	///</summary>
    [DbTable("tblSFITCatalog")]
    public class SFITCatalog
    {
        #region ��Ա���������캯����
        ///<summary>
        ///���캯����
        ///</summary>
        public SFITCatalog()
        {

        }
        #endregion

        #region ���ԡ�
        ///<summary>
        ///��ȡ������ѧУID��
        ///</summary>
        [DbField("SchoolID")]
        public GUIDEx SchoolID
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ������ѧУ���ơ�
        /// </summary>
        public string SchoolName
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������GradeID��
        ///</summary>
        [DbField("GradeID")]
        public GUIDEx GradeID
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������Ŀ¼ID��
        ///</summary>
        [DbField("CatalogID", DbFieldUsage.PrimaryKey)]
        public GUIDEx CatalogID
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������Ŀ¼���롣
        ///</summary>
        [DbField("CatalogCode")]
        public string CatalogCode
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������Ŀ¼���ơ�
        ///</summary>
        [DbField("CatalogName")]
        public string CatalogName
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������Ŀ¼���͡�
        ///</summary>
        [DbField("CatalogType")]
        public int CatalogType
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ����������
        ///</summary>
        [DbField("OrderNO")]
        public int OrderNO
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�����ô����û�ID
        /// </summary>
        [DbField("CreateEmployeeID")]
        public GUIDEx CreateEmployeeID
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�����ô����û����ơ�
        /// </summary>
        [DbField("CreateEmployeeName")]
        public string CreateEmployeeName
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�����ô���ʱ�䡣
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
