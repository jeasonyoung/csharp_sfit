//================================================================================
//  FileName: ErrorPage.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/8
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
using System.Text;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ErrorPage : ModuleBasePage, IModuleView
    {
        #region 成员变量，构造函数。
        ModulePresenter<IModuleView> presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ErrorPage()
        {
            this.presenter = new ModulePresenter<IModuleView>(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
            this.errMessage.Text = this.ShowExceptionMessage();
        }
        #endregion

        #region 显示异常信息。
        protected string ShowExceptionMessage()
        {
            lock (this)
            {
                Exception output = HttpContext.Current.Server.GetLastError();
                if (output != null)
                {
                    Exception e = output, temp = null;
                    while ((temp = e.InnerException) != null)
                    {
                        e = temp;
                    }

                    if (e != null)
                    {
                        return e.Message;
                    }
                }
                return string.Empty;
            }
        }
        #endregion
    }
}
