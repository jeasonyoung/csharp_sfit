//================================================================================
//  FileName: WorksCommentsPresenterExtend.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/16
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
    /// 作品评阅扩展。
    /// </summary>
    public class SFITWorksCommentsExtend<T>
        where T : IModuleView
    {
        #region 成员变量，构造函数。
        T theView;
        ModulePresenter<T> presenter = null;
        SFITWorksCommentsEntity worksCommentsEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITWorksCommentsExtend(T view)
        {
            this.theView = view;
            this.presenter = new ModulePresenter<T>(view);
            this.worksCommentsEntity = new SFITWorksCommentsEntity();
        }
        #endregion

        #region 列表数据源。
        /// <summary>
        /// 获取列表数据。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                DataTable dtSource = null;
                if (this.theView is ISFITWorksCommentsListView)
                {
                    ISFITWorksCommentsListView listView = (ISFITWorksCommentsListView)this.theView;
                    dtSource = this.worksCommentsEntity.ListDataSource(listView.UnitName, listView.GradeID, listView.ClassName, listView.CatalogName, listView.StudentName, listView.WorkName);
                }
                else if (this.theView is ISFITWorksCommentsByUnitListView)
                {
                    ISFITWorksCommentsByUnitListView listView = (ISFITWorksCommentsByUnitListView)this.theView;
                    dtSource = this.worksCommentsEntity.ListDataSource(listView.UnitID, listView.GradeID, listView.ClassName, listView.CatalogName, listView.StudentName, listView.WorkName);
                }
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    dtSource.Columns.Add("StatusName", typeof(string));
                    foreach (DataRow row in dtSource.Rows)
                    {
                        row["StatusName"] = this.presenter.GetEnumMemberName(typeof(EnumCommentStatus), Convert.ToInt32(row["Status"]));
                    }
                }
                return dtSource;
            }
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<SFITWorksComments>> handler)
        {
            ISFITWorksCommentsEditView editView = this.theView as ISFITWorksCommentsEditView;
            if (editView != null && editView.CommentID.IsValid)
            {
                SFITWorksComments data = new SFITWorksComments();
                data.CommentID = editView.CommentID;
                if (this.worksCommentsEntity.LoadRecord(ref data))
                {
                    handler(this, new EntityEventArgs<SFITWorksComments>(data));
                }
            }
        }
        /// <summary>
        /// 更新评论状态。
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateCommentsStatus(int status)
        {
            ISFITWorksCommentsEditView editView = this.theView as ISFITWorksCommentsEditView;
            if (editView != null && editView.CommentID.IsValid)
            {
                SFITWorksComments data = new SFITWorksComments();
                data.CommentID = editView.CommentID;
                if (this.worksCommentsEntity.LoadRecord(ref data))
                {
                    data.Status = status;
                    return this.worksCommentsEntity.UpdateRecord(data);
                }
            }
            return false;
        }
        /// <summary>
        /// 批量删除作品评阅数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteWorksComments(StringCollection priCollection)
        {
            return this.worksCommentsEntity.DeleteRecord(priCollection);
        }
        #endregion
    }
}
