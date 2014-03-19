//================================================================================
//  FileName: BootstrapPlugins.cs
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
using System.Windows.Forms;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.Forms;
namespace Yaesoft.SFIT.Client.Plugins
{
    /// <summary>
    /// 插件装载器。
    /// </summary>
    internal class BootstrapPlugins : IDisposable
    {
        #region 成员变量，构造函数。
        ICoreService service;
        PluginInfoCollection collection;
        CrossPluginsHandler crossPluginsHandler;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="info"></param>
        public BootstrapPlugins(ICoreService service)
        {
            this.collection = new PluginInfoCollection();
            this.crossPluginsHandler = new CrossPluginsHandler();
            this.service = service;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取停靠位置数量。
        /// </summary>
        public int Count
        {
            get { return this.collection.Count; }
        }
        #endregion

        /// <summary>
        /// 添加。
        /// </summary>
        /// <param name="location"></param>
        /// <param name="cfg"></param>
        /// <param name="plug"></param>
        public void Add(DockStyle location, PluginCfg cfg, IPlugin plug)
        {
            if (cfg != null && plug != null)
            {
                this.collection.Add(location, new PluginPair(cfg, plug));
            }
        }

        /// <summary>
        /// 部署插件。
        /// </summary>
        /// <param name="host"></param>
        public void Deploy(IPluginHost host)
        {
            if (host != null)
            {
                this.Deploy(host, DockStyle.Top);
                this.Deploy(host, DockStyle.Left);
                this.Deploy(host, DockStyle.Right);
                this.Deploy(host, DockStyle.Bottom);
                this.Deploy(host, DockStyle.Fill);
                this.Deploy(host, DockStyle.None);
            }
        }
        /// <summary>
        ///  部署插件。
        /// </summary>
        /// <param name="host"></param>
        /// <param name="location"></param>
        protected void Deploy(IPluginHost host, DockStyle location)
        {
            if (host == null)
            {
                return;
            }
            UserInfo userinfo = this.service["userinfo"] as UserInfo;
            PluginPair[] pairs = this.collection.GetPairs(location);
            int len = 0;
            if (userinfo != null && pairs != null && (len = pairs.Length) > 0)
            {
                for (int i = 0; i < len; i++)
                {
                    try
                    {
                        PluginCfg cfg = pairs[i].PluginCfg;
                        IPlugin plug = pairs[i].Plugin;

                        if (cfg != null && plug != null)
                        {
                            plug.CrossPluginSendEvent += this.SendCrossPluginData;
                            plug.Init(cfg, userinfo);
                            IWindow window = plug.LoadMain(this.service);
                            if (window != null)
                            {
                                this.crossPluginsHandler.Add(location, plug);
                                host.AddPlugin(location, window);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        UtilTools.OnExceptionRecord(e, pairs[i].Plugin == null ? this.GetType() : pairs[i].Plugin.GetType());
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
            if (e != null)
                this.crossPluginsHandler.SendCross(source, e);
        }

        #region IDisposable 成员

        public void Dispose()
        {
            this.collection.Dispose();
            this.crossPluginsHandler.Dispose();
        }

        #endregion

        #region 内置类。
        class PluginPair
        {
            #region 成员变量，构造函数。
            PluginCfg cfg = null;
            IPlugin plug = null;
            /// <summary>
            /// 构造函数。
            /// </summary>
            /// <param name="cfg"></param>
            /// <param name="plug"></param>
            public PluginPair(PluginCfg cfg, IPlugin plug)
            {
                this.cfg = cfg;
                this.plug = plug;
            }
            #endregion
            /// <summary>
            /// 获取或设置插件配置。
            /// </summary>
            public PluginCfg PluginCfg
            {
                get { return this.cfg; }
            }
            /// <summary>
            /// 获取或设置插件对象。
            /// </summary>
            public IPlugin Plugin
            {
                get { return this.plug; }
            }
        }
        /// <summary>
        /// 插件信息集合。
        /// </summary>
        class PluginInfoCollection : IComparer<PluginPair>, IDisposable
        {
            #region 成员变量，构造函数。
            Dictionary<DockStyle, List<PluginPair>> dict;
            /// <summary>
            /// 构造函数。
            /// </summary>
            public PluginInfoCollection()
            {
                this.dict = new Dictionary<DockStyle, List<PluginPair>>();
            }
            #endregion

            /// <summary>
            /// 
            /// </summary>
            /// <param name="location"></param>
            /// <param name="pair"></param>
            public void Add(DockStyle location, PluginPair pair)
            {
                if (pair == null)
                    return;

                if (this.dict.ContainsKey(location))
                {
                    this.dict[location].Add(pair);
                }
                else
                {
                    List<PluginPair> list = new List<PluginPair>();
                    list.Add(pair);
                    this.dict.Add(location, list);
                }
            }

            /// <summary>
            /// 获取给定位置的插件。
            /// </summary>
            /// <param name="location"></param>
            /// <returns></returns>
            public PluginPair[] GetPairs(DockStyle location)
            {
                if (this.dict.ContainsKey(location))
                {
                    List<PluginPair> list = this.dict[location];
                    if (list != null)
                    {
                        list.Sort(this);
                        return list.ToArray();
                    }
                }
                return null;
            }

            /// <summary>
            /// 获取集合数。
            /// </summary>
            public int Count
            {
                get { return this.dict.Count; }
            }

            #region IComparer<PluginPair> 成员
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(PluginPair x, PluginPair y)
            {
                return x.PluginCfg.Order - y.PluginCfg.Order;
            }

            #endregion

            #region IDisposable 成员

            public void Dispose()
            {
                this.dict.Clear();
            }

            #endregion
        }
        /// <summary>
        /// 跨插件处理。
        /// </summary>
        class CrossPluginsHandler: IDisposable
        {
            #region 成员变量，构造函数。
            Dictionary<DockStyle, List<IPlugin>> dict;
            /// <summary>
            /// 构造函数。
            /// </summary>
            public CrossPluginsHandler()
            {
                this.dict = new Dictionary<DockStyle, List<IPlugin>>();
            }
            #endregion

            /// <summary>
            /// 添加插件。
            /// </summary>
            /// <param name="location"></param>
            /// <param name="plug"></param>
            public void Add(DockStyle location, IPlugin plug)
            {
                if (plug != null)
                {
                    if (this.dict.ContainsKey(location))
                    {
                        this.dict[location].Add(plug);
                    }
                    else
                    {
                        List<IPlugin> list = new List<IPlugin>();
                        list.Add(plug);
                        this.dict.Add(location, list);
                    }
                }
            }
            /// <summary>
            /// 发送跨插件数据。
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void SendCross(object sender, CrossPluginEventArgs e)
            {
                if (this.dict.ContainsKey(e.TargetDock))
                {
                    List<IPlugin> list = this.dict[e.TargetDock];
                    if (list != null && list.Count > 0)
                    {
                        foreach (IPlugin p in list)
                        {
                            try
                            {
                                if (p != null)
                                    p.ReceiveCrossPluginData(sender, e);
                            }
                            catch (Exception x)
                            {
                                UtilTools.OnExceptionRecord(x, p.GetType());
                            }
                        }
                    }
                }
            }
            
            #region IDisposable 成员

            public void Dispose()
            {
                this.dict.Clear();
            }

            #endregion
        }
        #endregion
    }
}