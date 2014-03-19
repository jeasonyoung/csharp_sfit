namespace Yaesoft.SFIT.Client.Forms
{
    partial class CaptureScreenWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureScreenWindow));
            this.panel = new System.Windows.Forms.Panel();
            this.lbCatcherSize = new System.Windows.Forms.Label();
            this.lbMousePoints = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.panelScreenCatcher = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackgroundImage = global::Yaesoft.SFIT.Client.Properties.Resources.qq;
            this.panel.Controls.Add(this.lbCatcherSize);
            this.panel.Controls.Add(this.lbMousePoints);
            this.panel.Controls.Add(this.lbInfo);
            resources.ApplyResources(this.panel, "panel");
            this.panel.Name = "panel";
            this.panel.MouseEnter += new System.EventHandler(this.panel_MouseEnter);
            // 
            // lbCatcherSize
            // 
            this.lbCatcherSize.BackColor = System.Drawing.Color.Transparent;
            this.lbCatcherSize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.lbCatcherSize, "lbCatcherSize");
            this.lbCatcherSize.Name = "lbCatcherSize";
            // 
            // lbMousePoints
            // 
            this.lbMousePoints.BackColor = System.Drawing.Color.Transparent;
            this.lbMousePoints.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.lbMousePoints, "lbMousePoints");
            this.lbMousePoints.Name = "lbMousePoints";
            // 
            // lbInfo
            // 
            resources.ApplyResources(this.lbInfo, "lbInfo");
            this.lbInfo.BackColor = System.Drawing.Color.Transparent;
            this.lbInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbInfo.Name = "lbInfo";
            // 
            // panelScreenCatcher
            // 
            this.panelScreenCatcher.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.panelScreenCatcher, "panelScreenCatcher");
            this.panelScreenCatcher.Name = "panelScreenCatcher";
            // 
            // CaptureScreenWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelScreenCatcher);
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "CaptureScreenWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CaptureScreenWindow_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CaptureScreenWindow_MouseUp);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CaptureScreenWindow_MouseDoubleClick);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CaptureScreenWindow_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CaptureScreenWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CaptureScreenWindow_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaptureScreenWindow_KeyDown);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbCatcherSize;
        private System.Windows.Forms.Label lbMousePoints;
        private System.Windows.Forms.Panel panelScreenCatcher;

    }
}