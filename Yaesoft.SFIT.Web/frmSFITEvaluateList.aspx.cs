//================================================================================
// FileName: frmSFITEvaluateList.aspx.cs
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
	///frmSFITEvaluateList�б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITEvaluateList : ModuleBasePage, ISFITEvaluateListView
    {
        #region ��Ա���������캯����
        SFITEvaluatePresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITEvaluateList()
        {
            this.presenter = new SFITEvaluatePresenter(this);

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

        protected void dgfrmSFITEvaluateList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITEvaluateList.DataSource = this.presenter.ListDataSource;

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
            this.dgfrmSFITEvaluateList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteEvaluate(this.dgfrmSFITEvaluateList.CheckedValue);
        }
        #endregion

        #region ISFITEvaluateView ��Ա

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region ISFITEvaluateListView ��Ա

        public string EvaluateName
        {
            get { return this.txtEvaluateName.Text; }
        }

        #endregion
    }

}
