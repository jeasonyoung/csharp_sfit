//================================================================================
//  FileName: SFITStudentWorksQueryPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/13
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
    public interface ISFITStudentWorksQueryView : IModuleView
    {
        void ShowMessage(string message);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITStudentWorksUploadView : ISFITStudentWorksQueryView
    {
        /// <summary>
        /// 设置学校名称。
        /// </summary>
        string SchoolName { set; }
        /// <summary>
        /// 设置所属班级名称。
        /// </summary>
        string ClassName { set; }
        /// <summary>
        /// 设置学生姓名。
        /// </summary>
        string StudentName { set; }
        /// <summary>
        /// 设置课程科目。
        /// </summary>
        /// <param name="data"></param>
        void BindCatalogs(IListControlsData data);
        /// <summary>
        /// 设置作品类型。
        /// </summary>
        /// <param name="data"></param>
        void BindWorkType(IListControlsData data);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITStudentWorksQueryListView : ISFITStudentWorksQueryView
    {
        /// <summary>
        /// 获取所属学校名称。
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// 获取所属年级名称。
        /// </summary>
        string GradeName { get; }
        /// <summary>
        /// 获取班级名称。
        /// </summary>
        string ClassName { get; }
        /// <summary>
        /// 获取目录名称。
        /// </summary>
        string CatalogName { get; }
        /// <summary>
        /// 获取作品名称。
        /// </summary>
        string WorkName { get; }
        /// <summary>
        /// 获取作品状态。
        /// </summary>
        GUIDEx WorkStatusID { get; }
        /// <summary>
        /// 绑定作品状态。
        /// </summary>
        /// <param name="data"></param>
        void BindWorkStatus(IListControlsData data);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITStudentWorksQueryEditView : ISFITStudentWorksQueryView
    {
        /// <summary>
        /// 获取作品ID。
        /// </summary>
        GUIDEx WorkID { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SFITStudentWorksQueryPresenter: ModulePresenter<ISFITStudentWorksQueryView>
    {
        #region 成员变量，构造函数。
        private SFITStudentWorksEntity studentWorksEntity = null;
        private SFITStudentsEntity studentsEntity = null;
        private SFITClassEntity classEntity = null;
        private SFITCatalogEntity catalogEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITStudentWorksQueryPresenter(ISFITStudentWorksQueryView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.StudentPersonalWorks_ModuleID;
            this.studentWorksEntity = new SFITStudentWorksEntity();
            this.studentsEntity = new SFITStudentsEntity();
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
                ISFITStudentWorksQueryListView listView = this.View as ISFITStudentWorksQueryListView;
                if (listView != null && listView.CurrentUserID.IsValid)
                {
                    DataTable dtSource = this.studentWorksEntity.ListDataSource(listView.CurrentUserID, listView.SchoolName, listView.GradeName, listView.ClassName,
                        listView.CatalogName, listView.WorkName, listView.WorkStatusID);
                    if (dtSource != null && dtSource.Rows.Count > 0)
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
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            //listView
            ISFITStudentWorksQueryListView listView = this.View as ISFITStudentWorksQueryListView;
            if (listView != null)
            {
                listView.BindWorkStatus(this.BindEnumWorkStatusData());
            }
            //uploadview
            ISFITStudentWorksUploadView uploadView = this.View as ISFITStudentWorksUploadView;
            if (uploadView != null)
            {
                SFITStudents data = new SFITStudents();
                data.StudentID = uploadView.CurrentUserID;
                if (this.studentsEntity.LoadRecord(ref data))
                {
                    uploadView.SchoolName = data.SchoolName;
                    uploadView.ClassName = this.classEntity.LoadClassName(data.ClassID);
                    uploadView.BindCatalogs(this.catalogEntity.BindCatalogs(data.SchoolID, data.GradeID));
                }
                uploadView.BindWorkType(this.EnumDataSource(typeof(EnumWorkType)));
            }
        }
        #endregion

    }
}
