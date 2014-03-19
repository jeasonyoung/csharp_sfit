//================================================================================
//  FileName: Msg.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/4
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

namespace Yaesoft.SFIT.Client.Net.MSG
{
    /// <summary>
    ///消息抽象类。
    /// </summary>
    [Serializable]
    public abstract class Msg
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Msg()
        {
            this.Kind = MSGKind.None;
            this.Time = DateTime.Now;
        }
        #endregion

        /// <summary>
        /// 获取或设置发送方ID。
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// 获取或设置发送方IP。
        /// </summary>
        public string UIP { get; set; }
        /// <summary>
        /// 获取或设置发送类型。
        /// </summary>
        public MSGKind Kind { get; set; }
        /// <summary>
        /// 获取或设置消息时间。
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Time:{0:HHmmss},", this.Time);
            if (!string.IsNullOrEmpty(this.UID))
                sb.AppendFormat("UID:{0},", this.UID);
            if (!string.IsNullOrEmpty(this.UIP))
                sb.AppendFormat("UIP:{0},", this.UIP);
            sb.AppendFormat("Kind:{0};", this.Kind);
            return sb.ToString();
        }
    }
}
