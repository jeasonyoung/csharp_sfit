//================================================================================
// FileName: frmSFITStudentsEdit.aspx.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
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
	///<summary>
	///frmSFITStudentsEdit列表页面后台代码。
	///</summary>
    public partial class frmSFITStudentsEdit : ModuleBasePage, ISFITStudentsEditView
    {
        #region 成员变量，构造函数。
        SFITStudentsPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITStudentsEdit()
        {
            this.presenter = new SFITStudentsPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.presenter.InitializeComponent();
            }
        }

        protected void ddlGrade_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.presenter.ChangeGrade(this.pbSchool.Value, this.ddlGrade.SelectedValue);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SFITStudents data = new SFITStudents();
                data.StudentID = this.StudentID.IsValid ? this.StudentID : GUIDEx.New;
                data.SchoolID = this.pbSchool.Value;
                data.SchoolName = this.pbSchool.Text;
                data.GradeID = this.ddlGrade.SelectedValue;
                data.ClassID = this.ddlClass.SelectedValue;

                data.StudentCode = this.txtStudentCode.Text.Trim();
                data.StudentName = this.txtStudentName.Text.Trim();
                data.Gender = int.Parse(this.ddlGender.SelectedValue);
                data.JoinYear = int.Parse(this.txtJoinYear.Text.Trim());
                data.IDNumber = this.txtIDNumber.Text.Trim();
                data.SyncStatus = int.Parse(this.ddlSyncStatus.SelectedValue);

                if (this.presenter.UpdateStudents(data))
                    this.SaveData();
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {

            this.txtJoinYear.Text = string.Format("{0:yyyy}", DateTime.Now);
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITStudents>>(delegate(object sender, EntityEventArgs<SFITStudents> e)
            {
                if (e.Entity != null)
                {
                    this.pbSchool.Value = e.Entity.SchoolID;
                    this.pbSchool.Text = e.Entity.SchoolName;
                    this.ddlGrade.SelectedValue = e.Entity.GradeID;
                    this.ddlClass.SelectedValue = e.Entity.ClassID;

                    this.txtStudentCode.Text = e.Entity.StudentCode;
                    this.txtStudentName.Text = e.Entity.SchoolName;

                    this.ddlGender.SelectedValue = e.Entity.Gender.ToString();
                    this.txtJoinYear.Text = e.Entity.JoinYear.ToString();
                    this.txtIDNumber.Text = e.Entity.IDNumber;

                    this.ddlSyncStatus.SelectedValue = e.Entity.SyncStatus.ToString();
                }
            }));
        }

        public override bool DeleteData()
        {
            return false;

        }
        #endregion

        #region ISFITStudentsEditView 成员

        public GUIDEx ClassID
        {
            get { return this.RequestGUIEx("ClassID"); }
        }

        public GUIDEx StudentID
        {
            get { return this.RequestGUIEx("StudentID"); }
        }

        public void BindGrade(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        public void BindClass(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlClass, data);
        }

        public void BindGender(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGender, data);
        }

        public void BindSyncStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSyncStatus, data);
        }
        #endregion

        #region ISFITStudentsView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }
}
