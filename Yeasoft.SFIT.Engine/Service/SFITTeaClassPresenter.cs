//================================================================================
// FileName: SFITTeaClassPresenter.cs
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
	/// ISFITTeaClassView�ӿڡ�
	///</summary>
	public interface ISFITTeaClassView: IModuleView
	{
        /// <summary>
        /// ��ʾ��Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// �б�ҳ��ӿڡ�
    /// </summary>
    public interface ISFITTeaClassListView : ISFITTeaClassView
    {
        /// <summary>
        /// ��ȡѧУ���ơ�
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// ��ȡ��ʦ���ơ�
        /// </summary>
        string TearcherName { get; }
        /// <summary>
        /// ��ȡ�༶���ơ�
        /// </summary>
        string ClassName { get; }
       
    }
    /// <summary>
    /// �༭ҳ��ӿ�
    /// </summary>
    public interface ISFITTeaClassEditView : ISFITTeaClassView
    {
        /// <summary>
        /// ��ȡ��ʦID��
        /// </summary>
        GUIDEx TeacherID { get; }
        /// <summary>
        /// �󶨰༶���ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindClasses(IListControlsData data);
    }
	///<summary>
	/// SFITTeaClassPresenter��Ϊ�ࡣ
	///</summary>
	public class SFITTeaClassPresenter: ModulePresenter<ISFITTeaClassView>
	{
		#region ��Ա���������캯����
        SFITClassEntity classEntity = null;
        TeaClassPresenterExtend<ISFITTeaClassView> extend = null;
		///<summary>
		///���캯����
		///</summary>
		public SFITTeaClassPresenter(ISFITTeaClassView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.TeaClass_ModuleID;
            this.classEntity = new SFITClassEntity();
            this.extend = new TeaClassPresenterExtend<ISFITTeaClassView>(this.View);
		}
		#endregion

        #region ���ء�
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
        }
        #endregion

        #region ���ݲ���������
        /// <summary>
        /// ��ȡ�б����ݡ�
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                return this.extend.ListDataSource;
            }
        }
        ///<summary>
		///�༭ҳ��������ݡ�
		///</summary>
        public void LoadEntityData(EventHandler<EntityEventArgs<SchoolTeacherInfo>> handler)
		{
            this.extend.LoadEntityData(handler);
		}
        /// <summary>
        /// ����ɾ�����ݡ�
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteTeaClass(StringCollection priCollection)
        {
            return this.extend.BatchDeleteTeaClass(priCollection);
        }
        /// <summary>
        /// �������ݡ�
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateTeaClass(SchoolTeacherInfo data)
        {
            return this.extend.UpdateTeaClass(data);
        }
        /// <summary>
        /// ���ѧУ���ݡ�
        /// </summary>
        public void ChangeSchool(GUIDEx schoolID)
        {
            ISFITTeaClassEditView editView = this.View as ISFITTeaClassEditView;
            if (editView != null)
            {
                editView.BindClasses(this.classEntity.BindClass(schoolID));
            }
        }
		#endregion
    }
}
