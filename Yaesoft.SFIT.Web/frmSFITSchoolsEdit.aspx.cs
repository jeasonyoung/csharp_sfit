//================================================================================
// FileName: frmSFITSchoolsEdit.aspx.cs
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
	///frmSFITSchoolsEdit列表页面后台代码。
	///</summary>
    public partial class frmSFITSchoolsEdit : ModuleBasePage, ISFITSchoolsEditView
    {
        #region 成员变量，构造函数。
        SFITSchoolsPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITSchoolsEdit()
        {
            this.presenter = new SFITSchoolsPresenter(this);

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
                SFITSchools data = new SFITSchools();
                data.SchoolID = this.SchoolID.IsValid ? this.SchoolID : GUIDEx.New;
                data.SchoolCode = this.txtSchoolCode.Text;
                data.SchoolName = this.txtSchoolName.Text;
                data.SchoolType = int.Parse(this.ddlSchoolType.SelectedValue);
                data.OrderNO = int.Parse(this.txtOrderNO.Text);
                data.SyncStatus = int.Parse(this.ddlSyncStatus.SelectedValue);

                if (this.presenter.UpdateSFITSchools(data))
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITSchools>>(delegate(object sender, EntityEventArgs<SFITSchools> e)
            {
                if (e.Entity != null)
                {
                    this.txtSchoolCode.Text = e.Entity.SchoolCode;
                    this.txtSchoolName.Text = e.Entity.SchoolName;
                    this.ddlSchoolType.SelectedValue = e.Entity.SchoolType.ToString();
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

        #region ISFITSchoolsEditView 成员

        public GUIDEx SchoolID
        {
            get { return this.RequestGUIEx("SchoolID"); }
        }

        public void BindSyncStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSyncStatus, data);
        }

        public void BindSchoolType(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSchoolType, data);
        }
        #endregion

        #region ISFITSchoolsView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }

}
