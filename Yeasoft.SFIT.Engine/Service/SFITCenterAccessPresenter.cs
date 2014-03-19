//================================================================================
// FileName: SFITCenterAccessPresenter.cs
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
	/// �������ӿڡ�
	///</summary>
	public interface ISFITCenterAccessView: IModuleView
	{
        /// <summary>
        /// ��ʾ��Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// ��������б����ӿڡ�
    /// </summary>
    public interface ISFITCenterAccessListView : ISFITCenterAccessView
    {
        /// <summary>
        /// ��ȡѧУ���ơ�
        /// </summary>
        string SchoolName { get; }
    }
    /// <summary>
    /// �������༭����ӿڡ�
    /// </summary>
    public interface ISFITCenterAccessEditView : ISFITCenterAccessView
    {
        /// <summary>
        /// ��ȡ����ID��
        /// </summary>
        GUIDEx AccessID { get; }
        /// <summary>
        /// �󶨷���״̬��
        /// </summary>
        /// <param name="data"></param>
        void BindAccessStatus(IListControlsData data);
    }
	///<summary>
    /// ���������Ϊ�ࡣ
	///</summary>
	public class SFITCenterAccessPresenter: ModulePresenter<ISFITCenterAccessView>
	{
		#region ��Ա���������캯����
        SFITCenterAccessEntity centerAccessEntity = null;
		///<summary>
		///���캯����
		///</summary>
		public SFITCenterAccessPresenter(ISFITCenterAccessView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.CenterAccess_ModuleID;
            this.centerAccessEntity = new SFITCenterAccessEntity();
		}
		#endregion

        #region ���ء�
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

        #region ���ݲ���������
        /// <summary>
        /// ��ȡ�б�����Դ��
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
		///�༭ҳ��������ݡ�
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
        /// �������ݡ�
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
        /// ����ɾ�����ݡ�
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
