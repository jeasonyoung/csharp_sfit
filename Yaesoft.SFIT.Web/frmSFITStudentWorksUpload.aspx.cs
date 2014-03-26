using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Yaesoft.SFIT.Engine.Service;

namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmSFITStudentWorksUpload : ModuleBasePage, ISFITStudentWorksUploadView
    {
        #region 成员变量，构造函数。
        private SFITStudentWorksQueryPresenter presenter;
        /// <summary>
        /// 
        /// </summary>
        public frmSFITStudentWorksUpload()
        {
            this.presenter = new SFITStudentWorksQueryPresenter(this);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                StudentWorkTeaUpload stuworkUpload = new StudentWorkTeaUpload();
                stuworkUpload.CatalogID = this.ddlCatalog.SelectedValue;
                stuworkUpload.Description = this.txtWorkDescription.Text.Trim();
                stuworkUpload.WorkName = this.txtWorkName.Text.Trim();
                stuworkUpload.Type = (EnumWorkType)Enum.Parse(typeof(EnumWorkType), this.ddlWorkType.SelectedValue);
                stuworkUpload.Status = EnumWorkStatus.Submit;
                bool isUploadWork = false;
                this.uploadAttachments.SaveUploadAs(new EventHandler<iPower.Web.Upload.UploadViewEventArgs>(delegate(object o, iPower.Web.Upload.UploadViewEventArgs s)
                {
                    try
                    {
                        isUploadWork = true;
                        StudentWorkFile workfile = new StudentWorkFile();
                        stuworkUpload.WorkID = workfile.FileID = s.ItemRaw.FileID;
                        workfile.FileName = s.ItemRaw.FileName;
                        workfile.FileExt = s.ItemRaw.Extension;
                        workfile.OffSet = 0;
                        workfile.Size = s.ItemRaw.Size;
                        workfile.ContentType = s.ItemRaw.ContentType;
                        workfile.Data = s.ItemRaw.FileRaw;

                        stuworkUpload.CheckCode = s.ItemRaw.CheckCode;
                        stuworkUpload.Files = workfile;
                        if (this.presenter.UploadStudentWork(this.CurrentUserID, stuworkUpload))
                        {
                            this.SaveData();
                        }
                        else
                        {
                            this.ShowMessage("上传失败！发生未知异常。");
                        }
                    }
                    catch (Exception e1)
                    {
                        this.ShowMessage("发生异常：" + e1.Message);
                    }
                }));
                if (!isUploadWork)this.ShowMessage("请上传学生作业文件！");
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void uploadAttachments_OnUploadViewExceptionEvent(Exception e)
        {
            this.ShowMessage(e.Message); 
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override bool ViewStateInServer
        {
            get
            {
                return this.CurrentUserID.IsValid;
            }
        }
        #endregion

        #region ISFITStudentWorksQueryView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            this.errMessage.Message = message;
        }

        #endregion

        #region ISFITStudentWorksUploadView 成员
        /// <summary>
        /// 
        /// </summary>
        public string SchoolName
        {
            set { this.txtSchoolName.Text = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassName
        {
            set { this.txtClassName.Text = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StudentName
        {
            set { this.txtStudentName.Text = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindCatalogs(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlCatalog, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindWorkType(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlWorkType, data);
        }

        #endregion
    }
}