//================================================================================
// FileName: SFITSchoolsEntity.cs
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
using System.Collections.Specialized;
using System.Text;
using System.Data;

using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.SFIT.SyncService
{
    ///<summary>
    ///tblSFITSchoolsӳ���ࡣ
    ///</summary>
    [DbTable("tblSFITSchools")]
    internal class SFITSchools
    {
        #region ���ԡ�
        ///<summary>
        ///��ȡ������SchoolID��
        ///</summary>
        [DbField("SchoolID", DbFieldUsage.PrimaryKey)]
        public GUIDEx SchoolID
        {
            get;
            set;

        }

        ///<summary>
        ///��ȡ������SchoolCode��
        ///</summary>
        [DbField("SchoolCode", DbFieldUsage.UniqueKey)]
        public string SchoolCode
        {
            get;
            set;

        }

        ///<summary>
        ///��ȡ������SchoolName��
        ///</summary>
        [DbField("SchoolName")]
        public string SchoolName
        {
            get;
            set;

        }

        ///<summary>
        ///��ȡ������SchoolType��
        ///</summary>
        [DbField("SchoolType")]
        public int SchoolType
        {
            get;
            set;

        }

        ///<summary>
        ///��ȡ������OrderNO��
        ///</summary>
        [DbField("OrderNO")]
        public int OrderNO
        {
            get;
            set;

        }

        ///<summary>
        ///��ȡ������SyncStatus��
        ///</summary>
        [DbField("SyncStatus")]
        public int SyncStatus
        {
            get;
            set;

        }

        ///<summary>
        ///��ȡ������LastSyncTime��
        ///</summary>
        [DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime LastSyncTime
        {
            get;
            set;

        }

        #endregion
    }
	///<summary>
	///SFITSchoolsEntityʵ���ࡣ
	///</summary>
	internal class SFITSchoolsEntity: DbModuleEntity<SFITSchools>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯��
		///</summary>
		public SFITSchoolsEntity()
		{

		}
		#endregion

        #region ���ݲ�����
        /// <summary>
        /// ����ѧУ�����ȡѧУ��š�
        /// </summary>
        /// <param name="schoolCode"></param>
        /// <returns></returns>
        public GUIDEx GetSchoolID(string schoolCode)
        {
            const string sql = "select SchoolID from {0} where SchoolCode = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, schoolCode));
            return obj == null ? GUIDEx.Null : new GUIDEx(obj);
        }
        /// <summary>
        /// ����ȫ��ͬ�����ݡ�
        /// </summary>
        /// <returns></returns>
        public List<SFITSchools> LoadAllowSyncData()
        {
            return this.LoadRecord("SyncStatus <> 0x00");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SFITSchools> LoadNotAllowSyncData()
        {
            return this.LoadRecord("SyncStatus = 0x00");
        }
        #endregion
    }
}