<%--
//================================================================================
// FileName: frmSysMgrSettingPersonalEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrSettingPersonalEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrSettingPersonalEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrSettingPersonalEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
		<div style="float:left; width:100%">
			<JWC:LabelEx ID="lbSetting" runat="server" Style="float:left;" meta:resourcekey="Sys_Setting">所属系统参数：</JWC:LabelEx>
			<JWC:PickerBase ID="pbSetting" runat="server" Width="432px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrSettingPicker.aspx" 
			    IsRequired="true" ErrorMessage="所属系统参数不能为空！"/>
		</div>
		
		<div style="float:left; width:100%">
			<JWC:LabelEx ID="lbEmployee" runat="server" Style="float:left;" meta:resourcekey="Sys_Employee">用&nbsp;&nbsp;户&nbsp;&nbsp;&nbsp;姓&nbsp;&nbsp;&nbsp;名：</JWC:LabelEx>
			<JWC:PickerBase ID="pbEmployee" runat="server" Width="168px" PickerHeight="450px" PickerWidth="340px" MultiSelect="false" PickerPage="frmSysMgrOrgPicker.aspx?IsLocal=false"
			   AutoPostBack="true" /><span style="float:left; color:Red;">[为空时表示全局]</span>
		</div>
		
		<div style="float:left; width:100%">
			<JWC:LabelEx ID="lbSettingValue" runat="server" Style="float:left;" meta:resourcekey="Sys_SettingValue">参&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;值：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSettingValue" runat="server" Width="418px" TextMode="MultiLine" Rows="2" IsRequired="true" RequiredErrorMessage="参数值不能为空！" />
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
