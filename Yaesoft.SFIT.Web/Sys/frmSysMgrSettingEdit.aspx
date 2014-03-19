<%--
//================================================================================
// FileName: frmSysMgrSettingEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrSettingEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrSettingEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrSettingEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbAppSystem" runat="server" Style="float:left;" meta:resourcekey="Sys_AppSystem">����ϵͳ��</JWC:LabelEx>
			<JWC:PickerBase ID="pbAppSystem" runat="server" Width="432px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrAppAuthorizationPicker.aspx" 
			    IsRequired="true" ErrorMessage="����ϵͳ����Ϊ�գ�"/>
		</div>
		
		<div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbSettingSign" runat="server" Style="float:left;" meta:resourcekey="Sys_SettingSign">��&nbsp;&nbsp;��&nbsp;&nbsp;����</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSettingSign" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="����������Ϊ�գ�"  />
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbDefaultValue" runat="server" Style="float:left;" meta:resourcekey="Sys_DefaultValue">Ĭ&nbsp;&nbsp;��&nbsp;&nbsp;ֵ��</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtDefaultValue" runat="server" Width="418px"  />
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbSettingType" runat="server" Style="float:left;" meta:resourcekey="Sys_SettingType">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�ͣ�</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlSettingType" runat="server" Width="80px" ShowUnDefine="false"  />
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="Sys_Description">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtDescription" runat="server" Width="418px" TextMode="MultiLine" Rows="3"  />
		</div>
	</div>
	<!--���ݿ�������-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
		    <JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="��ȷ���������ݣ�" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
