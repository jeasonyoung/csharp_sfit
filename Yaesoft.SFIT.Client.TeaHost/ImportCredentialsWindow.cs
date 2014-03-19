//================================================================================
//  FileName: ImportCredentialsWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/29
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Yaesoft.SFIT.Client.Forms;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 导入密钥。
    /// </summary>
    public partial class ImportCredentialsWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        bool isPluginLoad = false;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ImportCredentialsWindow(ICoreService service)
            : base(service)
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="isPluginLoad"></param>
        public ImportCredentialsWindow(ICoreService service, bool isPluginLoad)
            : this(service)
        {
            this.isPluginLoad = isPluginLoad;
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportCredentialsWindow_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.OnToolTipEvent(this.btnClose, "关闭系统");
                         
            this.openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.openFileDialog.Filter = "Bin files (*.bin)|*.bin";

            this.OnMessageEvent(MessageType.Normal, string.Empty);
            this.btnOK.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = this.txtPath.Text = this.openFileDialog.FileName;
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    this.OnMessageEvent(MessageType.Normal, string.Format("密钥文件：{0}", Path.GetFileName(path)));
                    this.btnOK.Enabled = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.OnClearErrorEvent();
                string path = this.txtPath.Text;
                if (!File.Exists(path))
                {
                    string err = "选择的密钥文件不存在！";
                    this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, err);
                    this.OnSetErrorEvent(this.btnBrowse, err);
                    return;
                }
                CredentialsCollection collection = CredentialsFactory.DeSerialize(path);
                if (collection == null || collection.Count == 0)
                {
                    string err = "密钥文件不符合格式或密钥文件为空！";
                    this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, err);
                    this.OnSetErrorEvent(this.btnBrowse, err);
                    return;
                }
                if (this.isPluginLoad)
                {
                    this.Hide();
                    new SelectCredentialsWindow(this.CoreService, collection).ShowDialog();
                }
                else
                {
                    this.CoreService.AddForm(new SelectCredentialsWindow(this.CoreService, collection));
                    this.CoreService.ForceQuit = true;
                }
                this.btnClose_Click(sender, e);
            }
            catch (Exception)
            {
                this.OnMessageEvent(MessageType.PopupWarn, "密钥文件不符合格式！");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        protected override void OnMessageEvent(MessageType type, string content)
        {
            if ((type & MessageType.Normal) == MessageType.Normal)
                this.lbMessage.Text = content;
            base.OnMessageEvent(type, content);
        }
        #endregion
    }
}
