<%--
//================================================================================
// FileName: frmIRMPCommonLogEdit.aspx
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
	
	<!--����¼������-->
	<div class="TableSearch">
	    <div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemName" runat="server" Style="float:left;" meta:resourcekey="Sys_SystemName">ϵͳ���ƣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSystemName" runat="server" Width="170px"  />
		    </div>
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbRelationTable" runat="server" Style="float:left;" meta:resourcekey="Sys_RelationTable">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtRelationTable" runat="server" Width="170px"  />
		    </div>
		</div>
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbCreateEmployeeName" runat="server" Style="float:left;" meta:resourcekey="Sys_SystemName">�û����ƣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtCreateEmployeeName" runat="server" Width="170px"  />
		    </div>
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbCreateDate" runat="server" Style="float:left;" meta:resourcekey="Sys_CreateDate">�������ڣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtCreateDate" runat="server" Width="170px"  />
		    </div>
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbLogContext" runat="server" Style="float:left;" meta:resourcekey="Sys_LogContext">��־���ݣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtLogContext" runat="server" Width="418px" TextMode="MultiLine" Rows="6" />
		</div>
	</div>
	<!--���ݿ�������-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
