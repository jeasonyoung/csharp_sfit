//================================================================================
// FileName: SFITEvaluatePresenter.cs
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
	/// ISFITEvaluateView�ӿڡ�
	///</summary>
	public interface ISFITEvaluateView: IModuleView
	{
        /// <summary>
        /// ��ʾ���ݡ�
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// �б����ӿڡ�
    /// </summary>
    public interface ISFITEvaluateListView : ISFITEvaluateView
    {
        /// <summary>
        /// ��ȡ�������ơ�
        /// </summary>
        string EvaluateName { get; }
    }
    /// <summary>
    /// �༭����ӿڡ�
    /// </summary>
    public interface ISFITEvaluateEditView : ISFITEvaluateView
    {
        /// <summary>
        /// ��ȡ����ID��
        /// </summary>
        GUIDEx EvaluateID { get; }
        /// <summary>
        /// ��ȡ���������۵ȼ�ID��
        /// </summary>
        GUIDEx ItemID { get; set; }
        /// <summary>
        /// ��ȡ���۵ȼ����ϡ�
        /// </summary>
        EvaluateItems EditDataSource { get; set; }
        /// <summary>
        /// �������������ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindEvaluateType(IListControlsData data);
    }
	///<summary>
	/// SFITEvaluatePresenter��Ϊ�ࡣ
	///</summary>
	public class SFITEvaluatePresenter: ModulePresenter<ISFITEvaluateView>
	{
		#region ��Ա���������캯����
        SFITEvaluateEntity evaluateEntity = null;
        SFITEvaluateItemsEntity evaluateItemsEntity = null;
		///<summary>
		///���캯����
		///</summary>
		public SFITEvaluatePresenter(ISFITEvaluateView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.Evaluate_ModuleID;
            this.evaluateEntity = new SFITEvaluateEntity();
            this.evaluateItemsEntity = new SFITEvaluateItemsEntity();
		}
		#endregion

        #region ���ء�
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

        #region ���ԡ�
        /// <summary>
        /// ��ȡ�б�����Դ��
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

        #region ���ݲ���������
        ///<summary>
		///�༭ҳ��������ݡ�
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
        /// ��������Դ��
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
        /// ɾ��
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
