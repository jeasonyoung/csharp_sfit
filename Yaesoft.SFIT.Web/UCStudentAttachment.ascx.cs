//================================================================================
//  FileName: UCStudentAttachment.ascx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/29
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
namespace Yaesoft.SFIT.Web
{
    public partial class UCStudentAttachment : ModuleBaseControl, IStudentAttachmentView
    {
        #region 成员变量，构造函数。
        StudentAttachmentPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCStudentAttachment()
        {
            this.presenter = new StudentAttachmentPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }
        #endregion

        #region IStudentAttachmentView 成员

        public void LoadData(GUIDEx workID)
        {
            this.presenter.LoadAttachments(workID);
        }

        #endregion

        #region IStudentAttachmentView 成员

        public Attachments WorkAttachments
        {
            get
            {
                return this.ViewState["WorkAttachments"] as Attachments;
            }
            set
            {
                this.ViewState["WorkAttachments"] = value;
            }
        }

        #endregion
    }
}