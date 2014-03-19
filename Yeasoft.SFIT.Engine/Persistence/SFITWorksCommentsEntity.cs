//================================================================================
// FileName: SFITWorksCommentsEntity.cs
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

using Yaesoft.SFIT.Engine.Index;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITWorksCommentsEntity实体类。
	///</summary>
	internal class SFITWorksCommentsEntity: DbModuleEntity<SFITWorksComments>
	{
		#region 成员变量，构造函数。
        SFITStudentWorksEntity studentWorksEntity = null;
		///<summary>
		///构造函数
		///</summary>
		public SFITWorksCommentsEntity()
		{
            this.studentWorksEntity = new SFITStudentWorksEntity();
		}
		#endregion

        #region 重载。
        public override bool LoadRecord(ref SFITWorksComments entity)
        {
            bool result = base.LoadRecord(ref entity);
            if (result)
            {
                SFITStudentWorks data = new SFITStudentWorks();
                data.WorkID = entity.WorkID;
                if (result = this.studentWorksEntity.LoadRecord(ref data))
                {
                    entity.WorkName = data.WorkName;
                    entity.StudentInfo = string.Format("{0},{1},{2},{3}", data.StudentName, data.SchoolName, data.GradeName, data.ClassName);
                }
            }
            return result;
        }
        #endregion

        #region 数据操作函数
        /// <summary>
        /// 根据作品ID删除评论。
        /// </summary>
        /// <param name="workIDs"></param>
        /// <returns></returns>
        public bool DeleteRecordByWorkID(StringCollection workIDs)
        {
            bool result = false;
            if (workIDs != null && workIDs.Count > 0)
            {
                string[] ids = new string[workIDs.Count];
                workIDs.CopyTo(ids, 0);
                result = this.DeleteRecord(string.Format("WorkID in ('{0}')", string.Join("','", ids)));
            }
            return result;
        }
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx workID)
        {
            DataTable dtSource = this.GetAllRecord(string.Format("WorkID = '{0}'", workID));
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                dtSource.Columns.Add("StatusName", typeof(string));
                foreach (DataRow row in dtSource.Rows)
                {
                    row["StatusName"] = this.GetEnumMemberName(typeof(EnumCommentStatus), Convert.ToInt32(row["Status"]));
                }
            }
            return dtSource;
        }
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <param name="workID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx workID, EnumCommentStatus status)
        {
            DataTable dtSource = this.GetAllRecord(string.Format("WorkID = '{0}' and Status = '{1}'", workID, (int)status));
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                dtSource.Columns.Add("StatusName", typeof(string));
                foreach (DataRow row in dtSource.Rows)
                {
                    row["StatusName"] = this.GetEnumMemberName(typeof(EnumCommentStatus), Convert.ToInt32(row["Status"]));
                }
            }
            return dtSource;
        }
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="gradeID"></param>
        /// <param name="className"></param>
        /// <param name="catalogName"></param>
        /// <param name="studentName"></param>
        /// <param name="workName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string schoolName, GUIDEx gradeID, string className, string catalogName, string studentName, string workName)
        {
            const string sql = "exec spSFITWorksCommentsListView '{0}','{1}','{2}','{3}','{4}','{5}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolName, gradeID, className, catalogName, studentName, workName)).Tables[0];
        }
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="gradeID"></param>
        /// <param name="className"></param>
        /// <param name="catalogName"></param>
        /// <param name="studentName"></param>
        /// <param name="workName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx schoolID, GUIDEx gradeID, string className, string catalogName, string studentName, string workName)
        {
            const string sql = "exec spSFITWorksCommentsByUnitListView '{0}','{1}','{2}','{3}','{4}','{5}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolID, gradeID, className, catalogName, studentName, workName)).Tables[0];
        }
        /// <summary>
        /// 获取数据源。
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        public DataTable ListIndexDataSource(GUIDEx workID)
        {
            const string sql = "exec spSFITIndexAllComments '{0}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, workID)).Tables[0];
        }
        #endregion

        #region 加载评论数据到Index。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workID"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IndexDataResult<IndexComments> LoadCommentsData(GUIDEx workID,int pageSize, int pageIndex)
        {
            const string sql = "select ClientIP,Comment,CreateDateTime from {0} where WorkID = '{1}' and Status = 0";
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            string strSql = string.Format(sql, this.TableName, workID);
            DataTable dtSource = this.LoadPagingData(strSql, pageIndex, pageSize, out pindex, out psize, out pcount, out rcount);
            if (dtSource != null)
            {
                IndexComments collection = new IndexComments();
                foreach (DataRow row in dtSource.Rows)
                {
                    IndexComment data = new IndexComment();
                    data.IP = string.Format("{0}", row["ClientIP"]);
                    data.Comment = string.Format("{0}", row["Comment"]);
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(string.Format("{0}", row["CreateDateTime"]), out dt))
                    {
                        data.Time = dt;
                    }
                    collection.Add(data);
                }
                return new IndexDataResult<IndexComments>(psize, pindex, pcount, rcount, collection);
            }
            return null;
        }
        #endregion
    }
}
