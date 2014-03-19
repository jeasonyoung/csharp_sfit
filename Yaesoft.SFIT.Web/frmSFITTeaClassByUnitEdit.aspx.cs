//================================================================================
//  FileName: frmSFITTeaClassByUnitEdit.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/9
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
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
    /// <summary>
    /// 
    /// </summary>
    public partial class frmSFITTeaClassByUnitEdit : ModuleBasePage, ISFITTeaClassByUnitEditView
    {
        #region 成员变量，构造函数。
        SFITTeaClassByUnitPresenter presenter = null;
        /// <summary>
        /// 
        /// </summary>
        public frmSFITTeaClassByUnitEdit()
        {
            this.presenter = new SFITTeaClassByUnitPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }

        protected void ddlSchool_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string schoolID = string.Empty;
            if (!string.IsNullOrEmpty(schoolID = this.ddlSchool.SelectedValue))
            {
                string url = this.pbTeacher.PickerPage.Split('?')[0];
                this.pbTeacher.PickerPage = string.Format("{0}?SchoolName={1}", url, this.Server.UrlEncode(this.presenter.GetSchoolName(schoolID)));
                this.presenter.ChangeSchool(schoolID);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tvStudents.CheckedValue.Count > 0)
                {
                    SchoolTeacherInfo data = new SchoolTeacherInfo();
                    data.SchoolID = this.ddlSchool.SelectedValue;
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SchoolTeacherInfo>>(new EventHandler<EntityEventArgs<SchoolTeacherInfo>>(delegate(object sender, EntityEventArgs<SchoolTeacherInfo> e)
            {
                if (e != null && e.Entity != null)
                {
                    this.ddlSchool.SelectedValue = e.Entity.SchoolID;

                    this.pbTeacher.Text = e.Entity.TeacherName;
                    this.pbTeacher.Value = e.Entity.TeacherID;

                    this.ddlSchool_OnSelectedIndexChanged(null, EventArgs.Empty);

                    this.ddlSchool.Enabled = this.pbTeacher.Enabled = false;

                    this.tvStudents.CheckedValue = e.Entity.ClassIDCollection;
                }
            })));
        }
        #endregion

        #region ISFITTeaClassByUnitEditView 成员

        public GUIDEx TeacherID
        {
            get { return this.RequestGUIEx("TeacherID"); }
        }

        public void BindClasses(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.tvStudents, data);
        }

        #endregion

        #region ISFITTeaClassByUnitView 成员

        public void BindUnit(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSchool, data);
        }

        public void ShowMessage(string message)
        {
            this.errMessage.Message = message;
        }

        #endregion
    }
}
