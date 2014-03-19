//================================================================================
// FileName: SFITTeaClassEntity.cs
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

using Yaesoft.SFIT;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITTeaClassEntity实体类。
	///</summary>
	internal class SFITTeaClassEntity: DbModuleEntity<SFITTeaClass>
	{
		#region 成员变量，构造函数。
        SecurityRoleEmployeeEntity roleEmployeeEntity = null;
		///<summary>
		///构造函数
		///</summary>
		public SFITTeaClassEntity()
		{
            this.roleEmployeeEntity = new SecurityRoleEmployeeEntity();
		}
		#endregion

        #region 重载。
        /// <summary>
        ///  删除数据。
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public override bool DeleteRecord(StringCollection primaryValues)
        {
            bool result = false;
            if (primaryValues != null && primaryValues.Count > 0)
            {
                string[] arr = new string[primaryValues.Count];
                primaryValues.CopyTo(arr, 0);
                result = this.DeleteRecord(arr);
            }
            return result;
        }
        /// <summary>
        ///  删除数据。
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public new bool DeleteRecord(params string[] teacherID)
        {
            bool result = false;
            if (teacherID == null || teacherID.Length == 0)
                return result;

            if (result = base.DeleteRecord(string.Format("TeacherID in ('{0}')", string.Join("','", teacherID))))
                this.roleEmployeeEntity.BatchDeleteTeaClassUser(teacherID);
            return result;
        }
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool UpdateRecord(SFITTeaClass entity)
        {
            bool result = false;
            if (result = base.UpdateRecord(entity))
            {
                SecurityRoleEmployee sre = new SecurityRoleEmployee();
                sre.EmployeeID = entity.TeacherID;
                sre.EmployeeName = entity.TeacherName;
                sre.RoleID = this.ModuleConfig.TeaClassRoleID;
                if (sre.RoleID.IsValid)
                {
                    result = this.roleEmployeeEntity.UpdateRecord(sre);
                }
            }
            return result;
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 列表数据源。
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="teacherName"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string schoolName, string teacherName, string className)
        {
            const string sql = "exec spSFITTeaClassListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolName, teacherName, className)).Tables[0];
        }
        /// <summary>
        /// 列表数据源。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="teacherName"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx schoolID, string teacherName, string className)
        {
            const string sql = "exec spSFITTeaClassByUnitListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolID, teacherName, className)).Tables[0];
        }
        /// <summary>
        /// 根据教师ID获取班级ID集合。
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public StringCollection GetClassByTeacher(GUIDEx teacherID)
        {
            if (teacherID.IsValid)
            {
                DataTable dtSource = this.GetAllRecord(string.Format("TeacherID = '{0}'", teacherID));
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    StringCollection collection = new StringCollection();
                    foreach (DataRow row in dtSource.Rows)
                    {
                        collection.Add(Convert.ToString(row["ClassID"]));
                    }
                    return collection;
                }
            }
            return null;
        }
        /// <summary>
        ///验证是否为学校的任课教师。
        /// </summary>
        /// <param name="schoolID">学校ID。</param>
        /// <param name="teacherID">教师ID。</param>
        /// <returns></returns>
        public bool VerifyInstructor(GUIDEx schoolID, GUIDEx teacherID)
        {
            const string sql = "exec spSFITVerifyInstructor '{0}','{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, schoolID, teacherID));
            if (obj != null)
                return ((int)obj) == 1;
            return false;
        }
        #endregion
    }

}
