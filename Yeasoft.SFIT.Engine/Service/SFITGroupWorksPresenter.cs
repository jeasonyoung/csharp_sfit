//================================================================================
//  FileName: SFITGroupWorksPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/24
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
    public interface ISFITGroupWorksListView : IModuleView
    {
        /// <summary>
        /// 获取分组类型。
        /// </summary>
        int GroupType { get; }
        /// <summary>
        /// 获取是否为学校。
        /// </summary>
        bool IsUnit { get; }
        /// <summary>
        /// 获取模块ID。
        /// </summary>
        GUIDEx SID { get; }

        /// <summary>
        /// 获取所属学校名称。
        /// </summary>
        string UnitName { get; }
        /// <summary>
        /// 获取分组名称。
        /// </summary>
        string GroupName { get; }
        /// <summary>
        /// 获取课程科目名称。
        /// </summary>
        string CatalogName { get; }
        /// <summary>
        /// 获取学生名称。
        /// </summary>
        string StudentName { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SFITGroupWorksPresenter : ModulePresenter<ISFITGroupWorksListView>
    {
        #region 成员变量，构造函数。
        SFITGroupPresenterExtend<ISFITGroupWorksListView> extend = null;
        SFITStudentWorksEntity studentWorksEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITGroupWorksPresenter(ISFITGroupWorksListView view)
            : base(view)
        {
            this.extend = new SFITGroupPresenterExtend<ISFITGroupWorksListView>(view);
            this.studentWorksEntity = new SFITStudentWorksEntity();
        }
        #endregion

        #region 数据操作。
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
                    dtSource.Columns.Add("WorkStatusName", typeof(string));
                    foreach (DataRow row in dtSource.Rows)
                    {
                        row["WorkStatusName"] = this.GetEnumWorkStatusName((EnumWorkStatus)Convert.ToInt32(row["WorkStatus"]));
                    }
                    return dtSource;
                }
                return null;
            }
        }
        /// <summary>
        /// 批量删除学生作品。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteWorksEntity(StringCollection priCollection)
        {
            return this.studentWorksEntity.DeleteRecord(priCollection);
        }
        #endregion
    }
}
