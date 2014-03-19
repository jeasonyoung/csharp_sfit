//================================================================================
//  FileName: CDATA.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-11-21
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
using System.Xml;
using System.Xml.Serialization;
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// CDATA
    /// </summary>
    [Serializable]
    public class CDATA : IComparable, IFormattable, IComparable<CDATA>, IEquatable<CDATA>, IXmlSerializable
    {
        #region 成员变量，构造函数。
        string value = string.Empty;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public CDATA()
        {
             
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="value"></param>
        public CDATA(string value)
        {
            this.Value = value;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置值。
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.value = CDATA.ReplaceLowOrderASCIICharacters(value);
                }
                else
                {
                    this.value = null;
                }
            }
        }
        #endregion

        #region IXmlSerializable 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            string s = reader.ReadInnerXml();
            if (!string.IsNullOrEmpty(s))
            {
                string startTag = "<![CDATA[";
                string endTag = "]]>";
                char[] trims = new char[] { '\r', '\n', '\t', ' ' };
                s = s.Trim(trims);
                if (s.StartsWith(startTag) && s.EndsWith(endTag))
                {
                    s = s.Substring(startTag.Length, s.LastIndexOf(endTag) - startTag.Length);
                }
                this.value = s;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteCData(this.Value);
        }

        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Value;
        }
        #endregion

        #region IComparable 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                return string.Compare(this.Value, obj.ToString());
            }
            return -1;
        }

        #endregion

        #region IFormattable 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format) || (formatProvider == null))
            {
                return this.Value;
            }
            return string.Format(formatProvider, format, this.Value);
        }

        #endregion

        #region IComparable<CDATA> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int CompareTo(CDATA o)
        {
            if (o != null)
            {
                return string.Compare(this.Value, o.Value);
            }
            return -1;
        }

        #endregion

        #region IEquatable<CDATA> 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool Equals(CDATA o)
        {
            if (o != null)
            {
                return string.Equals(this.Value, o.Value, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        #endregion

        #region 静态函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static implicit operator string(CDATA data)
        {
            return data.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static implicit operator CDATA(string data)
        {
            return new CDATA(data);
        }
        /// <summary>
        /// 把一个字符串中的 低序位 ASCII 字符 替换成字符
        /// 转换  ASCII  0 - 8  ->
        /// 转换  ASCII 11 - 12 ->
        /// ASCII 14 - 31 ->
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ReplaceLowOrderASCIICharacters(string source)
        {
            StringBuilder info = new StringBuilder();
            if (!string.IsNullOrEmpty(source))
            {
                foreach (char c in source)
                {
                    int s = (int)c;
                    if ((s >= 0 && s <= 8) || (s >= 11 && s <= 12) || (s >= 14 && s <= 31))
                    {
                        info.AppendFormat("{0:X}", s);
                    }
                    else
                    {
                        info.Append(c);
                    }
                }
            }
            return info.ToString();
        }
        #endregion
    }
}
