//================================================================================
//  FileName: MonitorColorSettings.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/1
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
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 监控界面颜色设置。
    /// </summary>
    [Serializable]
    public class MonitorUIColorSettings : IXmlSerializable
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public MonitorUIColorSettings()
        {
            this.OnlineColor = Color.Green;
            this.OfflineColor = Color.Transparent;
            this.UploadColor = Color.Blue;
            this.OfflineUploadColor = Color.CadetBlue;
            this.MoveColor = Color.Violet;
            this.ReviewColor = Color.BlueViolet;
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置在线颜色。
        /// </summary>
        public Color OnlineColor { get; set; }
        /// <summary>
        /// 获取或设置离线颜色。
        /// </summary>
        public Color OfflineColor { get; set; }
        /// <summary>
        /// 获取或设置上传时颜色。
        /// </summary>
        public Color UploadColor { get; set; }
        /// <summary>
        /// 获取或设置上传离线后的颜色。
        /// </summary>
        public Color OfflineUploadColor { get; set; }
        /// <summary>
        /// 获取或设置鼠标移动颜色。
        /// </summary>
        public Color MoveColor { get; set; }
        /// <summary>
        /// 获取或设置已批阅颜色。
        /// </summary>
        public Color ReviewColor { get; set; }
        #endregion

        #region 序列化与反序列化。
        /// <summary>
        /// 序列化。
        /// </summary>
        /// <param name="data"></param>
        public static void Serializer(MonitorUIColorSettings data)
        {
            if (data != null)
            {
                string path = FolderStructure.MonitorUIColorSettingsFile;
                UtilTools.Serializer<MonitorUIColorSettings>(data, path);
            }
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <returns></returns>
        public static MonitorUIColorSettings DeSerializer()
        {
            string path = FolderStructure.MonitorUIColorSettingsFile;
            MonitorUIColorSettings data = UtilTools.DeSerializer<MonitorUIColorSettings>(path);
            if (data == null)
                data = new MonitorUIColorSettings();
            return data;
        }
        #endregion
        
        #region IXmlSerializable 成员

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("MonitorUIColorSettings");
            try
            {
                this.OnlineColor = this.ReadXmlElement(reader, "OnlineColor");
            }
            catch (Exception) { }
            try
            {
                this.OfflineColor = this.ReadXmlElement(reader, "OfflineColor");
            }
            catch (Exception) { }
            try
            {
                this.UploadColor = this.ReadXmlElement(reader, "UploadColor");
            }
            catch (Exception) { }
            try
            {
                this.OfflineUploadColor = this.ReadXmlElement(reader, "OfflineUploadColor");
            }
            catch (Exception) { }
            try
            {
                this.MoveColor = this.ReadXmlElement(reader, "MoveColor");
            }
            catch (Exception) { }
            try
            {
                this.ReviewColor = this.ReadXmlElement(reader, "ReviewColor");
            }
            catch (Exception) { }
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            this.CreateXmlElement(writer, "OnlineColor", this.OnlineColor);
            this.CreateXmlElement(writer, "OfflineColor", this.OfflineColor);
            this.CreateXmlElement(writer, "UploadColor", this.UploadColor);
            this.CreateXmlElement(writer, "OfflineUploadColor", this.OfflineUploadColor);
            this.CreateXmlElement(writer, "MoveColor", this.MoveColor);
            this.CreateXmlElement(writer, "ReviewColor", this.ReviewColor);
        }

        #endregion

        #region 辅助函数。
        void CreateXmlElement(XmlWriter writer, string name, Color color)
        {
            if (!string.IsNullOrEmpty(name))
            {
                writer.WriteStartElement(name);
                writer.WriteString(string.Format("{0},{1},{2},{3}", color.A, color.R, color.G, color.B));
                writer.WriteEndElement();
            }
        }
        Color ReadXmlElement(XmlReader reader, string name)
        {
            string s = reader.ReadElementContentAsString(name, string.Empty);
            if (!string.IsNullOrEmpty(s))
            {
                try
                {
                    string[] buf = s.Split(',');
                    if (buf != null && buf.Length == 4)
                    {
                        return Color.FromArgb(Convert.ToInt32(buf[0], 10), Convert.ToInt32(buf[1], 10), Convert.ToInt32(buf[2], 10), Convert.ToInt32(buf[3], 10));
                    }
                }
                catch (Exception) { }
            }
            return Color.Transparent;
        }
        #endregion
    }
}
