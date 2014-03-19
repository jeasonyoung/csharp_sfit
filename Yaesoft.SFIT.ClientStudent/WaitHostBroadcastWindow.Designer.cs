namespace Yaesoft.SFIT.ClientStudent
{
    partial class WaitHostBroadcastWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitHostBroadcastWindow));
            this.btnClose = new System.Windows.Forms.Button();
            this.lbHost = new System.Windows.Forms.Label();
            this.cbbTeaHost = new System.Windows.Forms.ComboBox();
            this.txtHostInfo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBoxMessage = new System.Windows.Forms.GroupBox();
            this.lbBroadcastMessage = new System.Windows.Forms.Label();
            this.lbRunTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelMessage = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBoxMessage.SuspendLayout();
            this.panelMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Yaesoft.SFIT.ClientStudent.Properties.Resources.btnClose;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(356, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbHost
            // 
            this.lbHost.AutoSize = true;
            this.lbHost.BackColor = System.Drawing.Color.Transparent;
            this.lbHost.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHost.Location = new System.Drawing.Point(26, 145);
            this.lbHost.Name = "lbHost";
            this.lbHost.Size = new System.Drawing.Size(92, 17);
            this.lbHost.TabIndex = 1;
            this.lbHost.Text = "授课教师主机：";
            this.lbHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbTeaHost
            // 
            this.cbbTeaHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTeaHost.FormattingEnabled = true;
            this.cbbTeaHost.Location = new System.Drawing.Point(113, 145);
            this.cbbTeaHost.Name = "cbbTeaHost";
            this.cbbTeaHost.Size = new System.Drawing.Size(294, 20);
            this.cbbTeaHost.TabIndex = 2;
            this.cbbTeaHost.SelectedIndexChanged += new System.EventHandler(this.cbbTeaHost_SelectedIndexChanged);
            // 
            // txtHostInfo
            // 
            this.txtHostInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHostInfo.Enabled = false;
            this.txtHostInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHostInfo.Location = new System.Drawing.Point(29, 171);
            this.txtHostInfo.Multiline = true;
            this.txtHostInfo.Name = "txtHostInfo";
            this.txtHostInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHostInfo.Size = new System.Drawing.Size(378, 57);
            this.txtHostInfo.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::Yaesoft.SFIT.ClientStudent.Properties.Resources.ButtonOK;
            this.btnSave.Location = new System.Drawing.Point(335, 232);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 27);
            this.btnSave.TabIndex = 4;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBoxMessage
            // 
            this.groupBoxMessage.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxMessage.Controls.Add(this.lbBroadcastMessage);
            this.groupBoxMessage.Location = new System.Drawing.Point(27, 40);
            this.groupBoxMessage.Name = "groupBoxMessage";
            this.groupBoxMessage.Size = new System.Drawing.Size(380, 99);
            this.groupBoxMessage.TabIndex = 5;
            this.groupBoxMessage.TabStop = false;
            // 
            // lbBroadcastMessage
            // 
            this.lbBroadcastMessage.AutoSize = true;
            this.lbBroadcastMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBroadcastMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBroadcastMessage.ForeColor = System.Drawing.Color.Silver;
            this.lbBroadcastMessage.Location = new System.Drawing.Point(3, 17);
            this.lbBroadcastMessage.Name = "lbBroadcastMessage";
            this.lbBroadcastMessage.Size = new System.Drawing.Size(75, 17);
            this.lbBroadcastMessage.TabIndex = 0;
            this.lbBroadcastMessage.Text = "[Broadcast]";
            // 
            // lbRunTime
            // 
            this.lbRunTime.AutoSize = true;
            this.lbRunTime.BackColor = System.Drawing.Color.Transparent;
            this.lbRunTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRunTime.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbRunTime.Location = new System.Drawing.Point(29, 237);
            this.lbRunTime.Name = "lbRunTime";
            this.lbRunTime.Size = new System.Drawing.Size(75, 17);
            this.lbRunTime.TabIndex = 6;
            this.lbRunTime.Text = "运行时间:0\'s";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            // 
            // panelMessage
            // 
            this.panelMessage.BackColor = System.Drawing.Color.Transparent;
            this.panelMessage.Controls.Add(this.lbMessage);
            this.panelMessage.Location = new System.Drawing.Point(10, 263);
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Size = new System.Drawing.Size(409, 27);
            this.panelMessage.TabIndex = 7;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.ForeColor = System.Drawing.Color.DimGray;
            this.lbMessage.Location = new System.Drawing.Point(3, 7);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(69, 17);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.Text = "[Message]";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "学生信息技术档案管理系统学生客户端";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "学生客户端";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // WaitHostBroadcastWindow
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yaesoft.SFIT.ClientStudent.Properties.Resources.Host;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(431, 300);
            this.Controls.Add(this.panelMessage);
            this.Controls.Add(this.lbRunTime);
            this.Controls.Add(this.groupBoxMessage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHostInfo);
            this.Controls.Add(this.cbbTeaHost);
            this.Controls.Add(this.lbHost);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitHostBroadcastWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生机客户端等待连接教师主机";
            this.Title = "学生机客户端等待连接教师主机";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WaitHostBroadcastWindow_Load);
            this.groupBoxMessage.ResumeLayout(false);
            this.groupBoxMessage.PerformLayout();
            this.panelMessage.ResumeLayout(false);
            this.panelMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbHost;
        private System.Windows.Forms.ComboBox cbbTeaHost;
        private System.Windows.Forms.TextBox txtHostInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBoxMessage;
        private System.Windows.Forms.Label lbBroadcastMessage;
        private System.Windows.Forms.Label lbRunTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panelMessage;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}