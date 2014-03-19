//================================================================================
//  FileName: AnswerMSG.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/5
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
    /// 应答消息。
    /// </summary>
    [Serializable]
    public class Answer : Msg
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="messge"></param>
        public Answer(MSGKind source, string messge)
        {
            this.Kind = MSGKind.Answer;
            this.SourceKind = source;
            this.Message = messge;
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="source"></param>
        public Answer(MSGKind source)
            : this(source, string.Empty)
        {
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Answer()
            : this(MSGKind.None)
        {
        }
        #endregion

        /// <summary>
        /// 获取或设置应答的消息类型。
        /// </summary>
        public MSGKind SourceKind { get; set; }
        /// <summary>
        /// 获取或设置传递信息。
        /// </summary>
        public string Message { get; set; }
    }
}
