//================================================================================
//  FileName: frmSFITStudentWorksQueryEdit.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/14
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
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmSFITStudentWorksQueryEdit : ModuleBasePage, ISFITStudentWorksQueryEditView
    {
        #region 成员变量，构造函数。
        SFITStudentWorksQueryPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITStudentWorksQueryEdit()
        {
            this.presenter = new SFITStudentWorksQueryPresenter(this);
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
            this.LoadComplete += new EventHandler(delegate(object o, EventArgs s)
            {
                GUIDEx workID = this.WorkID;
                if (workID.IsValid)
                {
                    this.ucStudentWork.LoadData(workID);
                    this.ucStudentAttachment.LoadData(workID);
                    this.ucReviewStudent.LoadData(workID);
                    this.ucWorksComments.LoadData(workID, false);
                }
            });    
        }
        #endregion

        #region ISFITStudentWorksQueryEditView 成员

        public GUIDEx WorkID
        {
            get { return this.RequestGUIEx("WorkID"); }
        }

        #endregion

        #region ISFITStudentWorksQueryView 成员

        public void ShowMessage(string message)
        {
            this.errMessage.Message = message;
        }

        #endregion
    }
}
