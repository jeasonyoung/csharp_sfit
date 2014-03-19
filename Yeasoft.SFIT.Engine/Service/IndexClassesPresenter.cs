//================================================================================
//  FileName: IndexClassesPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-16
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
    public interface IIndexClassesView : IModuleView
    {
        /// <summary>
        /// 获取班级ID。
        /// </summary>
        GUIDEx ClassID { get; }
        /// <summary>
        /// 获取或设置班级名称。
        /// </summary>
        string ClassName { get; set; }
        /// <summary>
        /// 获取或设置学校ID。
        /// </summary>
        string SchoolID { get; set; }
        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        string SchoolName { get; set; }
        /// <summary>
        /// 获取或设置年级ID。
        /// </summary>
        string GradeID { get; set; }
        /// <summary>
        /// 获取当前科目ID。
        /// </summary>
        string CatalogID { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class IndexClassesPresenter :ModulePresenter<IIndexClassesView>
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity = null;
        SFITClassEntity classEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public IndexClassesPresenter(IIndexClassesView view)
            : base(view)
        {
            this.schoolsEntity = new SFITSchoolsEntity();
            this.classEntity = new SFITClassEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            if (this.View != null && this.View.ClassID.IsValid)
            {
                SFITClass data = new SFITClass();
                data.ClassID = this.View.ClassID;
                if (this.classEntity.LoadRecord(ref data))
                {
                    this.View.SchoolID = data.SchoolID;
                    this.View.SchoolName = data.SchoolName;
                    this.View.GradeID = data.GradeID;
                    this.View.ClassName = data.ClassName;
                }
            }
        }
        #endregion
    }
}