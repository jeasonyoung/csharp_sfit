//================================================================================
// FileName: SFITClassEntity.cs
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
    ///tblSFITClassӳ���ࡣ
    ///</summary>
    [DbTable("tblSFITClass")]
    internal class SFITClass
    {
        #region ���ԡ�
        ///<summary>
        ///��ȡ������ClassID��
        ///</summary>
        [DbField("ClassID", DbFieldUsage.PrimaryKey)]
        public GUIDEx ClassID
        {
            get;
            set;

        }
        ///<summary>
        ///��ȡ������ClassCode��
        ///</summary>
        [DbField("ClassCode", DbFieldUsage.UniqueKey)]
        public string ClassCode
        {
            get;
            set;

        }
        ///<summary>
        ///��ȡ������ClassName��
        ///</summary>
        [DbField("ClassName")]
        public string ClassName
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
        ///��ȡ������SchoolID��
        ///</summary>
        [DbField("SchoolID")]
        public GUIDEx SchoolID
        {
            get;
            set;

        }
        /// <summary>
        /// ��ȡ��������ѧ��ݡ�
        /// </summary>
        [DbField("JoinYear")]
        public int JoinYear
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�����õ�ǰ�꼶��
        /// </summary>
        [DbField("GradeValue")]
        public int GradeValue
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ������ѧϰ�׶Ρ�
        /// </summary>
        [DbField("LearnLevel")]
        public int LearnLevel
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
        [DbField("LastSyncTime")]
        public DateTime LastSyncTime
        {
            get;
            set;

        }
        #endregion
    }
	///<summary>
	///SFITClassEntityʵ���ࡣ
	///</summary>
	internal class SFITClassEntity: DbModuleEntity<SFITClass>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯��
		///</summary>
		public SFITClassEntity()
		{

		}
		#endregion
        
        #region ���ݲ�����
        /// <summary>
        /// ���ݰ༶�����ȡ�༶ID��
        /// </summary>
        /// <param name="classCode"></param>
        /// <returns></returns>
        public GUIDEx GetClassIDByCode(GUIDEx classCode)
        {
            const string sql = "select ClassID from {0} where ClassCode = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, classCode));
            return obj == null ? GUIDEx.Null : new GUIDEx(obj);
        }
        /// <summary>
        /// ��ȡ����ͬ����ѧУ�µİ༶��
        /// </summary>
        /// <param name="schoolID"></param>
        /// <returns></returns>
        public List<SFITClass> LoadAllowSyncData(GUIDEx schoolID)
        {
            return this.LoadRecord(string.Format("(SyncStatus <> 0x00) and (SchoolID = '{0}')", schoolID));
        }
         /// <summary>
        /// ��ȡѧУ�µİ༶��
        /// </summary>
        /// <param name="schoolID"></param>
        /// <returns></returns>
        public List<SFITClass> LoadAllData(GUIDEx schoolID)
        {
            return this.LoadRecord(string.Format("SchoolID = '{0}'", schoolID));
        }
        #endregion
    }
}