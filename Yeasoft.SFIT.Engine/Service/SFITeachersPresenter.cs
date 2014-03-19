//================================================================================
// FileName: SFITeachersPresenter.cs
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
	/// ISFITeachersView接口。
	///</summary>
	public interface ISFITeachersView: IModuleView
	{
        /// <summary>
        /// 显示数据。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 列表数据接口。
    /// </summary>
    public interface ISFITeachersListView : ISFITeachersView
    {
        /// <summary>
        /// 获取学校ID。
        /// </summary>
        GUIDEx SchoolID { get; }
        /// <summary>
        /// 教师名称。
        /// </summary>
        string TeacherName { get; }
        /// <summary>
        /// 绑定学校数据。
        /// </summary>
        /// <param name="data"></param>
        void BindSchools(IListControlsData data);
    }
    /// <summary>
    /// 编辑数据接口。
    /// </summary>
    public interface ISFITeachersEditView : ISFITeachersView
    {
        /// <summary>
        /// 获取教师ID。
        /// </summary>
        GUIDEx TeacherID { get; }
        /// <summary>
        ///  绑定同步状态数据。
        /// </summary>
        /// <param name="data"></param>
        void BindSyncStatus(IListControlsData data);
    }
	///<summary>
	/// SFITeachersPresenter行为类。
	///</summary>
	public class SFITeachersPresenter: ModulePresenter<ISFITeachersView>
	{
		#region 成员变量，构造函数。
        SFITeachersEntity teachersEntity = null;
		///<summary>
		///构造函数。
		///</summary>
		public SFITeachersPresenter(ISFITeachersView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.Teachers_ModuleID;
            this.teachersEntity = new SFITeachersEntity();
		}
		#endregion

        #region 重载。
        /// <summary>
        /// 重载。
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            ISFITeachersListView listView = this.View as ISFITeachersListView;
            if (listView != null)
                listView.BindSchools(new SFITSchoolsEntity().BindSchools());

            ISFITeachersEditView editView = this.View as ISFITeachersEditView;
            if (editView != null)
                editView.BindSyncStatus(this.EnumDataSource(typeof(EnumSyncStatus)));
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
                ISFITeachersListView listView = this.View as ISFITeachersListView;
                if (listView != null)
                {
                    DataTable dtSource = this.teachersEntity.ListDataSource(listView.SchoolID, listView.TeacherName);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("SyncStatusName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["SyncStatusName"] = this.GetEnumMemberName(typeof(EnumSyncStatus), Convert.ToInt32(row["SyncStatus"]));
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
		public void LoadEntityData(EventHandler<EntityEventArgs<SFITeachers>> handler)
		{
            ISFITeachersEditView editView = this.View as ISFITeachersEditView;
            if (handler != null && editView != null && editView.TeacherID.IsValid)
            {
                SFITeachers data = new SFITeachers();
                data.TeacherID = editView.TeacherID;
                if (this.teachersEntity.LoadRecord(ref data))
                {
                    handler(this, new EntityEventArgs<SFITeachers>(data));
                }
            }
		}
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateTeachers(SFITeachers data)
        {
            if (data == null)
                return false;
            return this.teachersEntity.UpdateRecord(data);
        }
        /// <summary>
        /// 批量删除教师数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteTeachers(StringCollection priCollection)
        {
            bool result = false;
            if (priCollection != null && priCollection.Count > 0)
            {
                string err = null;
                foreach (string p in priCollection)
                {
                    if (!(result = this.teachersEntity.DeleteRecord(p, out err)))
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
