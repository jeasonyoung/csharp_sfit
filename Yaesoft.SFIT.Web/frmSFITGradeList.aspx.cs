//================================================================================
// FileName: frmSFITGradeList.aspx.cs
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
	///frmSFITGradeList�б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITGradeList : ModuleBasePage, ISFITGradeListView
    {
        #region ��Ա���������캯����
        SFITGradePresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITGradeList()
        {
            this.presenter = new SFITGradePresenter(this);
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

        protected void dgfrmSFITGradeList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITGradeList.DataSource = this.presenter.ListDataSource;
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
            this.dgfrmSFITGradeList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteGrade(this.dgfrmSFITGradeList.CheckedValue);
        }
        #endregion

        #region ISFITGradeListView ��Ա

        public GUIDEx LearnLevelID
        {
            get { return this.ddlLearnLevel.SelectedValue; }
        }

        public string GradeName
        {
            get { return this.txtGradeName.Text.Trim(); }
        }

        #endregion

        #region ISFITGradeView ��Ա

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        
        public void BindLearnLevel(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlLearnLevel, data);
        }

        #endregion
    }
}
