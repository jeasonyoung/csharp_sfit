//================================================================================
//  FileName: UCStudentWork.ascx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/10
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
    public partial class UCStudentWork : ModuleBaseControl, IUCStudentWorkView
    {
        #region 成员变量，构造函数。
        UCStudentWorkPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCStudentWork()
        {
            this.presenter = new UCStudentWorkPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }
        #endregion

        #region IUCStudentWorkView 成员

        public void BindWorkStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.chkWorkStatus, data);
        }

        public void BindWorkType(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlWorkType, data);
        }

        public bool LoadData(GUIDEx workID)
        {
            SFITStudentWorks data = this.presenter.LoadEntityData(workID);
            if (data != null)
            {
                this.txtWorkName.Text = data.WorkName;
                this.txtCheckCode.Text = data.CheckCode;

                this.chkWorkStatus.CheckedValueToArray = EnumWorkStatusOperaTools.ToArray((EnumWorkStatus)data.WorkStatus);
                this.ddlWorkType.SelectedValue = data.WorkType.ToString();

                this.txtWorkDescription.Text = data.WorkDescription;

                this.txtSchoolName.Text = data.SchoolName;
                this.txtGradeName.Text = data.GradeName;
                this.txtClassName.Text = data.ClassName;
                this.txtStudentName.Text = data.StudentName;
                this.txtCatalogName.Text = data.CatalogName;

                return true;
            }
            return false;
        }

        public bool SaveData(GUIDEx workID)
        {
            if (workID.IsValid)
            {
                SFITStudentWorks data = new SFITStudentWorks();
                data.WorkID = workID;
                data.WorkName = this.txtWorkName.Text;
                data.WorkStatus = (int)EnumWorkStatusOperaTools.ToValue(this.chkWorkStatus.CheckedValueToArray);
                data.WorkType = int.Parse(this.ddlWorkType.SelectedValue);
                data.WorkDescription = this.txtWorkDescription.Text;

                return this.presenter.UpdateEntityData(data);
            }
            return false;
        }

        #endregion
    }
}