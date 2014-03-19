//================================================================================
//  FileName: frmSFITSchoolPicker.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/13
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

using iPower.Web.Utility;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    public partial class frmSFITSchoolPicker : ModuleBasePage, ISchoolPickerView
    {
        #region 成员变量，构造函数。
        SFITSchoolPickerPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITSchoolPicker()
        {
            this.presenter = new SFITSchoolPickerPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            this.presenter.QuerySchool();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] text = new string[0], values = new string[0];
            if (this.MultiSelect)
                ListBoxHelper.GetAll(this.listSchool, out text, out values);
            else
                ListBoxHelper.GetSelected(this.listSchool, out text, out values);
            if (values != null && values.Length > 0)
                this.SaveData(string.Join(",", text), string.Join(",", values));
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            base.LoadData();
            this.listSchool.SelectionMode = this.MultiSelect ? ListSelectionMode.Multiple : ListSelectionMode.Single;
        }
        #endregion


        #region IPickerView 成员

        public void BindSearchResult(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            if (data != null)
            {
                this.ListControlsDataSourceBind(this.listSchool, data);
                if (this.Values != null && this.Values.Length > 0)
                {
                    string[] sValue = this.Values;
                    foreach (ListItem item in this.listSchool.Items)
                    {
                        item.Selected = (Array.BinarySearch(sValue, item.Value) > -1);
                    }
                }
            }
        }

        public bool MultiSelect
        {
            get
            {
                bool result = false;
                try
                {
                    string str = this.Request["MultiSelect"];
                    if (!string.IsNullOrEmpty(str))
                        result = bool.Parse(str);
                }
                catch{}
                return result;
            }
        }

        public string[] Values
        {
            get
            {
                string strValue = this.Request["Value"];
                if (!string.IsNullOrEmpty(strValue))
                    return strValue.Split(',');
                return null;
            }
        }

        #endregion

        #region ISchoolPickerView 成员

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        #endregion
    }
}
