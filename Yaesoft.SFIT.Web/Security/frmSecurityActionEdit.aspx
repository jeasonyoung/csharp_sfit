<%--
//================================================================================
// FileName: frmSecurityActionEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityActionEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityActionEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityActionEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbParentActionID" runat="server" Style="float:left;" meta:resourcekey="Sec_ParentActionID">元操作编号：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtActionID" runat="server" Width="428px"  MaxLength="32" IsRequired="true" RequiredErrorMessage="元操作编号不能为空！" />
		</div>
		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbActionSign" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionSign">元操作标识：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtActionSign" runat="server" Width="168px"   IsRequired="true" RequiredErrorMessage="元操作标识不能为空！"/>
		    </div>
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbActionName" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionName">元操作名称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtActionName" runat="server" Width="168px"  IsRequired="true" RequiredErrorMessage="元操作名称不能为空！" />
		    </div>
		</div>
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbActionType" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionType">元操作类型：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlActionType" runat="server" Width="80px" IsRequired="true" ErrorMessage="元操作类不能为空！" />
	    </div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbActionDescription" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionDescription">描&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;述：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtActionDescription" runat="server" TextMode="MultiLine" Rows="3" Width="428px"  />
		</div>
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
