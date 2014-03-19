namespace Yaesoft.SFIT.AccessoriesUtils
{
    partial class AccessoriesUtilsWin
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
            this.lbWorkRoot = new System.Windows.Forms.Label();
            this.txtWorkRoot = new System.Windows.Forms.TextBox();
            this.lbConn = new System.Windows.Forms.Label();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lbMessage = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBrowser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbWorkRoot
            // 
            this.lbWorkRoot.AutoSize = true;
            this.lbWorkRoot.Location = new System.Drawing.Point(13, 13);
            this.lbWorkRoot.Name = "lbWorkRoot";
            this.lbWorkRoot.Size = new System.Drawing.Size(101, 12);
            this.lbWorkRoot.TabIndex = 0;
            this.lbWorkRoot.Text = "作业数据根目录：";
            // 
            // txtWorkRoot
            // 
            this.txtWorkRoot.Location = new System.Drawing.Point(112, 7);
            this.txtWorkRoot.Name = "txtWorkRoot";
            this.txtWorkRoot.Size = new System.Drawing.Size(423, 21);
            this.txtWorkRoot.TabIndex = 1;
            // 
            // lbConn
            // 
            this.lbConn.AutoSize = true;
            this.lbConn.Location = new System.Drawing.Point(25, 37);
            this.lbConn.Name = "lbConn";
            this.lbConn.Size = new System.Drawing.Size(89, 12);
            this.lbConn.TabIndex = 2;
            this.lbConn.Text = "数据库链接串：";
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(112, 34);
            this.txtConn.Multiline = true;
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(462, 71);
            this.txtConn.TabIndex = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(435, 111);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(139, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "更新数据库附件校验码";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(12, 172);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(59, 12);
            this.lbMessage.TabIndex = 5;
            this.lbMessage.Text = "[Message]";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 191);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(559, 23);
            this.progressBar.TabIndex = 6;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(539, 6);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(44, 23);
            this.btnBrowser.TabIndex = 7;
            this.btnBrowser.Text = "浏览";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // AccessoriesUtilsWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 237);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtConn);
            this.Controls.Add(this.lbConn);
            this.Controls.Add(this.txtWorkRoot);
            this.Controls.Add(this.lbWorkRoot);
            this.Name = "AccessoriesUtilsWin";
            this.Text = "网站作业附件整理工具";
            this.Load += new System.EventHandler(this.AccessoriesUtilsWin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbWorkRoot;
        private System.Windows.Forms.TextBox txtWorkRoot;
        private System.Windows.Forms.Label lbConn;
        private System.Windows.Forms.TextBox txtConn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnBrowser;
    }
}

