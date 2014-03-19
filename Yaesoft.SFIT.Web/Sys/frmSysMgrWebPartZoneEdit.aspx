<%--
//================================================================================
// FileName: frmSysMgrWebPartZoneEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrWebPartZoneEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrWebPartZoneEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrWebPartZoneEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbZoneName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartZoneName">����λ�����ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtZoneName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="����λ�����Ʋ���Ϊ�գ�" />
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbAppSystem" runat="server" Style="float:left;" meta:resourcekey="Sys_AppSystem">ѡ������ϵͳ��</JWC:LabelEx>
			<JWC:PickerBase ID="pbAppSystem" runat="server" Width="280px" PickerHeight="420px" PickerWidth="320px" 
			    MultiSelect="false" PickerPage="frmSysMgrAppAuthorizationPicker.aspx"/>
			<span style="float:left; color:Red;">[Ϊ��ʱ��ʾȫ��]</span>
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbZoneMode" runat="server" Style="float:left;" meta:resourcekey="Sys_ZoneMode">��&nbsp;&nbsp;ʾ&nbsp;&nbsp;&nbsp;λ&nbsp;&nbsp;&nbsp;�ã�</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlZoneMode" runat="server" ShowUnDefine="false" Width="80px"  />
		</div>
		
		<div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbZoneLength" runat="server" Style="float:left;" meta:resourcekey="Sys_ZoneLength">�����ʾ��Ŀ��</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtZoneLength" runat="server" Width="80px" OnlyNumber="true"  Text="0" IsRequired="true" RequiredErrorMessage="�����ʾ��Ŀ����Ϊ�գ�Ϊ0�����ƣ�" />
			<span style="float:left;color:Red;">[Ϊ0ʱ��ʾ������]</span>
		</div>
		<div style="float:left;">
			<JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartZoneDescription">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtDescription" runat="server" Width="418px" TextMode="MultiLine" Rows="3"  />
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
