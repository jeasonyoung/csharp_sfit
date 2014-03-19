//================================================================================
// FileName: frmSFITKnowledgePointsList.aspx.cs
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
using System.Data;

using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
	///<summary>
	///frmSFITKnowledgePointsList列表页面后台代码。
	///</summary>
    public partial class frmSFITKnowledgePointsList : ModuleBasePage, ISFITKnowledgePointsListView
    {
        #region 成员变量，构造函数。
        SFITKnowledgePointsPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITKnowledgePointsList()
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
                this.lbTitle.Text = this.NavigationContent;
                this.tvKnowledgePoints.Visible = !(this.dgfrmSFITopKnowledgePointsList.Visible = this.panelSearch.Visible = !this.TopPointID.IsValid);
            }
        }

        protected void dgfrmSFITopKnowledgePointsList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITopKnowledgePointsList.DataSource = this.presenter.ListDataSource;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteData())
                this.LoadData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            if (this.TopPointID.IsValid)
            {
                this.dgfrmSFITopKnowledgePointsList.Visible = false;

                string url = this.btnAdd.PickerPage.Split('?')[0];
                if (!string.IsNullOrEmpty(url))
                    this.btnAdd.PickerPage = string.Format("{0}?ParentPointID={1}", url, this.TopPointID);

                DataTable dtSource = this.presenter.ListDataSource;
                if (dtSource != null)
                {
                    dtSource.Columns.Add("ClickAction", typeof(string));
                    foreach (DataRow row in dtSource.Rows)
                    {
                        row["ClickAction"] = string.Format("tvKnowledgePointsOpenEdit('{0}');", row["PointID"]);
                    }

                    this.tvKnowledgePoints.DataSource = dtSource;
                    this.tvKnowledgePoints.IDField = "PointID";
                    this.tvKnowledgePoints.TitleField = "PointNameCode";
                    this.tvKnowledgePoints.PIDField = "ParentPointID";
                    this.tvKnowledgePoints.ClickActionField = "ClickAction";
                    this.tvKnowledgePoints.BuildTree();
                }
            }
            else
                this.dgfrmSFITopKnowledgePointsList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            if (this.dgfrmSFITopKnowledgePointsList.Visible)
                return this.presenter.BatchDeleteKnowledgePoints(this.dgfrmSFITopKnowledgePointsList.CheckedValue);
            else if (this.tvKnowledgePoints.Visible)
                return this.presenter.BatchDeleteKnowledgePoints(this.tvKnowledgePoints.CheckedValue);
            return false;
        }
        #endregion

        #region ISFITKnowledgePointsView 成员

        public void BindGrade(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region ISFITKnowledgePointsListView 成员

        public GUIDEx TopPointID
        {
            get { return this.RequestGUIEx("TopPointID"); }
        }

        public GUIDEx GradeID
        {
            get
            {
                if (this.panelSearch.Visible)
                    return this.ddlGrade.SelectedValue;
                return GUIDEx.Null;
            }
        }

        public string PointsName
        {
            get { return this.txtPointName.Text.Trim(); }
        }

        #endregion
    }
}
