namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class LoginWindow
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lkUpdateCert = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.ddlUserAccount = new System.Windows.Forms.ComboBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.btnClose;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(355, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lkUpdateCert
            // 
            this.lkUpdateCert.AutoSize = true;
            this.lkUpdateCert.BackColor = System.Drawing.Color.Transparent;
            this.lkUpdateCert.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkUpdateCert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lkUpdateCert.Location = new System.Drawing.Point(325, 228);
            this.lkUpdateCert.Name = "lkUpdateCert";
            this.lkUpdateCert.Size = new System.Drawing.Size(80, 17);
            this.lkUpdateCert.TabIndex = 18;
            this.lkUpdateCert.TabStop = true;
            this.lkUpdateCert.Text = "更新访问密钥";
            this.lkUpdateCert.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkUpdateCert_LinkClicked);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.ButtonOK;
            this.btnLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogin.Location = new System.Drawing.Point(231, 222);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(72, 27);
            this.btnLogin.TabIndex = 17;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkOffline
            // 
            this.chkOffline.AutoSize = true;
            this.chkOffline.BackColor = System.Drawing.Color.Transparent;
            this.chkOffline.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOffline.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkOffline.Location = new System.Drawing.Point(106, 227);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(75, 21);
            this.chkOffline.TabIndex = 16;
            this.chkOffline.Text = "离线登陆";
            this.chkOffline.UseVisualStyleBackColor = false;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(155, 188);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(177, 21);
            this.txtUserPassword.TabIndex = 15;
            // 
            // ddlUserAccount
            // 
            this.ddlUserAccount.FormattingEnabled = true;
            this.ddlUserAccount.Location = new System.Drawing.Point(155, 162);
            this.ddlUserAccount.Name = "ddlUserAccount";
            this.ddlUserAccount.Size = new System.Drawing.Size(177, 20);
            this.ddlUserAccount.TabIndex = 14;
            this.ddlUserAccount.TextChanged += new System.EventHandler(this.ddlUserAccount_TextChanged);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(8, 269);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(58, 16);
            this.lbMessage.TabIndex = 19;
            this.lbMessage.Text = "[Message]";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoginWindow
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.login;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(430, 300);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lkUpdateCert);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkOffline);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.ddlUserAccount);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginWindow";
            this.Text = "任课教师登陆";
            this.Title = "任课教师登陆";
            this.Load += new System.EventHandler(this.LoginWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lkUpdateCert;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.ComboBox ddlUserAccount;
        private System.Windows.Forms.Label lbMessage;
    }
}