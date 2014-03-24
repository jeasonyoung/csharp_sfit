//================================================================================
// FileName: SFITClassEntity.cs
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
using Yaesoft.SFIT.Engine.Index;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITClassEntity实体类。
	///</summary>
	internal class SFITClassEntity: DbModuleEntity<SFITClass>
	{
		#region 成员变量，构造函数。
        SFITStudentsEntity studentsEntity;
		///<summary>
		///构造函数
		///</summary>
		public SFITClassEntity()
		{
            this.studentsEntity = new SFITStudentsEntity();
		}
		#endregion

        #region 重载。
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool LoadRecord(ref SFITClass entity)
        {
            bool result = false;
            if (result = base.LoadRecord(ref entity))
            {
                string[] gs = this.GetGradeID(entity.ClassID);
                if (gs != null && gs.Length > 0)
                {
                    entity.GradeID = string.Join(",", gs);
                }
                SFITSchools school = new SFITSchools();
                school.SchoolID = entity.SchoolID;
                if (new SFITSchoolsEntity().LoadRecord(ref school))
                    entity.SchoolName = school.SchoolName;
            }
            return result;
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 根据班级ID加载班级名称。
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string LoadClassName(String classId)
        {
            if (string.IsNullOrEmpty(classId)) return null;
            SFITClass data = new SFITClass();
            data.ClassID = classId;
            if (base.LoadRecord(ref data))
            {
                return data.ClassName;
            }
            return null;
        }
        /// <summary>
        /// 绑定班级数据。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <returns></returns>
        public IListControlsData BindClass(GUIDEx schoolID)
        {
            DataTable dtSource = this.GetAllRecord(string.Format("SchoolID = '{0}'", schoolID), "OrderNO,ClassName");
            if (dtSource != null)
            {
                dtSource.Columns.Add("ClassCodeName", typeof(string));
                foreach (DataRow row in dtSource.Rows)
                {
                    row["ClassCodeName"] = string.Format("{0}(班级代码：{1})", row["ClassName"], row["ClassCode"]);
                }
                return new ListControlsDataSource("ClassCodeName", "ClassID", dtSource);
            }
            return null;
        }
        /// <summary>
        /// 绑定任课教师所属课程班级数据。
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public IListControlsData BindClassByTeacher(GUIDEx teacherID)
        {
            DataTable dtSource = this.GetAllRecord(string.Format("ClassID in (select ClassID from tblSFITTeaClass where TeacherID = '{0}')", teacherID), "OrderNO,ClassName");
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                return new ListControlsDataSource("ClassName", "ClassID", dtSource);
            }
            return null;
        }
        /// <summary>
        /// 绑定班级数据。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="gradeID"></param>
        /// <returns></returns>
        public IListControlsData BindClass(GUIDEx schoolID, GUIDEx gradeID)
        {
            const string sql = "select ClassID,ClassName from vwSFITGradeClass where SchoolID = '{0}' and GradeID = '{1}' order by OrderNO,ClassName";
            DataTable dtSource = this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolID, gradeID)).Tables[0];
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                return new ListControlsDataSource("ClassName", "ClassID", dtSource);
            }
            return null;
        }
        /// <summary>
        /// 列表数据源。
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="gradeID"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string schoolName, string gradeID, string className)
        {
            const string sql = "exec spSFITClassListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolName, gradeID, className)).Tables[0];
        }
        /// <summary>
        /// 根据班级ID获取年级ID。
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public string[] GetGradeID(GUIDEx classID)
        {
            const string sql = "select GradeID from vwSFITGradeClass where ClassID = '{0}'";
            if (classID.IsValid)
            {
                DataSet set = this.DatabaseAccess.ExecuteDataset(string.Format(sql, classID));
                if (set != null && set.Tables.Count > 0)
                {
                    DataTable dt = set.Tables[0].Copy();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        List<string> list = new List<string>();
                        foreach (DataRow row in dt.Rows)
                        {
                            list.Add(Convert.ToString(row[0]));
                        }
                        return list.ToArray();
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteRecord(GUIDEx classID, out string err)
        {
            const string sql = "exec spSFITDeleteClass '{0}'";
            string result = this.DatabaseAccess.ExecuteScalar(string.Format(sql, classID)).ToString();
            string[] array = result.Split('|');
            err = array[1];
            return array[0] == "0";
        }

        /// <summary>
        /// 加载年级班级。
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public bool LoadTeaSyncClassStudents(Grade grade, GUIDEx teacherID)
        {
            bool result = false;
            if (grade != null && teacherID.IsValid)
            {
                const string sql = "exec spSFITeaSyncClass '{0}','{1}'";
                DataTable dtSource = this.DatabaseAccess.ExecuteDataset(string.Format(sql, grade.GradeID, teacherID)).Tables[0];
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    foreach (DataRow row in dtSource.Rows)
                    {
                        Class c = new Class();
                        c.ClassID = Convert.ToString(row["ClassID"]);
                        c.ClassCode = Convert.ToString(row["ClassCode"]);
                        c.ClassName = Convert.ToString(row["ClassName"]);
                        c.OrderNO = Convert.ToInt32(row["OrderNO"]);

                        this.studentsEntity.LoadTeaSyncStudents(ref c);

                        grade.Classes.Add(c);
                    }
                }
            }
            return result;
        }
        #endregion

        #region 首页学校班级数据。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IndexDataResult<IndexDatas> LoadIndexUnitClasses(string uid, int pageSize, int pageIndex)
        {
            string sql = string.Format("select ClassID,ClassName from vwSFITClasses where SchoolID = '{0}' order by JoinYear desc,OrderNO", uid);
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            DataTable dtSource = this.LoadPagingData(sql, pageIndex, pageSize, out pindex, out psize, out pcount, out rcount);
            if (dtSource != null)
            {
                IndexDatas collection = new IndexDatas();
                foreach (DataRow row in dtSource.Rows)
                {
                    IndexData data = new IndexData();
                    data.ID = string.Format("{0}", row["ClassID"]);
                    data.Name = string.Format("{0}", row["ClassName"]);
                    collection.Add(data);
                }
                return new IndexDataResult<IndexDatas>(psize, pindex, pcount, rcount, collection);
            }
            return null;
        }
        #endregion
    }

}
