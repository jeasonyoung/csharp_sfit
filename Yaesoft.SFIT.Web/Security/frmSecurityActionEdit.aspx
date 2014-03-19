<%--
//================================================================================
// FileName: frmSecurityActionEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityActionEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityActionEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityActionEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbParentActionID" runat="server" Style="float:left;" meta:resourcekey="Sec_ParentActionID">Ԫ������ţ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtActionID" runat="server" Width="428px"  MaxLength="32" IsRequired="true" RequiredErrorMessage="Ԫ������Ų���Ϊ�գ�" />
		</div>
		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbActionSign" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionSign">Ԫ������ʶ��</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtActionSign" runat="server" Width="168px"   IsRequired="true" RequiredErrorMessage="Ԫ������ʶ����Ϊ�գ�"/>
		    </div>
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbActionName" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionName">Ԫ�������ƣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtActionName" runat="server" Width="168px"  IsRequired="true" RequiredErrorMessage="Ԫ�������Ʋ���Ϊ�գ�" />
		    </div>
		</div>
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbActionType" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionType">Ԫ�������ͣ�</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlActionType" runat="server" Width="80px" IsRequired="true" ErrorMessage="Ԫ�����಻��Ϊ�գ�" />
	    </div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbActionDescription" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionDescription">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtActionDescription" runat="server" TextMode="MultiLine" Rows="3" Width="428px"  />
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
