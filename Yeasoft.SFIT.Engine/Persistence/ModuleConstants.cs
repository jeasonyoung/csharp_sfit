//================================================================================
//  FileName: ModuleConstants.cs
//  Desc:模块常量
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

namespace Yaesoft.SFIT.Engine.Persistence
{
    /// <summary>
    /// 模块常量。
    /// </summary>
    public static class ModuleConstants
    {
        #region 系统设置
        /// <summary>
        /// 系统设置_接入管理_模块ID。
        /// </summary>
        public const string CenterAccess_ModuleID = "PAS00000000000000000000000000101";

        /// <summary>
        /// 系统设置_评价管理_模块ID。
        /// </summary>
        public const string Evaluate_ModuleID = "PAS00000000000000000000000000201";
        /// <summary>
        /// 系统设置_评价应用_模块ID。
        /// </summary>
        public const string EvaluateSet_ModuleID = "PAS00000000000000000000000010201";

        /// <summary>
        /// 要点与目录_知识要点_模块ID。
        /// </summary>
        public const string KnowledgePoints_ModuleID = "PAS00000000000000000000000010301";

        /// <summary>
        /// 要点与目录_课程目录(教育局)_模块ID。
        /// </summary>
        public const string Catalog_ModuleID = "PAS00000000000000000000000020301";
        /// <summary>
        /// 要点与目录_课程目录(学校)_模块ID。
        /// </summary>
        public const string CatalogByUnit_ModuleID = "PAS00000000000000000000000030301";

        /// <summary>
        /// 系统设置_教师/班级设置(教育局)_模块ID。
        /// </summary>
        public const string TeaClass_ModuleID = "PAS00000000000000000000000000401";
        /// <summary>
        /// 系统设置_教师/班级设置(学校)_模块ID。
        /// </summary>
        public const string TeaClassByUnit_ModuleID = "PAS00000000000000000000000000501";
        #endregion

        #region 数据维护。
        /// <summary>
        /// 数据维护_学校数据_模块ID。
        /// </summary>
        public const string Schools_ModuleID = "PAS00000000000000000000000000102";
        /// <summary>
        /// 数据维护_年级_模块ID。
        /// </summary>
        public const string Grade_ModuleID = "PAS00000000000000000000000000202";
        /// <summary>
        /// 数据维护_教师_模块ID。
        /// </summary>
        public const string Teachers_ModuleID = "PAS00000000000000000000000000302";
        /// <summary>
        /// 数据维护_班级_模块ID。
        /// </summary>
        public const string Class_ModuleID = "PAS00000000000000000000000000402";
        /// <summary>
        /// 数据维护_学生_模块ID。
        /// </summary>
        public const string Students_ModuleID = "PAS00000000000000000000000000502";
        #endregion

        #region 发布/评论
        /// <summary>
        /// 作品收集(教育局)_模块ID。
        /// </summary>
        public const string StudentWorks_ModuleID = "PAS00000000000000000000000000103";
        /// <summary>
        /// 作品收集(学校)_模块ID。
        /// </summary>
        public const string StudentWorksByUnit_ModuleID = "PAS00000000000000000000000000203";
        /// <summary>
        /// 发布设置(教育局)_模块ID。
        /// </summary>
        public const string PublishSettings_ModuleID = "PAS00000000000000000000000000303";
        /// <summary>
        /// 发布设置(学校)_模块ID。
        /// </summary>
        public const string PublishSettingsByUnit_ModuleID = "PAS00000000000000000000000000403";
        /// <summary>
        /// 评论汇总(教育局)_模块ID。
        /// </summary>
        public const string WorksComments_ModuleID = "PAS00000000000000000000000000503";
        /// <summary>
        /// 评论汇总(学校)_模块ID。
        /// </summary>
        public const string WorksCommentsByUnit_ModuleID = "PAS00000000000000000000000000603";
        /// <summary>
        /// 教师查询_模块ID。
        /// </summary>
        public const string TeaStudentWorks_ModuleID = "PAS00000000000000000000000000703";
        /// <summary>
        /// 学生查询_模块ID。
        /// </summary>
        public const string StudentPersonalWorks_ModuleID = "PAS00000000000000000000000000803";
       
        #endregion

        #region 兴趣小组。
        /// <summary>
        /// 兴趣小组(教育局)_模块ID。
        /// </summary>
        public const string HobbyGroup_ModuleID = "PAS00000000000000000000000010104";
        /// <summary>
        /// 兴趣小组作品(教育局)_模块ID。
        /// </summary>
        public const string HobbyGroupWork_ModuleID = "PAS00000000000000000000000020104";
        /// <summary>
        /// 兴趣小组(学校单位)_模块ID。
        /// </summary>
        public const string HobbyGroupByUnit_ModuleID = "PAS00000000000000000000000010204";
        /// <summary>
        /// 兴趣小组作品(学校单位)_模块ID。
        /// </summary>
        public const string HobbyGroupWorkByUnit_ModuleID = "PAS00000000000000000000000020204";
        #endregion

        #region 竞赛管理。
        /// <summary>
        /// 竞赛管理(教育局)_模块ID。
        /// </summary>
        public const string SportsGroup_ModuleID = "PAS00000000000000000000000010105";
        /// <summary>
        /// 竞赛作品(教育局)_模块ID。
        /// </summary>
        public const string SportsGroupWork_ModuleID = "PAS00000000000000000000000020105";
        /// <summary>
        /// 竞赛管理(学校单位)_模块ID。
        /// </summary>
        public const string SportsGroupByUnit_ModuleID = "PAS00000000000000000000000010205";
        /// <summary>
        /// 竞赛作品(学校单位)_模块ID。
        /// </summary>
        public const string SportsGroupWorkByUnit_ModuleID = "PAS00000000000000000000000020205";
        #endregion
    }
}
