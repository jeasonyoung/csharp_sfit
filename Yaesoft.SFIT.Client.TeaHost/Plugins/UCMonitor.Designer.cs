namespace Yaesoft.SFIT.Client.TeaHost.Plugins
{
    partial class UCMonitor
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelWork = new Yaesoft.SFIT.Client.Controls.PanelEx();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQueryWorks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemIssueWorks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOutputAll = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWork
            // 
            this.panelWork.AutoScroll = true;
            this.panelWork.AutoSize = true;
            this.panelWork.BackColor = System.Drawing.Color.Transparent;
            this.panelWork.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.MonitorBackground;
            this.panelWork.ContextMenuStrip = this.contextMenuStrip;
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(0, 0);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(584, 451);
            this.panelWork.TabIndex = 0;
            this.panelWork.Resize += new System.EventHandler(this.panelWork_Resize);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRefresh,
            this.menuItemQueryWorks,
            this.menuItemClear,
            this.menuItemIssueWorks,
            this.menuItemOutputAll});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 136);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // menuItemRefresh
            // 
            this.menuItemRefresh.Name = "menuItemRefresh";
            this.menuItemRefresh.Size = new System.Drawing.Size(152, 22);
            this.menuItemRefresh.Text = "刷新";
            this.menuItemRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
            // 
            // menuItemQueryWorks
            // 
            this.menuItemQueryWorks.Name = "menuItemQueryWorks";
            this.menuItemQueryWorks.Size = new System.Drawing.Size(152, 22);
            this.menuItemQueryWorks.Text = "查看全部作品";
            this.menuItemQueryWorks.Click += new System.EventHandler(this.menuItemQueryWorks_Click);
            // 
            // menuItemIssueWorks
            // 
            this.menuItemIssueWorks.Name = "menuItemIssueWorks";
            this.menuItemIssueWorks.Size = new System.Drawing.Size(152, 22);
            this.menuItemIssueWorks.Text = "下发学生作品";
            this.menuItemIssueWorks.Click += new System.EventHandler(this.menuItemIssueWorks_Click);
            // 
            // menuItemOutputAll
            // 
            this.menuItemOutputAll.Name = "menuItemOutputAll";
            this.menuItemOutputAll.Size = new System.Drawing.Size(152, 22);
            this.menuItemOutputAll.Text = "导出全部作品";
            this.menuItemOutputAll.Click += new System.EventHandler(this.menuItemOutputAll_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "作品单向导出目录";
            // 
            // menuItemClear
            // 
            //this.menuItemClear.Name = "menuItemClear";
            //this.menuItemClear.Size = new System.Drawing.Size(152, 22);
            //this.menuItemClear.Text = "清理冗余作品";
            //this.menuItemClear.Click += new System.EventHandler(this.menuItemClear_Click);
            // 
            // UCMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelWork);
            this.Name = "UCMonitor";
            this.Size = new System.Drawing.Size(584, 451);
            this.Load += new System.EventHandler(this.UCMonitor_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Yaesoft.SFIT.Client.Controls.PanelEx panelWork;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuItemOutputAll;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem menuItemQueryWorks;
        private System.Windows.Forms.ToolStripMenuItem menuItemIssueWorks;
        private System.Windows.Forms.ToolStripMenuItem menuItemClear;
    }
}
