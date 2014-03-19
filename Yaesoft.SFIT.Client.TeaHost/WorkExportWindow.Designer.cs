namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class WorkExportWindow
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.panelWork = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.Panel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.panelControl = new System.Windows.Forms.Panel();
            this.chkStudents = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panelBottom.SuspendLayout();
            this.panelWork.SuspendLayout();
            this.panel.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lbMessage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 440);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(621, 42);
            this.panelBottom.TabIndex = 0;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbMessage.Location = new System.Drawing.Point(7, 11);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(89, 17);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.Text = "准备导出数据...";
            // 
            // panelWork
            // 
            this.panelWork.Controls.Add(this.panel);
            this.panelWork.Controls.Add(this.panelControl);
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(0, 0);
            this.panelWork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(621, 440);
            this.panelWork.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.treeView);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(621, 397);
            this.panel.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Control;
            this.treeView.CheckBoxes = true;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(621, 397);
            this.treeView.TabIndex = 0;
            this.treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCheck);
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.chkStudents);
            this.panelControl.Controls.Add(this.btnExport);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(0, 397);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(621, 43);
            this.panelControl.TabIndex = 0;
            // 
            // chkStudents
            // 
            this.chkStudents.AutoSize = true;
            this.chkStudents.Location = new System.Drawing.Point(48, 10);
            this.chkStudents.Name = "chkStudents";
            this.chkStudents.Size = new System.Drawing.Size(75, 21);
            this.chkStudents.TabIndex = 1;
            this.chkStudents.Text = "显示学生";
            this.chkStudents.UseVisualStyleBackColor = true;
            this.chkStudents.CheckedChanged += new System.EventHandler(this.chkStudents_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(273, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "zip";
            this.saveFileDialog.Filter = "导出文件|*.zip";
            this.saveFileDialog.Title = "导出学生作品数据文件";
            // 
            // WorkExportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 482);
            this.Controls.Add(this.panelWork);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkExportWindow";
            this.Opacity = 0.9;
            this.Text = "导出作品数据";
            this.Title = "导出作品数据";
            this.Load += new System.EventHandler(this.WorkExportWindow_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelWork.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.CheckBox chkStudents;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}