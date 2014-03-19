namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class SystemSettingsWindow
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
            this.groupBoxNetPort = new System.Windows.Forms.GroupBox();
            this.txtFileDownTransfer = new System.Windows.Forms.TextBox();
            this.lbFileDownTransfer = new System.Windows.Forms.Label();
            this.lbPortInfo = new System.Windows.Forms.Label();
            this.txtMaxFileSize = new System.Windows.Forms.TextBox();
            this.lbMaxFileSize = new System.Windows.Forms.Label();
            this.txtFileUpTransfer = new System.Windows.Forms.TextBox();
            this.lbFileUpTransfer = new System.Windows.Forms.Label();
            this.txtClientCallback = new System.Windows.Forms.TextBox();
            this.lbClientCallback = new System.Windows.Forms.Label();
            this.txtHostOrder = new System.Windows.Forms.TextBox();
            this.lbHostOrder = new System.Windows.Forms.Label();
            this.txtBroadcastInterval = new System.Windows.Forms.TextBox();
            this.lbBroadcastInterval = new System.Windows.Forms.Label();
            this.txtHostBroadcast = new System.Windows.Forms.TextBox();
            this.lbHostBroadcast = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnApp = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBoxUIColor = new System.Windows.Forms.GroupBox();
            this.txtMoveColor = new System.Windows.Forms.TextBox();
            this.lbMoveColor = new System.Windows.Forms.Label();
            this.txtOfflineUploadColor = new System.Windows.Forms.TextBox();
            this.lbOfflineUploadColor = new System.Windows.Forms.Label();
            this.txtUploadColor = new System.Windows.Forms.TextBox();
            this.lbUploadColor = new System.Windows.Forms.Label();
            this.txtOfflineColor = new System.Windows.Forms.TextBox();
            this.lbOfflineColor = new System.Windows.Forms.Label();
            this.txtOnlineColor = new System.Windows.Forms.TextBox();
            this.lbOnlineColor = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.txtReviewColor = new System.Windows.Forms.TextBox();
            this.lbReviewColor = new System.Windows.Forms.Label();
            this.groupBoxNetPort.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupBoxUIColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxNetPort
            // 
            this.groupBoxNetPort.Controls.Add(this.txtFileDownTransfer);
            this.groupBoxNetPort.Controls.Add(this.lbFileDownTransfer);
            this.groupBoxNetPort.Controls.Add(this.lbPortInfo);
            this.groupBoxNetPort.Controls.Add(this.txtMaxFileSize);
            this.groupBoxNetPort.Controls.Add(this.lbMaxFileSize);
            this.groupBoxNetPort.Controls.Add(this.txtFileUpTransfer);
            this.groupBoxNetPort.Controls.Add(this.lbFileUpTransfer);
            this.groupBoxNetPort.Controls.Add(this.txtClientCallback);
            this.groupBoxNetPort.Controls.Add(this.lbClientCallback);
            this.groupBoxNetPort.Controls.Add(this.txtHostOrder);
            this.groupBoxNetPort.Controls.Add(this.lbHostOrder);
            this.groupBoxNetPort.Controls.Add(this.txtBroadcastInterval);
            this.groupBoxNetPort.Controls.Add(this.lbBroadcastInterval);
            this.groupBoxNetPort.Controls.Add(this.txtHostBroadcast);
            this.groupBoxNetPort.Controls.Add(this.lbHostBroadcast);
            this.groupBoxNetPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxNetPort.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBoxNetPort.Location = new System.Drawing.Point(0, 0);
            this.groupBoxNetPort.Name = "groupBoxNetPort";
            this.groupBoxNetPort.Size = new System.Drawing.Size(584, 185);
            this.groupBoxNetPort.TabIndex = 0;
            this.groupBoxNetPort.TabStop = false;
            this.groupBoxNetPort.Text = "网络端口设置";
            // 
            // txtFileDownTransfer
            // 
            this.txtFileDownTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileDownTransfer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtFileDownTransfer.Location = new System.Drawing.Point(160, 118);
            this.txtFileDownTransfer.Name = "txtFileDownTransfer";
            this.txtFileDownTransfer.Size = new System.Drawing.Size(100, 23);
            this.txtFileDownTransfer.TabIndex = 14;
            // 
            // lbFileDownTransfer
            // 
            this.lbFileDownTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFileDownTransfer.AutoSize = true;
            this.lbFileDownTransfer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbFileDownTransfer.Location = new System.Drawing.Point(34, 121);
            this.lbFileDownTransfer.Name = "lbFileDownTransfer";
            this.lbFileDownTransfer.Size = new System.Drawing.Size(122, 17);
            this.lbFileDownTransfer.TabIndex = 13;
            this.lbFileDownTransfer.Text = "文件下发端口(TCP)：";
            // 
            // lbPortInfo
            // 
            this.lbPortInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPortInfo.AutoSize = true;
            this.lbPortInfo.Location = new System.Drawing.Point(195, 152);
            this.lbPortInfo.Name = "lbPortInfo";
            this.lbPortInfo.Size = new System.Drawing.Size(194, 17);
            this.lbPortInfo.TabIndex = 12;
            this.lbPortInfo.Text = "(*端口应配置在1024~65535之间*)";
            // 
            // txtMaxFileSize
            // 
            this.txtMaxFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxFileSize.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtMaxFileSize.Location = new System.Drawing.Point(443, 86);
            this.txtMaxFileSize.Name = "txtMaxFileSize";
            this.txtMaxFileSize.Size = new System.Drawing.Size(100, 23);
            this.txtMaxFileSize.TabIndex = 11;
            // 
            // lbMaxFileSize
            // 
            this.lbMaxFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMaxFileSize.AutoSize = true;
            this.lbMaxFileSize.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbMaxFileSize.Location = new System.Drawing.Point(325, 89);
            this.lbMaxFileSize.Name = "lbMaxFileSize";
            this.lbMaxFileSize.Size = new System.Drawing.Size(112, 17);
            this.lbMaxFileSize.TabIndex = 10;
            this.lbMaxFileSize.Text = "文件传输上限(M)：";
            // 
            // txtFileUpTransfer
            // 
            this.txtFileUpTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileUpTransfer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtFileUpTransfer.Location = new System.Drawing.Point(160, 86);
            this.txtFileUpTransfer.Name = "txtFileUpTransfer";
            this.txtFileUpTransfer.Size = new System.Drawing.Size(100, 23);
            this.txtFileUpTransfer.TabIndex = 9;
            // 
            // lbFileUpTransfer
            // 
            this.lbFileUpTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFileUpTransfer.AutoSize = true;
            this.lbFileUpTransfer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbFileUpTransfer.Location = new System.Drawing.Point(34, 89);
            this.lbFileUpTransfer.Name = "lbFileUpTransfer";
            this.lbFileUpTransfer.Size = new System.Drawing.Size(122, 17);
            this.lbFileUpTransfer.TabIndex = 8;
            this.lbFileUpTransfer.Text = "文件上传端口(TCP)：";
            // 
            // txtClientCallback
            // 
            this.txtClientCallback.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientCallback.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtClientCallback.Location = new System.Drawing.Point(443, 53);
            this.txtClientCallback.Name = "txtClientCallback";
            this.txtClientCallback.Size = new System.Drawing.Size(100, 23);
            this.txtClientCallback.TabIndex = 7;
            // 
            // lbClientCallback
            // 
            this.lbClientCallback.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClientCallback.AutoSize = true;
            this.lbClientCallback.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbClientCallback.Location = new System.Drawing.Point(300, 56);
            this.lbClientCallback.Name = "lbClientCallback";
            this.lbClientCallback.Size = new System.Drawing.Size(137, 17);
            this.lbClientCallback.TabIndex = 6;
            this.lbClientCallback.Text = "客户端反馈端口(UDP)：";
            // 
            // txtHostOrder
            // 
            this.txtHostOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHostOrder.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtHostOrder.Location = new System.Drawing.Point(160, 53);
            this.txtHostOrder.Name = "txtHostOrder";
            this.txtHostOrder.Size = new System.Drawing.Size(100, 23);
            this.txtHostOrder.TabIndex = 5;
            // 
            // lbHostOrder
            // 
            this.lbHostOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbHostOrder.AutoSize = true;
            this.lbHostOrder.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbHostOrder.Location = new System.Drawing.Point(7, 56);
            this.lbHostOrder.Name = "lbHostOrder";
            this.lbHostOrder.Size = new System.Drawing.Size(149, 17);
            this.lbHostOrder.TabIndex = 4;
            this.lbHostOrder.Text = "主机下发指令端口(UDP)：";
            // 
            // txtBroadcastInterval
            // 
            this.txtBroadcastInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBroadcastInterval.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtBroadcastInterval.Location = new System.Drawing.Point(443, 21);
            this.txtBroadcastInterval.Name = "txtBroadcastInterval";
            this.txtBroadcastInterval.Size = new System.Drawing.Size(100, 23);
            this.txtBroadcastInterval.TabIndex = 3;
            // 
            // lbBroadcastInterval
            // 
            this.lbBroadcastInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBroadcastInterval.AutoSize = true;
            this.lbBroadcastInterval.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbBroadcastInterval.Location = new System.Drawing.Point(325, 24);
            this.lbBroadcastInterval.Name = "lbBroadcastInterval";
            this.lbBroadcastInterval.Size = new System.Drawing.Size(112, 17);
            this.lbBroadcastInterval.TabIndex = 2;
            this.lbBroadcastInterval.Text = "广播间隔时间(秒)：";
            // 
            // txtHostBroadcast
            // 
            this.txtHostBroadcast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHostBroadcast.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtHostBroadcast.Location = new System.Drawing.Point(160, 23);
            this.txtHostBroadcast.Name = "txtHostBroadcast";
            this.txtHostBroadcast.Size = new System.Drawing.Size(100, 23);
            this.txtHostBroadcast.TabIndex = 1;
            // 
            // lbHostBroadcast
            // 
            this.lbHostBroadcast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbHostBroadcast.AutoSize = true;
            this.lbHostBroadcast.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbHostBroadcast.Location = new System.Drawing.Point(55, 26);
            this.lbHostBroadcast.Name = "lbHostBroadcast";
            this.lbHostBroadcast.Size = new System.Drawing.Size(101, 17);
            this.lbHostBroadcast.TabIndex = 0;
            this.lbHostBroadcast.Text = "广播端口(UDP)：";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnApp);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 330);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(584, 52);
            this.panelBottom.TabIndex = 1;
            // 
            // btnApp
            // 
            this.btnApp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApp.Location = new System.Drawing.Point(500, 13);
            this.btnApp.Name = "btnApp";
            this.btnApp.Size = new System.Drawing.Size(72, 27);
            this.btnApp.TabIndex = 1;
            this.btnApp.Text = "应用";
            this.btnApp.UseVisualStyleBackColor = true;
            this.btnApp.Click += new System.EventHandler(this.btnApp_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(422, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBoxUIColor
            // 
            this.groupBoxUIColor.Controls.Add(this.txtReviewColor);
            this.groupBoxUIColor.Controls.Add(this.lbReviewColor);
            this.groupBoxUIColor.Controls.Add(this.txtMoveColor);
            this.groupBoxUIColor.Controls.Add(this.lbMoveColor);
            this.groupBoxUIColor.Controls.Add(this.txtOfflineUploadColor);
            this.groupBoxUIColor.Controls.Add(this.lbOfflineUploadColor);
            this.groupBoxUIColor.Controls.Add(this.txtUploadColor);
            this.groupBoxUIColor.Controls.Add(this.lbUploadColor);
            this.groupBoxUIColor.Controls.Add(this.txtOfflineColor);
            this.groupBoxUIColor.Controls.Add(this.lbOfflineColor);
            this.groupBoxUIColor.Controls.Add(this.txtOnlineColor);
            this.groupBoxUIColor.Controls.Add(this.lbOnlineColor);
            this.groupBoxUIColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUIColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBoxUIColor.Location = new System.Drawing.Point(0, 185);
            this.groupBoxUIColor.Name = "groupBoxUIColor";
            this.groupBoxUIColor.Size = new System.Drawing.Size(584, 145);
            this.groupBoxUIColor.TabIndex = 2;
            this.groupBoxUIColor.TabStop = false;
            this.groupBoxUIColor.Text = "监控界面颜色配置";
            // 
            // txtMoveColor
            // 
            this.txtMoveColor.BackColor = System.Drawing.SystemColors.Window;
            this.txtMoveColor.Location = new System.Drawing.Point(422, 108);
            this.txtMoveColor.Name = "txtMoveColor";
            this.txtMoveColor.Size = new System.Drawing.Size(100, 23);
            this.txtMoveColor.TabIndex = 9;
            this.txtMoveColor.Click += new System.EventHandler(this.ChoiceColor);
            this.txtMoveColor.Enter += new System.EventHandler(this.ChoiceColor);
            // 
            // lbMoveColor
            // 
            this.lbMoveColor.AutoSize = true;
            this.lbMoveColor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbMoveColor.Location = new System.Drawing.Point(326, 111);
            this.lbMoveColor.Name = "lbMoveColor";
            this.lbMoveColor.Size = new System.Drawing.Size(92, 17);
            this.lbMoveColor.TabIndex = 8;
            this.lbMoveColor.Text = "鼠标移动颜色：";
            // 
            // txtOfflineUploadColor
            // 
            this.txtOfflineUploadColor.BackColor = System.Drawing.SystemColors.Window;
            this.txtOfflineUploadColor.Location = new System.Drawing.Point(422, 74);
            this.txtOfflineUploadColor.Name = "txtOfflineUploadColor";
            this.txtOfflineUploadColor.Size = new System.Drawing.Size(100, 23);
            this.txtOfflineUploadColor.TabIndex = 7;
            this.txtOfflineUploadColor.Click += new System.EventHandler(this.ChoiceColor);
            this.txtOfflineUploadColor.Enter += new System.EventHandler(this.ChoiceColor);
            // 
            // lbOfflineUploadColor
            // 
            this.lbOfflineUploadColor.AutoSize = true;
            this.lbOfflineUploadColor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbOfflineUploadColor.Location = new System.Drawing.Point(312, 77);
            this.lbOfflineUploadColor.Name = "lbOfflineUploadColor";
            this.lbOfflineUploadColor.Size = new System.Drawing.Size(104, 17);
            this.lbOfflineUploadColor.TabIndex = 6;
            this.lbOfflineUploadColor.Text = "上传离线后颜色：";
            // 
            // txtUploadColor
            // 
            this.txtUploadColor.BackColor = System.Drawing.SystemColors.Window;
            this.txtUploadColor.Location = new System.Drawing.Point(160, 74);
            this.txtUploadColor.Name = "txtUploadColor";
            this.txtUploadColor.Size = new System.Drawing.Size(100, 23);
            this.txtUploadColor.TabIndex = 5;
            this.txtUploadColor.Click += new System.EventHandler(this.ChoiceColor);
            this.txtUploadColor.Enter += new System.EventHandler(this.ChoiceColor);
            // 
            // lbUploadColor
            // 
            this.lbUploadColor.AutoSize = true;
            this.lbUploadColor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbUploadColor.Location = new System.Drawing.Point(76, 77);
            this.lbUploadColor.Name = "lbUploadColor";
            this.lbUploadColor.Size = new System.Drawing.Size(80, 17);
            this.lbUploadColor.TabIndex = 4;
            this.lbUploadColor.Text = "上传时颜色：";
            // 
            // txtOfflineColor
            // 
            this.txtOfflineColor.BackColor = System.Drawing.SystemColors.Window;
            this.txtOfflineColor.Location = new System.Drawing.Point(422, 33);
            this.txtOfflineColor.Name = "txtOfflineColor";
            this.txtOfflineColor.Size = new System.Drawing.Size(100, 23);
            this.txtOfflineColor.TabIndex = 3;
            this.txtOfflineColor.Click += new System.EventHandler(this.ChoiceColor);
            this.txtOfflineColor.Enter += new System.EventHandler(this.ChoiceColor);
            // 
            // lbOfflineColor
            // 
            this.lbOfflineColor.AutoSize = true;
            this.lbOfflineColor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbOfflineColor.Location = new System.Drawing.Point(348, 36);
            this.lbOfflineColor.Name = "lbOfflineColor";
            this.lbOfflineColor.Size = new System.Drawing.Size(68, 17);
            this.lbOfflineColor.TabIndex = 2;
            this.lbOfflineColor.Text = "离线颜色：";
            // 
            // txtOnlineColor
            // 
            this.txtOnlineColor.BackColor = System.Drawing.SystemColors.Window;
            this.txtOnlineColor.Location = new System.Drawing.Point(160, 33);
            this.txtOnlineColor.Name = "txtOnlineColor";
            this.txtOnlineColor.Size = new System.Drawing.Size(100, 23);
            this.txtOnlineColor.TabIndex = 1;
            this.txtOnlineColor.Click += new System.EventHandler(this.ChoiceColor);
            this.txtOnlineColor.Enter += new System.EventHandler(this.ChoiceColor);
            // 
            // lbOnlineColor
            // 
            this.lbOnlineColor.AutoSize = true;
            this.lbOnlineColor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbOnlineColor.Location = new System.Drawing.Point(88, 36);
            this.lbOnlineColor.Name = "lbOnlineColor";
            this.lbOnlineColor.Size = new System.Drawing.Size(68, 17);
            this.lbOnlineColor.TabIndex = 0;
            this.lbOnlineColor.Text = "在线颜色：";
            // 
            // txtReviewColor
            // 
            this.txtReviewColor.BackColor = System.Drawing.SystemColors.Window;
            this.txtReviewColor.Location = new System.Drawing.Point(160, 108);
            this.txtReviewColor.Name = "txtReviewColor";
            this.txtReviewColor.Size = new System.Drawing.Size(100, 23);
            this.txtReviewColor.TabIndex = 11;
            this.txtReviewColor.Click += new System.EventHandler(this.ChoiceColor);
            this.txtReviewColor.Enter += new System.EventHandler(this.ChoiceColor);
            // 
            // lbReviewColor
            // 
            this.lbReviewColor.AutoSize = true;
            this.lbReviewColor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbReviewColor.Location = new System.Drawing.Point(52, 111);
            this.lbReviewColor.Name = "lbReviewColor";
            this.lbReviewColor.Size = new System.Drawing.Size(104, 17);
            this.lbReviewColor.TabIndex = 10;
            this.lbReviewColor.Text = "已批阅作品颜色：";
            // 
            // SystemSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 382);
            this.Controls.Add(this.groupBoxUIColor);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.groupBoxNetPort);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SystemSettingsWindow";
            this.Text = "系统设置";
            this.Title = "系统设置";
            this.Load += new System.EventHandler(this.SystemSettingsWindow_Load);
            this.groupBoxNetPort.ResumeLayout(false);
            this.groupBoxNetPort.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.groupBoxUIColor.ResumeLayout(false);
            this.groupBoxUIColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxNetPort;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnApp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtHostBroadcast;
        private System.Windows.Forms.Label lbHostBroadcast;
        private System.Windows.Forms.Label lbBroadcastInterval;
        private System.Windows.Forms.TextBox txtBroadcastInterval;
        private System.Windows.Forms.Label lbHostOrder;
        private System.Windows.Forms.TextBox txtHostOrder;
        private System.Windows.Forms.Label lbClientCallback;
        private System.Windows.Forms.TextBox txtClientCallback;
        private System.Windows.Forms.Label lbFileUpTransfer;
        private System.Windows.Forms.TextBox txtFileUpTransfer;
        private System.Windows.Forms.Label lbMaxFileSize;
        private System.Windows.Forms.TextBox txtMaxFileSize;
        private System.Windows.Forms.Label lbPortInfo;
        private System.Windows.Forms.GroupBox groupBoxUIColor;
        private System.Windows.Forms.Label lbOnlineColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TextBox txtOnlineColor;
        private System.Windows.Forms.TextBox txtOfflineColor;
        private System.Windows.Forms.Label lbOfflineColor;
        private System.Windows.Forms.TextBox txtUploadColor;
        private System.Windows.Forms.Label lbUploadColor;
        private System.Windows.Forms.TextBox txtOfflineUploadColor;
        private System.Windows.Forms.Label lbOfflineUploadColor;
        private System.Windows.Forms.TextBox txtMoveColor;
        private System.Windows.Forms.Label lbMoveColor;
        private System.Windows.Forms.TextBox txtFileDownTransfer;
        private System.Windows.Forms.Label lbFileDownTransfer;
        private System.Windows.Forms.TextBox txtReviewColor;
        private System.Windows.Forms.Label lbReviewColor;
    }
}