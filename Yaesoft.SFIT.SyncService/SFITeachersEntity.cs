//================================================================================
// FileName: SFITeachersEntity.cs
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
    ///tblSFITeachersӳ���ࡣ
    ///</summary>
    [DbTable("tblSFITeachers")]
    internal class SFITeachers
    {
        #region ���ԡ�
        ///<summary>
        ///��ȡ������TeacherID��
        ///</summary>
        [DbField("TeacherID", DbFieldUsage.PrimaryKey)]
        public GUIDEx TeacherID
        {
            get;
            set;

        }

        ///<summary>
        ///��ȡ������TeacherCode��
        ///</summary>
        [DbField("TeacherCode", DbFieldUsage.UniqueKey)]
        public string TeacherCode
        {
            get;
            set;

        }

        ///<summary>
        ///��ȡ������TeacherName��
        ///</summary>
        [DbField("TeacherName")]
        public string TeacherName
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
	///SFITeachersEntityʵ���ࡣ
	///</summary>
	internal class SFITeachersEntity: DbModuleEntity<SFITeachers>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯��
		///</summary>
		public SFITeachersEntity()
		{

		}
		#endregion

        #region ���ݲ�����
        /// <summary>
        /// ��ȡ��ʦID��
        /// </summary>
        /// <param name="teacherCode"></param>
        /// <returns></returns>
        public GUIDEx GetTeacherID(string teacherCode)
        {
            const string sql = "select TeacherID from {0} where TeacherCode = '{1}'";
            if (!string.IsNullOrEmpty(teacherCode))
            {
                object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, teacherCode));
                if (obj != null)
                    return new GUIDEx(obj);
            }
            return GUIDEx.Null;
        }
        #endregion
    }
}