//================================================================================
//  FileName: InitializeWindow.cs
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
using System.Diagnostics;
using Yaesoft.SFIT;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost
{
    /// <summary>
    /// 初始化界面。
    /// </summary>
    public partial class InitializeWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        int wait = 0, len = 0;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public InitializeWindow(ICoreService coreService)
            : base(coreService)
        {
            InitializeComponent(); 
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeWindow_Load(object sender, EventArgs e)
        {
            this.CoreService.ForceQuit = false;
            this.len = this.Size.Width;
            this.OnMessageEvent(MessageType.Normal, new string('=', this.len));
            this.timer.Interval = 2000;
            this.timer.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.wait == 0)
                this.timer.Interval = 80;
            this.OnMessageEvent(MessageType.Normal, new string('=', this.wait));
            this.wait++;
            if (this.lbMessage.Width > this.len)
            {
                this.timer.Stop();
                InitialService initService = this.CoreService as InitialService;
                if (initService != null)
                {
                    initService.CustomLoadEvent += new EventHandler(delegate(object o, EventArgs s)
                    {
                        this.LoadNetPortSettingsCfg(o as InitialService);
                        this.LoadMonitorUIColorSettingsCfg(o as InitialService);
                        this.LoadAutoUpdateProgram(o as InitialService);
                    });
                    initService.LoadingInitial(this, this.LoadMainForm);
                }
            }
        }
        /// <summary>
        /// 加载端口设置文件。
        /// </summary>
        protected void LoadNetPortSettingsCfg(InitialService initService)
        {
            if (initService != null)
            {
                initService.RaiseChanged("开始加载端口设置数据...");
                PortSettings ps = NetPortSettingsMgr.DeSerializer();
                if (ps != null)
                {
                    initService.Add("portsettings", ps);
                    initService.RaiseChanged("加载端口设置数据完成...");
                }
                else
                {
                    initService.RaiseChanged("加载端口设置数据失败");
                }
            }
        }
        /// <summary>
        /// 加载监控界面颜色配置文件。
        /// </summary>
        /// <param name="initService"></param>
        protected void LoadMonitorUIColorSettingsCfg(InitialService initService)
        {
            if (initService != null)
            {
                initService.RaiseChanged("开始加载监控界面颜色配置数据...");
                MonitorUIColorSettings settings = MonitorUIColorSettings.DeSerializer();
                if (settings != null)
                {
                    initService.Add("monitoruicolorsettings", settings);
                    initService.RaiseChanged("加载监控界面颜色配置数据完成...");
                }
                else
                {
                    initService.RaiseChanged("加载监控界面颜色配置数据失败");
                }
            }
        }
        /// <summary>
        /// 加载自动更新程序。
        /// </summary>
        /// <param name="initService"></param>
        protected void LoadAutoUpdateProgram(InitialService initService)
        {
            if (initService != null)
            {
                CredentialsCollection cred = CredentialsFactory.DeSerialize(FolderStructure.CredentialsFile);
                if (cred != null && cred.Count > 0)
                {
                    this.CoreService.Add("credentials", cred[0]);
                    try
                    {
                        string url = cred[0].ServiceURL;
                        if (!string.IsNullOrEmpty(url))
                        {
                            initService.RaiseChanged("检测自动更新...");
                            string[] urls = url.Split('/');
                            url = url.Replace(urls[urls.Length - 1], "AutoUpdate.ashx");
                            Process.Start("Yaesoft.SFIT.Client.AutoUpdate.exe", url);
                        }
                    }
                    catch (Exception x)
                    {
                        initService.RaiseChanged("自动更新异常：" + x.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 加载主界面。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadMainForm(object sender, EventArgs e)
        {
            Credentials credentials = this.CoreService["credentials"] as Credentials;
            //CredentialsCollection creti = CredentialsFactory.DeSerialize(FolderStructure.CredentialsFile);
            if (credentials == null)
            {
                //检测访问密钥文件。
                this.CoreService.AddForm(new ImportCredentialsWindow(this.CoreService));
            }
            else
            {
                //登录界面。
                //this.CoreService.Add("credentials", creti[0]);
                this.CoreService.AddForm(new LoginWindow(this.CoreService));
            }
            this.CoreService.ForceQuit = true;
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
            {
                this.ThreadSafeMethod(this.lbMessage, new MethodInvoker(delegate()
                {
                    this.lbMessage.Text = content;
                    this.OnToolTipEvent(this.lbMessage, content);
                }));
            }
            base.OnMessageEvent(type, content);
        }
        #endregion
    }
}