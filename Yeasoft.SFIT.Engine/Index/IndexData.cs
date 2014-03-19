using System;
using System.Collections.Generic;
using System.Text;

namespace Yaesoft.SFIT.Engine.Index
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class IndexData
    {
        /// <summary>
        /// 获取或设置ID。
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置名称。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置排序。
        /// </summary>
        public int OrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                return this.ID.GetHashCode();
            }
            return base.GetHashCode();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class IndexDatas : DataCollection<IndexData>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public override void Add(IndexData item)
        {
            if (item != null)
            {
                if (item.OrderNo == 0)
                {
                    item.OrderNo = this.Count;
                }
                base.Add(item);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(IndexData x, IndexData y)
        {
            int result = x.OrderNo - y.OrderNo;
            if (result == 0)
            {
                result = string.Compare(x.Name, y.Name);
            }
            return result;
        }
    }
}