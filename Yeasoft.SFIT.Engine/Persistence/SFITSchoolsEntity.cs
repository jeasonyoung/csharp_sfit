//================================================================================
// FileName: SFITSchoolsEntity.cs
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
using Yaesoft.SFIT.Engine.Index;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITSchoolsEntity实体类。
	///</summary>
    internal class SFITSchoolsEntity : DbModuleEntity<SFITSchools>
    {
        #region 成员变量，构造函数。
        ///<summary>
        ///构造函数
        ///</summary>
        public SFITSchoolsEntity()
        {

        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 绑定学校数据。
        /// </summary>
        public IListControlsData BindSchools()
        {
            return new ListControlsDataSource("SchoolName", "SchoolID", this.ListDataSource(null));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IListControlsData BindIndexSchools()
        {
            return new ListControlsDataSource("UnitName", "UnitID", this.GetIndexUnits());
        }
        /// <summary>
        /// 绑定用户的学校数据。
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public IListControlsData BindSchools(GUIDEx employeeID)
        {
            if (employeeID.IsValid)
            {
                SFITeachers data = new SFITeachers();
                data.TeacherID = employeeID;
                if (new SFITeachersEntity().LoadRecord(ref data))
                {
                    return this.BindControls(new string[] { data.SchoolID });
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schoolIDs"></param>
        /// <returns></returns>
        public IListControlsData BindControls(string[] schoolIDs)
        {
            DataTable dtSource = this.GetAllRecord(string.Format("SchoolID in ('{0}')", string.Join("','", schoolIDs)), "OrderNO");
            return new ListControlsDataSource("SchoolName", "SchoolID", dtSource);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schoolName"></param>
        /// <returns></returns>
        public IListControlsData BindControls(string schoolName)
        {
            DataTable dtSource = this.ListDataSource(schoolName);
            return new ListControlsDataSource("SchoolName", "SchoolID", dtSource);
        }
        /// <summary>
        /// 列表数据。
        /// </summary>
        /// <param name="schoolName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string schoolName)
        {
            string sort = "OrderNO,SchoolType desc,SchoolCode";
            if (string.IsNullOrEmpty(schoolName))
                return this.GetAllRecord(string.Empty, sort);
            return this.GetAllRecord(string.Format("(SchoolName like '%{0}%' or SchoolCode like '%{0}%')", schoolName), sort);
        }
        /// <summary>
        /// 获取首页学校单位数据。
        /// </summary>
        /// <returns></returns>
        public DataTable GetIndexUnits()
        {
            const string sql = "exec spSFITIndexTopUnit";
            return this.DatabaseAccess.ExecuteDataset(sql).Tables[0];
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteRecord(GUIDEx schoolID, out string err)
        {
            const string sql = "exec spSFITDeleteSchools '{0}'";
            string result = this.DatabaseAccess.ExecuteScalar(string.Format(sql, schoolID)).ToString();
            string[] array = result.Split('|');
            err = array[1];
            return array[0] == "0";
        }
        /// <summary>
        /// 加载学校信息。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool LoadTeaSyncSchool(ref School data, GUIDEx schoolID)
        {
            if (schoolID.IsValid)
            {
                SFITSchools sc = new SFITSchools();
                sc.SchoolID = schoolID;
                if (this.LoadRecord(ref sc))
                {
                    data.SchoolID = sc.SchoolID;
                    data.SchoolCode = sc.SchoolCode;
                    data.SchoolName = sc.SchoolName;
                    data.SchoolType = (EnumSchoolType)sc.SchoolType;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 获取学校数据对象集合。
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public OrgDepartmentCollection GetAllDepartment(string departmentID)
        {
            DataTable dtSource = null;
            if (string.IsNullOrEmpty(departmentID))
                dtSource = this.GetAllRecord();
            else
            {
                dtSource = this.GetAllRecord(string.Format("SchoolID='{0}'", departmentID));
                if (dtSource != null && dtSource.Rows.Count == 0)
                    dtSource = this.GetAllRecord(string.Format("SchoolCode like '%{0}%' or SchoolName like '%{0}%'", departmentID));
            }

            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                OrgDepartmentCollection collection = new OrgDepartmentCollection();
                foreach (DataRow row in dtSource.Rows)
                {
                    OrgDepartment data = new OrgDepartment();
                    data.DepartmentID = Convert.ToString(row["SchoolID"]);
                    data.DepartmentName = Convert.ToString(row["SchoolName"]);
                    data.Order = Convert.ToInt32(row["OrderNO"]);
                    collection.Add(data);
                }
                return collection;
            }
            return null;
        }
        #endregion

        #region 首页数据处理。
        /// <summary>
        /// 获取首页单位数据。
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IndexDataResult<IndexDatas> LoadIndexUnitData(int pageSize,int pageIndex)
        {
            const string sql = "select SchoolID,SchoolName from tblSFITSchools where (SchoolType = 1 or SchoolType = 2) order by SchoolName";
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            DataTable dtSource = this.LoadPagingData(sql, pageIndex, pageSize, out pindex, out psize, out pcount, out rcount);
            if (dtSource != null)
            {
                IndexDatas collection = new IndexDatas();
                foreach (DataRow row in dtSource.Rows)
                {
                    IndexData data = new IndexData();
                    data.ID = string.Format("{0}", row["SchoolID"]);
                    data.Name = string.Format("{0}", row["SchoolName"]);
                    collection.Add(data);
                }
                return new IndexDataResult<IndexDatas>(psize, pindex, pcount, rcount, collection);
            }
            return null;
        }
        #endregion
    }
}