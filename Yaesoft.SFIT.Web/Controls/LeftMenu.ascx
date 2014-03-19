<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.ascx.cs" Inherits="Yaesoft.SFIT.Web.Controls.LeftMenu" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.OutlookView" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.TreeView" tagprefix="JWC" %>

<JWC:OutlookView ID="tvMenuOutlook" Width="100%" runat="server" ShowScrollBar="true" Visible="false" />
<JWC:TreeView ID="tvMenuTree" Width="100%" runat="server" ShowScrollBar="true" Visible="false" />