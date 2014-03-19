namespace Yaesoft.SFIT.Client.TeaHost.Plugins
{
    partial class UClassSettngs
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelWork = new System.Windows.Forms.Panel();
            this.lbStuLoginSet = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.ddlCatalog = new System.Windows.Forms.ComboBox();
            this.ddlLoginMethod = new System.Windows.Forms.ComboBox();
            this.lbCatalog = new System.Windows.Forms.Label();
            this.ddlClass = new System.Windows.Forms.ComboBox();
            this.lbClass = new System.Windows.Forms.Label();
            this.ddlGrade = new System.Windows.Forms.ComboBox();
            this.lbGrade = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbUserInfo = new System.Windows.Forms.Label();
            this.lbSchoolName = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelWork.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWork
            // 
            this.panelWork.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.ClassSettings_02;
            this.panelWork.Controls.Add(this.lbStuLoginSet);
            this.panelWork.Controls.Add(this.txtLoginPassword);
            this.panelWork.Controls.Add(this.ddlCatalog);
            this.panelWork.Controls.Add(this.ddlLoginMethod);
            this.panelWork.Controls.Add(this.lbCatalog);
            this.panelWork.Controls.Add(this.ddlClass);
            this.panelWork.Controls.Add(this.lbClass);
            this.panelWork.Controls.Add(this.ddlGrade);
            this.panelWork.Controls.Add(this.lbGrade);
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(25, 0);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(469, 103);
            this.panelWork.TabIndex = 2;
            // 
            // lbStuLoginSet
            // 
            this.lbStuLoginSet.AutoSize = true;
            this.lbStuLoginSet.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStuLoginSet.Location = new System.Drawing.Point(8, 67);
            this.lbStuLoginSet.Name = "lbStuLoginSet";
            this.lbStuLoginSet.Size = new System.Drawing.Size(92, 17);
            this.lbStuLoginSet.TabIndex = 9;
            this.lbStuLoginSet.Text = "学生登录方式：";
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginPassword.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginPassword.Location = new System.Drawing.Point(242, 67);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(220, 23);
            this.txtLoginPassword.TabIndex = 23;
            this.txtLoginPassword.Visible = false;
            // 
            // ddlCatalog
            // 
            this.ddlCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCatalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCatalog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ddlCatalog.FormattingEnabled = true;
            this.ddlCatalog.Location = new System.Drawing.Point(68, 38);
            this.ddlCatalog.Name = "ddlCatalog";
            this.ddlCatalog.Size = new System.Drawing.Size(394, 25);
            this.ddlCatalog.TabIndex = 8;
            this.ddlCatalog.SelectedIndexChanged += new System.EventHandler(this.ddlCatalog_SelectedIndexChanged);
            // 
            // ddlLoginMethod
            // 
            this.ddlLoginMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLoginMethod.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ddlLoginMethod.FormattingEnabled = true;
            this.ddlLoginMethod.Location = new System.Drawing.Point(98, 65);
            this.ddlLoginMethod.Name = "ddlLoginMethod";
            this.ddlLoginMethod.Size = new System.Drawing.Size(140, 25);
            this.ddlLoginMethod.TabIndex = 22;
            this.ddlLoginMethod.SelectedIndexChanged += new System.EventHandler(this.ddlLoginMethod_SelectedIndexChanged);
            // 
            // lbCatalog
            // 
            this.lbCatalog.AutoSize = true;
            this.lbCatalog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCatalog.Location = new System.Drawing.Point(7, 41);
            this.lbCatalog.Name = "lbCatalog";
            this.lbCatalog.Size = new System.Drawing.Size(68, 17);
            this.lbCatalog.TabIndex = 6;
            this.lbCatalog.Text = "课程目录：";
            // 
            // ddlClass
            // 
            this.ddlClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClass.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ddlClass.FormattingEnabled = true;
            this.ddlClass.Location = new System.Drawing.Point(218, 11);
            this.ddlClass.Name = "ddlClass";
            this.ddlClass.Size = new System.Drawing.Size(244, 25);
            this.ddlClass.TabIndex = 5;
            // 
            // lbClass
            // 
            this.lbClass.AutoSize = true;
            this.lbClass.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbClass.Location = new System.Drawing.Point(181, 15);
            this.lbClass.Name = "lbClass";
            this.lbClass.Size = new System.Drawing.Size(44, 17);
            this.lbClass.TabIndex = 3;
            this.lbClass.Text = "班级：";
            // 
            // ddlGrade
            // 
            this.ddlGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrade.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ddlGrade.FormattingEnabled = true;
            this.ddlGrade.Location = new System.Drawing.Point(44, 11);
            this.ddlGrade.Name = "ddlGrade";
            this.ddlGrade.Size = new System.Drawing.Size(121, 25);
            this.ddlGrade.TabIndex = 2;
            this.ddlGrade.SelectedIndexChanged += new System.EventHandler(this.ddlGrade_SelectedIndexChanged);
            // 
            // lbGrade
            // 
            this.lbGrade.AutoSize = true;
            this.lbGrade.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbGrade.Location = new System.Drawing.Point(7, 15);
            this.lbGrade.Name = "lbGrade";
            this.lbGrade.Size = new System.Drawing.Size(44, 17);
            this.lbGrade.TabIndex = 0;
            this.lbGrade.Text = "年级：";
            // 
            // panelRight
            // 
            this.panelRight.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.ClassSettings_03;
            this.panelRight.Controls.Add(this.groupBox);
            this.panelRight.Controls.Add(this.btnStart);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(494, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(306, 103);
            this.panelRight.TabIndex = 1;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lbStatus);
            this.groupBox.Controls.Add(this.lbUserInfo);
            this.groupBox.Controls.Add(this.lbSchoolName);
            this.groupBox.Location = new System.Drawing.Point(89, 4);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(214, 94);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbStatus.Location = new System.Drawing.Point(7, 64);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(51, 17);
            this.lbStatus.TabIndex = 2;
            this.lbStatus.Text = "[Status]";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbUserInfo
            // 
            this.lbUserInfo.AutoSize = true;
            this.lbUserInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserInfo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbUserInfo.Location = new System.Drawing.Point(7, 38);
            this.lbUserInfo.Name = "lbUserInfo";
            this.lbUserInfo.Size = new System.Drawing.Size(66, 17);
            this.lbUserInfo.TabIndex = 1;
            this.lbUserInfo.Text = "[UserInfo]";
            this.lbUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSchoolName
            // 
            this.lbSchoolName.AutoSize = true;
            this.lbSchoolName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSchoolName.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbSchoolName.Location = new System.Drawing.Point(7, 14);
            this.lbSchoolName.Name = "lbSchoolName";
            this.lbSchoolName.Size = new System.Drawing.Size(90, 17);
            this.lbSchoolName.TabIndex = 0;
            this.lbSchoolName.Text = "[SchoolName]";
            this.lbSchoolName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.Start;
            this.btnStart.Location = new System.Drawing.Point(3, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 90);
            this.btnStart.TabIndex = 0;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.MouseLeave += new System.EventHandler(this.btnStart_MouseLeave);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.btnStart_MouseEnter);
            // 
            // panelLeft
            // 
            this.panelLeft.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.ClassSettings_01;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(25, 103);
            this.panelLeft.TabIndex = 0;
            // 
            // UClassSettngs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWork);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "UClassSettngs";
            this.Size = new System.Drawing.Size(800, 103);
            this.Load += new System.EventHandler(this.UClassSettngs_Load);
            this.panelWork.ResumeLayout(false);
            this.panelWork.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.Label lbGrade;
        private System.Windows.Forms.ComboBox ddlGrade;
        private System.Windows.Forms.Label lbClass;
        private System.Windows.Forms.Label lbCatalog;
        private System.Windows.Forms.ComboBox ddlClass;
        private System.Windows.Forms.ComboBox ddlCatalog;
        private System.Windows.Forms.Label lbStuLoginSet;
        private System.Windows.Forms.ComboBox ddlLoginMethod;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lbSchoolName;
        private System.Windows.Forms.Label lbUserInfo;
        private System.Windows.Forms.Label lbStatus;
    }
}
