<%--
//================================================================================
// FileName: frmSecurityRoleEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityRoleEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRoleEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.TreeView" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityRoleEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbRoleName" runat="server" Style="float:left;" meta:resourcekey="Sec_RoleName">��ɫ���ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtRoleName" runat="server" Width="228px" IsRequired="true" RequiredErrorMessage="��ɫ���Ʋ���Ϊ�գ�" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbParentRoleID" runat="server" Style="float:left;" meta:resourcekey="Sec_ParentRoleID">�ϼ���ɫ��</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlParentRoleID" runat="server" ShowUnDefine="true" ShowTreeView="true" Width="228px"  />
		</div>
		
		<div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbRoleStatus" runat="server" Style="float:left;" meta:resourcekey="Sec_RoleStatus">��ɫ״̬��</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlRoleStatus" runat="server" ShowUnDefine="true" Width="228px" IsRequired="true" ErrorMessage="��ɫ״̬����Ϊ�գ�" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbRoleDescription" runat="server" Style="float:left;" meta:resourcekey="Sec_RoleDescription">��ɫ������</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtRoleDescription" runat="server" Width="228px" TextMode="MultiLine" Rows="3"  />
		</div>
		<div style="float:left;width:100%;">
		    <fieldset>
		        <legend>
		            <JWC:LabelEx ID="lbSystem" runat="server" Style="float:left;" meta:resourcekey="Sec_System">����ϵͳ</JWC:LabelEx>
		        </legend>
		        <div style="float:left; height:230px; overflow:auto;">
		            <JWC:TreeView ID="tvSystem" runat="server" CheckType="CheckBox" />
		        </div>
		    </fieldset>
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
