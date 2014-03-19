namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class ModifyWorkWindow
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
            this.panelTop = new Yaesoft.SFIT.Client.Controls.PanelEx();
            this.panelBottom = new Yaesoft.SFIT.Client.Controls.PanelEx();
            this.splitContainer = new Yaesoft.SFIT.Client.Controls.SplitContainerEx();
            this.treeView = new System.Windows.Forms.TreeView();
            this.listView = new System.Windows.Forms.ListView();
            this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemBatchUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAllDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.panelQuery = new Yaesoft.SFIT.Client.Controls.PanelEx();
            this.chkNoUpload = new System.Windows.Forms.CheckBox();
            this.chkNoReview = new System.Windows.Forms.CheckBox();
            this.cbbView = new System.Windows.Forms.ComboBox();
            this.chkRelease = new System.Windows.Forms.CheckBox();
            this.chkUpload = new System.Windows.Forms.CheckBox();
            this.chkReview = new System.Windows.Forms.CheckBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.lbStudentName = new System.Windows.Forms.Label();
            this.txtWorkName = new System.Windows.Forms.TextBox();
            this.lbWorkName = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.contextMenuStripListView.SuspendLayout();
            this.panelQuery.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.BottomBackground;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 27);
            this.panelTop.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.BottomBackground;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 522);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(800, 27);
            this.panelBottom.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.CollpasePanel = Yaesoft.SFIT.Client.Controls.SplitContainerEx.SplitterPanelEnum.Panel1;
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 27);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            this.splitContainer.Panel1MinSize = 0;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Panel2.Controls.Add(this.panelQuery);
            this.splitContainer.Panel2MinSize = 0;
            this.splitContainer.Size = new System.Drawing.Size(800, 495);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.SplitterWidth = 9;
            this.splitContainer.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Control;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(198, 493);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listView.BackgroundImage = global::Yaesoft.SFIT.Client.TeaHost.Properties.Resources.MonitorBackground;
            this.listView.ContextMenuStrip = this.contextMenuStripListView;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Location = new System.Drawing.Point(0, 60);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(589, 433);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.ItemActivate += new System.EventHandler(this.listView_ItemActivate);
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // contextMenuStripListView
            // 
            this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBatchUpload,
            this.menuItemAllDelete,
            this.menuItemClear});
            this.contextMenuStripListView.Name = "contextMenuStripListView";
            this.contextMenuStripListView.Size = new System.Drawing.Size(191, 92);
            this.contextMenuStripListView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripListView_Opening);
            // 
            // menuItemBatchUpload
            // 
            this.menuItemBatchUpload.Name = "menuItemBatchUpload";
            this.menuItemBatchUpload.Size = new System.Drawing.Size(178, 22);
            this.menuItemBatchUpload.Text = "批量上传列表中作品";
            this.menuItemBatchUpload.Click += new System.EventHandler(this.menuItemBatchUpload_Click);
            // 
            // menuItemAllDelete
            // 
            this.menuItemAllDelete.Name = "menuItemAllDelete";
            this.menuItemAllDelete.Size = new System.Drawing.Size(190, 22);
            this.menuItemAllDelete.Text = "删除当前班级课程作品";
            this.menuItemAllDelete.Click += new System.EventHandler(this.menuItemAllDelete_Click);
            // 
            // menuItemClear
            // 
            //this.menuItemClear.Name = "menuItemClear";
            //this.menuItemClear.Size = new System.Drawing.Size(178, 22);
            //this.menuItemClear.Text = "清理冗余作品";
            //this.menuItemClear.Click += new System.EventHandler(this.menuItemClear_Click);
            // 
            // panelQuery
            // 
            this.panelQuery.Controls.Add(this.chkNoUpload);
            this.panelQuery.Controls.Add(this.chkNoReview);
            this.panelQuery.Controls.Add(this.cbbView);
            this.panelQuery.Controls.Add(this.chkRelease);
            this.panelQuery.Controls.Add(this.chkUpload);
            this.panelQuery.Controls.Add(this.chkReview);
            this.panelQuery.Controls.Add(this.btnQuery);
            this.panelQuery.Controls.Add(this.txtStudentName);
            this.panelQuery.Controls.Add(this.lbStudentName);
            this.panelQuery.Controls.Add(this.txtWorkName);
            this.panelQuery.Controls.Add(this.lbWorkName);
            this.panelQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuery.Location = new System.Drawing.Point(0, 0);
            this.panelQuery.Name = "panelQuery";
            this.panelQuery.Size = new System.Drawing.Size(589, 60);
            this.panelQuery.TabIndex = 0;
            // 
            // chkNoUpload
            // 
            this.chkNoUpload.AutoSize = true;
            this.chkNoUpload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkNoUpload.Location = new System.Drawing.Point(205, 36);
            this.chkNoUpload.Name = "chkNoUpload";
            this.chkNoUpload.Size = new System.Drawing.Size(63, 21);
            this.chkNoUpload.TabIndex = 9;
            this.chkNoUpload.Text = "未上传";
            this.chkNoUpload.UseVisualStyleBackColor = true;
            this.chkNoUpload.CheckedChanged += new System.EventHandler(this.chkNoUpload_CheckedChanged);
            // 
            // chkNoReview
            // 
            this.chkNoReview.AutoSize = true;
            this.chkNoReview.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkNoReview.Location = new System.Drawing.Point(74, 36);
            this.chkNoReview.Name = "chkNoReview";
            this.chkNoReview.Size = new System.Drawing.Size(63, 21);
            this.chkNoReview.TabIndex = 7;
            this.chkNoReview.Text = "未批阅";
            this.chkNoReview.UseVisualStyleBackColor = true;
            this.chkNoReview.CheckedChanged += new System.EventHandler(this.chkNoReview_CheckedChanged);
            // 
            // cbbView
            // 
            this.cbbView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbView.FormattingEnabled = true;
            this.cbbView.Location = new System.Drawing.Point(457, 34);
            this.cbbView.Name = "cbbView";
            this.cbbView.Size = new System.Drawing.Size(121, 20);
            this.cbbView.TabIndex = 4;
            this.cbbView.SelectedIndexChanged += new System.EventHandler(this.cbbView_SelectedIndexChanged);
            // 
            // chkRelease
            // 
            this.chkRelease.AutoSize = true;
            this.chkRelease.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkRelease.Location = new System.Drawing.Point(271, 36);
            this.chkRelease.Name = "chkRelease";
            this.chkRelease.Size = new System.Drawing.Size(63, 21);
            this.chkRelease.TabIndex = 10;
            this.chkRelease.Text = "已发布";
            this.chkRelease.UseVisualStyleBackColor = true;
            // 
            // chkUpload
            // 
            this.chkUpload.AutoSize = true;
            this.chkUpload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkUpload.Location = new System.Drawing.Point(139, 36);
            this.chkUpload.Name = "chkUpload";
            this.chkUpload.Size = new System.Drawing.Size(63, 21);
            this.chkUpload.TabIndex = 8;
            this.chkUpload.Text = "已上传";
            this.chkUpload.UseVisualStyleBackColor = true;
            this.chkUpload.CheckedChanged += new System.EventHandler(this.chkUpload_CheckedChanged);
            // 
            // chkReview
            // 
            this.chkReview.AutoSize = true;
            this.chkReview.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkReview.Location = new System.Drawing.Point(8, 36);
            this.chkReview.Name = "chkReview";
            this.chkReview.Size = new System.Drawing.Size(63, 21);
            this.chkReview.TabIndex = 6;
            this.chkReview.Text = "已批阅";
            this.chkReview.UseVisualStyleBackColor = true;
            this.chkReview.CheckedChanged += new System.EventHandler(this.chkReview_CheckedChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(503, 8);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtStudentName
            // 
            this.txtStudentName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudentName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStudentName.Location = new System.Drawing.Point(293, 6);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(127, 23);
            this.txtStudentName.TabIndex = 2;
            // 
            // lbStudentName
            // 
            this.lbStudentName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStudentName.AutoSize = true;
            this.lbStudentName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStudentName.Location = new System.Drawing.Point(230, 10);
            this.lbStudentName.Name = "lbStudentName";
            this.lbStudentName.Size = new System.Drawing.Size(68, 17);
            this.lbStudentName.TabIndex = 8;
            this.lbStudentName.Text = "学生姓名：";
            // 
            // txtWorkName
            // 
            this.txtWorkName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWorkName.Location = new System.Drawing.Point(65, 6);
            this.txtWorkName.Name = "txtWorkName";
            this.txtWorkName.Size = new System.Drawing.Size(158, 23);
            this.txtWorkName.TabIndex = 1;
            // 
            // lbWorkName
            // 
            this.lbWorkName.AutoSize = true;
            this.lbWorkName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWorkName.Location = new System.Drawing.Point(4, 10);
            this.lbWorkName.Name = "lbWorkName";
            this.lbWorkName.Size = new System.Drawing.Size(68, 17);
            this.lbWorkName.TabIndex = 6;
            this.lbWorkName.Text = "作品名称：";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBatch,
            this.menuItemOutput});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(119, 48);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // menuItemBatch
            // 
            this.menuItemBatch.Name = "menuItemBatch";
            this.menuItemBatch.Size = new System.Drawing.Size(118, 22);
            this.menuItemBatch.Text = "批量批阅";
            this.menuItemBatch.Click += new System.EventHandler(this.menuItemBatch_Click);
            // 
            // menuItemOutput
            // 
            this.menuItemOutput.Name = "menuItemOutput";
            this.menuItemOutput.Size = new System.Drawing.Size(118, 22);
            this.menuItemOutput.Text = "导出作品";
            this.menuItemOutput.Click += new System.EventHandler(this.menuItemOutput_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            this.toolTip.OwnerDraw = true;
            this.toolTip.ShowAlways = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "导出学生作品数据";
            // 
            // ModifyWorkWindow
            // 
            this.AcceptButton = this.btnQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ModifyWorkWindow";
            this.Text = "学生作品管理";
            this.Title = "学生作品管理";
            this.Load += new System.EventHandler(this.ModifyWorkWindow_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.contextMenuStripListView.ResumeLayout(false);
            this.panelQuery.ResumeLayout(false);
            this.panelQuery.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Yaesoft.SFIT.Client.Controls.PanelEx panelTop;
        private Yaesoft.SFIT.Client.Controls.PanelEx panelBottom;
        private Yaesoft.SFIT.Client.Controls.SplitContainerEx splitContainer;
        private Yaesoft.SFIT.Client.Controls.PanelEx panelQuery;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.Label lbWorkName;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label lbStudentName;
        private System.Windows.Forms.TextBox txtWorkName;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.CheckBox chkReview;
        private System.Windows.Forms.CheckBox chkUpload;
        private System.Windows.Forms.CheckBox chkRelease;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ComboBox cbbView;
        private System.Windows.Forms.ToolStripMenuItem menuItemBatch;
        private System.Windows.Forms.ToolStripMenuItem menuItemOutput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox chkNoReview;
        private System.Windows.Forms.CheckBox chkNoUpload;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem menuItemBatchUpload;
        private System.Windows.Forms.ToolStripMenuItem menuItemAllDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemClear;
    }
}