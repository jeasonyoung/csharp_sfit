//================================================================================
// FileName: SFITGroupStudentsEntity.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
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
	///SFITGroupStudentsEntity实体类。
	///</summary>
	internal class SFITGroupStudentsEntity: DbModuleEntity<SFITGroupStudents>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITGroupStudentsEntity()
		{

		}
		#endregion

        #region 数据操作。
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
        /// 删除数据。
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public bool DeleteRecord(GUIDEx groupID)
        {
            return base.DeleteRecord(string.Format("GroupID = '{0}'", groupID));
        }
        #endregion

        #region 重载。
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
