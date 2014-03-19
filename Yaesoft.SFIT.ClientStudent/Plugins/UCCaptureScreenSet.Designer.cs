namespace Yaesoft.SFIT.ClientStudent.Plugins
{
    partial class UCCaptureScreenSet
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
            this.SuspendLayout();
            // 
            // UCCaptureScreenSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yaesoft.SFIT.ClientStudent.Properties.Resources.CaptureScreen;
            this.Name = "UCCaptureScreenSet";
            this.Size = new System.Drawing.Size(80, 27);
            this.Load += new System.EventHandler(this.UCCaptureScreenSet_Load);
            this.DoubleClick += new System.EventHandler(this.UCCaptureScreenSet_DoubleClick);
            this.MouseLeave += new System.EventHandler(this.UCCaptureScreenSet_MouseLeave);
            this.Click += new System.EventHandler(this.UCCaptureScreenSet_Click);
            this.EnabledChanged += new System.EventHandler(this.UCCaptureScreenSet_EnabledChanged);
            this.MouseEnter += new System.EventHandler(this.UCCaptureScreenSet_MouseEnter);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
