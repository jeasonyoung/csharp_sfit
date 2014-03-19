//================================================================================
//  FileName: frmSFITGroupList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/24
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
using iPower.Web.UI;
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
    public partial class frmSFITGroupWorksList : ModuleBasePage, ISFITGroupWorksListView
    {
        #region 成员变量，构造函数。
        SFITGroupWorksPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITGroupWorksList()
        {
            this.presenter = new SFITGroupWorksPresenter(this);
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
            }
        }

        protected void dgfrmSFITGroupWorksList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITGroupWorksList.DataSource = this.presenter.ListDataSource;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DeleteData())
                    this.LoadData();
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.dgfrmSFITGroupWorksList.InvokeBuildDataSource();
        }
        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteWorksEntity(this.dgfrmSFITGroupWorksList.CheckedValue);
        }
        #endregion

        #region ISFITGroupView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region ISFITGroupListView 成员

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

        public GUIDEx SID
        {
            get { return this.RequestGUIEx("SID"); }
        }

        public string UnitName
        {
            get { return this.txtSchoolName.Text.Trim(); }
        }

        public string GroupName
        {
            get { return this.txtGroupName.Text.Trim(); }
        }

        public string CatalogName
        {
            get { return this.txtCatalogName.Text.Trim(); }
        }

        public string StudentName
        {
            get { return this.txtStudentName.Text.Trim(); }
        }

        #endregion
    }
}
