//================================================================================
// FileName: frmSFITClassEdit.aspx.cs
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
	///frmSFITClassEdit列表页面后台代码。
	///</summary>
    public partial class frmSFITClassEdit : ModuleBasePage, ISFITClassEditView
    {
        #region 成员变量，构造函数。
        SFITClassPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITClassEdit()
        {
            this.presenter = new SFITClassPresenter(this);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SFITClass data = new SFITClass();
                data.ClassID = this.ClassID.IsValid ? this.ClassID : GUIDEx.New;
                data.SchoolID = this.pbSchool.Value;
                data.GradeID = this.ddlGrade.SelectedValue;
                data.ClassCode = this.txtClassCode.Text.Trim();
                data.ClassName = this.txtClassName.Text.Trim();
                data.JoinYear = int.Parse(this.txtJoinYear.Text);
                data.OrderNO = int.Parse(this.txtOrderNO.Text);
                data.SyncStatus = int.Parse(this.ddlSyncStatus.SelectedValue);

                if (this.presenter.UpdateClass(data))
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITClass>>(delegate(object sender, EntityEventArgs<SFITClass> e)
            {
                if (e.Entity != null)
                {
                    this.pbSchool.Value = e.Entity.SchoolID;
                    this.pbSchool.Text = e.Entity.SchoolName;
                    this.ddlGrade.SelectedValue = e.Entity.GradeID;

                    this.txtClassCode.Text = e.Entity.ClassCode;
                    this.txtClassName.Text = e.Entity.ClassName;
                    this.txtJoinYear.Text = e.Entity.JoinYear.ToString();

                    this.txtOrderNO.Text = e.Entity.OrderNO.ToString();
                    this.ddlSyncStatus.SelectedValue = e.Entity.SyncStatus.ToString();
                }
            }));
        }

        public override bool DeleteData()
        {
            return false;

        }
        #endregion

        #region ISFITClassEditView 成员

        public GUIDEx ClassID
        {
            get { return this.RequestGUIEx("ClassID"); }
        }

        public void BindGrades(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        public void BindSyncStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSyncStatus, data);
        }
        #endregion

        #region ISFITClassView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion

    }

}
