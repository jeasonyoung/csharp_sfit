//================================================================================
// FileName: SFITStudentsEntity.cs
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
    ///ѧ����Ϣӳ���ࡣ
    ///</summary>
    [DbTable("tblSFITStudents")]
    internal class SFITStudents
    {
        #region ���ԡ�
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
        ///��ȡ������ѧ��ѧ�š�
        ///</summary>
        [DbField("StudentCode", DbFieldUsage.UniqueKey)]
        public string StudentCode
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������������
        ///</summary>
        [DbField("StudentName")]
        public string StudentName
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�������Ա�
        /// </summary>
        [DbField("Gender")]
        public int Gender
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
        /// ��ȡ���������֤�š�
        /// </summary>
        [DbField("IDNumber")]
        public string IDNumber
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
	///SFITStudentsEntityʵ���ࡣ
	///</summary>
	internal class SFITStudentsEntity: DbModuleEntity<SFITStudents>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯��
		///</summary>
		public SFITStudentsEntity()
		{

		}
		#endregion

        #region ���ݲ�����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="syncStudentIDs"></param>
        /// <param name="log"></param>
        /// <param name="count"></param>
        public void StopSync(GUIDEx classID, List<GUIDEx> syncStudentIDs, ref StringBuilder log, ref int count)
        {
            if (classID.IsValid)
            {
                List<GUIDEx> hiddens = new List<GUIDEx>();

                #region ��ȡ�����ص�ѧ��ID��
                List<GUIDEx> allStudentIDs = new SFITClassStudentsEntity().GetStudents(classID);
                if (allStudentIDs != null && allStudentIDs.Count > 0)
                {
                    if (syncStudentIDs == null || syncStudentIDs.Count == 0)
                    {
                        hiddens = allStudentIDs;
                    }
                    else
                    {
                        for (int i = 0; i < allStudentIDs.Count; i++)
                        {
                            bool result = syncStudentIDs.Exists(new Predicate<GUIDEx>(delegate(GUIDEx sender)
                            {
                                return (sender.IsValid) && (sender == allStudentIDs[i]);
                            }));
                            if (!result)
                            {
                                hiddens.Add(allStudentIDs[i]);
                            }
                        }

                    }
                }
                #endregion

                if (hiddens.Count > 0)
                {
                    for (int j = 0; j < hiddens.Count; j++)
                    {
                        SFITStudents data = new SFITStudents();
                        data.StudentID = hiddens[j];
                        if (this.LoadRecord(ref data))
                        {
                            data.SyncStatus = 0x00;
                            if (this.UpdateRecord(data))
                            {
                                log.AppendLine();
                                log.AppendFormat("(ѧ��ID��{0})[ѧ�ţ�{1}][���ƣ�{2}][�Ա�{3}][��ѧ��ݣ�{4}][���֤�ţ�{5}] �������أ�",
                                            data.StudentID, data.StudentCode, data.StudentName, data.Gender, data.JoinYear, data.IDNumber);
                                count++;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// ����ѧ�Ż�ȡѧ�����롣
        /// </summary>
        /// <param name="stuCode"></param>
        /// <returns></returns>
        public GUIDEx GetStudentIDByCode(string stuCode)
        {
            const string sql = "select StudentID from {0} where StudentCode = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql,this.TableName, stuCode));
            return obj == null ? GUIDEx.Null : new GUIDEx(obj);
        }
        #endregion
    }
}