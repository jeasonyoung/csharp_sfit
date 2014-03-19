<%--
//================================================================================
//  FileName: frmSFITWorksCommentsEdit.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/7
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
//--%>
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITWorksCommentsEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITWorksCommentsEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx id="vsfrmSFITWorksCommentsEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
<!--数据录入区域-->
<div class="TableSearch">
    <div style="float:left; width:100%;">
		<JWC:LabelEx ID="lbWorkName" runat="server" Style="float:left;" meta:resourcekey="SFIT_WorkName">作品名称：</JWC:LabelEx>
		<JWC:TextBoxEx ID="txtWorkName" runat="server" Width="312px" />
	</div>
	<div style="float:left; width:100%;">
		<JWC:LabelEx ID="lbStudentName" runat="server" Style="float:left;" meta:resourcekey="SFIT_StudentName">所属学生：</JWC:LabelEx>
		<JWC:TextBoxEx ID="txtStudentName" runat="server" Width="312px" />
	</div>
	<div style="float:left;">
		<JWC:LabelEx ID="lbUserName" runat="server" Style="float:left;" meta:resourcekey="SFIT_UserName">评论用户：</JWC:LabelEx>
		<JWC:TextBoxEx ID="txtUserName" runat="server" Width="128px" />
	</div>
	<div style="float:left;">
		<JWC:LabelEx ID="lbClientIP" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClientIP">用户IP：</JWC:LabelEx>
		<JWC:TextBoxEx ID="txtClientIP" runat="server" Width="128px" />
	</div>
	<div style="float:left; width:100%;">
		<JWC:LabelEx ID="lbComment" runat="server" Style="float:left;" meta:resourcekey="SFIT_Comment">评论内容：</JWC:LabelEx>
		<JWC:TextBoxEx ID="txtComment" runat="server" Width="312px" TextMode="MultiLine" Rows="5" />
	</div>
	<div style="float:left;width:100%;">
		<JWC:LabelEx ID="lbStatus" runat="server" Style="float:left;" meta:resourcekey="SFIT_Status">评论状态：</JWC:LabelEx>
		<JWC:DropDownListEx ID="ddlStatus" runat="server" Width="128px" />
	</div>
	<div style="float:left;width:100%;">
		<JWC:LabelEx ID="lbCreateDateTime" runat="server" Style="float:left;" meta:resourcekey="SFIT_CreateDateTime">评论时间：</JWC:LabelEx>
		<JWC:TextBoxEx ID="txtCreateDateTime" runat="server" Width="128px" />
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
