//================================================================================
//  FileName: SyncPlugin.cs
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
    /// 同步插件。
    /// </summary>
    public class SyncPlugin : IPlugin
    {
        #region 成员变量，构造函数。
        PluginCfg cfg;
        UserInfo info;
        UCSyncSet ucSyncSet;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public SyncPlugin()
        {
        }
        #endregion

        #region IPlugin 成员
        /// <summary>
        /// 
        /// </summary>
        public IWindow Window
        {
            get { return this.ucSyncSet; }
        }
        /// <summary>
        /// 初始化插件
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
            this.ucSyncSet = new UCSyncSet(service, this.info);
            this.ucSyncSet.CrossPluginSendEvent += new CrossPluginHandler(delegate(object sender, CrossPluginEventArgs e)
            {
                this.OnCrossPluginSendEvent(e);
            });
            return this.ucSyncSet;
        }
        /// <summary>
        /// 
        /// </summary>
        public event CrossPluginHandler CrossPluginSendEvent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void OnCrossPluginSendEvent(CrossPluginEventArgs e)
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
            try
            {
                if ((e.TargetDock == this.cfg.Location) &&
                    (e.Args != null && e.Args.Length > 1))
                {
                    if (e.Args[0].ToString() == "syncdata" && this.ucSyncSet != null)
                    {
                        this.ucSyncSet.Enabled = bool.Parse(e.Args[1].ToString());
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