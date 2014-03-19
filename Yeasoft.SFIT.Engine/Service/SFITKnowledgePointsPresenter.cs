//================================================================================
// FileName: SFITKnowledgePointsPresenter.cs
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
	/// ISFITKnowledgePointsView�ӿڡ�
	///</summary>
	public interface ISFITKnowledgePointsView: IModuleView
	{
        /// <summary>
        /// ���꼶���ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindGrade(IListControlsData data);
        /// <summary>
        /// ��ʾ��Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// �б�ҳ��ӿڡ�
    /// </summary>
    public interface ISFITKnowledgePointsListView : ISFITKnowledgePointsView
    {
        /// <summary>
        /// ��ȡ����Ҫ��ID��
        /// </summary>
        GUIDEx TopPointID { get; }
        /// <summary>
        /// ��ȡ�꼶ID��
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// ��ȡҪ�����ơ�
        /// </summary>
        string PointsName { get; }
    }
    /// <summary>
    /// �༭ҳ��ӿڡ�
    /// </summary>
    public interface ISFITKnowledgePointsEditView : ISFITKnowledgePointsView
    {
        /// <summary>
        /// ��ȡҪ��ID��
        /// </summary>
        GUIDEx PointID { get; }
        /// <summary>
        /// ��ȡ�ϼ�Ҫ��ID��
        /// </summary>
        GUIDEx ParentPointID { get; }
        /// <summary>
        /// ���ϼ�Ҫ�����ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindParentPoints(IListControlsTreeViewData data);
    }
	///<summary>
	/// SFITKnowledgePointsPresenter��Ϊ�ࡣ
	///</summary>
	public class SFITKnowledgePointsPresenter: ModulePresenter<ISFITKnowledgePointsView>
	{
		#region ��Ա���������캯����
        SFITKnowledgePointsEntity knowledgePointsEntity = null;
		///<summary>
		///���캯����
		///</summary>
		public SFITKnowledgePointsPresenter(ISFITKnowledgePointsView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.KnowledgePoints_ModuleID;
            this.knowledgePointsEntity = new SFITKnowledgePointsEntity();
		}
		#endregion

        #region ���ء�
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

        #region ���ݲ���������
        /// <summary>
        /// ��ȡ�б�����Դ
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
		///�༭ҳ��������ݡ�
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
        /// �������ݡ�
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
        /// ����ɾ�����ݡ�
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
