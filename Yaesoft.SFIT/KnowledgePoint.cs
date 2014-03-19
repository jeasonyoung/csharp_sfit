//================================================================================
//  FileName: KnowledgePoint.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/25
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
    /// 知识要点。
    /// </summary>
    [Serializable]
    public class KnowledgePoint
    {
        /// <summary>
        /// 获取或设置要点ID。
        /// </summary>
        public string PointID { get; set; }
        /// <summary>
        /// 获取或设置要点代码。
        /// </summary>
        public string PointCode { get; set; }
        /// <summary>
        /// 获取或设置要点名称。
        /// </summary>
        public string PointName { get; set; }
        /// <summary>
        /// 获取或设置要点描述。
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 获取或设置排序号。
        /// </summary>
        public int OrderNO { get; set; }

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("ID:{0},Code:{1},Name:{2},Order:{3}",
                                 this.PointID, 
                                 this.PointCode,
                                 this.PointName,
                                 this.OrderNO);
        }
        #endregion
    }
    /// <summary>
    /// 知识要点集合。
    /// </summary>
    [Serializable]
    public class KnowledgePoints : BaseCollection<KnowledgePoint>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointID"></param>
        /// <returns></returns>
        public override KnowledgePoint this[string pointID]
        {
            get
            {
                KnowledgePoint p = this.Items.Find(new Predicate<KnowledgePoint>(delegate(KnowledgePoint sender)
                {
                    return (sender != null) && (sender.PointID == pointID);
                }));
                return p;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(KnowledgePoint x, KnowledgePoint y)
        {
            return x.OrderNO - y.OrderNO;
        }
    }
}
