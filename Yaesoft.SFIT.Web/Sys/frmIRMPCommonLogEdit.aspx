<%--
//================================================================================
// FileName: frmIRMPCommonLogEdit.aspx
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
//--%>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmIRMPCommonLogEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmIRMPCommonLogEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmIRMPCommonLogEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
	    <div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemName" runat="server" Style="float:left;" meta:resourcekey="Sys_SystemName">系统名称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSystemName" runat="server" Width="170px"  />
		    </div>
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbRelationTable" runat="server" Style="float:left;" meta:resourcekey="Sys_RelationTable">操&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;作：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtRelationTable" runat="server" Width="170px"  />
		    </div>
		</div>
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbCreateEmployeeName" runat="server" Style="float:left;" meta:resourcekey="Sys_SystemName">用户名称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtCreateEmployeeName" runat="server" Width="170px"  />
		    </div>
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbCreateDate" runat="server" Style="float:left;" meta:resourcekey="Sys_CreateDate">创建日期：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtCreateDate" runat="server" Width="170px"  />
		    </div>
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbLogContext" runat="server" Style="float:left;" meta:resourcekey="Sys_LogContext">日志内容：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtLogContext" runat="server" Width="418px" TextMode="MultiLine" Rows="6" />
		</div>
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
