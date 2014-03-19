<%--
//================================================================================
// FileName: frmSysMgrAppAuthorizationEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrAppAuthorizationEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrAppAuthorizationEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrAppAuthorizationEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbAppSystem" runat="server" Style="float:left;" meta:resourcekey="Sys_AppSystem">系统名称：</JWC:LabelEx>
			<JWC:PickerBase ID="pbAppSystem" runat="server" Width="368px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrAppAuthorizationPicker.aspx?IsLocal=False" 
			    IsRequired="true" ErrorMessage="系统名称不能为空！"/>
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbAuthPwd" runat="server" Style="float:left;" meta:resourcekey="Sys_AuthPwd">授权密码：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtAuthPwd" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="授权密码不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbAuthStatus" runat="server" Style="float:left;" meta:resourcekey="Sys_AuthStatus">授权状态：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlAuthStatus" runat="server" Width="168px" IsRequired="true" ErrorMessage="授权状态不能为空！"/>
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
