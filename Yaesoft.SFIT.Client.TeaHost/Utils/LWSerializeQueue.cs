//================================================================================
//  FileName: LWSerializeQueue.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-12-26
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
using System.Timers;
using System.IO;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Utils
{
    /// <summary>
    /// 学生作业索引对象序列化队列。
    /// </summary>
    public sealed class LWSerializeQueue : IDisposable
    {
        #region 成员变量，构造函数。
        Queue<LocalStudentWorkStore> queue = null;
        Timer timer = null;
        bool isRuning = false;
        /// <summary>
        /// 构造函数。
        /// </summary>
        private LWSerializeQueue()
        {
            this.queue = new Queue<LocalStudentWorkStore>();
            this.timer = new Timer();
            this.timer.Interval = 5000;
            this.timer.Enabled = false;
            this.timer.Elapsed+=new ElapsedEventHandler(timer_Elapsed);
        }
        #endregion

        #region 静态对象。
        static LWSerializeQueue instance;
        /// <summary>
        /// 获取对象实例。
        /// </summary>
        public static LWSerializeQueue Instance
        {
            get
            {
                lock (typeof(LWSerializeQueue))
                {
                    if (instance == null)
                    {
                        instance = new LWSerializeQueue();
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region 辅助函数。
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (this)
            {
                this.isRuning = true;
                this.timer.Stop();
                if (this.queue.Count > 0)
                {
                    LocalStudentWorkStore store = this.queue.Dequeue();
                    if (store != null)
                    {
                        try
                        {
                            LocalStudentWorkStore lss = store;
                            string dir = lss.RootDir();
                            if (!string.IsNullOrEmpty(dir))
                            {
                                string path = Path.GetFullPath(string.Format("{0}/TSW_{1}_{2}.cfg.xml", dir, lss.ClassID, lss.CatalogID));
                                UtilTools.Serializer<LocalStudentWorkStore>(lss, path);
                            }
                        }
                        catch (Exception x)
                        {
                            UtilTools.OnExceptionRecord(x, typeof(LWSerializeQueue));
                        }
                        finally
                        {
                            if (this.queue.Count > 0)
                            {
                                this.timer.Start();
                            }
                            this.isRuning = false;
                        }
                    }
                }
            }
        }
        #endregion

        #region 函数处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        public void Add(LocalStudentWorkStore store)
        {
            if (store != null)
            {
                LocalStudentWorkStore lss = store;
                this.queue.Enqueue(lss);
                if (!this.timer.Enabled && !this.isRuning)
                {
                    this.timer.Start();
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
            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer.Elapsed -= new ElapsedEventHandler(this.timer_Elapsed);
                this.timer.Dispose();
            }
        }

        #endregion
    }
}