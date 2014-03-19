//================================================================================
// FileName: SFITeaReviewStudentPresenter.cs
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
	/// ISFITeaReviewStudentView�ӿڡ�
	///</summary>
	public interface ISFITeaReviewStudentView: IModuleView
	{

	}

    /// <summary>
    /// �༭����ӿ�
    /// </summary>
    public interface ISFITeaReviewStudentEidtView : ISFITeaReviewStudentView
    {
        /// <summary>
        /// ��Ʒid��
        /// </summary>
        GUIDEx WorkID { get; }
        /// <summary>
        /// �������͡�
        /// </summary>
        /// <param name="data"></param>
        void BindEvaluateType(IListControlsData data);
        /// <summary>
        /// ͬ��״̬��
        /// </summary>
        /// <param name="data"></param>
        void BingSyncStatus(IListControlsData data);
        /// <summary>
        /// ������Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
		
	///<summary>
	/// SFITeaReviewStudentPresenter��Ϊ�ࡣ
	///</summary>
	public class SFITeaReviewStudentPresenter: ModulePresenter<ISFITeaReviewStudentView>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯����
		///</summary>
		public SFITeaReviewStudentPresenter(ISFITeaReviewStudentView view)
		: base(view)
		{

		}
		#endregion

		#region ���ݲ���������
		///<summary>
		///�༭ҳ��������ݡ�
		///</summary>
		///<param name="handler"></param>
		public void LoadEntityData(EventHandler<EntityEventArgs<SFITeaReviewStudent>> handler)
		{
            ISFITeaReviewStudentEidtView editView = this.View as ISFITeaReviewStudentEidtView;
            if (editView != null && editView.WorkID.IsValid)
            {
                SFITeaReviewStudent data = new SFITeaReviewStudent();
                data.WorkID = editView.WorkID;
                if (new SFITeaReviewStudentEntity().LoadRecord(ref data))
                {
                    SFITStudentWorks sFITStudentWorks = new SFITStudentWorks();
                    sFITStudentWorks.WorkID = data.WorkID;
                    if (new SFITStudentWorksEntity().LoadRecord(ref sFITStudentWorks))
                    {
                        data.WorkName = sFITStudentWorks.WorkName;
                    }
                    handler(this, new EntityEventArgs<SFITeaReviewStudent>(data));
                }
            }
		}

        /// <summary>
        /// ���ݸ���
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateTeaReviewStudent(SFITeaReviewStudent data)
        {
            bool result = false;
            ISFITeaReviewStudentEidtView editView = this.View as ISFITeaReviewStudentEidtView;
            if (editView != null && data != null)
            {
                try
                {
                    result = new SFITeaReviewStudentEntity().UpdateRecord(data);
                }
                catch (Exception ex)
                {
                    editView.ShowMessage(ex.Message); 
                }
            }
            return result;
        }

        /// <summary>
        /// �����б�����Դ��
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                ISFITeaReviewStudentEidtView editView = this.View as ISFITeaReviewStudentEidtView;
                if (editView != null)
                {
                    return new SFITStudentAttachmentEntity().ListDataSource(editView.WorkID);
                }
                return null;
            }
        }

		#endregion

        #region ����
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            ISFITeaReviewStudentEidtView editView = this.View as ISFITeaReviewStudentEidtView;
            if (editView != null)
            {
                editView.BindEvaluateType(this.EnumDataSource(typeof(EnumEvaluateType)));
                editView.BingSyncStatus(this.EnumDataSource(typeof(EnumSyncStatus)));
            }
        }
        #endregion

    }

}
