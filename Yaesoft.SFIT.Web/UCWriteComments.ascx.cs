//================================================================================
//  FileName: UCWriteComments.ascx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/21
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
using iPower.Platform.Engine.Service;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCWriteComments : ModuleBaseControl, IUCWorksCommentsEditView
    {
        #region 成员变量，构造函数。
        UCWorksCommentsPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCWriteComments()
        {
            this.presenter = new UCWorksCommentsPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.presenter.SaveData(this.WorkID, this.Username, this.Comments, this.Request.UserHostAddress))
                {
                    ModuleBasePage p = this.Page as ModuleBasePage;
                    if (p != null)
                        p.LoadData();
                }  
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.Page.LoadComplete += new EventHandler(delegate(object sender, EventArgs e)
            {
                this.txtUsername.Text = this.CurrentUserName;
            });
        }
        #endregion

        #region IUCWorksCommentsEditView 成员

        public void LoadData(GUIDEx workID)
        {
            this.WorkID = workID;
        }

        GUIDEx WorkID
        {
            get
            {
                object obj = this.ViewState["WorkID"];
                return obj == null ? GUIDEx.Null : new GUIDEx(obj);
            }
            set
            {
                this.ViewState["WorkID"] = value;
            }
        }

        #endregion

        #region IUCWorksCommentsEditView 成员

        public string Username
        {
            get { return this.txtUsername.Text.Trim(); }
        }

        public string Comments
        {
            get { return this.txtComments.Text.Trim(); }
        }

       
        public void ShowMessage(string message)
        {
            this.errMsg.Message = message;
        }

        #endregion
    }
}