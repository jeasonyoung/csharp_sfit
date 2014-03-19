//================================================================================
//  FileName: MonitorPlugin.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/31
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
using System.Text;
using System.Threading;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
using Yaesoft.SFIT.Client.TeaHost.Net;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Plugins
{
    /// <summary>
    /// 监控学生上课。
    /// </summary>
    public class MonitorPlugin : IPlugin
    {
        #region 成员变量，构造函数。
        private PluginCfg cfg = null;
        private UCMonitor userControl = null;
        private ICoreService service = null;
        private HostNetService hostNetService = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public MonitorPlugin()
        {
        }
        #endregion

        #region IPlugin 成员
        /// <summary>
        /// 
        /// </summary>
        public IWindow Window
        {
            get { return this.userControl; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        /// <param name="info"></param>
        public void Init(PluginCfg cfg, UserInfo info)
        {
            this.cfg = cfg;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public IWindow LoadMain(ICoreService service)
        {
            this.userControl = new UCMonitor(this.service = service);
            this.userControl.CrossPluginSendEvent += new CrossPluginHandler(delegate(object sender, CrossPluginEventArgs e)
            {
                this.OnCrossPluginSend(e);
            });
            return this.userControl;
        }
        /// <summary>
        /// 
        /// </summary>
        public event CrossPluginHandler CrossPluginSendEvent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void OnCrossPluginSend(CrossPluginEventArgs e)
        {
            CrossPluginHandler handler = this.CrossPluginSendEvent;
            if (handler != null && e != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void ReceiveCrossPluginData(object source, CrossPluginEventArgs e)
        {
            if (e.TargetDock == this.cfg.Location && this.userControl != null)
            {
                object[] args = e.Args;
                if (args != null && args.Length > 0)
                {
                    bool start = false;
                    if ((args[0].ToString() == "load") && (Boolean.TryParse(args[1].ToString(), out start)))
                    {
                        StartClassInfo sci = args[2] as StartClassInfo;
                        if (sci != null && start)
                        {
                            //开始上课。
                            if (sci.ClassInfo != null)
                            {
                                (this.hostNetService = this.initHostNetService(sci)).Start();
                                this.userControl.GradeID = sci.GradeID;
                                this.userControl.ClassID = sci.ClassInfo.ClassID;
                                this.userControl.CatalogID = sci.CatalogInfo.CatalogID;
                                this.userControl.Start(Program.STUDENTS);
                            }
                        }
                        else
                        {
                            //结束上课。
                            this.disposeHostNetService();
                        }
                    }
                }
            }
        }
        #endregion

        #region  辅助函数。
        private HostNetService initHostNetService(StartClassInfo sci)
        {
            this.service["startclassinfo"] = sci;
            HostNetService hostNetService = HostNetService.Instance(this.service);
            if (hostNetService != null)
            {
                hostNetService.RaiseChanged += this.onRaiseChanged;
                hostNetService.UpdateControls += this.onUpdateControls;
            }
            return hostNetService;
        }
        private void disposeHostNetService()
        {
            if (this.hostNetService != null)
            {
                this.hostNetService.Close();
                this.hostNetService.RaiseChanged -= this.onRaiseChanged;
                this.hostNetService.UpdateControls -= this.onUpdateControls;
            }
            if (this.userControl != null) this.userControl.Close();
        }
        private void onRaiseChanged(string content)
        {
            if (this.userControl != null) this.userControl.RaiseChanged(content);
        }
        private void onUpdateControls(StudentEx sender)
        {
            if (this.userControl != null) this.userControl.UpdateStudentControl(sender);
        }
        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            
        }
        #endregion
    }
}