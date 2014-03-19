//================================================================================
// FileName: frmSFITeachersEdit.aspx.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
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
	///frmSFITeachersEdit列表页面后台代码。
	///</summary>
	public partial class frmSFITeachersEdit:ModuleBasePage,ISFITeachersEditView
	{
		#region 成员变量，构造函数。
		SFITeachersPresenter presenter = null;
		///<summary>
		///构造函数。
		///</summary>
		public frmSFITeachersEdit()
		{
			this.presenter = new SFITeachersPresenter(this);
		}
		#endregion

		#region 事件处理。
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

		#region 重载。
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
        
        #region ISFITeachersEditView 成员

        public GUIDEx TeacherID
        {
            get { return this.RequestGUIEx("TeacherID"); }
        }

        public void BindSyncStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSyncStatus, data);
        }

        #endregion

        #region ISFITeachersView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion
    }

}
