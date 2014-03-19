//================================================================================
// FileName: SFITSchoolsPresenter.cs
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
	/// ISFITSchoolsView�ӿڡ�
	///</summary>
	public interface ISFITSchoolsView: IModuleView
	{
        /// <summary>
        /// ��ʾ��Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// �б����ӿڡ�
    /// </summary>
    public interface ISFITSchoolsListView : ISFITSchoolsView
    {
        /// <summary>
        /// ��ȡѧУ���ơ�
        /// </summary>
        string SchoolName { get; }
    }
    /// <summary>
    /// �༭����ӿڡ�
    /// </summary>
    public interface ISFITSchoolsEditView : ISFITSchoolsView
    {
        /// <summary>
        /// ��ȡѧУID��
        /// </summary>
        GUIDEx SchoolID { get; }
        /// <summary>
        ///  ��ͬ��״̬���ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindSyncStatus(IListControlsData data);
        /// <summary>
        /// ��ѧУ����״̬��
        /// </summary>
        /// <param name="data"></param>
        void BindSchoolType(IListControlsData data);
    }
	///<summary>
	/// SFITSchoolsPresenter��Ϊ�ࡣ
	///</summary>
	public class SFITSchoolsPresenter: ModulePresenter<ISFITSchoolsView>
	{
		#region ��Ա���������캯����
        SFITSchoolsEntity schoolsEntity = null;
		///<summary>
		///���캯����
		///</summary>
		public SFITSchoolsPresenter(ISFITSchoolsView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.Schools_ModuleID;
            this.schoolsEntity = new SFITSchoolsEntity();
		}
		#endregion

        #region ���ء�
        /// <summary>
        /// ���ء�
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

        #region ���ݲ���������
        /// <summary>
        /// ��ȡ�б�����Դ��
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
		///�༭ҳ��������ݡ�
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
        /// �������ݡ�
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
        /// ����ɾ�����ݡ�
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
