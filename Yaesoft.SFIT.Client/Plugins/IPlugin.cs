//================================================================================
//  FileName: IPlugin.cs
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
using System.Text;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
namespace Yaesoft.SFIT.Client.Plugins
{
    /// <summary>
    /// 跨插件传递数据。
    /// </summary>
    /// <param name="source">发送的源对象。</param>
    /// <param name="e">发送的消息。</param>
    public delegate void CrossPluginHandler(object source, CrossPluginEventArgs e);
    /// <summary>
    /// 插件入口接口
    /// </summary>
    public interface IPlugin : IDisposable
    {
        /// <summary>
        /// 获取控件。
        /// </summary>
        IWindow Window { get; }
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="cfg">插件配置信息。</param>
        /// <param name="info">当前用户信息。</param>
        void Init(PluginCfg cfg,UserInfo info);
        /// <summary>
        /// 加载主入口。
        /// </summary>
        /// <param name="service">核心服务。</param>
        /// <returns>控件接口。</returns>
        IWindow LoadMain(ICoreService service);
        /// <summary>
        /// 跨插件传递数据事件。
        /// </summary>
        event CrossPluginHandler CrossPluginSendEvent;
        /// <summary>
        /// 接收跨插件传递数据。
        /// </summary>
        /// <param name="source">发送数据的源对象。</param>
        /// <param name="e">消息数据。</param>
        void ReceiveCrossPluginData(object source, CrossPluginEventArgs e);
    }

    /// <summary>
    /// 跨插件事件消息。
    /// </summary>
    public class CrossPluginEventArgs : EventArgs
    {
        #region 成员变量，构造函数。
        DockStyle target = DockStyle.None;
        object[] args = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="target">目标插件停靠位置。</param>
        /// <param name="args">传递的数据。</param>
        public CrossPluginEventArgs(DockStyle target, params object[] args)
        {
            this.target = target;
            this.args = args;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取目标插件停靠位置。
        /// </summary>
        public DockStyle TargetDock
        {
            get { return this.target; }
        }
        /// <summary>
        /// 获取传递的消息。
        /// </summary>
        public object[] Args
        {
            get { return this.args; }
        }
        #endregion
    }
}