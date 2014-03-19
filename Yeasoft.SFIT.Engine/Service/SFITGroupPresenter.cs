//================================================================================
//  FileName: SFITGroupPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/17
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
using Yaesoft.SFIT;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITGroupView : IModuleView
    {
        /// <summary>
        /// 获取分组类型。
        /// </summary>
        int GroupType { get; }
        /// <summary>
        /// 获取是否单位学校。
        /// </summary>
        bool IsUnit { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITGroupEditView : ISFITGroupView
    {
        /// <summary>
        /// 获取分组ID。
        /// </summary>
        GUIDEx GroupID { get; }
       
        /// <summary>
        /// 获取或设置分组目录管理数据源。
        /// </summary>
        List<GroupCatalogItem> GroupCatalogs { get; set; }
        /// <summary>
        /// 获取或设置分组学生数据源。
        /// </summary>
        List<GroupStudentsItem> GroupStudents { get; set; }
        /// <summary>
        /// 绑定所属单位。
        /// </summary>
        /// <param name="data"></param>
        void BindUnit(IListControlsData data);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITGroupListView : ISFITGroupView
    {
        /// <summary>
        /// 获取模块ID。
        /// </summary>
        GUIDEx SID { get; }
        /// <summary>
        /// 获取所属学校名称。
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// 获取分组名称。
        /// </summary>
        string GroupName { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SFITGroupPresenter : ModulePresenter<ISFITGroupView>
    {
        #region 成员变量，构造函数。
        SFITGroupPresenterExtend<ISFITGroupView> extend = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITGroupPresenter(ISFITGroupView view)
            : base(view)
        {
            this.extend = new SFITGroupPresenterExtend<ISFITGroupView>(view);
        }
        #endregion

        #region 重载。
        protected override void PreViewLoadData()
        {
            ISFITGroupEditView editView = this.View as ISFITGroupEditView;
            if (editView != null)
            {
                if (editView.IsUnit)
                    editView.BindUnit(new SFITSchoolsEntity().BindSchools(editView.CurrentUserID));
                else
                    editView.BindUnit(new SFITSchoolsEntity().BindSchools());
            }
        }
        #endregion

        #region 数据操作
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            { 
                DataTable dtSource = this.extend.ListDataSource();
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    dtSource.Columns.Add("GroupType", typeof(string));
                    dtSource.Columns.Add("IsUnit", typeof(string));
                    int type = this.View.GroupType;
                    bool isUnit = this.View.IsUnit;
                    foreach (DataRow row in dtSource.Rows)
                    {
                        row["GroupType"] = string.Format("{0}", type);
                        row["IsUnit"] = string.Format("{0}", isUnit);
                    }
                }
                return dtSource;
            }
        }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<SFITGroup>> handler)
        {
            this.extend.LoadEntityData(handler, this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateEntityData(SFITGroup data)
        {
            return this.extend.UpdateEntityData(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteData(StringCollection priCollection)
        {
            return this.extend.BatchDeleteEntity(priCollection);
        }
        #endregion
    }

   
}
