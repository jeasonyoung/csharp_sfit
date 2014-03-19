namespace Yaesoft.SFIT.ClientStudent
{
    partial class WorkUploadWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkUploadWindow));
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopWork = new System.Windows.Forms.Panel();
            this.panelTopRight = new System.Windows.Forms.Panel();
            this.panelWork = new System.Windows.Forms.Panel();
            this.groupBoxWork = new System.Windows.Forms.GroupBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtUploadFiles = new System.Windows.Forms.TextBox();
            this.lbUploadFiles = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.chkPublic = new System.Windows.Forms.CheckBox();
            this.lbWorkType = new System.Windows.Forms.Label();
            this.txtCatalogName = new System.Windows.Forms.TextBox();
            this.lbCatalog = new System.Windows.Forms.Label();
            this.txtWorkName = new System.Windows.Forms.TextBox();
            this.lbWorkName = new System.Windows.Forms.Label();
            this.panelWorkBottom = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.panelWorkTop = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelTopRight.SuspendLayout();
            this.panelWork.SuspendLayout();
            this.groupBoxWork.SuspendLayout();
            this.panelWorkBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Yaesoft.SFIT.ClientStudent.Properties.Resources.btnClose;
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.panelTopWork);
            this.panelTop.Controls.Add(this.panelTopRight);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(365, 26);
            this.panelTop.TabIndex = 1;
            // 
            // panelTopWork
            // 
            this.panelTopWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopWork.Location = new System.Drawing.Point(0, 0);
            this.panelTopWork.Name = "panelTopWork";
            this.panelTopWork.Size = new System.Drawing.Size(293, 26);
            this.panelTopWork.TabIndex = 1;
            // 
            // panelTopRight
            // 
            this.panelTopRight.Controls.Add(this.btnClose);
            this.panelTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTopRight.Location = new System.Drawing.Point(293, 0);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(72, 26);
            this.panelTopRight.TabIndex = 0;
            // 
            // panelWork
            // 
            this.panelWork.BackColor = System.Drawing.Color.Transparent;
            this.panelWork.Controls.Add(this.groupBoxWork);
            this.panelWork.Controls.Add(this.panelWorkBottom);
            this.panelWork.Controls.Add(this.panelWorkTop);
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(0, 26);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(365, 298);
            this.panelWork.TabIndex = 2;
            // 
            // groupBoxWork
            // 
            this.groupBoxWork.Controls.Add(this.btnUpload);
            this.groupBoxWork.Controls.Add(this.txtUploadFiles);
            this.groupBoxWork.Controls.Add(this.lbUploadFiles);
            this.groupBoxWork.Controls.Add(this.txtDescription);
            this.groupBoxWork.Controls.Add(this.lbDescription);
            this.groupBoxWork.Controls.Add(this.chkPublic);
            this.groupBoxWork.Controls.Add(this.lbWorkType);
            this.groupBoxWork.Controls.Add(this.txtCatalogName);
            this.groupBoxWork.Controls.Add(this.lbCatalog);
            this.groupBoxWork.Controls.Add(this.txtWorkName);
            this.groupBoxWork.Controls.Add(this.lbWorkName);
            this.groupBoxWork.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxWork.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxWork.Location = new System.Drawing.Point(8, 37);
            this.groupBoxWork.Name = "groupBoxWork";
            this.groupBoxWork.Size = new System.Drawing.Size(337, 224);
            this.groupBoxWork.TabIndex = 2;
            this.groupBoxWork.TabStop = false;
            this.groupBoxWork.Text = "作品信息";
            // 
            // btnUpload
            // 
            this.btnUpload.BackgroundImage = global::Yaesoft.SFIT.ClientStudent.Properties.Resources.ButtonOK;
            this.btnUpload.ForeColor = System.Drawing.Color.Navy;
            this.btnUpload.Location = new System.Drawing.Point(150, 192);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(72, 27);
            this.btnUpload.TabIndex = 10;
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtUploadFiles
            // 
            this.txtUploadFiles.Location = new System.Drawing.Point(66, 130);
            this.txtUploadFiles.Multiline = true;
            this.txtUploadFiles.Name = "txtUploadFiles";
            this.txtUploadFiles.ReadOnly = true;
            this.txtUploadFiles.Size = new System.Drawing.Size(265, 59);
            this.txtUploadFiles.TabIndex = 9;
            // 
            // lbUploadFiles
            // 
            this.lbUploadFiles.AutoSize = true;
            this.lbUploadFiles.ForeColor = System.Drawing.Color.Navy;
            this.lbUploadFiles.Location = new System.Drawing.Point(0, 134);
            this.lbUploadFiles.Name = "lbUploadFiles";
            this.lbUploadFiles.Size = new System.Drawing.Size(68, 17);
            this.lbUploadFiles.TabIndex = 8;
            this.lbUploadFiles.Text = "上传附件：";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(65, 88);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(266, 37);
            this.txtDescription.TabIndex = 7;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.ForeColor = System.Drawing.Color.Navy;
            this.lbDescription.Location = new System.Drawing.Point(0, 91);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(68, 17);
            this.lbDescription.TabIndex = 6;
            this.lbDescription.Text = "作品描述：";
            // 
            // chkPublic
            // 
            this.chkPublic.AutoSize = true;
            this.chkPublic.Checked = true;
            this.chkPublic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPublic.ForeColor = System.Drawing.Color.Navy;
            this.chkPublic.Location = new System.Drawing.Point(65, 68);
            this.chkPublic.Name = "chkPublic";
            this.chkPublic.Size = new System.Drawing.Size(75, 21);
            this.chkPublic.TabIndex = 5;
            this.chkPublic.Text = "公开作品";
            this.chkPublic.UseVisualStyleBackColor = true;
            // 
            // lbWorkType
            // 
            this.lbWorkType.AutoSize = true;
            this.lbWorkType.ForeColor = System.Drawing.Color.Navy;
            this.lbWorkType.Location = new System.Drawing.Point(-1, 67);
            this.lbWorkType.Name = "lbWorkType";
            this.lbWorkType.Size = new System.Drawing.Size(68, 17);
            this.lbWorkType.TabIndex = 4;
            this.lbWorkType.Text = "作品类型：";
            // 
            // txtCatalogName
            // 
            this.txtCatalogName.Location = new System.Drawing.Point(65, 42);
            this.txtCatalogName.Name = "txtCatalogName";
            this.txtCatalogName.ReadOnly = true;
            this.txtCatalogName.Size = new System.Drawing.Size(266, 23);
            this.txtCatalogName.TabIndex = 3;
            // 
            // lbCatalog
            // 
            this.lbCatalog.AutoSize = true;
            this.lbCatalog.ForeColor = System.Drawing.Color.Navy;
            this.lbCatalog.Location = new System.Drawing.Point(-1, 44);
            this.lbCatalog.Name = "lbCatalog";
            this.lbCatalog.Size = new System.Drawing.Size(68, 17);
            this.lbCatalog.TabIndex = 2;
            this.lbCatalog.Text = "课程目录：";
            // 
            // txtWorkName
            // 
            this.txtWorkName.Location = new System.Drawing.Point(65, 15);
            this.txtWorkName.Name = "txtWorkName";
            this.txtWorkName.Size = new System.Drawing.Size(266, 23);
            this.txtWorkName.TabIndex = 1;
            // 
            // lbWorkName
            // 
            this.lbWorkName.AutoSize = true;
            this.lbWorkName.ForeColor = System.Drawing.Color.Navy;
            this.lbWorkName.Location = new System.Drawing.Point(0, 17);
            this.lbWorkName.Name = "lbWorkName";
            this.lbWorkName.Size = new System.Drawing.Size(68, 17);
            this.lbWorkName.TabIndex = 0;
            this.lbWorkName.Text = "作品名称：";
            // 
            // panelWorkBottom
            // 
            this.panelWorkBottom.Controls.Add(this.lbMessage);
            this.panelWorkBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelWorkBottom.Location = new System.Drawing.Point(0, 267);
            this.panelWorkBottom.Name = "panelWorkBottom";
            this.panelWorkBottom.Size = new System.Drawing.Size(365, 31);
            this.panelWorkBottom.TabIndex = 1;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.ForeColor = System.Drawing.Color.DimGray;
            this.lbMessage.Location = new System.Drawing.Point(18, 9);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(69, 17);
            this.lbMessage.TabIndex = 1;
            this.lbMessage.Text = "[Message]";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelWorkTop
            // 
            this.panelWorkTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWorkTop.Location = new System.Drawing.Point(0, 0);
            this.panelWorkTop.Name = "panelWorkTop";
            this.panelWorkTop.Size = new System.Drawing.Size(365, 40);
            this.panelWorkTop.TabIndex = 0;
            // 
            // WorkUploadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(365, 324);
            this.Controls.Add(this.panelWork);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WorkUploadWindow";
            this.Text = "上传作品信息";
            this.Title = "上传作品信息";
            this.Load += new System.EventHandler(this.WorkUploadWindow_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTopRight.ResumeLayout(false);
            this.panelWork.ResumeLayout(false);
            this.groupBoxWork.ResumeLayout(false);
            this.groupBoxWork.PerformLayout();
            this.panelWorkBottom.ResumeLayout(false);
            this.panelWorkBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelTopWork;
        private System.Windows.Forms.Panel panelTopRight;
        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.Panel panelWorkBottom;
        private System.Windows.Forms.Panel panelWorkTop;
        private System.Windows.Forms.GroupBox groupBoxWork;
        private System.Windows.Forms.Label lbWorkName;
        private System.Windows.Forms.TextBox txtWorkName;
        private System.Windows.Forms.TextBox txtCatalogName;
        private System.Windows.Forms.Label lbCatalog;
        private System.Windows.Forms.Label lbWorkType;
        private System.Windows.Forms.CheckBox chkPublic;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbUploadFiles;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtUploadFiles;
        private System.Windows.Forms.Label lbMessage;
    }
}