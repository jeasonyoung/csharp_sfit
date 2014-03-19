//================================================================================
// FileName: SFITCatalogPresenter.cs
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
	/// ISFITCatalogView�ӿڡ�
	///</summary>
	public interface ISFITCatalogView: IModuleView
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
    /// �б����ӿڡ�
    /// </summary>
    public interface ISFITCatalogListView : ISFITCatalogView
    {
        /// <summary>
        /// ��ȡѧУ���ơ�
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// ��ȡ�꼶ID��
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// ��ȡĿ¼���ơ�
        /// </summary>
        string CatalogName { get; }
    }
    /// <summary>
    /// �༭����ӿڡ�
    /// </summary>
    public interface ISFITCatalogEditView : ISFITCatalogView
    {
        /// <summary>
        /// ��ȡĿ¼ID��
        /// </summary>
        GUIDEx CatalogID { get; }
        /// <summary>
        /// ��Ŀ¼���͡�
        /// </summary>
        /// <param name="data"></param>
        void BindCatalogType(IListControlsData data);
        /// <summary>
        /// ��Ҫ�����ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindKnowledgePoints(IListControlsTreeViewData data);
        /// <summary>
        /// ����ѡ�е���ĿҪ�㡣
        /// </summary>
        /// <param name="chkPoints"></param>
        void SetCatalogKnowledgePoints(StringCollection chkPoints);
    }
    /// <summary>
    ///
    /// </summary>
    public interface ISFITCatalogPickerView : ISFITCatalogView
    {
        /// <summary>
        /// ��ȡ����ѧУID��
        /// </summary>
        GUIDEx UnitID { get; }
        /// <summary>
        /// ��ȡ�����꼶ID��
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// ��ȡ�γ�Ŀ¼���ơ�
        /// </summary>
        string CatalogName { get; }
        /// <summary>
        /// 
        /// </summary>
        bool IsUnit { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void BindUnits(IListControlsData data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void BindQueryResult(IListControlsData data);
    }
	///<summary>
	/// SFITCatalogPresenter��Ϊ�ࡣ
	///</summary>
	public class SFITCatalogPresenter: ModulePresenter<ISFITCatalogView>
	{
		#region ��Ա���������캯����
        SFITCatalogEntity catalogEntity = null;
        CatalogPresenterExtend<ISFITCatalogView> presenterExtend;
		///<summary>
		///���캯����
		///</summary>
		public SFITCatalogPresenter(ISFITCatalogView view)
		: base(view)
		{
            if (view is ISFITCatalogPickerView)
            {
                this.View.SecurityID = GUIDEx.Null;
            }
            else
            {
                this.View.SecurityID = ModuleConstants.Catalog_ModuleID;
            }
            this.catalogEntity = new SFITCatalogEntity();
            this.presenterExtend = new CatalogPresenterExtend<ISFITCatalogView>(view);
		}
		#endregion

        #region ���ء�
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            ISFITCatalogView view = this.View as ISFITCatalogView;
            if (view != null)
            {
                view.BindGrade(new SFITGradeEntity().BindGrade);
            }
           
            ISFITCatalogEditView editView = this.View as ISFITCatalogEditView;
            if (editView != null)
            {
                editView.BindCatalogType(this.EnumDataSource(typeof(EnumCatalogType)));
                this.presenterExtend.BindKnowledgePoints();
            }
            ISFITCatalogPickerView pickerView = this.View as ISFITCatalogPickerView;
            if (pickerView != null)
            {
                if (pickerView.IsUnit)
                    pickerView.BindUnits(new SFITSchoolsEntity().BindSchools(pickerView.CurrentUserID));
                else
                    pickerView.BindUnits(new SFITSchoolsEntity().BindSchools());
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
                return this.presenterExtend.ListDataSource(this);
            }
        }
        ///<summary>
		///�༭ҳ��������ݡ�
		///</summary>
		///<param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<SFITCatalog>> handler)
        {
            if (handler != null)
                this.presenterExtend.LoadEntityData(handler);
        }
        /// <summary>
        /// �����꼶ˢ�¸ı�֪ʶҪ������ݡ�
        /// </summary>
        /// <param name="gradeID"></param>
        public void ChangeRefreshBindKnowledgePointsByGrade(GUIDEx gradeID)
        {
            this.presenterExtend.ChangeRefreshBindKnowledgePointsByGrade(gradeID);
        }
        /// <summary>
        /// ����Ŀ¼���ݡ�
        /// </summary>
        /// <param name="data"></param>
        /// <param name="chkPoints"></param>
        /// <returns></returns>
        public bool UpdateCatalog(SFITCatalog data, StringCollection chkPoints)
        {
            return this.presenterExtend.UpdateCatalog(data, chkPoints);
        }
        /// <summary>
        /// 
        /// </summary>
        public void QueryResult()
        {
            ISFITCatalogPickerView pickerView = this.View as ISFITCatalogPickerView;
            if (pickerView != null)
            {
                DataTable dtSource = this.catalogEntity.ListDataSource(pickerView.UnitID, pickerView.GradeID, pickerView.CatalogName);
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    dtSource.Columns.Add("FullName", typeof(string));
                    dtSource.Columns.Add("FullValue", typeof(string));
                    int index = 0;
                    foreach (DataRow row in dtSource.Rows)
                    {
                        row["FullName"] = string.Format("{0}.{1}-({2})|{3},{4}",
                                                            ++index,
                                                            row["CatalogName"],
                                                            this.GetEnumMemberName(typeof(EnumCatalogType), Convert.ToInt32(row["CatalogType"])),
                                                            row["SchoolName"], row["GradeName"]);
                        row["FullValue"] = string.Format("{0}#{1}#{2}#{3}",
                                                        row["CatalogID"],
                                                        string.Format("{0}({1})", row["CatalogName"], this.GetEnumMemberName(typeof(EnumCatalogType), Convert.ToInt32(row["CatalogType"]))),
                                                        row["SchoolName"],
                                                        row["GradeName"]);
                    }

                    pickerView.BindQueryResult(new ListControlsDataSource("FullName", "FullValue", dtSource));
                }
            }
        }
        /// <summary>
        /// ɾ��Ŀ¼���ݡ�
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool DeleteCatalog(StringCollection priCollection)
        {
            return this.presenterExtend.DeleteCatalog(priCollection, new EventHandler(delegate(object sender, EventArgs e)
            {
                if (sender != null)
                    this.View.ShowMessage(sender.ToString());
            }));
        }
		#endregion

	}

}
