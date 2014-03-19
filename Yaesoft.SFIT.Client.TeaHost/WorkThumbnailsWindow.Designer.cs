namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class WorkThumbnailsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBottom = new Yaesoft.SFIT.Client.Controls.PanelEx();
            this.splitContainer = new Yaesoft.SFIT.Client.Controls.SplitContainerEx();
            this.panelWork = new System.Windows.Forms.Panel();
            this.groupBoxWork = new System.Windows.Forms.GroupBox();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.chkPublish = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkUpload = new System.Windows.Forms.CheckBox();
            this.chkSelectedAll = new System.Windows.Forms.CheckBox();
            this.txtSubjectiveReviews = new System.Windows.Forms.TextBox();
            this.lbSubjectiveReviews = new System.Windows.Forms.Label();
            this.cbbReviewValue = new System.Windows.Forms.ComboBox();
            this.lbReviewValue = new System.Windows.Forms.Label();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBoxWork.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.BottomBackground;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 551);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(844, 27);
            this.panelBottom.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelWork);
            this.splitContainer.Panel1MinSize = 0;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBoxWork);
            this.splitContainer.Panel2MinSize = 0;
            this.splitContainer.Size = new System.Drawing.Size(844, 551);
            this.splitContainer.SplitterDistance = 450;
            this.splitContainer.SplitterWidth = 9;
            this.splitContainer.TabIndex = 1;
            // 
            // panelWork
            // 
            this.panelWork.AutoScroll = true;
            this.panelWork.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.RightBackground;
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(0, 0);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(842, 448);
            this.panelWork.TabIndex = 0;
            this.panelWork.Resize += new System.EventHandler(this.panelWork_Resize);
            // 
            // groupBoxWork
            // 
            this.groupBoxWork.Controls.Add(this.groupBoxControl);
            this.groupBoxWork.Controls.Add(this.txtSubjectiveReviews);
            this.groupBoxWork.Controls.Add(this.lbSubjectiveReviews);
            this.groupBoxWork.Controls.Add(this.cbbReviewValue);
            this.groupBoxWork.Controls.Add(this.lbReviewValue);
            this.groupBoxWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxWork.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxWork.Location = new System.Drawing.Point(0, 0);
            this.groupBoxWork.Name = "groupBoxWork";
            this.groupBoxWork.Size = new System.Drawing.Size(842, 90);
            this.groupBoxWork.TabIndex = 0;
            this.groupBoxWork.TabStop = false;
            this.groupBoxWork.Text = "作品评阅";
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.chkPublish);
            this.groupBoxControl.Controls.Add(this.btnSave);
            this.groupBoxControl.Controls.Add(this.chkUpload);
            this.groupBoxControl.Controls.Add(this.chkSelectedAll);
            this.groupBoxControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxControl.Location = new System.Drawing.Point(664, 19);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(175, 68);
            this.groupBoxControl.TabIndex = 4;
            this.groupBoxControl.TabStop = false;
            // 
            // chkPublish
            // 
            this.chkPublish.AutoSize = true;
            this.chkPublish.Location = new System.Drawing.Point(10, 44);
            this.chkPublish.Name = "chkPublish";
            this.chkPublish.Size = new System.Drawing.Size(51, 21);
            this.chkPublish.TabIndex = 3;
            this.chkPublish.Text = "发布";
            this.chkPublish.UseVisualStyleBackColor = true;
            this.chkPublish.CheckedChanged += new System.EventHandler(this.chkPublish_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(75, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkUpload
            // 
            this.chkUpload.AutoSize = true;
            this.chkUpload.Location = new System.Drawing.Point(64, 16);
            this.chkUpload.Name = "chkUpload";
            this.chkUpload.Size = new System.Drawing.Size(99, 21);
            this.chkUpload.TabIndex = 1;
            this.chkUpload.Text = "上传至服务器";
            this.chkUpload.UseVisualStyleBackColor = true;
            // 
            // chkSelectedAll
            // 
            this.chkSelectedAll.AutoSize = true;
            this.chkSelectedAll.Location = new System.Drawing.Point(10, 16);
            this.chkSelectedAll.Name = "chkSelectedAll";
            this.chkSelectedAll.Size = new System.Drawing.Size(51, 21);
            this.chkSelectedAll.TabIndex = 0;
            this.chkSelectedAll.Text = "全选";
            this.chkSelectedAll.UseVisualStyleBackColor = true;
            this.chkSelectedAll.Click += new System.EventHandler(this.chkSelectedAll_Click);
            // 
            // txtSubjectiveReviews
            // 
            this.txtSubjectiveReviews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubjectiveReviews.Location = new System.Drawing.Point(75, 43);
            this.txtSubjectiveReviews.Multiline = true;
            this.txtSubjectiveReviews.Name = "txtSubjectiveReviews";
            this.txtSubjectiveReviews.Size = new System.Drawing.Size(545, 41);
            this.txtSubjectiveReviews.TabIndex = 3;
            // 
            // lbSubjectiveReviews
            // 
            this.lbSubjectiveReviews.AutoSize = true;
            this.lbSubjectiveReviews.Location = new System.Drawing.Point(12, 47);
            this.lbSubjectiveReviews.Name = "lbSubjectiveReviews";
            this.lbSubjectiveReviews.Size = new System.Drawing.Size(68, 17);
            this.lbSubjectiveReviews.TabIndex = 2;
            this.lbSubjectiveReviews.Text = "主观评价：";
            // 
            // cbbReviewValue
            // 
            this.cbbReviewValue.FormattingEnabled = true;
            this.cbbReviewValue.Location = new System.Drawing.Point(75, 17);
            this.cbbReviewValue.Name = "cbbReviewValue";
            this.cbbReviewValue.Size = new System.Drawing.Size(144, 25);
            this.cbbReviewValue.TabIndex = 1;
            // 
            // lbReviewValue
            // 
            this.lbReviewValue.AutoSize = true;
            this.lbReviewValue.Location = new System.Drawing.Point(12, 21);
            this.lbReviewValue.Name = "lbReviewValue";
            this.lbReviewValue.Size = new System.Drawing.Size(68, 17);
            this.lbReviewValue.TabIndex = 0;
            this.lbReviewValue.Text = "客观评阅：";
            // 
            // WorkThumbnailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 578);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelBottom);
            this.Name = "WorkThumbnailsWindow";
            this.Text = "学生作品缩略图";
            this.Title = "学生作品缩略图";
            this.Load += new System.EventHandler(this.WorkThumbnailsWindow_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.groupBoxWork.ResumeLayout(false);
            this.groupBoxWork.PerformLayout();
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Yaesoft.SFIT.Client.Controls.PanelEx panelBottom;
        private Yaesoft.SFIT.Client.Controls.SplitContainerEx splitContainer;
        private System.Windows.Forms.GroupBox groupBoxWork;
        private System.Windows.Forms.Label lbReviewValue;
        private System.Windows.Forms.ComboBox cbbReviewValue;
        private System.Windows.Forms.Label lbSubjectiveReviews;
        private System.Windows.Forms.TextBox txtSubjectiveReviews;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.CheckBox chkSelectedAll;
        private System.Windows.Forms.CheckBox chkUpload;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkPublish;
        private System.Windows.Forms.Panel panelWork;
    }
}