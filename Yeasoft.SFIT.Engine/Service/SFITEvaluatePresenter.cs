//================================================================================
// FileName: SFITEvaluatePresenter.cs
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
	/// ISFITEvaluateView接口。
	///</summary>
	public interface ISFITEvaluateView: IModuleView
	{
        /// <summary>
        /// 显示数据。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 列表界面接口。
    /// </summary>
    public interface ISFITEvaluateListView : ISFITEvaluateView
    {
        /// <summary>
        /// 获取评价名称。
        /// </summary>
        string EvaluateName { get; }
    }
    /// <summary>
    /// 编辑界面接口。
    /// </summary>
    public interface ISFITEvaluateEditView : ISFITEvaluateView
    {
        /// <summary>
        /// 获取评价ID。
        /// </summary>
        GUIDEx EvaluateID { get; }
        /// <summary>
        /// 获取或设置评价等级ID。
        /// </summary>
        GUIDEx ItemID { get; set; }
        /// <summary>
        /// 获取评价等级集合。
        /// </summary>
        EvaluateItems EditDataSource { get; set; }
        /// <summary>
        /// 绑定评价类型数据。
        /// </summary>
        /// <param name="data"></param>
        void BindEvaluateType(IListControlsData data);
    }
	///<summary>
	/// SFITEvaluatePresenter行为类。
	///</summary>
	public class SFITEvaluatePresenter: ModulePresenter<ISFITEvaluateView>
	{
		#region 成员变量，构造函数。
        SFITEvaluateEntity evaluateEntity = null;
        SFITEvaluateItemsEntity evaluateItemsEntity = null;
		///<summary>
		///构造函数。
		///</summary>
		public SFITEvaluatePresenter(ISFITEvaluateView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.Evaluate_ModuleID;
            this.evaluateEntity = new SFITEvaluateEntity();
            this.evaluateItemsEntity = new SFITEvaluateItemsEntity();
		}
		#endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            ISFITEvaluateEditView editView = this.View as ISFITEvaluateEditView;
            if (editView != null)
            {
                editView.BindEvaluateType(this.EnumDataSource(typeof(EnumEvaluateType)));
            }
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
                ISFITEvaluateListView listView = this.View as ISFITEvaluateListView;
                if (listView != null)
                {
                    DataTable dtSource = this.evaluateEntity.ListDataSource(listView.EvaluateName);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("EvaluateTypeName", typeof(string));
                       // dtSource.Columns.Add("SyncStatusName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["EvaluateTypeName"] = this.GetEnumMemberName(typeof(EnumEvaluateType), Convert.ToInt32(row["EvaluateType"]));
                            //row["SyncStatusName"] = this.GetEnumMemberName(typeof(EnumSyncStatus), Convert.ToInt32(row["SyncStatus"]));
                        }
                    }
                    return dtSource;
                }
                return null;
            }
        }
        #endregion

        #region 数据操作函数。
        ///<summary>
		///编辑页面加载数据。
		///</summary>
		///<param name="handler"></param>
		public void LoadEntityData(EventHandler<EntityEventArgs<SFITEvaluate>> handler)
		{
            ISFITEvaluateEditView editView = this.View as ISFITEvaluateEditView;
            if (handler != null && editView != null && editView.EvaluateID.IsValid)
            {
                SFITEvaluate data = new SFITEvaluate();
                data.EvaluateID = editView.EvaluateID;
                if (this.evaluateEntity.LoadRecord(ref data))
                {
                   EvaluateItems dataSource = this.evaluateItemsEntity.GetAllEvaluateItems(data.EvaluateID);
                   handler(this, new EntityEventArgs<SFITEvaluate>(data));
                   editView.EditDataSource = dataSource;
                }
            }
		}
        /// <summary>
        /// 更新数据源。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool UpdateEntityData(SFITEvaluate data, EvaluateItems items)
        {
            bool result = false;
            if (data != null)
            {
                //data.SyncStatus = (int)EnumSyncStatus.Sync;
                result = this.evaluateEntity.UpdateRecord(data);
                if (result)
                {
                    this.evaluateItemsEntity.BatchDeleteEvaluateItems(data.EvaluateID);
                    if (items != null && items.Count > 0)
                    {
                        foreach (EvaluateItem item in items)
                        {
                            SFITEvaluateItems i = new SFITEvaluateItems();
                            i.EvaluateID = data.EvaluateID;
                            i.ItemID = item.ItemID;
                            i.ItemName = item.ItemName;
                            i.ItemValue = item.ItemValue;
                            //i.SyncStatus = data.SyncStatus;
                            result = this.evaluateItemsEntity.UpdateRecord(i);
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteEvaluate(StringCollection priCollection)
        {
            bool result = false;
            if (priCollection != null && priCollection.Count > 0)
            {
                string err=  null;
                foreach (string p in priCollection)
                {
                    if (!(result = this.evaluateEntity.DeleteEvaluate(p, out err)))
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
