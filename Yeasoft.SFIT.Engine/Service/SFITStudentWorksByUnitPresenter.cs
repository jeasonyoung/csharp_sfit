//================================================================================
//  FileName: SFITStudentWorksByUnitPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/10
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

using Yaesoft.SFIT;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    
    /// <summary>
    /// 
    /// </summary>
    public interface IStudentWorksByUnitListView : IModuleView
    {
        /// <summary>
        /// 获取学校单位ID。
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
        /// 获取学生名称
        /// </summary>
        string StudentName { get; }
        /// <summary>
        /// 获取作品名称。
        /// </summary>
        string WorkName { get; }
        /// <summary>
        /// 获取作品状态。
        /// </summary>
        GUIDEx WorkStatusID { get; }
        /// <summary>
        /// 绑定年级
        /// </summary>
        /// <param name="data"></param>
        void BindUnit(IListControlsData data);
        /// <summary>
        /// 绑定年级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindGrade(IListControlsData data);
        /// <summary>
        /// 绑定作品状态。
        /// </summary>
        /// <param name="data"></param>
        void BindWorkStatus(IListControlsData data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
    }
    /// <summary>
    /// 
    /// </summary>
    public class SFITStudentWorksByUnitPresenter : ModulePresenter<IStudentWorksByUnitListView>
    {
        #region 成员变量，构造函数。
        SFITStudentWorksEntity studentWorksEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITStudentWorksByUnitPresenter(IStudentWorksByUnitListView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.StudentWorksByUnit_ModuleID;
            this.studentWorksEntity = new SFITStudentWorksEntity();
        }
        #endregion

        #region 重载。
        protected override void PreViewLoadData()
        {
            this.View.BindUnit(new SFITSchoolsEntity().BindSchools(this.View.CurrentUserID));
            this.View.BindGrade(new SFITGradeEntity().BindGrade);
            IStudentWorksByUnitListView listView = this.View as IStudentWorksByUnitListView;
            if (listView != null)
            {
                 listView.BindWorkStatus(this.BindEnumWorkStatusData());
            }
        }
        #endregion

        #region 数据操作函数。
        /// <summary>
        /// 列表数据源
        /// </summary>
        public DataTable ListDataScuore
        {
            get
            {
                IStudentWorksByUnitListView listView = this.View as IStudentWorksByUnitListView;
                if (listView != null)
                {
                    DataTable dtSource = this.studentWorksEntity.ListDataSource(listView.UnitID, listView.GradeID, listView.ClassName, 
                        listView.StudentName, listView.WorkName, listView.WorkStatusID);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("WorkStatusName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["WorkStatusName"] = this.GetEnumWorkStatusName((EnumWorkStatus)Convert.ToInt32(row["WorkStatus"]));
                        }
                        return dtSource;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// 批量删除。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteEntityData(StringCollection priCollection)
        {
            bool result = false;
            try
            {
                if (priCollection != null && priCollection.Count > 0)
                    result = this.studentWorksEntity.DeleteRecord(priCollection);
            }
            catch (Exception x)
            {
                this.View.ShowMessage(x.Message);
            }
            return result;
        }
        #endregion
    }
}
