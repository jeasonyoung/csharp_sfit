//================================================================================
// FileName: SFITEvaluateSetPresenter.cs
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
	/// ISFITEvaluateSetView接口。
	///</summary>
	public interface ISFITEvaluateSetView: IModuleView
	{
        /// <summary>
        /// 绑定年级。
        /// </summary>
        /// <param name="data"></param>
        void BindGrades(IListControlsData data);
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 列表界面接口。
    /// </summary>
    public interface ISFITEvaluateSetListView : ISFITEvaluateSetView
    {
        /// <summary>
        /// 获取年级ID。
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// 获取评价规则名称。
        /// </summary>
        string EvaluateName { get; }
    }
    /// <summary>
    /// 编辑界面接口。
    /// </summary>
    public interface ISFITEvaluateSetEditView : ISFITEvaluateSetView
    {
        /// <summary>
        /// 获取评价规则ID。
        /// </summary>
        GUIDEx EvaluateID { get; }
        /// <summary>
        /// 获取年级ID。
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// 绑定评价规则。
        /// </summary>
        /// <param name="data"></param>
        void BindEvaluates(IListControlsData data);
    }
	///<summary>
	/// SFITEvaluateSetPresenter行为类。
	///</summary>
	public class SFITEvaluateSetPresenter: ModulePresenter<ISFITEvaluateSetView>
	{
		#region 成员变量，构造函数。
        SFITEvaluateSetEntity evaluateSetEntity = null;
		///<summary>
		///构造函数。
		///</summary>
		public SFITEvaluateSetPresenter(ISFITEvaluateSetView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.EvaluateSet_ModuleID;
            this.evaluateSetEntity = new SFITEvaluateSetEntity();
		}
		#endregion

        #region 重载。
        /// <summary>
        /// 重载。
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            ISFITEvaluateSetView view = this.View as ISFITEvaluateSetView;
            if (view != null)
            {
                view.BindGrades(new SFITGradeEntity().BindGrade);   
            }
            ISFITEvaluateSetEditView editView = this.View as ISFITEvaluateSetEditView;
            if (editView != null)
            {
                editView.BindEvaluates(new SFITEvaluateEntity().BindEvaluate);
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
                ISFITEvaluateSetListView listView = this.View as ISFITEvaluateSetListView;
                if (listView != null)
                {
                    DataTable dtSource = this.evaluateSetEntity.ListDataSource(listView.GradeID, listView.EvaluateName);
                    if (dtSource != null && dtSource.Rows.Count > 0)
                    {
                       dtSource.Columns.Add("EvaluateTypeName", typeof(string));

                       foreach (DataRow row in dtSource.Rows)
                       {
                           row["EvaluateTypeName"] = this.GetEnumMemberName(typeof(EnumEvaluateType), Convert.ToInt32(row["EvaluateType"]));
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
		public void LoadEntityData(EventHandler<EntityEventArgs<SFITEvaluateSet>> handler)
		{
            ISFITEvaluateSetEditView editView = this.View as ISFITEvaluateSetEditView;
            if (editView != null && handler != null)
            {
                SFITEvaluateSet data = new SFITEvaluateSet();
                data.EvaluateID = editView.EvaluateID;
                data.GradeID = editView.GradeID;
                if (this.evaluateSetEntity.LoadRecord(ref data))
                {
                    handler(this, new EntityEventArgs<SFITEvaluateSet>(data));
                }
            }
		}
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateEntityData(SFITEvaluateSet data)
        {
            if (data != null)
                return this.evaluateSetEntity.UpdateRecord(data);
            return false;
        }
        /// <summary>
        /// 批量删除数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteEntityData(StringCollection priCollection)
        {
            bool result = false;
            if (priCollection != null && priCollection.Count > 0)
            {
                result = this.evaluateSetEntity.DeleteRecord(priCollection);
            }
            return result;
        }
		#endregion

	}

}
