namespace OldWorksToNew
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnBrowserRoot = new System.Windows.Forms.Button();
            this.txtNewRoot = new System.Windows.Forms.TextBox();
            this.lbNew = new System.Windows.Forms.Label();
            this.btnOldBowser = new System.Windows.Forms.Button();
            this.txtOldPath = new System.Windows.Forms.TextBox();
            this.lbOld = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lbMessage);
            this.groupBox.Controls.Add(this.btnRun);
            this.groupBox.Controls.Add(this.btnBrowserRoot);
            this.groupBox.Controls.Add(this.txtNewRoot);
            this.groupBox.Controls.Add(this.lbNew);
            this.groupBox.Controls.Add(this.btnOldBowser);
            this.groupBox.Controls.Add(this.txtOldPath);
            this.groupBox.Controls.Add(this.lbOld);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(566, 103);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "设置";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(406, 72);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(120, 23);
            this.btnRun.TabIndex = 12;
            this.btnRun.Text = "[执行升级]";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnBrowserRoot
            // 
            this.btnBrowserRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowserRoot.Location = new System.Drawing.Point(452, 43);
            this.btnBrowserRoot.Name = "btnBrowserRoot";
            this.btnBrowserRoot.Size = new System.Drawing.Size(73, 23);
            this.btnBrowserRoot.TabIndex = 11;
            this.btnBrowserRoot.Text = "[浏览...]";
            this.btnBrowserRoot.UseVisualStyleBackColor = true;
            this.btnBrowserRoot.Click += new System.EventHandler(this.btnBrowserRoot_Click);
            // 
            // txtNewRoot
            // 
            this.txtNewRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewRoot.Location = new System.Drawing.Point(140, 42);
            this.txtNewRoot.Name = "txtNewRoot";
            this.txtNewRoot.Size = new System.Drawing.Size(300, 21);
            this.txtNewRoot.TabIndex = 10;
            // 
            // lbNew
            // 
            this.lbNew.AutoSize = true;
            this.lbNew.Location = new System.Drawing.Point(7, 47);
            this.lbNew.Name = "lbNew";
            this.lbNew.Size = new System.Drawing.Size(137, 12);
            this.lbNew.TabIndex = 9;
            this.lbNew.Text = "当前系统HostData目录：";
            // 
            // btnOldBowser
            // 
            this.btnOldBowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOldBowser.Location = new System.Drawing.Point(451, 13);
            this.btnOldBowser.Name = "btnOldBowser";
            this.btnOldBowser.Size = new System.Drawing.Size(73, 23);
            this.btnOldBowser.TabIndex = 8;
            this.btnOldBowser.Text = "[浏览...]";
            this.btnOldBowser.UseVisualStyleBackColor = true;
            this.btnOldBowser.Click += new System.EventHandler(this.btnOldBowser_Click);
            // 
            // txtOldPath
            // 
            this.txtOldPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldPath.Location = new System.Drawing.Point(140, 15);
            this.txtOldPath.Name = "txtOldPath";
            this.txtOldPath.Size = new System.Drawing.Size(300, 21);
            this.txtOldPath.TabIndex = 7;
            // 
            // lbOld
            // 
            this.lbOld.AutoSize = true;
            this.lbOld.Location = new System.Drawing.Point(7, 18);
            this.lbOld.Name = "lbOld";
            this.lbOld.Size = new System.Drawing.Size(137, 12);
            this.lbOld.TabIndex = 6;
            this.lbOld.Text = "旧版备份HostData目录：";
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(0, 103);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(566, 163);
            this.rtbLog.TabIndex = 8;
            this.rtbLog.Text = "";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(12, 77);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(59, 12);
            this.lbMessage.TabIndex = 13;
            this.lbMessage.Text = "[Message]";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "作业系统HostData目录";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 266);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.groupBox);
            this.Name = "MainForm";
            this.Text = "旧版作业结构向新版升级";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnBrowserRoot;
        private System.Windows.Forms.TextBox txtNewRoot;
        private System.Windows.Forms.Label lbNew;
        private System.Windows.Forms.Button btnOldBowser;
        private System.Windows.Forms.TextBox txtOldPath;
        private System.Windows.Forms.Label lbOld;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;

    }
}

