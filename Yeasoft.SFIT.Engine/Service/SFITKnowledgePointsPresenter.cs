//================================================================================
// FileName: SFITKnowledgePointsPresenter.cs
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
	/// ISFITKnowledgePointsView接口。
	///</summary>
	public interface ISFITKnowledgePointsView: IModuleView
	{
        /// <summary>
        /// 绑定年级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindGrade(IListControlsData data);
        /// <summary>
        /// 显示信息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 列表页面接口。
    /// </summary>
    public interface ISFITKnowledgePointsListView : ISFITKnowledgePointsView
    {
        /// <summary>
        /// 获取顶级要点ID。
        /// </summary>
        GUIDEx TopPointID { get; }
        /// <summary>
        /// 获取年级ID。
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// 获取要点名称。
        /// </summary>
        string PointsName { get; }
    }
    /// <summary>
    /// 编辑页面接口。
    /// </summary>
    public interface ISFITKnowledgePointsEditView : ISFITKnowledgePointsView
    {
        /// <summary>
        /// 获取要点ID。
        /// </summary>
        GUIDEx PointID { get; }
        /// <summary>
        /// 获取上级要点ID。
        /// </summary>
        GUIDEx ParentPointID { get; }
        /// <summary>
        /// 绑定上级要点数据。
        /// </summary>
        /// <param name="data"></param>
        void BindParentPoints(IListControlsTreeViewData data);
    }
	///<summary>
	/// SFITKnowledgePointsPresenter行为类。
	///</summary>
	public class SFITKnowledgePointsPresenter: ModulePresenter<ISFITKnowledgePointsView>
	{
		#region 成员变量，构造函数。
        SFITKnowledgePointsEntity knowledgePointsEntity = null;
		///<summary>
		///构造函数。
		///</summary>
		public SFITKnowledgePointsPresenter(ISFITKnowledgePointsView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.KnowledgePoints_ModuleID;
            this.knowledgePointsEntity = new SFITKnowledgePointsEntity();
		}
		#endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            ISFITKnowledgePointsView view = this.View as ISFITKnowledgePointsView;
            if (view != null)
            {
                view.BindGrade(new SFITGradeEntity().BindGrade);
            }
            ISFITKnowledgePointsListView listView = this.View as ISFITKnowledgePointsListView;
            if (listView != null && listView.TopPointID.IsValid)
            {
                listView.CurrentFolderID = string.Format("{0}-{1}", listView.SecurityID, listView.TopPointID);
            }
            ISFITKnowledgePointsEditView editView = this.View as ISFITKnowledgePointsEditView;
            if (editView != null)
            {
                editView.BindParentPoints(this.knowledgePointsEntity.BindKnowledgePoints(editView.ParentPointID));
            }
        }
        #endregion

        #region 数据操作函数。
        /// <summary>
        /// 获取列表数据源
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                ISFITKnowledgePointsListView listView = this.View as ISFITKnowledgePointsListView;
                if (listView != null)
                {
                    DataTable dtSource = this.knowledgePointsEntity.ListDataSource(listView.TopPointID, listView.GradeID, listView.PointsName);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("PointNameCode", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["PointNameCode"] = string.Format("{0}-{1}", row["PointCode"], row["PointName"]);
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
		public void LoadEntityData(EventHandler<EntityEventArgs<SFITKnowledgePoints>> handler)
		{
            ISFITKnowledgePointsEditView editView = this.View as ISFITKnowledgePointsEditView;
            if (handler != null && editView != null && editView.PointID.IsValid)
            {
                SFITKnowledgePoints data = new SFITKnowledgePoints();
                data.PointID = editView.PointID;
                if (this.knowledgePointsEntity.LoadRecord(ref data))
                {
                    if (data.ParentPointID.IsValid)
                        editView.BindParentPoints(this.knowledgePointsEntity.BindNonKnowledgePoints(data.PointID));
                    handler(this, new EntityEventArgs<SFITKnowledgePoints>(data));
                }
            }
		}
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateKnowledgePoints(SFITKnowledgePoints data)
        {
            bool result = false;
            if (data != null)
                result = this.knowledgePointsEntity.UpdateRecord(data);
            return result;
        }
        /// <summary>
        /// 批量删除数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteKnowledgePoints(StringCollection priCollection)
        {
            bool result = false;
            if (priCollection != null && priCollection.Count > 0)
            {
                string err = null;
                foreach (string p in priCollection)
                {
                    if (!(result = this.knowledgePointsEntity.DeleteRecord(p, out err)))
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
