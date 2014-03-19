//================================================================================
// FileName: frmSFITEvaluateSetEdit.aspx.cs
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
    ///frmSFITEvaluateSetEdit列表页面后台代码。
    ///</summary>
    public partial class frmSFITEvaluateSetEdit : ModuleBasePage, ISFITEvaluateSetEditView
    {
        #region 成员变量，构造函数。
        SFITEvaluateSetPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmSFITEvaluateSetEdit()
        {
            this.presenter = new SFITEvaluateSetPresenter(this);
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
                SFITEvaluateSet data = new SFITEvaluateSet();
                data.GradeID = this.ddlGrade.SelectedValue;
                data.EvaluateID = this.ddlEvaluate.SelectedValue;
                data.ModifyTime = DateTime.Now;

                if (this.presenter.UpdateEntityData(data))
                    this.SaveData();
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITEvaluateSet>>(delegate(object sender, EntityEventArgs<SFITEvaluateSet> e)
            {
                if (e.Entity != null)
                {
                    this.ddlGrade.SelectedValue = e.Entity.GradeID;
                    this.ddlEvaluate.SelectedValue = e.Entity.EvaluateID;
                    this.ddlGrade.Enabled = this.ddlEvaluate.Enabled = false;
                }
            }));
        }

        public override bool DeleteData()
        {
            return false;
        }
        #endregion


        #region ISFITEvaluateSetView 成员

        public void BindGrades(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGrade, data);
        }

        public void BindEvaluates(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlEvaluate, data);
        }

        public GUIDEx EvaluateID
        {
            get { return this.RequestGUIEx("EvaluateID"); }
        }

        public GUIDEx GradeID
        {
            get { return this.RequestGUIEx("GradeID"); }
        }
 
        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }
}
