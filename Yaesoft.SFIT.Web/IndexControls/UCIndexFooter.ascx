<%--
//================================================================================
//  FileName: UCIndexFooter.ascx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/20
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCIndexFooter.ascx.cs" Inherits="Yaesoft.SFIT.Web.IndexControls.UCIndexFooter" %>
<!--底部版权-->
<div class="footer">
 <dl>
  <dt>
   <a href="/Download/TeaSeviceSetup.msi" target="_blank" title="下载[教师客户端]">[教师客户端]</a> | 
   <a href="/Download/StuClientSetup.msi" target="_blank" title="下载[学生客户端]">[学生客户端]</a> | 
   <a href="/Download/ClientStudent.zip"  target="_blank" title="下载[学生客户端绿色分发版]">[学生客户端绿色分发版]</a> 
  </dt>
  <dd>
 	<span><%=this.CopyRight%></span>
  </dd>
 </dl>
</div>