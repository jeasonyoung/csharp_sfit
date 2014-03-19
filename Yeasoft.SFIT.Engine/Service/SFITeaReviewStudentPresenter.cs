//================================================================================
// FileName: SFITeaReviewStudentPresenter.cs
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
	/// ISFITeaReviewStudentView接口。
	///</summary>
	public interface ISFITeaReviewStudentView: IModuleView
	{

	}

    /// <summary>
    /// 编辑界面接口
    /// </summary>
    public interface ISFITeaReviewStudentEidtView : ISFITeaReviewStudentView
    {
        /// <summary>
        /// 作品id。
        /// </summary>
        GUIDEx WorkID { get; }
        /// <summary>
        /// 评价类型。
        /// </summary>
        /// <param name="data"></param>
        void BindEvaluateType(IListControlsData data);
        /// <summary>
        /// 同步状态。
        /// </summary>
        /// <param name="data"></param>
        void BingSyncStatus(IListControlsData data);
        /// <summary>
        /// 错误消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
		
	///<summary>
	/// SFITeaReviewStudentPresenter行为类。
	///</summary>
	public class SFITeaReviewStudentPresenter: ModulePresenter<ISFITeaReviewStudentView>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数。
		///</summary>
		public SFITeaReviewStudentPresenter(ISFITeaReviewStudentView view)
		: base(view)
		{

		}
		#endregion

		#region 数据操作函数。
		///<summary>
		///编辑页面加载数据。
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
        /// 数据更新
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
        /// 附件列表数据源。
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

        #region 重载
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
