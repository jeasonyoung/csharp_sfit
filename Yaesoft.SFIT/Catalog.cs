//================================================================================
//  FileName: Catalog.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/10/24
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
    /// 目录信息类。
    /// </summary>
    [Serializable]
    public class Catalog
    {
        #region 成员变量，构造函数。
        KnowledgePoints points = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Catalog()
        {
            this.points = new KnowledgePoints();
        }
        #endregion

        /// <summary>
        /// 获取或设置目录ID。
        /// </summary>
        public string CatalogID { get; set; }
        /// <summary>
        /// 获取或设置目录代码。
        /// </summary>
        public string CatalogCode { get; set; }
        /// <summary>
        /// 获取或设置目录名称。
        /// </summary>
        public string CatalogName { get; set; }
        /// <summary>
        /// 获取或设置目录类型名称。
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 获取或设置排序号。
        /// </summary>
        public int OrderNO { get; set; }
        /// <summary>
        /// 获取或设置知识要点集合。
        /// </summary>
        public KnowledgePoints Points
        {
            get { return this.points; }
            set { this.points = value; }
        }

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("ID:{0},Code:{1},Name:{2},Type:{3},Order:{4}",
                                this.CatalogID,
                                this.CatalogCode,
                                this.CatalogName,
                                this.TypeName,
                                this.OrderNO);
        }
        #endregion
    }
    /// <summary>
    /// 目录信息集合。
    /// </summary>
    [Serializable]
    public class Catalogs : BaseCollection<Catalog>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public override Catalog this[string catalogID]
        {
            get
            {
                Catalog c = this.Items.Find(new Predicate<Catalog>(delegate(Catalog sender)
                {
                    return (sender != null) && (sender.CatalogID == catalogID);
                }));
                return c;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(Catalog x, Catalog y)
        {
            return x.OrderNO - y.OrderNO;
        }
    }
}
