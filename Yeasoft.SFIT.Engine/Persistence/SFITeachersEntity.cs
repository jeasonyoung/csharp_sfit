//================================================================================
// FileName: SFITeachersEntity.cs
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

using iPower.IRMP.Org;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITeachersEntity实体类。
	///</summary>
	internal class SFITeachersEntity: DbModuleEntity<SFITeachers>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITeachersEntity()
		{

		}
		#endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool LoadRecord(ref SFITeachers entity)
        {
            bool result = false;
            if ((result = base.LoadRecord(ref entity)))
            {
                SFITSchools data = new SFITSchools();
                data.SchoolID = entity.SchoolID;
                if (new SFITSchoolsEntity().LoadRecord(ref data))
                {
                    entity.SchoolName = data.SchoolName;
                }
            }
            return result;
        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 列表数据。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="teacherName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string schoolID, string teacherName)
        {
            const string sql = "exec spSFITeachersListView '{0}','{1}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolID, teacherName)).Tables[0];
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteRecord(GUIDEx teacherID, out string err)
        {
            const string sql = "exec spSFITDeleteTeachers '{0}'";
            string result = this.DatabaseAccess.ExecuteScalar(string.Format(sql, teacherID)).ToString();
            string[] array = result.Split('|');
            err = array[1];
            return array[0] == "0";
        }
        /// <summary>
        /// 绑定数据。
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="teacherName"></param>
        /// <returns></returns>
        public IListControlsData BindTeachers(GUIDEx schoolName, string teacherName)
        {
            const string sql = "exec spSFITBindTeachers '{0}','{1}'";
            DataTable dtSource = this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolName, teacherName)).Tables[0];
            if (dtSource != null)
            {
                dtSource.Columns.Add("TeacherNameCode", typeof(string));
                foreach (DataRow row in dtSource.Rows)
                {
                    row["TeacherNameCode"] = string.Format("{0}(账号：{1})", row["TeacherName"], row["TeacherCode"]);
                }
                return new ListControlsDataSource("TeacherNameCode", "TeacherID", dtSource);
            }
            return null;
        }
        /// <summary>
        /// 绑定教师数据。
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public IListControlsData BindTeachers(string[] teacherID)
        {
            if (teacherID != null && teacherID.Length > 0)
            {
                DataTable dtSource = this.GetAllRecord(string.Format("TeacherID in ('{0}')", string.Join("','", teacherID)));
                if (dtSource != null)
                {
                    dtSource.Columns.Add("TeacherNameCode", typeof(string));
                    foreach (DataRow row in dtSource.Rows)
                    {
                        row["TeacherNameCode"] = string.Format("{0}(账号：{1})", row["TeacherName"], row["TeacherCode"]);
                    }
                    return new ListControlsDataSource("TeacherNameCode", "TeacherID", dtSource);
                }
            }
            return null;
        }
        /// <summary>
        /// 加载教师信息。
        /// </summary>
        /// <param name="info"></param>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public bool LoadTeaSyncTeacher(ref Teacher info, GUIDEx teacherID)
        {
            if (teacherID.IsValid)
            {
                SFITeachers data = new SFITeachers();
                data.TeacherID = teacherID;
                if (this.LoadRecord(ref data))
                {
                    info.TeacherID = data.TeacherID;
                    info.TeacherCode = data.TeacherCode;
                    info.TeacherName = data.TeacherName;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 查找教师信息。
        /// </summary>
        /// <param name="teacherCode"></param>
        /// <returns></returns>
        public SFITeachers FindTeacher(string teacherCode)
        {
            List<SFITeachers> list = this.LoadRecord(string.Format("TeacherCode = '{0}'", teacherCode));
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public OrgEmployeeCollection GetAllEmployee(string employeeID)
        {
            DataTable dtSource = null;
            if (string.IsNullOrEmpty(employeeID))
                dtSource = this.GetAllRecord();
            else
            {
                dtSource = this.GetAllRecord(string.Format("TeacherID='{0}'", employeeID));
                if (dtSource != null && dtSource.Rows.Count == 0)
                    dtSource = this.GetAllRecord(string.Format("TeacherCode like '%{0}%' or TeacherName like '%{0}%'", employeeID));
            }
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                OrgEmployeeCollection collection = new OrgEmployeeCollection();
                foreach (DataRow row in dtSource.Rows)
                {
                    OrgEmployee data = new OrgEmployee();
                    data.EmployeeID = Convert.ToString(row["TeacherID"]);
                    data.EmployeeSign = Convert.ToString(row["TeacherCode"]);
                    data.EmployeeName = string.Format("{0}(工)", row["TeacherName"]);
                    data.DepartmentID = Convert.ToString(row["SchoolID"]);
                    collection.Add(data);
                }
                return collection;
            }
            return null;
        }
        #endregion

    }

}
