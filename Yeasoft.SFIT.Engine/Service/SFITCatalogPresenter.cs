//================================================================================
// FileName: SFITCatalogPresenter.cs
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
	/// ISFITCatalogView接口。
	///</summary>
	public interface ISFITCatalogView: IModuleView
	{
        /// <summary>
        /// 绑定年级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindGrade(IListControlsData data);
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 列表界面接口。
    /// </summary>
    public interface ISFITCatalogListView : ISFITCatalogView
    {
        /// <summary>
        /// 获取学校名称。
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// 获取年级ID。
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// 获取目录名称。
        /// </summary>
        string CatalogName { get; }
    }
    /// <summary>
    /// 编辑界面接口。
    /// </summary>
    public interface ISFITCatalogEditView : ISFITCatalogView
    {
        /// <summary>
        /// 获取目录ID。
        /// </summary>
        GUIDEx CatalogID { get; }
        /// <summary>
        /// 绑定目录类型。
        /// </summary>
        /// <param name="data"></param>
        void BindCatalogType(IListControlsData data);
        /// <summary>
        /// 绑定要点数据。
        /// </summary>
        /// <param name="data"></param>
        void BindKnowledgePoints(IListControlsTreeViewData data);
        /// <summary>
        /// 设置选中的项目要点。
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
        /// 获取所属学校ID。
        /// </summary>
        GUIDEx UnitID { get; }
        /// <summary>
        /// 获取所属年级ID。
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// 获取课程目录名称。
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
	/// SFITCatalogPresenter行为类。
	///</summary>
	public class SFITCatalogPresenter: ModulePresenter<ISFITCatalogView>
	{
		#region 成员变量，构造函数。
        SFITCatalogEntity catalogEntity = null;
        CatalogPresenterExtend<ISFITCatalogView> presenterExtend;
		///<summary>
		///构造函数。
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

        #region 重载。
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

        #region 数据操作函数。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                return this.presenterExtend.ListDataSource(this);
            }
        }
        ///<summary>
		///编辑页面加载数据。
		///</summary>
		///<param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<SFITCatalog>> handler)
        {
            if (handler != null)
                this.presenterExtend.LoadEntityData(handler);
        }
        /// <summary>
        /// 根据年级刷新改变知识要点绑定数据。
        /// </summary>
        /// <param name="gradeID"></param>
        public void ChangeRefreshBindKnowledgePointsByGrade(GUIDEx gradeID)
        {
            this.presenterExtend.ChangeRefreshBindKnowledgePointsByGrade(gradeID);
        }
        /// <summary>
        /// 更新目录数据。
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
        /// 删除目录数据。
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
