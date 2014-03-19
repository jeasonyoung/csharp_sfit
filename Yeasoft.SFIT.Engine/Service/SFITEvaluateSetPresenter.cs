//================================================================================
// FileName: SFITEvaluateSetPresenter.cs
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
	/// ISFITEvaluateSetView�ӿڡ�
	///</summary>
	public interface ISFITEvaluateSetView: IModuleView
	{
        /// <summary>
        /// ���꼶��
        /// </summary>
        /// <param name="data"></param>
        void BindGrades(IListControlsData data);
        /// <summary>
        /// ��ʾ��Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// �б����ӿڡ�
    /// </summary>
    public interface ISFITEvaluateSetListView : ISFITEvaluateSetView
    {
        /// <summary>
        /// ��ȡ�꼶ID��
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// ��ȡ���۹������ơ�
        /// </summary>
        string EvaluateName { get; }
    }
    /// <summary>
    /// �༭����ӿڡ�
    /// </summary>
    public interface ISFITEvaluateSetEditView : ISFITEvaluateSetView
    {
        /// <summary>
        /// ��ȡ���۹���ID��
        /// </summary>
        GUIDEx EvaluateID { get; }
        /// <summary>
        /// ��ȡ�꼶ID��
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// �����۹���
        /// </summary>
        /// <param name="data"></param>
        void BindEvaluates(IListControlsData data);
    }
	///<summary>
	/// SFITEvaluateSetPresenter��Ϊ�ࡣ
	///</summary>
	public class SFITEvaluateSetPresenter: ModulePresenter<ISFITEvaluateSetView>
	{
		#region ��Ա���������캯����
        SFITEvaluateSetEntity evaluateSetEntity = null;
		///<summary>
		///���캯����
		///</summary>
		public SFITEvaluateSetPresenter(ISFITEvaluateSetView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.EvaluateSet_ModuleID;
            this.evaluateSetEntity = new SFITEvaluateSetEntity();
		}
		#endregion

        #region ���ء�
        /// <summary>
        /// ���ء�
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

        #region ���ݲ���������
        /// <summary>
        /// ��ȡ�б�����Դ��
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
		///�༭ҳ��������ݡ�
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
        /// �������ݡ�
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
        /// ����ɾ�����ݡ�
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
