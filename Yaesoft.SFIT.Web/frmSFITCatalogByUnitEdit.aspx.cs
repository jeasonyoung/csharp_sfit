//================================================================================
//  FileName: frmSFITCatalogByUnitEdit.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/28
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
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Web
{
    public partial class frmSFITCatalogByUnitEdit : ModuleBasePage, ICatalogByUnitEditView
    {
        #region 成员变量，构造函数。
        SFITCatalogByUnitPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITCatalogByUnitEdit()
        {
            this.presenter = new SFITCatalogByUnitPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }
        protected void ddlGrade_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.presenter.ChangeRefreshBindKnowledgePointsByGrade(this.ddlGrade.SelectedValue);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SFITCatalog data = new SFITCatalog();
                data.CatalogID = this.CatalogID.IsValid ? this.CatalogID : GUIDEx.New;

                data.SchoolID = this.ddlSchool.SelectedValue;
                data.SchoolName = this.ddlSchool.Text;

                data.GradeID = this.ddlGrade.SelectedValue;

                data.CatalogType = int.Parse(this.ddlCatalogType.SelectedValue);

                data.CatalogCode = this.txtCatalogCode.Text.Trim();
                data.CatalogName = this.txtCatalogName.Text.Trim();

                data.OrderNO = int.Parse(this.txtOrderNO.Text);

                data.CreateEmployeeID = this.CurrentUserID;
                data.CreateEmployeeName = this.CurrentUserName;
                data.LastModifyTime = DateTime.Now;

                if (this.presenter.UpdateCatalog(data, this.tvKnowledgePoints.CheckedValue))
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITCatalog>>(delegate(object sender, EntityEventArgs<SFITCatalog> e)
            {
                if (e.Entity != null)
                {
                    this.ddlSchool.SelectedValue = e.Entity.SchoolID;
                    this.ddlGrade.SelectedValue = e.Entity.GradeID;
                    this.ddlCatalogType.SelectedValue = e.Entity.CatalogType.ToString();
                    this.txtCatalogCode.Text = e.Entity.CatalogCode;
                    this.txtCatalogName.Text = e.Entity.CatalogName;
                    
                    this.ddlSchool.Enabled = this.ddlGrade.Enabled = false;
                    if (string.IsNullOrEmpty(e.Entity.SchoolID))
                    {
                        this.btnSave.Enabled = false;
                    }
                }
            }));
        }
        #endregion

        #region ICatalogByUnitEditView 成员

        public GUIDEx CatalogID
        {
            get { return this.RequestGUIEx("CatalogID"); }
        }

        public void BindCatalogType(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlCatalogType, data);
        }

        public void BindKnowledgePoints(iPower.Platform.Engine.DataSource.IListControlsTreeViewData data)
        {
            this.ListControlsDataSourceBind(this.tvKnowledgePoints, data);
        }

        public void SetCatalogKnowledgePoints(System.Collections.Specialized.StringCollection chkPoints)
        {
            if (chkPoints != null && chkPoints.Count > 0)
                this.tvKnowledgePoints.CheckedValue = chkPoints;
        }

        #endregion

        #region ICatalogByUnitView 成员

        public void BindUnit(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSchool, data);   
        }

        public void BindGrade(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

    }
}
