//================================================================================
//  FileName: ModuleFrameSetMasterPage.Master.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/2/23
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

namespace Yaesoft.SFIT.Web.Share
{
    /// <summary>
    /// 框架母版页。
    /// </summary>
    public partial class ModuleFrameSetMasterPage : ModuleBaseMasterPage
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ModuleFrameSetMasterPage()
        {
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取模块名称。
        /// </summary>
        protected virtual string CurrentModuleTitle
        {
            get
            {
                if (this.ModulePage != null)
                    return this.ModulePage.CurrentModuleTitle;
                return string.Empty;
            }
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string strTitle = this.CurrentModuleTitle;
                if (!string.IsNullOrEmpty(strTitle))
                    this.lbTitle.Text = strTitle;
            }
        }
        #endregion
    }
}
