//================================================================================
// FileName: frmSFITeachersEdit.aspx.cs
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
	///frmSFITeachersEdit�б�ҳ���̨���롣
	///</summary>
	public partial class frmSFITeachersEdit:ModuleBasePage,ISFITeachersEditView
	{
		#region ��Ա���������캯����
		SFITeachersPresenter presenter = null;
		///<summary>
		///���캯����
		///</summary>
		public frmSFITeachersEdit()
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
			}
		}
			
		protected void btnSave_Click(object sender, EventArgs e)
		{
            try
            {
                SFITeachers data = new SFITeachers();
                data.TeacherID = this.TeacherID.IsValid ? this.TeacherID : GUIDEx.New;
                data.TeacherCode = this.txtTeacherCode.Text.Trim();
                data.TeacherName = this.txtTeacherName.Text.Trim();
                data.SchoolID = this.pbSchool.Value;
                data.SchoolName = this.pbSchool.Text;
                data.SyncStatus = int.Parse(this.ddlSyncStatus.SelectedValue);

                if (this.presenter.UpdateTeachers(data))
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITeachers>>(delegate(object sender, EntityEventArgs<SFITeachers> e)
            {
                if (e.Entity != null)
                {
                    this.txtTeacherCode.Text = e.Entity.TeacherCode;
                    this.txtTeacherName.Text = e.Entity.TeacherName;

                    this.pbSchool.Text = e.Entity.SchoolName;
                    this.pbSchool.Value = e.Entity.SchoolID;

                    this.ddlSyncStatus.SelectedValue = e.Entity.SyncStatus.ToString();
                }
            }));
		}
			
		public override bool DeleteData()
		{
			return false;

		}
		#endregion
        
        #region ISFITeachersEditView ��Ա

        public GUIDEx TeacherID
        {
            get { return this.RequestGUIEx("TeacherID"); }
        }

        public void BindSyncStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSyncStatus, data);
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
