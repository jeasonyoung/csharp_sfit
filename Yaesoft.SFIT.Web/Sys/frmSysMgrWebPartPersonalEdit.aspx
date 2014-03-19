<%--
//================================================================================
// FileName: frmSysMgrWebPartPersonalEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrWebPartPersonalEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrWebPartPersonalEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrWebPartPersonalEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
 		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbWebPartName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartName">�������ƣ�</JWC:LabelEx>
			<JWC:PickerBase ID="pbWebPart" runat="server" Width="418px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrWebPartPicker.aspx" 
			    IsRequired="true" ErrorMessage="�������Ʋ���Ϊ�գ�"/>
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbWebPartZone" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartZone">����λ�ã�</JWC:LabelEx>
			<JWC:PickerBase ID="pbWebPartZone" runat="server" Width="418px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrWebPartZonePicker.aspx" 
			    IsRequired="true" ErrorMessage="����λ�ò���Ϊ�գ�"/>
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbEmployee" runat="server" Style="float:left;" meta:resourcekey="Sys_Employee">�����û���</JWC:LabelEx>
			<JWC:PickerBase ID="pbEmployee" runat="server" Width="180px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrOrgPicker.aspx?IsLocal=False" />
			<span style="float:left; color:Red;">[Ϊ��ʱ��ʾȫ��]</span>
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbOrderNo" runat="server" Style="float:left;" meta:resourcekey="Sys_OrderNo">����˳��</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtOrderNo" runat="server" Width="80px" OnlyNumber="true"  Text="1" IsRequired="true" RequiredErrorMessage="����˳����Ϊ�գ�" />
		</div>
 	</div>
	<!--���ݿ�������-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="��ȷ���������ݣ�" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</div>
</asp:Content>
