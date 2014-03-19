//================================================================================
// FileName: frmSFITTeaClassEdit.aspx.cs
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
	///frmSFITTeaClassEdit列表页面后台代码。
	///</summary>
    public partial class frmSFITTeaClassEdit : ModuleBasePage, ISFITTeaClassEditView
    {
        #region 成员变量，构造函数。
        SFITTeaClassPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITTeaClassEdit()
        {
            this.presenter = new SFITTeaClassPresenter(this);
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

        protected void pbSchool_OnTextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.pbSchool.Value))
            {
                string url = this.pbTeacher.PickerPage.Split('?')[0];
                this.pbTeacher.PickerPage = string.Format("{0}?SchoolID={1}", url, this.Server.UrlEncode(this.pbSchool.Value));
            }
            this.presenter.ChangeSchool(this.pbSchool.Value);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tvStudents.CheckedValue.Count > 0)
                {
                    SchoolTeacherInfo data = new SchoolTeacherInfo();
                    data.SchoolID = this.pbSchool.Value;
                    data.SchoolName = this.pbSchool.Text;
                    data.TeacherID = this.pbTeacher.Value;
                    data.TeacherName = this.pbTeacher.Text;
                    data.ClassIDCollection = this.tvStudents.CheckedValue;

                    if (this.presenter.UpdateTeaClass(data))
                        this.SaveData();
                }
                else
                    throw new Exception("请选择班级！");
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SchoolTeacherInfo>>(delegate(object sender, EntityEventArgs<SchoolTeacherInfo> e)
            {
                if (e != null && e.Entity != null)
                {
                    this.pbSchool.Text = e.Entity.SchoolName;
                    this.pbSchool.Value = e.Entity.SchoolID;

                    this.pbTeacher.Text = e.Entity.TeacherName;
                    this.pbTeacher.Value = e.Entity.TeacherID;

                    this.pbSchool_OnTextChanged(null, EventArgs.Empty);

                    this.pbSchool.Enabled = this.pbTeacher.Enabled = false;

                    this.tvStudents.CheckedValue = e.Entity.ClassIDCollection;
                }
            }));
        }

        public override bool DeleteData()
        {
            return false;

        }
        #endregion

        #region ISFITTeaClassView 成员

        public GUIDEx SchoolID
        {
            get { return this.pbSchool.Value; }
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion

        #region ISFITTeaClassEditView 成员

        public GUIDEx TeacherID
        {
            get { return this.RequestGUIEx("TeacherID"); }
        }

        public void BindClasses(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.tvStudents, data);
        }
        #endregion

    }

}
