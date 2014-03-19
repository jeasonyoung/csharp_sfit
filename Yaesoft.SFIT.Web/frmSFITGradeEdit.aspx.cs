//================================================================================
// FileName: frmSFITGradeEdit.aspx.cs
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
	///frmSFITGradeEdit�б�ҳ���̨���롣
	///</summary>
    public partial class frmSFITGradeEdit : ModuleBasePage, ISFITGradeEditView
    {
        #region ��Ա���������캯����
        SFITGradePresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITGradeEdit()
        {
            this.presenter = new SFITGradePresenter(this);
        }
        #endregion

        #region �¼�����
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
                SFITGrade data = new SFITGrade();
                data.GradeID = this.GradeID.IsValid ? this.GradeID : GUIDEx.New;
                data.GradeCode = this.txtGradeCode.Text.Trim();
                data.GradeName = this.txtGradeName.Text.Trim();
                data.OrderNO = int.Parse(this.txtOrderNO.Text);
                data.GradeValue = int.Parse(this.txtGradeValue.Text);
                data.LearnLevel = int.Parse(this.ddlLearnLevel.SelectedValue);

                if (this.presenter.UpdateSFITGrade(data))
                    this.SaveData();
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
        #endregion

        #region ���ء�
        public override void LoadData()
        {
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITGrade>>(delegate(object sender, EntityEventArgs<SFITGrade> e)
            {
                if (e.Entity != null)
                {
                    this.txtGradeCode.Text = e.Entity.GradeCode;
                    this.txtGradeName.Text = e.Entity.GradeName;
                    this.txtOrderNO.Text = e.Entity.OrderNO.ToString();
                    this.txtGradeValue.Text = e.Entity.GradeValue.ToString();
                    this.ddlLearnLevel.SelectedValue = e.Entity.LearnLevel.ToString();
                }
            }));
        }

        public override bool DeleteData()
        {
            return false;
        }
        #endregion

        #region ISFITGradeEditView ��Ա

        public GUIDEx GradeID
        {
            get { return this.RequestGUIEx("GradeID"); }
        }
        #endregion

        #region ISFITGradeView ��Ա
 
        public void BindLearnLevel(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlLearnLevel, data);
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }

}
