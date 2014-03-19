//================================================================================
//  FileName: ModulePresenter.cs
//  Desc:
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
using System.Data;

using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;

using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 模块UI接口。
    /// </summary>
    public interface IModuleView : IBaseView
    {
    }

    /// <summary>
    /// 模块行为基础类。
    /// </summary>
    /// <typeparam name="T">UI视图接口。</typeparam>
    public class ModulePresenter<T> : BasePresenter<T, ModuleConfiguration>
        where T : IModuleView
    {

        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view">UI视图接口对象。</param>
        public ModulePresenter(T view)
            : base(view)
        {
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 菜单数据。
        /// </summary>
        protected override ModuleDefineCollection ModuleDefineConfig
        {
            get
            {
                ModuleDefineCollection collection = base.ModuleDefineConfig;
                if (collection != null)
                {
                    #region 知识技能要点。
                    ModuleDefine parentKnowledgePoints = collection[ModuleConstants.KnowledgePoints_ModuleID];
                    if (parentKnowledgePoints != null)
                    {
                        if (parentKnowledgePoints.Modules.Count > 0)
                            parentKnowledgePoints.Modules.Clear();
                        DataTable dtSource = new SFITKnowledgePointsEntity().GetKnowledgePointsMenuData();
                        if (dtSource != null && dtSource.Rows.Count > 0)
                        {
                            string url = parentKnowledgePoints.ModuleUri + "?TopPointID={0}";
                            string pointID = parentKnowledgePoints.ModuleID;
                            foreach (DataRow row in dtSource.Rows)
                            {
                                parentKnowledgePoints.Modules.Add(new ModuleDefine(string.Format("{0}-{1}", pointID, row["PointID"]),
                                                                                   Convert.ToString(row["PointName"]),
                                                                                   string.Format(url, row["PointID"]),
                                                                                   Convert.ToInt32(row["OrderNO"])));
                            }
                        }
                    }
                    #endregion
                }
                return collection;
            }
        }
        /// <summary>
        /// 获取模块配置实例。
        /// </summary>
        /// <returns></returns>
        protected override ModuleConfiguration CreateModuleConfiguration()
        {
            return new ModuleConfiguration();
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 构建课程目录子菜单数据。
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="url"></param>
        /// <param name="baseID"></param>
        /// <param name="parentValue"></param>
        /// <param name="parent"></param>
        void BuildCatalogMenuData(DataTable dtSource, string url, string baseID, string parentValue, ref ModuleDefine parent)
        {
            if (dtSource != null && !string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(parentValue))
            {
                DataRow[] rows = dtSource.Select(string.Format("PID = '{0}'", parentValue));
                if (rows != null && rows.Length > 0)
                {
                    foreach (DataRow r in rows)
                    {
                        ModuleDefine m = new ModuleDefine(string.Format("{0}-{1}", baseID, r["ID"]),
                                                          Convert.ToString(r["Name"]),
                                                          string.Format(url, r["YearTermID"], r["GradeID"]),
                                                          Convert.ToInt32(r["OrderNO"]));
                        this.BuildCatalogMenuData(dtSource.Copy(), url, baseID, Convert.ToString(r["ID"]), ref m);
                        parent.Modules.Add(m);
                    }
                }
            }
        }
        /// <summary>
        /// 构建班级子菜单数据。
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="url"></param>
        /// <param name="baseID"></param>
        /// <param name="parentValue"></param>
        /// <param name="parent"></param>
        void BuildClassMenuData(DataTable dtSource, string url, string baseID, string parentValue, ref ModuleDefine parent)
        {
            if (dtSource != null && !string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(parentValue))
            {
                DataRow[] rows = dtSource.Select(string.Format("PID = '{0}'", parentValue));
                if (rows != null && rows.Length > 0)
                {
                    foreach (DataRow r in rows)
                    {
                        ModuleDefine m = new ModuleDefine(string.Format("{0}-{1}", baseID, r["ID"]),
                                                          Convert.ToString(r["Name"]),
                                                          string.Format(url, r["SchoolID"], r["YearTermID"], r["GradeID"]),
                                                          Convert.ToInt32(r["OrderNO"]));
                        this.BuildClassMenuData(dtSource.Copy(), url, baseID, Convert.ToString(r["ID"]), ref m);
                        parent.Modules.Add(m);
                    }
                }
            }
        }
        /// <summary>
        /// 构造学生子菜单数据。
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="url"></param>
        /// <param name="baseID"></param>
        /// <param name="parentValue"></param>
        /// <param name="parent"></param>
        void BuildStudentsMenuData(DataTable dtSource, string url, string baseID, string parentValue, ref ModuleDefine parent)
        {
            if (dtSource != null && !string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(parentValue))
            {
                DataRow[] rows = dtSource.Select(string.Format("PID = '{0}'", parentValue));
                if (rows != null && rows.Length > 0)
                {
                    foreach (DataRow r in rows)
                    {
                        ModuleDefine m = new ModuleDefine(string.Format("{0}-{1}", baseID, r["ID"]),
                                                          Convert.ToString(r["Name"]),
                                                          string.Format(url, r["SchoolID"], r["YearTermID"], r["GradeID"],r["ClassID"]),
                                                          Convert.ToInt32(r["OrderNO"]));
                        this.BuildStudentsMenuData(dtSource.Copy(), url, baseID, Convert.ToString(r["ID"]), ref m);
                        parent.Modules.Add(m);
                    }
                }
            }
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 获取学生作品状态名称
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string GetEnumWorkStatusName(EnumWorkStatus status)
        {
            Type t = typeof(EnumWorkStatus);
            List<string> list = new List<string>();

            if ((status & EnumWorkStatus.Submit) == EnumWorkStatus.Submit)
                list.Add(this.GetEnumMemberName(t, (int)EnumWorkStatus.Submit));
            if ((status & EnumWorkStatus.Recive) == EnumWorkStatus.Recive)
                list.Add(this.GetEnumMemberName(t, (int)EnumWorkStatus.Recive));
            if ((status & EnumWorkStatus.Review) == EnumWorkStatus.Review)
                list.Add(this.GetEnumMemberName(t, (int)EnumWorkStatus.Review));
            if ((status & EnumWorkStatus.Upload) == EnumWorkStatus.Upload)
                list.Add(this.GetEnumMemberName(t, (int)EnumWorkStatus.Upload));
            if ((status & EnumWorkStatus.Release) == EnumWorkStatus.Release)
                list.Add(this.GetEnumMemberName(t, (int)EnumWorkStatus.Release));

            return string.Join(",", list.ToArray());
        }
        /// <summary>
        /// 绑定作品状态数据。
        /// </summary>
        /// <returns></returns>
        public IListControlsData BindEnumWorkStatusData()
        {
            return new ConstListControlsDataSource<ModuleConfiguration>(typeof(EnumWorkStatus), new int[] { (int)EnumWorkStatus.None }, this.ModuleConfig);
        }
        #endregion
    }
}
