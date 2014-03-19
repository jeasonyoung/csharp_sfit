//================================================================================
// FileName: frmSFITeaReviewStudentEdit.aspx.cs
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
using iPower.Platform.Engine.DataSource;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    ///<summary>
    ///frmSFITeaReviewStudentEdit�б�ҳ���̨���롣
    ///</summary>
    public partial class frmSFITeaReviewStudentEdit : ModuleBasePage, ISFITeaReviewStudentEidtView
    {
        #region ��Ա���������캯����
        SFITeaReviewStudentPresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmSFITeaReviewStudentEdit()
        {
            this.presenter = new SFITeaReviewStudentPresenter(this);

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
                SFITeaReviewStudent data = new SFITeaReviewStudent();
                data.WorkID = this.WorkID;
                data.TeacherID = this.CurrentUserID;
                data.EvaluateType = int.Parse(this.ddlEvaluateType.SelectedValue);
                data.ReviewValue = this.txtReviewValue.Text;
                data.SubjectiveReviews = this.txtSubjectiveReviews.Text;
                //data.SyncStatus = int.Parse(this.ddlSyncStatus.SelectedValue);
                //data.LastSyncTime = DateTime.Now;
                data.CreateEmployeeID = this.CurrentUserID;
                data.CreateEmployeeName = this.CurrentUserName;
                if (this.presenter.UpdateTeaReviewStudent(data))
                {
                    this.SaveData();
                }

            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
        }

        protected void dgfrmSFITeaReviewStudentEdit_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSFITeaReviewStudentEdit.DataSource = this.presenter.ListDataSource;
        }

        #endregion

        #region ���ء�
        public override void LoadData()
        {
            this.txtStudentWorks.Enabled = false;
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITeaReviewStudent>>(delegate(object sender, EntityEventArgs<SFITeaReviewStudent> e)
            {
                if (e.Entity != null)
                {
                    this.txtStudentWorks.Text = e.Entity.WorkName;
                    this.ddlEvaluateType.SelectedValue = e.Entity.EvaluateType.ToString();
                    this.txtReviewValue.Text = e.Entity.ReviewValue;
                    this.txtSubjectiveReviews.Text = e.Entity.SubjectiveReviews;
                    //this.ddlSyncStatus.SelectedValue = e.Entity.SyncStatus.ToString();
                    //this.DateLastSyncTime.Text = string.Format("{0:d}", e.Entity.LastSyncTime);

                }
            }
                ));

        }

        public override bool DeleteData()
        {
            return false;

        }
        #endregion

        #region ISFITeaReviewStudentEidtView ��Ա

        public GUIDEx WorkID
        {
            get { return RequestGUIEx("WorkID"); }
        }
        /// <summary>
        /// ������Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        /// <summary>
        /// �������͡�
        /// </summary>
        /// <param name="data"></param>
        public void BindEvaluateType(IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlEvaluateType, data);
        }
        /// <summary>
        /// ͬ��״̬��
        /// </summary>
        /// <param name="data"></param>
        public void BingSyncStatus(IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlSyncStatus, data);
        }

        #endregion

    }

}
