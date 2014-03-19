<%--
//================================================================================
// FileName: frmSecurityRoleDepartmentEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityRoleDepartmentEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRoleDepartmentEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.TreeView" tagprefix="JWC" %>

<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityRoleDepartmentEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
	    <div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbRole" runat="server" Style="float:left;" meta:resourcekey="Sec_Role">角色名称：</JWC:LabelEx>
		    <JWC:PickerBase ID="pbRole" runat="server" Width="268px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSecurityRolePicker.aspx" 
		     AutoPostBack="true" OnTextChanged="pbRole_OnTextChanged" IsRequired="true" ErrorMessage="角色名称不能为空！" />
	    </div>
	    <div style="float:left;width:100%;">
	        <fieldset style="width:96%; height:460px;">
	            <legend>
	                <JWC:LabelEx ID="lbDepartment" runat="server" Style="float:left;" meta:resourcekey="Sec_Department">所有部门</JWC:LabelEx>
	            </legend>
	            <JWC:TreeView ID="tvDepartment" runat="server" ExpandAllLevel="true" ShowScrollBar="true" CheckType="CheckBox" />
	        </fieldset>
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
