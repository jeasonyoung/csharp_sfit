//================================================================================
//  FileName: UCIndexBanner.ascx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/18
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

using iPower;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web.IndexControls
{
    /// <summary>
    /// Index的Banner头。
    /// </summary>
    public partial class UCIndexBanner : ModuleBaseControl,IModuleView
    {
        #region 成员变量，构造函数。
        ModulePresenter<IModuleView> presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCIndexBanner()
        {
            this.presenter = new ModulePresenter<IModuleView>(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
            else
                this.LoadData();
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.Page.LoadComplete += new EventHandler(delegate(object sender, EventArgs e)
            {
                this.LoginPanel.Visible = !(this.MCenterPanel.Visible = this.CurrentUserID.IsValid);
                if (this.MCenterPanel.Visible)
                {
                    this.lbUsername.Text = this.CurrentUserName;
                }
            });
        }
        #endregion
    }
}