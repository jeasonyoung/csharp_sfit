//================================================================================
//  FileName: LoadingPluginService.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.Forms;
namespace Yaesoft.SFIT.Client.Plugins
{

    /// <summary>
    /// 插件加载服务。
    /// </summary>
    public class LoadingPluginService : IDisposable
    {
        #region 成员变量，构造函数。
        IPluginHost host = null;
        Hashtable pluginHotKeys = null;
        HotkeysFilter hotkeysFilter = null;
        BootstrapPlugins bootstrapPlugins;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="host"></param>
        public LoadingPluginService(ICoreService service, IPluginHost host)
        {
            this.host = host;
            this.pluginHotKeys = Hashtable.Synchronized(new Hashtable());
            this.bootstrapPlugins = new BootstrapPlugins(service);
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 加载当前主程序插件。
        /// </summary>
        /// <param name="cfgs"></param>
        public void Load(PluginCfgs cfgs)
        {
            if (cfgs != null && cfgs.Count > 0)
            {
                foreach (PluginCfg cfg in cfgs)
                {
                    this.LoadPlugin(cfg);
                }
                if (this.host != null)
                {
                    this.bootstrapPlugins.Deploy(this.host);
                    Form f = this.host as Form;
                    if (f != null && this.pluginHotKeys.Count > 0)
                    {
                        this.hotkeysFilter = new HotkeysFilter(f.Handle);
                        f.FormClosing += new FormClosingEventHandler(delegate(object sender, FormClosingEventArgs e)
                        {
                            this.hotkeysFilter.UnregisterHotKey();
                        });

                        string[] hotKeys = new string[this.pluginHotKeys.Keys.Count];
                        this.pluginHotKeys.Keys.CopyTo(hotKeys, 0);
                        this.hotkeysFilter.RegisterHotkey(hotKeys);

                        this.hotkeysFilter.Hotkey += new HotkeyEventHandler(delegate(string hotKey)
                        {
                            IPlugin p = this.pluginHotKeys[hotKey] as IPlugin;
                            if (p != null && p.Window != null)
                            {
                                IHotkeys hot = p.Window as IHotkeys;
                                if (hot != null)
                                {
                                    hot.ProcessHotkey(hotKey);
                                }
                            }
                        });
                    }
                }
            }
        }
        /// <summary>
        /// 跨插件发送数据。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void SendCrossPluginData(object source, CrossPluginEventArgs e)
        {
            if (this.bootstrapPlugins != null && e != null)
            {
                if (source == null)
                {
                    source = this;
                }
                this.bootstrapPlugins.SendCrossPluginData(source, e);
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 加载插件。
        /// </summary>
        /// <param name="cfg"></param>
        protected void LoadPlugin(PluginCfg cfg)
        {
            try
            {
                if (cfg != null && !string.IsNullOrEmpty(cfg.Assembly))
                {
                    IPlugin plugin = UtilTools.Create(cfg.Assembly) as IPlugin;
                    if (plugin != null)
                    {
                        this.bootstrapPlugins.Add(cfg.Location, cfg, plugin);
                        string hotKey = string.Empty;
                        if (!string.IsNullOrEmpty(hotKey = cfg.Hotkeys) && (!this.pluginHotKeys.ContainsKey(hotKey)))
                        {
                            this.pluginHotKeys.Add(hotKey, plugin);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                UtilTools.OnExceptionRecord(e, this.GetType());
            }
        }
        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 释放资源。
        /// </summary>
        public void Dispose()
        {
            this.bootstrapPlugins.Dispose();
        }
        #endregion
    }
}