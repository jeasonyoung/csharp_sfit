//================================================================================
//  FileName: IndexDataResult.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-12-31
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

namespace Yaesoft.SFIT.Engine.Index
{
    /// <summary>
    /// 首页异步数据结果类。
    /// </summary>
    [Serializable]
    public class IndexDataResult<T>
    {
        #region 构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public IndexDataResult()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="rowcount"></param>
        /// <param name="items"></param>
        public IndexDataResult(int pageSize, int pageIndex, int pageCount, int rowCount,T items)
        {
            this.PS = pageSize;
            this.PI = pageIndex;
            this.PC = pageCount;
            this.RC = rowCount;
            this.Items = items;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置每页数据条数。
        /// </summary>
        public int PS
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置当前页码。
        /// </summary>
        public int PI
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置分页数。
        /// </summary>
        public int PC
        {
            get;
            set;
        }
        /// <summary>
        /// 获取总数据行数。
        /// </summary>
        public int RC
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置数据集合。
        /// </summary>
        public T Items
        {
            get;
            set;
        }
        #endregion
    }
}