<%--
//================================================================================
//  FileName: frmSecurityRolePicker.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/4/6
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSecurityRolePicker.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRolePicker" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>

<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx id="vsfrmSecurityRolePicker" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
   
	<!--查询条件-->
    <div class="TableSearch">
        <div style="float:left;">
            <JWC:LabelEx ID="lbRoleName" runat="server" Style="float:left;" meta:resourcekey="Sec_RoleName">角色名称：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtRoleName" runat="server" Width="168px" />
        </div>
       <div style="float:right;">
            <JWC:ButtonEx ID="btnRoleSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnRoleSearch_OnClick" />
       </div>
    </div>
    <!--数据显示-->
    <div class="TableSearch" style="text-align:center;">
         <asp:ListBox ID="listRoleSingleSelect" runat="server" Width="100%" Height="270px" SelectionMode="Single" />
    </div>
     <!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="false"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
