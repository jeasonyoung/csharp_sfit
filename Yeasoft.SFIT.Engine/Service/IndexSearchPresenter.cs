//================================================================================
//  FileName: IndexSearchPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-17
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
    /// 作业搜索视图接口。
    /// </summary>
    public interface IIndexSearchView : IModuleView
    {
        /// <summary>
        /// 获取学校ID。
        /// </summary>
        string SchoolID { get; }
        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        string SchoolName { get; set; }
        /// <summary>
        /// 获取班级ID。
        /// </summary>
        string ClassID { get; }
        /// <summary>
        /// 获取或设置班级名称。
        /// </summary>
        string ClassName { get; set; }
        /// <summary>
        /// 获取科目ID。
        /// </summary>
        string CatalogID { get; }
        /// <summary>
        /// 获取或设置科目名称。
        /// </summary>
        string CatalogName { get; set; }
        /// <summary>
        /// 获取作品时间。
        /// </summary>
        string WorkTime { get; }
    }
    /// <summary>
    /// 作业搜索行为类。
    /// </summary>
    public class IndexSearchPresenter : ModulePresenter<IIndexSearchView>
    {
        #region  成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity = null;
        SFITClassEntity classEntity = null;
        SFITCatalogEntity catalogEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public IndexSearchPresenter(IIndexSearchView view)
            : base(view)
        {
            this.schoolsEntity = new SFITSchoolsEntity();
            this.classEntity = new SFITClassEntity();
            this.catalogEntity = new SFITCatalogEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            if (!string.IsNullOrEmpty(this.View.ClassID))
            {
                SFITClass data = new SFITClass();
                data.ClassID = this.View.ClassID;
                if (this.classEntity.LoadRecord(ref data))
                {
                    this.View.ClassName = data.ClassName;
                    this.View.SchoolName = data.SchoolName;
                }
            }
            else if (!string.IsNullOrEmpty(this.View.SchoolID))
            {
                SFITSchools data = new SFITSchools();
                data.SchoolID = this.View.SchoolID;
                if (this.schoolsEntity.LoadRecord(ref data))
                {
                    this.View.SchoolName = data.SchoolName;
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
        #endregion
    }
}