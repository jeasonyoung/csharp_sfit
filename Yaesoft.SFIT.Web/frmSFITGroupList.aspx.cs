//================================================================================
//  FileName: frmSFITHobbyGroupList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/17
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
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmSFITGroupList : ModuleBasePage, ISFITGroupListView
    {
        #region  成员变量，构造函数。
        SFITGroupPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITGroupList()
        {
            this.presenter = new SFITGroupPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.SecurityID = this.SID;
                this.presenter.InitializeComponent();
                this.lbTitle.Text = this.NavigationContent;
                string url = this.btnAdd.PickerPage.Split('?')[0];
                if (!string.IsNullOrEmpty(url))
                {
                    this.btnAdd.PickerPage = string.Format("{0}?Type={1}&IsUnit={2}", url, this.GroupType, this.IsUnit);
                }
            }
        }
        protected void dgfrmSFITGroupList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITGroupList.DataSource = this.presenter.ListDataSource;
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

        #region 重载。
        public override void LoadData()
        {
            this.dgfrmSFITGroupList.InvokeBuildDataSource();
        }
        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteData(this.dgfrmSFITGroupList.CheckedValue);
        }
        #endregion
        
        #region ISFITGroupListView 成员

        public GUIDEx SID
        {
            get { return this.RequestGUIEx("SID"); }
        }

        public string SchoolName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        public string GroupName
        {
            get { return this.txtGroupName.Text.Trim(); }
        }

        #endregion

        #region ISFITGroupView 成员

        public int GroupType
        {
            get
            {
                try
                {
                    string s = this.Request["GroupType"];
                    if (!string.IsNullOrEmpty(s))
                        return int.Parse(s);
                }
                catch (Exception) { }
                return 0;
            }
        }
        public bool IsUnit
        {
            get
            {
                try
                {
                    string s = this.Request["IsUnit"];
                    if (!string.IsNullOrEmpty(s))
                        return bool.Parse(s);
                }
                catch (Exception) { }
                return false;
            }
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }
}
