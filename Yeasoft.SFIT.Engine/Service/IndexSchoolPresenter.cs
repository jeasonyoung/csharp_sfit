//================================================================================
//  FileName: IndexSchoolPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-14
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
    public interface IIndexSchoolView : IModuleView
    {
        /// <summary>
        /// 
        /// </summary>
        GUIDEx SchoolID { get; }
        /// <summary>
        /// 
        /// </summary>
        string SchoolName { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class IndexSchoolPresenter : ModulePresenter<IIndexSchoolView>
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public IndexSchoolPresenter(IIndexSchoolView view)
            : base(view)
        {
            this.schoolsEntity = new SFITSchoolsEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            if (this.View != null && this.View.SchoolID.IsValid)
            {
                SFITSchools data = new SFITSchools();
                data.SchoolID = this.View.SchoolID;
                if (this.schoolsEntity.LoadRecord(ref data))
                {
                    this.View.SchoolName = data.SchoolName;
                }
            }
        }
        #endregion
    }
}
