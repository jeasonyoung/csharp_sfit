//================================================================================
//  FileName: EnumWorkStatus.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/2
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

namespace Yaesoft.SFIT
{
    /// <summary>
    /// 学生作品状态。
    /// </summary>
    [Serializable]
    [Flags]
    public enum EnumWorkStatus
    {
        ///<summary>
        /// 未提交。
        /// </summary>
        None = 0x01,
        /// <summary>
        /// 已提交。
        /// </summary>
        Submit = 0x02,
        /// <summary>
        /// 已接收。
        /// </summary>
        Recive = 0x04,
        /// <summary>
        /// 已批阅。
        /// </summary>
        Review = 0x08,
        /// <summary>
        /// 已上传。
        /// </summary>
        Upload = 0x10,
        /// <summary>
        /// 已发布。
        /// </summary>
        Release = 0x20
    }

    /// <summary>
    /// 学生作品状态操作帮助类。
    /// </summary>
    public static class EnumWorkStatusOperaTools
    {
        /// <summary>
        /// 添加状态。
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="status"></param>
        public static EnumWorkStatus AddStatus(EnumWorkStatus owner, EnumWorkStatus status)
        {
            if ((owner & status) != status)
                owner |= status;
            return owner;
        }
        /// <summary>
        /// 获取状态名称。
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetStatusName(EnumWorkStatus status)
        {
            List<string> list = new List<string>();
            //if ((status & EnumWorkStatus.None) == EnumWorkStatus.None)
            //    list.Add("未提交");
            if ((status & EnumWorkStatus.Submit) == EnumWorkStatus.Submit)
                list.Add("已提交");
            if ((status & EnumWorkStatus.Recive) == EnumWorkStatus.Recive)
                list.Add("已接收");
            if ((status & EnumWorkStatus.Review) == EnumWorkStatus.Review)
                list.Add("已批阅");
            if ((status & EnumWorkStatus.Upload) == EnumWorkStatus.Upload)
                list.Add("已上传");
            if ((status & EnumWorkStatus.Release) == EnumWorkStatus.Release)
                list.Add("已发布");
            return string.Join(",", list.ToArray());
        }
        /// <summary>
        /// 将其转化为数组。
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string[] ToArray(EnumWorkStatus status)
        {
            List<string> list = new List<string>();
            if ((status & EnumWorkStatus.Submit) == EnumWorkStatus.Submit)
                list.Add(string.Format("{0}", (int)EnumWorkStatus.Submit));
            if ((status & EnumWorkStatus.Recive) == EnumWorkStatus.Recive)
                list.Add(string.Format("{0}", (int)EnumWorkStatus.Recive));
            if ((status & EnumWorkStatus.Review) == EnumWorkStatus.Review)
                list.Add(string.Format("{0}", (int)EnumWorkStatus.Review));
            if ((status & EnumWorkStatus.Upload) == EnumWorkStatus.Upload)
                list.Add(string.Format("{0}", (int)EnumWorkStatus.Upload));
            if ((status & EnumWorkStatus.Release) == EnumWorkStatus.Release)
                list.Add(string.Format("{0}", (int)EnumWorkStatus.Release));
            return list.ToArray();
        }
        /// <summary>
        /// 将其转化为枚举。
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static EnumWorkStatus ToValue(string[] values)
        {
            EnumWorkStatus status = EnumWorkStatus.None;
            int len = 0;
            if (values != null && (len = values.Length) > 0)
            {
                if (len > 0)
                {
                    try
                    {
                        status = (EnumWorkStatus)int.Parse(values[0]);
                    }
                    catch (Exception) { }
                }

                if (len > 1)
                {
                    for (int i = 1; i < len; i++)
                    {
                        try
                        {
                            status |= (EnumWorkStatus)int.Parse(values[i]);
                        }
                        catch (Exception) { }
                    }

                }
            }
            return status;
         }
    }
}
