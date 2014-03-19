//================================================================================
// FileName: frmSFITCatalogEdit.aspx.cs
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
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Web
{
    ///<summary>
    ///frmSFITCatalogEdit列表页面后台代码。
    ///</summary>
    public partial class frmSFITCatalogEdit : ModuleBasePage, ISFITCatalogEditView
    {
        #region 成员变量，构造函数。
        SFITCatalogPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITCatalogEdit()
        {
            this.presenter = new SFITCatalogPresenter(this);
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
            this.presenter.ChangeRefreshBindKnowledgePointsByGrade(this.ddlGrade.SelectedValue);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SFITCatalog data = new SFITCatalog();
                data.CatalogID = this.CatalogID.IsValid ? this.CatalogID : GUIDEx.New;

                data.SchoolID = this.pbSchool.Value;
                data.SchoolName = this.pbSchool.Text;

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
            this.pbSchool.Text = "[全区必修]";
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITCatalog>>(delegate(object sender, EntityEventArgs<SFITCatalog> e)
            {
                if (e.Entity != null)
                {
                    if (e.Entity.SchoolID.IsValid)
                    {
                        this.pbSchool.Value = e.Entity.SchoolID;
                        this.pbSchool.Text = e.Entity.SchoolName;
                    }
                    this.ddlGrade.SelectedValue = e.Entity.GradeID;
                    this.ddlCatalogType.SelectedValue = e.Entity.CatalogType.ToString();
                    this.txtCatalogCode.Text = e.Entity.CatalogCode;
                    this.txtCatalogName.Text = e.Entity.CatalogName;
                    this.txtOrderNO.Text = string.Format("{0}", e.Entity.OrderNO);
                    this.ddlGrade.Enabled = false;
                }
            }));
        }

        public override bool DeleteData()
        {
            return false;
        }
        #endregion

        #region ISFITCatalogView 成员

        public void BindGrade(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region ISFITCatalogEditView 成员
        
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
            this.tvKnowledgePoints.CheckedValue = chkPoints;
        }

        #endregion
    }

}
