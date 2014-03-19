<%--
//================================================================================
// FileName: frmSysMgrLimitSpecifyTimeZoneEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrLimitSpecifyTimeZoneEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrLimitSpecifyTimeZoneEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrLimitSpecifyTimeZoneEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbEmployeeName" runat="server" Style="float:left;" meta:resourcekey="Sys_EmployeeName">�û����ƣ�</JWC:LabelEx>
			<JWC:PickerBase ID="pbEmployee" runat="server" Width="268px" PickerHeight="450px" PickerWidth="340px" ToolTip="[Ϊ��ʱ��ʾȫ��]"
			MultiSelect="false" PickerPage="frmSysMgrOrgPicker.aspx?IsLocal=True"/>
			<span style="float:left; color:Red;">[Ϊ��ʱ��ʾȫ��]</span>
		</div>
		
		<div style="float:left;">
			<JWC:LabelEx ID="lbStartTime" runat="server" Style="float:left;" meta:resourcekey="Sys_StartTime">��ʼʱ�䣺</JWC:LabelEx>
			<JWC:TextBoxCalendar ID="txtStartTime" runat="server" Width="168px" IsRequired="true" ErrorMessage="��ʼʱ�䲻��Ϊ�գ�" />
		</div>
		
		<div style="float:left;">
			<JWC:LabelEx ID="lbEndTime" runat="server" Style="float:left;" meta:resourcekey="Sys_EndTime">����ʱ�䣺</JWC:LabelEx>
			<JWC:TextBoxCalendar ID="txtEndTime" runat="server" Width="168px" IsRequired="true" ErrorMessage="����ʱ�䲻��Ϊ�գ�" />
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbAuthStatus" runat="server" Style="float:left;" meta:resourcekey="Sys_AuthStatus">��Ȩ״̬��</JWC:LabelEx>
			<JWC:RadioButtonListEx ID="rdAuthStatus" runat="server" Width="168px" RepeatLayout="Table" RepeatDirection="Horizontal" IsRequired="true" ErrorMessage="��Ȩ״̬����Ϊ�գ�" />
		</div>
	</div>
	<!--���ݿ�������-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
		    <JWC:ServerAlert ID="errMsg" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="��ȷ���������ݣ�" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
