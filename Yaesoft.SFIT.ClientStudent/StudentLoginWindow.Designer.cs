namespace Yaesoft.SFIT.ClientStudent
{
    partial class StudentLoginWindow
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
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxWork = new System.Windows.Forms.GroupBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.groupBoxWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Yaesoft.SFIT.ClientStudent.Properties.Resources.btnClose;
            this.btnClose.Location = new System.Drawing.Point(353, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBoxWork
            // 
            this.groupBoxWork.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxWork.Controls.Add(this.lbMessage);
            this.groupBoxWork.Location = new System.Drawing.Point(24, 133);
            this.groupBoxWork.Name = "groupBoxWork";
            this.groupBoxWork.Size = new System.Drawing.Size(382, 233);
            this.groupBoxWork.TabIndex = 1;
            this.groupBoxWork.TabStop = false;
            this.groupBoxWork.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBoxWork_Paint);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.ForeColor = System.Drawing.Color.BlueViolet;
            this.lbMessage.Location = new System.Drawing.Point(171, 106);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(69, 17);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.Text = "[Message]";
            // 
            // StudentLoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yaesoft.SFIT.ClientStudent.Properties.Resources.Login;
            this.ClientSize = new System.Drawing.Size(430, 400);
            this.Controls.Add(this.groupBoxWork);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentLoginWindow";
            this.Text = "学生登录";
            this.Title = "学生登录";
            this.Load += new System.EventHandler(this.StudentLoginWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentLoginWindow_FormClosing);
            this.groupBoxWork.ResumeLayout(false);
            this.groupBoxWork.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxWork;
        private System.Windows.Forms.Label lbMessage;
    }
}