//================================================================================
// FileName: SFITGroupEntity.cs
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
	///SFITGroupEntity实体类。
	///</summary>
	internal class SFITGroupEntity: DbModuleEntity<SFITGroup>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITGroupEntity()
		{

		}
		#endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitName"></param>
        /// <param name="groupName"></param>
        /// <param name="groupType"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string unitName, string groupName, int groupType, int IsUnit, GUIDEx employeeID)
        {
            const string sql = "exec spSFITGroupListView '{0}','{1}','{2}','{3}','{4}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, unitName, groupName, groupType, IsUnit, employeeID)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitName"></param>
        /// <param name="groupName"></param>
        /// <param name="catalogName"></param>
        /// <param name="studentName"></param>
        /// <param name="groupType"></param>
        /// <param name="isUnit"></param>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string unitName, string groupName, string catalogName, string studentName,
            int groupType, int isUnit, GUIDEx employeeID)
        {
            const string sql = "exec spSFITGroupWorkListView '{0}','{1}','{2}','{3}','{4}','{5}','{6}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, unitName, groupName, catalogName, studentName,
                    groupType, isUnit, employeeID)).Tables[0];
        }
	}

}
