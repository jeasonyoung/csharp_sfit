//================================================================================
//  FileName: TextValueDataObserver.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/23
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
using Yaesoft.SFIT.Client.Net.MSG;
namespace Yaesoft.SFIT.Client.Utils
{
    /// <summary>
    /// 数据观察委托。
    /// </summary>
    /// <param name="data"></param>
    public delegate void DataObserverHandler(List<HostBroadcast> data);
    /// <summary>
    /// 数据观察者模式。
    /// </summary>
    public class DataObserver
    {
        #region 成员变量，构造函数。
        Hashtable htcCache = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DataObserver()
        {
            this.htcCache = Hashtable.Synchronized(new Hashtable());
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 数据观察事件。
        /// </summary>
        public event DataObserverHandler Observer;
        /// <summary>
        /// 触发数据观察事件。
        /// </summary>
        /// <param name="data"></param>
        protected void OnDataObserver()
        {
            DataObserverHandler handler = this.Observer;
            int len = 0;
            if (handler != null && ((len = this.htcCache.Count) > 0))
            {
                HostBroadcast[] array = new HostBroadcast[len];
                this.htcCache.Values.CopyTo(array, 0);
                List<HostBroadcast> list = new List<HostBroadcast>();
                for (int i = 0; i < len; i++)
                    list.Add(array[i]);
                if (list.Count > 0)
                    handler(list);
            }
        }
        #endregion

        /// <summary>
        /// 添加观察数据。
        /// </summary>
        /// <param name="data"></param>
        public void AddDataObserver(HostBroadcast data)
        {
            if (data != null && !this.htcCache.ContainsKey(data.SName))
            {
                this.htcCache.Add(data.SName, data);
                this.OnDataObserver();
            }
        }
    }
}
