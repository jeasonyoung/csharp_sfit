<%--
//================================================================================
//  FileName: DesktopCenter.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/13
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="DesktopCenter.aspx.cs" Inherits="Yaesoft.SFIT.Web.DesktopCenter" %>
<%@ Import Namespace="Yaesoft.SFIT.Engine.Service" %>

<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
   <style type="text/css">
        .WebPartPanel
        {
        	float:left;
        	width:270px;
        	height:100%;
        	margin-left:10px;
        	margin-top:5px;
        	text-align:center;
        	border:solid 0px red;
        }
    </style>
    <div style="width:100%; height:100%;">
        <% string[] accessID = CreateCredentialsPresenter.GetAccessID(this.CurrentUserID);
           if (accessID != null && accessID.Length > 0)
           { %>
        <div style="margin:0 auto;width:560px;height:400px;margin-top:60px;border:solid 1px #ccc; overflow:auto;">
            <div class="PanelUnitDataTitle" style="background-color:#ccc;">
                <span style="color:#fff;">资源下载</span>
            </div>
            
            <span class="IndexWorkItemTitle" style=" margin-top:10px; margin-left:12px; border:solid 0px red;">
                 <a href='CreateCredentials.ashx?AccessID=<%=string.Join(",", accessID) %>' target="_blank" title="下载教师机客户端访问密钥">1.下载教师机客户端访问密钥</a>
            </span>
        </div>
        <%} %>
        
        <asp:Panel ID="leftPanel" runat="server" CssClass="WebPartPanel"/>
        <asp:Panel ID="middlePanel" runat="server" CssClass="WebPartPanel"/>
        <asp:Panel ID="rightPanel" runat="server" CssClass="WebPartPanel"/>
    </div>
</asp:Content>
