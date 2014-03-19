//================================================================================
//  FileName: frmSFITCatalogPicker.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/23
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
using iPower.Web.Utility;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;

using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Service;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmSFITCatalogPicker : ModuleBasePage, ISFITCatalogPickerView
    {
        #region 成员变量，构造函数。
        SFITCatalogPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITCatalogPicker()
        {
            this.presenter = new SFITCatalogPresenter(this);
        }
        #endregion

        #region 事件函数。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.presenter.QueryResult();
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strText = null, strValue = null;
                ListBoxHelper.GetSelected(this.listCatalog, out strText, out strValue);
                if (strText != null && strValue != null)
                    this.SaveData(string.Empty, string.Join("|", strValue));
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }
        #endregion

        #region ISFITCatalogView 成员

        public void BindGrade(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        public void ShowMessage(string msg)
        {
            this.errMsg.Message = msg;
        }

        #endregion

        #region ISFITCatalogPickerView 成员

        public bool IsUnit
        {
            get
            {
                try
                {
                    string str = this.Request["IsUnit"];
                    if (!string.IsNullOrEmpty(str))
                        return bool.Parse(str);
                }
                catch (Exception) { }
                return false;
            }
        }

        public void BindUnits(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSchool, data);
        }

        public GUIDEx UnitID
        {
            get { return this.ddlSchool.SelectedValue; }
        }

        public GUIDEx GradeID
        {
            get { return this.ddlGrade.SelectedValue; }
        }

        public string CatalogName
        {
            get { return this.txtCatalogName.Text.Trim(); }
        }

        public void BindQueryResult(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.listCatalog, data);
        }

        #endregion
    }
}
