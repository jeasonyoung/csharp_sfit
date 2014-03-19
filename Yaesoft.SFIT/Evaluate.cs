//================================================================================
//  FileName: Evaluate.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/29
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
using System.Xml.Serialization;
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 客观评价。
    /// </summary>
    [Serializable]
    public class Evaluate
    {
        #region 成员变量，构造函数。
        EvaluateItems items;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Evaluate()
        {
            this.items = new EvaluateItems();
        }
        #endregion
        /// <summary>
        /// 获取或设置评价ID。
        /// </summary>
        public string EvaluateID { get; set; }
        /// <summary>
        /// 获取或设置评价名称。
        /// </summary>
        public string EvaluateName { get; set; }
        /// <summary>
        /// 获取或设置类型。
        /// </summary>
        public EnumEvaluateType Type { get; set; }
        /// <summary>
        /// 获取或设置分数上限(分数制时使用)。
        /// </summary>
        public int MaxValue { get; set; }
        /// <summary>
        /// 获取或设置分数下限(分数制时使用)。
        /// </summary>
        public int MinValue { get; set; }
        /// <summary>
        /// 获取或设置评价项。
        /// </summary>
        public EvaluateItems Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("id:").Append(this.EvaluateID).Append(",")
              .Append("name:").Append(this.EvaluateName).Append(",")
              .Append("type:").Append(this.Type).Append(",")
              .Append("max:").Append(this.MaxValue).Append(",")
              .Append("min:").Append(this.MinValue).Append(",")
              .Append("[").Append(this.items).Append("]");
            return sb.ToString();
        }
    }
    /// <summary>
    /// 客观评价项目内容。
    /// </summary>
    [Serializable]
    public class EvaluateItem
    {
        /// <summary>
        /// 获取或设置项目ID。
        /// </summary>
        public string ItemID { get; set; }
        /// <summary>
        /// 获取或设置项目名称。
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 获取或设置项目值。
        /// </summary>
        public string ItemValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "id:" + this.ItemID + ",name:" + this.ItemName + ",value:" + this.ItemValue;
        }
    }
    /// <summary>
    ///  客观评价项目内容集合。
    /// </summary>
    [Serializable]
    public class EvaluateItems : BaseCollection<EvaluateItem>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public override EvaluateItem this[string itemName]
        {
            get
            {
                EvaluateItem item = this.Items.Find(new Predicate<EvaluateItem>(delegate(EvaluateItem sender)
                {
                    return (sender != null) && (sender.ItemName == itemName);
                }));
                return item;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(EvaluateItem x, EvaluateItem y)
        {
            return string.Compare(x.ItemName, y.ItemName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Items != null && this.Items.Count > 0)
            {
                foreach (EvaluateItem item in this)
                {
                    if (sb.Length > 0) sb.Append(",");
                    sb.Append("{").Append(item).Append("}");
                }
            }
            return sb.ToString();
        }
    }
}
