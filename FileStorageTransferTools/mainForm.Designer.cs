namespace FileStorageTransferTools
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.panelWorkspace = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnTrans = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.lbConn = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbProccess = new System.Windows.Forms.Label();
            this.panelWorkspace.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWorkspace
            // 
            this.panelWorkspace.Controls.Add(this.lbProccess);
            this.panelWorkspace.Controls.Add(this.progressBar);
            this.panelWorkspace.Controls.Add(this.btnTrans);
            this.panelWorkspace.Controls.Add(this.txtPath);
            this.panelWorkspace.Controls.Add(this.txtConn);
            this.panelWorkspace.Controls.Add(this.lbFilePath);
            this.panelWorkspace.Controls.Add(this.lbConn);
            resources.ApplyResources(this.panelWorkspace, "panelWorkspace");
            this.panelWorkspace.Name = "panelWorkspace";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // btnTrans
            // 
            resources.ApplyResources(this.btnTrans, "btnTrans");
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // txtPath
            // 
            this.txtPath.ForeColor = System.Drawing.Color.ForestGreen;
            resources.ApplyResources(this.txtPath, "txtPath");
            this.txtPath.Name = "txtPath";
            this.txtPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPath_MouseDoubleClick);
            // 
            // txtConn
            // 
            this.txtConn.ForeColor = System.Drawing.Color.ForestGreen;
            resources.ApplyResources(this.txtConn, "txtConn");
            this.txtConn.Name = "txtConn";
            // 
            // lbFilePath
            // 
            resources.ApplyResources(this.lbFilePath, "lbFilePath");
            this.lbFilePath.Name = "lbFilePath";
            // 
            // lbConn
            // 
            resources.ApplyResources(this.lbConn, "lbConn");
            this.lbConn.Name = "lbConn";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lbMessage);
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // lbMessage
            // 
            resources.ApplyResources(this.lbMessage, "lbMessage");
            this.lbMessage.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbMessage.Name = "lbMessage";
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lbProccess
            // 
            resources.ApplyResources(this.lbProccess, "lbProccess");
            this.lbProccess.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbProccess.Name = "lbProccess";
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelWorkspace);
            this.DoubleBuffered = true;
            this.Name = "mainForm";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panelWorkspace.ResumeLayout(false);
            this.panelWorkspace.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWorkspace;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lbConn;
        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.TextBox txtConn;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnTrans;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbProccess;
    }
}