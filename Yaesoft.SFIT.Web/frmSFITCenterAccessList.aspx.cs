//================================================================================
// FileName: frmSFITCenterAccessList.aspx.cs
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
using System.Collections.Specialized;
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
	///frmSFITCenterAccessList�б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITCenterAccessList : ModuleBasePage, ISFITCenterAccessListView
    {
        #region ��Ա���������캯����
        SFITCenterAccessPresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITCenterAccessList()
        {
            this.presenter = new SFITCenterAccessPresenter(this);
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

        protected void dgfrmSFITCenterAccessList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITCenterAccessList.DataSource = this.presenter.ListDataSource;
        }

        protected void btnBuild_OnClick(object sender, EventArgs e)
        {
            try
            {
                StringCollection collection = this.dgfrmSFITCenterAccessList.CheckedValue;
                if (collection != null && collection.Count > 0)
                {
                    string[] arr = new string[collection.Count];
                    collection.CopyTo(arr, 0);
                    this.Response.Redirect(string.Format("CreateCredentials.ashx?AccessID={0}", string.Join(",", arr)), true);
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
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
            this.dgfrmSFITCenterAccessList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return this.presenter.BatchDelete(this.dgfrmSFITCenterAccessList.CheckedValue);
        }
        #endregion
        
        #region ISFITCenterAccessListView ��Ա

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }
        #endregion

        #region ISFITCenterAccessView ��Ա

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

    }

}
