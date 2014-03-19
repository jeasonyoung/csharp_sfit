//================================================================================
// FileName: SFITClassStudentsEntity.cs
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
    ///�༶ѧ��ӳ���ࡣ
    ///</summary>
    [DbTable("tblSFITClassStudents")]
    internal class SFITClassStudents
    {
        #region ���ԡ�
        ///<summary>
        ///��ȡ�����ð༶ID��
        ///</summary>
        [DbField("ClassID", DbFieldUsage.PrimaryKey)]
        public GUIDEx ClassID
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������ѧ��ID��
        ///</summary>
        [DbField("StudentID", DbFieldUsage.PrimaryKey)]
        public GUIDEx StudentID
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������ͬ��ʱ�䡣
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
	///SFITClassStudentsEntityʵ���ࡣ
	///</summary>
	internal class SFITClassStudentsEntity: DbModuleEntity<SFITClassStudents>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯��
		///</summary>
		public SFITClassStudentsEntity()
		{

		}
		#endregion

        #region ������
        /// <summary>
        /// ɾ�����ݡ�
        /// </summary>
        /// <param name="studentID"></param>
        public void Delete(GUIDEx studentID)
        {
            this.DeleteRecord(string.Format("StudentID='{0}'", studentID));
        }
        /// <summary>
        /// �Ƿ�������ݡ�
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool ExistsData(GUIDEx classID, GUIDEx studentID)
        {
            const string sql = "select 0 from {0} where ClassID = '{1}' and StudentID = '{2}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, classID, studentID));
            return obj != null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<GUIDEx> GetStudents(GUIDEx classID)
        {
            List<GUIDEx> list = new List<GUIDEx>();
            DataTable dtSource = this.GetAllRecord(string.Format("ClassID = '{0}'", classID));
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    list.Add(string.Format("{0}", row["StudentID"]));
                }
            }
            return list;
        }
        #endregion
    }

}