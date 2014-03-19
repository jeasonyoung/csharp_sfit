namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class WorkImportWindow
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
            this.chkWorkInfo = new System.Windows.Forms.CheckBox();
            this.panelWork = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lbFileName = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.panelWork.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkWorkInfo
            // 
            this.chkWorkInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWorkInfo.AutoSize = true;
            this.chkWorkInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.chkWorkInfo.Location = new System.Drawing.Point(12, 40);
            this.chkWorkInfo.Name = "chkWorkInfo";
            this.chkWorkInfo.Size = new System.Drawing.Size(219, 21);
            this.chkWorkInfo.TabIndex = 1;
            this.chkWorkInfo.Text = "仅导入作品信息（不导入作品文件）";
            this.chkWorkInfo.UseVisualStyleBackColor = true;
            // 
            // panelWork
            // 
            this.panelWork.Controls.Add(this.btnImport);
            this.panelWork.Controls.Add(this.txtFilePath);
            this.panelWork.Controls.Add(this.lbFileName);
            this.panelWork.Controls.Add(this.chkWorkInfo);
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(0, 0);
            this.panelWork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(631, 108);
            this.panelWork.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(544, 38);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "导入数据";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilePath.Location = new System.Drawing.Point(147, 6);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(472, 23);
            this.txtFilePath.TabIndex = 3;
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(9, 9);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(140, 17);
            this.lbFileName.TabIndex = 2;
            this.lbFileName.Text = "导入学生数据文件地址：";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lbMessage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 73);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(631, 35);
            this.panelBottom.TabIndex = 1;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lbMessage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbMessage.Location = new System.Drawing.Point(15, 8);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(69, 17);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.Text = "[Message]";
            // 
            // WorkImportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 108);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelWork);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkImportWindow";
            this.Opacity = 0.9;
            this.Text = "学生作品导入";
            this.Title = "学生作品导入";
            this.Load += new System.EventHandler(this.WorkImportWindow_Load);
            this.panelWork.ResumeLayout(false);
            this.panelWork.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkWorkInfo;
        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnImport;

    }
}