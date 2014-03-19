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
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
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

        /// <summary>
        /// ����ѧ��ID��ȡ�༶ID��
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public GUIDEx GetLastClassIDByStudentID(GUIDEx studentID)
        {
            const string sql = "select ClassID from {0} where StudentID = '{1}' order by LastSyncTime desc";
            if (studentID.IsValid)
            {
                object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, studentID));
                if (obj != null)
                    return new GUIDEx(obj);
            }
            return GUIDEx.Null;
        }
	}

}
