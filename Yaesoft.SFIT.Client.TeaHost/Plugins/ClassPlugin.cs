//================================================================================
//  FileName: ClassPlugin.cs
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

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Plugins;
namespace Yaesoft.SFIT.Client.TeaHost.Plugins
{
    /// <summary>
    /// 课程设置插件。
    /// </summary>
    public class ClassPlugin : IPlugin
    {
        #region 成员变量，构造函数。
        PluginCfg cfg = null;
        UserInfo info = null;
        UClassSettngs userControl = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ClassPlugin()
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
            this.info = info;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public IWindow LoadMain(ICoreService service)
        {
            this.userControl = new UClassSettngs(service);
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
                handler(this, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void ReceiveCrossPluginData(object source, CrossPluginEventArgs e)
        {
            if (e != null && e.TargetDock == this.cfg.Location)
            {
                object[] args = e.Args;
                if (args != null && args.Length > 0)
                {
                    switch (args[0].ToString())
                    {
                        case "reload":
                            bool result = false;
                            if (Boolean.TryParse(args[1].ToString(), out result))
                            {
                                if (result)
                                {
                                    this.userControl.LoadData();
                                }
                            }
                            break;
                    }
                }
            }
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