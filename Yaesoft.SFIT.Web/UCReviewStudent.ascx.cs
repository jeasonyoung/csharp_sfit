//================================================================================
//  FileName: UCReviewStudent.ascx.cs
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
using iPower.Platform.Engine.Service;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    public partial class UCReviewStudent : ModuleBaseControl, IReviewStudentView
    {
        #region 成员变量，构造函数。
        ReviewStudentPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCReviewStudent()
        {
            this.presenter = new ReviewStudentPresenter(this);
        }
        #endregion

        #region 事件处理。

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.txtCreateEmployeeName.Text = this.CurrentUserName;
            this.txtCreateDateTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        }
        #endregion

        #region IReviewStudentView 成员

        public void LoadData(GUIDEx workID)
        {
            this.presenter.LoadReviewsData(workID, new EventHandler<EntityEventArgs<SFITeaReviewStudent>>(delegate(object sender, EntityEventArgs<SFITeaReviewStudent> e)
            {
                if (e.Entity != null)
                {
                    this.txtReviewValue.Visible = !(this.ddlReviewValue.Visible = (e.Entity.EvaluateType == (int)EnumEvaluateType.Hierarchy));
                    if (this.txtReviewValue.Visible)
                        this.txtReviewValue.Text = e.Entity.ReviewValue;
                    else if (this.ddlReviewValue.Visible)
                        this.ddlReviewValue.SelectedValue = e.Entity.ReviewValue;

                    this.txtSubjectiveReviews.Text = e.Entity.SubjectiveReviews;
                    this.txtTeacharName.Text = e.Entity.TeacharName;
                    this.txtCreateEmployeeName.Text = e.Entity.CreateEmployeeName;
                    this.txtCreateDateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", e.Entity.CreateDateTime);
                }
            }));
        }

        public void SaveData(GUIDEx workID)
        {
            if (workID.IsValid)
            {
                SFITeaReviewStudent data = new SFITeaReviewStudent();
                data.WorkID = workID;
                data.ReviewValue = this.ddlReviewValue.Visible ? this.ddlReviewValue.SelectedValue : this.txtReviewValue.Text;
                data.SubjectiveReviews = this.txtSubjectiveReviews.Text;
                data.TeacharName = this.txtTeacharName.Text;

                data.TeacherID = data.CreateEmployeeID = this.CurrentUserID;
                data.TeacharName = data.CreateEmployeeName = this.CurrentUserName;
                data.CreateDateTime = DateTime.Now;

                this.presenter.UpdateReviews(data);
            }
        }

        #endregion

        #region IReviewStudentView 成员


        public void BindReviewValue(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            if (data != null)
            {
                this.ListControlsDataSourceBind(this.ddlReviewValue, data);
                this.txtReviewValue.Visible = !(this.ddlReviewValue.Visible = true);
            }
        }

        #endregion
    }
}