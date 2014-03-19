//================================================================================
// FileName: SFITeachersPresenter.cs
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
	/// ISFITeachersView�ӿڡ�
	///</summary>
	public interface ISFITeachersView: IModuleView
	{
        /// <summary>
        /// ��ʾ���ݡ�
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// �б����ݽӿڡ�
    /// </summary>
    public interface ISFITeachersListView : ISFITeachersView
    {
        /// <summary>
        /// ��ȡѧУID��
        /// </summary>
        GUIDEx SchoolID { get; }
        /// <summary>
        /// ��ʦ���ơ�
        /// </summary>
        string TeacherName { get; }
        /// <summary>
        /// ��ѧУ���ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindSchools(IListControlsData data);
    }
    /// <summary>
    /// �༭���ݽӿڡ�
    /// </summary>
    public interface ISFITeachersEditView : ISFITeachersView
    {
        /// <summary>
        /// ��ȡ��ʦID��
        /// </summary>
        GUIDEx TeacherID { get; }
        /// <summary>
        ///  ��ͬ��״̬���ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindSyncStatus(IListControlsData data);
    }
	///<summary>
	/// SFITeachersPresenter��Ϊ�ࡣ
	///</summary>
	public class SFITeachersPresenter: ModulePresenter<ISFITeachersView>
	{
		#region ��Ա���������캯����
        SFITeachersEntity teachersEntity = null;
		///<summary>
		///���캯����
		///</summary>
		public SFITeachersPresenter(ISFITeachersView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.Teachers_ModuleID;
            this.teachersEntity = new SFITeachersEntity();
		}
		#endregion

        #region ���ء�
        /// <summary>
        /// ���ء�
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

        #region ���ݲ���������
        /// <summary>
        /// ��ȡ�б�����Դ��
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
		///�༭ҳ��������ݡ�
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
        /// �������ݡ�
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
        /// ����ɾ����ʦ���ݡ�
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
