//================================================================================
//  FileName: SFITGroupPresenterExtend.cs
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
    /// 竞赛、兴趣等分组行为类。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SFITGroupPresenterExtend<T>
        where T : IModuleView
    {
        #region 成员变量，构造函数。
        T view;
        SFITGroupEntity groupEntity = null;
        SFITGroupCatalogEntity groupCatalogEntity = null;
        SFITGroupStudentsEntity groupStudentEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITGroupPresenterExtend(T view)
        {
            this.view = view;
            this.groupEntity = new SFITGroupEntity();
            this.groupCatalogEntity = new SFITGroupCatalogEntity();
            this.groupStudentEntity = new SFITGroupStudentsEntity();
        }
        #endregion

        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="presenter"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<SFITGroup>> handler,ModulePresenter<T> presenter)
        {
            ISFITGroupEditView editView = this.view as ISFITGroupEditView;
            if (editView != null && editView.GroupID.IsValid && handler != null && presenter != null)
            {
                SFITGroup data = new SFITGroup();
                data.GroupID = editView.GroupID;
                if (this.groupEntity.LoadRecord(ref data))
                {
                    #region 分组项目。
                    DataTable dtSource = this.groupCatalogEntity.ListDataSource(data.GroupID);
                    if (dtSource != null && dtSource.Rows.Count > 0)
                    {
                        List<GroupCatalogItem> list = new List<GroupCatalogItem>();
                        foreach (DataRow row in dtSource.Rows)
                        {
                            GroupCatalogItem item = new GroupCatalogItem();
                            item.CatalogID = string.Format("{0}", row["CatalogID"]);
                            item.CatalogName = string.Format("{0}({1})", row["CatalogName"], presenter.GetEnumMemberName(typeof(EnumCatalogType), Convert.ToInt32(row["CatalogType"])));
                            item.UnitName = string.Format("{0}", row["SchoolName"]);
                            item.GradeName = string.Format("{0}", row["GradeName"]);
                            list.Add(item);
                        }
                        editView.GroupCatalogs = list;
                    }
                    #endregion

                    #region 分组学生。
                    dtSource = this.groupStudentEntity.ListDataSource(data.GroupID);
                    if (dtSource != null && dtSource.Rows.Count > 0)
                    {
                        List<GroupStudentsItem> list = new List<GroupStudentsItem>();
                        foreach (DataRow row in dtSource.Rows)
                        {
                            GroupStudentsItem item = new GroupStudentsItem();
                            item.StudentID = string.Format("{0}", row["StudentID"]);
                            item.StudentCode = string.Format("{0}", row["StudentCode"]);
                            item.StudentName = string.Format("{0}", row["StudentName"]);
                            item.UnitName = string.Format("{0}", row["SchoolName"]);
                            item.ClassName = string.Format("{0}", row["ClassName"]);
                            list.Add(item);
                        }
                        editView.GroupStudents = list;
                    }
                    #endregion

                    handler(this, new EntityEventArgs<SFITGroup>(data));
                }
            }
        }
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <returns></returns>
        public DataTable ListDataSource()
        {
            if (this.view is ISFITGroupListView)
            {
                ISFITGroupListView listView = this.view as ISFITGroupListView;
                if (listView != null)
                {
                    return this.groupEntity.ListDataSource(listView.SchoolName, listView.GroupName, listView.GroupType, listView.IsUnit ? 1 : 0, listView.CurrentUserID);
                }
            }
            else if (this.view is ISFITGroupWorksListView)
            {
                ISFITGroupWorksListView listView = this.view as ISFITGroupWorksListView;
                if (listView != null)
                {
                    return this.groupEntity.ListDataSource(listView.UnitName, listView.GroupName, listView.CatalogName,
                        listView.StudentName, listView.GroupType, listView.IsUnit ? 1 : 0, listView.CurrentUserID);
                }
            }
            return null;
        }
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateEntityData(SFITGroup data)
        {
            bool result = false;
            ISFITGroupEditView editView = this.view as ISFITGroupEditView;
            if (editView != null && data != null)
            {
                this.groupCatalogEntity.DeleteRecord(data.GroupID);
                this.groupStudentEntity.DeleteRecord(data.GroupID);

                if (editView.GroupID.IsValid)
                {
                    SFITGroup g = new SFITGroup();
                    g.GroupID = editView.GroupID;
                    if (this.groupEntity.LoadRecord(ref g))
                    {
                        data.GroupType = g.GroupType;
                    }
                }
                result = this.groupEntity.UpdateRecord(data);


                if (result)
                {
                    #region 添加分组目录。
                    List<GroupCatalogItem> catalogs = editView.GroupCatalogs;
                    if (catalogs != null && catalogs.Count > 0)
                    {
                        foreach (GroupCatalogItem item in catalogs)
                        {
                            SFITGroupCatalog gc = new SFITGroupCatalog();
                            gc.CatalogID = item.CatalogID;
                            gc.CatalogName = item.CatalogName;
                            gc.GroupID = data.GroupID;
                            this.groupCatalogEntity.UpdateRecord(gc);
                        }
                    }
                    #endregion

                    #region 添加分组学生。
                    List<GroupStudentsItem> students = editView.GroupStudents;
                    if (students != null && students.Count > 0)
                    {
                        foreach (GroupStudentsItem item in students)
                        {
                            SFITGroupStudents gs = new SFITGroupStudents();
                            gs.StudentID = item.StudentID;
                            gs.StudentCode = item.StudentCode;
                            gs.StudentName = item.StudentName;
                            gs.GroupID = data.GroupID;
                            this.groupStudentEntity.UpdateRecord(gs);
                        }
                    }
                    #endregion
                }
            }
            return result;
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteEntity(StringCollection priCollection)
        {
            bool result = false;
            if (priCollection != null && priCollection.Count > 0)
            {
                this.groupCatalogEntity.DeleteRecord(priCollection);
                this.groupStudentEntity.DeleteRecord(priCollection);
                result = this.groupEntity.DeleteRecord(priCollection);
            }
            return result;
        }
    }

    #region 数据类。
    /// <summary>
    /// 分组目录数据项。
    /// </summary>
    [Serializable]
    public class GroupCatalogItem
    {
        /// <summary>
        /// 获取或设置目录ID。
        /// </summary>
        public string CatalogID { get; set; }
        /// <summary>
        /// 获取或设置目录名称。
        /// </summary>
        public string CatalogName { get; set; }
        /// <summary>
        /// 获取或设置学校单位。
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 获取或设置所属年级名称。
        /// </summary>
        public string GradeName { get; set; }
    }
    /// <summary>
    /// 分组学生数据项。
    /// </summary>
    [Serializable]
    public class GroupStudentsItem
    {
        /// <summary>
        /// 获取或设置学生ID。
        /// </summary>
        public string StudentID { get; set; }
        /// <summary>
        /// 获取或设置学生代码。
        /// </summary>
        public string StudentCode { get; set; }
        /// <summary>
        /// 获取或设置学生姓名。
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 获取或设置学校单位。
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 获取或设置班级名称。
        /// </summary>
        public string ClassName { get; set; }
    }
    #endregion
}
