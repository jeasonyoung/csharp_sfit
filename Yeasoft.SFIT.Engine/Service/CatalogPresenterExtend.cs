//================================================================================
//  FileName: CatalogPresenterExtend.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/28
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
    /// 目录行为扩展。
    /// </summary>
    internal class CatalogPresenterExtend<T>
        where T : IModuleView
    {
        #region 成员变量，构造函数。
        T theView;
        SFITCatalogEntity catalogEntity = null;
        SFITKnowledgePointsEntity knowledgePointsEntity = null;
        SFITCatalogKnowledgePointsEntity catalogKnowledgePointsEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public CatalogPresenterExtend(T view)
        {
            this.theView = view;
            this.catalogEntity = new SFITCatalogEntity();
            this.knowledgePointsEntity = new SFITKnowledgePointsEntity();
            this.catalogKnowledgePointsEntity = new SFITCatalogKnowledgePointsEntity();
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <returns></returns>
        public DataTable ListDataSource(ModulePresenter<T> presenter)
        {
            DataTable dtSource = null;
            if (this.theView is ISFITCatalogListView)
            {
                ISFITCatalogListView listView = this.theView as ISFITCatalogListView;
                dtSource = this.catalogEntity.ListDataSource(listView.SchoolName, listView.GradeID, listView.CatalogName);
            }
            else if (this.theView is ICatalogByUnitListView)
            {
                ICatalogByUnitListView listView = this.theView as ICatalogByUnitListView;
                dtSource = this.catalogEntity.ListDataSource(listView.UnitID, listView.GradeID, listView.CatalogName);
            }
            if (dtSource != null && presenter != null)
            {
                dtSource.Columns.Add("CatalogTypeName", typeof(string));
                foreach (DataRow row in dtSource.Rows)
                {
                    row["CatalogTypeName"] = presenter.GetEnumMemberName(typeof(EnumCatalogType), Convert.ToInt32(row["CatalogType"]));
                }
            }
            return dtSource;
        }
        /// <summary>
        /// 绑定知识要点。
        /// </summary>
        public void BindKnowledgePoints()
        {
            if (this.theView is ISFITCatalogEditView)
            {
                ((ISFITCatalogEditView)this.theView).BindKnowledgePoints(this.knowledgePointsEntity.BindKnowledgePoints());
            }
            else if (this.theView is ICatalogByUnitEditView)
            {
                ((ICatalogByUnitEditView)this.theView).BindKnowledgePoints(this.knowledgePointsEntity.BindKnowledgePoints());
            }
        }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<SFITCatalog>> handler)
        {
            SFITCatalog data = new SFITCatalog();

            if (this.theView is ISFITCatalogEditView)
            {
                data.CatalogID = ((ISFITCatalogEditView)this.theView).CatalogID;
            }
            else if (this.theView is ICatalogByUnitEditView)
            {
                data.CatalogID = ((ICatalogByUnitEditView)this.theView).CatalogID;
            }
            
            if (handler != null && data.CatalogID.IsValid)
            {
                if (this.catalogEntity.LoadRecord(ref data))
                {
                    if (this.theView is ISFITCatalogEditView)
                        ((ISFITCatalogEditView)this.theView).BindKnowledgePoints(this.knowledgePointsEntity.BindKnowledgePoints(data.GradeID, GUIDEx.Null));
                    else if (this.theView is ICatalogByUnitEditView)
                        ((ICatalogByUnitEditView)this.theView).BindKnowledgePoints(this.knowledgePointsEntity.BindKnowledgePoints(data.GradeID, GUIDEx.Null));

                    handler(this, new EntityEventArgs<SFITCatalog>(data));

                    if (this.theView is ISFITCatalogEditView)
                        ((ISFITCatalogEditView)this.theView).SetCatalogKnowledgePoints(this.catalogKnowledgePointsEntity.GetCatalogKnowledgePoints(data.CatalogID));
                    else if (this.theView is ICatalogByUnitEditView)
                        ((ICatalogByUnitEditView)this.theView).SetCatalogKnowledgePoints(this.catalogKnowledgePointsEntity.GetCatalogKnowledgePoints(data.CatalogID));
                }
            }
        }
        /// <summary>
        /// 根据年级刷新改变知识要点绑定数据。
        /// </summary>
        /// <param name="gradeID"></param>
        public void ChangeRefreshBindKnowledgePointsByGrade(GUIDEx gradeID)
        {
            if (this.theView is ISFITCatalogEditView)
            {
                ((ISFITCatalogEditView)this.theView).BindKnowledgePoints(this.knowledgePointsEntity.BindKnowledgePoints(gradeID, GUIDEx.Null));
            }
            else if (this.theView is ICatalogByUnitEditView)
            {
                ((ICatalogByUnitEditView)this.theView).BindKnowledgePoints(this.knowledgePointsEntity.BindKnowledgePoints(gradeID, GUIDEx.Null));
            }
        }
        /// <summary>
        /// 更新目录数据。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="chkPoints"></param>
        /// <returns></returns>
        public bool UpdateCatalog(SFITCatalog data, StringCollection chkPoints)
        {
            bool result = false;
            if (data != null)
            {
                if (result = this.catalogEntity.UpdateRecord(data))
                {
                    this.catalogKnowledgePointsEntity.UpdateCatalogKnowledgePoints(data.CatalogID, chkPoints);
                }
            }
            return result;
        }
        /// <summary>
        /// 删除目录数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <param name="changed"></param>
        /// <returns></returns>
        public bool DeleteCatalog(StringCollection priCollection, EventHandler changed)
        {
            bool result = false;
            if (priCollection != null && priCollection.Count > 0)
            {
                string err = null;
                foreach (string p in priCollection)
                {
                    if (!(result = this.catalogEntity.DeleteRecord(p, out err)))
                    {
                        if (changed != null)
                            changed(err, EventArgs.Empty);
                        break;
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
