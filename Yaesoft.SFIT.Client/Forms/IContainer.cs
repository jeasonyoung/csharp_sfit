//================================================================================
//  FileName: IContainer.cs
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

namespace Yaesoft.SFIT.Client.Forms
{
    /// <summary>
    /// 容器接口。
    /// </summary>
    public interface IContainer : IDisposable
    {
        /// <summary>
        /// 根据名称获取或设置对象。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object this[string name] { get; set; }
        /// <summary>
        /// 根据类型获取所有满足条件的对象数组。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object this[Type type] { get; }
        /// <summary>
        /// 将指定的对象添加至列表结尾。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="component"></param>
        void Add(string name, object component);
        /// <summary>
        /// 从容器中移除对象。
        /// </summary>
        /// <param name="name"></param>
        void Remove(string name);
    }
    ///// <summary>
    ///// 抽象容器实现。
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //public abstract class Container<T> : IContainer<T>
    //{
    //    #region 成员变量，构造函数。
    //    Dictionary<string, T> dict;
    //    /// <summary>
    //    /// 构造函数。
    //    /// </summary>
    //    public Container()
    //    {
    //        this.dict = new Dictionary<string, T>();
    //    }
    //    #endregion

    //    #region IContainer<T> 成员
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="name"></param>
    //    /// <returns></returns>
    //    public T this[string name]
    //    {
    //        get
    //        {
    //            if (!string.IsNullOrEmpty(name) && this.dict.ContainsKey(name))
    //            {
    //                return this.dict[name];
    //            }
    //            return default(T);
    //        }
    //        set
    //        {
    //            if (!string.IsNullOrEmpty(name) && value != null)
    //            {
    //                this.Add(name, value);
    //            }
    //        }
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="type"></param>
    //    /// <returns></returns>
    //    public T[] this[Type type]
    //    {
    //        get
    //        {
    //            if (type != null && this.dict != null && this.dict.Count > 0)
    //            {
    //                T[] array = new T[this.dict.Count];
    //                this.dict.Values.CopyTo(array, 0);
    //                if (array != null)
    //                {
    //                    T[] result = Array.FindAll<T>(array, new Predicate<T>(delegate(T sender)
    //                    {
    //                        return (sender != null) && (sender.GetType() == type);
    //                    }));
    //                    return result;
    //                }
    //            }
    //            return null;
    //        }
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="name"></param>
    //    /// <param name="component"></param>
    //    public void Add(string name, T component)
    //    {
    //        if (!string.IsNullOrEmpty(name) && component != null)
    //        {
    //            if (this.dict.ContainsKey(name))
    //                this.dict[name] = component;
    //            else
    //                this.dict.Add(name, component);
    //        }
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="name"></param>
    //    public void Remove(string name)
    //    {
    //        if (!string.IsNullOrEmpty(name) && this.dict.ContainsKey(name))
    //            this.dict.Remove(name);
    //    }

    //    #endregion

    //    #region IDisposable 成员

    //    public void Dispose()
    //    {
    //        if (this.dict != null)
    //        {
    //            this.dict.Clear();
    //        }
    //    }

    //    #endregion
    //}
}
