//================================================================================
//  FileName: SFITeachersPickerPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/10/19
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
using iPower.Platform.Engine.DataSource;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITeachersPickerView : IModuleView
    {
        /// <summary>
        /// 获取学校名称。
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// 获取教师名称。
        /// </summary>
        string TeacherName { get; }
        /// <summary>
        /// 获取值数组。
        /// </summary>
        string[] Values { get; }
        /// <summary>
        /// 绑定查询结果数据。
        /// </summary>
        /// <param name="data"></param>
        void BindResultQuery(IListControlsData data);
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 
    /// </summary>
    public class SFITeachersPickerPresenter : ModulePresenter<ISFITeachersPickerView>
    {
        #region 成员变量，构造函数。
        SFITeachersEntity teachersEntity = null;
        SFITSchoolsEntity schoolsEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public SFITeachersPickerPresenter(ISFITeachersPickerView view)
            : base(view)
        {
            this.teachersEntity = new SFITeachersEntity();
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
            ISFITeachersPickerView view = this.View as ISFITeachersPickerView;
            if (view != null && view.Values != null)
            {
                view.BindResultQuery(this.teachersEntity.BindTeachers(view.Values));
            }
        }
        #endregion
        
        #region 数据操作。
        /// <summary>
        /// 根据学校ID获取学校名称。
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
        /// 查询数据。
        /// </summary>
        public void Query()
        {
            this.View.BindResultQuery(this.teachersEntity.BindTeachers(this.View.SchoolName, this.View.TeacherName));
        }
        #endregion
    }
}
