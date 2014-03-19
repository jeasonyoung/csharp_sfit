<%--
//================================================================================
// FileName: frmSysMgrWebPartPersonalEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrWebPartPersonalEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrWebPartPersonalEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrWebPartPersonalEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
 		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbWebPartName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartName">部件名称：</JWC:LabelEx>
			<JWC:PickerBase ID="pbWebPart" runat="server" Width="418px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrWebPartPicker.aspx" 
			    IsRequired="true" ErrorMessage="部件名称不能为空！"/>
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbWebPartZone" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartZone">部件位置：</JWC:LabelEx>
			<JWC:PickerBase ID="pbWebPartZone" runat="server" Width="418px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrWebPartZonePicker.aspx" 
			    IsRequired="true" ErrorMessage="部件位置不能为空！"/>
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbEmployee" runat="server" Style="float:left;" meta:resourcekey="Sys_Employee">所属用户：</JWC:LabelEx>
			<JWC:PickerBase ID="pbEmployee" runat="server" Width="180px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrOrgPicker.aspx?IsLocal=False" />
			<span style="float:left; color:Red;">[为空时表示全局]</span>
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbOrderNo" runat="server" Style="float:left;" meta:resourcekey="Sys_OrderNo">呈现顺序：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtOrderNo" runat="server" Width="80px" OnlyNumber="true"  Text="1" IsRequired="true" RequiredErrorMessage="呈现顺序不能为空！" />
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
