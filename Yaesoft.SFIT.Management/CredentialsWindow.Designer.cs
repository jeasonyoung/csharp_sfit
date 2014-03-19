namespace Yaesoft.SFIT.Management
{
    partial class CredentialsWindow
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.txtAccessPassword = new System.Windows.Forms.TextBox();
            this.lbAccessPassword = new System.Windows.Forms.Label();
            this.txtAccessAccount = new System.Windows.Forms.TextBox();
            this.lbAccessAccount = new System.Windows.Forms.Label();
            this.txtServiceURL = new System.Windows.Forms.TextBox();
            this.lbServiceURL = new System.Windows.Forms.Label();
            this.txtSchoolName = new System.Windows.Forms.TextBox();
            this.lbSchoolName = new System.Windows.Forms.Label();
            this.txtSchoolCode = new System.Windows.Forms.TextBox();
            this.lbSchoolCode = new System.Windows.Forms.Label();
            this.txtSchoolID = new System.Windows.Forms.TextBox();
            this.lbSchoolID = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panelWork.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWork
            // 
            this.panelWork.Controls.Add(this.txtDescription);
            this.panelWork.Controls.Add(this.lbDescription);
            this.panelWork.Controls.Add(this.txtAccessPassword);
            this.panelWork.Controls.Add(this.lbAccessPassword);
            this.panelWork.Controls.Add(this.txtAccessAccount);
            this.panelWork.Controls.Add(this.lbAccessAccount);
            this.panelWork.Controls.Add(this.txtServiceURL);
            this.panelWork.Controls.Add(this.lbServiceURL);
            this.panelWork.Controls.Add(this.txtSchoolName);
            this.panelWork.Controls.Add(this.lbSchoolName);
            this.panelWork.Controls.Add(this.txtSchoolCode);
            this.panelWork.Controls.Add(this.lbSchoolCode);
            this.panelWork.Controls.Add(this.txtSchoolID);
            this.panelWork.Controls.Add(this.lbSchoolID);
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(0, 0);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(456, 355);
            this.panelWork.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(72, 206);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(358, 85);
            this.txtDescription.TabIndex = 13;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(11, 210);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(65, 12);
            this.lbDescription.TabIndex = 12;
            this.lbDescription.Text = "描述信息：";
            // 
            // txtAccessPassword
            // 
            this.txtAccessPassword.Location = new System.Drawing.Point(72, 178);
            this.txtAccessPassword.Name = "txtAccessPassword";
            this.txtAccessPassword.Size = new System.Drawing.Size(358, 21);
            this.txtAccessPassword.TabIndex = 11;
            // 
            // lbAccessPassword
            // 
            this.lbAccessPassword.AutoSize = true;
            this.lbAccessPassword.Location = new System.Drawing.Point(11, 182);
            this.lbAccessPassword.Name = "lbAccessPassword";
            this.lbAccessPassword.Size = new System.Drawing.Size(65, 12);
            this.lbAccessPassword.TabIndex = 10;
            this.lbAccessPassword.Text = "密钥密码：";
            // 
            // txtAccessAccount
            // 
            this.txtAccessAccount.Location = new System.Drawing.Point(72, 148);
            this.txtAccessAccount.Name = "txtAccessAccount";
            this.txtAccessAccount.Size = new System.Drawing.Size(358, 21);
            this.txtAccessAccount.TabIndex = 9;
            // 
            // lbAccessAccount
            // 
            this.lbAccessAccount.AutoSize = true;
            this.lbAccessAccount.Location = new System.Drawing.Point(11, 152);
            this.lbAccessAccount.Name = "lbAccessAccount";
            this.lbAccessAccount.Size = new System.Drawing.Size(65, 12);
            this.lbAccessAccount.TabIndex = 8;
            this.lbAccessAccount.Text = "密钥账号：";
            // 
            // txtServiceURL
            // 
            this.txtServiceURL.Location = new System.Drawing.Point(72, 93);
            this.txtServiceURL.Multiline = true;
            this.txtServiceURL.Name = "txtServiceURL";
            this.txtServiceURL.Size = new System.Drawing.Size(358, 46);
            this.txtServiceURL.TabIndex = 7;
            // 
            // lbServiceURL
            // 
            this.lbServiceURL.AutoSize = true;
            this.lbServiceURL.Location = new System.Drawing.Point(6, 107);
            this.lbServiceURL.Name = "lbServiceURL";
            this.lbServiceURL.Size = new System.Drawing.Size(71, 12);
            this.lbServiceURL.TabIndex = 6;
            this.lbServiceURL.Text = "服务器URL：";
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.Location = new System.Drawing.Point(72, 65);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(358, 21);
            this.txtSchoolName.TabIndex = 5;
            // 
            // lbSchoolName
            // 
            this.lbSchoolName.AutoSize = true;
            this.lbSchoolName.Location = new System.Drawing.Point(11, 69);
            this.lbSchoolName.Name = "lbSchoolName";
            this.lbSchoolName.Size = new System.Drawing.Size(65, 12);
            this.lbSchoolName.TabIndex = 4;
            this.lbSchoolName.Text = "学校名称：";
            // 
            // txtSchoolCode
            // 
            this.txtSchoolCode.Location = new System.Drawing.Point(72, 37);
            this.txtSchoolCode.Name = "txtSchoolCode";
            this.txtSchoolCode.Size = new System.Drawing.Size(358, 21);
            this.txtSchoolCode.TabIndex = 3;
            // 
            // lbSchoolCode
            // 
            this.lbSchoolCode.AutoSize = true;
            this.lbSchoolCode.Location = new System.Drawing.Point(11, 41);
            this.lbSchoolCode.Name = "lbSchoolCode";
            this.lbSchoolCode.Size = new System.Drawing.Size(65, 12);
            this.lbSchoolCode.TabIndex = 2;
            this.lbSchoolCode.Text = "学校代码：";
            // 
            // txtSchoolID
            // 
            this.txtSchoolID.Location = new System.Drawing.Point(72, 9);
            this.txtSchoolID.Name = "txtSchoolID";
            this.txtSchoolID.ReadOnly = true;
            this.txtSchoolID.Size = new System.Drawing.Size(358, 21);
            this.txtSchoolID.TabIndex = 1;
            // 
            // lbSchoolID
            // 
            this.lbSchoolID.AutoSize = true;
            this.lbSchoolID.Location = new System.Drawing.Point(22, 13);
            this.lbSchoolID.Name = "lbSchoolID";
            this.lbSchoolID.Size = new System.Drawing.Size(53, 12);
            this.lbSchoolID.TabIndex = 0;
            this.lbSchoolID.Text = "学校ID：";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnDelete);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 309);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(456, 46);
            this.panelBottom.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(146, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(236, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // CredentialsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 355);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelWork);
            this.MaximizeBox = false;
            this.Name = "CredentialsWindow";
            this.ShowInTaskbar = false;
            this.Text = "访问密钥明细";
            this.Title = "访问密钥明细";
            this.Load += new System.EventHandler(this.CredentialsWindow_Load);
            this.panelWork.ResumeLayout(false);
            this.panelWork.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lbSchoolID;
        private System.Windows.Forms.TextBox txtSchoolID;
        private System.Windows.Forms.Label lbSchoolCode;
        private System.Windows.Forms.TextBox txtSchoolCode;
        private System.Windows.Forms.TextBox txtSchoolName;
        private System.Windows.Forms.Label lbSchoolName;
        private System.Windows.Forms.TextBox txtServiceURL;
        private System.Windows.Forms.Label lbServiceURL;
        private System.Windows.Forms.TextBox txtAccessAccount;
        private System.Windows.Forms.Label lbAccessAccount;
        private System.Windows.Forms.TextBox txtAccessPassword;
        private System.Windows.Forms.Label lbAccessPassword;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
    }
}