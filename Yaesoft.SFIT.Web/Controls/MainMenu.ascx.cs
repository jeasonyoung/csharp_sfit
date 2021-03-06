﻿//================================================================================
//  FileName: MainMenu.ascx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/8/10
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using iPower;
using iPower.Utility;
using iPower.Platform;
using iPower.IRMP.Engine.Service;
namespace Yaesoft.SFIT.Web.Controls
{
    /// <summary>
    /// 主菜单用户控件。
    /// </summary>
    public partial class MainMenu : ModuleBaseControl, IModuleView
    {
        #region 成员变量，构造函数。
        ModulePresenter<IModuleView> presenter = null;
         /// <summary>
        /// 构造函数。
        /// </summary>
        public MainMenu()
        {
            this.presenter = new ModulePresenter<IModuleView>(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.presenter.InitializeComponent();
            }
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.Page.LoadComplete += new EventHandler(delegate(object sender, EventArgs e)
            {
                ModuleDefineCollection collection = this.MainMenuData;
                if (collection != null)
                {
                    this.repeaterMainMenu.DataSource = collection;
                    this.repeaterMainMenu.DataBind();
                }
                
            });
        }
        #endregion
    }
}