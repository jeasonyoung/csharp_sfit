//================================================================================
//  FileName: frmSFITWorksCommentsEdit.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/7
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
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    public partial class frmSFITWorksCommentsEdit : ModuleBasePage, ISFITWorksCommentsEditView
    {
        #region 成员变量，构造函数。
        SFITWorksCommentsPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITWorksCommentsEdit()
        {
            this.presenter = new SFITWorksCommentsPresenter(this);
            this.SecurityID = GUIDEx.Null;
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int status = Convert.ToInt32(this.ddlStatus.SelectedValue);
                if (this.presenter.UpdateCommentsStatus(status))
                    this.SaveData();
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITWorksComments>>(delegate(object sender, EntityEventArgs<SFITWorksComments> e)
            {
                if (e != null && e.Entity != null)
                {
                    this.txtWorkName.Text = e.Entity.WorkName;
                    this.txtStudentName.Text = e.Entity.StudentInfo;
                    this.txtUserName.Text = e.Entity.UserName;
                    this.txtClientIP.Text = e.Entity.ClientIP;
                    this.txtComment.Text = e.Entity.Comment;
                    this.ddlStatus.SelectedValue = e.Entity.Status.ToString();
                    this.txtCreateDateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", e.Entity.CreateDateTime);
                }
            }));
        }
        #endregion

        #region ISFITWorksCommentsEditView 成员

        public GUIDEx CommentID
        {
            get { return this.RequestGUIEx("CommentID"); }
        }

        public void BindCommentStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlStatus, data);
        }
        #endregion

        #region ISFITWorksCommentsView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion
    }
}
