<%--
//================================================================================
// FileName: frmSecurityRoleEmployeeEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityRoleEmployeeEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRoleEmployeeEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityRoleEmployeeEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbRole" runat="server" Style="float:left;" meta:resourcekey="Sec_Role">��ɫ���ƣ�</JWC:LabelEx>
			<JWC:PickerBase ID="pbRole" runat="server" Width="268px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSecurityRolePicker.aspx" 
			 AutoPostBack="true" OnTextChanged="pbRole_OnTextChanged" IsRequired="true" ErrorMessage="��ɫ���Ʋ���Ϊ�գ�" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbEmployee" runat="server" Style="float:left;" meta:resourcekey="Sec_Employee">�û����ƣ�</JWC:LabelEx>
			<JWC:PickerBase ID="pbEmployee" runat="server" Width="418px" PickerHeight="470px" PickerWidth="340px" MultiSelect="true" PickerPage="frmSecurityEmployeePicker.aspx" 
			   TextBoxMode="MultiLine" Rows="3" />
		</div>
	</div>
	<!--���ݿ�������-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="��ȷ���������ݣ�" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
