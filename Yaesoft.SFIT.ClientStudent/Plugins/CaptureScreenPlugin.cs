//================================================================================
//  FileName: CaptureScreenPlugin.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/14
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
namespace Yaesoft.SFIT.ClientStudent.Plugins
{
    /// <summary>
    /// 截屏插件。
    /// </summary>
    public class CaptureScreenPlugin : IPlugin
    {
        #region  成员变量，构造函数。
        UCCaptureScreenSet userControl = null;
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

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public IWindow LoadMain(ICoreService service)
        {
            this.userControl = new UCCaptureScreenSet(service);
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