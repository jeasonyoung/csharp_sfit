//================================================================================
//  FileName: UCGroupListPresenter.cs
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
    public interface IUCGroupListView : IModuleView
    {
        /// <summary>
        /// 获取选中的数据。
        /// </summary>
        StringCollection GetSelected { get; }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="listDataSource"></param>
        void LoadData(DataTable listDataSource);
    }
    /// <summary>
    /// 
    /// </summary>
    public class UCGroupListPresenter : ModulePresenter<IUCGroupListView>
    {
        #region 成员变量，构造函数。
        DataTable dtSource = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public UCGroupListPresenter(IUCGroupListView view)
            : base(view)
        {

        }
        #endregion

        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get { return this.dtSource; }
        }
        /// <summary>
        /// 设置列表数据源。
        /// </summary>
        /// <param name="dtSource"></param>
        public void SetListDataSource(DataTable dtSource)
        {
            this.dtSource = dtSource;
        }
    }
}
