//================================================================================
// FileName: frmSFITCatalogList.aspx.cs
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
	///<summary>
	///frmSFITCatalogList�б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITCatalogList : ModuleBasePage, ISFITCatalogListView
    {
        #region ��Ա���������캯����
        SFITCatalogPresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITCatalogList()
        {
            this.presenter = new SFITCatalogPresenter(this);
        }
        #endregion

        #region �¼�����
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.presenter.InitializeComponent();
                this.lbTitle.Text = this.NavigationContent;
            }
        }

        protected void dgfrmSFITCatalogList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITCatalogList.DataSource = this.presenter.ListDataSource;
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

        #region ���ء�
        public override void LoadData()
        {
            this.dgfrmSFITCatalogList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.DeleteCatalog(this.dgfrmSFITCatalogList.CheckedValue);
        }
        #endregion

        #region ISFITCatalogListView ��Ա

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        public GUIDEx GradeID
        {
            get { return this.ddlGrade.SelectedValue; }
        }

        public string CatalogName
        {
            get { return this.txtCatalogName.Text.Trim(); }
        }
        #endregion

        #region ISFITCatalogView ��Ա

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
