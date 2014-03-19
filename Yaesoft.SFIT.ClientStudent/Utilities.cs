//================================================================================
//  FileName: Utilities.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/24
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

using Yaesoft.SFIT;
namespace Yaesoft.SFIT.ClientStudent
{
    /// <summary>
    /// 工具类。
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static string BuildKnowledgePointsToolTip(KnowledgePoints points)
        {
            StringBuilder toolTip = new StringBuilder();
            if (points != null && points.Count > 0)
            {
                foreach (KnowledgePoint p in points)
                {
                    toolTip.AppendFormat("\t{0}\r\n", p.PointName);
                }
            }
            return toolTip.ToString();
        }
    }
}
