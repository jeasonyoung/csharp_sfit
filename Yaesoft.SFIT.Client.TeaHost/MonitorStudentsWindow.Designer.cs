namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class MonitorStudentsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorStudentsWindow));
            this.panelTop = new Yaesoft.SFIT.Client.Controls.PanelEx();
            this.panelBottom = new Yaesoft.SFIT.Client.Controls.PanelEx();
            this.splitContainer = new Yaesoft.SFIT.Client.Controls.SplitContainerEx();
            this.panelRight = new Yaesoft.SFIT.Client.Controls.PanelEx();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            // 
            // panelBottom
            // 
            this.panelBottom.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.BottomBackground;
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelRight);
            // 
            // panelRight
            // 
            resources.ApplyResources(this.panelRight, "panelRight");
            this.panelRight.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.RightBackground;
            this.panelRight.Name = "panelRight";
            // 
            // MonitorStudentsWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "MonitorStudentsWindow";
            this.Title = "教师机客户端";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResizeEnd += new System.EventHandler(this.MonitorStudentsWindow_ResizeEnd);
            this.Load += new System.EventHandler(this.MonitorStudentsWindow_Load);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Yaesoft.SFIT.Client.Controls.PanelEx panelTop;
        private Yaesoft.SFIT.Client.Controls.PanelEx panelBottom;
        private Yaesoft.SFIT.Client.Controls.SplitContainerEx splitContainer;
        private Yaesoft.SFIT.Client.Controls.PanelEx panelRight;
    }
}