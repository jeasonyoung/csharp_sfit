//================================================================================
// FileName: SFITStudentWorksEntity.cs
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
	///SFITStudentWorksEntity实体类。
	///</summary>
    internal class SFITStudentWorksEntity : DbModuleEntity<SFITStudentWorks>
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schoolEntity = null;
        SFITGradeEntity gradeEntity = null;
        SFITClassEntity classEntity = null;
        SFITCatalogEntity catalogEntity = null;

        SFITStudentsEntity studentsEntity = null;
        SFITStudentAttachmentEntity studentAttachmentEntity = null;
        SFITeaReviewStudentEntity teaReviewStudentEntity = null;
        ///<summary>
        ///构造函数
        ///</summary>
        public SFITStudentWorksEntity()
        {
            this.schoolEntity = new SFITSchoolsEntity();
            this.gradeEntity = new SFITGradeEntity();
            this.classEntity = new SFITClassEntity();
            this.catalogEntity = new SFITCatalogEntity();

            this.studentsEntity = new SFITStudentsEntity();
            this.studentAttachmentEntity = new SFITStudentAttachmentEntity();
            this.teaReviewStudentEntity = new SFITeaReviewStudentEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 重载。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool LoadRecord(ref SFITStudentWorks entity)
        {
            bool result = false;
            if (result = base.LoadRecord(ref entity))
            {
                SFITStudents data = new SFITStudents();
                data.StudentID = entity.StudentID;
                if (result = this.studentsEntity.LoadRecord(ref data))
                {
                    entity.StudentCode = data.StudentCode;
                    entity.StudentName = data.StudentName;
                }
            }
            return result;
        }
        /// <summary>
        /// 重载删除数据。
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public override bool DeleteRecord(StringCollection primaryValues)
        {
            this.teaReviewStudentEntity.DeleteRecord(primaryValues);
            new SFITWorksCommentsEntity().DeleteRecordByWorkID(primaryValues);
            this.studentAttachmentEntity.DeleteRecordByWorkID(primaryValues);
            return base.DeleteRecord(primaryValues);
        }
        #endregion

        #region 更新点击量。
        /// <summary>
        /// 更新点击量。
        /// </summary>
        /// <param name="workID"></param>
        public void UpdateHits(GUIDEx workID)
        {
            if (workID.IsValid)
            {
                SFITStudentWorks data = new SFITStudentWorks();
                data.WorkID = workID;
                if (base.LoadRecord(ref data))
                {
                    data.Hits += 1;
                    base.UpdateRecord(data);
                }
            }
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 获取列表数据。
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="gradeID"></param>
        /// <param name="className"></param>
        /// <param name="studentName"></param>
        /// <param name="workStatus"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string schoolName, GUIDEx gradeID, string className, string studentName,string workName, GUIDEx workStatus)
        {
            const string sql = "exec spSFITStudentWorksListView '{0}','{1}','{2}','{3}','{4}','{5}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolName, gradeID, className, studentName,workName, workStatus)).Tables[0];
        }
        /// <summary>
        /// 获取列表数据。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="gradeID"></param>
        /// <param name="className"></param>
        /// <param name="studentName"></param>
        /// <param name="workName"></param>
        /// <param name="workStatus"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx schoolID, GUIDEx gradeID, string className, string studentName, string workName, GUIDEx workStatus)
        {
            const string sql = "exec spSFITStudentWorksByUnitListView '{0}','{1}','{2}','{3}','{4}','{5}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolID, gradeID, className, studentName, workName, workStatus)).Tables[0];
        }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="classID"></param>
        /// <param name="studentName"></param>
        /// <param name="workName"></param>
        /// <param name="workStatus"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx schoolID, GUIDEx classID, string studentName,string workName, GUIDEx workStatus)
        {
            const string sql = "exec spSFITStudentWorksByTeaListView '{0}','{1}','{2}','{3}','{4}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolID, classID, studentName, workName, workStatus)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="schoolName"></param>
        /// <param name="gradeName"></param>
        /// <param name="className"></param>
        /// <param name="catalogName"></param>
        /// <param name="workName"></param>
        /// <param name="workStatus"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx studentID, string schoolName, string gradeName, string className, string catalogName, string workName, GUIDEx workStatus)
        {
            const string sql = "exec spSFITStudentWorksQueryListView '{0}','{1}','{2}','{3}','{4}','{5}','{6}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, studentID, schoolName, gradeName, className, catalogName, workName, workStatus)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public DataTable LoadAllWorkItems(GUIDEx unitID, GUIDEx gradeID, GUIDEx catalogID, string query)
        {
            const string sql = "exec spSFITIndexAllWorks '{0}','{1}','{2}','{3}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, unitID, gradeID, catalogID,query)).Tables[0];
        }
        /// <summary>
        /// 上传作品。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UploadWorks(GUIDEx schoolID, StudentWorkTeaUpload data)
        {
            bool result = false;
            if (schoolID.IsValid && data != null && data.Files != null)
            {
                SFITStudentWorks work = new SFITStudentWorks();
                work.WorkID = data.WorkID;

                if (data.Files.OffSet == 0)
                {
                    #region 保存作业数据。

                    work.WorkName = data.WorkName;
                    work.WorkStatus = (int)data.Status;
                    work.WorkType = (int)data.Type;
                    work.CheckCode = data.CheckCode;

                    #region 学校
                    work.SchoolID = schoolID;
                    SFITSchools sch = new SFITSchools();
                    sch.SchoolID = work.SchoolID;
                    if (this.schoolEntity.LoadRecord(ref sch))
                    {
                        work.SchoolName = sch.SchoolName;
                    }
                    else
                    {
                        throw new Exception(string.Format("学校ID[{0}]不存在！", work.SchoolID));
                    }
                    #endregion

                    #region 年级。
                    work.GradeID = data.GradeID;
                    SFITGrade g = new SFITGrade();
                    g.GradeID = work.GradeID;
                    if (this.gradeEntity.LoadRecord(ref g))
                    {
                        work.GradeName = g.GradeName;
                    }
                    else
                    {
                        throw new Exception(string.Format("年级ID[{0}]不存在！", work.GradeID));
                    }
                    #endregion

                    #region 班级。
                    work.ClassID = data.ClassID;
                    SFITClass c = new SFITClass();
                    c.ClassID = work.ClassID;
                    if (this.classEntity.LoadRecord(ref c))
                    {
                        work.ClassName = c.ClassName;
                    }
                    else
                    {
                        throw new Exception(string.Format("年级ID[{0}]不存在！", work.ClassID));
                    }
                    #endregion

                    if (data.Student != null)
                    {
                        work.StudentID = data.Student.StudentID;
                        work.StudentName = data.Student.StudentName;
                    }

                    #region 科目。
                    work.CatalogID = data.CatalogID;
                    SFITCatalog cata = new SFITCatalog();
                    cata.CatalogID = work.CatalogID;
                    if (this.catalogEntity.LoadRecord(ref cata))
                    {
                        work.CatalogName = cata.CatalogName;
                    }
                    else
                    {
                        throw new Exception(string.Format("科目ID[{0}]不存在！", work.CatalogID));
                    }
                    #endregion

                    work.CreateDateTime = DateTime.Now;
                    work.WorkDescription = data.Description;

                    if (data.Review != null)
                    {
                        work.CreateEmployeeID = data.Review.TeacherID;
                        work.CreateEmployeeName = data.Review.TeacherName;
                    }

                    #region 教师评价。
                    if ((result = this.UpdateRecord(work)) && data.Review != null && new GUIDEx(data.Review.TeacherID).IsValid)
                    {
                        SFITeaReviewStudent srs = new SFITeaReviewStudent();
                        srs.WorkID = work.WorkID;
                        srs.TeacherID = data.Review.TeacherID;
                        srs.TeacharName = data.Review.TeacherName;
                        srs.EvaluateType = (int)data.Review.EvaluateType;
                        srs.ReviewValue = data.Review.ReviewValue;
                        srs.SubjectiveReviews = data.Review.SubjectiveReviews;
                        srs.CreateDateTime = DateTime.Now;
                        srs.CreateEmployeeID = data.Review.TeacherID;
                        srs.CreateEmployeeName = data.Review.TeacherName;

                        result = this.teaReviewStudentEntity.UpdateRecord(srs);
                    }
                    #endregion
                    #endregion
                }
                else
                {
                    result = true;
                }
                //附件处理。
                if (result)
                {
                    result = this.studentAttachmentEntity.UploadStudentAttachment(work.WorkID, work.CheckCode, data.Files, work.CreateEmployeeID, work.CreateEmployeeName);
                }
            }
            return result;
        }
        #endregion

        #region 首页作品数据列表。
        /// <summary>
        /// 获取最新作品。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IndexDataResult<IndexNewWorks> LoadNewWorks(string uid, string cid,string sid, string st, int pageSize, int pageIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select SchoolID,SchoolName,ClassID,ClassName,CatalogID,CatalogName,Works,CreateDateTime from vwSFITNewWorks ");
            if (!string.IsNullOrEmpty(uid) || !string.IsNullOrEmpty(cid) || !string.IsNullOrEmpty(sid) || !string.IsNullOrEmpty(st))
            {
                builder.Append(" where ");
                bool flag = false;
                if ((flag = !string.IsNullOrEmpty(uid)))
                {
                    builder.AppendFormat(" SchoolID = '{0}' ", uid);
                }

                if (!string.IsNullOrEmpty(cid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" ClassID='{0}' ", cid);
                    flag = true;
                }

                if (!string.IsNullOrEmpty(sid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" CatalogID='{0}' ", sid);
                    flag = true;
                }
                if (!string.IsNullOrEmpty(st))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" convert(nvarchar(7),CreateDateTime,121) = '{0}'", st);
                }
            }
            builder.Append(" order by CreateDateTime desc");
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            DataTable dtSource = this.LoadPagingData(builder.ToString(), pageIndex, pageSize, out pindex, out psize, out pcount, out rcount);
            if (dtSource != null)
            {
                IndexNewWorks collection = new IndexNewWorks();
                foreach (DataRow row in dtSource.Rows)
                {
                    IndexNewWork data = new IndexNewWork();
                    data.UID = string.Format("{0}", row["SchoolID"]);
                    data.UName = string.Format("{0}", row["SchoolName"]);
                    data.CID = string.Format("{0}", row["ClassID"]);
                    data.CName = string.Format("{0}", row["ClassName"]);
                    data.SID = string.Format("{0}", row["CatalogID"]);
                    data.SName = string.Format("{0}", row["CatalogName"]);
                    data.Works = Convert.ToInt32(row["Works"]);
                    data.Time = Convert.ToDateTime(row["CreateDateTime"]);
                    collection.Add(data);
                }
                return new IndexDataResult<IndexNewWorks>(psize, pindex, pcount, rcount, collection);
            }
            return null;
        }
        /// <summary>
        /// 获取点击率最高作品。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="sid"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IndexDataResult<IndexHotWorks> LoadHotWorks(string uid,string cid,string sid, string st,int pageSize, int pageIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" select WorkID,WorkName,SchoolName,ClassName,StudentName,Hits,CreateDateTime from vwSFITHotWorks ");
            if (!string.IsNullOrEmpty(uid) || !string.IsNullOrEmpty(cid) || !string.IsNullOrEmpty(sid) || !string.IsNullOrEmpty(st))
            {
                builder.Append(" where ");
                bool flag = false;
                if ((flag = !string.IsNullOrEmpty(uid)))
                {
                    builder.AppendFormat("SchoolID='{0}' ", uid);
                }
                if (!string.IsNullOrEmpty(cid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" ClassID='{0}' ", cid);
                    flag = true;
                }
                if (!string.IsNullOrEmpty(sid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" CatalogID='{0}' ", sid);
                    flag = true;
                }
                if (!string.IsNullOrEmpty(st))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" convert(nvarchar(7),CreateDateTime,121) = '{0}'", st);
                }
            }
            builder.Append(" order by Hits desc");
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            DataTable dtSource = this.LoadPagingData(builder.ToString(), pageIndex, pageSize, out pindex, out psize, out pcount, out rcount);
            if (dtSource != null)
            {
                IndexHotWorks collection = new IndexHotWorks();
                foreach (DataRow row in dtSource.Rows)
                {
                    IndexHotWork data = new IndexHotWork();
                    data.WID = string.Format("{0}", row["WorkID"]);
                    data.WName = string.Format("{0}", row["WorkName"]);
                    data.UName = string.Format("{0}", row["SchoolName"]);
                    data.CName = string.Format("{0}", row["ClassName"]);
                    data.SName = string.Format("{0}", row["StudentName"]);
                    data.Hits = Convert.ToInt32(row["Hits"]);
                    data.Time = Convert.ToDateTime(row["CreateDateTime"]);
                    collection.Add(data);
                }
                return new IndexDataResult<IndexHotWorks>(psize, pindex, pcount, rcount, collection);
            }
            return null;
        }
        /// <summary>
        /// 获取最优作品。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="sid"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IndexDataResult<IndexBastWorks> LoadBestWorks(string uid, string cid,string sid, string st, int pageSize, int pageIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select WorkID,WorkName,SchoolName,ClassName,StudentName,ReviewValue,SubjectiveReviews, CreateDateTime from vwSFITBestWorks ");
            if (!string.IsNullOrEmpty(uid) || !string.IsNullOrEmpty(cid) || !string.IsNullOrEmpty(sid) || !string.IsNullOrEmpty(st))
            {
                builder.Append(" where ");
                bool flag = false;
                if ((flag = !string.IsNullOrEmpty(uid)))
                {
                    builder.AppendFormat("SchoolID='{0}' ", uid);
                }
                if (!string.IsNullOrEmpty(cid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" ClassID='{0}' ", cid);
                    flag = true;
                }
                if (!string.IsNullOrEmpty(sid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" CatalogID='{0}' ", sid);
                    flag = true;
                }
                if (!string.IsNullOrEmpty(st))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" convert(nvarchar(7),CreateDateTime,121) = '{0}'", st);
                }
            }
            builder.Append(" order by ReviewValue, CreateDateTime desc");
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            DataTable dtSource = this.LoadPagingData(builder.ToString(), pageIndex, pageSize, out pindex, out psize, out pcount, out rcount);
            if (dtSource != null)
            {
                IndexBastWorks collection = new IndexBastWorks();
                foreach (DataRow row in dtSource.Rows)
                {
                    IndexBastWork data = new IndexBastWork();
                    data.WID = string.Format("{0}", row["WorkID"]);
                    data.WName = string.Format("{0}", row["WorkName"]);
                    data.UName = string.Format("{0}", row["SchoolName"]);
                    data.CName = string.Format("{0}", row["ClassName"]);
                    data.SName = string.Format("{0}", row["StudentName"]);
                    data.Value = string.Format("{0}", row["ReviewValue"]);
                    data.SubRev = string.Format("{0}", row["SubjectiveReviews"]);
                    data.Time = Convert.ToDateTime(row["CreateDateTime"]);
                    collection.Add(data);
                }
                return new IndexDataResult<IndexBastWorks>(psize, pindex, pcount, rcount, collection);
            }
            return null;
        }
        /// <summary>
        /// 获取全部作业。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="sid"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IndexDataResult<IndexAllWorks> LoadAllWorks(string uid, string cid, string sid,string st, int pageSize, int pageIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select WorkID,WorkName,SchoolName,ClassName,CatalogName,StudentName,ReviewValue,SubjectiveReviews, CreateDateTime from vwSFITALLWorks ");
            if (!string.IsNullOrEmpty(uid) || !string.IsNullOrEmpty(cid) || !string.IsNullOrEmpty(sid) || !string.IsNullOrEmpty(st))
            {
                builder.Append(" where ");
                bool flag = false;
                if ((flag = !string.IsNullOrEmpty(uid)))
                {
                    builder.AppendFormat("SchoolID='{0}' ", uid);
                }
                if (!string.IsNullOrEmpty(cid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" ClassID='{0}' ", cid);
                    flag = true;
                }
                if (!string.IsNullOrEmpty(sid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" CatalogID='{0}' ", sid);
                    flag = true;
                }
                if (!string.IsNullOrEmpty(st))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" convert(nvarchar(7),CreateDateTime,121) = '{0}'", st);
                }
            }
            builder.Append(" order by ReviewValue, CreateDateTime desc");
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            DataTable dtSource = this.LoadPagingData(builder.ToString(), pageIndex, pageSize, out pindex, out psize, out pcount, out rcount);
            if (dtSource != null)
            {
                IndexAllWorks collection = new IndexAllWorks();
                foreach (DataRow row in dtSource.Rows)
                {
                    IndexAllWork data = new IndexAllWork();
                    data.ID = string.Format("{0}", row["WorkID"]);
                    data.Name = string.Format("{0}", row["WorkName"]);
                    data.UName = string.Format("{0}", row["SchoolName"]);
                    data.CName = string.Format("{0}", row["ClassName"]);
                    data.SName = string.Format("{0}", row["CatalogName"]);
                    data.StuName = string.Format("{0}", row["StudentName"]);
                    data.Value = string.Format("{0}", row["ReviewValue"]);
                    data.SubRev = string.Format("{0}", row["SubjectiveReviews"]);
                    data.Time = Convert.ToDateTime(row["CreateDateTime"]);
                    collection.Add(data);
                }
                return new IndexDataResult<IndexAllWorks>(psize, pindex, pcount, rcount, collection);
            }
            return null;
        }
        /// <summary>
        /// 获取作业时间。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IndexDataResult<IndexDatas> LoadWorksTime(string uid, string cid, int pageSize, int pageIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select WorkTime from vwSFITWorksTime ");
            if (!string.IsNullOrEmpty(uid) || !string.IsNullOrEmpty(cid))
            {
                bool flag = false;
                builder.Append(" where ");
                if ((flag = !string.IsNullOrEmpty(uid)))
                {
                    builder.AppendFormat(" SchoolID = '{0}'", uid);
                }
                if (!string.IsNullOrEmpty(cid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" ClassID = '{0}' ", cid);
                }
            }
            builder.Append(" group by WorkTime order by WorkTime desc ");
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            DataTable dtSource = this.LoadPagingData(builder.ToString(), pageIndex, pageSize, out pindex, out psize, out pcount, out rcount);
            if (dtSource != null)
            {
                IndexDatas collection = new IndexDatas();
                foreach (DataRow row in dtSource.Rows)
                {
                    IndexData data = new IndexData();
                    data.ID = data.Name = string.Format("{0}", row["WorkTime"]);
                    collection.Add(data);
                }
                return new IndexDataResult<IndexDatas>(psize, pindex, pcount, rcount, collection);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="sid"></param>
        /// <param name="st"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IndexDataResult<IndexAllWorks> LoadSearchWorks(string uid, string cid, string sid, string st, int pageSize, int pageIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select WorkID,WorkName,SchoolName,ClassName,CatalogName,StudentName,ReviewValue,SubjectiveReviews, CreateDateTime from vwSFITALLWorks ");
            if (!string.IsNullOrEmpty(uid) || !string.IsNullOrEmpty(cid) || !string.IsNullOrEmpty(sid) || (!string.IsNullOrEmpty(st) && (st != "|")))
            {
                builder.Append(" where ");
                bool flag = false;
                if ((flag = !string.IsNullOrEmpty(uid)))
                {
                    builder.AppendFormat(" (SchoolName like '%{0}%') ", uid);
                }
                if (!string.IsNullOrEmpty(cid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" (ClassName like '%{0}%') ", cid);
                    flag = true;
                }
                if (!string.IsNullOrEmpty(sid))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    builder.AppendFormat(" (CatalogName like '%{0}%') ", sid);
                    flag = true;
                }
                if (!string.IsNullOrEmpty(st) && (st != "|"))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    string[] date = st.Split('|');
                    string start = date[0], end = string.Empty;
                    if (date.Length > 1)
                    {
                        end = date[1];
                    }
                    if (!string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
                    {
                        end = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                        builder.AppendFormat(" (convert(nvarchar(10),CreateDateTime,121) between '{0}' and '{1}') ", start, end);
                    }
                    else if (string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                    {
                        builder.AppendFormat(" (convert(nvarchar(10),CreateDateTime,121) = '{0}') ", end);
                    }
                    else
                    {
                        builder.AppendFormat(" (convert(nvarchar(10),CreateDateTime,121) between '{0}' and '{1}') ", start, end);
                    }
                }
            }
            builder.Append(" order by ReviewValue, CreateDateTime desc");
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            DataTable dtSource = this.LoadPagingData(builder.ToString(), pageIndex, pageSize, out pindex, out psize, out pcount, out rcount);
            if (dtSource != null)
            {
                IndexAllWorks collection = new IndexAllWorks();
                foreach (DataRow row in dtSource.Rows)
                {
                    IndexAllWork data = new IndexAllWork();
                    data.ID = string.Format("{0}", row["WorkID"]);
                    data.Name = string.Format("{0}", row["WorkName"]);
                    data.UName = string.Format("{0}", row["SchoolName"]);
                    data.CName = string.Format("{0}", row["ClassName"]);
                    data.SName = string.Format("{0}", row["CatalogName"]);
                    data.StuName = string.Format("{0}", row["StudentName"]);
                    data.Value = string.Format("{0}", row["ReviewValue"]);
                    data.SubRev = string.Format("{0}", row["SubjectiveReviews"]);
                    data.Time = Convert.ToDateTime(row["CreateDateTime"]);
                    collection.Add(data);
                }
                return new IndexDataResult<IndexAllWorks>(psize, pindex, pcount, rcount, collection);
            }
            return null;
        }
        /// <summary>
        /// 加载报表数据。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="sid"></param>
        /// <param name="st"></param>
        /// <param name="page"></param>
        /// <param name="index"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public CallAjaxDataGridResult<IndexReport> LoadRptData(string uid, string cid, string studentId, string sid, string st, int page, int index, string sort, string order)
        {
            CallAjaxDataGridResult<IndexReport> result = new CallAjaxDataGridResult<IndexReport>();
            string sql = null;
            string start = null, end = null;

            #region 拆分日期。
            if (!string.IsNullOrEmpty(st) && st != "|")
            {
                string[] array = st.Split('|');
                start = array[0];
                if (array.Length > 1)
                {
                    end = array[1];
                }
            }
            #endregion

            IndexReports collection = null;
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            DataTable dtSource = null;

            if (!string.IsNullOrEmpty(studentId))//学生作品统计。
            {
                #region 学生作品。
                sql = this.createRptStudentSql(studentId, sid, start, end, sort, order);
                dtSource = this.LoadPagingData(sql, index, page, out pindex, out psize, out pcount, out rcount);
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    collection = new IndexReports();
                    foreach (DataRow row in dtSource.Rows)
                    {
                        IndexReport data = new IndexReport();
                        data.StudentName = string.Format("{0}", row["StudentName"]);
                        data.WorkID = string.Format("{0}", row["WorkID"]);
                        data.WorkName = string.Format("{0}", row["WorkName"]);
                        data.ReviewValue = string.Format("{0}", row["ReviewValue"]);
                        data.SRCount = Convert.ToInt32(string.Format("{0}", row["SRCount"]));
                        data.CreateTime = string.Format("{0}", row["CreateTime"]);
                        collection.Add(data);
                    }
                }
                #endregion
            }
            else if (!string.IsNullOrEmpty(cid))//班级作品统计。
            {
                #region 班级作品统计。
                sql = this.createRptClassSql(cid, sid, start, end, sort, order);
                dtSource = this.LoadPagingData(sql, index, page, out pindex, out psize, out pcount, out rcount);
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    collection = new IndexReports();
                    foreach (DataRow row in dtSource.Rows)
                    {
                        IndexReport data = new IndexReport();
                        data.StudentID = string.Format("{0}", row["StudentID"]);
                        data.StudentName = string.Format("{0}", row["StudentName"]);
                        data.WorkCount = Convert.ToInt32(string.Format("{0}", row["WorkCount"]));
                        data.SRCount = Convert.ToInt32(string.Format("{0}", row["SRCount"]));
                        data.Score = string.Format("{0}", row["Score"]);
                        collection.Add(data);
                    }
                }
                #endregion
            }
            else if (!string.IsNullOrEmpty(uid))//学校作品统计。
            {
                #region 学校作品统计。
                sql = this.createRptUnitSql(uid, sid, start, end, sort, order);
                dtSource = this.LoadPagingData(sql, index, page, out pindex, out psize, out pcount, out rcount);
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    collection = new IndexReports();
                    foreach (DataRow row in dtSource.Rows)
                    {
                        IndexReport data = new IndexReport();
                        data.ClassID = string.Format("{0}", row["ClassID"]);
                        data.ClassName = string.Format("{0}", row["ClassName"]);
                        data.StudentCount = Convert.ToInt32(string.Format("{0}", row["StudentCount"]));
                        data.WorkCount = Convert.ToInt32(string.Format("{0}", row["WorkCount"]));
                        data.AvgCount = (float)Convert.ToDouble(string.Format("{0}", row["AvgCount"]));
                        data.SRCount = Convert.ToInt32(string.Format("{0}", row["SRCount"]));
                        data.Score = string.Format("{0}", row["Score"]);
                        collection.Add(data);
                    }
                }
                #endregion
            }
            else
            {
                #region 全区作品统计。
                sql = this.createRptAllSql(sid, start, end, sort, order);
                dtSource = this.LoadPagingData(sql, index, page, out pindex, out psize, out pcount, out rcount);
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    collection = new IndexReports();
                    foreach (DataRow row in dtSource.Rows)
                    {
                        IndexReport data = new IndexReport();
                        data.UnitID = string.Format("{0}", row["UnitID"]);
                        data.UnitName = string.Format("{0}", row["UnitName"]);
                        data.ClassCount = Convert.ToInt32(string.Format("{0}", row["ClassCount"]));
                        data.StudentCount = Convert.ToInt32(string.Format("{0}", row["StudentCount"]));
                        data.WorkCount = Convert.ToInt32(string.Format("{0}", row["WorkCount"]));
                        data.AvgCount = (float)Convert.ToDouble(string.Format("{0}", row["AvgCount"]));
                        data.SRCount = Convert.ToInt32(string.Format("{0}", row["SRCount"]));
                        data.Score = string.Format("{0}", row["Score"]);
                        collection.Add(data);
                    }
                }
                #endregion
            }
            
            #region 初始化数据。
            if ((result.Success = (result.total = rcount) > 0) && collection != null)
            {
                IndexReport[] rows = new IndexReport[collection.Count];
                collection.CopyTo(rows, 0);
                result.rows = rows;
            }
            else
            {
                result.rows = new IndexReport[0];
            }
            #endregion
            return result;
        }
        #endregion

        #region 辅助函数。
        //全区报表数据。
        private string createRptAllSql(string sid, string start, string end, string sort, string order)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select H.UnitID,H.UnitName,H.ClassCount,H.StudentCount,H.WorkCount,H.AvgCount,H.SRCount,H.Score ");
            sql.Append(" from ( ");
            sql.Append("    select k.SchoolID as UnitID,k.SchoolName as UnitName,k.ClassCount,k.StudentCount,k.WorkCount,");
            sql.Append("           round((case when isnull(k.StudentCount,0) = 0 then 0 else cast(k.WorkCount as float)/k.StudentCount end),2) as AvgCount, ");
            sql.Append("           isnull(k.SRCount,0) as SRCount,isnull(k.Score,0) as Score ");
            sql.Append("    from ( ");
            sql.Append("            select a.SchoolID,a.SchoolName,COUNT(b.ClassID) as ClassCount,");
            sql.Append("            ( ");
            sql.Append("	            select COUNT(c.StudentID) ");
            sql.Append("	            from tblSFITClassStudents c ");
            sql.Append("	            inner join tblSFITClass d ");
            sql.Append("	            on d.ClassID = c.ClassID ");
            sql.Append("	            where d.SchoolID = a.SchoolID ");
            sql.Append("            ) as StudentCount,");
            sql.Append("            ( ");
            sql.Append("	          select COUNT(e.WorkID)  ");
            sql.Append("	          from vwSFITStudentWorks e ");
            sql.Append("	          where e.SchoolID = a.SchoolID ");
            if (!string.IsNullOrEmpty(start) || !string.IsNullOrEmpty(end))
            {
                sql.Append("          and ");
                if (!string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),e.CreateDateTime,121) between '{0}' and '{1:yyyy-MM-dd}')  ", start, DateTime.Now);
                }
                else if (string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("   (convert(nvarchar(10),e.CreateDateTime,121) like '{0}%')  ", start);
                }
                else
                {
                    sql.AppendFormat("   (convert(nvarchar(10),e.CreateDateTime,121) between '{0}' and '{1}')  ", start, end);
                }
            }
            if (!string.IsNullOrEmpty(sid))
            {
                sql.AppendFormat("   and e.CatalogID = '{0}' ", sid);
            }
            sql.Append("          ) as WorkCount,");
            sql.Append("         ( ");
            sql.Append("	        select sum(case when isnull(f.SubjectiveReviews,'') = '' then 0 else 1 end) ");
            sql.Append("	        from vwSFITStudentWorks f ");
            //sql.Append("	        left outer join tblSFITeaReviewStudent g ");
            //sql.Append("	        on g.WorkID = f.WorkID ");
            sql.Append("	        where f.SchoolID = a.SchoolID ");
            if (!string.IsNullOrEmpty(start) || !string.IsNullOrEmpty(end))
            {
                sql.Append("        and ");
                if (!string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),f.CreateDateTime,121) between '{0}' and '{1:yyyy-MM-dd}') ", start, DateTime.Now);
                }
                else if (string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),f.CreateDateTime,121) like '{0}%') ", start);
                }
                else
                {
                    sql.AppendFormat("  (convert(nvarchar(10),f.CreateDateTime,121) between '{0}' and '{1}') ", start, end);
                }
            }
            if (!string.IsNullOrEmpty(sid))
            {
                sql.AppendFormat("  and f.CatalogID = '{0}' ", sid);
            }
            sql.Append("        ) as SRCount,");
            sql.Append("        (  ");
            sql.Append("	        select cast(sum(case when (p.ReviewValue = 'A') then 1 else 0 end) as nvarchar(10)) + 'A'+ ");
            sql.Append("	               cast(sum(case when (p.ReviewValue = 'B') then 1 else 0 end) as nvarchar(10)) + 'B'+ ");
            sql.Append("	               cast(sum(case when (p.ReviewValue = 'C') then 1 else 0 end) as nvarchar(10)) + 'C'+ ");
            sql.Append("	               cast(sum(case when (p.ReviewValue = 'D') then 1 else 0 end) as nvarchar(10)) + 'D' ");
            sql.Append("	        from vwSFITStudentWorks p ");
            //sql.Append("	        left outer join tblSFITeaReviewStudent i ");
            //sql.Append("	        on i.WorkID = p.WorkID ");
            sql.Append("	        where p.SchoolID = a.SchoolID ");
            if (!string.IsNullOrEmpty(start) || !string.IsNullOrEmpty(end))
            {
                sql.Append("        and ");
                if (!string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),p.CreateDateTime,121) between '{0}' and '{1:yyyy-MM-dd}')", start, DateTime.Now);
                }
                else if (string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),p.CreateDateTime,121) like '{0}%')", start);
                }
                else
                {
                    sql.AppendFormat("  (convert(nvarchar(10),p.CreateDateTime,121) between '{0}' and '{1}')", start, end);
                }
            }
            if (!string.IsNullOrEmpty(sid))
            {
                sql.AppendFormat(" and p.CatalogID = '{0}' ", sid);
            }
            sql.Append("        )as Score ");
            sql.Append("        from tblSFITSchools a ");
            sql.Append("        inner join tblSFITClass b ");
            sql.Append("        on b.SchoolID = a.SchoolID ");
            sql.Append("        group by a.SchoolID,a.SchoolName ");
            sql.Append("    ) k  ");
            sql.Append("  ) H ");
            if (!string.IsNullOrEmpty(sort))
            {
                sql.AppendFormat("  order by H.{0} {1}", sort, order);
            }
            else
            {
                sql.Append("    order by H.AvgCount desc,H.WorkCount desc,H.SRCount desc, H.Score desc ");
            }
            return sql.ToString();
        }
        //学校报表数据。
        private string createRptUnitSql(string unitID,string sid, string start, string end, string sort, string order)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select H.ClassID,H.ClassName,H.StudentCount,H.WorkCount,H.AvgCount,H.SRCount,H.Score ");
            sql.Append(" from ( ");
            sql.Append("        select dd.ClassID,dd.ClassName,dd.StudentCount,dd.WorkCount,");
            sql.Append("        round((case when isnull(dd.StudentCount,0) = 0 then 0 else cast(dd.WorkCount as float)/dd.StudentCount end),2) as AvgCount,");
            sql.Append("        dd.SRCount,dd.Score ");
            sql.Append("        from ");
            sql.Append("        ( ");
            //sql.Append("            select a.ClassID,a.ClassName + '['+cast(k.JoinYear as nvarchar(4))+']' as ClassName,");
            sql.Append("            select a.ClassID,a.ClassName,");
            sql.Append("            ( ");
            sql.Append("	            select count(b.StudentID) ");
            sql.Append("	            from tblSFITClassStudents b ");
            sql.Append("	            where b.ClassID = a.ClassID ");
            sql.Append("            ) as StudentCount,");
            sql.Append("            count(a.WorkID) as WorkCount,");
            sql.Append("            ( ");
            sql.Append("	            select sum(case when isnull(c.SubjectiveReviews,'') = '' then 0 else 1 end) ");
            sql.Append("	            from vwSFITStudentWorks c ");
            //sql.Append("	            left outer join tblSFITeaReviewStudent d ");
            //sql.Append("	            on d.WorkID = c.WorkID ");
            sql.Append("	            where c.ClassID = a.ClassID ");
            if (!string.IsNullOrEmpty(start) || !string.IsNullOrEmpty(end))
            {
                sql.Append("            and ");
                if (!string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),c.CreateDateTime,121) between '{0}' and '{1:yyyy-MM-dd}')", start, DateTime.Now);
                }
                else if (string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),c.CreateDateTime,121) like '{0}%')", start);
                }
                else
                {
                    sql.AppendFormat("  (convert(nvarchar(10),c.CreateDateTime,121) between '{0}' and '{1}')", start, end);
                }
            }
            if (!string.IsNullOrEmpty(sid))
            {
                sql.AppendFormat(" and c.CatalogID = '{0}' ", sid);
            }
            sql.Append("            ) as SRCount,");
            sql.Append("            ( ");
            sql.Append("	            select cast(sum(case when (e.ReviewValue = 'A') then 1 else 0 end) as nvarchar(10)) + 'A'+ ");
            sql.Append("	                   cast(sum(case when (e.ReviewValue = 'B') then 1 else 0 end) as nvarchar(10)) + 'B'+ ");
            sql.Append("	                   cast(sum(case when (e.ReviewValue = 'C') then 1 else 0 end) as nvarchar(10)) + 'C'+ ");
            sql.Append("	                   cast(sum(case when (e.ReviewValue = 'D') then 1 else 0 end) as nvarchar(10)) + 'D' ");
            sql.Append("	             from vwSFITStudentWorks e ");
            //sql.Append("	             left outer join tblSFITeaReviewStudent f ");
            //sql.Append("	             on f.WorkID = e.WorkID ");
            sql.Append("	             where e.ClassID = a.ClassID ");
            if (!string.IsNullOrEmpty(start) || !string.IsNullOrEmpty(end))
            {
                sql.Append("            and ");
                if (!string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),e.CreateDateTime,121) between '{0}' and '{1:yyyy-MM-dd}')", start, DateTime.Now);
                }
                else if (string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),e.CreateDateTime,121) like '{0}%')", start);
                }
                else
                {
                    sql.AppendFormat("(convert(nvarchar(10),e.CreateDateTime,121) between '{0}' and '{1}')", start, end);
                }
            }
            if (!string.IsNullOrEmpty(sid))
            {
                sql.AppendFormat(" and e.CatalogID = '{0}' ", sid);
            }
            sql.Append("            ) as Score ");
            sql.Append("            from vwSFITStudentWorks a ");
            //sql.Append("            left outer join tblSFITClass k on k.ClassID = a.ClassID ");
            sql.AppendFormat("      where a.SchoolID = '{0}' ", unitID);
            if (!string.IsNullOrEmpty(start) || !string.IsNullOrEmpty(end))
            {
                sql.Append("        and ");
                if (!string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),a.CreateDateTime,121) between '{0}' and '{1:yyyy-MM-dd}')", start, DateTime.Now);
                }
                else if (string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),a.CreateDateTime,121) like '{0}%')", start);
                }
                else
                {
                    sql.AppendFormat("  (convert(nvarchar(10),a.CreateDateTime,121) between '{0}' and '{1}')", start, end);
                }
            }
            if (!string.IsNullOrEmpty(sid))
            {
                sql.AppendFormat("  and a.CatalogID = '{0}' ", sid);
            }
            //sql.Append("            group by a.ClassID,a.ClassName + '['+cast(k.JoinYear as nvarchar(4))+']' ");
            sql.Append("            group by a.ClassID,a.ClassName ");
            sql.Append("    ) dd ");
            sql.Append(" ) H  ");
            if (!string.IsNullOrEmpty(sort))
            {
                sql.AppendFormat("  order by H.{0} {1}", sort, order);
            }
            else
            {
                sql.Append("    order by H.ClassName ");
            }
            return sql.ToString();
        }
        //班级报表数据。
        private string createRptClassSql(string classID, string sid, string start, string end, string sort, string order)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select a.StudentID,a.StudentName,");
            sql.Append("        COUNT(a.WorkID) as WorkCount,");
            sql.Append("        Sum(case when isnull(a.SubjectiveReviews,'') = '' then 0 else 1 end) as SRCount,");
            sql.Append("        ( ");
            sql.Append("	        cast(sum(case when (a.ReviewValue = 'A') then 1 else 0 end) as nvarchar(10)) + 'A'+ ");
            sql.Append("	        cast(sum(case when (a.ReviewValue = 'B') then 1 else 0 end) as nvarchar(10)) + 'B'+  ");
            sql.Append("	        cast(sum(case when (a.ReviewValue = 'C') then 1 else 0 end) as nvarchar(10)) + 'C'+ ");
            sql.Append("	        cast(sum(case when (a.ReviewValue = 'D') then 1 else 0 end) as nvarchar(10)) + 'D'");
            sql.Append("         ) as Score  ");
            sql.Append(" from vwSFITALLWorks a ");
            sql.AppendFormat(" where a.ClassID = '{0}' ", classID);
            if (!string.IsNullOrEmpty(start) || !string.IsNullOrEmpty(end))
            {
                sql.Append(" and ");
                if (!string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat(" (convert(nvarchar(10),a.CreateDateTime,121) between '{0}' and '{1:yyyy-MM-dd}')", start, DateTime.Now);
                }
                else if (string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat(" (convert(nvarchar(10),a.CreateDateTime,121) like '{0}%')", start);
                }
                else
                {
                    sql.AppendFormat(" (convert(nvarchar(10),a.CreateDateTime,121) between '{0}' and '{1}')", start, end);
                }
            }
            if (!string.IsNullOrEmpty(sid))
            {
                sql.AppendFormat(" and a.CatalogID = '{0}' ", sid);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                sql.AppendFormat("  order by a.{0} {1}", sort, order);
            }
            else
            {
                sql.Append(" group by a.StudentID,a.StudentName ");
            }
            
            return sql.ToString();
        }
        //学生报表数据。
        private string createRptStudentSql(string studentID, string sid, string start, string end, string sort, string order)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select H.StudentName,H.WorkID,H.WorkName,H.ReviewValue,H.SRCount,H.CreateTime ");
            sql.Append(" from ");
            sql.Append(" ( ");
            sql.Append("    select a.StudentName,a.WorkID,a.WorkName,");
            sql.Append("    (case when isnull(a.ReviewValue,'D-') = 'D-' then '' else a.ReviewValue end) as ReviewValue,");
            sql.Append("    (case when isnull(a.SubjectiveReviews,'') = '' then 0 else 1 end) as SRCount,");
            sql.Append("    convert(nvarchar(10),a.CreateDateTime,121) as CreateTime ");
            sql.Append("    from vwSFITALLWorks a ");
            sql.AppendFormat("  where a.StudentID = '{0}' ", studentID);
            if (!string.IsNullOrEmpty(start) || !string.IsNullOrEmpty(end))
            {
                sql.Append("   and ");
                if (!string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),a.CreateDateTime,121) between '{0}' and '{1:yyyy-MM-dd}')", start, DateTime.Now);
                }
                else if (string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    sql.AppendFormat("  (convert(nvarchar(10),a.CreateDateTime,121) like '{0}%')", start);
                }
                else
                {
                    sql.AppendFormat("  (convert(nvarchar(10),a.CreateDateTime,121) between '{0}' and '{1}')", start, end);
                }
            }
            if (!string.IsNullOrEmpty(sid))
            {
                sql.AppendFormat(" and a.CatalogID = '{0}' ", sid);
            }
            sql.Append(" ) H ");
            if (!string.IsNullOrEmpty(sort))
            {
                sql.AppendFormat("  order by H.{0} {1}", sort, order);
            }
            else
            {
                sql.Append(" order by H.CreateTime desc ");
            }
            return sql.ToString();
        }
        #endregion

    }
}