//================================================================================
//  FileName: UCStudentWorksListPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/10
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
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Data;

using iPower;
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;

namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 学生作品列表用户控件接口。
    /// </summary>
    public interface IUCStudentWorksListView : IModuleView
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
    /// 学生作品列表用户控件行为类。
    /// </summary>
    public class UCStudentWorksListPresenter : ModulePresenter<IUCStudentWorksListView>
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public UCStudentWorksListPresenter(IUCStudentWorksListView view)
            : base(view)
        {

        }
        #endregion
    }
}
