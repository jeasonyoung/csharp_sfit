//================================================================================
// FileName: SFITStudentWorksCollectPresenter.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
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
	///<summary>
	/// ISFITStudentWorksView接口。
	///</summary>
    public interface ISFITStudentWorksView : IModuleView
    {
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 列表接口。
    /// </summary>
    public interface ISFITStudentWorksListView : ISFITStudentWorksView
    {
        /// <summary>
        /// 获取学校名称。
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// 获取年级ID。
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// 获取班级名称。
        /// </summary>
        string ClassName { get; }
        /// <summary>
        /// 获取学生名称。
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
        /// 绑定年级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindGrade(IListControlsData data);
        /// <summary>
        /// 绑定作品状态。
        /// </summary>
        /// <param name="data"></param>
        void BindWorkStatus(IListControlsData data);
    }
    /// <summary>
    /// 编辑接口。
    /// </summary>
    public interface ISFITStudentWorksEditView : ISFITStudentWorksView
    {
        /// <summary>
        /// 获取作品ID。
        /// </summary>
        GUIDEx WorkID { get; }
    }
	///<summary>
	/// SFITStudentWorksCollectPresenter行为类。
	///</summary>
    public class SFITStudentWorksPresenter : ModulePresenter<ISFITStudentWorksView>
    {
        #region 成员变量，构造函数。
        SFITStudentWorksEntity studentWorksEntity = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public SFITStudentWorksPresenter(ISFITStudentWorksView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.StudentWorks_ModuleID;
            this.studentWorksEntity = new SFITStudentWorksEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            ISFITStudentWorksListView listView = this.View as ISFITStudentWorksListView;
            if (listView != null)
            {
                listView.BindGrade(new SFITGradeEntity().BindGrade);
                listView.BindWorkStatus(this.BindEnumWorkStatusData());
            }
        }
        #endregion

        #region 数据操作函数。
        /// <summary>
        /// 列表数据源
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                ISFITStudentWorksListView listView = this.View as ISFITStudentWorksListView;
                if (listView != null)
                {
                    DataTable dtSource = this.studentWorksEntity.ListDataSource(listView.SchoolName, listView.GradeID, listView.ClassName, 
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
