//================================================================================
// FileName: frmSFITClassList.aspx.cs
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
	///frmSFITClassList�б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITClassList : ModuleBasePage, ISFITClassListView
    {
        #region ��Ա���������캯����
        SFITClassPresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITClassList()
        {
            this.presenter = new SFITClassPresenter(this);
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

        protected void dgfrmSFITClassList_BuildDataSource(object sender, EventArgs e)
        {
                this.dgfrmSFITClassList.DataSource = this.presenter.ListDataSource;
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
            this.dgfrmSFITClassList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteClass(this.dgfrmSFITClassList.CheckedValue);
        }
        #endregion

        #region ISFITClassView ��Ա

        public GUIDEx GradeID
        {
            get { return this.ddlGrade.SelectedValue; }
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        public void BindGrades(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }
        #endregion

        #region ISFITClassListView ��Ա

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        public string ClassName
        {
            get { return this.txtClassName.Text.Trim(); }
        }
        #endregion

    }

}
