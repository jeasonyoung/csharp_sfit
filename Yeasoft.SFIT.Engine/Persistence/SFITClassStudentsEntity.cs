//================================================================================
// FileName: SFITClassStudentsEntity.cs
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
	///SFITClassStudentsEntity实体类。
	///</summary>
	internal class SFITClassStudentsEntity: DbModuleEntity<SFITClassStudents>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITClassStudentsEntity()
		{

		}
		#endregion

        /// <summary>
        /// 根据学生ID获取班级ID。
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
