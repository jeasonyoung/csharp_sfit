//================================================================================
//  FileName: SFITCatalogByUnitPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/26
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
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
    /// <summary>
    /// 
    /// </summary>
    public interface ICatalogByUnitView : IModuleView
    {
        /// <summary>
        /// 绑定学校单位数据。
        /// </summary>
        /// <param name="data"></param>
        void BindUnit(IListControlsData data);
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
    /// 列表接口。
    /// </summary>
    public interface ICatalogByUnitListView : ICatalogByUnitView
    {
        /// <summary>
        /// 获取学校单位ID。
        /// </summary>
        GUIDEx UnitID { get; }
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
    /// 编辑接口。
    /// </summary>
    public interface ICatalogByUnitEditView : ICatalogByUnitView
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
    public class SFITCatalogByUnitPresenter : ModulePresenter<ICatalogByUnitView>
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schoolsEntity = null;
        SFITCatalogEntity catalogEntity = null; 
        CatalogPresenterExtend<ICatalogByUnitView> extend;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITCatalogByUnitPresenter(ICatalogByUnitView view)
            : base(view)
        {
            view.SecurityID = ModuleConstants.CatalogByUnit_ModuleID;
            this.catalogEntity = new SFITCatalogEntity();
            this.extend = new CatalogPresenterExtend<ICatalogByUnitView>(view);
            this.schoolsEntity = new SFITSchoolsEntity();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                return this.extend.ListDataSource(this);
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 加载数据。
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            this.View.BindGrade(new SFITGradeEntity().BindGrade);
            this.View.BindUnit(this.schoolsEntity.BindSchools(this.View.CurrentUserID));
            ICatalogByUnitEditView editView = this.View as ICatalogByUnitEditView;
            if (editView != null)
            {
                editView.BindCatalogType(this.EnumDataSource(typeof(EnumCatalogType)));
                this.extend.BindKnowledgePoints();
            }
        }
        #endregion

        #region 数据操作函数。
        ///<summary>
        ///编辑页面加载数据。
        ///</summary>
        ///<param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<SFITCatalog>> handler)
        {
            if (handler != null)
                this.extend.LoadEntityData(handler);
        }
        /// <summary>
        /// 根据年级刷新改变知识要点绑定数据。
        /// </summary>
        /// <param name="gradeID"></param>
        public void ChangeRefreshBindKnowledgePointsByGrade(GUIDEx gradeID)
        {
            this.extend.ChangeRefreshBindKnowledgePointsByGrade(gradeID);
        }
        /// <summary>
        /// 更新目录数据。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="chkPoints"></param>
        /// <returns></returns>
        public bool UpdateCatalog(SFITCatalog data, StringCollection chkPoints)
        {
            return this.extend.UpdateCatalog(data, chkPoints);
        }
        /// <summary>
        /// 删除目录数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool DeleteCatalog(StringCollection priCollection)
        {
            if (priCollection != null && priCollection.Count > 0)
            {
                StringCollection delPriCollection = new StringCollection();
                for (int i = 0; i < priCollection.Count; i++)
                {
                    SFITCatalog data = new SFITCatalog();
                    data.CatalogID = priCollection[i];
                    if (this.catalogEntity.LoadRecord(ref data))
                    {
                        if (!string.IsNullOrEmpty(data.SchoolID))
                        {
                            delPriCollection.Add(data.CatalogID);
                        }
                    }
                }
                
                return this.extend.DeleteCatalog(delPriCollection, new EventHandler(delegate(object sender, EventArgs e)
                {
                    if (sender != null)
                        this.View.ShowMessage(sender.ToString());
                }));
            }
            return false;
        }
        #endregion
    }
}
