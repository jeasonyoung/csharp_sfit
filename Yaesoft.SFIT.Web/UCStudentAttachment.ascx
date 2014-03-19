<%--
//================================================================================
//  FileName: UCStudentAttachment.ascx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/28
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
//--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStudentAttachment.ascx.cs" Inherits="Yaesoft.SFIT.Web.UCStudentAttachment" %>
<%@ Import Namespace="Yaesoft.SFIT.Engine.Service" %>
<fieldset style="margin-top:2px;">
    <legend>作品附件</legend>
    <div style="float:left;width:100%; height:40px; overflow:auto;">
        <%Attachments attachments = this.WorkAttachments;
          if (attachments != null && attachments.Count > 0)
          {%>
          <ul style="float:left; margin:0; list-style-type:decimal; list-style-position:inside; text-align:left;">
            <%foreach (AttachmentInfo info in attachments)
              { %>
                  <li>
                    <a target="_blank" href='AccessoriesDownload.ashx?FileID=<%=info.FileID %>'><%=info.FileName%></a>
                  </li>
            <%} %>
          </ul>
        <%} %>
    </div>
</fieldset>