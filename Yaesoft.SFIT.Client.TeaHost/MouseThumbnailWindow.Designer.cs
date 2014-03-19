namespace Yaesoft.SFIT.Client.TeaHost
{
    partial class MouseThumbnailWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseThumbnailWindow));
            this.SuspendLayout();
            // 
            // MouseThumbnailWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MouseThumbnailWindow";
            this.Opacity = 0.98;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Title = "鼠标缩略图";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MouseThumbnailWindow_MouseDoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseThumbnailWindow_MouseClick);
            this.Load += new System.EventHandler(this.MouseThumbnailWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

    }
}