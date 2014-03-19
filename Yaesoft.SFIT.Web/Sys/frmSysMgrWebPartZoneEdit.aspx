<%--
//================================================================================
// FileName: frmSysMgrWebPartZoneEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrWebPartZoneEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrWebPartZoneEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrWebPartZoneEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbZoneName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartZoneName">部件位置名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtZoneName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="部件位置名称不能为空！" />
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbAppSystem" runat="server" Style="float:left;" meta:resourcekey="Sys_AppSystem">选择所属系统：</JWC:LabelEx>
			<JWC:PickerBase ID="pbAppSystem" runat="server" Width="280px" PickerHeight="420px" PickerWidth="320px" 
			    MultiSelect="false" PickerPage="frmSysMgrAppAuthorizationPicker.aspx"/>
			<span style="float:left; color:Red;">[为空时表示全局]</span>
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbZoneMode" runat="server" Style="float:left;" meta:resourcekey="Sys_ZoneMode">显&nbsp;&nbsp;示&nbsp;&nbsp;&nbsp;位&nbsp;&nbsp;&nbsp;置：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlZoneMode" runat="server" ShowUnDefine="false" Width="80px"  />
		</div>
		
		<div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbZoneLength" runat="server" Style="float:left;" meta:resourcekey="Sys_ZoneLength">最大显示数目：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtZoneLength" runat="server" Width="80px" OnlyNumber="true"  Text="0" IsRequired="true" RequiredErrorMessage="最大显示数目不能为空，为0不限制！" />
			<span style="float:left;color:Red;">[为0时表示不限制]</span>
		</div>
		<div style="float:left;">
			<JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartZoneDescription">描&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;述：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtDescription" runat="server" Width="418px" TextMode="MultiLine" Rows="3"  />
		</div>
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</div>
</asp:Content>
