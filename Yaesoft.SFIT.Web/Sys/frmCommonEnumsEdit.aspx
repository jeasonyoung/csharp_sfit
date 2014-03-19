<%--
//================================================================================
// FileName: frmCommonEnumsEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmCommonEnumsEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmCommonEnumsEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmCommonEnumsEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbEnumName" runat="server" Style="float:left;" meta:resourcekey="Sys_EnumName">枚举名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtEnumName" runat="server" Width="168px" Enabled="false" RequiredErrorMessage="枚举名称不能为空！" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbFullEnumName" runat="server" Style="float:left;" meta:resourcekey="Sys_FullEnumName">枚举全称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtFullEnumName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="枚举全称不能为空！" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbMember" runat="server" Style="float:left;" meta:resourcekey="Sys_Member">键&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtMember" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="键名不能为空！" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbMemberName" runat="server" Style="float:left;" meta:resourcekey="Sys_MemberName">中&nbsp;&nbsp;文&nbsp;&nbsp;名：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtMemberName" runat="server" Width="168px"  IsRequired="true" RequiredErrorMessage="中文名不能为空！" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbIntValue" runat="server" Style="float:left;" meta:resourcekey="Sys_IntValue">键&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;值：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtIntValue" runat="server" Width="168px"  OnlyNumber="true" IsRequired="true" RequiredErrorMessage="键值不能为空！"/>
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbOrderNo" runat="server" Style="float:left;" meta:resourcekey="Sys_OrderNo">排&nbsp;&nbsp;序&nbsp;&nbsp;号：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtOrderNo" runat="server" Width="168px" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="排序号不能为空！" />
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
