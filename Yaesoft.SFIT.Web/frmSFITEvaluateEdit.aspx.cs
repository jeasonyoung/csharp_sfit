//================================================================================
// FileName: frmSFITEvaluateEdit.aspx.cs
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
using iPower.Web.UI;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Service;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Web
{
	///<summary>
	///frmSFITEvaluateEdit列表页面后台代码。
	///</summary>
    public partial class frmSFITEvaluateEdit : ModuleBasePage, ISFITEvaluateEditView
    {
        #region 成员变量，构造函数。
        SFITEvaluatePresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITEvaluateEdit()
        {
            this.presenter = new SFITEvaluatePresenter(this);
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

        protected void ddlEvaluateType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownListEx dropDown = sender as DropDownListEx;
                if (dropDown != null && !string.IsNullOrEmpty(dropDown.SelectedValue))
                {
                    EnumEvaluateType evaluateType = (EnumEvaluateType)Enum.Parse(typeof(EnumEvaluateType), dropDown.SelectedValue);
                    if (evaluateType == EnumEvaluateType.Hierarchy)
                    {
                        this.panelEvaluate.Visible = false;
                        this.tabEvaluateItems.Visible = true;
                    }
                    else
                    {
                        this.panelEvaluate.Visible = true;
                        this.tabEvaluateItems.Visible = false;
                    }
                }
                else
                    this.panelEvaluate.Visible = this.tabEvaluateItems.Visible = false;
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
        protected void dgfrmSFITEvaluateEdit_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITEvaluateEdit.DataSource = this.EditDataSource;
        }

        protected void dgfrmSFITEvaluateEdit_OnRowSelecting(object sender, EventArgs e)
        {
            EvaluateItem data = sender as EvaluateItem;
            if (data != null)
            {
                this.ItemID = data.ItemID;
                this.txtItemName.Text = data.ItemName;
                this.txtItemValue.Text = data.ItemValue;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EvaluateItem item = new EvaluateItem();
                item.ItemID = this.ItemID.IsValid ? this.ItemID : GUIDEx.New;
                item.ItemName = this.txtItemName.Text;
                item.ItemValue = this.txtItemValue.Text;

                if (string.IsNullOrEmpty(item.ItemName))
                    throw new Exception(this.txtItemName.RequiredErrorMessage);
                else if (string.IsNullOrEmpty(item.ItemValue))
                    throw new Exception(this.txtItemValue.RequiredErrorMessage);

                EvaluateItems dataSource = this.EditDataSource;
                if (dataSource == null)
                    dataSource = new EvaluateItems();
                if (dataSource.Contains(item) || dataSource[item.ItemName] != null)
                    throw new Exception("该等级已存在！");
                else
                {
                    dataSource.Add(item);
                    this.EditDataSource = dataSource;
                    this.ItemID = GUIDEx.Null;
                    this.txtItemName.Text = this.txtItemValue.Text = string.Empty;
                    this.dgfrmSFITEvaluateEdit.InvokeBuildDataSource();
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ItemID.IsValid)
                {
                    EvaluateItems dataSource = this.EditDataSource;
                    if (dataSource != null && dataSource.Count > 0)
                    {
                        EvaluateItem item = dataSource[this.ItemID];
                        if (item != null)
                        {
                            if (dataSource.Remove(item))
                            {
                                this.EditDataSource = dataSource;
                                this.dgfrmSFITEvaluateEdit.InvokeBuildDataSource();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SFITEvaluate data = new SFITEvaluate();
                data.EvaluateID = this.EvaluateID.IsValid ? this.EvaluateID : GUIDEx.New;
                data.EvaluateName = this.txtEvaluateName.Text;
                data.EvaluateType = int.Parse(this.ddlEvaluateType.SelectedValue);
                data.OrderNO = int.Parse(this.txtOrderNO.Text);
                data.MinValue = this.panelEvaluate.Visible ? int.Parse(this.txtMinValue.Text) : 0;
                data.MaxValue = this.panelEvaluate.Visible ? int.Parse(this.txtMaxValue.Text) : 0;
                //data.SyncStatus = (int)EnumSyncStatus.Sync;
                if (this.presenter.UpdateEntityData(data, this.EditDataSource))
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITEvaluate>>(delegate(object sender, EntityEventArgs<SFITEvaluate> e)
            {
                if (e.Entity != null)
                {
                    this.txtEvaluateName.Text = e.Entity.EvaluateName;
                    this.ddlEvaluateType.SelectedValue = e.Entity.EvaluateType.ToString();
                    this.ddlEvaluateType.Enabled = false;
                    this.txtOrderNO.Text = e.Entity.OrderNO.ToString();

                    this.txtMaxValue.Text = e.Entity.MaxValue.ToString();
                    this.txtMinValue.Text = e.Entity.MinValue.ToString();

                    EnumEvaluateType type = (EnumEvaluateType)Enum.Parse(typeof(EnumEvaluateType), e.Entity.EvaluateType.ToString());
                    if (type == EnumEvaluateType.Hierarchy)//等级制。
                    {
                        this.panelEvaluate.Visible = false;
                        this.tabEvaluateItems.Visible = true;
                        this.dgfrmSFITEvaluateEdit.InvokeBuildDataSource();
                    }
                    else
                    {//分数制。
                        this.panelEvaluate.Visible = true;
                        this.tabEvaluateItems.Visible = false;
                    }
                }
            }));
        }

        public override bool DeleteData()
        {
            return false;

        }
        #endregion

        #region ISFITEvaluateView 成员

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region ISFITEvaluateEditView 成员
        public GUIDEx ItemID
        {
            get
            {
                object obj = this.ViewState["ItemID"];
                return obj == null ? GUIDEx.Null : new GUIDEx(obj);
            }
            set
            {
                this.ViewState["ItemID"] = value;
            }
        }
        public GUIDEx EvaluateID
        {
            get { return this.RequestGUIEx("EvaluateID"); }
        }

        public void BindEvaluateType(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlEvaluateType, data);
        }

        public EvaluateItems EditDataSource
        {
            get
            {
                object obj = this.ViewState["EditDataSource"];
                return obj == null ? null : (EvaluateItems)obj;
            }
            set
            {
                this.ViewState["EditDataSource"] = value;
            }
        }

        #endregion
    }

}
