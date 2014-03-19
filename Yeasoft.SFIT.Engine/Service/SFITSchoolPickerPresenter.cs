//================================================================================
//  FileName: SFITSchoolPickerPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/13
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
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;

using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 学校Picker视图。
    /// </summary>
    public interface ISchoolPickerView : IModuleView, IPickerView
    {
        /// <summary>
        /// 获取学校名称。
        /// </summary>
        string SchoolName { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SFITSchoolPickerPresenter : ModulePresenter<ISchoolPickerView>
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITSchoolPickerPresenter(ISchoolPickerView view)
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
            ISchoolPickerView pickerView = this.View as ISchoolPickerView;
            if (pickerView != null && pickerView.Values != null && pickerView.Values.Length > 0)
            {
                pickerView.BindSearchResult(this.schoolsEntity.BindControls(pickerView.Values));
            }
        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 查询学校信息。
        /// </summary>
        public void QuerySchool()
        {
            ISchoolPickerView pickerView = this.View as ISchoolPickerView;
            if (pickerView != null)
            {
                pickerView.BindSearchResult(this.schoolsEntity.BindControls(pickerView.SchoolName));
            }
        }
        #endregion
    }
}
