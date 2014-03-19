//================================================================================
//  FileName: IndexRptPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-22
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Text;

using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIndexRptView : IModuleView
    {
        string RptType { get; }
        string UnitID { get; }
        string UnitName { get; set; }
        string ClassID { get; }
        string ClassName { get; set; }
        string CatalogID { get; }
        string CatalogName { get; set; }
        string StudentID { get; }
        string StudentName { get; set; }
        string Time { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class IndexRptPresenter : ModulePresenter<IIndexRptView>
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity = null;
        SFITClassEntity classEntity = null;
        SFITStudentsEntity studentsEntity = null;
        SFITCatalogEntity catalogEntity = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        public IndexRptPresenter(IIndexRptView view)
            : base(view)
        {
            this.schoolsEntity = new SFITSchoolsEntity();
            this.classEntity = new SFITClassEntity();
            this.catalogEntity = new SFITCatalogEntity();
            this.studentsEntity = new SFITStudentsEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            if (this.View != null && !string.IsNullOrEmpty(this.View.RptType))
            {
                if (!string.IsNullOrEmpty(this.View.StudentID))
                {
                    SFITStudents data = new SFITStudents();
                    data.StudentID = this.View.StudentID;
                    if (this.studentsEntity.LoadRecord(ref data))
                    {
                        this.View.UnitName = data.SchoolName;
                        if (data.ClassID.IsValid)
                        {
                            SFITClass c = new SFITClass();
                            c.ClassID = data.ClassID;
                            if (this.classEntity.LoadRecord(ref c))
                            {
                                this.View.ClassName = c.ClassName;
                            }
                        }
                        this.View.StudentName = data.StudentName;
                    }
                }
                else if (!string.IsNullOrEmpty(this.View.ClassID))
                {
                    SFITClass data = new SFITClass();
                    data.ClassID = this.View.ClassID;
                    if (this.classEntity.LoadRecord(ref data))
                    {
                        this.View.UnitName = data.SchoolName;
                        this.View.ClassName = data.ClassName;
                    }
                }
                else if (!string.IsNullOrEmpty(this.View.UnitID))
                {
                    SFITSchools data = new SFITSchools();
                    data.SchoolID = this.View.UnitID;
                    if (this.schoolsEntity.LoadRecord(ref data))
                    {
                        this.View.UnitName = data.SchoolName;
                    }
                }

                if (!string.IsNullOrEmpty(this.View.CatalogID))
                {
                    SFITCatalog data = new SFITCatalog();
                    data.CatalogID = this.View.CatalogID;
                    if (this.catalogEntity.LoadRecord(ref data))
                    {
                        this.View.CatalogName = data.CatalogName;
                    }
                }
            }
        }
        #endregion
    }
}