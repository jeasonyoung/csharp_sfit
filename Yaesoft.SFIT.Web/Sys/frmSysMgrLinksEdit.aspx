<%--
//================================================================================
// FileName: frmSysMgrLinksEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrLinksEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrLinksEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrLinksEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
	    <div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbLinkName" runat="server" Style="float:left;" meta:resourcekey="Sys_LinkName">链接名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtLinkName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="链接名称不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbLinkUrl" runat="server" Style="float:left;" meta:resourcekey="Sys_LinkUrl">链接地址：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtLinkUrl" runat="server" Width="418px" TextMode="MultiLine" Rows="2" IsRequired="true" RequiredErrorMessage="链接地址不能为空！" />
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbEmployee" runat="server" Style="float:left;" meta:resourcekey="Sys_Employee">所属用户：</JWC:LabelEx>
			<JWC:PickerBase ID="pbEmployee" runat="server" Width="180px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrOrgPicker.aspx?IsLocal=false"
			   AutoPostBack="true" /><span style="float:left; color:Red;">[为空时表示全局]</span>
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbLinkTarget" runat="server" Style="float:left;" meta:resourcekey="Sys_LinkTarget">链接方式：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlLinkTarget" runat="server" Width="80px"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbLinkStatus" runat="server" Style="float:left;" meta:resourcekey="Sys_LinkStatus">链接状态：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlLinkStatus" runat="server" Width="80px"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbOrderNo" runat="server" Style="float:left;" meta:resourcekey="Sys_OrderNo">序&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtOrderNo" runat="server" Width="80px" OnlyNumber="true" Text="1" IsRequired="true" RequiredErrorMessage="序号不能为空！"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="Sys_Description">描&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;述：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtDescription" runat="server" Width="418px" TextMode="MultiLine" Rows="3"  />
		</div>
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</div>
</asp:Content>
