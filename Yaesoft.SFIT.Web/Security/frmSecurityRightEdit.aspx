<%--
//================================================================================
// FileName: frmSecurityRightEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityRightEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRightEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityRightEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemID">所属系统：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlSystemID" runat="server" ShowUnDefine="true" Width="198px" AutoPostBack="true" OnSelectedIndexChanged="ddlSystemID_OnSelectedIndexChanged"
			         IsRequired="true" ErrorMessage="所属系统不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbModuleID" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleID">系统模块：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlModuleID" runat="server" ShowUnDefine="true" ShowTreeView="true" AutoPostBack="true" OnSelectedIndexChanged="ddlModuleID_OnSelectedIndexChanged"
			 Width="198px" IsRequired="true" ErrorMessage="系统模块不能为空！"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbActionID" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionID">元&nbsp;&nbsp;操&nbsp;&nbsp;作：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlActionID" runat="server" ShowUnDefine="true" Width="198px" AutoPostBack="true" OnSelectedIndexChanged="ddlActionID_OnSelectedIndexChanged"
			IsRequired="true" ErrorMessage="元操作不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbRightName" runat="server" Style="float:left;" meta:resourcekey="Sec_RightName">权限名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtRightName" runat="server" Width="198px" IsRequired="true" RequiredErrorMessage="权限名称不能为空！"  />
		</div>
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
		    <JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
