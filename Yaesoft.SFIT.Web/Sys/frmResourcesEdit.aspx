<%--
//================================================================================
// FileName: frmResourcesEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmResourcesEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmResourcesEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmResourcesEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbResKey" runat="server" Style="float:left;" meta:resourcekey="Sys_ResKey">资源键名：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtResKey" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="资源键名不能为空！" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbResValue" runat="server" Style="float:left;" meta:resourcekey="Sys_ResValue">资源键值：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtResValue" runat="server" Width="418px"  IsRequired="true" RequiredErrorMessage="资源键值不能为空！"/>
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="Sys_Description">资源描述：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtDescription" runat="server" Width="418px"  TextMode="MultiLine" Rows="3" />
		</div>
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
		    <JWC:ServerAlert ID="errMsg" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
