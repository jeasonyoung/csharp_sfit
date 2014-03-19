//================================================================================
//  FileName: BootstrapLoadService.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Yaesoft.SFIT.Client.Plugins;
namespace Yaesoft.SFIT.Client.Forms
{
    /// <summary>
    /// 核心服务接口。
    /// </summary>
    public interface ICoreService : IContainer
    {
        /// <summary>
        /// 获取或设置是否强制退出。
        /// </summary>
        bool ForceQuit { get; set; }
        /// <summary>
        /// 通知外部消息。
        /// </summary>
        event RaiseChangedHandler Changed;
        /// <summary>
        /// 添加窗体。
        /// </summary>
        /// <param name="frm"></param>
        void AddForm(Form frm);
    }
    /// <summary>
    /// 系统初始化服务
    /// </summary>
    public class InitialService : ICoreService
    {
        #region 成员变量，构造函数。
        private Queue forms;
        private Hashtable provider;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public InitialService()
        {
            this.forms = Queue.Synchronized(new Queue());
            this.provider = Hashtable.Synchronized(new Hashtable());
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置是否强制退出。
        /// </summary>
        public bool ForceQuit { get; set; }
        /// <summary>
        /// 获取窗体队列中的总数。
        /// </summary>
        public int Count
        {
            get { return this.forms.Count; }
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 自定义加载事件。
        /// </summary>
        public event EventHandler CustomLoadEvent;
        /// <summary>
        /// 触发自定义加载事件。
        /// </summary>
        protected void OnCustomLoadEvent()
        {
            EventHandler hander = this.CustomLoadEvent;
            if (hander != null)
                hander(this, EventArgs.Empty);
        }
        /// <summary>
        /// 通知外部消息。
        /// </summary>
        public event RaiseChangedHandler Changed;
        /// <summary>
        /// 触发通知外部消息。
        /// </summary>
        /// <param name="e"></param>
        public void RaiseChanged(string context)
        {
            RaiseChangedHandler handler = this.Changed;
            if (handler != null)
                handler(context);
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 加载初始化数据。
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="complete"></param>
        public void LoadingInitial(Control ctrl, EventHandler complete)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object sender)
            {
                this.RaiseChanged("开始加载初始化数据...");
                Thread.Sleep(500);
                this.LoadPluginsCfg();
                Thread.Sleep(500);
                this.OnCustomLoadEvent();
                Thread.Sleep(500);
                this.RaiseChanged("初始化数据加载完成.");
                Thread.Sleep(500);
                if (complete != null)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
                    {
                        Control c = o as Control;
                        if (c != null)
                        {
                            c.Invoke(new MethodInvoker(delegate()
                            {
                                complete(this, EventArgs.Empty);
                            }));
                        }
                        else
                        {
                            complete(this, EventArgs.Empty);
                        }
                    }), ctrl);
                }
            }));
        }
        /// <summary>
        /// 加载插件。
        /// </summary>
        protected void LoadPluginsCfg()
        {
            this.RaiseChanged("开始加载插件配置数据...");
            PluginsConfiguration cfg = PluginsConfiguration.DeSerializer();
            if (cfg != null && cfg.Plugins != null)
            {
                this.Add("plugins", cfg.Plugins);
            }
            this.RaiseChanged("加载插件配置数据完成...");
        }
        /// <summary>
        /// 加入窗体。
        /// </summary>
        /// <param name="frm"></param>
        public void AddForm(Form frm)
        {
            if (frm != null)
            {
                this.forms.Enqueue(frm);
            }
        }
        /// <summary>
        /// 运行窗体。
        /// </summary>
        public void Run()
        {
            this.BeginRun();
            Form f = null;
            while ((this.forms.Count > 0) && ((f = (this.forms.Dequeue() as Form)) != null))
            {
                f.StartPosition = FormStartPosition.CenterScreen;
                f.FormClosing += this.FormClosing;
                this.PreRunForm(f);
                Application.Run(f);
            }
        }
        /// <summary>
        /// 开始运行所有的窗体。
        /// </summary>
        protected virtual void BeginRun()
        {
        }
        /// <summary>
        /// 窗体开始执行运行前。
        /// </summary>
        /// <param name="form"></param>
        protected virtual void PreRunForm(Form form)
        {

        }
        /// <summary>
        /// 窗体关闭。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.ForceQuit)
            {
                DialogResult result = MessageBox.Show("确定退出程序？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                this.ForceQuit = !(e.Cancel = (result == DialogResult.No));
            }
        }
        #endregion

        #region IContainer<object> 成员
        /// <summary>
        /// 根据名称获取或设置容器对象。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name)) return null;
                return this.provider[name];
            }
            set
            {
                if (!string.IsNullOrEmpty(name)) this.provider[name] = value;
            }
        }
        /// <summary>
        /// 根据类型获取容器对象数组。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object this[Type type]
        {
            get
            {
                if (type == null) return null;
                return this.provider[type];
            }
        }
        /// <summary>
        /// 添加容器对象。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="component"></param>
        public void Add(string name, object component)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this.provider[name] = component;
            }
        }
        /// <summary>
        /// 移除容器对象。
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            if (!string.IsNullOrEmpty(name) && this.provider.ContainsKey(name))
            {
                this.provider.Remove(name);
            }
        }

        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 释放资源。
        /// </summary>
        public virtual void Dispose()
        {
            this.provider.Clear();
        }

        #endregion
    }
}