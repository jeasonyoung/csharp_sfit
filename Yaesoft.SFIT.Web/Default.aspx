<%--
//================================================================================
//  FileName: Default.aspx
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameMasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Yaesoft.SFIT.Web.Default" %>

<asp:Content ID="WorkContent" ContentPlaceHolderID="MainPlace" runat="server">
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
        <asp:Panel ID="leftPanel" runat="server" CssClass="WebPartPanel"/>
        <asp:Panel ID="middlePanel" runat="server" CssClass="WebPartPanel"/>
        <asp:Panel ID="rightPanel" runat="server" CssClass="WebPartPanel"/>
    </div>
</asp:Content>