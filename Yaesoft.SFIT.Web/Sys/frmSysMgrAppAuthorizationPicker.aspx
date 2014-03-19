<%--
//================================================================================
// FileName: frmSysMgrWebPartZoneList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrAppAuthorizationPicker.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrAppAuthorizationPicker" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>

<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrAppAuthorizationPicker" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--查询条件-->
    <div class="TableSearch">
        <div style="float:left;">
            <JWC:LabelEx ID="lbAppName" runat="server" Style="float:left;" meta:resourcekey="Sys_AppName">系统名称：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtAppName" runat="server" Width="148px" />
        </div>
       <div style="float:right;">
            <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_OnClick" />
       </div>
    </div>
    <!--数据显示-->
    <div class="TableSearch">
         <asp:ListBox ID="listSingleSelect" runat="server" Width="100%" Height="270px" SelectionMode="Single" />
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
