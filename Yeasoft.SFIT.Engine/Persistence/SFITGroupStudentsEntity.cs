//================================================================================
// FileName: SFITGroupStudentsEntity.cs
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
	///SFITGroupStudentsEntityʵ���ࡣ
	///</summary>
	internal class SFITGroupStudentsEntity: DbModuleEntity<SFITGroupStudents>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯��
		///</summary>
		public SFITGroupStudentsEntity()
		{

		}
		#endregion

        #region ���ݲ�����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx groupID)
        {
            const string sql = "exec spSFITGroupStudentsListView '{0}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, groupID)).Tables[0];
        }
        /// <summary>
        /// ɾ�����ݡ�
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public bool DeleteRecord(GUIDEx groupID)
        {
            return base.DeleteRecord(string.Format("GroupID = '{0}'", groupID));
        }
        #endregion

        #region ���ء�
        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public override bool DeleteRecord(StringCollection primaryValues)
        {
            if (primaryValues != null && primaryValues.Count > 0)
            {
                string[] groupIds = new string[primaryValues.Count];
                primaryValues.CopyTo(groupIds, 0);
                return base.DeleteRecord(string.Format("GroupID in ('{0}')", string.Join("','", groupIds)));
            }
            return false;
        }
        #endregion
    }

}
