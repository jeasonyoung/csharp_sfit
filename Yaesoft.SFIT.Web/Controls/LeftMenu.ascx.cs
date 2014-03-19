//================================================================================
//  FileName: LeftMenu.ascx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/2/23
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
using System.Data;

using iPower;
using iPower.Utility;
using iPower.Platform;
using iPower.IRMP.Engine.Service;
namespace Yaesoft.SFIT.Web.Controls
{
    /// <summary>
    /// 左边菜单用户控件。
    /// </summary>
    public partial class LeftMenu : ModuleBaseControl,IModuleView
    {
        #region 成员变量，构造函数。
        ModulePresenter<IModuleView> presenter = null;
        DataTable dtSource = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public LeftMenu()
        {
            this.dtSource = new DataTable();
            this.dtSource.Columns.Add("ModuleID", typeof(System.String));
            this.dtSource.Columns.Add("ParentModuleID", typeof(System.String));
            this.dtSource.Columns.Add("ModuleName", typeof(System.String));
            this.dtSource.Columns.Add("ModuleUri", typeof(System.String));
            this.dtSource.Columns.Add("OrderNo", typeof(System.Int32));
            this.dtSource.PrimaryKey = new DataColumn[] { this.dtSource.Columns["ModuleID"] };

            this.presenter = new ModulePresenter<IModuleView>(this);

        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置菜单风格类型。
        /// </summary>
        public EnumMenuType MenuType
        {
            get
            {
                object obj = this.ViewState["MenuType"];
                return obj == null ? EnumMenuType.Outlook : (EnumMenuType)obj;
            }
            set
            {
                this.ViewState["MenuType"] = value;
            }
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.presenter.InitializeComponent();
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.Page.LoadComplete += new EventHandler(delegate(object sender, EventArgs e)
            {
                ModuleDefineCollection collection = this.MenuData;
                if (collection != null)
                {
                    this.BuilderModuleDefineDataSource(ref this.dtSource, collection);
                }

                if (this.dtSource != null && this.dtSource.Rows.Count > 0)
                {
                    iPower.Web.TreeView.TreeView treeView = null;
                    switch (this.MenuType)
                    {
                        case EnumMenuType.Outlook:
                             treeView = this.tvMenuOutlook;
                            break;
                        case EnumMenuType.TreeView:
                             treeView = this.tvMenuTree;
                            break;
                    }
                    if (treeView != null)
                    {
                        treeView.DataSource = this.dtSource.Copy();
                        treeView.IDField = "ModuleID";
                        treeView.PIDField = "ParentModuleID";
                        treeView.TitleField = "ModuleName";
                        treeView.HrefField = "ModuleUri";
                        treeView.OrderNoField = "OrderNo";

                        string currentFolderID = this.CurrentFolderID;
                        if (string.IsNullOrEmpty(currentFolderID))
                            currentFolderID = this.SecurityID;

                        treeView.Visible = true;
                        treeView.CurrentFolderValue = currentFolderID;
                        treeView.BuildTree();

                        iPower.Web.TreeView.TreeViewNode node = treeView.Items[currentFolderID];
                        if (node != null)
                        {
                            bool flag = false;
                            iPower.Web.TreeView.TreeViewNode p = node.Parent;
                            while (p != null)
                            {
                                p.Expand = flag = true;
                                p = p.Parent;
                            }
                            if (flag)
                                treeView.DataBind();
                        }
                    }
                }
            });
        }
        #endregion

        #region 辅助函数。
        void BuilderModuleDefineDataSource(ref DataTable dt, ModuleDefineCollection collection)
        {
            if (collection != null)
            {
                DataRow dr = null;
                foreach (ModuleDefine d in collection)
                {
                    if (dt.Rows.Find(d.ModuleID) == null)
                    {
                        dr = dt.NewRow();
                        dr["ModuleID"] = d.ModuleID;
                        dr["ParentModuleID"] = (d.Parent == null) ? string.Empty : d.Parent.ModuleID;
                        dr["ModuleName"] = d.ModuleName;
                        dr["ModuleUri"] = d.ModuleUri;
                        dr["OrderNo"] = d.OrderNo;
                        dt.Rows.Add(dr);
                    }
                    if (d.Modules != null && d.Modules.Count > 0)
                    {
                        this.BuilderModuleDefineDataSource(ref dt, d.Modules);
                    }
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// 菜单类型枚举。
    /// </summary>
    public enum EnumMenuType
    {
        /// <summary>
        /// Outlook风格。
        /// </summary>
        Outlook = 0,
        /// <summary>
        /// 树形风格。
        /// </summary>
        TreeView = 1
    }
}