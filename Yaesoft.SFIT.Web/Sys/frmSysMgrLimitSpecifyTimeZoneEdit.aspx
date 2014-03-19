<%--
//================================================================================
// FileName: frmSysMgrLimitSpecifyTimeZoneEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrLimitSpecifyTimeZoneEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrLimitSpecifyTimeZoneEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrLimitSpecifyTimeZoneEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbEmployeeName" runat="server" Style="float:left;" meta:resourcekey="Sys_EmployeeName">用户名称：</JWC:LabelEx>
			<JWC:PickerBase ID="pbEmployee" runat="server" Width="268px" PickerHeight="450px" PickerWidth="340px" ToolTip="[为空时表示全局]"
			MultiSelect="false" PickerPage="frmSysMgrOrgPicker.aspx?IsLocal=True"/>
			<span style="float:left; color:Red;">[为空时表示全局]</span>
		</div>
		
		<div style="float:left;">
			<JWC:LabelEx ID="lbStartTime" runat="server" Style="float:left;" meta:resourcekey="Sys_StartTime">起始时间：</JWC:LabelEx>
			<JWC:TextBoxCalendar ID="txtStartTime" runat="server" Width="168px" IsRequired="true" ErrorMessage="起始时间不能为空！" />
		</div>
		
		<div style="float:left;">
			<JWC:LabelEx ID="lbEndTime" runat="server" Style="float:left;" meta:resourcekey="Sys_EndTime">结束时间：</JWC:LabelEx>
			<JWC:TextBoxCalendar ID="txtEndTime" runat="server" Width="168px" IsRequired="true" ErrorMessage="结束时间不能为空！" />
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbAuthStatus" runat="server" Style="float:left;" meta:resourcekey="Sys_AuthStatus">授权状态：</JWC:LabelEx>
			<JWC:RadioButtonListEx ID="rdAuthStatus" runat="server" Width="168px" RepeatLayout="Table" RepeatDirection="Horizontal" IsRequired="true" ErrorMessage="授权状态不能为空！" />
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
