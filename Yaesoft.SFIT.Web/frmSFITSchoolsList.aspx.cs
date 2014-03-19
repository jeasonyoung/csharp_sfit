//================================================================================
// FileName: frmSFITSchoolsList.aspx.cs
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
	///frmSFITSchoolsList�б�ҳ���̨���롣
	///</summary>
	public partial class frmSFITSchoolsList:ModuleBasePage,ISFITSchoolsListView
	{
		#region ��Ա���������캯����
		SFITSchoolsPresenter presenter = null;
		///<summary>
		///���캯����
		///</summary>
		public frmSFITSchoolsList()
		{
			this.presenter = new SFITSchoolsPresenter(this);
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

		protected void dgfrmSFITSchoolsList_BuildDataSource(object sender, EventArgs e)
		{
            this.dgfrmSFITSchoolsList.DataSource = this.presenter.ListDataSource;
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
            this.dgfrmSFITSchoolsList.InvokeBuildDataSource();
        }

		public override bool DeleteData()
		{
			return this.presenter.BatchDeleteData(this.dgfrmSFITSchoolsList.CheckedValue);
		}
		#endregion

        #region ISFITSchoolsListView ��Ա

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        #endregion

        #region ISFITSchoolsView ��Ա

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }

}
