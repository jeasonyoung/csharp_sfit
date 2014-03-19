//================================================================================
// FileName: frmSFITCenterAccessEdit.aspx.cs
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
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
	///<summary>
	///��������б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITCenterAccessEdit : ModuleBasePage, ISFITCenterAccessEditView
    {
        #region ��Ա���������캯����
        SFITCenterAccessPresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITCenterAccessEdit()
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
            }
        }

        protected void pbSchool_OnTextChanged(object sender, EventArgs e)
        {
            this.txtAccessAccount.Text = this.pbSchool.Value;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SFITCenterAccess data = new SFITCenterAccess();
                data.AccessID = this.AccessID.IsValid ? this.AccessID : GUIDEx.New;
                data.SchoolID = this.pbSchool.Value;
                data.SchoolName = this.pbSchool.Text;
                data.AccessAccount = this.txtAccessAccount.Text.Trim();
                data.AccessPassword = this.txtAccessPassword.Text.Trim();
                data.AccessStatus = int.Parse(this.ddlAccessStatus.SelectedValue);
                data.Description = this.txtDescription.Text.Trim();
                data.CreateEmployeeID = this.CurrentUserID;
                data.CreateEmployeeName = this.CurrentUserName;
                data.CreateDateTime = DateTime.Now;

                if (this.presenter.UpdateCenterAccess(data))
                    this.SaveData();
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
        #endregion

        #region ���ء�
        public override void LoadData()
        {
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITCenterAccess>>(delegate(object sender, EntityEventArgs<SFITCenterAccess> e)
            {
                if (e.Entity != null)
                {
                    this.pbSchool.Text = e.Entity.SchoolName;
                    this.pbSchool.Value = e.Entity.SchoolID;
                    this.txtAccessAccount.Text = e.Entity.AccessAccount;
                    this.txtAccessPassword.Text = e.Entity.AccessPassword;
                    this.ddlAccessStatus.SelectedValue = e.Entity.AccessStatus.ToString();
                    this.txtDescription.Text = e.Entity.Description;
                }
            }));
        }

        public override bool DeleteData()
        {
            return false;

        }
        #endregion


        #region ISFITCenterAccessEditView ��Ա

        public GUIDEx AccessID
        {
            get { return this.RequestGUIEx("AccessID"); }
        }

        public void BindAccessStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlAccessStatus, data);
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
