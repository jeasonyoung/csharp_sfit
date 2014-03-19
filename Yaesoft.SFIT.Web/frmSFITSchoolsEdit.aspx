<%--
//================================================================================
// FileName: frmSFITSchoolsEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITSchoolsEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITSchoolsEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITSchoolsEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--数据录入区域-->
	<div class="TableSearch">
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbSchoolCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolCode">学校代码：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSchoolCode" runat="server" Width="286px"  IsRequired="true" RequiredErrorMessage="学校代码不能为空！"/>
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSchoolName" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolName">学校名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="286px"  IsRequired="true" RequiredErrorMessage="学校名称不能为空！"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSchoolType" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolTypeName">学校类型：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlSchoolType" runat="server" Width="80px" IsRequired="true" ErrorMessage="学校类型不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">排&nbsp;&nbsp;序&nbsp;&nbsp;号：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtOrderNO" runat="server"  CssClass="NumberTextBoxFlat" OnlyNumber="true" Width="80px" Text="1" IsRequired="true" RequiredErrorMessage="排序号不能为空！"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSyncStatus" runat="server" Style="float:left;" meta:resourcekey="SFIT_SyncStatus">同步状态：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlSyncStatus" runat="server" Width="80px" IsRequired="true" ErrorMessage="同步状态不能为空！" />
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
