<%--
//================================================================================
//  FileName: frmLogout.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/7/1
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
<%@ Page Title="" Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmLogout.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmLogout" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>

<asp:Content ID="content" ContentPlaceHolderID="workPlace" runat="server">
    <div>
        <JWC:ServerAlert ID="errMsg" runat="server" />
    </div>
</asp:Content>
