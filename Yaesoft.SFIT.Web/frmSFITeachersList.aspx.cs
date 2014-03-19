//================================================================================
// FileName: frmSFITeachersList.aspx.cs
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
	///frmSFITeachersList�б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITeachersList : ModuleBasePage, ISFITeachersListView
    {
        #region ��Ա���������캯����
        SFITeachersPresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITeachersList()
        {
            this.presenter = new SFITeachersPresenter(this);
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

        protected void dgfrmSFITeachersList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITeachersList.DataSource = this.presenter.ListDataSource;
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
            this.dgfrmSFITeachersList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteTeachers(this.dgfrmSFITeachersList.CheckedValue);
        }
        #endregion
        
        #region ISFITeachersListView ��Ա

        public string TeacherName
        {
            get { return this.txtTeacherName.Text.Trim(); }
        }

        public GUIDEx SchoolID
        {
            get { return this.ddlSchool.SelectedValue; }
        }

        public void BindSchools(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSchool, data);
        }
        #endregion

        #region ISFITeachersView ��Ա

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion
    }
}
