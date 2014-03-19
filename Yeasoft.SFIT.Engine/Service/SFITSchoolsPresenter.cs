//================================================================================
// FileName: SFITSchoolsPresenter.cs
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
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
	///<summary>
	/// ISFITSchoolsView接口。
	///</summary>
	public interface ISFITSchoolsView: IModuleView
	{
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 列表界面接口。
    /// </summary>
    public interface ISFITSchoolsListView : ISFITSchoolsView
    {
        /// <summary>
        /// 获取学校名称。
        /// </summary>
        string SchoolName { get; }
    }
    /// <summary>
    /// 编辑界面接口。
    /// </summary>
    public interface ISFITSchoolsEditView : ISFITSchoolsView
    {
        /// <summary>
        /// 获取学校ID。
        /// </summary>
        GUIDEx SchoolID { get; }
        /// <summary>
        ///  绑定同步状态数据。
        /// </summary>
        /// <param name="data"></param>
        void BindSyncStatus(IListControlsData data);
        /// <summary>
        /// 绑定学校类型状态。
        /// </summary>
        /// <param name="data"></param>
        void BindSchoolType(IListControlsData data);
    }
	///<summary>
	/// SFITSchoolsPresenter行为类。
	///</summary>
	public class SFITSchoolsPresenter: ModulePresenter<ISFITSchoolsView>
	{
		#region 成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity = null;
		///<summary>
		///构造函数。
		///</summary>
		public SFITSchoolsPresenter(ISFITSchoolsView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.Schools_ModuleID;
            this.schoolsEntity = new SFITSchoolsEntity();
		}
		#endregion

        #region 重载。
        /// <summary>
        /// 重载。
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            ISFITSchoolsEditView editView = this.View as ISFITSchoolsEditView;
            if (editView != null)
            {
                editView.BindSyncStatus(this.EnumDataSource(typeof(EnumSyncStatus)));
                editView.BindSchoolType(this.EnumDataSource(typeof(EnumSchoolType)));
            }
        }
        #endregion

        #region 数据操作函数。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                ISFITSchoolsListView listView = this.View as ISFITSchoolsListView;
                if (listView != null)
                {
                    DataTable dtSource = this.schoolsEntity.ListDataSource(listView.SchoolName);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("SyncStatusName", typeof(string));
                        dtSource.Columns.Add("SchoolTypeName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["SyncStatusName"] = this.GetEnumMemberName(typeof(EnumSyncStatus), Convert.ToInt32(row["SyncStatus"]));
                            row["SchoolTypeName"] = this.GetEnumMemberName(typeof(EnumSchoolType), Convert.ToInt32(row["SchoolType"]));
                        }
                    }
                    return dtSource;
                }
                return null;
            }
        }
		///<summary>
		///编辑页面加载数据。
		///</summary>
		///<param name="handler"></param>
		public void LoadEntityData(EventHandler<EntityEventArgs<SFITSchools>> handler)
		{
            ISFITSchoolsEditView editView = this.View as ISFITSchoolsEditView;
            if (editView != null && editView.SchoolID.IsValid)
            {
                SFITSchools data = new SFITSchools();
                data.SchoolID = editView.SchoolID;
                if (this.schoolsEntity.LoadRecord(ref data))
                    handler(this, new EntityEventArgs<SFITSchools>(data));
            }
		}
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateSFITSchools(SFITSchools data)
        {
            if (data == null)
                return false;
            return this.schoolsEntity.UpdateRecord(data);
        }
        /// <summary>
        /// 批量删除数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteData(StringCollection priCollection)
        {
            bool result = false;
            if (priCollection != null && priCollection.Count > 0)
            {
                string err = null;
                foreach (string schoolID in priCollection)
                {
                    if (!(result = this.schoolsEntity.DeleteRecord(schoolID, out err)))
                    {
                        this.View.ShowMessage(err);
                        break;
                    }
                }
            }
            return result;
        }
		#endregion

	}

}
