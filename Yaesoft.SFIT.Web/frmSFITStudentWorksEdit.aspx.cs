//================================================================================
//  FileName: frmSFITStudentWorktsEdit.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/20
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
    public partial class frmSFITStudentWorksEdit : ModuleBasePage, ISFITStudentWorksEditView
    {
        #region 成员变量，构造函数。
        SFITStudentWorksPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITStudentWorksEdit()
        {
            this.presenter = new SFITStudentWorksPresenter(this);
            this.SecurityID = GUIDEx.Null;
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
                bool result = false;
                GUIDEx workID = this.WorkID;
                if (workID.IsValid)
                {
                    if (result = this.ucStudentWork.SaveData(workID))
                    {
                        this.ucReviewStudent.SaveData(workID);
                    }
                }
                if (result)
                    this.SaveData();
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 加载数据。
        /// </summary>
        public override void LoadData()
        {
            this.LoadComplete += new EventHandler(delegate(object o, EventArgs s)
            {
                GUIDEx workID = this.WorkID;
                if (workID.IsValid)
                {
                    this.ucStudentWork.LoadData(workID);
                    this.ucStudentAttachment.LoadData(workID);
                    this.ucReviewStudent.LoadData(workID);
                    this.ucWorksComments.LoadData(workID, true);
                    //this.ucWorkThumbnailsList.LoadData(workID);
                }
            });    
        }
        #endregion

        #region ISFITStudentWorksView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        public GUIDEx WorkID
        {
            get { return this.Request["WorkID"]; }
        }
        #endregion
    }
}
