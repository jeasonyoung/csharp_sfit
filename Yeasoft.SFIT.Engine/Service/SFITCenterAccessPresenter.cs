//================================================================================
// FileName: SFITCenterAccessPresenter.cs
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
using System.IO;

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
	/// 接入管理接口。
	///</summary>
	public interface ISFITCenterAccessView: IModuleView
	{
        /// <summary>
        /// 显示信息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 接入管理列表界面接口。
    /// </summary>
    public interface ISFITCenterAccessListView : ISFITCenterAccessView
    {
        /// <summary>
        /// 获取学校名称。
        /// </summary>
        string SchoolName { get; }
    }
    /// <summary>
    /// 接入管理编辑界面接口。
    /// </summary>
    public interface ISFITCenterAccessEditView : ISFITCenterAccessView
    {
        /// <summary>
        /// 获取访问ID。
        /// </summary>
        GUIDEx AccessID { get; }
        /// <summary>
        /// 绑定访问状态。
        /// </summary>
        /// <param name="data"></param>
        void BindAccessStatus(IListControlsData data);
    }
	///<summary>
    /// 接入管理行为类。
	///</summary>
	public class SFITCenterAccessPresenter: ModulePresenter<ISFITCenterAccessView>
	{
		#region 成员变量，构造函数。
        SFITCenterAccessEntity centerAccessEntity = null;
		///<summary>
		///构造函数。
		///</summary>
		public SFITCenterAccessPresenter(ISFITCenterAccessView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.CenterAccess_ModuleID;
            this.centerAccessEntity = new SFITCenterAccessEntity();
		}
		#endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            ISFITCenterAccessEditView editView = this.View as ISFITCenterAccessEditView;
            if (editView != null)
            {
                editView.BindAccessStatus(this.EnumDataSource(typeof(EnumAccessStatus)));
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
                ISFITCenterAccessListView listView = this.View as ISFITCenterAccessListView;
                if (listView != null)
                {
                    DataTable dtSource = this.centerAccessEntity.ListDataSource(listView.SchoolName);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("AccessStatusName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["AccessStatusName"] = this.GetEnumMemberName(typeof(EnumAccessStatus), Convert.ToInt32(row["AccessStatus"]));
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
		public void LoadEntityData(EventHandler<EntityEventArgs<SFITCenterAccess>> handler)
		{
            ISFITCenterAccessEditView editView = this.View as ISFITCenterAccessEditView;
            if (handler != null && editView != null && editView.AccessID.IsValid)
            {
                try
                {
                    SFITCenterAccess data = new SFITCenterAccess();
                    data.AccessID = editView.AccessID;
                    if (this.centerAccessEntity.LoadRecord(ref data))
                        handler(this, new EntityEventArgs<SFITCenterAccess>(data));
                }
                catch (Exception e)
                {
                    editView.ShowMessage(e.Message);
                }
            }
		}
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateCenterAccess(SFITCenterAccess data)
        {
            bool result = false;
            ISFITCenterAccessEditView editView = this.View as ISFITCenterAccessEditView;
            if (editView != null && data != null)
            {
                try
                {
                    result = this.centerAccessEntity.UpdateRecord(data);
                }
                catch (Exception e)
                {
                    editView.ShowMessage(e.Message);
                }
            }
            return result;
        }
        /// <summary>
        /// 批量删除数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDelete(StringCollection priCollection)
        {
            bool result = false;
            ISFITCenterAccessListView listView = this.View as ISFITCenterAccessListView;
            if (listView != null && priCollection != null && priCollection.Count > 0)
            {
                try
                {
                    result = this.centerAccessEntity.DeleteRecord(priCollection);
                }
                catch (Exception e)
                {
                    listView.ShowMessage(e.Message);
                }
            }
            return result;
        }
		#endregion

	}

}
