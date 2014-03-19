namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class InitializeWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitializeWindow));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lbCopyRight = new System.Windows.Forms.Label();
            this.panelWork = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelBottom.SuspendLayout();
            this.panelWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.lbCopyRight);
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // lbCopyRight
            // 
            resources.ApplyResources(this.lbCopyRight, "lbCopyRight");
            this.lbCopyRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbCopyRight.Name = "lbCopyRight";
            // 
            // panelWork
            // 
            this.panelWork.BackColor = System.Drawing.Color.Transparent;
            this.panelWork.Controls.Add(this.lbMessage);
            resources.ApplyResources(this.panelWork, "panelWork");
            this.panelWork.Name = "panelWork";
            // 
            // lbMessage
            // 
            resources.ApplyResources(this.lbMessage, "lbMessage");
            this.lbMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Name = "lbMessage";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // InitializeWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.initload;
            this.Controls.Add(this.panelWork);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InitializeWindow";
            this.Title = "学生信息技术档案管理系统";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InitializeWindow_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelWork.ResumeLayout(false);
            this.panelWork.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label lbCopyRight;
        private System.Windows.Forms.Timer timer;
    }
}