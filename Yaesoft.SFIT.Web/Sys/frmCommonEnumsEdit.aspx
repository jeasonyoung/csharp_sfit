<%--
//================================================================================
// FileName: frmCommonEnumsEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmCommonEnumsEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmCommonEnumsEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmCommonEnumsEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbEnumName" runat="server" Style="float:left;" meta:resourcekey="Sys_EnumName">ö�����ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtEnumName" runat="server" Width="168px" Enabled="false" RequiredErrorMessage="ö�����Ʋ���Ϊ�գ�" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbFullEnumName" runat="server" Style="float:left;" meta:resourcekey="Sys_FullEnumName">ö��ȫ�ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtFullEnumName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="ö��ȫ�Ʋ���Ϊ�գ�" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbMember" runat="server" Style="float:left;" meta:resourcekey="Sys_Member">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtMember" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="��������Ϊ�գ�" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbMemberName" runat="server" Style="float:left;" meta:resourcekey="Sys_MemberName">��&nbsp;&nbsp;��&nbsp;&nbsp;����</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtMemberName" runat="server" Width="168px"  IsRequired="true" RequiredErrorMessage="����������Ϊ�գ�" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbIntValue" runat="server" Style="float:left;" meta:resourcekey="Sys_IntValue">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ֵ��</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtIntValue" runat="server" Width="168px"  OnlyNumber="true" IsRequired="true" RequiredErrorMessage="��ֵ����Ϊ�գ�"/>
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbOrderNo" runat="server" Style="float:left;" meta:resourcekey="Sys_OrderNo">��&nbsp;&nbsp;��&nbsp;&nbsp;�ţ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtOrderNo" runat="server" Width="168px" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="����Ų���Ϊ�գ�" />
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
