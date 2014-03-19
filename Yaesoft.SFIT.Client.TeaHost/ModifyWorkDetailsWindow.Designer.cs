namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class ModifyWorkDetailsWindow
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
            this.panelWork = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.linkDownloadWork = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.chkPublish = new System.Windows.Forms.CheckBox();
            this.chkUpload = new System.Windows.Forms.CheckBox();
            this.txtSubjectiveReviews = new System.Windows.Forms.TextBox();
            this.lbSubjectiveReviews = new System.Windows.Forms.Label();
            this.cbbReviewValue = new System.Windows.Forms.ComboBox();
            this.lbReviewValue = new System.Windows.Forms.Label();
            this.chkPublic = new System.Windows.Forms.CheckBox();
            this.lbWorkType = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.txtUploadIP = new System.Windows.Forms.TextBox();
            this.lbUploadIP = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.lbStudentName = new System.Windows.Forms.Label();
            this.txtWorkstatusName = new System.Windows.Forms.TextBox();
            this.lbWorkStatus = new System.Windows.Forms.Label();
            this.txtWorkName = new System.Windows.Forms.TextBox();
            this.lbWorkName = new System.Windows.Forms.Label();
            this.panelWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelControls.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWork
            // 
            this.panelWork.AutoSize = true;
            this.panelWork.Controls.Add(this.pictureBox);
            this.panelWork.Controls.Add(this.panelControls);
            this.panelWork.Controls.Add(this.chkPublic);
            this.panelWork.Controls.Add(this.lbWorkType);
            this.panelWork.Controls.Add(this.txtDescription);
            this.panelWork.Controls.Add(this.lbDescription);
            this.panelWork.Controls.Add(this.txtTime);
            this.panelWork.Controls.Add(this.lbTime);
            this.panelWork.Controls.Add(this.txtUploadIP);
            this.panelWork.Controls.Add(this.lbUploadIP);
            this.panelWork.Controls.Add(this.txtStudentName);
            this.panelWork.Controls.Add(this.lbStudentName);
            this.panelWork.Controls.Add(this.txtWorkstatusName);
            this.panelWork.Controls.Add(this.lbWorkStatus);
            this.panelWork.Controls.Add(this.txtWorkName);
            this.panelWork.Controls.Add(this.lbWorkName);
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(0, 0);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(556, 380);
            this.panelWork.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.Location = new System.Drawing.Point(347, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(200, 150);
            this.pictureBox.TabIndex = 27;
            this.pictureBox.TabStop = false;
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.btnNext);
            this.panelControls.Controls.Add(this.btnPrev);
            this.panelControls.Controls.Add(this.btnDelete);
            this.panelControls.Controls.Add(this.panelBottom);
            this.panelControls.Controls.Add(this.linkDownloadWork);
            this.panelControls.Controls.Add(this.btnClose);
            this.panelControls.Controls.Add(this.btnSave);
            this.panelControls.Controls.Add(this.groupBox);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(0, 220);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(556, 160);
            this.panelControls.TabIndex = 26;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(347, 98);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "下一个(&→)";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(16, 98);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 18;
            this.btnPrev.Text = "上一个(&←)";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(179, 98);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.BottomBackground;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 130);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(556, 30);
            this.panelBottom.TabIndex = 31;
            // 
            // linkDownloadWork
            // 
            this.linkDownloadWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkDownloadWork.AutoSize = true;
            this.linkDownloadWork.Location = new System.Drawing.Point(441, 103);
            this.linkDownloadWork.Name = "linkDownloadWork";
            this.linkDownloadWork.Size = new System.Drawing.Size(107, 12);
            this.linkDownloadWork.TabIndex = 11;
            this.linkDownloadWork.TabStop = true;
            this.linkDownloadWork.Text = "查看作品文件({0})";
            this.linkDownloadWork.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDownloadWork_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(97, 98);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(264, 98);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.chkPublish);
            this.groupBox.Controls.Add(this.chkUpload);
            this.groupBox.Controls.Add(this.txtSubjectiveReviews);
            this.groupBox.Controls.Add(this.lbSubjectiveReviews);
            this.groupBox.Controls.Add(this.cbbReviewValue);
            this.groupBox.Controls.Add(this.lbReviewValue);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(556, 90);
            this.groupBox.TabIndex = 26;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "作品评阅";
            // 
            // chkPublish
            // 
            this.chkPublish.AutoSize = true;
            this.chkPublish.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPublish.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPublish.Location = new System.Drawing.Point(444, 14);
            this.chkPublish.Name = "chkPublish";
            this.chkPublish.Size = new System.Drawing.Size(87, 21);
            this.chkPublish.TabIndex = 13;
            this.chkPublish.Text = "发布到网站";
            this.chkPublish.UseVisualStyleBackColor = true;
            // 
            // chkUpload
            // 
            this.chkUpload.AutoSize = true;
            this.chkUpload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkUpload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUpload.Location = new System.Drawing.Point(353, 13);
            this.chkUpload.Name = "chkUpload";
            this.chkUpload.Size = new System.Drawing.Size(87, 21);
            this.chkUpload.TabIndex = 12;
            this.chkUpload.Text = "上传到网站";
            this.chkUpload.UseVisualStyleBackColor = true;
            // 
            // txtSubjectiveReviews
            // 
            this.txtSubjectiveReviews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubjectiveReviews.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSubjectiveReviews.Location = new System.Drawing.Point(73, 41);
            this.txtSubjectiveReviews.Multiline = true;
            this.txtSubjectiveReviews.Name = "txtSubjectiveReviews";
            this.txtSubjectiveReviews.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSubjectiveReviews.Size = new System.Drawing.Size(471, 39);
            this.txtSubjectiveReviews.TabIndex = 10;
            // 
            // lbSubjectiveReviews
            // 
            this.lbSubjectiveReviews.AutoSize = true;
            this.lbSubjectiveReviews.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSubjectiveReviews.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbSubjectiveReviews.Location = new System.Drawing.Point(8, 42);
            this.lbSubjectiveReviews.Name = "lbSubjectiveReviews";
            this.lbSubjectiveReviews.Size = new System.Drawing.Size(68, 17);
            this.lbSubjectiveReviews.TabIndex = 23;
            this.lbSubjectiveReviews.Text = "主观评价：";
            // 
            // cbbReviewValue
            // 
            this.cbbReviewValue.FormattingEnabled = true;
            this.cbbReviewValue.Location = new System.Drawing.Point(73, 14);
            this.cbbReviewValue.Name = "cbbReviewValue";
            this.cbbReviewValue.Size = new System.Drawing.Size(121, 25);
            this.cbbReviewValue.TabIndex = 9;
            // 
            // lbReviewValue
            // 
            this.lbReviewValue.AutoSize = true;
            this.lbReviewValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbReviewValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbReviewValue.Location = new System.Drawing.Point(8, 19);
            this.lbReviewValue.Name = "lbReviewValue";
            this.lbReviewValue.Size = new System.Drawing.Size(68, 17);
            this.lbReviewValue.TabIndex = 21;
            this.lbReviewValue.Text = "客观评阅：";
            // 
            // chkPublic
            // 
            this.chkPublic.AutoSize = true;
            this.chkPublic.Location = new System.Drawing.Point(293, 80);
            this.chkPublic.Name = "chkPublic";
            this.chkPublic.Size = new System.Drawing.Size(48, 16);
            this.chkPublic.TabIndex = 5;
            this.chkPublic.Text = "公开";
            this.chkPublic.UseVisualStyleBackColor = true;
            // 
            // lbWorkType
            // 
            this.lbWorkType.AutoSize = true;
            this.lbWorkType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWorkType.Location = new System.Drawing.Point(226, 79);
            this.lbWorkType.Name = "lbWorkType";
            this.lbWorkType.Size = new System.Drawing.Size(68, 17);
            this.lbWorkType.TabIndex = 22;
            this.lbWorkType.Text = "作品类型：";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDescription.Location = new System.Drawing.Point(73, 162);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(471, 58);
            this.txtDescription.TabIndex = 8;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDescription.Location = new System.Drawing.Point(8, 177);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(68, 17);
            this.lbDescription.TabIndex = 20;
            this.lbDescription.Text = "作品描述：";
            // 
            // txtTime
            // 
            this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTime.Location = new System.Drawing.Point(73, 104);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(268, 23);
            this.txtTime.TabIndex = 6;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.Location = new System.Drawing.Point(8, 107);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(68, 17);
            this.lbTime.TabIndex = 18;
            this.lbTime.Text = "上传时间：";
            // 
            // txtUploadIP
            // 
            this.txtUploadIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUploadIP.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUploadIP.Location = new System.Drawing.Point(73, 77);
            this.txtUploadIP.Name = "txtUploadIP";
            this.txtUploadIP.ReadOnly = true;
            this.txtUploadIP.Size = new System.Drawing.Size(147, 23);
            this.txtUploadIP.TabIndex = 4;
            // 
            // lbUploadIP
            // 
            this.lbUploadIP.AutoSize = true;
            this.lbUploadIP.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUploadIP.Location = new System.Drawing.Point(8, 80);
            this.lbUploadIP.Name = "lbUploadIP";
            this.lbUploadIP.Size = new System.Drawing.Size(68, 17);
            this.lbUploadIP.TabIndex = 16;
            this.lbUploadIP.Text = "上传地址：";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudentName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStudentName.Location = new System.Drawing.Point(73, 26);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(268, 23);
            this.txtStudentName.TabIndex = 2;
            // 
            // lbStudentName
            // 
            this.lbStudentName.AutoSize = true;
            this.lbStudentName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStudentName.Location = new System.Drawing.Point(8, 29);
            this.lbStudentName.Name = "lbStudentName";
            this.lbStudentName.Size = new System.Drawing.Size(68, 17);
            this.lbStudentName.TabIndex = 14;
            this.lbStudentName.Text = "学生名称：";
            // 
            // txtWorkstatusName
            // 
            this.txtWorkstatusName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkstatusName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWorkstatusName.Location = new System.Drawing.Point(73, 51);
            this.txtWorkstatusName.Name = "txtWorkstatusName";
            this.txtWorkstatusName.ReadOnly = true;
            this.txtWorkstatusName.Size = new System.Drawing.Size(268, 23);
            this.txtWorkstatusName.TabIndex = 3;
            // 
            // lbWorkStatus
            // 
            this.lbWorkStatus.AutoSize = true;
            this.lbWorkStatus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWorkStatus.Location = new System.Drawing.Point(8, 53);
            this.lbWorkStatus.Name = "lbWorkStatus";
            this.lbWorkStatus.Size = new System.Drawing.Size(68, 17);
            this.lbWorkStatus.TabIndex = 8;
            this.lbWorkStatus.Text = "作品状态：";
            // 
            // txtWorkName
            // 
            this.txtWorkName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWorkName.Location = new System.Drawing.Point(73, 2);
            this.txtWorkName.Name = "txtWorkName";
            this.txtWorkName.Size = new System.Drawing.Size(268, 23);
            this.txtWorkName.TabIndex = 1;
            // 
            // lbWorkName
            // 
            this.lbWorkName.AutoSize = true;
            this.lbWorkName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWorkName.Location = new System.Drawing.Point(8, 6);
            this.lbWorkName.Name = "lbWorkName";
            this.lbWorkName.Size = new System.Drawing.Size(68, 17);
            this.lbWorkName.TabIndex = 0;
            this.lbWorkName.Text = "作品名称：";
            // 
            // ModifyWorkDetailsWindow
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(556, 380);
            this.Controls.Add(this.panelWork);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ModifyWorkDetailsWindow";
            this.Text = "作品明细：";
            this.Title = "作品明细：";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ModifyWorkDetailsWindow_KeyDown);
            this.Load += new System.EventHandler(this.ModifyWorkDetailsWindow_Load);
            this.panelWork.ResumeLayout(false);
            this.panelWork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.Label lbWorkName;
        private System.Windows.Forms.TextBox txtWorkName;
        private System.Windows.Forms.TextBox txtWorkstatusName;
        private System.Windows.Forms.Label lbWorkStatus;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label lbStudentName;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TextBox txtUploadIP;
        private System.Windows.Forms.Label lbUploadIP;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbWorkType;
        private System.Windows.Forms.CheckBox chkPublic;
        private System.Windows.Forms.LinkLabel linkDownloadWork;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox chkPublish;
        private System.Windows.Forms.CheckBox chkUpload;
        private System.Windows.Forms.TextBox txtSubjectiveReviews;
        private System.Windows.Forms.Label lbSubjectiveReviews;
        private System.Windows.Forms.ComboBox cbbReviewValue;
        private System.Windows.Forms.Label lbReviewValue;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
    }
}