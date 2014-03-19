//================================================================================
// FileName: SFITStudentsEntity.cs
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
	///SFITStudentsEntity实体类。
	///</summary>
	internal class SFITStudentsEntity: DbModuleEntity<SFITStudents>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITStudentsEntity()
		{

		}
		#endregion

        #region 重载。
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool LoadRecord(ref SFITStudents entity)
        {
            bool result = false;
            GUIDEx classID = entity.ClassID;
            if (result = base.LoadRecord(ref entity))
            {
                if (!classID.IsValid)
                    classID = new SFITClassStudentsEntity().GetLastClassIDByStudentID(entity.StudentID);
                entity.ClassID = classID;
                if (entity.ClassID.IsValid)
                {
                    SFITClass data = new SFITClass();
                    data.ClassID = entity.ClassID;
                    if (new SFITClassEntity().LoadRecord(ref data))
                    {
                        entity.GradeID = data.GradeID;
                        entity.SchoolID = data.SchoolID;
                        entity.SchoolName = data.SchoolName;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool UpdateRecord(SFITStudents entity)
        {
            bool result = false;
            if (result = base.UpdateRecord(entity))
            {
                const string sql = "select 0 from tblSFITClassStudents where ClassID = '{0}' and StudentID = '{1}'";
                object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, entity.ClassID, entity.StudentID));
                if (obj == null && entity.ClassID.IsValid && entity.StudentID.IsValid) 
                {
                    SFITClassStudents data = new SFITClassStudents();
                    data.ClassID = entity.ClassID;
                    data.StudentID = entity.StudentID;
                    data.LastSyncTime = DateTime.Now;

                    result = new SFITClassStudentsEntity().UpdateRecord(data);
                }
            }
            return result;
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="gradeName"></param>
        /// <param name="className"></param>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string schoolName, string gradeName, string className, string studentName)
        {
            const string sql = "exec spSFITStudentsListView '{0}','{1}','{2}','{3}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolName, gradeName, className, studentName)).Tables[0];
        }
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <param name="unitID"></param>
        /// <param name="className"></param>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public DataTable PickerListDataSource(GUIDEx unitID, string className, string studentName)
        {
            const string sql = "exec spSFITStudentsPickerView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, unitID, className, studentName)).Tables[0];
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="classStudentID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteRecord(string classStudentID, out string err)
        {
            const string sql = "exec spSFITDeleteStudents '{0}','{1}'";
            err = null;
            if (!string.IsNullOrEmpty(classStudentID) && classStudentID.IndexOf('-') > -1)
            {
                string[] arr = classStudentID.Split('-');
                string result = this.DatabaseAccess.ExecuteScalar(string.Format(sql, arr[0], arr[1])).ToString();
                string[] array = result.Split('|');
                err = array[1];
                return array[0] == "0";
            }
            return false;
        }
        /// <summary>
        /// 查找学生。
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public DataTable FindStudent(string studentName)
        {
            return this.GetAllRecord(string.Format("(StudentCode like '%{0}%' or StudentName like '%{0}%')", studentName), "StudentCode");
        }
        /// <summary>
        /// 查找学生。
        /// </summary>
        /// <param name="studentCode"></param>
        /// <returns></returns>
        public SFITStudents FindStudentByCode(string studentCode)
        {
            List<SFITStudents> list = this.LoadRecord(string.Format("StudentCode = '{0}'", studentCode));
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        /// <summary>
        /// 加载学生数据。
        /// </summary>
        /// <param name="cInfo"></param>
        /// <returns></returns>
        public void LoadTeaSyncStudents(ref Class info)
        {
            const string filter = "(SyncStatus <> 0x00) and (StudentID in (select StudentID from tblSFITClassStudents where ClassID = '{0}'))";
            DataTable dtSource = this.GetAllRecord(string.Format(filter, info.ClassID), "StudentCode");
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    Student s = new Student();
                    s.StudentID = Convert.ToString(row["StudentID"]);
                    s.StudentCode = Convert.ToString(row["StudentCode"]);
                    s.StudentName = Convert.ToString(row["StudentName"]);
                    info.Students.Add(s);
                }
            }
        }
        /// <summary>
        /// 获取学生所属学校ID。
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        GUIDEx GetSchoolID(GUIDEx studentID)
        {
            const string sql = "select SchoolID from tblSFITClass where (ClassID in (select ClassID from tblSFITClassStudents where StudentID = '{0}'))";
            if (string.IsNullOrEmpty(studentID))
                return GUIDEx.Null;
            return new GUIDEx(this.DatabaseAccess.ExecuteScalar(string.Format(sql, studentID)));
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
                dtSource = this.GetAllRecord(string.Format("StudentID = '{0}'", employeeID));
                if (dtSource != null && dtSource.Rows.Count == 0)
                    dtSource = this.GetAllRecord(string.Format("StudentCode like '%{0}%' or StudentName like '%{0}%'", employeeID));
            }
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                OrgEmployeeCollection collection = new OrgEmployeeCollection();
                foreach (DataRow row in dtSource.Rows)
                {
                    OrgEmployee data = new OrgEmployee();
                    data.EmployeeID = Convert.ToString(row["StudentID"]);
                    data.EmployeeSign = Convert.ToString(row["StudentCode"]);
                    data.EmployeeName =string.Format("{0}(学)",row["StudentName"]);
                    data.DepartmentID = this.GetSchoolID(data.EmployeeID);

                    collection.Add(data);
                }
                return collection;
            }
            return null;
        }
        #endregion

    }

}
