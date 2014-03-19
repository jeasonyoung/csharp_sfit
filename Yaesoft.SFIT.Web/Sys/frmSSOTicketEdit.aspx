<%--
//================================================================================
// FileName: frmSSOTicketEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSSOTicketEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSSOTicketEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSSOTicketEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbToken" runat="server" Style="float:left;" meta:resourcekey="Sys_Token">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtToken" runat="server" Width="418px" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbUserData" runat="server" Style="float:left;" meta:resourcekey="Sys_UserData">�û���Ϣ��</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtUserData" runat="server" Width="418px"  />
		</div>
		
		<div style="float:left;width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbIssueDate" runat="server" Style="float:left;" meta:resourcekey="Sys_IssueDate">����ʱ�䣺</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtIssueDate" runat="server" Width="168px" />
		    </div>
		    <div style="float:left;margin-left:13px;">
			    <JWC:LabelEx ID="lbExpiration" runat="server" Style="float:left;" meta:resourcekey="Sys_Expiration">ʧЧʱ�䣺</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtExpiration" runat="server" Width="168px"  />
		    </div>
		</div>
		
		<div style="float:left;width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbIssueClientIP" runat="server" Style="float:left;" meta:resourcekey="Sys_IssueClientIP">��&nbsp;&nbsp;��&nbsp;&nbsp;IP��</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtIssueClientIP" runat="server" Width="168px"  />
		    </div>
		    <div style="float:left;margin-left:14px;">
			    <JWC:LabelEx ID="lbLastRenewalIP" runat="server" Style="float:left;" meta:resourcekey="Sys_LastRenewalIP">��&nbsp;Լ&nbsp;&nbsp;I&nbsp;P��</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtLastRenewalIP" runat="server" Width="168px"  />
		    </div>
		</div>
		
		<div style="float:left;width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbRenewalCount" runat="server" Style="float:left;" meta:resourcekey="Sys_RenewalCount">��Լ������</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtRenewalCount" runat="server" Width="168px"  />
		    </div>
    		
		    <div style="float:left;margin-left:13px;">
			    <JWC:LabelEx ID="lbHasValid" runat="server" Style="float:left;" meta:resourcekey="Sys_HasValid">�Ƿ���Ч��</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtHasValid" runat="server" Width="168px"  />
		    </div>
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
