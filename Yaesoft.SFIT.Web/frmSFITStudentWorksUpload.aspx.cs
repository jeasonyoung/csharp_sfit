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
    }
}