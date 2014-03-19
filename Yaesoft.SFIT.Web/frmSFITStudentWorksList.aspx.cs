//================================================================================
// FileName: frmSFITStudentWorksCollectList.aspx.cs
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
	///frmSFITStudentWorktsList�б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITStudentWorksList : ModuleBasePage, ISFITStudentWorksListView
    {
        #region ��Ա���������캯����
        SFITStudentWorksPresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITStudentWorksList()
        {
            this.presenter = new SFITStudentWorksPresenter(this);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
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
        #endregion

        #region ���ء�
        public override void LoadData()
        {
            this.ucStudentWorksList.LoadData(this.presenter.ListDataSource);
        }
        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteEntityData(this.ucStudentWorksList.GetSelected);
        }
        #endregion


        #region ISFITStudentWorksListView ��Ա

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        public GUIDEx GradeID
        {
            get { return this.ddlGrade.SelectedValue; }
        }

        public string ClassName
        {
            get { return this.txtClassName.Text.Trim(); }
        }

        public string StudentName
        {
            get { return this.txtStudentName.Text.Trim(); }
        }
        public string WorkName
        {
            get { return this.txtWorkName.Text.Trim(); }
        }
        public GUIDEx WorkStatusID
        {
            get { return this.ddlWorkStatus.SelectedValue; }
        }

        public void BindGrade(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        public void BindWorkStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlWorkStatus, data);
        }

        #endregion

        #region ISFITStudentWorksView ��Ա

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

    }

}
