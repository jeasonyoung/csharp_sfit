//================================================================================
//  FileName: SystemSettingsWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/15
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
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 系统设置。
    /// </summary>
    public partial class SystemSettingsWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        PortSettings portSettings = null;
        MonitorUIColorSettings colorSettings = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public SystemSettingsWindow(ICoreService service)
            : base(service)
        {
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        private void SystemSettingsWindow_Load(object sender, EventArgs e)
        {
            this.portSettings = this.CoreService["portsettings"] as PortSettings;
            if (this.portSettings == null)
            {
                this.portSettings = NetPortSettingsMgr.DeSerializer();
            }

            this.colorSettings = this.CoreService["monitoruicolorsettings"] as MonitorUIColorSettings;
            if (this.colorSettings == null)
            {
                this.colorSettings = MonitorUIColorSettings.DeSerializer();
            }

            this.SetTextBoxValue(this.txtHostBroadcast, this.portSettings.HostBroadcast);
            this.SetTextBoxValue(this.txtBroadcastInterval, this.portSettings.BroadcastInterval);
            this.SetTextBoxValue(this.txtHostOrder, this.portSettings.HostOrder);
            this.SetTextBoxValue(this.txtClientCallback, this.portSettings.ClientCallback);
            this.SetTextBoxValue(this.txtFileUpTransfer, this.portSettings.FileUpTransfer);
            this.SetTextBoxValue(this.txtFileDownTransfer, this.portSettings.FileDownTransfer);
            this.SetTextBoxValue(this.txtMaxFileSize, this.portSettings.MaxFileSize);

            this.SetTextBoxColor(this.txtOnlineColor, this.colorSettings.OnlineColor);
            this.SetTextBoxColor(this.txtOfflineColor, this.colorSettings.OfflineColor);
            this.SetTextBoxColor(this.txtUploadColor, this.colorSettings.UploadColor);
            this.SetTextBoxColor(this.txtOfflineUploadColor, this.colorSettings.OfflineUploadColor);
            this.SetTextBoxColor(this.txtMoveColor, this.colorSettings.MoveColor);
            this.SetTextBoxColor(this.txtReviewColor, this.colorSettings.ReviewColor);
         }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SaveConfigData())
                {
                    this.OnMessageEvent(MessageType.PopupInfo, "已保存");
                }
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, x.Message);
            }
        }

        private void btnApp_Click(object sender, EventArgs e)
        {
            try
            {
                this.CoreService["portsettings"] = this.portSettings;
                this.CoreService["monitoruicolorsettings"] = this.colorSettings;
                this.OnMessageEvent(MessageType.PopupInfo, "已应用");
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.PopupWarn, x.Message);
            }
        }

        private void ChoiceColor(object sender, EventArgs e)
        {
            this.colorDialog.Color = ((TextBox)sender).BackColor;
            if (this.colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.SetTextBoxColor(((TextBox)sender), this.colorDialog.Color);
            }
        }
        #endregion

        #region 辅助函数。
        private bool SaveConfigData()
        {
            this.portSettings.HostBroadcast = this.GetTextBoxValue(this.txtHostBroadcast, this.portSettings.HostBroadcast);
            this.portSettings.BroadcastInterval = this.GetTextBoxValue(this.txtBroadcastInterval, this.portSettings.BroadcastInterval);
            this.portSettings.HostOrder = this.GetTextBoxValue(this.txtHostOrder, this.portSettings.HostOrder);
            this.portSettings.ClientCallback = this.GetTextBoxValue(this.txtClientCallback, this.portSettings.ClientCallback);
            this.portSettings.FileUpTransfer = this.GetTextBoxValue(this.txtFileUpTransfer, this.portSettings.FileUpTransfer);
            this.portSettings.FileDownTransfer = this.GetTextBoxValue(this.txtFileDownTransfer, this.portSettings.FileDownTransfer);
            this.portSettings.MaxFileSize = this.GetTextBoxValue(this.txtMaxFileSize, this.portSettings.MaxFileSize);
            NetPortSettingsMgr.Serializer(this.portSettings);
                        
            this.colorSettings.OnlineColor = this.GetTextBoxColor(this.txtOnlineColor);
            this.colorSettings.OfflineColor = this.GetTextBoxColor(this.txtOfflineColor);
            this.colorSettings.UploadColor = this.GetTextBoxColor(this.txtUploadColor);
            this.colorSettings.OfflineUploadColor = this.GetTextBoxColor(this.txtOfflineUploadColor);
            this.colorSettings.MoveColor = this.GetTextBoxColor(this.txtMoveColor);
            this.colorSettings.ReviewColor = this.GetTextBoxColor(this.txtReviewColor);
            MonitorUIColorSettings.Serializer(this.colorSettings);

            return true;
        }

        private void SetTextBoxColor(TextBox txt, Color color)
        {
            if (txt != null)
            {
                if (color.A == 0)
                    color = Color.White;
                txt.BackColor = color;
                txt.ForeColor = Color.FromArgb((byte)(~color.R), (byte)(~color.G), (byte)(~color.B));
                txt.Text = string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
            }
        }
        private Color GetTextBoxColor(TextBox txt)
        {
            Color c = txt.BackColor;
            if (c == Color.White)
                return Color.Transparent;
            return c;
        }
        private void SetTextBoxValue(TextBox txt, int value)
        {
            if (txt != null)
            {
                txt.TextAlign = HorizontalAlignment.Right;
                txt.Text = string.Format("{0}", value);
            }
        }
        private int GetTextBoxValue(TextBox txt, int defValue)
        {
            string strValue = txt.Text;
            if (Regex.IsMatch(strValue, @"^\d+$"))
                return int.Parse(strValue);
            return defValue;
        }
        #endregion
    }
}
