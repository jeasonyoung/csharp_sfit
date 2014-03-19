<%--
//================================================================================
// FileName: frmSFITCenterAccessEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITCenterAccessEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITCenterAccessEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITCenterAccessEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbSchoolName" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolName">学校名称：</JWC:LabelEx>
			<JWC:PickerBase ID="pbSchool" runat="server" Width="370px" PickerPage="frmSFITSchoolPicker.aspx" PickerHeight="400px" PickerWidth="300px" MultiSelect="false"
			      IsRequired="true" ErrorMessage="学校名称不能为空！" OnTextChanged="pbSchool_OnTextChanged" AutoPostBack="true" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbAccessAccount" runat="server" Style="float:left;" meta:resourcekey="SFIT_AccessAccount">接入账号：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtAccessAccount" runat="server" Width="368px" IsRequired="true" RequiredErrorMessage="接入账号不能为空！"/>
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbAccessPassword" runat="server" Style="float:left;" meta:resourcekey="SFIT_AccessPassword">接入密码：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtAccessPassword" runat="server" Width="368px" IsRequired="true" RequiredErrorMessage="接入密码不能为空！"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbAccessStatus" runat="server" Style="float:left;" meta:resourcekey="SFIT_AccessStatus">访问状态：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlAccessStatus" runat="server" Width="80px" IsRequired="true" ErrorMessage="访问状态不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="SFIT_Description">描&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;述：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtDescription" runat="server" Width="368px" TextMode="MultiLine" Rows="3"  />
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
