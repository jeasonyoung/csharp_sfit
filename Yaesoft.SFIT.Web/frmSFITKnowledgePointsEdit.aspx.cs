//================================================================================
// FileName: frmSFITKnowledgePointsEdit.aspx.cs
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
	///frmSFITKnowledgePointsEdit列表页面后台代码。
	///</summary>
    public partial class frmSFITKnowledgePointsEdit : ModuleBasePage, ISFITKnowledgePointsEditView
    {
        #region 成员变量，构造函数。
        SFITKnowledgePointsPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITKnowledgePointsEdit()
        {
            this.presenter = new SFITKnowledgePointsPresenter(this);

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
                SFITKnowledgePoints data = new SFITKnowledgePoints();
                data.PointID = this.PointID.IsValid ? this.PointID : GUIDEx.New;
                data.GradeID = this.panelGrade.Visible ? new GUIDEx(this.ddlGrade.SelectedValue) : GUIDEx.Null;
                data.PointCode = this.txtPointCode.Text.Trim();
                data.PointName = this.txtPointName.Text.Trim();
                data.OrderNO = int.Parse(this.txtOrderNO.Text);
                data.Description = this.txtDescription.Text;
                data.ParentPointID = this.panelParentPoint.Visible ? new GUIDEx(this.ddlParentPointID.SelectedValue) : this.ParentPointID;
                if (this.presenter.UpdateKnowledgePoints(data))
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITKnowledgePoints>>(delegate(object sender, EntityEventArgs<SFITKnowledgePoints> e)
            {
                if (e.Entity != null)
                {
                    bool gradeVisible = this.panelGrade.Visible = !(this.panelParentPoint.Visible = e.Entity.ParentPointID.IsValid);
                    this.ddlParentPointID.SelectedValue = e.Entity.ParentPointID;
                    if (gradeVisible)
                        this.ddlGrade.SelectedValue = e.Entity.GradeID;
                    this.txtPointCode.Text = e.Entity.PointCode;
                    this.txtPointName.Text = e.Entity.PointName;
                    this.txtOrderNO.Text = e.Entity.OrderNO.ToString();
                    this.txtDescription.Text = e.Entity.Description;
                }
            }));
            this.panelGrade.Visible = !this.panelParentPoint.Visible;
        }

        public override bool DeleteData()
        {
            return false;

        }
        #endregion

        #region ISFITKnowledgePointsEditView 成员

        public GUIDEx PointID
        {
            get { return this.RequestGUIEx("PointID"); }
        }

        public GUIDEx ParentPointID
        {
            get
            {
                GUIDEx p = this.RequestGUIEx("ParentPointID");
                if (this.panelParentPoint.Visible = p.IsValid)
                {
                    this.ddlParentPointID.SelectedValue = p;
                    return p;
                }
                return this.ddlParentPointID.SelectedValue;
            }
        }

        public void BindParentPoints(iPower.Platform.Engine.DataSource.IListControlsTreeViewData data)
        {
            this.ListControlsDataSourceBind(this.ddlParentPointID, data);
        }

        public void BindGrade(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            if (this.panelGrade.Visible)
                this.ListControlsDataSourceBind(this.ddlGrade, data);
        }
        #endregion

        #region ISFITKnowledgePointsView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }
}
