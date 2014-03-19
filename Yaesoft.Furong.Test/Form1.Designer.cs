namespace Yaesoft.Furong.Test
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_Unit = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_loadUnit = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_classes = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLoadClasses = new System.Windows.Forms.Button();
            this.txtSchoolName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_students = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLoadStudents = new System.Windows.Forms.Button();
            this.txtJoinYear = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnPost = new System.Windows.Forms.Button();
            this.txtCallbackData = new System.Windows.Forms.TextBox();
            this.txtPostData = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPostUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_Unit);
            this.tabPage1.Controls.Add(this.panel1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_Unit
            // 
            resources.ApplyResources(this.txt_Unit, "txt_Unit");
            this.txt_Unit.Name = "txt_Unit";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_loadUnit);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btn_loadUnit
            // 
            resources.ApplyResources(this.btn_loadUnit, "btn_loadUnit");
            this.btn_loadUnit.Name = "btn_loadUnit";
            this.btn_loadUnit.UseVisualStyleBackColor = true;
            this.btn_loadUnit.Click += new System.EventHandler(this.btn_loadUnit_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_classes);
            this.tabPage2.Controls.Add(this.panel2);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_classes
            // 
            resources.ApplyResources(this.txt_classes, "txt_classes");
            this.txt_classes.Name = "txt_classes";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLoadClasses);
            this.panel2.Controls.Add(this.txtSchoolName);
            this.panel2.Controls.Add(this.label1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnLoadClasses
            // 
            resources.ApplyResources(this.btnLoadClasses, "btnLoadClasses");
            this.btnLoadClasses.Name = "btnLoadClasses";
            this.btnLoadClasses.UseVisualStyleBackColor = true;
            this.btnLoadClasses.Click += new System.EventHandler(this.btnClasses_Click);
            // 
            // txtSchoolName
            // 
            resources.ApplyResources(this.txtSchoolName, "txtSchoolName");
            this.txtSchoolName.Name = "txtSchoolName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_students);
            this.tabPage3.Controls.Add(this.panel3);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_students
            // 
            resources.ApplyResources(this.txt_students, "txt_students");
            this.txt_students.Name = "txt_students";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLoadStudents);
            this.panel3.Controls.Add(this.txtJoinYear);
            this.panel3.Controls.Add(this.txtClassName);
            this.panel3.Controls.Add(this.txtUnitName);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btnLoadStudents
            // 
            resources.ApplyResources(this.btnLoadStudents, "btnLoadStudents");
            this.btnLoadStudents.Name = "btnLoadStudents";
            this.btnLoadStudents.UseVisualStyleBackColor = true;
            this.btnLoadStudents.Click += new System.EventHandler(this.btnLoadStudents_Click);
            // 
            // txtJoinYear
            // 
            resources.ApplyResources(this.txtJoinYear, "txtJoinYear");
            this.txtJoinYear.Name = "txtJoinYear";
            // 
            // txtClassName
            // 
            resources.ApplyResources(this.txtClassName, "txtClassName");
            this.txtClassName.Name = "txtClassName";
            // 
            // txtUnitName
            // 
            resources.ApplyResources(this.txtUnitName, "txtUnitName");
            this.txtUnitName.Name = "txtUnitName";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnPost);
            this.tabPage4.Controls.Add(this.txtCallbackData);
            this.tabPage4.Controls.Add(this.txtPostData);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.txtPostUrl);
            this.tabPage4.Controls.Add(this.label5);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnPost
            // 
            resources.ApplyResources(this.btnPost, "btnPost");
            this.btnPost.Name = "btnPost";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // txtCallbackData
            // 
            resources.ApplyResources(this.txtCallbackData, "txtCallbackData");
            this.txtCallbackData.Name = "txtCallbackData";
            // 
            // txtPostData
            // 
            resources.ApplyResources(this.txtPostData, "txtPostData");
            this.txtPostData.Name = "txtPostData";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtPostUrl
            // 
            resources.ApplyResources(this.txtPostUrl, "txtPostUrl");
            this.txtPostUrl.Name = "txtPostUrl";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_loadUnit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_Unit;
        private System.Windows.Forms.TextBox txt_classes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSchoolName;
        private System.Windows.Forms.Button btnLoadClasses;
        private System.Windows.Forms.TextBox txt_students;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJoinYear;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Button btnLoadStudents;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtPostUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPostData;
        private System.Windows.Forms.TextBox txtCallbackData;
        private System.Windows.Forms.Button btnPost;
    }
}

