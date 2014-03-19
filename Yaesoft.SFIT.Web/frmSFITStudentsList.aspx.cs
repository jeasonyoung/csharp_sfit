//================================================================================
// FileName: frmSFITStudentsList.aspx.cs
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
	///frmSFITStudentsList�б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITStudentsList : ModuleBasePage, ISFITStudentsListView
    {
        #region ��Ա���������캯����
        SFITStudentsPresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITStudentsList()
        {
            this.presenter = new SFITStudentsPresenter(this);
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

        protected void dgfrmSFITStudentsList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITStudentsList.DataSource = this.presenter.ListDataSource;
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
            this.dgfrmSFITStudentsList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteStudents(this.dgfrmSFITStudentsList.CheckedValue);
        }
        #endregion


        #region ISFITStudentsListView ��Ա

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        public string GradeName
        {
            get { return this.txtGradeName.Text.Trim(); }
        }

        public string ClassName
        {
            get { return this.txtClassName.Text.Trim(); }
        }

        public string StudentName
        {
            get { return this.txtStudentName.Text.Trim(); }
        }

        #endregion

        #region ISFITStudentsView ��Ա

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }
}
