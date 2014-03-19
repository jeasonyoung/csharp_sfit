//================================================================================
//  FileName: SFITWorksCommentsByUnitPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/16
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
using System.Collections.Specialized;
using System.Text;
using System.Data;

using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITWorksCommentsByUnitView : IModuleView
    {
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITWorksCommentsByUnitListView : ISFITWorksCommentsByUnitView
    {
        /// <summary>
        /// 获取所属学校ID。
        /// </summary>
        GUIDEx UnitID { get; }
        /// <summary>
        /// 获取所属年级ID。
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// 获取所属班级名称。
        /// </summary>
        string ClassName { get; }
        /// <summary>
        /// 获取所属目录名称。
        /// </summary>
        string CatalogName { get; }
        /// <summary>
        /// 获取学生姓名。
        /// </summary>
        string StudentName { get; }
        /// <summary>
        /// 获取作品名称。
        /// </summary>
        string WorkName { get; }
        /// <summary>
        /// 绑定学校单位数据。
        /// </summary>
        /// <param name="data"></param>
        void BindUnit(IListControlsData data);
        /// <summary>
        /// 绑定年级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindGrades(IListControlsData data);
    }
    /// <summary>
    /// 
    /// </summary>
    public class SFITWorksCommentsByUnitPresenter : ModulePresenter<ISFITWorksCommentsByUnitView>
    {
        #region 成员变量，构造函数。
        SFITWorksCommentsExtend<ISFITWorksCommentsByUnitView> extend = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITWorksCommentsByUnitPresenter(ISFITWorksCommentsByUnitView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.WorksCommentsByUnit_ModuleID;
            this.extend = new SFITWorksCommentsExtend<ISFITWorksCommentsByUnitView>(view);
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                return this.extend.ListDataSource;
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            ISFITWorksCommentsByUnitListView listView = this.View as ISFITWorksCommentsByUnitListView;
            if (listView != null)
            {
                listView.BindUnit(new SFITSchoolsEntity().BindSchools(this.View.CurrentUserID));
                listView.BindGrades(new SFITGradeEntity().BindGrade);
            }
        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteWorksComments(StringCollection priCollection)
        {
            return this.extend.BatchDeleteWorksComments(priCollection);
        }
        #endregion
    }
}
