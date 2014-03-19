//================================================================================
//  FileName: IndexDetailsPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-21
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
using iPower;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIndexDetailsView : IModuleView
    {
        GUIDEx WorkID { get; }      
        string SchoolName { get; set; }
        string GradeName { get; set; }
        string ClassName { get; set; }
        string CatalogName { get; set; }
        string StudentName { get; set; }

        string WorkName { get; set; }
        string WorkStatus { get; set; }
        string WorkDescription { get; set; }
        string CheckCode { get; set; }

        string WorkValue { get; set; }
        string WorkSubRev { get; set; }
        string WorkTeaName { get; set; }

        int Hits { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class IndexDetailsPresenter : ModulePresenter<IIndexDetailsView>
    {
        #region 成员变量，构造函数。
        SFITStudentWorksEntity worksEntity = null;
        SFITeaReviewStudentEntity teaReviewStudentEntity = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        public IndexDetailsPresenter(IIndexDetailsView view)
            : base(view)
        {
            this.worksEntity = new SFITStudentWorksEntity();
            this.teaReviewStudentEntity = new SFITeaReviewStudentEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            if (this.View.WorkID.IsValid)
            {
                SFITStudentWorks data = new SFITStudentWorks();
                data.WorkID = this.View.WorkID;
                if (this.worksEntity.LoadRecord(ref data))
                {
                    this.View.SchoolName = data.SchoolName;
                    this.View.GradeName = data.GradeName;
                    this.View.ClassName = data.ClassName;
                    this.View.CatalogName = data.CatalogName;
                    this.View.StudentName = data.StudentName;

                    this.View.WorkName = data.WorkName;
                    this.View.WorkStatus = EnumWorkStatusOperaTools.GetStatusName((EnumWorkStatus)data.WorkStatus);
                    this.View.WorkDescription = data.WorkDescription;
                    this.View.CheckCode = data.CheckCode;

                    this.View.Hits = data.Hits;
                }
                SFITeaReviewStudent trs = new SFITeaReviewStudent();
                trs.WorkID = data.WorkID;
                if (this.teaReviewStudentEntity.LoadRecord(ref trs))
                {
                    this.View.WorkValue = trs.ReviewValue;
                    this.View.WorkSubRev = trs.SubjectiveReviews;
                    this.View.WorkTeaName = trs.TeacharName;
                }
                this.worksEntity.UpdateHits(data.WorkID);
            }
        }
        #endregion
    }
}