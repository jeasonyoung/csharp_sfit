//================================================================================
// FileName: SFITGradeEntity.cs
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
	///SFITGradeEntity实体类。
	///</summary>
    internal class SFITGradeEntity : DbModuleEntity<SFITGrade>
    {
        #region 成员变量，构造函数。
        ///<summary>
        ///构造函数
        ///</summary>
        public SFITGradeEntity()
        {

        }
        #endregion

        #region 属性。
        /// <summary>
        /// 绑定年级数据。
        /// </summary>
        public IListControlsData BindGrade
        {
            get
            {
                return new ListControlsDataSource("GradeName", "GradeID", this.GetAllRecord(string.Empty, "OrderNO,GradeName"));
            }
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 列表数据源。
        /// </summary>
        /// <param name="learnLevelID"></param>
        /// <param name="gradeName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx learnLevelID, string gradeName)
        {
            string sort = "OrderNO,GradeName";
            if (learnLevelID.IsValid)
                return this.GetAllRecord(string.Format("LearnLevel = '{0}' and (GradeCode like '%{1}%' or GradeName like '%{1}%')", learnLevelID, gradeName), sort);
            return this.GetAllRecord(string.Format("(GradeCode like '%{0}%' or GradeName like '%{0}%')", gradeName), sort);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetIndexGrades()
        {
            string sql = "exec spSFITIndexTopGrade";
            return this.DatabaseAccess.ExecuteDataset(sql).Tables[0];
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="gradeID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteRecord(GUIDEx gradeID, out string err)
        {
            const string sql = "exec spSFITDeleteGrade '{0}'";
            string result = this.DatabaseAccess.ExecuteScalar(string.Format(sql, gradeID)).ToString();
            string[] array = result.Split('|');
            err = array[1];
            return array[0] == "0";
        }
        /// <summary>
        /// 加载年级数据。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public Grades LoadTeaSyncGrades(GUIDEx schoolID, GUIDEx teacherID)
        {
            const string sql = "exec spSFITeaSyncGrade '{0}','{1}'";
            if (schoolID.IsValid && teacherID.IsValid)
            {
                DataTable dtSource = this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolID, teacherID)).Tables[0];
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    Grades grades = new Grades();
                    foreach (DataRow row in dtSource.Rows)
                    {
                        Grade item = new Grade();
                        item.GradeID = Convert.ToString(row["GradeID"]);
                        item.GradeCode = Convert.ToString(row["GradeCode"]);
                        item.GradeName = Convert.ToString(row["GradeName"]);
                        item.OrderNO = Convert.ToInt32(row["OrderNO"]);

                        grades.Add(item);
                    }
                    return grades;
                }
            }
            return null;
        }
        #endregion

    }

}
