namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class SelectCredentialsWindow
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.txtAccessPassword = new System.Windows.Forms.TextBox();
            this.lbAccessPassword = new System.Windows.Forms.Label();
            this.txtAccessAccount = new System.Windows.Forms.TextBox();
            this.lbAccessAccount = new System.Windows.Forms.Label();
            this.txtServiceURL = new System.Windows.Forms.TextBox();
            this.lbServiceURL = new System.Windows.Forms.Label();
            this.ddlSchoolName = new System.Windows.Forms.ComboBox();
            this.lbSchoolName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Enabled = false;
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDescription.Location = new System.Drawing.Point(104, 292);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(300, 43);
            this.txtDescription.TabIndex = 36;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.BackColor = System.Drawing.Color.Transparent;
            this.lbDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDescription.Location = new System.Drawing.Point(39, 295);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(68, 17);
            this.lbDescription.TabIndex = 35;
            this.lbDescription.Text = "描述信息：";
            // 
            // txtAccessPassword
            // 
            this.txtAccessPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccessPassword.Enabled = false;
            this.txtAccessPassword.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAccessPassword.Location = new System.Drawing.Point(104, 265);
            this.txtAccessPassword.Name = "txtAccessPassword";
            this.txtAccessPassword.PasswordChar = '*';
            this.txtAccessPassword.ReadOnly = true;
            this.txtAccessPassword.Size = new System.Drawing.Size(300, 23);
            this.txtAccessPassword.TabIndex = 34;
            // 
            // lbAccessPassword
            // 
            this.lbAccessPassword.AutoSize = true;
            this.lbAccessPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbAccessPassword.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAccessPassword.Location = new System.Drawing.Point(39, 269);
            this.lbAccessPassword.Name = "lbAccessPassword";
            this.lbAccessPassword.Size = new System.Drawing.Size(68, 17);
            this.lbAccessPassword.TabIndex = 33;
            this.lbAccessPassword.Text = "密钥密码：";
            // 
            // txtAccessAccount
            // 
            this.txtAccessAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccessAccount.Enabled = false;
            this.txtAccessAccount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAccessAccount.Location = new System.Drawing.Point(104, 238);
            this.txtAccessAccount.Name = "txtAccessAccount";
            this.txtAccessAccount.ReadOnly = true;
            this.txtAccessAccount.Size = new System.Drawing.Size(300, 23);
            this.txtAccessAccount.TabIndex = 32;
            // 
            // lbAccessAccount
            // 
            this.lbAccessAccount.AutoSize = true;
            this.lbAccessAccount.BackColor = System.Drawing.Color.Transparent;
            this.lbAccessAccount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAccessAccount.Location = new System.Drawing.Point(39, 242);
            this.lbAccessAccount.Name = "lbAccessAccount";
            this.lbAccessAccount.Size = new System.Drawing.Size(68, 17);
            this.lbAccessAccount.TabIndex = 31;
            this.lbAccessAccount.Text = "密钥账号：";
            // 
            // txtServiceURL
            // 
            this.txtServiceURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceURL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtServiceURL.Location = new System.Drawing.Point(104, 190);
            this.txtServiceURL.Multiline = true;
            this.txtServiceURL.Name = "txtServiceURL";
            this.txtServiceURL.ReadOnly = true;
            this.txtServiceURL.Size = new System.Drawing.Size(300, 42);
            this.txtServiceURL.TabIndex = 30;
            // 
            // lbServiceURL
            // 
            this.lbServiceURL.AutoSize = true;
            this.lbServiceURL.BackColor = System.Drawing.Color.Transparent;
            this.lbServiceURL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbServiceURL.Location = new System.Drawing.Point(39, 192);
            this.lbServiceURL.Name = "lbServiceURL";
            this.lbServiceURL.Size = new System.Drawing.Size(79, 17);
            this.lbServiceURL.TabIndex = 29;
            this.lbServiceURL.Text = "服务器URL：";
            // 
            // ddlSchoolName
            // 
            this.ddlSchoolName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSchoolName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ddlSchoolName.FormattingEnabled = true;
            this.ddlSchoolName.Location = new System.Drawing.Point(105, 164);
            this.ddlSchoolName.Name = "ddlSchoolName";
            this.ddlSchoolName.Size = new System.Drawing.Size(300, 25);
            this.ddlSchoolName.TabIndex = 28;
            this.ddlSchoolName.SelectedIndexChanged += new System.EventHandler(this.ddlSchoolName_SelectedIndexChanged);
            // 
            // lbSchoolName
            // 
            this.lbSchoolName.AutoSize = true;
            this.lbSchoolName.BackColor = System.Drawing.Color.Transparent;
            this.lbSchoolName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSchoolName.Location = new System.Drawing.Point(39, 167);
            this.lbSchoolName.Name = "lbSchoolName";
            this.lbSchoolName.Size = new System.Drawing.Size(68, 17);
            this.lbSchoolName.TabIndex = 27;
            this.lbSchoolName.Text = "学校名称：";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.ButtonOK;
            this.btnSave.Location = new System.Drawing.Point(179, 341);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 27);
            this.btnSave.TabIndex = 37;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(12, 376);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(69, 17);
            this.lbMessage.TabIndex = 38;
            this.lbMessage.Text = "[Message]";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SelectCredentialsWindow
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.Credentials;
            this.ClientSize = new System.Drawing.Size(430, 400);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.txtAccessPassword);
            this.Controls.Add(this.lbAccessPassword);
            this.Controls.Add(this.txtAccessAccount);
            this.Controls.Add(this.lbAccessAccount);
            this.Controls.Add(this.txtServiceURL);
            this.Controls.Add(this.lbServiceURL);
            this.Controls.Add(this.ddlSchoolName);
            this.Controls.Add(this.lbSchoolName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectCredentialsWindow";
            this.Text = "SelectCredentialsWindow";
            this.Title = "SelectCredentialsWindow";
            this.Load += new System.EventHandler(this.SelectCredentialsWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox txtAccessPassword;
        private System.Windows.Forms.Label lbAccessPassword;
        private System.Windows.Forms.TextBox txtAccessAccount;
        private System.Windows.Forms.Label lbAccessAccount;
        private System.Windows.Forms.TextBox txtServiceURL;
        private System.Windows.Forms.Label lbServiceURL;
        private System.Windows.Forms.ComboBox ddlSchoolName;
        private System.Windows.Forms.Label lbSchoolName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbMessage;
    }
}