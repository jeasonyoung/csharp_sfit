//================================================================================
// FileName: SFITWorksCommentsPresenter.cs
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
	/// ISFITWorksCommentsView�ӿڡ�
	///</summary>
    public interface ISFITWorksCommentsView : IModuleView
    {
        /// <summary>
        /// ������Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITWorksCommentsListView : ISFITWorksCommentsView
    {
        /// <summary>
        /// ��ȡѧУ���ơ�
        /// </summary>
        string UnitName { get; }
        /// <summary>
        /// ��ȡ�꼶ID��
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// ��ȡ�༶���ơ�
        /// </summary>
        string ClassName { get; }
        /// <summary>
        /// ��ȡ�γ�Ŀ¼��
        /// </summary>
        string CatalogName { get; }
        /// <summary>
        /// ��ȡѧ��������
        /// </summary>
        string StudentName { get; }
        /// <summary>
        /// ��ȡ��Ʒ���ơ�
        /// </summary>
        string WorkName { get; }
        /// <summary>
        /// ���꼶���ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindGrades(IListControlsData data);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITWorksCommentsEditView : ISFITWorksCommentsView
    {
        /// <summary>
        /// ��ȡ����ID��
        /// </summary>
        GUIDEx CommentID { get; }
        /// <summary>
        /// ������״̬���ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindCommentStatus(IListControlsData data);
    }
		
	///<summary>
	/// SFITWorksCommentsPresenter��Ϊ�ࡣ
	///</summary>
    public class SFITWorksCommentsPresenter : ModulePresenter<ISFITWorksCommentsView>
    {
        #region ��Ա���������캯����
        SFITWorksCommentsExtend<ISFITWorksCommentsView> extend = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public SFITWorksCommentsPresenter(ISFITWorksCommentsView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.WorksComments_ModuleID;
            this.extend = new SFITWorksCommentsExtend<ISFITWorksCommentsView>(this.View);
        }
        #endregion

        #region ���ء�
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            ISFITWorksCommentsListView listView = this.View as ISFITWorksCommentsListView;
            if (listView != null)
            {
                listView.BindGrades(new SFITGradeEntity().BindGrade);
            }
            ISFITWorksCommentsEditView editView = this.View as ISFITWorksCommentsEditView;
            if (editView != null)
            {
                editView.BindCommentStatus(this.EnumDataSource(typeof(EnumCommentStatus)));
            }
        }
        #endregion

        #region ���ݲ���������
        ///<summary>
        ///�༭ҳ��������ݡ�
        ///</summary>
        ///<param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<SFITWorksComments>> handler)
        {
            this.extend.LoadEntityData(handler);
        }
        /// <summary>
        /// ���¸�������״̬��
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateCommentsStatus(int status)
        {
            return this.extend.UpdateCommentsStatus(status);
        }
        /// <summary>
        /// �б�����Դ
        /// </summary>
        public DataTable listDataSource
        {
            get { return this.extend.ListDataSource; }
        }
        /// <summary>
        /// ����ɾ������
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteWorksComments(StringCollection priCollection)
        {
            return this.extend.BatchDeleteWorksComments(priCollection);
        }
        #endregion
    }
}
