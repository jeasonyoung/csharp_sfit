namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class BoradcastAddressWindow
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
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBroadcast = new System.Windows.Forms.TextBox();
            this.lbHostBroadcast = new System.Windows.Forms.Label();
            this.txtIPSubnet = new System.Windows.Forms.TextBox();
            this.lbIPSubnet = new System.Windows.Forms.Label();
            this.ddlHostIP = new System.Windows.Forms.ComboBox();
            this.lbHostIP = new System.Windows.Forms.Label();
            this.groupBoxDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.btnClose;
            this.btnClose.Location = new System.Drawing.Point(354, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxDescription.Controls.Add(this.lbMessage);
            this.groupBoxDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxDescription.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBoxDescription.Location = new System.Drawing.Point(26, 264);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(379, 105);
            this.groupBoxDescription.TabIndex = 23;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "说明";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.Location = new System.Drawing.Point(3, 19);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(360, 85);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.Text = "       由于采用教师机客户端采用广播的方式，向学生机客户端发送\r\n广播消息告之主机位置以便学生向教师机客户端发送连接请求从而\r\n达到双方能够通讯之目的；因此" +
                "本功能的目的在于得到教师机与学\r\n生机在同一网络的广播地址，在可能存在多网卡或多IP地址的教师\r\n机上选择一与学生机在同一网络之IP。";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.ButtonOK;
            this.btnSave.Location = new System.Drawing.Point(180, 235);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 27);
            this.btnSave.TabIndex = 22;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBroadcast
            // 
            this.txtBroadcast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBroadcast.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBroadcast.ForeColor = System.Drawing.Color.Blue;
            this.txtBroadcast.Location = new System.Drawing.Point(142, 206);
            this.txtBroadcast.Name = "txtBroadcast";
            this.txtBroadcast.ReadOnly = true;
            this.txtBroadcast.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBroadcast.Size = new System.Drawing.Size(224, 23);
            this.txtBroadcast.TabIndex = 21;
            // 
            // lbHostBroadcast
            // 
            this.lbHostBroadcast.AutoSize = true;
            this.lbHostBroadcast.BackColor = System.Drawing.Color.Transparent;
            this.lbHostBroadcast.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHostBroadcast.Location = new System.Drawing.Point(71, 209);
            this.lbHostBroadcast.Name = "lbHostBroadcast";
            this.lbHostBroadcast.Size = new System.Drawing.Size(68, 17);
            this.lbHostBroadcast.TabIndex = 20;
            this.lbHostBroadcast.Text = "广播地址：";
            // 
            // txtIPSubnet
            // 
            this.txtIPSubnet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPSubnet.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIPSubnet.Location = new System.Drawing.Point(142, 174);
            this.txtIPSubnet.Name = "txtIPSubnet";
            this.txtIPSubnet.Size = new System.Drawing.Size(224, 23);
            this.txtIPSubnet.TabIndex = 19;
            this.txtIPSubnet.Text = "255.255.255.0";
            this.txtIPSubnet.TextChanged += new System.EventHandler(this.txtIPSubnet_TextChanged);
            // 
            // lbIPSubnet
            // 
            this.lbIPSubnet.AutoSize = true;
            this.lbIPSubnet.BackColor = System.Drawing.Color.Transparent;
            this.lbIPSubnet.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIPSubnet.Location = new System.Drawing.Point(71, 176);
            this.lbIPSubnet.Name = "lbIPSubnet";
            this.lbIPSubnet.Size = new System.Drawing.Size(68, 17);
            this.lbIPSubnet.TabIndex = 18;
            this.lbIPSubnet.Text = "子网掩码：";
            // 
            // ddlHostIP
            // 
            this.ddlHostIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlHostIP.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ddlHostIP.FormattingEnabled = true;
            this.ddlHostIP.Location = new System.Drawing.Point(142, 141);
            this.ddlHostIP.Name = "ddlHostIP";
            this.ddlHostIP.Size = new System.Drawing.Size(224, 25);
            this.ddlHostIP.TabIndex = 17;
            this.ddlHostIP.SelectedIndexChanged += new System.EventHandler(this.ddlHostIP_SelectedIndexChanged);
            // 
            // lbHostIP
            // 
            this.lbHostIP.AutoSize = true;
            this.lbHostIP.BackColor = System.Drawing.Color.Transparent;
            this.lbHostIP.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHostIP.Location = new System.Drawing.Point(65, 144);
            this.lbHostIP.Name = "lbHostIP";
            this.lbHostIP.Size = new System.Drawing.Size(79, 17);
            this.lbHostIP.TabIndex = 16;
            this.lbHostIP.Text = "本机IP地址：";
            // 
            // BoradcastAddressWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.BoradcastAddress;
            this.ClientSize = new System.Drawing.Size(430, 400);
            this.Controls.Add(this.groupBoxDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBroadcast);
            this.Controls.Add(this.lbHostBroadcast);
            this.Controls.Add(this.txtIPSubnet);
            this.Controls.Add(this.lbIPSubnet);
            this.Controls.Add(this.ddlHostIP);
            this.Controls.Add(this.lbHostIP);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BoradcastAddressWindow";
            this.Text = "网络设置";
            this.Title = "网络设置";
            this.Load += new System.EventHandler(this.BoradcastAddressWindow_Load);
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBroadcast;
        private System.Windows.Forms.Label lbHostBroadcast;
        private System.Windows.Forms.TextBox txtIPSubnet;
        private System.Windows.Forms.Label lbIPSubnet;
        private System.Windows.Forms.ComboBox ddlHostIP;
        private System.Windows.Forms.Label lbHostIP;
    }
}