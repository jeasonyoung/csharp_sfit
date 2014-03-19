//================================================================================
//  FileName: SFITTeaClassByUnitPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/9
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
using System.Collections.Specialized;
using System.Collections.Generic;
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
    public interface ISFITTeaClassByUnitView : IModuleView
    {
        /// <summary>
        /// 绑定学校单位。
        /// </summary>
        /// <param name="data"></param>
        void BindUnit(IListControlsData data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITTeaClassByUnitListView : ISFITTeaClassByUnitView
    {
        /// <summary>
        /// 获取学校单位ID。
        /// </summary>
        GUIDEx UnitID { get; }
        /// <summary>
        /// 获取教师名称。
        /// </summary>
        string TeacherName { get; }
        /// <summary>
        /// 获取班级名称。
        /// </summary>
        string ClassName { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITTeaClassByUnitEditView : ISFITTeaClassByUnitView
    {
        /// <summary>
        /// 获取教师ID。
        /// </summary>
        GUIDEx TeacherID { get; }
        /// <summary>
        /// 绑定班级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindClasses(IListControlsData data);
    }
    /// <summary>
    /// 
    /// </summary>
    public class SFITTeaClassByUnitPresenter : ModulePresenter<ISFITTeaClassByUnitView>
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity = null;
        SFITClassEntity classEntity = null;
        TeaClassPresenterExtend<ISFITTeaClassByUnitView> extend = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITTeaClassByUnitPresenter(ISFITTeaClassByUnitView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.TeaClassByUnit_ModuleID;
            this.schoolsEntity = new SFITSchoolsEntity();
            this.classEntity = new SFITClassEntity();
            this.extend = new TeaClassPresenterExtend<ISFITTeaClassByUnitView>(this.View);
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListdataSource
        {
            get
            {
                return this.extend.ListDataSource;
            }
        }
        #endregion

        #region 数据操作。
        ///<summary>
        ///编辑页面加载数据。
        ///</summary>
        public void LoadEntityData(EventHandler<EntityEventArgs<SchoolTeacherInfo>> handler)
        {
            this.extend.LoadEntityData(handler);
        }
        /// <summary>
        /// 保存数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateTeaClass(SchoolTeacherInfo data)
        {
            return this.extend.UpdateTeaClass(data);
        }
        /// <summary>
        /// 获取学生名称。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <returns></returns>
        public string GetSchoolName(GUIDEx schoolID)
        {
            if (schoolID.IsValid)
            {
                SFITSchools data = new SFITSchools();
                data.SchoolID = schoolID;
                if (this.schoolsEntity.LoadRecord(ref data))
                {
                    return data.SchoolName;
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 批量删除。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteTeaClass(StringCollection priCollection)
        {
            return this.extend.BatchDeleteTeaClass(priCollection);
        }
        /// <summary>
        /// 变更学校数据。
        /// </summary>
        public void ChangeSchool(GUIDEx schoolID)
        {
            ISFITTeaClassByUnitEditView editView = this.View as ISFITTeaClassByUnitEditView;
            if (editView != null)
            {
                editView.BindClasses(this.classEntity.BindClass(schoolID));
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            this.View.BindUnit(this.schoolsEntity.BindSchools(this.View.CurrentUserID));
        }
        #endregion
    }
}
