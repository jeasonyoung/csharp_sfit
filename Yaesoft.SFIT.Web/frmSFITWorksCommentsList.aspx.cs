//================================================================================
// FileName: frmSFITWorksCommentsList.aspx.cs
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
	///frmSFITWorksCommentsList�б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITWorksCommentsList : ModuleBasePage, ISFITWorksCommentsListView
    {
        #region ��Ա���������캯����
        SFITWorksCommentsPresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITWorksCommentsList()
        {
            this.presenter = new SFITWorksCommentsPresenter(this);
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

        protected void dgfrmSFITWorksCommentsList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITWorksCommentsList.DataSource = this.presenter.listDataSource;
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
            this.dgfrmSFITWorksCommentsList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteWorksComments(dgfrmSFITWorksCommentsList.CheckedValue);
        }
        #endregion
        
        #region ISFITWorksCommentsListView ��Ա

        public string UnitName
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

        public string CatalogName
        {
            get { return this.txtCatalogName.Text.Trim(); }
        }

        public string StudentName
        {
            get { return this.txtStudentName.Text.Trim(); }
        }

        public string WorkName
        {
            get { return this.txtWorkName.Text.Trim(); }
        }

        public void BindGrades(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        #endregion

        #region ISFITWorksCommentsView ��Ա

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }

}
