<%--
//================================================================================
// FileName: frmSSOTicketEdit.aspx
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
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
	
	<!--数据录入区域-->
	<div class="TableSearch">
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbToken" runat="server" Style="float:left;" meta:resourcekey="Sys_Token">令&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;牌：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtToken" runat="server" Width="418px" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbUserData" runat="server" Style="float:left;" meta:resourcekey="Sys_UserData">用户信息：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtUserData" runat="server" Width="418px"  />
		</div>
		
		<div style="float:left;width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbIssueDate" runat="server" Style="float:left;" meta:resourcekey="Sys_IssueDate">创建时间：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtIssueDate" runat="server" Width="168px" />
		    </div>
		    <div style="float:left;margin-left:13px;">
			    <JWC:LabelEx ID="lbExpiration" runat="server" Style="float:left;" meta:resourcekey="Sys_Expiration">失效时间：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtExpiration" runat="server" Width="168px"  />
		    </div>
		</div>
		
		<div style="float:left;width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbIssueClientIP" runat="server" Style="float:left;" meta:resourcekey="Sys_IssueClientIP">创&nbsp;&nbsp;建&nbsp;&nbsp;IP：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtIssueClientIP" runat="server" Width="168px"  />
		    </div>
		    <div style="float:left;margin-left:14px;">
			    <JWC:LabelEx ID="lbLastRenewalIP" runat="server" Style="float:left;" meta:resourcekey="Sys_LastRenewalIP">续&nbsp;约&nbsp;&nbsp;I&nbsp;P：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtLastRenewalIP" runat="server" Width="168px"  />
		    </div>
		</div>
		
		<div style="float:left;width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbRenewalCount" runat="server" Style="float:left;" meta:resourcekey="Sys_RenewalCount">续约次数：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtRenewalCount" runat="server" Width="168px"  />
		    </div>
    		
		    <div style="float:left;margin-left:13px;">
			    <JWC:LabelEx ID="lbHasValid" runat="server" Style="float:left;" meta:resourcekey="Sys_HasValid">是否有效：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtHasValid" runat="server" Width="168px"  />
		    </div>
		</div>
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
		    <JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
