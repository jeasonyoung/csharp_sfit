//================================================================================
//  FileName: MessagePlugin.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/2
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
using Yaesoft.SFIT.Client.Plugins;
namespace Yaesoft.SFIT.Client.TeaHost.Plugins
{
    /// <summary>
    /// 消息显示插件。
    /// </summary>
    public class MessagePlugin : IPlugin
    {
        #region 成员变量，构造函数。
        PluginCfg cfg;
        UCMessage userControl;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public MessagePlugin()
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
            this.userControl = new UCMessage(service);
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
            if (this.cfg != null && this.cfg.Location == e.TargetDock && e.Args != null && e.Args.Length > 1)
            {
                object[] args = e.Args;
                if (args[0].ToString() == "msg" && this.userControl != null)
                {
                    string strMsg = args[1].ToString();
                    if (!string.IsNullOrEmpty(strMsg))
                    {
                        this.userControl.ThreadSafeMethod(new MethodInvoker(delegate()
                        {
                            this.userControl.ShowMessage(strMsg);
                        }));
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