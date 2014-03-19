//================================================================================
//  FileName: PluginControl.cs
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
using System.Xml.Serialization;
namespace Yaesoft.SFIT.Client.Plugins
{
    /// <summary>
    /// 插件配置信息。
    /// </summary>
    [Serializable]
    [XmlRoot("Plugin")]
    public class PluginCfg
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public PluginCfg()
        {
            this.Location = DockStyle.Fill;    
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置插件ID。
        /// </summary>
        [XmlAttribute("id")]
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置插件名称。
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置排序。
        /// </summary>
        [XmlAttribute("order")]
        public int Order { get; set; }
        /// <summary>
        /// 获取或设置快捷键。
        /// </summary>
        [XmlAttribute("hotkeys")]
        public string Hotkeys { get; set; }
        /// <summary>
        /// 获取或设置宿主ID。
        /// </summary>
        public string HostID { get; set; }
        /// <summary>
        /// 获取或设置在宿主中的停靠位置。
        /// </summary>
        public DockStyle Location { get; set; }
        /// <summary>
        /// 获取或设置程序集合。
        /// </summary>
        public string Assembly { get; set; }
        /// <summary>
        /// 获取或设置描述。
        /// </summary>
        public string Description { get; set; }
        #endregion
    }

    /// <summary>
    /// 插件配置信息集合。
    /// </summary>
    [Serializable]
    [XmlRoot("Plugins")]
    public class PluginCfgs : ICollection<PluginCfg>, IComparer<PluginCfg>
    {
        #region 成员变量，构造函数。
        List<PluginCfg> list;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public PluginCfgs()
        {
            this.list = new List<PluginCfg>();
        }
        #endregion

        /// <summary>
        /// 获取指定宿主ID的插件。
        /// </summary>
        /// <param name="hostId"></param>
        /// <returns></returns>
        public PluginCfgs GetPluginCfgs(string hostId)
        {
            if (!string.IsNullOrEmpty(hostId))
            {
                List<PluginCfg> items = this.list.FindAll(new Predicate<PluginCfg>(delegate(PluginCfg sender) {
                    return (sender != null) && (sender.HostID == hostId);                        
                }));

                if (items != null && items.Count > 0)
                {
                    PluginCfgs result = new PluginCfgs();
                    foreach (PluginCfg cfg in items)
                    {
                        result.Add(cfg);
                    }
                    return result;
                }
            }
            return null;
        }

        #region ICollection<PluginCfg> 成员
        /// <summary>
        /// 添加插件配置。
        /// </summary>
        /// <param name="item"></param>
        public void Add(PluginCfg item)
        {
            if (item != null)
            {
                if (this.Contains(item))
                    this.Remove(item);
                this.list.Add(item);
            }
        }
        /// <summary>
        /// 清除插件。
        /// </summary>
        public void Clear()
        {
            this.list.Clear();
        }
        /// <summary>
        /// 判断插件是否存在。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(PluginCfg item)
        {
            if (item != null)
            {
                int index = this.list.FindIndex(new Predicate<PluginCfg>(delegate(PluginCfg sender)
                {
                    return (sender != null) && (sender.ID == item.ID);
                }));
                return index > -1;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(PluginCfg[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return this.list.Count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(PluginCfg item)
        {
            if (item != null)
            {
                int index = this.list.FindIndex(new Predicate<PluginCfg>(delegate(PluginCfg sender)
                {
                    return (sender != null) && (sender.ID == item.ID);
                }));
                if (index > -1)
                {
                    this.list.RemoveAt(index);
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region IEnumerable<PluginCfg> 成员

        public IEnumerator<PluginCfg> GetEnumerator()
        {
            this.list.Sort(this);
            return this.list.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            this.list.Sort(this);
            foreach (PluginCfg cfg in this.list)
                yield return cfg;
        }

        #endregion

        #region IComparer<PluginCfg> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(PluginCfg x, PluginCfg y)
        {
            int result = x.Order - y.Order;
            if (result == 0)
                result = string.Compare(x.Name, y.Name);
            return result;
        }

        #endregion
    }
}
