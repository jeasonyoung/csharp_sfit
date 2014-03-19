namespace Yaesoft.SFIT.ClientStudent
{
    partial class StudentMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentMainWindow));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelPlugins = new System.Windows.Forms.Panel();
            this.panelWork = new System.Windows.Forms.Panel();
            this.groupBoxWork = new System.Windows.Forms.GroupBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openFiletoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFoldertoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BrowserFilesAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrowserFoldersAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl = new System.Windows.Forms.Panel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.panelControlLeft = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.groupBoxTop = new System.Windows.Forms.GroupBox();
            this.lbUserinfo = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panelBottom.SuspendLayout();
            this.panelWork.SuspendLayout();
            this.groupBoxWork.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.panelControlLeft.SuspendLayout();
            this.groupBoxTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.panelPlugins);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 271);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(353, 58);
            this.panelBottom.TabIndex = 1;
            // 
            // panelPlugins
            // 
            this.panelPlugins.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelPlugins.Location = new System.Drawing.Point(18, 9);
            this.panelPlugins.Name = "panelPlugins";
            this.panelPlugins.Size = new System.Drawing.Size(316, 36);
            this.panelPlugins.TabIndex = 0;
            // 
            // panelWork
            // 
            this.panelWork.BackColor = System.Drawing.Color.Transparent;
            this.panelWork.Controls.Add(this.groupBoxWork);
            this.panelWork.Controls.Add(this.groupBoxTop);
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(0, 0);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(353, 271);
            this.panelWork.TabIndex = 2;
            // 
            // groupBoxWork
            // 
            this.groupBoxWork.Controls.Add(this.listView);
            this.groupBoxWork.Controls.Add(this.panelControl);
            this.groupBoxWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxWork.Location = new System.Drawing.Point(0, 84);
            this.groupBoxWork.Name = "groupBoxWork";
            this.groupBoxWork.Size = new System.Drawing.Size(353, 187);
            this.groupBoxWork.TabIndex = 1;
            this.groupBoxWork.TabStop = false;
            // 
            // listView
            // 
            this.listView.AllowDrop = true;
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.Location = new System.Drawing.Point(15, 10);
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(319, 133);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView_ItemChecked);
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.listView.DragLeave += new System.EventHandler(this.listView_DragLeave);
            this.listView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.listView.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_DragOver);
            // 
            // columnHeader
            // 
            this.columnHeader.Width = 380;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.toolStripSeparator3,
            this.openFiletoolStripMenuItem,
            this.openFoldertoolStripMenuItem,
            this.toolStripSeparator1,
            this.selectRemoveToolStripMenuItem,
            this.removeAllToolStripMenuItem,
            this.toolStripSeparator2,
            this.BrowserFilesAddToolStripMenuItem,
            this.BrowserFoldersAddToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(167, 198);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.selectAllToolStripMenuItem.Text = "全选";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.invertToolStripMenuItem.Text = "反选";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.InvertToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(163, 6);
            // 
            // openFiletoolStripMenuItem
            // 
            this.openFiletoolStripMenuItem.Name = "openFiletoolStripMenuItem";
            this.openFiletoolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.openFiletoolStripMenuItem.Text = "打开当前文件";
            this.openFiletoolStripMenuItem.Click += new System.EventHandler(this.openFiletoolStripMenuItem_Click);
            // 
            // openFoldertoolStripMenuItem
            // 
            this.openFoldertoolStripMenuItem.Name = "openFoldertoolStripMenuItem";
            this.openFoldertoolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.openFoldertoolStripMenuItem.Text = "打开当前文件目录";
            this.openFoldertoolStripMenuItem.Click += new System.EventHandler(this.openFoldertoolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // selectRemoveToolStripMenuItem
            // 
            this.selectRemoveToolStripMenuItem.Name = "selectRemoveToolStripMenuItem";
            this.selectRemoveToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.selectRemoveToolStripMenuItem.Text = "选中移除";
            this.selectRemoveToolStripMenuItem.Click += new System.EventHandler(this.SelectRemoveToolStripMenuItem_Click);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.removeAllToolStripMenuItem.Text = "全部移除";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.RemoveAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // BrowserFilesAddToolStripMenuItem
            // 
            this.BrowserFilesAddToolStripMenuItem.Name = "BrowserFilesAddToolStripMenuItem";
            this.BrowserFilesAddToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.BrowserFilesAddToolStripMenuItem.Text = "浏览文件添加";
            this.BrowserFilesAddToolStripMenuItem.Click += new System.EventHandler(this.BrowserFilesAddToolStripMenuItem_Click);
            // 
            // BrowserFoldersAddToolStripMenuItem
            // 
            this.BrowserFoldersAddToolStripMenuItem.Name = "BrowserFoldersAddToolStripMenuItem";
            this.BrowserFoldersAddToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.BrowserFoldersAddToolStripMenuItem.Text = "浏览目录添加";
            this.BrowserFoldersAddToolStripMenuItem.Click += new System.EventHandler(this.BrowserFoldersAddToolStripMenuItem_Click);
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.btnUpload);
            this.panelControl.Controls.Add(this.panelControlLeft);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(3, 149);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(347, 35);
            this.panelControl.TabIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpload.Location = new System.Drawing.Point(253, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(72, 27);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "上传作品";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // panelControlLeft
            // 
            this.panelControlLeft.Controls.Add(this.lbMessage);
            this.panelControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControlLeft.Location = new System.Drawing.Point(0, 0);
            this.panelControlLeft.Name = "panelControlLeft";
            this.panelControlLeft.Size = new System.Drawing.Size(244, 35);
            this.panelControlLeft.TabIndex = 2;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbMessage.Location = new System.Drawing.Point(16, 13);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(69, 17);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.Text = "[Message]";
            // 
            // groupBoxTop
            // 
            this.groupBoxTop.Controls.Add(this.lbUserinfo);
            this.groupBoxTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxTop.ForeColor = System.Drawing.Color.Maroon;
            this.groupBoxTop.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTop.Name = "groupBoxTop";
            this.groupBoxTop.Size = new System.Drawing.Size(353, 84);
            this.groupBoxTop.TabIndex = 0;
            this.groupBoxTop.TabStop = false;
            this.groupBoxTop.Text = "学生信息";
            // 
            // lbUserinfo
            // 
            this.lbUserinfo.AutoSize = true;
            this.lbUserinfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserinfo.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbUserinfo.Location = new System.Drawing.Point(22, 13);
            this.lbUserinfo.Name = "lbUserinfo";
            this.lbUserinfo.Size = new System.Drawing.Size(65, 17);
            this.lbUserinfo.TabIndex = 0;
            this.lbUserinfo.Text = "[Userinfo]";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "学生机客户端";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "浏览上传的学生作业";
            // 
            // StudentMainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(353, 329);
            this.Controls.Add(this.panelWork);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StudentMainWindow";
            this.Text = "学生机客户端";
            this.Title = "学生机客户端";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.StudentMainWindow_DragDrop);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentMainWindow_FormClosed);
            this.Load += new System.EventHandler(this.StudentMainWindow_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.StudentMainWindow_DragEnter);
            this.panelBottom.ResumeLayout(false);
            this.panelWork.ResumeLayout(false);
            this.groupBoxWork.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelControlLeft.ResumeLayout(false);
            this.panelControlLeft.PerformLayout();
            this.groupBoxTop.ResumeLayout(false);
            this.groupBoxTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.GroupBox groupBoxTop;
        private System.Windows.Forms.GroupBox groupBoxWork;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Panel panelControlLeft;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.Label lbUserinfo;
        private System.Windows.Forms.Panel panelPlugins;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem selectRemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem BrowserFilesAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrowserFoldersAddToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem openFiletoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFoldertoolStripMenuItem;

    }
}