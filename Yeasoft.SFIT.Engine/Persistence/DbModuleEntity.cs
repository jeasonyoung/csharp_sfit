//================================================================================
//  FileName: DbModuleEntity.cs
//  Desc:实体基类。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/5
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
using System.Text.RegularExpressions;
using System.Data;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Persistence
{
    /// <summary>
    ///  实体基类。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DbModuleEntity<T> : DbBaseEntity<T, ModuleConfiguration>
        where T : class, new()
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DbModuleEntity() :
            base(new ModuleConfiguration())
        {

        }
        #endregion

        /// <summary>
        /// 获取枚举数据名称。
        /// </summary>
        /// <param name="type">枚举类型。</param>
        /// <param name="value">枚举值。</param>
        /// <returns>中文名称。</returns>
        public string GetEnumMemberName(Type type, int value)
        {
            CommonEnumsEntity<ModuleConfiguration> enumsEntity = new CommonEnumsEntity<ModuleConfiguration>(this.ModuleConfig);
            return enumsEntity.GetEnumMemberName(type, value);
        }
        /// <summary>
        /// 加载分页数据。
        /// </summary>
        /// <param name="sql">查询语句。</param>
        /// <param name="size">每页数据量。</param>
        /// <param name="index">指定页码。</param>
        /// <param name="pageIndex">当前页码。</param>
        /// <param name="pageCount">总页数。</param>
        /// <param name="rowCount">总数据量。</param>
        /// <returns>分页数据集。</returns>
        protected DataTable LoadPagingData(string sql, int index, int size, out int pageIndex,out int pageSize, out int pageCount, out int rowCount)
        {
            pageIndex = pageSize = pageCount = rowCount = 0;
            DataTable dtResult = null;
            if (!string.IsNullOrEmpty(sql))
            {
                if (index < 1)
                {
                    index = 1;
                }
                if (size < 1)
                {
                    size = 20;
                }
                #region 过滤非法字符。
                Regex regex = new Regex("'", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (regex.IsMatch(sql))
                {
                    sql = regex.Replace(sql, "''");
                }
                #endregion
                string strSql = string.Format("exec spSFITRecordForPaging '{0}',{1},{2}",sql,index, size);
                DataSet ds = this.DatabaseAccess.ExecuteDataset(strSql);
                if (ds != null && ds.Tables.Count >= 3)
                {
                    DataTable dt = ds.Tables[2].Copy();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        pageIndex = Convert.ToInt32(dt.Rows[0][0]);
                        pageSize = Convert.ToInt32(dt.Rows[0][1]);
                        pageCount = Convert.ToInt32(dt.Rows[0][2]);
                        rowCount = Convert.ToInt32(dt.Rows[0][3]);
                    }
                    dtResult = ds.Tables[1].Copy();
                }
            }
            return dtResult;
        }
    }
}
