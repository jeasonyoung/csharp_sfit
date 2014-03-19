//================================================================================
//  FileName: NetPlugin.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/27
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
    /// 网络设置插件。
    /// </summary>
    public class NetPlugin : IPlugin
    {
        #region 成员变量，构造函数。
        UCNetPluginSet userControl = null;
        PluginCfg cfg = null;
        /// <summary>
        /// 构造。
        /// </summary>
        public NetPlugin()
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
            this.userControl = new UCNetPluginSet(service);
            return this.userControl;
        }
        /// <summary>
        /// 
        /// </summary>
        public event CrossPluginHandler CrossPluginSendEvent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void ReceiveCrossPluginData(object source, CrossPluginEventArgs e)
        {
            try
            {
                if ((e.TargetDock == this.cfg.Location) &&
                    (e.Args != null && e.Args.Length > 1))
                {
                    if (e.Args[0].ToString() == "syncdata" && this.userControl != null)
                    {
                        this.userControl.Enabled = bool.Parse(e.Args[1].ToString());
                    }
                }
            }
            catch (Exception) { }
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