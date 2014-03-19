<%--
//================================================================================
// FileName: frmSecurityRightEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityRightEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRightEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityRightEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemID">����ϵͳ��</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlSystemID" runat="server" ShowUnDefine="true" Width="198px" AutoPostBack="true" OnSelectedIndexChanged="ddlSystemID_OnSelectedIndexChanged"
			         IsRequired="true" ErrorMessage="����ϵͳ����Ϊ�գ�" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbModuleID" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleID">ϵͳģ�飺</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlModuleID" runat="server" ShowUnDefine="true" ShowTreeView="true" AutoPostBack="true" OnSelectedIndexChanged="ddlModuleID_OnSelectedIndexChanged"
			 Width="198px" IsRequired="true" ErrorMessage="ϵͳģ�鲻��Ϊ�գ�"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbActionID" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionID">Ԫ&nbsp;&nbsp;��&nbsp;&nbsp;����</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlActionID" runat="server" ShowUnDefine="true" Width="198px" AutoPostBack="true" OnSelectedIndexChanged="ddlActionID_OnSelectedIndexChanged"
			IsRequired="true" ErrorMessage="Ԫ��������Ϊ�գ�" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbRightName" runat="server" Style="float:left;" meta:resourcekey="Sec_RightName">Ȩ�����ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtRightName" runat="server" Width="198px" IsRequired="true" RequiredErrorMessage="Ȩ�����Ʋ���Ϊ�գ�"  />
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
